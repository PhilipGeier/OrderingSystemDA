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
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;
using OderingSystem.Wpf.ItemWindows;

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Frame main;
        public Grid mainWindowGrid;
        public Page currentPage;

        private CompanyJsonLogic _companyJsonLogic;
        
        public MainWindow()
        {
            InitializeComponent();

            main = Main;
            mainWindowGrid = MainWindowGrid;

            if (main.Content == null)
            {
                var page = new TableListPage(this);
                main.Content = page;
                currentPage = page;
            }

            _companyJsonLogic = new CompanyJsonLogic();

            if (_companyJsonLogic.GetCompany() == null)
            {
                var createCompanyWindow = new CreateCompanyWindow(this);
                createCompanyWindow.Show();
                createCompanyWindow.Focus();
                IsEnabled = false;
            }
        }

        private void SwitchViewClick(object sender, RoutedEventArgs e)
        {


        }

        private void ItemTransferButton_Click(object sender, RoutedEventArgs e)
        {
            var choosingWindow = new TransferChoosing(this);
            choosingWindow.Show();
        }

        private void OpenNewTable_Click(object sender, RoutedEventArgs e)
        {
            var newTableWindow = new NewTableWindow(this);
            newTableWindow.Show();
        }

        private void OpenNewItem_Click(object sender, RoutedEventArgs e)
        {
            var createItemWindow = new CreateItemWindow(this);
            createItemWindow.Show();
        }

        private void SwtichView_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TableLocationPage(this);
        }
    }
}