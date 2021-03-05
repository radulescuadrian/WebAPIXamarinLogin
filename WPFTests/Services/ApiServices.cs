using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WPFTests.Models;

namespace WPFTests.Services
{
    public class ApiServices
    {
        #region Login
        public async Task<LoginModel> LoginAsync(string username, string password)
        {
            var URI = "https://localhost:44344/Token";
            var headers = new List<KeyValuePair<string, string>>
            {
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("grant_type", "password")
            };

            var request = new HttpRequestMessage(HttpMethod.Post, URI);
            request.Content = new FormUrlEncodedContent(headers);

            var client = new HttpClient();
            var response = await client.SendAsync(request);

            var content = await response.Content.ReadAsStringAsync();

            var login = JsonConvert.DeserializeObject<LoginModel>(content);

            return login;
        }
        #endregion

        #region GET values
        public async Task<IEnumerable<string>> GetValuesAsync(string token)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = new
                AuthenticationHeaderValue($"bearer", token);

            var json = await client.GetStringAsync("https://localhost:44344/api/values");

            var values = JsonConvert.DeserializeObject<IEnumerable<string>>(json);

            return values;
        } 
        #endregion
    }
}
