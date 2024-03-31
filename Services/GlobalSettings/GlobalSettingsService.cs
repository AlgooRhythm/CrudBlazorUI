namespace WeatherForecastUI.Services.GlobalSettings
{
    public class GlobalSettingsService
    {
        public bool IsUsingExternalAPI { get; set; } = true;

        public string APIurl { get; set; } = "https://localhost:7186/";

        public event Action OnChange;

        public void SetGlobalString(bool isUsingExternalAPI, string API_URL)
        {
            IsUsingExternalAPI = isUsingExternalAPI;
            APIurl = API_URL;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
