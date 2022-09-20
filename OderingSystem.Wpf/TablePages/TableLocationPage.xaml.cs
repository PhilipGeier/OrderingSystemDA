using OrderingSystem.Domain.Enums;
using OrderingSystem.Json;
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

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for TableGraphicView.xaml
    /// </summary>
    public partial class TableLocationPage : Page
    {
        MainWindow mainWindow;

        TableJsonLogic tableJsonLogic;

        public TableLocationPage(MainWindow main)
        {
            InitializeComponent();

            mainWindow = main;

            tableJsonLogic = new TableJsonLogic();

            RenderTables(Locations.Tables);
        }

        private void RenderTables(Locations location)
        {
            int row = 0;
            int column = 0;

            var tables = tableJsonLogic.Tables.OrderBy(o => o.Id).ToList();

            foreach(var table in tables)
            {
                if(table.Location == location)
                {

                    var button = new Button();
                    TableGrid.Children.Add(button);
                    button.Content = table.Label;
                    button.Click += tableClick;
                    button.Name = table.Id;
                    button.Style = Application.Current.FindResource("RoundedButton") as Style;

                    if (column == 8)
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

        private void tableClick(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            mainWindow.Main.Content = new TablePage(button.Name, mainWindow);
        }

        private void Bar_Click(object sender, RoutedEventArgs e)
        {
            TableGrid.Children.Clear();
            RenderTables(Locations.Bar);
        }

        private void Tables_Click(object sender, RoutedEventArgs e)
        {
            TableGrid.Children.Clear();
            RenderTables(Locations.Tables);
        }

        private void Terrace_Click(object sender, RoutedEventArgs e)
        {
            TableGrid.Children.Clear();
            RenderTables(Locations.Terrace);
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
