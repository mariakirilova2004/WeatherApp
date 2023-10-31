using Moq;
using SQLite;
using WeatherApp.Models;
using WeatherApp.Services.User;
using Xamarin.Essentials;
using static SQLite.SQLite3;

namespace WeatherApp.Tests
{
    public class UserValidatorServiceTest
    {
        private readonly IUserValidatorService userservice;
        private readonly string databaseLocation;

        public UserValidatorServiceTest()
        {
            userservice = new UserValidatorService();
            string applicationFolderPath = System.IO.Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "WeatherApp");

            // Create the folder path.
            System.IO.Directory.CreateDirectory(applicationFolderPath);

            this.databaseLocation = System.IO.Path.Combine(applicationFolderPath, "WeatherApp.db");
        }

        [Theory]
        [InlineData("mariakirilova2004@gmail.com")]
        [InlineData("mariakirilova@abv.bg")]
        [InlineData("mk@gmail.com")]
        public void IsValidEmailTest_ReturnTrue(string email)
        {
            bool res = userservice.IsValidEmail(email);
            Assert.True(res);
        }

        [Theory]
        [InlineData("@gmail.com")]
        [InlineData("mariakirilova")]
        [InlineData(".com")]
        public void IsValidEmailTest_ReturnFalse(string email)
        {
            bool res = userservice.IsValidEmail(email);
            Assert.False(res);
        }

        [Theory]
        [InlineData("12345678")]
        [InlineData("12bg12345")]
        [InlineData("1HHHHHHHHHHH")]
        public void IsValidPasswordTest_ReturnTrue(string password)
        {
            bool res = userservice.IsValidPassword(password);
            Assert.True(res);
        }

        [Theory]
        [InlineData("maria")]
        [InlineData("mariaaaaa")]
        [InlineData("..........")]
        public void IsValidPasswordTest_ReturnFalse(string password)
        {
            bool res = userservice.IsValidPassword(password);
            Assert.False(res);
        }

        //[Theory]
        //[InlineData("mariakirilova2004@gmail.com")]
        //[InlineData("mariakirilova@abv.bg")]
        //public void DoesEmailExistsTest_ReturnTrue(string email)
        //{
        //    SQLiteConnection connection = new SQLiteConnection(databaseLocation);
        //    User user1 = new User()
        //    {
        //        Email = "mariakirilova2004@gmail.com",
        //        Password = "12345678K"
        //    };
        //    User user2 = new User()
        //    {
        //        Email = "mariakirilova@abv.bg",
        //        Password = "12345678K"
        //    };
        //    connection.CreateTable<User>();
        //    connection.Insert(user1);
        //    connection.Insert(user2);
        //    bool res = userservice.DoesEmailExists(email);
        //    Assert.True(res);
        //}

        //[Theory]
        //[InlineData("mariakirilova2004@gmail.com")]
        //[InlineData("mariakirilova@abv.bg")]
        //public void DoesEmailExistsTest_ReturnFalse(string email)
        //{
        //    bool res = userservice.DoesEmailExists(email);
        //    Assert.False(res);
        //}


    }
}