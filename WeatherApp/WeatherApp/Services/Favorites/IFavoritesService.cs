using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp.Services.Favorites
{
    public interface IFavoritesService
    {
        Task SetFavourites(bool IsFavorite, string Name);
    }
}
