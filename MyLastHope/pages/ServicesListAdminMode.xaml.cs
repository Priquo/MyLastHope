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

namespace MyLastHope.pages
{
    /// <summary>
    /// Логика взаимодействия для ServicesListAdminMode.xaml
    /// </summary>
    public partial class ServicesListAdminMode : Page
    {
        int index, idService;
        LoadServices loadServices = new LoadServices();
        public ServicesListAdminMode()
        {
            InitializeComponent();
            DataContext = loadServices;
        }
        private void buttResetSettings_Click(object sender, RoutedEventArgs e)
        {
            loadServices.ResetFilter();
        }

        private void butt_delServ_Click(object sender, RoutedEventArgs e)
        {
            index = listboxServices.SelectedIndex;
            idService = loadServices.Services[index].ID_service;
            if (listboxServices.SelectedItem != null)
            {
                List<ServiceToClients> a = BaseConnect.BaseModel.ServiceToClients.Where(x => x.ID_service == idService).ToList();
                if (a.Count == 0)
                {
                    BaseConnect.BaseModel.Services.Remove(loadServices.Services[listboxServices.SelectedIndex]);
                    BaseConnect.BaseModel.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Нельзя удалить услугу. Существуют зависимости");
                }
            }
            else
            {
                MessageBox.Show("Выберите услугу!");
            }
        }

        private void buttMakeService_Click(object sender, RoutedEventArgs e)
        {

        }

        private void butt_editServ_Click(object sender, RoutedEventArgs e)
        {            
            index = listboxServices.SelectedIndex;
            if (index == -1)
                MessageBox.Show("Выберите услугу");
            else
            {
                idService = loadServices.Services[index].ID_service;
                LoadPages.MainFrame.Navigate(new EditServices(idService));
                listboxServices.Items.Refresh();
            }            
        }
    }
}
