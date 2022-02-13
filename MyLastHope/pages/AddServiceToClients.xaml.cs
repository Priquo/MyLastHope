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
    /// Логика взаимодействия для AddServiceToClients.xaml
    /// </summary>
    public partial class AddServiceToClients : Page
    {
        LoadServiceToClients loadService;
        public AddServiceToClients(int idService)
        {
            InitializeComponent();
            loadService = new LoadServiceToClients(idService);
            DataContext = loadService;            
        }
        
        private void buttSave_Click(object sender, RoutedEventArgs e)
        {
            if (loadService.SaveData())
                MessageBox.Show("Сохранено успешно");
            else
                MessageBox.Show("Какая-то ошибка");
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }
    }
}
