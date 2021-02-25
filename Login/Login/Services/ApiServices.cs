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
            var headers = new NameValueCollection();
            headers["username"] = username;
            headers["password"] = password;
            headers["grant_type"] = "password";

            try
            {
                using (var wb = new WebClient())
                {
                    var response = wb.UploadValues("https://localhost:44344/Token", "POST", headers);
                    Debug.WriteLine(response.ToString());
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
