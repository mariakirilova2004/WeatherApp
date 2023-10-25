using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.ViewModels
{
    public class RegisterLoginPageViewModel : ViewModel
    {
        private bool _isVisible;
        public bool IsVisible
        {
            get { return _isVisible; }
            set { this.SetProperty(ref _isVisible, value); }
        }

        private string _Message;
        public string Message
        {
            get { return _Message; }
            set { this.SetProperty(ref _Message, value); }
        }
    }
}
