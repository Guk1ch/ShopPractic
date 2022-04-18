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

namespace ShopPractic.Pages
{
    /// <summary>
    /// Логика взаимодействия для IntakesPage.xaml
    /// </summary>
    public partial class IntakesPage : Page
    {
        public IntakesPage()
        {
            InitializeComponent();
        }

        private void btn_AddInt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProdIntakePage());
        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ProductListPage());
        }
    }
}
