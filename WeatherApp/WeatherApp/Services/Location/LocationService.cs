using System;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace WeatherApp.Services.Location
{
    public class LocationService : ILocationService
    {
        private CancellationTokenSource _cts;

        public async Task<Xamarin.Essentials.Location> GetCurrentLocationCoordinatesAsync()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Best, TimeSpan.FromSeconds(10));
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    return location;
                }

                return null;
            }
            catch (FeatureNotSupportedException ex)
            {
                throw ex;
            }
            catch (FeatureNotEnabledException ex)
            {
                throw ex;
            }
            catch (PermissionException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return null;
        }

        public async Task<Placemark> GetCurrentLocationNameAsync(double lat, double lon)
        {
            try
            {
                var placemarks = await Geocoding.GetPlacemarksAsync(lat, lon);

                var placemark = placemarks.FirstOrDefault();
                if (placemark != null)
                {
                    return placemark;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }

        public async Task<Xamarin.Essentials.Location> GetLocation(string locationName)
        {
            try
            {
                var locations = await Geocoding.GetLocationsAsync(locationName);

                var location = locations.FirstOrDefault();
                if (location != null)
                {
                    return location;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return null;
        }
    }
}
