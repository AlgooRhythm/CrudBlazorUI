namespace WeatherForecastUI.Model
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public double Temperature {  get; set; }
        public string Summary { get; set; }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
