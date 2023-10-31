﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignOut : ContentPage
    {
        public SignOut()
        {
            App.LoggedInUser = null;
            App.Current.MainPage = new LoginPage();
            //InitializeComponent();
        }
    }
}