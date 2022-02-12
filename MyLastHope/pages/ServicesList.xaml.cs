using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace MyLastHope.pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesList.xaml
    /// </summary>
    public partial class ServicesList : Page
    {
        LoadServices loadServices = new LoadServices();
        public ServicesList()
        {
            InitializeComponent();
            DataContext = loadServices;
        }
        private void buttResetSettings_Click(object sender, RoutedEventArgs e)
        {
            loadServices.ResetFilter();
        }

        private void buttAdminCheck_Click(object sender, RoutedEventArgs e)
        {
            if (loadServices.AdminHashCode.Equals(passAdmin.Text.GetHashCode()))
            {
                MessageBox.Show("Вам открыт режим редактирования и создания услуг");
                LoadPages.MainFrame.Navigate(new ServicesListAdminMode());
            }
        }
    }
}
