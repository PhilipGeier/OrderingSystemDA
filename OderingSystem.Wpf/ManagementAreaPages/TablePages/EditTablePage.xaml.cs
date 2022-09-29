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
    /// Interaction logic for EditTablePage.xaml
    /// </summary>
    public partial class EditTablePage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;
        private TableJsonLogic _tableJsonLogic;
        private Table _table;

        public EditTablePage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();

            _managementAreaWindow = managementAreaWindow;
            _tableJsonLogic = new TableJsonLogic();

            LocationsDropdown.Items.Add(Locations.Terrace);
            LocationsDropdown.Items.Add(Locations.Bar);
            LocationsDropdown.Items.Add(Locations.Tables);

            var tables = _tableJsonLogic.Tables;

            if (tables == null || tables.Count == 0)
                _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);

            foreach (var table in tables)
            {
                TableBox.Items.Add(table);
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(LabelInput.Text))
            {
                NotificationField.Text = "You need to enter a Label";
                return;
            }

            _tableJsonLogic.EditTable(new Table()
            {
                Id = _table.Id,
                Label = LabelInput.Text,
                Location = (Locations)LocationsDropdown.SelectedItem,
                CurrentItems = _table.CurrentItems
            });

            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void TableBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(TableBox.SelectedItem == null)
            {
                NotificationField.Text = "You need to select a Table to edit!";
                return;
            }

            _table = (Table)TableBox.SelectedItem;
            LabelInput.Text = _table.Label;
            LocationsDropdown.SelectedItem = _table.Location;
        }
    }
}
