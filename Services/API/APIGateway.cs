using Microsoft.SqlServer.Server;
using System.Net.NetworkInformation;
using System.Text.Json;
using WeatherForecastUI.Services.GlobalSettings;
using WeatherForecastUI.Model;
using System.Net;
using Newtonsoft.Json;
//using WeatherForecastUI.Services.GlobalSettings.GlobalSettingsService;


namespace WeatherForecastUI.Services.API
{
    public class APIGateway
    {
        private readonly HttpClient _httpClient;
        private readonly GlobalSettingsService globalSettingsService;

        public APIGateway(HttpClient httpClient, GlobalSettingsService globalSettingsServices)
        {
            _httpClient = httpClient;
            globalSettingsService = globalSettingsServices;
        }

        #region Staff CRUD
        public async Task<Stream> GetAllStaffList()
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + "api/Home/GetAllStaff";

            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(FullAPI_URL);

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
                else
                {
                    return await response.Content.ReadAsStreamAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured ath the API Endpoint, Error Info" + ex.Message);
            }
            finally { };

        }

        #endregion

        #region Weather Forecast
        public async Task<string> ForecastWeatherExternalAPI(string FullAPI_URL, MultipartFormDataContent formData)
        {
            HttpClient httpClient = new HttpClient();

            try
            {
                HttpResponseMessage response = await httpClient.PostAsync(FullAPI_URL, formData);

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
                else
                {
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured ath the API Endpoint, Error Info" + ex.Message);
            }
            finally { };
        }

        #endregion
    }
}
