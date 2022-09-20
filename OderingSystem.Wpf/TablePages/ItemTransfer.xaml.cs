using OrderingSystem.Json;
using OrderingSystem.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Table = OrderingSystem.Domain.Table;

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for ItemTransfer.xaml
    /// </summary>
    public partial class ItemTransfer : Page
    {
        IDictionary<Guid, int> leftGroupedItems;
        IDictionary<Guid, int> rightGroupedItems;

        private TableJsonLogic tableJsonLogic;
        private ItemJsonLogic itemJsonLogic;

        Table fromTable;
        Table toTable;

        Grid leftGrid;
        Grid rightGrid;

        public ItemTransfer(string fromTable, string toTable)
        {
            InitializeComponent();

            Header.Text = $"Item Tranfser from {fromTable} to {toTable}";

            leftGrid = LeftGrid;
            rightGrid = RightGrid;

            tableJsonLogic = new TableJsonLogic();
            itemJsonLogic = new ItemJsonLogic();

            this.fromTable = tableJsonLogic.GetSingle(fromTable);
            this.toTable = tableJsonLogic.GetSingle(toTable);

            var leftItems = this.fromTable.CurrentItems;
            var rightItems = this.toTable.CurrentItems;

            leftGroupedItems = leftItems
                .GroupBy(x => x)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.Key, g => g.Count);

            rightGroupedItems = rightItems
                .GroupBy(x => x)
                .Select(g => new { g.Key, Count = g.Count() })
                .OrderByDescending(x => x.Count)
                .ToDictionary(g => g.Key, g => g.Count);


            PutItemsInLeftGrid();
            PutItemsInRightGrid();
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

            if (rightGroupedItems[itemId] == 0)
            {
                rightGroupedItems.Remove(itemId);
                rightGrid.Children.Clear();
                PutItemsInRightGrid();
            }

            PutItemsInRightGrid();
        }

        private void TransferItemsButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var i in rightGroupedItems)
            {
                for (int j = 1; j <= i.Value; j++)
                {
                    fromTable.CurrentItems.Remove(i.Key);
                    toTable.CurrentItems.Add(i.Key);
                }
            }

            tableJsonLogic.EditTable(toTable);
            tableJsonLogic.EditTable(fromTable);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
