using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using WeatherApp.Services.Location;
using WeatherApp.ViewModels;
using static System.Net.WebRequestMethods;
using Xamarin.Forms;

namespace WeatherApp.Models
{
    public sealed class Days10WeatherViewModel : ViewModel
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
            d1.Weather[0].Description = dayOne[0].Weather[0].Description;
            d1.Weather[0].Icon = dayOne[0].Weather[0].Icon;
            d1.Main.TempMin = dayOne.Min(x => x.Main.TempMin);
            d1.Main.TempMax = dayOne.Max(x => x.Main.TempMax);

            this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d1));

            var dayTwo = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(1).Day).ToList();
            var d2 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
            d2.DtTxt = DateTime.Now.AddDays(1).ToString();
            d2.Weather.Add(new Weather());
            d2.Weather[0].Description = dayTwo[3].Weather[0].Description;
            d2.Weather[0].Icon = dayTwo[3].Weather[0].Icon;
            d2.Main.TempMin = dayTwo.Min(x => x.Main.TempMin);
            d2.Main.TempMax = dayTwo.Max(x => x.Main.TempMax);

            this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d2));

            var dayThree = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(2).Day).ToList();
            var d3 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
            d3.DtTxt = DateTime.Now.AddDays(2).ToString();
            d3.Weather.Add(new Weather());
            d3.Weather[0].Description = dayThree[3].Weather[0].Description;
            d3.Weather[0].Icon = dayThree[3].Weather[0].Icon;
            d3.Main.TempMin = dayThree.Min(x => x.Main.TempMin);
            d3.Main.TempMax = dayThree.Max(x => x.Main.TempMax);

            this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d3));

            var dayFour = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(3).Day).ToList();
            var d4 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
            d4.DtTxt = DateTime.Now.AddDays(3).ToString();
            d4.Weather.Add(new Weather());
            d4.Weather[0].Description = dayFour[3].Weather[0].Description;
            d4.Weather[0].Icon = dayFour[3].Weather[0].Icon;
            d4.Main.TempMin = dayFour.Min(x => x.Main.TempMin);
            d4.Main.TempMax = dayFour.Max(x => x.Main.TempMax);

            this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d4));

            var dayFive = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(4).Day).ToList();
            var d5 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
            d5.DtTxt = DateTime.Now.AddDays(4).ToString();
            d5.Weather.Add(new Weather());
            d5.Weather[0].Description = dayFive[3].Weather[0].Description;
            d5.Weather[0].Icon = dayFive[3].Weather[0].Icon;
            d5.Main.TempMin = dayFive.Min(x => x.Main.TempMin);
            d5.Main.TempMax = dayFive.Max(x => x.Main.TempMax);

            this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d4));

            var daySix = root.List.Where(l => DateTime.Parse(l.DtTxt).Day == DateTime.Now.AddDays(5).Day).ToList();
            if (daySix.Count > 0)
            {
                var d6 = new List() { Main = new Main(), Weather = new List<Weather>(), Wind = new Wind() };
                d6.DtTxt = DateTime.Now.AddDays(5).ToString();
                d6.Weather.Add(new Weather());
                d6.Weather[0].Description = daySix[2].Weather[0].Description;
                d6.Weather[0].Icon = daySix[2].Weather[0].Icon;
                d6.Main.TempMin = daySix.Min(x => x.Main.TempMin);
                d6.Main.TempMax = daySix.Max(x => x.Main.TempMax);

                this.ListDayWeatherViewModel.Add(new DayWeatherViewModel(d6));
            }
        }
    }
}
