using Xamarin.Forms;
using System;

namespace WaterHeaterTracker
{
    public partial class WaterHeaterTrackerPage : ContentPage
    {
        public WaterHeaterTrackerPage()
        {
            InitializeComponent();
        }

        async void OnAdd(object sender, EventArgs e){
            await Navigation.PushAsync(new NewHeater());
        }

        async void OnEdit(object sender, EventArgs e){
            await Navigation.PushAsync(new SavedHeaters());
        }

        async void OnShowCharts(object sender, EventArgs e){
            
        }
    }
}
