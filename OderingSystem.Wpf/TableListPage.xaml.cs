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
    /// <summary>
    /// Interaction logic for TableListPage.xaml
    /// </summary>
    public partial class TableListPage : Page
    {
        TableJsonLogic tableJsonLogic;
        List<Table> tables;
        Grid tableGrid;
        MainWindow mainWindow;

        public TableListPage()
        {
            InitializeComponent();

            tableJsonLogic = new TableJsonLogic();

            tables = tableJsonLogic.Tables;

            tableGrid = (Grid)FindName("TableGrid");

            mainWindow = MainWindow.GetWindow(this) as MainWindow;

            int row = 0;
            int column = 0;

            foreach (var table in tables)
            {
                if (table.CurrentItems.Count == 0)
                    continue;

                var controlTemplate = new ControlTemplate();

                var button = new Button();
                tableGrid.Children.Add(button);
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


        private void tableClick(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            Trace.WriteLine(button.Name);

            var mainWindow = MainWindow.GetWindow(this) as MainWindow;
            mainWindow.Main.Content = new TablePage(button.Name);
        }
    }
}
