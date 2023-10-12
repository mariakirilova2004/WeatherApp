using System.Collections.Generic;
using System;
using WeatherApp.Models;
using WeatherApp.Resources;
using System.Linq;
using Xamarin.Essentials;
using System.ComponentModel;
using System.Threading.Tasks;

namespace WeatherApp.ViewModels
{
    public class FavouritesViewModel : ViewModel
    {
        private List<FavouriteViewModel> _ListFavouritesWeatherViewModel;
        public List<FavouriteViewModel> ListFavouritesWeatherViewModel 
        {
            get { return _ListFavouritesWeatherViewModel; }
            set { this.SetProperty(ref _ListFavouritesWeatherViewModel, value); }
        }

        public async Task<List<string>> GetFavouritesNameAsync()
        {
            string list;
            if (await SecureStorage.GetAsync("FavouritesList") != null)
            {
                list = await SecureStorage.GetAsync("FavouritesList");
            }
            else
            {
                await SecureStorage.SetAsync("FavouritesList", "");
                return new List<string>();
            }

            return list.Trim().Split(' ').ToList();
        }

        internal void TransformWeatherToDisplay(List<Root> favourites)
        {
            foreach (var favourite in favourites) 
            {
                if (favourite != null) 
                {
                    this.ListFavouritesWeatherViewModel = new List<FavouriteViewModel>
                    {
                        new FavouriteViewModel(favourite)
                    };
                }
            }
        }
    }
}