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
    /// Логика взаимодействия для ProdIntakePage.xaml
    /// </summary>
    public partial class ProdIntakePage : Page
    {
        public ProdIntakePage()
        {
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btn_Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
