using OderingSystem.Wpf.ManagementAreaPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for ManagementAreaWindow.xaml
    /// </summary>
    public partial class ManagementAreaWindow : Window
    {
        public ManagementAreaWindow()
        {
            InitializeComponent();

            if(ManagementAreaFrame.Content == null)
            {
                var page = new ManagementAreaPage(this);
                ManagementAreaFrame.Content = page;
            }
        }

        private void OnClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
