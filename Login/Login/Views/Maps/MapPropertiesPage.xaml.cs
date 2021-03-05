using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace Login.Views.Maps
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MapPropertiesPage : ContentPage
    {
        public MapPropertiesPage()
        {
            InitializeComponent();

            scrollEnabledCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            zoomEnabledCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
            moveRegionCheckBox.CheckedChanged += OnCheckBoxCheckedChanged;
        }

        void OnMapClicked(object sender, MapClickedEventArgs e)
        {
            Debug.WriteLine($"MapClick: {e.Position.Latitude}, {e.Position.Longitude}");
        }

        void OnCheckBoxCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            switch (checkBox.StyleId)
            {
                case "scrollEnabledCheckBox":
                    map.HasScrollEnabled = !map.HasScrollEnabled;
                    break;
                case "zoomEnabledCheckBox":
                    map.HasZoomEnabled = !map.HasZoomEnabled;
                    break;
                case "showUserCheckBox":
                    map.IsShowingUser = !map.IsShowingUser;
                    break;
                case "showTrafficCheckBox":
                    map.TrafficEnabled = !map.TrafficEnabled;
                    break;
                case "moveRegionCheckBox":
                    map.MoveToLastRegionOnLayoutChange = !map.MoveToLastRegionOnLayoutChange;
                    break;
            }
        }
    }
}