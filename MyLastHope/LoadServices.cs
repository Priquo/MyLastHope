using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace MyLastHope
{
    public class LoadServices:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        int adminHashCode = 15947562;
        int discountIndex = 0;
        string titleFilter = "";
        double[,] discountsValuesList = new double[,] { { 0, 0.15 }, { 0.15, 0.3 }, { 0.3, 0.7 }, { 0.7, 1 } };
        List<string> discountsList = new List<string> { "", "от 0 до 15%", "от 15 до 30%", "от 30 до 70%", "от 70 до 100%" };
        List<Services> services = BaseConnect.BaseModel.Services.ToList();
        public int AdminHashCode => adminHashCode;
        public List<Services> Services => services;        
        public List<string> DiscountsList => discountsList;
        public int DiscountIndex 
        { 
            get => discountIndex;
            set
            {
                discountIndex = value;
                if (value>0)
                {
                    services = services.Where(x => x.Discount >= discountsValuesList[value-1, 0] && x.Discount < discountsValuesList[value-1, 1]).ToList();
                    DoPropertyChange("Services");
                }
            }
        }
        public string TitleFilter
        {
            get => titleFilter;
            set
            {
                titleFilter = value;
                if (value != "" || value != null)
                {
                    services = services.Where(x => x.Title.Contains(value)).ToList();
                    DoPropertyChange("Services");
                }
            }
        }
        private void DoPropertyChange(string propertyName)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        public void ResetFilter()
        {
            discountIndex = 0;
            titleFilter = "";
            services = BaseConnect.BaseModel.Services.ToList();
            DoPropertyChange("Services");
            DoPropertyChange("DiscountIndex");
            DoPropertyChange("TitleFilter");
        }
    }
}
