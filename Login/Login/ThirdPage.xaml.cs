using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdPage : ContentPage
    {
        public int fValue = 0;
        public ThirdPage(int number1)
        {
            fValue = number1;
            InitializeComponent();
            LabelFNum.Text = $"First number is {fValue}";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            Numbers val = new Numbers();
            val.number1 = fValue;
            val.number2 = Convert.ToInt32(Num2.Text);

            MessagingCenter.Send<Numbers>(val, "ReciveData");
            //can just pop 1 page, depends on what you want to do
            await Navigation.PopToRootAsync();
        }
    }
}