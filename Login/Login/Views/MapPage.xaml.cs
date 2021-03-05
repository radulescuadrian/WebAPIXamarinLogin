using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;
using Map = Xamarin.Forms.Maps.Map;

namespace Login.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPage : ContentPage
    {
        public MapPage()
        {
            GetLocation();
        }

        public async void GetLocation()
        {
            Geocoder geoCoder = new Geocoder();
            

            IEnumerable<Position> approximateLocations = await geoCoder.GetPositionsForAddressAsync("Strada Cobadin 7A, Sector 5, Bucuresti, Romania");
            Position position = approximateLocations.FirstOrDefault();
            string coordinates = $"{position.Latitude}, {position.Longitude}";

            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            Map map = new Map(mapSpan);
            map.IsShowingUser = true;
            map.HasScrollEnabled = false;

            var pin = new Pin()
            {
                Position = position,
                Label = "Destination"
            };
            map.Pins.Add(pin);

            Content = map;
        }
    }
}