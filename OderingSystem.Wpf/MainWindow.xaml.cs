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

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Frame main;

        private CompanyJsonLogic _companyJsonLogic;
        
        public MainWindow()
        {
            InitializeComponent();

            main = Main;

            if (main.Content == null)
            {
                var page = new TableListPage(this);
                main.Content = page;
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

        private void ItemTransferButton_Click(object sender, RoutedEventArgs e)
        {
            var choosingWindow = new TransferChoosing(this);
            choosingWindow.Show();
        }

        private void SwtichView_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new TableLocationPage(this);
        }

        private void ShowCompanyInfo_Click(object sender, RoutedEventArgs e)
        {
            var companyInfoWindow = new CompanyInfoWindow(this);
            companyInfoWindow.Show();
        }

        private void OpenManagementArea_Click(object sender, RoutedEventArgs e)
        {
            var managementAreaWindow = new ManagementAreaWindow();
            managementAreaWindow.Show();
            Close();
        }
    }
}