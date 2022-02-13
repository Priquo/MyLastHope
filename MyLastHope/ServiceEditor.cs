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
        bool isNewService = false;
        Services service;
        List<Services> list = BaseConnect.BaseModel.Services.ToList();
        public event PropertyChangedEventHandler PropertyChanged;
        public string Title
        {
            get => service.Title;
            set => service.Title = CheckTitle(value);
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
        public ServiceEditor()
        {
            isNewService = true;
            service = new Services()
            {
                ID_service = list.Last().ID_service + 1,
                Title = "",
                Description = null,
                DurationInSeconds = null,
                Cost = 0,
                Discount = null,
                MainImagePath = ""
            };
        }
        public ServiceEditor(int idService)
        {
            service = BaseConnect.BaseModel.Services.FirstOrDefault(x => x.ID_service == idService);
        }
        private string CheckTitle(string Title)
        {            
            if (isNewService)
            {
                if(list.Contains(list.FirstOrDefault(x => x.Title == Title)))
                {
                    MessageBox.Show("Услуга с таким же названием уже существует");
                    Title = service.Title;
                }
            }
            else
            {                
                if (list.Contains(list.FirstOrDefault(x => x.Title == Title || x.ID_service != service.ID_service)))
                {
                    MessageBox.Show("Услуга с таким же названием уже существует");
                    Title = service.Title;
                }
            }
            return Title;
        }
        private int CheckDuration(int duration)
        {
            if (duration / 3600 > 4 || duration < 0)
            {
                MessageBox.Show("Длительность не может превышать 4 часов и быть отрицательной");
                return isNewService ? 0 : (int)service.DurationInSeconds;
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
            if (isNewService)
                BaseConnect.BaseModel.Services.Add(service);
            //    service = new Services()
            //    {
            //        ID_service = list.Last().ID_service + 1,
            //        Title = Title,
            //        Description = null,
            //        DurationInSeconds = Convert.ToInt32(DurationInSeconds),
            //        Cost = Convert.ToDouble(Cost),
            //        Discount = Convert.ToDouble(Discount),
            //        MainImagePath = MainImagePath
            //    };
            BaseConnect.BaseModel.SaveChanges();
            MessageBox.Show("Сохранено успешно");
        }
    }
}
