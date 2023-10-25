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
    public class FavouritesPageViewModel : ViewModel
    {
        private List<FavouriteViewModel> _ListFavouritesWeatherViewModel = new List<FavouriteViewModel>();
        public List<FavouriteViewModel> ListFavouritesWeatherViewModel 
        {
            get { return _ListFavouritesWeatherViewModel; }
            set { this.SetProperty(ref _ListFavouritesWeatherViewModel, value); }
        }
        public async Task<List<string>> GetFavouritesNameAsync()
        {
            try
            {
                string list;
                if (await SecureStorage.GetAsync(App.LoggedInUser + "Favourites") != null)
                {
                    list = await SecureStorage.GetAsync(App.LoggedInUser + "Favourites");
                }
                else
                {
                    await SecureStorage.SetAsync(App.LoggedInUser + "Favourites", "");
                    return new List<string>();
                }
                list = list.Trim();
                return list.Split(' ').ToList();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void TransformWeatherToDisplay(List<Root> favourites)
        {
            try
            {
                foreach (var favourite in favourites)
                {
                    if (favourite != null)
                    {
                        this.ListFavouritesWeatherViewModel.Add(new FavouriteViewModel(favourite));
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}