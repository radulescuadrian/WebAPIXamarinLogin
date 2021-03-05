using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Login.Services
{
    public class ApiServices
    {
        public async Task LoginAsync(string username, string password)
        {
            var URI = "https://192.168.1.116:44344/Token";
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

            Debug.WriteLine(content);
        }
    }
}
