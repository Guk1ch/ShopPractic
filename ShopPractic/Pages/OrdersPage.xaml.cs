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
    /// Логика взаимодействия для OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {
        public static ObservableCollection<Order> orders { get; set; }
        public static ObservableCollection<ProductOrder> Prodorders { get; set; }
        public Order Order { get; set; }
        public List<StatusOrder> StatusOrders { get; set; }
        public List<ProductOrder> ProductOrders { get; set; }
        public static ObservableCollection<DataBase.Product> products { get; set; }
        public static ObservableCollection<StatusOrder> statuses { get; set; }
        public OrdersPage()
        {
            InitializeComponent();
            dgOrders.ItemsSource = new ObservableCollection<Order>(BD_Connection.connection.Order);
        }

        private void btn_AddOrd_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegOrderPage());
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }

    }
}
