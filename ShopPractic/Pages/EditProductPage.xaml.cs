using System;
using System.IO;
using Microsoft.Win32;
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

namespace ShopPractic.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public static DataBase.Product constProd;
        public EditProductPage(DataBase.Product product)
        {
            InitializeComponent();
            constProd = product;
            this.DataContext = constProd;
            txt_ID.Text = product.Id.ToString();
            txt_NameProd.Text = product.Name;
            txt_OpisProd.Text = product.Description;
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            constProd.AddDate = DateTime.Now;
            DataBase.BD_Connection.connection.SaveChanges();
            NavigationService.Navigate(new ProductListPage());
        }

        private void Btn_ChangePhoto_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog()
            {
                Filter = "*.jpg|*.jpg|*.png|*.png"
            };
            if (openFile.ShowDialog().GetValueOrDefault())
            {
                constProd.Photo = File.ReadAllBytes(openFile.FileName);
                img_prod.Source = new BitmapImage(new Uri(openFile.FileName));
            }
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn_Del_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Не надо дядя " + " НЯЯ!"); 
        }
    }
}
