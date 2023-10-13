using System;
using System.Collections.Generic;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Resources;

namespace WeatherApp.ViewModels
{
    public class FavouriteViewModel : ViewModel
    {
        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { this.SetProperty(ref _Name, value); }
        }

        private string _Temp;
        public string Temp
        {
            get { return _Temp; }
            set { this.SetProperty(ref _Temp, value); }
        }

        private string _Icon;
        public string Icon
        {
            get { return _Icon; }
            set { this.SetProperty(ref _Icon, value); }
        }

        public void TransformWeatherToDisplay(Root root)
        {
            this.Name = root.City.Name;

            this.Temp = root.List[0].Main.Temp.ToString();

            this.Icon = "https://openweathermap.org/img/wn/" + root.List[0].Weather[0].Icon + "@2x.png";
        }

        public FavouriteViewModel(Root root)
        {
            try
            {
                TransformWeatherToDisplay(root);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
