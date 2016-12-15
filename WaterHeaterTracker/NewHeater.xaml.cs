using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WaterHeaterTracker
{
    public partial class NewHeater : ContentPage
    {
        public NewHeater()
        {
            InitializeComponent();

            //Add values for manufacturer picker
            var enumVals = EnumUtil.GetManufacturerNames();
            manufacturer.Items.Clear();
            foreach(var enumVal in enumVals){
                manufacturer.Items.Add(enumVal);
            };
            manufacturer.SelectedIndex = 0;

            //Add date values for manufactured date picker
            //From 1980 to current day
            manufactured.Items.Clear();
            for (int i = DateTime.Now.Year; i >= 1980; i--){
                manufactured.Items.Add(i.ToString());
            }
            manufactured.SelectedIndex = 20; //20 years ago default failure time (warranty usually expires here)
        }

        async void SaveClicked(object sender, EventArgs e){
            //Persist the new heater to the cloud
            WaterHeater heater = new WaterHeater
            {
                Capacity = (int)capacity.Value,
                Created = created.Date,
                ManufactureYear = Int32.Parse(manufactured.Items[manufactured.SelectedIndex]),
                Manufacturer = EnumUtil.ParseManufacturerString(manufacturer.Items[manufacturer.SelectedIndex]),
                HasSoftener = hasSoftener.IsToggled
            };

            SyncManager manager = new SyncManager();
            manager.createHeaterRecord(heater);

            await Navigation.PopAsync();
        }
    }
}
