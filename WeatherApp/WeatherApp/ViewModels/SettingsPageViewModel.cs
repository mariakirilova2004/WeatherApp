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
    public class SettingsPageViewModel
    {
        public List<string> LanguageItems { get; set; }
        public List<string> MetricsItems { get; set; }

        public SettingsPageViewModel()
        {
            LanguageItems = new List<string>() { AppResources.English, AppResources.Bulgarian };

            MetricsItems = new List<string>() { AppResources.CELSIUS, AppResources.FARENHAIT };
        }
    }
}
