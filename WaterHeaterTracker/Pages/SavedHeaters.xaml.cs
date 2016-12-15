using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WaterHeaterTracker
{
    public partial class SavedHeaters : ContentPage
    {
        public SavedHeaters()
        {
            InitializeComponent();
        }

        public async void FetchHeaters(){
            SyncManager manager = new SyncManager();
            savedHeaters.ItemsSource = await manager.GetAllHeaters();
        }
    }
}
