using OrderingSystem.Domain;
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

namespace OderingSystem.Wpf.ManagementAreaPages
{
    /// <summary>
    /// Interaction logic for RemoveTablePage.xaml
    /// </summary>
    public partial class RemoveTablePage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;
        private TableJsonLogic _tableJsonLogic;

        public RemoveTablePage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();

            _managementAreaWindow = managementAreaWindow;
            _tableJsonLogic = new TableJsonLogic();

            if (_tableJsonLogic.Tables == null || _tableJsonLogic.Tables.Count == 0)
                _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);

            foreach (var table in _tableJsonLogic.Tables)
            {
                TableBox.Items.Add(table);
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if(TableBox.SelectedItem == null)
            {
                NotificationField.Text = "You need to select a Table!";
                return;
            }

            var table = (Table)TableBox.SelectedItem;
            if(table.CurrentItems.Count != 0)
            {
                NotificationField.Text = "The Table you are trying to delete still contains Items!";
                return;
            }

            _tableJsonLogic.RemoveTable(table.Id);

            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }
    }
}
