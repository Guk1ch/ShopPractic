using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;
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
using ShopPractic.DataBase;

namespace ShopPractic
{
    /// <summary>
    /// Логика взаимодействия для AutorisationPage.xaml
    /// </summary>
    public partial class AutorisationPage : Page
    {
        public static ObservableCollection<DataBase.User> users { get; set; }
        public AutorisationPage()
        {
            InitializeComponent();
            txt_login.Text = Properties.Settings.Default.Login;
        }
        private void Btn_Reg_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Pages.RegistrationPage());
        }
        private void Btn_Login_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<DataBase.User>(BD_Connection.connection.User.ToList());
            var uz = users.Where(a => a.Login == txt_login.Text && a.Password == txt_password.Password).FirstOrDefault();
            if (uz != null)
            {
                if (RememberMe.IsChecked.GetValueOrDefault())
                {
                    Properties.Settings.Default.Login = txt_login.Text;
                    Properties.Settings.Default.Save();
                }
                else 
                {
                    Properties.Settings.Default.Login = null;
                    Properties.Settings.Default.Save();
                }
                
                NavigationService.Navigate(new Pages.ProductListPage(uz));
            }
            else
            {
                MessageBox.Show("Логин или пароль неверный", "error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

    }
}
