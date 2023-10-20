using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logs;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CrashPage : ContentPage
    {
        public CrashPage()
        {
            InitializeComponent();
        }

        private void Generate_Uncaught(object sender, EventArgs e)
        {
            try
            {
                string value = null;
                if (value.Length == 0)
                {
                    Exception exception = new Exception();
                    throw exception;
                }
            }
            catch (Exception ex)
            {
                ex.TraceWarning();
            }

        }
    }
}