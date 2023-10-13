using Moq;
using Xamarin.Essentials;

namespace WeatherApp.Tests
{
    public class FavoriteServiceTest
    {
        [Fact]
        public async Task SetFavouritesTest()
        {
            var credentialsMock = new Mock<SecureStorage>();
            credentialsMock.Setup(x => x.Authenticate()).Returns(() => Task.FromResult(“SomeRandomAccessToken”));



            var mainViewModel = new MainViewModel(
                 new Mock<IMvxLogProvider>().Object,
                 new Mock<IMvxNavigationService>().Object,
                 credentialsMock.Object);
            Assert.True(await mainViewModel.Authenticate());
        }
    }
}