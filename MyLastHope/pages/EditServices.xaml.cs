using Microsoft.Win32;
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
using System.Drawing;

namespace MyLastHope.pages
{
    /// <summary>
    /// Логика взаимодействия для EditServices.xaml
    /// </summary>
    public partial class EditServices : Page
    {
        ServiceEditor serviceEditor;
        public EditServices(int idService)
        {
            InitializeComponent();
            serviceEditor = new ServiceEditor(idService);
            DataContext = serviceEditor;
        }

        private void buttAddImage_Click(object sender, RoutedEventArgs e)
        {
            serviceEditor.AddImage();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            serviceEditor.SaveService();
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }
    }
}
