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
                    string list = await SecureStorage.GetAsync("FavouritesList");
                    if(!list.Contains(name))
                    {
                        list += $" {name}";
                        await SecureStorage.SetAsync("FavouritesList", list);
                    }
                    else
                    {
                        list = list.Remove(list.IndexOf(name), name.Count());
                        await SecureStorage.SetAsync("FavouritesList", list);
                    }                    
                }
                else if (await SecureStorage.GetAsync("FavouritesList") != null)
                {
                    string list = await SecureStorage.GetAsync("FavouritesList");
                    if (!list.Contains(name))
                    {
                        list += $" {name}";
                        await SecureStorage.SetAsync("FavouritesList", list);
                    }
                }
                else
                {
                    await SecureStorage.SetAsync("FavouritesList", name);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
