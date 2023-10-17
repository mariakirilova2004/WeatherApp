namespace WeatherApp.Models
{
    public class SuggestionViewModel
    {
        public string Name { get; set; }

        public void TransformToDisplay(SuggestionCity city)
        {
            this.Name = city.Name;
        }
    }
}