using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services.Weather;

namespace WeatherApp.Services.User
{
    public class UserValidatorService : IUserValidatorService
    {
        public bool DoesEmailExists(string email)
        {
            SQLiteConnection connection = new SQLiteConnection(App.DatabaseLocation);
            connection.CreateTable<WeatherApp.Models.User>();
            var table = connection.Table<WeatherApp.Models.User>();
            var emailExists = table.Any(v => v.Email == email);
            return emailExists;
        }

        public bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith(".") || email == "")
            {
                return false; // suggested by @TK-421
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPassword(string password)
        {
            bool res = (password.Length >= 8 && password.Any(char.IsDigit));
            return res;
        }
    }
}
