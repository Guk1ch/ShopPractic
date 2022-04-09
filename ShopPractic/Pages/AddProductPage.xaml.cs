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
using System.Collections.ObjectModel;
using ShopPractic.DataBase;

namespace ShopPractic.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddProductPage.xaml
    /// </summary>
    public partial class AddProductPage : Page
    {
        public static DataBase.Product constProd;
        public static ObservableCollection<Product> products { get; set; }
        public static ObservableCollection<Country> country { get; set; }
        public AddProductPage()
        {

            InitializeComponent();
        }

        private void Btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Btn_Save_Click(object sender, RoutedEventArgs e)
        {
            Product new_product = new Product();
            new_product.Name = txt_NameProd.Text;
            new_product.Description = txt_OpisProd.Text;
            new_product.UnitId = Cb_Unit.SelectedIndex +1;
            new_product.AddDate = DateTime.Now;

            DataBase.BD_Connection.connection.Product.Add(new_product);
            DataBase.BD_Connection.connection.SaveChanges();
            products = new ObservableCollection<Product>(BD_Connection.connection.Product.ToList());
            
            NavigationService.Navigate(new EditProductPage(new_product));
        }

        private void Btn_AddPhoto_Click(object sender, RoutedEventArgs e)
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

        private void AddCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountryCb.SelectedIndex >= 0)
            {
                var ProdCountry = new ProductCountry();
                var sel = CountryCb.SelectedItem as Country;
                ProdCountry.ProductId = constProd.Id;
                ProdCountry.CountryId = sel.Id;
                var isCountry = DataBase.BD_Connection.connection.ProductCountry.Where(c => c.CountryId == sel.Id && c.ProductId == constProd.Id).Count();
                if (isCountry == 0)
                {
                    DataBase.BD_Connection.connection.ProductCountry.Add(ProdCountry);
                    DataBase.BD_Connection.connection.SaveChanges();
                    UpdateCountryList();
                }

            }
        }

        private void DelCountryBtn_Click(object sender, RoutedEventArgs e)
        {
            if (CountryLv.SelectedItem != null)
            {
                var selProductCountry = DataBase.BD_Connection.connection.ProductCountry.ToList().Find(c => c.ProductId == constProd.Id && c.CountryId == (CountryLv.SelectedItem as ProductCountry).CountryId);
                DataBase.BD_Connection.connection.ProductCountry.Remove(selProductCountry);
                DataBase.BD_Connection.connection.SaveChanges();
                UpdateCountryList();

            }

        }
        private void UpdateCountryList()
        {
            CountryLv.ItemsSource = DataBase.BD_Connection.connection.ProductCountry.Where(e => e.ProductId == constProd.Id).ToList();
        }
    }
}
