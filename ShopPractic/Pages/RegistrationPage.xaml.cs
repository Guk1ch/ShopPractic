using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using ShopPractic.DataBase;

namespace ShopPractic.Pages
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public static ObservableCollection<DataBase.User> users { get; set; }
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void Btn_registration_Click(object sender, RoutedEventArgs e)
        {
            users = new ObservableCollection<DataBase.User>(BD_Connection.connection.User.ToList());

            var new_usr = new User();
            var new_clnt = new Client();

            var ValidPass = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[^a-zA-Z0-9])\S{6,16}$";
            Regex regex = new Regex(ValidPass);
            var input = password_txt.Text;

            bool pass = regex.IsMatch(input);
                if (pass)
                {
                    new_usr.Login = login_txt.Text;
                    new_usr.Password = password_txt.Text;
                    new_usr.RoleId = 2;

                    BD_Connection.connection.User.Add(new_usr);
                    BD_Connection.connection.SaveChanges();

                    new_clnt.FIO = name_txt.Text;
                    if (gender.Text == "Мужчина")
                    {
                        new_clnt.GenderId = 1;
                    }
                    else if (gender.Text == "Женщина")
                    {
                        new_clnt.GenderId = 2;
                    }
                    else
                        MessageBox.Show("Пол не выбран");

                    new_clnt.NumberPhone = Phone_txt.Text;
                    new_clnt.Email = login_txt.Text;
                    new_clnt.AddDate = DateTime.Now;
                    new_clnt.UserId = users.Last().Id;

                    BD_Connection.connection.Client.Add(new_clnt);
                    BD_Connection.connection.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно");
                    NavigationService.GoBack();
                }
                else
                {
                    MessageBox.Show("Пароль должен быть: \n" +
                                  "Минимум 6 символов.\n" +
                                  "Минимум 1 прописная буква.\n" +
                                  "Минимум 1 цифра.\n" +
                                  "Минимум один символ из набора: ! @ # $ % ^.\n");
                }



        }

        private void Btn_goBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Phone_txt_TextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0))
            {
                e.Handled = true;
            }
        }
    }
}
