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
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OderingSystem.Wpf.ManagementAreaPages
{
    /// <summary>
    /// Interaction logic for CreateItemPage.xaml
    /// </summary>
    public partial class CreateItemPage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;
        private ItemJsonLogic _itemJsonLogic;

        public CreateItemPage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();

            _managementAreaWindow = managementAreaWindow;
            _itemJsonLogic = new ItemJsonLogic();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            var priceIsFloat = float.TryParse(PriceInput.Text, out var price);

            if (!priceIsFloat)
            {
                NotificationField.Text = "The Price you entered is invalid!";
                return;
            }

            Item item;

            switch (CategoryDropdown.SelectedIndex.ToString())
            {

                case "0":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Beer
                    };
                    break;
                case "1":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Wine
                    };
                    break;
                case "2":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Longdrinks
                    };
                    break;
                case "3":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Shots
                    };
                    break;
                case "4":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Cocktails
                    };
                    break;
                case "5":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Starter
                    };
                    break;
                case "6":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.MainCourse
                    };
                    break;
                case "7":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Dessert
                    };
                    break;
                case "8":
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Specials
                    };
                    break;
                default:
                    item = new Item()
                    {
                        Id = Guid.NewGuid(),
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Specials
                    };
                    break;
            }

            _itemJsonLogic.AddItem(item);
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }
    }
}
