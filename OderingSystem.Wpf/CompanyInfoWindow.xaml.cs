using OrderingSystem.Domain;
using OrderingSystem.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for CompanyInfoWindow.xaml
    /// </summary>
    public partial class CompanyInfoWindow : Window
    {
        private MainWindow _mainWindow;
        private CompanyJsonLogic _companyJsonLogic;

        public CompanyInfoWindow(MainWindow main)
        {
            InitializeComponent();

            _mainWindow = main;
            _companyJsonLogic = new CompanyJsonLogic();
            try
            {
                FillFields(_companyJsonLogic.GetCompany());
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }
        }

        private void FillFields(Company company)
        {
            IDField.Text = company.Id.ToString();
            NameField.Text = company.Name;
            StreetField.Text = company.Street;
            ZipField.Text = company.ZipCode.ToString();
            CityField.Text = company.City;
            UIDField.Text = company.UIdNumber;
            TelField.Text = company.TelephoneNumber;
        }
    }
}
