using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WeatherApp.Resources;
using WeatherApp.Services.Favorites;
using WeatherApp.Services.Location;
using WeatherApp.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using static System.Net.WebRequestMethods;

namespace WeatherApp.Models
{
    public sealed class HomePageViewModel : ViewModel
    {
        private string _Temp;
        public string Temp // 30
        {
            get { return _Temp; }
            set { this.SetProperty(ref _Temp, value); }
        }

        private string _currentDayFormatted;
        public string CurrentDayFormatted // 02.02.24 Sun
        {
            get { return _currentDayFormatted; }
            set { this.SetProperty(ref _currentDayFormatted, value); }
        }

        private string _name;
        public string Name// Istanbul
        {
            get { return _name; }
            set { this.SetProperty(ref _name, value); }
        }

        private string _country;
        public string Country// Turkey
        {
            get { return _country; }
            set { this.SetProperty(ref _country, value); }
        }

        private string _metric;
        public string Metric // CELSIUS
        {
            get { return _metric; }
            set { this.SetProperty(ref _metric, value); }
        }

        private string _humidity;
        public string Humidity // 50%
        {
            get { return _humidity; }
            set { this.SetProperty(ref _humidity, value); }
        }

        private string _wind;
        public string Wind // 2.3m/s
        {
            get { return _wind; }
            set { this.SetProperty(ref _wind, value); }
        }

        private string _pressure;
        public string Pressure // 1500hpa
        {
            get { return _pressure; }
            set { this.SetProperty(ref _pressure, value); }
        }

        private string _weatherState;
        public string WeatherState // Cloudy
        {
            get { return _weatherState; }
            set { this.SetProperty(ref _weatherState, value); }
        }

        private string _icon;
        public string Icon // Cloudy Image
        {
            get { return _icon; }
            set { this.SetProperty(ref _icon, value); }
        }

        private bool _isFavorite;
        public bool IsFavorite // true/false
        {
            get { return _isFavorite; }
            set //begin invoke on main
            { 
                this.SetProperty(ref _isFavorite, value);
            }
        }

        private bool _isCheckVisible;
        public bool IsCheckVisible // true/false
        {
            get { return _isCheckVisible; }
            set //begin invoke on main
            {
                this.SetProperty(ref _isCheckVisible, value);
            }
        }

        private List<HourWeatherViewModel> _ListHourWeatherViewModel;
        public List<HourWeatherViewModel> ListHourWeatherViewModel // List of HourWeatherViewModel
        {
            get { return _ListHourWeatherViewModel; }
            set { this.SetProperty(ref _ListHourWeatherViewModel, value); }
        }

        public IFavoritesService favoritesService { get; set; } = new FavoritesService();

        public ICollection<SuggestionViewModel> SuggestionCollection { get; set; } = new List<SuggestionViewModel>();

        public async Task TransformWeatherToDisplay(Root root, Suggestion suggestion)
        {
            this.Temp = Math.Round(root.List[0].Main.Temp).ToString();

            this.Name = root.City.Name;

            this.Country = root.City.Country;

            var dayOfWeek = DateTime.Parse(root.List[0].DtTxt).DayOfWeek.ToString();

            this.CurrentDayFormatted = DateTime.Parse(root.List[0].DtTxt).Day.ToString() 
                + " " + AppResources.ResourceManager.GetString(dayOfWeek, AppResources.Culture);

            try
            {
                var metric = await SecureStorage.GetAsync(App.LoggedInUser + "metrics");
                if (metric == "metric") this.Metric = AppResources.CELSIUS;
                if (metric == "imperial") this.Metric = AppResources.FARENHAIT;

                var fv = await SecureStorage.GetAsync(App.LoggedInUser + "Favourites");
                if (fv != null)
                {
                    this.IsFavorite = fv.ToLower().Contains(this.Name.ToLower());
                }
                else this.IsFavorite = false;

                this.Humidity = root.List[0].Main.Humidity.ToString() + "%";

                var weatherState = root.List[0].Weather[0].Description;

                this.WeatherState = AppResources_bg.ResourceManager.GetString(weatherState, AppResources.Culture); 

                this.Icon = "https://openweathermap.org/img/wn/" + root.List[0].Weather[0].Icon + "@2x.png";

                this.Wind = root.List[0].Wind.Speed.ToString() + "m/s";

                this.Pressure = root.List[0].Main.Pressure.ToString() + "hpa";

                this.ListHourWeatherViewModel = root.List.Take(9).Select(l => new HourWeatherViewModel(l)).ToList();

                this.IsCheckVisible = false;

                if(suggestion != null)
                {
                    this.SuggestionCollection = suggestion.ListCities.Select(x => new SuggestionViewModel() { Name = $"{x.Name}, {x.Country}" }).Distinct().ToList();
                    this.IsCheckVisible = true;
                }

                for (int i = 0; i < this.ListHourWeatherViewModel.Count; i++)
                {
                    this.ListHourWeatherViewModel[i].Index = i;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
