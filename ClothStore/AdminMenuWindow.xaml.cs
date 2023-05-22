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
    /// Логика взаимодействия для AdminMenuWindow.xaml
    /// </summary>
    public partial class AdminMenuWindow : Window
    {
        public AdminMenuWindow()
        {
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ProductItem_Click(object sender, RoutedEventArgs e)
        {
            new ProductWindow().Show();
            this.Close();
        }
    }
}
