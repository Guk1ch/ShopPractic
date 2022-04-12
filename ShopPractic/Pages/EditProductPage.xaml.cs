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
using ShopPractic.DataBase;
using System.Collections.ObjectModel;


namespace ShopPractic.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProductPage.xaml
    /// </summary>
    public partial class EditProductPage : Page
    {
        public static DataBase.Product constProd;
        public static ObservableCollection<Country> country { get; set; }
        public EditProductPage(DataBase.Product product)
        {
            InitializeComponent();
            country = new ObservableCollection<Country>(BD_Connection.connection.Country.ToList());
            CountryCb.ItemsSource = country;
            CountryCb.DisplayMemberPath = "Name";

            constProd = product;
            this.DataContext = constProd;
            txt_ID.Text = product.Id.ToString();
            txt_NameProd.Text = product.Name;
            txt_OpisProd.Text = product.Description;
            if (constProd.Id != 0)
            {
                AddCountryBtn.Visibility = Visibility.Visible;
                DelCountryBtn.Visibility = Visibility.Visible;
                AddCountryBtn.Visibility = Visibility.Visible;
                DelCountryBtn.Visibility = Visibility.Visible;
                CountryLabel.Visibility = Visibility.Visible;
                CountryCb.Visibility = Visibility.Visible;
                CountryLv.Visibility = Visibility.Visible;
            }
            if(product.UnitId == 2)
            {
                Cb_Unit.SelectedIndex = 0;
            }
            else if (product.UnitId == 1)
            {
                Cb_Unit.SelectedIndex = 1;
            }
            else if (product.UnitId == 3)
            {
                Cb_Unit.SelectedIndex = 2;
            }

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
            constProd.IsDelete = true;
            BD_Connection.connection.SaveChanges();
            NavigationService.Navigate(new Pages.ProductListPage());
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
        private void UpdateCountryList()
        {
            CountryLv.ItemsSource = DataBase.BD_Connection.connection.ProductCountry.Where(e => e.ProductId == constProd.Id).ToList();
        }
    }
}
