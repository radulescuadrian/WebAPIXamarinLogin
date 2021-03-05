using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace Login.Views.Maps
{
    public class MapRegionPageCode : ContentPage
    {
        public MapRegionPageCode()
        {
            Title = "Map region demo";

            Position position = new Position(36.9628066, -122.0194722);
            MapSpan mapSpan = new MapSpan(position, 0.01, 0.01);
            //MapSpan mapSpan = MapSpan.FromCenterAndRadius(position, Distance.FromKilometers(0.444));

            Map map = new Map(mapSpan);

            Content = new StackLayout
            {
                Margin = new Thickness(10),
                Children = { map }
            };
        }
    }
}
