﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.Services.User
{
    public interface IEmailService
    {
        bool IsValidEmail(string email);
    }
}