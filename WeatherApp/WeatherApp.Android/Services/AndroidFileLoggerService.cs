using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Logs;
using Xamarin.Forms;

[assembly: Dependency(typeof(WeatherApp.Droid.Services.AndroidFileFileLoggerService))]
namespace WeatherApp.Droid.Services
{
    public sealed class AndroidFileFileLoggerService : IFileLoggerService
    {
        private bool IsInitialized { get; set; }
        private DateTime FilePatternDateTime { get; set; } = DateTime.Today;
        private string LogFile { get; set; }

        public void Log(string message, LogLevel level)
        {
            lock (this)
            {
                // Reset the log if date has changed
                if (this.FilePatternDateTime != DateTime.Today)
                {
                    this.IsInitialized = false;
                }
                // Initialize once
                if (!this.IsInitialized)
                {
                    this.Initialize();
                    this.IsInitialized = true;
                }
                File.AppendAllText(this.LogFile, DateTime.Now.ToString(@"O") + @"|" + level + @":" + message + System.Environment.NewLine);
            }
#if DEBUG
            Debug.WriteLine(level + @" : " + message);
#endif

        }

        private void Initialize()
        {
            this.FilePatternDateTime = DateTime.Today;

            var localFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            this.LogFile = Path.Combine(localFolder, this.FilePatternDateTime.ToString(@"yyyyMMdd") + @".txt");
            if (!File.Exists(this.LogFile))
            {
                using (File.Create(this.LogFile))
                {
                }
            }
        }

        public Task<List<string>> GetLogsFilePathsAsync()
        {
            var filePaths = new List<string>();

            foreach (var filePath in Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), @"*.txt"))
            {
                var name = Path.GetFileNameWithoutExtension(filePath);
                DateTime date;
                if (DateTime.TryParseExact(name, @"yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    filePaths.Add(filePath);
                }
            }

            return Task.FromResult(filePaths);
        }

        public Task<string> GetContentsAsync(string filePath)
        {
            if (filePath == null) throw new ArgumentNullException(nameof(filePath));

            return Task.FromResult(File.ReadAllText(filePath));
        }

        public Task DeleteAsync()
        {
            foreach (var filePath in Directory.GetFiles(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), @"*.txt"))
            {
                var name = Path.GetFileNameWithoutExtension(filePath);
                DateTime date;
                if (DateTime.TryParseExact(name, @"yyyyMMdd", CultureInfo.InvariantCulture, DateTimeStyles.None, out date))
                {
                    if (date != DateTime.Today)
                    {
                        File.Delete(filePath);
                    }
                }
            }
            return Task.CompletedTask;
        }
    }
}