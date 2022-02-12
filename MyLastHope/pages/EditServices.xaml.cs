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
        Services service;
        int indx;
        public EditServices(object idService)
        {
            InitializeComponent();
            indx = Convert.ToInt32(idService);
            service = BaseConnect.BaseModel.Services.FirstOrDefault(x => x.ID_service == indx);
            servName.Text = service.Title;
            servImg.Text = service.MainImagePath;
            servCost.Text = service.Cost.ToString();
            servDuration.Text = service.DurationInSeconds.ToString();
            servDiscount.Text = service.Discount.ToString();
        }

        private void buttAddImage_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".jpg"; // задаем расширение по умолчанию
            openFileDialog.Filter = "Изображения |*.jpg;*.png"; // задаем фильтр на форматы файлов
            var result = openFileDialog.ShowDialog();
            if (result == true)//если файл выбран
            {
                servImg.Text = openFileDialog.FileName;
                MessageBox.Show("картинка пользователя добавлена в базу");
            }
            else
            {
                MessageBox.Show("операция выбора изображения отменена");
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            service.Title = servName.Text;
            service.MainImagePath = servImg.Text;
            service.Cost = Convert.ToDouble(servCost.Text);
            service.DurationInSeconds = Convert.ToInt32(servDuration.Text);
            service.Discount = Convert.ToDouble(servDiscount.Text);
            BaseConnect.BaseModel.SaveChanges();
            LoadPages.MainFrame.GoBack();
        }

        private void buttExit_Click(object sender, RoutedEventArgs e)
        {
            LoadPages.MainFrame.GoBack();
        }
    }
}
