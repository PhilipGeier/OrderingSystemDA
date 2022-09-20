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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OderingSystem.Wpf
{
    /// <summary>
    /// Interaction logic for CreateCompanyWindow.xaml
    /// </summary>
    public partial class CreateCompanyWindow : Window
    {
        private MainWindow _mainWindow;
        private CompanyJsonLogic _companyJsonLogic;
        
        public CreateCompanyWindow(MainWindow mainWindow)
        {
            InitializeComponent();

            _mainWindow = mainWindow;

            _companyJsonLogic = new CompanyJsonLogic();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrEmpty(NameInput.Text) || String.IsNullOrEmpty(StreetInput.Text) || String.IsNullOrEmpty(ZipCodeInput.Text) || String.IsNullOrEmpty(CityInput.Text) || String.IsNullOrEmpty(UIdInput.Text) || String.IsNullOrEmpty(TelNumberInput.Text))
                ErrorMessage.Text = "An input field is empty!";
            else
            {
                bool isInt = int.TryParse(ZipCodeInput.Text, out int zipCode);
                if (isInt)
                {
                    _companyJsonLogic.PutCompany(new Company()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        Street = StreetInput.Text,
                        ZipCode = zipCode,
                        City = CityInput.Text,
                        UIdNumber = UIdInput.Text,
                        TelephoneNumber = TelNumberInput.Text,
                    });

                    _mainWindow.IsEnabled = true;
                    Close();
                }
            }
        }
    }
}
