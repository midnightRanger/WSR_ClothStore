using ClothStore.Models;
using ClothStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace ClothStore
{
    /// <summary>
    /// Логика взаимодействия для ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        AdminMenuWindowViewModel adminMenuWindowViewModel;
        ApplicationContext _db;
        ObservableCollection<Product> _productOC;
        public ProductWindow()
        {
            InitializeComponent();
            _db = new();
            _productOC = new();

            adminMenuWindowViewModel = new();
            this.DataContext = adminMenuWindowViewModel;

            var products = _db.Product.ToList();

            foreach (var product in products)
            {
                product.ProductPhoto = (product.ProductPhoto != null) ? $"/ClothStore;component/{product.ProductPhoto}" : "Images/picture.png";
                _productOC.Add(product);
            }

            productDG.ItemsSource = _productOC;
            
        }
    }
}
