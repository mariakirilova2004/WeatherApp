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
                _cts = new CancellationTokenSource();
                var location = await Geolocation.GetLocationAsync(request, _cts.Token);

                if (location != null)
                {
                    return location;
                }

                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                // Handle permission exception
            }
            catch (Exception ex)
            {
                // Unable to get location
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
                Debug.WriteLine(ex);
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
                Debug.WriteLine(ex);
            }
            return null;
        }
    }
}
