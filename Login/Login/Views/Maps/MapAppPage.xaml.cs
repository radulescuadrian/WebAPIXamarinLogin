using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Login.Views.Maps
{
    // WARNING: when adding latitude/longitude values be careful of localization.
    // European (and other countries) use a comma as the separator, which will break the request
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapAppPage : ContentPage
    {
        public MapAppPage()
        {
            InitializeComponent();
        }

        async void OnLocationButtonClicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?q=394+Pacific+Ave+San+Francisco+CA");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // opens the Maps app directly
                await Launcher.OpenAsync("geo:0,0?q=Strada+Cobadin+7A+Bucuresti+Sector+5+Romania");
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                await Launcher.OpenAsync("bingmaps:?where=394 Pacific Ave San Francisco CA");
            }
        }

        async void OnDirectionButtonClicked(object sender, EventArgs e)
        {
            if (Device.RuntimePlatform == Device.iOS)
            {
                // https://developer.apple.com/library/ios/featuredarticles/iPhoneURLScheme_Reference/MapLinks/MapLinks.html
                await Launcher.OpenAsync("http://maps.apple.com/?daddr=San+Francisco,+CA&saddr=cupertino");
            }
            else if (Device.RuntimePlatform == Device.Android)
            {
                // opens the 'task chooser' so the user can pick Maps, Chrome or other mapping app
                await Launcher.OpenAsync("http://maps.google.com/?daddr=Strada+Cobadin+7A,+Bucuresti,+Sector+5,+Romania&saddr=Centrul+Vechi");
            }
            else if (Device.RuntimePlatform == Device.UWP)
            {
                await Launcher.OpenAsync("bingmaps:?rtp=adr.394 Pacific Ave San Francisco CA~adr.One Microsoft Way Redmond WA 98052");
            }
        }
    }
}