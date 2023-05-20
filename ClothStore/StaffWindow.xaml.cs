using ClothStore.Models;
using Microsoft.EntityFrameworkCore;
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

namespace ClothStore
{

    /// <summary>
    /// Логика взаимодействия для StaffWindow.xaml
    /// </summary>
    public partial class StaffWindow : Window
    {
        private readonly ApplicationContext _db;


        public StaffWindow()
        {
            InitializeComponent();
            _db = new ApplicationContext();

            var orders = _db.Order.Include(o=>o.OrderProducts).FirstOrDefault();
            var products = _db.Product.ToList();

            var productsList = products.Where(s => s.OrderID == orders.OrderID).ToList(); ;
        }


    }
}
