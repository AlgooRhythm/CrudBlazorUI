using Microsoft.SqlServer.Server;
using System.Net.NetworkInformation;
using System.Text.Json;
using WeatherForecastUI.Services.GlobalSettings;
using WeatherForecastUI.Model;
using System.Net;
using Newtonsoft.Json;

namespace WeatherForecastUI.Services.API
{
    public class APIGateway
    {
        private readonly HttpClient _httpClient;
        private readonly GlobalSettingsService globalSettingsService;

        string GetAllStaffListAPIurl = "api/Staff/GetAllStaff";
        string GetStaffByIdAPIurl = "api/Staff/GetStaffById/";
        string CreateStaffAPIurl = "api/Staff/CreateNewStaff";
        string EditStaffAPIurl = "api/Staff/EditStaff";
        string DeleteStaffAPIurl = "api/Staff/DeleteStaff/";
        string GetWeatherForecastAPIurl = "api/WeatherForecast/GetWeatherForecast";

        public APIGateway(HttpClient httpClient, GlobalSettingsService globalSettingsServices)
        {
            _httpClient = httpClient;
            globalSettingsService = globalSettingsServices;
        }

        #region Staff CRUD
        public async Task<Stream> GetAllStaffList()
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + GetAllStaffListAPIurl;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(FullAPI_URL);

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

        public async Task<string> GetStaffbyId(int id)
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + GetStaffByIdAPIurl + id;

            try
            {
                HttpResponseMessage response = await _httpClient.GetAsync(FullAPI_URL);

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
                else
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    return await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured ath the API Endpoint, Error Info" + ex.Message);
            }
            finally { };
        }

        public async void CreateNewStaff(MultipartFormDataContent formData)
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + CreateStaffAPIurl;

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(FullAPI_URL, formData);

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured ath the API Endpoint, Error Info" + ex.Message);
            }
            finally { };
        }

        public async void EditStaff(MultipartFormDataContent formData)
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + EditStaffAPIurl;

            try
            {
                HttpResponseMessage response = await _httpClient.PutAsync(FullAPI_URL, formData);

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error Occured ath the API Endpoint, Error Info" + ex.Message);
            }
            finally { };
        }

        public async void DeleteStaff(int id)
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + DeleteStaffAPIurl + id;

            try
            {
                HttpResponseMessage response = await _httpClient.DeleteAsync(FullAPI_URL);

                if (!response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    throw new Exception("Error Occured at the API Endpoint, Error Info " + result);
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
        public async Task<string> ForecastWeatherExternalAPI(MultipartFormDataContent formData)
        {
            string FullAPI_URL = globalSettingsService.APIurl.ToString() + GetWeatherForecastAPIurl;

            try
            {
                HttpResponseMessage response = await _httpClient.PostAsync(FullAPI_URL, formData);

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
