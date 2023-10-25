using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Services.Favorites
{
    internal class FavoritesService : IFavoritesService
    {
        public async Task SetFavourites(bool isFavorite, string name)
        {
            try
            {
                if (!isFavorite)
                {
                    //JSON serialization
                    string list = await SecureStorage.GetAsync(App.LoggedInUser + "Favourites");
                    if(!list.Contains(name))
                    {
                        list += $" {name}";
                        await SecureStorage.SetAsync(App.LoggedInUser + "Favourites", list);
                    }
                    else
                    {
                        list = list.Remove(list.IndexOf(name), name.Count());
                        await SecureStorage.SetAsync(App.LoggedInUser + "Favourites", list);
                    }                    
                }
                else if (await SecureStorage.GetAsync(App.LoggedInUser + "Favourites") != null)
                {
                    string list = await SecureStorage.GetAsync(App.LoggedInUser + "Favourites");
                    if (!list.Contains(name))
                    {
                        list += $" {name}";
                        await SecureStorage.SetAsync(App.LoggedInUser + "Favourites", list);
                    }
                }
                else
                {
                    await SecureStorage.SetAsync(App.LoggedInUser + "Favourites", name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
