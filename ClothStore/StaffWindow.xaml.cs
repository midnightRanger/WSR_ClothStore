﻿using ClothStore.Models;
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



        public StaffWindow()
        {
            InitializeComponent();
            _db = new ApplicationContext();
            _staff = new StaffWindowViewModel();
            this.DataContext = _staff;


            //var orders = _db.Order.Include(o=>o.OrderProducts).ThenInclude(s=>s.Product).FirstOrDefault();
            //var productsList = orders.OrderProducts.Select(o => o.Product).ToList();

            _productOC = new();
            List<Product> products = _db.Product.ToList();



            foreach (var product in products)
            {
                product.ProductPhoto = (product.ProductPhoto != null) ? $"Images/{product.ProductPhoto}" : "Images/picture.png";
                _productOC.Add(product);
            }

            staffLV.ItemsSource = _productOC;
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
    }
}
