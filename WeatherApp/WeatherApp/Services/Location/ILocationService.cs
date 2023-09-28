using System.Threading.Tasks;

namespace WeatherApp.Services.Location
{
    public interface ILocationService
    {
        Task<Xamarin.Essentials.Location> GetCurrentLocationCoordinatesAsync();
        Task<Xamarin.Essentials.Placemark> GetCurrentLocationNameAsync(double lat, double lon);
        Task<Xamarin.Essentials.Location> GetLocation(string locationName);

    }
}
