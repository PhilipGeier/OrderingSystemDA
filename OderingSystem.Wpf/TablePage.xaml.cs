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

namespace OderingSystem.Wpf
{
    //TODO: RightButtonEventHandler

    /// <summary>
    /// Interaction logic for TablePage.xaml
    /// </summary>
    public partial class TablePage : Page
    {
        MainWindow mainWindow;

        TableJsonLogic tableJsonLogic;
        ItemJsonLogic itemJsonLogic;

        Table table;

        IDictionary<Guid, int> leftGroupedItems;
        IDictionary<Guid, int> rightGroupedItems;

        TextBlock header;

        Grid leftGrid;
        Grid rightGrid;

        public TablePage()
        {
            InitializeComponent();
        }

        public TablePage(string tableId)
        {
            InitializeComponent();

            mainWindow = Window.GetWindow(this) as MainWindow;

            tableJsonLogic = new TableJsonLogic();
            itemJsonLogic = new ItemJsonLogic();

            PrintBill.Style = Application.Current.FindResource("RoundedButton") as Style;

            table = tableJsonLogic.GetSingle(tableId);
            var items = table.CurrentItems;

            rightGroupedItems = new Dictionary<Guid, int>();

            leftGroupedItems = items
                .GroupBy(x => x)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count).ToDictionary(g => g.Key, g=> g.Count);


            leftGrid = (Grid)FindName("LeftGrid");
            rightGrid = (Grid)FindName("RightGrid");

            header = (TextBlock)FindName("Header");
            
            if (char.IsDigit(table.Label[0]))
                header.Text = $"Table {table.Label}";
            else
                header.Text = table.Label;

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

            foreach (var x in leftGroupedItems)
            {
                var item = itemJsonLogic.GetSingle(x.Key);

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
            }
        }

        private void PutItemsInRightGrid()
        {
            int rightRow = 0;
            int rightColumn = 0;

            foreach (var x in rightGroupedItems)
            {
                var item = itemJsonLogic.GetSingle(x.Key);

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
            }
        }

        private void AddItemToRightGrid(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var itemId = Guid.Parse(button.Tag.ToString());

            if (!rightGroupedItems.ContainsKey(itemId))
                rightGroupedItems.Add(itemId, 1);
            else
                rightGroupedItems[itemId] += 1;

            rightGrid.Children.Clear();

            PutItemsInRightGrid();
            PutInItemTable();
            DebugDictionaries();
            

            leftGroupedItems[itemId] -= 1;

            if (leftGroupedItems[itemId] == 0)
            {
                leftGroupedItems.Remove(itemId);
                leftGrid.Children.Clear();
            }

            PutItemsInLeftGrid();
        }

        private void AddItemToLeftGrid(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;

            var itemId = Guid.Parse(button.Tag.ToString());

            if (!leftGroupedItems.ContainsKey(itemId))
                leftGroupedItems.Add(itemId, 1);
            else
                leftGroupedItems[itemId] += 1;


            leftGrid.Children.Clear();

            rightGroupedItems[itemId] -= 1;


            PutItemsInLeftGrid();
            PutInItemTable();
            DebugDictionaries();

            if (rightGroupedItems[itemId] == 0){
                rightGroupedItems.Remove(itemId);
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
            textSum.FontSize = 20;
            textSum.Margin = new Thickness(5, 0, 0, 0);

            ItemTable.Children.Add(textSum);
            Grid.SetColumn(textSum, 0);
            Grid.SetRow(textSum, 0);

            var textSumNumber = new TextBlock();
            textSumNumber.Text = GetSum().ToString("0.00");
            textSumNumber.FontSize = 20;
            textSumNumber.Margin = new Thickness(0, 0, 5, 0);
            textSumNumber.HorizontalAlignment = HorizontalAlignment.Right;

            ItemTable.Children.Add(textSumNumber);
            Grid.SetColumn(textSumNumber, 1);
            Grid.SetRow(textSumNumber, 0);

            foreach (var i in rightGroupedItems)
            {
                var item = itemJsonLogic.GetSingle(i.Key);

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
            foreach (var i in rightGroupedItems)
            {
                var item = itemJsonLogic.GetSingle(i.Key);
                sum += item.PriceInclTax * i.Value;
            }
            return sum;
        }

        private void DebugDictionaries()
        {
            Trace.WriteLine("--- Right Items");
            foreach (var item in rightGroupedItems)
                Trace.WriteLine($"Key: {item.Key} Value: {item.Value}");

            Trace.WriteLine("--- Right Items\n");

            Trace.WriteLine("--- Left Items");
            foreach (var item in leftGroupedItems)
                Trace.WriteLine($"Key: {item.Key} Value: {item.Value}");
            Trace.WriteLine("--- Left Items\n");
        }

        private void PrintBill_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
