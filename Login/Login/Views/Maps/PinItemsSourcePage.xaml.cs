using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Login.ViewModel.MapsViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Login.Views.Maps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinItemsSourcePage : ContentPage
    {
        public PinItemsSourcePage()
        {
            InitializeComponent();
            BindingContext = new PinItemsSourcePageViewModel();
            map.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(39.8283459, -98.5794797), Distance.FromMiles(1500)));
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }
    }
}