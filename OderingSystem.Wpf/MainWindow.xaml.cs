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
        public Grid mainWindowGrid;
        public Page currentPage;

        public MainWindow()
        {
            InitializeComponent();

            main = Main;
            mainWindowGrid = MainWindowGrid;

            if (main.Content == null)
            {
                var page = new TableListPage();
                main.Content = page;
                currentPage = page;
            }
        }

        private void SwitchViewClick(object sender, RoutedEventArgs e)
        {
            if (currentPage.GetType() == typeof(TableListPage))
                main.Content = new TableGraphicView();
            else if (currentPage.GetType() == typeof(TableGraphicView))
                main.Content = new TableListPage();

        }
    }
}