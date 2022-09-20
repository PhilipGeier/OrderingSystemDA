using OrderingSystem.Domain;
using OrderingSystem.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

namespace OderingSystem.Wpf.ItemWindows
{
    /// <summary>
    /// Interaction logic for CreateItemWindow.xaml
    /// </summary>
    public partial class CreateItemWindow : Window
    {
        ItemJsonLogic itemJsonLogic;
        MainWindow mainWindow;

        public CreateItemWindow(MainWindow main)
        {
            InitializeComponent();

            mainWindow = main;

            itemJsonLogic = new ItemJsonLogic();
        }

        private void ConfirmButton_Click(object sender, RoutedEventArgs e)
        {
            Item item;

            var priceIsFloat = float.TryParse(PriceInput.Text, out float price);

            if (!priceIsFloat)
            {
                NotificationField.Text = "The Price you entered is invalid!";
                return;
            }

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

            itemJsonLogic.AddItem(item);

            this.Hide();
        }
    }
}
