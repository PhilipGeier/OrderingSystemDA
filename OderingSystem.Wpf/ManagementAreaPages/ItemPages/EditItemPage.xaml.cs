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

namespace OderingSystem.Wpf.ManagementAreaPages.ItemPages
{
    /// <summary>
    /// Interaction logic for EditItemPage.xaml
    /// </summary>
    public partial class EditItemPage : Page
    {
        private ManagementAreaWindow _managementAreaWindow;
        private ItemJsonLogic _itemJsonLogic;
        private Item _item;

        public EditItemPage(ManagementAreaWindow managementAreaWindow)
        {
            InitializeComponent();

            _managementAreaWindow = managementAreaWindow;

            _itemJsonLogic = new ItemJsonLogic();

            var items = _itemJsonLogic.Items;

            if(items == null || items.Count == 0)
                _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);

            foreach (var item in items)
            {
                ItemsBox.Items.Add(item);
            }
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
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Longdrinks
                    };
                    break;
                case "1":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Shots
                    };
                    break;
                case "2":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Beer
                    };
                    break;
                case "3":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Wine
                    };
                    break;
                case "4":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Starter
                    };
                    break;
                case "5":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.MainCourse
                    };
                    break;
                case "6":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Dessert
                    };
                    break;
                case "7":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Cocktails
                    };
                    break;
                case "8":
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Specials
                    };
                    break;
                default:
                    item = new Item()
                    {
                        Id = _item.Id,
                        Name = NameInput.Text,
                        PriceInclTax = price,
                        Category = OrderingSystem.Domain.Enums.ItemCategories.Specials
                    };
                    break;
            }

            _itemJsonLogic.EditItem(item);
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            _managementAreaWindow.ManagementAreaFrame.Content = new ManagementAreaPage(_managementAreaWindow);
        }

        private void ItemSelection_Changed(object sender, SelectionChangedEventArgs e)
        {
            var box = (ComboBox)sender;

            if(box.SelectedItem == null)
            {
                NotificationField.Text = "You need to select an Item to edit!";
                return;
            }

            _item = (Item)box.SelectedItem;

            NameInput.Text = _item.Name;
            PriceInput.Text = _item.PriceInclTax.ToString();
            CategoryDropdown.SelectedIndex = _item.Category.GetHashCode();
        }
    }
}
