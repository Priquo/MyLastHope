using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MyLastHope
{
    class ServiceEditor:INotifyPropertyChanged
    {
        Services service;
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title
        {
            get => service.Title;
            set => service.Title = value;
        }
        public string Cost
        {
            get => service.Cost.ToString();
            set => service.Cost = value != "" ? Convert.ToDouble(value) : service.Cost;
        }
        public string DurationInSeconds
        {
            get => service.DurationInSeconds.ToString();
            set => service.DurationInSeconds = CheckDuration(Convert.ToInt32(value));
        }
        public string Discount
        {
            get => service.Discount.ToString();
            set => service.Discount = value != "" ? Convert.ToDouble(value) : service.Discount;
        }
        public string MainImagePath
        {
            get => service.MainImagePath;
            set => service.MainImagePath = value;
        }
        public ServiceEditor(int idService)
        {
            service = BaseConnect.BaseModel.Services.FirstOrDefault(x => x.ID_service == idService);
        }
        private int CheckDuration(int duration)
        {
            if (duration / 3600 > 4 || duration < 0)
            {
                MessageBox.Show("Длительность не может превышать 4 часов и быть отрицательной");
                return (int)service.DurationInSeconds;
            }
            return duration;
        }
        public void AddImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.DefaultExt = ".jpg"; // задаем расширение по умолчанию
            openFileDialog.Filter = "Изображения |*.jpg;*.png"; // задаем фильтр на форматы файлов
            var result = openFileDialog.ShowDialog();
            if (result == true)//если файл выбран
            {                
                MessageBox.Show("картинка пользователя добавлена в базу");
                MainImagePath = openFileDialog.FileName;
                PropertyChanged(this, new PropertyChangedEventArgs("MainImagePath"));
            }
            else
            {
                MessageBox.Show("операция выбора изображения отменена");
            }
        }
        public void SaveService()
        {            
            BaseConnect.BaseModel.SaveChanges();
        }
    }
}
