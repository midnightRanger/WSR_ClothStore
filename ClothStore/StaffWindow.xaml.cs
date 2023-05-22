using ClothStore.Converter;
using ClothStore.Models;
using ClothStore.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.CompilerServices;
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

namespace ClothStore
{

    /// <summary>
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        private readonly ApplicationContext _db;
        private string _searchText;
        private StaffWindowViewModel _staff;
        private ObservableCollection<Product> _productOC;
        private ObservableCollection<String> _productMan; 

        public class BoolToStringConverter : BoolToValueConverter<String> { }

        public StaffWindow()
        {
            InitializeComponent();
            _db = new ApplicationContext();
            _staff = new StaffWindowViewModel();
            this.DataContext = _staff;


            //var orders = _db.Order.Include(o=>o.OrderProducts).ThenInclude(s=>s.Product).FirstOrDefault();
            //var productsList = orders.OrderProducts.Select(o => o.Product).ToList();

            _productOC = new();
            _productMan = new();
            List<Product> products = _db.Product.ToList();



            foreach (var product in products)
            {
                product.ProductPhoto = (product.ProductPhoto != null) ? $"/ClothStore;component/{product.ProductPhoto}" : "Images/picture.png";
                _productOC.Add(product);
            }

            var productMans = _db.Product.Select(p => p.ProductManufacturer).Distinct().ToList();

            

            foreach (var man in productMans)
                _productMan.Add(man);

            filterCB.ItemsSource = _productMan; 
            filterCB.SelectedIndex = 0;
            

            staffLV.ItemsSource = _productOC;
            staffLV.SelectedValuePath = "ProductArticleNumber"; 

            showItemsValueTB.Text = $"Выведено: {products.Count}/{products.Count}";
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void searchTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            _searchText = searchTB.Text;

            var products = _db.Product.Where(p=>p.ProductName.ToUpper().StartsWith(_searchText.ToUpper()) ||
                p.ProductDescription.ToUpper().StartsWith(_searchText.ToUpper())).ToList();

            _productOC.Clear(); 
            foreach (var product in products)
                _productOC.Add(product);


            _staff.ShowValueText = $"Выведено: {products.Count}/{_db.Product.ToList().Count()}";
 

        }

        private void staffLV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void sortBTN_Click(object sender, RoutedEventArgs e)
        {
            _productOC.Clear();

            List<Product>? products;
            _staff.Sort = !_staff.Sort;


            if (_staff.Sort)
                products = _db.Product.OrderByDescending(p => p.ProductCost).ToList();
            else
                products = _db.Product.OrderBy(p => p.ProductCost).ToList();

            foreach (var product in products) 
                _productOC.Add(product);    


        }

        private void staffLV_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var itemToDelete = _db.Product.FirstOrDefault(p => p.ProductArticleNumber == staffLV.SelectedValue);

            if (itemToDelete != null)
            {
                try
                {
                    _db.Product.Remove(itemToDelete);
                    _db.SaveChanges();
                    UpdateOC();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка! Описание: {ex.Message}", "Ошибка", MessageBoxButton.OK);
                }

                MessageBox.Show($"Удаление успешно произошло", "Успех", MessageBoxButton.OK);

            }
            else {
                MessageBox.Show($"Предмета для удаления не существует", "Проблема..", MessageBoxButton.OK);
            }
        }

        private void UpdateOC() {

            _productOC.Clear();
            var products = _db.Product.ToList();

            foreach (var product in products)
                _productOC.Add(product);
        }

        private void filterCB_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var products = _db.Product.Where(p => p.ProductManufacturer == filterCB.SelectedValue).ToList();

            _productOC.Clear();
            foreach (var product in products)
                _productOC.Add(product);
        }
    }
}
