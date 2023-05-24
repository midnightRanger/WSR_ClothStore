using ClothStore.Models;
using Microsoft.EntityFrameworkCore;
using SF2022User_01_Lib;
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


namespace ClothStore
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext _db; 
        public MainWindow()
        {
            InitializeComponent();
            _db = new ApplicationContext();
            guestBTN.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));
            loginBTN.Background = new SolidColorBrush(Color.FromRgb(73, 140, 81));

            Calculations calc = new();

            var test = Calculations.AvailablePeriods(new TimeSpan[] { new TimeSpan(10, 0, 0),
            new TimeSpan(11, 0, 0) }, new int[] {30, 30 }, new TimeSpan(8,45,0), new TimeSpan(19, 45, 0), 30);
        }

        private void guestBTN_Click(object sender, RoutedEventArgs e)
        {
            new StaffWindow().Show();
            Close();
        }

        private void loginBTN_Click(object sender, RoutedEventArgs e)
        {
            string? password = passwordTB.Password;
            string? login = loginTB.Text;
            if (password == null || login == null)
                MessageBox.Show("Заполните все поля!", "Ошибка", MessageBoxButton.OK);
            else
            {

                if (String.IsNullOrEmpty(password) || String.IsNullOrEmpty(login))
                    MessageBox.Show("Поля не могут состоять из пустых пробелов", "Ошибка", MessageBoxButton.OK);
                else
                {
                    var user = _db.User.Include(u=>u.Role).FirstOrDefault(u => u.UserLogin == login);

                    if (user == null)
                        MessageBox.Show("Пользователь не найден", "Ошибка", MessageBoxButton.OK);
                    else
                    {
                        if (user.UserPassword != password)
                            MessageBox.Show("Пароль не подходит", "Ошибка", MessageBoxButton.OK);
                        else
                        {
                            MessageBox.Show("Успешная авторизация", "Успех", MessageBoxButton.OK);

                            switch (user.Role.RoleName) {
                                case "Client": {
                                        new StaffWindow().Show();
                                        Close();
                                    } break;

                                case "Manager":
                                    {
                                        new StaffWindow().Show();
                                        Close();
                                    }
                                    break;
                                case "Admin":
                                    {
                                        new AdminMenuWindow().Show();
                                        Close();
                                    }
                                    break;
                            }
                            
                        }
                    }
                }
            }
        }
    }
}
