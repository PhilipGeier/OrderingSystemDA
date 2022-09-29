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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OderingSystem.Wpf.ManagementAreaPages
{
    /// <summary>
    /// Interaction logic for RemoveItemPage.xaml
    /// </summary>
    public partial class RemoveItemPage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;
        private ItemJsonLogic _itemJsonLogic;
        private TableJsonLogic _tableJsonLogic;

        public RemoveItemPage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();

            _managementAreaWindow = managementAreaWindow;
            _itemJsonLogic = new ItemJsonLogic();
            _tableJsonLogic = new TableJsonLogic();

            foreach (var item in _itemJsonLogic.Items)
            {
                ItemsBox.Items.Add(item);
            }
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (ItemsBox.SelectedItem == null)
                return;

            var item = (Item)ItemsBox.SelectedItem;

            foreach (var table in _tableJsonLogic.Tables)
            {
                if (table.CurrentItems.Contains(item.Id))
                {
                    NotificationField.Text = "The could not be deleted because it is present on a table!";
                    return;
                }
            }

            _itemJsonLogic.RemoveItem(item.Id);
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }
    }
}
