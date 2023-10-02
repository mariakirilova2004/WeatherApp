using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
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
                    new MainPageFlyoutMenuItem { Id = 0, Title = "Home", TargetType = typeof(HomePage) },
                    new MainPageFlyoutMenuItem { Id = 1, Title = "24 Hour Weather", TargetType = typeof(Hours24WeatherPage) },
                    new MainPageFlyoutMenuItem { Id = 2, Title = "10 Days Weather", TargetType = typeof(Days6WeatherPage) },
                    new MainPageFlyoutMenuItem { Id = 3, Title = "Settings", TargetType = typeof(HomePage) },
                    new MainPageFlyoutMenuItem { Id = 4, Title = "About", TargetType = typeof(HomePage) },
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
