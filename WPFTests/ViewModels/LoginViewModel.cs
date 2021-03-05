using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WPFTests.Models;
using WPFTests.Services;
using WPFTests.Views;

namespace WPFTests.ViewModels
{
    public class LoginViewModel
    {
        private ApiServices _apiServices = new ApiServices();
        public LoginModel login;

        public string Username { get; set; } = "test@test.com";
        public string Password { get; set; } = "Test?123";
        public bool IsLoggedIn { get; set; } = false;
        public Action CloseAction { get; set; }

        public async void Login()
        {
            login = await _apiServices.LoginAsync(Username, Password);

            if (login.access_token != null)
            {
                MainWindow window = new MainWindow(login);
                window.Show();
            }
        }
    }
}
