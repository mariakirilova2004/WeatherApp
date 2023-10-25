using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using WeatherApp.Resources;
using WeatherApp.Views;

namespace WeatherApp.ViewModels
{
    public class MainPageFlyoutViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<MainPageFlyoutMenuItem> MenuItems { get; set; }

        public MainPageFlyoutViewModel()
        {
            MenuItems = new ObservableCollection<MainPageFlyoutMenuItem>(new[]
            {
                    new MainPageFlyoutMenuItem { Id = 0, Title = AppResources.HomeMenu, TargetType = typeof(HomePage) },
                    new MainPageFlyoutMenuItem { Id = 1, Title = AppResources.Hours24Menu, TargetType = typeof(Hours24WeatherPage) },
                    new MainPageFlyoutMenuItem { Id = 2, Title = AppResources.Days6Menu, TargetType = typeof(Days6WeatherPage) },
                    new MainPageFlyoutMenuItem { Id = 3, Title = AppResources.SettingsMenu, TargetType = typeof(SettingsPage) },
                    new MainPageFlyoutMenuItem { Id = 4, Title = AppResources.AboutMenu, TargetType = typeof(AboutPage) },
                    new MainPageFlyoutMenuItem { Id = 5, Title = AppResources.FavouritesMenu, TargetType = typeof(FavouritesPage) },
                    new MainPageFlyoutMenuItem { Id = 6, Title = AppResources.SignOut, TargetType = typeof(SignOut) }
            });
        }

        #region INotifyPropertyChanged Implementation
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged == null)
                return;

            PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
