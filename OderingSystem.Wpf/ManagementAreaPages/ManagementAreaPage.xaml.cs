using OderingSystem.Wpf.ManagementAreaPages.ItemPages;
using OderingSystem.Wpf.ManagementAreaPages.TablePages;
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
    /// Interaction logic for ManagementAreaPage.xaml
    /// </summary>
    public partial class ManagementAreaPage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;

        public ManagementAreaPage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();
            _managementAreaWindow = managementAreaWindow;
        }

        private void CreateItem_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new CreateItemPage(_managementAreaWindow);
        }

        private void EditItem_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new EditItemPage(_managementAreaWindow);
        }

        private void DeleteItem_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new RemoveItemPage(_managementAreaWindow);
        }

        private void CreateTable_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new CreateTablePage(_managementAreaWindow);
        }

        private void EditTable_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new EditTablePage(_managementAreaWindow);
        }

        private void DeleteTable_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new RemoveTablePage(_managementAreaWindow);
        }
    }
}
