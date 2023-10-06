using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WeatherApp.Services.Location;
using WeatherApp.ViewModels;
using static System.Net.WebRequestMethods;
using Xamarin.Forms;
using WeatherApp.Resources;

namespace WeatherApp.Models
{
    public sealed class Days6WeatherViewModel : ViewModel
    {
        private List<DayWeatherViewModel> _ListDayWeatherViewModel;
        public List<DayWeatherViewModel> ListDayWeatherViewModel // List of DayWeatherViewModel
        {
            get { return _ListDayWeatherViewModel; }
            set { this.SetProperty(ref _ListDayWeatherViewModel, value); }
        }

        public void TransformWeatherToDisplay(Root root)
        {
            this.ListDayWeatherViewModel = new List<DayWeatherViewModel>();

            var dayOne = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.Day).ToList();
            var d1 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind()};
            d1.DtTxt = DateTime.Now.ToString();
            d1.Weather.Add(new Weather());
            d1.Weather[0].Description = AppResources.ResourceManager.GetString(dayOne[0].Weather[0].Description);
            d1.Weather[0].Icon = dayOne[0].Weather[0].Icon;
            d1.Main.TempMin = dayOne.Min(x => x.Main.TempMin);
            d1.Main.TempMax = dayOne.Max(x => x.Main.TempMax);

            this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d1));

            for (int i = 1; i <= 4; i++)
            {
                var day = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(i).Day).ToList();
                var d = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
                d.DtTxt = DateTime.Now.AddDays(i).ToString();
                d.Weather.Add(new Weather());
                d.Weather[0].Description = AppResources.ResourceManager.GetString(day[3].Weather[0].Description);
                d.Weather[0].Icon = day[3].Weather[0].Icon;
                d.Main.TempMin = day.Min(x => x.Main.TempMin);
                d.Main.TempMax = day.Max(x => x.Main.TempMax);

                this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d));
            }

            var daySix = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(5).Day).ToList();
            if (daySix.Count > 0)
            {
                var d6 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
                d6.DtTxt = DateTime.Now.AddDays(5).ToString();
                d6.Weather.Add(new Weather());
                d6.Weather[0].Description = AppResources.ResourceManager.GetString(daySix[2].Weather[0].Description);
                d6.Weather[0].Icon = daySix[2].Weather[0].Icon;
                d6.Main.TempMin = daySix.Min(x => x.Main.TempMin);
                d6.Main.TempMax = daySix.Max(x => x.Main.TempMax);

                this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d6));
            }
        }
    }
}
