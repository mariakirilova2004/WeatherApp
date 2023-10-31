using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services.User
{
    public interface IUserValidatorService
    {
        bool IsValidEmail(string email);
        bool DoesEmailExists(string email);
        bool IsValidPassword(string password);
    }
}
