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
using System.Windows.Shapes;
using OrderingSystem.Domain.Enums;
using OrderingSystem.Domain;
using Table = OrderingSystem.Domain.Table;

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for NewTableWindow.xaml
    /// </summary>
    public partial class NewTableWindow : Window
    {
        TableJsonLogic tableJsonLogic;
        MainWindow mainWindow;

        public NewTableWindow(MainWindow main)
        {
            InitializeComponent();

            tableJsonLogic = new TableJsonLogic();

            mainWindow = main;
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Table table;

            switch(LocationsDropdown.SelectedValue.ToString())
            {
                case "Bar":
                    table = new Table()
                    {
                        Id = $"table{LabelInput.Text}",
                        Label = LabelInput.Text,
                        CurrentItems = new List<Guid>(),
                        Location = Locations.Bar
                    };
                    break;
                case "Terrace":
                    table = new Table()
                    {
                        Id = $"table{LabelInput.Text}",
                        Label = LabelInput.Text,
                        CurrentItems = new List<Guid>(),
                        Location = Locations.Terrace
                    };
                    break;
                case "Tables":
                    table = new Table()
                    {
                        Id = $"table{LabelInput.Text}",
                        Label = LabelInput.Text,
                        CurrentItems = new List<Guid>(),
                        Location = Locations.Tables
                    };
                    break;
                default:
                    table = new Table()
                    {
                        Id = $"table{LabelInput.Text}",
                        Label = LabelInput.Text,
                        CurrentItems = new List<Guid>(),
                        Location = Locations.Tables
                    };
                    break;
            }

            if(tableJsonLogic.GetSingle(table.Id) == null)
            {
                tableJsonLogic.AddTable(table);
                NotificationField.Text = "Table was successfully created";
                NotificationField.Foreground = Brushes.Green;
                this.Hide();
            }
            else
            {
                NotificationField.Text = "The table already exists";
                NotificationField.Foreground = Brushes.Red;
            }
        }
    }
}
