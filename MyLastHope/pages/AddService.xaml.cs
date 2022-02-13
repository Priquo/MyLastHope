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
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Page
    {
        ServiceEditor serviceEditor = new ServiceEditor();
        public AddService()
        {
            InitializeComponent();
            DataContext = serviceEditor;
        }

        private void buttAddImageFromApp_Click(object sender, RoutedEventArgs e)
        {

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
