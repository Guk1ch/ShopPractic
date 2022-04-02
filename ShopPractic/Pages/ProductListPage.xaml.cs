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
using System.Collections.ObjectModel;
using ShopPractic.DataBase;

namespace ShopPractic.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductListPage.xaml
    /// </summary>
    public partial class ProductListPage : Page
    {
        public static ObservableCollection<DataBase.Product> products { get; set; }
        public ProductListPage()
        {
            products = new ObservableCollection<DataBase.Product>(BD_Connection.connection.Product.ToList());
            InitializeComponent();

            var Prod = new Product();
            this.DataContext = this;
        }

        private void tb_search_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }
    }
}
