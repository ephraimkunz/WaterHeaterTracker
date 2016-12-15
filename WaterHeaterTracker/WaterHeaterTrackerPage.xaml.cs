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
            var saved = new SavedHeaters();
            saved.FetchHeaters();
            await Navigation.PushAsync(saved);
        }

        async void OnShowCharts(object sender, EventArgs e){
            var graphs = new GraphPage();
            await Navigation.PushAsync(graphs);
        }
    }
}
