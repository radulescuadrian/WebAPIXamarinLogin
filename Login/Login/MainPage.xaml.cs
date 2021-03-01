using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Models;
using Xamarin.Forms;

namespace Login
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SecondaryPage());
            MessagingCenter.Unsubscribe<Numbers>(this, "ReciveData");
            MessagingCenter.Subscribe<Numbers>(this, "ReciveData", (value) =>
            {
                if (value.number1 != 0 && value.number2 != 0)
                {
                    LabelMessage.Text = "Sum of " + value.number1 + " and " + value.number2 +
                                        " is " + (value.number1 + value.number2);
                    MessagingCenter.Unsubscribe<Numbers>(this,"ReciveData");
                }
                else
                {
                    MessagingCenter.Unsubscribe<Numbers>(this, "ReciveData");
                    LabelMessage.Text = "Null Values";
                }
            });
        }
    }
}
