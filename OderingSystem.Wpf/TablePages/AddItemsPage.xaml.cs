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
using OrderingSystem.Domain.Enums;
using OrderingSystem.Domain;
using OrderingSystem.Json;

namespace OderingSystem.Wpf.TablePages
{
    /// <summary>
    /// Interaction logic for AddItemsPage.xaml
    /// </summary>
    public partial class AddItemsPage : Page
    {
        MainWindow mainWindow;

        TableJsonLogic tableJsonLogic;
        ItemJsonLogic itemJsonLogic;

        public List<ItemToAdd> itemsToAdd { get; set; } = new List<ItemToAdd>();

        string TableId;

        public AddItemsPage(MainWindow main, string tableId)
        {
            InitializeComponent();

            mainWindow = main;

            TableId = tableId;

            tableJsonLogic = new TableJsonLogic();
            itemJsonLogic = new ItemJsonLogic();

            RenderItems(ItemCategories.Beer);
        }

        private void RenderItems(ItemCategories category)
        {
            int row = 0;
            int column = 0;

            foreach (var item in itemJsonLogic.Items)
            {
                if(item.Category == category)
                {
                    var button = new Button();
                    button.Content = item.Name;
                    button.Tag = item.Id;
                    button.Style = Application.Current.FindResource("RoundedButton") as Style;
                    button.Click += AddItem;

                    ItemsGrid.Children.Add(button);

                    if (column == 6)
                    {
                        row++;
                        column = 0;
                    }

                    Grid.SetColumn(button, column);
                    Grid.SetRow(button, row);
                    column++;
                }
            }
        }

        private void AddItem(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            itemsToAdd.Add(new ItemToAdd { Id = Guid.Parse(button.Tag.ToString()), ItemName = button.Content.ToString() });

            var text = new TextBlock();
            text.Text = button.Content.ToString();

            itemStackPanel.Children.Add(text);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            foreach(var item in itemsToAdd)
            {
                tableJsonLogic.AddItemToTable(TableId, item.Id);
            }
            NavigationService.RemoveBackEntry();
            NavigationService.Content = new TablePage(TableId, mainWindow);
        }

        private void BeerButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Beer);
        }

        private void WineButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Wine);
        }

        private void LongdrinksButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Longdrinks);
        }

        private void ShotsButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Shots);
        }

        private void CocktailsButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Cocktails);
        }

        private void StartersButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Starter);
        }

        private void MainCourseButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.MainCourse);
        }

        private void DessertButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Dessert);
        }

        private void SpecialsButton_Click(object sender, RoutedEventArgs e)
        {
            ItemsGrid.Children.Clear();
            RenderItems(ItemCategories.Specials);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

    public class ItemToAdd
    {
        public Guid Id { get; set; }
        public string ItemName { get; set; }
    }
}
