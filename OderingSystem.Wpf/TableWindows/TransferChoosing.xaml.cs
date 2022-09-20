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

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for TransferChoosing.xaml
    /// </summary>
    public partial class TransferChoosing : Window
    {
        MainWindow _mainWindow;

        public TransferChoosing(MainWindow main)
        {
            _mainWindow = main;

            var tableJsonLogic = new TableJsonLogic();

            InitializeComponent();

            foreach(var table in tableJsonLogic.Tables)
            {
                LeftDropdown.Items.Add(table.Id);
                RightDropdown.Items.Add(table.Id);
            }
        }

        private void StartTransferButton_Click(object sender, RoutedEventArgs e)
        {
            if (LeftDropdown.SelectedValue.ToString() != null && RightDropdown.SelectedValue.ToString() != null && LeftDropdown.SelectedIndex != RightDropdown.SelectedIndex)
            {
                _mainWindow.Main.Content = new ItemTransfer(LeftDropdown.SelectedValue.ToString(), RightDropdown.SelectedValue.ToString());
                this.Hide();
            }
        }
    }
}
