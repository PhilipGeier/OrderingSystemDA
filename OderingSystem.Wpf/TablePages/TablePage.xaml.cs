using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using OrderingSystem.Domain;
using OrderingSystem.Json;
using OderingSystem.Wpf.TablePages;
using OrderingSystem.Domain.Enums;
using OrderingSystem.Services;

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        private MainWindow _mainWindow;

        private readonly TableJsonLogic _tableJsonLogic;
        private readonly ItemJsonLogic _itemJsonLogic;
        private readonly BillJsonLogic _billJsonLogic;
        private readonly CompanyJsonLogic _companyJsonLogic;
        private readonly ItemRemovalJsonLogic _itemRemovalJsonLogic;

        private Table _table;

        private IDictionary<Guid, int> _leftGroupedItems;
        private IDictionary<Guid, int> _rightGroupedItems;

        private TextBlock header;

        private Grid leftGrid;
        private Grid rightGrid;

        public TablePage(string tableId, MainWindow main)
        {
            InitializeComponent();

            _mainWindow = main;

            _tableJsonLogic = new TableJsonLogic();
            _itemJsonLogic = new ItemJsonLogic();
            _billJsonLogic = new BillJsonLogic();
            _companyJsonLogic = new CompanyJsonLogic();
            _itemRemovalJsonLogic = new ItemRemovalJsonLogic();

            PrintBill.Style = Application.Current.FindResource("RoundedButton") as Style;
            RemoveItems.Style = Application.Current.FindResource("RoundedButton") as Style;
            AddItem.Style = Application.Current.FindResource("RoundedButton") as Style;

            _table = _tableJsonLogic.GetSingle(tableId);
            var items = _table.CurrentItems;

            _rightGroupedItems = new Dictionary<Guid, int>();

            _leftGroupedItems = items
                .GroupBy(x => x)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count).ToDictionary(g => g.Key, g=> g.Count);


            leftGrid = (Grid)FindName("LeftGrid");
            rightGrid = (Grid)FindName("RightGrid");

            header = (TextBlock)FindName("Header");
            
            if (char.IsDigit(_table.Label[0]))
                header.Text = $"Table {_table.Label}";
            else
                header.Text = _table.Label;

            PutItemsInLeftGrid();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.GoBack();
        }

        private void PutItemsInLeftGrid()
        {
            int leftRow = 0;
            int leftColumn = 0;

            foreach (var x in _leftGroupedItems)
            {
                var item = _itemJsonLogic.GetSingle(x.Key);

                var button = new Button();
                button.Content = $"{item.Name}\n{x.Value}";
                button.Tag = x.Key;
                button.Style = Application.Current.FindResource("RoundedButton") as Style;
                button.Click += AddItemToRightGrid;

                leftGrid.Children.Add(button);

                if (leftColumn == 5)
                {
                    leftRow++;
                    leftColumn = 0;
                }

                Grid.SetColumn(button, leftColumn);
                Grid.SetRow(button, leftRow);

                leftColumn++;    
                
                DebugDictionaries();
            }
        }

        private void PutItemsInRightGrid()
        {
            int rightRow = 0;
            int rightColumn = 0;

            foreach (var x in _rightGroupedItems)
            {
                var item = _itemJsonLogic.GetSingle(x.Key);

                var button = new Button();
                button.Content = $"{item.Name}\n{x.Value}";
                button.Tag = x.Key;
                button.Style = Application.Current.FindResource("RoundedButton") as Style;
                button.Click += AddItemToLeftGrid;

                rightGrid.Children.Add(button);

                if (rightColumn == 5)
                {
                    rightRow++;
                    rightColumn = 0;
                }

                Grid.SetColumn(button, rightColumn);
                Grid.SetRow(button, rightRow);

                rightColumn++;
                
                DebugDictionaries();
            }
        }

        private void AddItemToRightGrid(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var itemId = Guid.Parse(button.Tag.ToString());

            if (!_rightGroupedItems.ContainsKey(itemId))
                _rightGroupedItems.Add(itemId, 1);
            else
                _rightGroupedItems[itemId] += 1;

            rightGrid.Children.Clear();

            PutItemsInRightGrid();
            PutInItemTable();
            DebugDictionaries();
            

            _leftGroupedItems[itemId] -= 1;

            if (_leftGroupedItems[itemId] == 0)
            {
                _leftGroupedItems.Remove(itemId);
                leftGrid.Children.Clear();
            }

            PutItemsInLeftGrid();
        }

        private void AddItemToLeftGrid(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var itemId = Guid.Parse(button.Tag.ToString());

            if (!_leftGroupedItems.ContainsKey(itemId))
                _leftGroupedItems.Add(itemId, 1);
            else
                _leftGroupedItems[itemId] += 1;


            leftGrid.Children.Clear();

            _rightGroupedItems[itemId] -= 1;


            PutItemsInLeftGrid();
            PutInItemTable();
            DebugDictionaries();

            if (_rightGroupedItems[itemId] == 0){
                _rightGroupedItems.Remove(itemId);
                rightGrid.Children.Clear();
                PutItemsInRightGrid();
                PutInItemTable();
            }

            PutItemsInRightGrid();
        }

        private void PutInItemTable()
        {
            int currentTableRow = 1;
            ItemTable.Children.Clear();
            ItemTable.RowDefinitions.Clear();

            var firstRowDef = new RowDefinition();
            firstRowDef.Height = new GridLength(25);
            ItemTable.RowDefinitions.Add(firstRowDef);

            var textSum = new TextBlock();
            textSum.Text = "Summe";
            textSum.FontWeight = FontWeights.Bold;
            textSum.FontSize = 20;
            textSum.Margin = new Thickness(5, 0, 0, 0);

            ItemTable.Children.Add(textSum);
            Grid.SetColumn(textSum, 0);
            Grid.SetRow(textSum, 0);

            var textSumNumber = new TextBlock();
            textSumNumber.Text = GetSum().ToString("0.00");
            textSumNumber.FontWeight = FontWeights.Bold;
            textSumNumber.FontSize = 20;
            textSumNumber.Margin = new Thickness(0, 0, 5, 0);
            textSumNumber.HorizontalAlignment = HorizontalAlignment.Right;

            ItemTable.Children.Add(textSumNumber);
            Grid.SetColumn(textSumNumber, 1);
            Grid.SetRow(textSumNumber, 0);

            foreach (var i in _rightGroupedItems)
            {
                var item = _itemJsonLogic.GetSingle(i.Key);

                var rowDef = new RowDefinition();
                rowDef.Height = new GridLength(25);

                var textName = new TextBlock();
                textName.Text = $"{i.Value} {item.Name}";
                textName.FontSize = 20;
                textName.Margin = new Thickness(5, 0, 0, 0);

                var textPrice = new TextBlock();
                textPrice.Text = (item.PriceInclTax * i.Value).ToString("0.00");
                textPrice.FontSize = 20;
                textPrice.HorizontalAlignment = HorizontalAlignment.Right;
                textPrice.Margin = new Thickness(0, 0, 5, 0);

                ItemTable.RowDefinitions.Add(rowDef);

                ItemTable.Children.Add(textName);
                ItemTable.Children.Add(textPrice);

                Grid.SetColumn(textName, 0);
                Grid.SetColumn(textPrice, 1);

                Grid.SetRow(textName, currentTableRow);
                Grid.SetRow(textPrice, currentTableRow);

                currentTableRow++;
            }
        }

        private float GetSum()
        {
            float sum = 0;
            foreach (var i in _rightGroupedItems)
            {
                var item = _itemJsonLogic.GetSingle(i.Key);
                sum += item.PriceInclTax * i.Value;
            }
            return sum;
        }

        private float GetSumExclTax()
        {
            float sum = 0;
            foreach (var i in _rightGroupedItems)
            {
                var item = _itemJsonLogic.GetSingle(i.Key);
                sum += item.PriceExclTax * i.Value;
            }

            return sum;
        }

        private void DebugDictionaries()
        {
            Trace.WriteLine("--- Right Items");
            foreach (var item in _rightGroupedItems)
                Trace.WriteLine($"Key: {item.Key} Value: {item.Value}");

            Trace.WriteLine("--- Right Items\n");

            Trace.WriteLine("--- Left Items");
            foreach (var item in _leftGroupedItems)
                Trace.WriteLine($"Key: {item.Key} Value: {item.Value}");
            Trace.WriteLine("--- Left Items\n");
        }

        private void PrintBill_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in _rightGroupedItems)
            {
                for (int i = 1; i <= item.Value; i++)
                {
                    _tableJsonLogic.RemoveItemFromTable(_table.Id, item.Key);
                }

                var bill = new Bill()
                {
                    BillNumber = _billJsonLogic.Bills.Count + 1,
                    Company = _companyJsonLogic.GetCompany(),
                    PaymentMethod = PaymentMethods.Cash,
                    PrintDate = DateTime.Now,
                    RegisterId = Guid.Empty,
                    SortedItems = _rightGroupedItems,
                    Sum = GetSum(),
                    SumExclTax = GetSumExclTax(),
                    TableId = _table.Id
                };

                _billJsonLogic.CreateBill(bill);
                PdfService.CreatePdfBill(bill);
                _rightGroupedItems.Clear();
                NavigationService.Content = new TableListPage(_mainWindow);
            }
        }

        private void RemoveItems_Click(object sender, RoutedEventArgs e)
        {
            foreach (var item in _rightGroupedItems)
            {
                for (int i = 1; i <= item.Value; i++)
                {
                    _tableJsonLogic.RemoveItemFromTable(_table.Id, item.Key);
                    
                }
                
                _itemRemovalJsonLogic.AddRemoval(new ItemRemoval()
                {
                    Id = Guid.NewGuid(),
                    RegisterId = Guid.Empty,
                    RemovalReason = RemovalReason.Incorrect,
                    RemovedItems = _rightGroupedItems,
                    Time = DateTime.Now
                });
                
                _rightGroupedItems.Clear();
                NavigationService.Content = new TableListPage(_mainWindow);
            }
        }

        private void AddItems_Click(object sender, RoutedEventArgs e)
        {
            _mainWindow.Main.Content = new AddItemsPage(_mainWindow, _table.Id);
        }
    }
}
