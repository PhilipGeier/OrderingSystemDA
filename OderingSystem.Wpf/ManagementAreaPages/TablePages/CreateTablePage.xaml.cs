using OrderingSystem.Domain;
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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OderingSystem.Wpf.ManagementAreaPages.TablePages
{
    /// <summary>
    /// Interaction logic for CreateTablePage.xaml
    /// </summary>
    public partial class CreateTablePage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;
        private TableJsonLogic _tableJsonLogic;

        public CreateTablePage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();
            _managementAreaWindow = managementAreaWindow;
            _tableJsonLogic = new TableJsonLogic();

            LocationsDropdown.Items.Add(Locations.Terrace);
            LocationsDropdown.Items.Add(Locations.Bar);
            LocationsDropdown.Items.Add(Locations.Tables);
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (LocationsDropdown.SelectedItem == null)
            {
                NotificationField.Text = $"You need to select a location!";
                return;
            }
   

            if (string.IsNullOrEmpty(LabelInput.Text))
            {
                NotificationField.Text = $"You need to enter a Label!";
                return;
            }
                

            var id = $"table{LabelInput.Text.ToLower().Replace(" ", "")}";

            if (_tableJsonLogic.GetSingle(id) != null)
            {
                NotificationField.Text = $"Table with ID {id} already exists!";
                return;
            }


            _tableJsonLogic.AddTable(new Table()
            {
                Id = id,
                Label = LabelInput.Text,
                Location = (Locations)LocationsDropdown.SelectedItem
            });

            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }
    }
}
