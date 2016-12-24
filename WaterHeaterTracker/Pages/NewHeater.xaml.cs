using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WaterHeaterTracker
{
    public partial class NewHeater : ContentPage
    {
        const int DEFAULT_FAILURE_INDEX = 20; //20 years ago default failure time
        public NewHeater()
        {
            InitializeComponent();

            //Disable serial number field by default
            serialNumber.IsEnabled = false;

            //Don't show the serialYearKey by default
            serialYearKey.IsVisible = false;

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
            manufactured.SelectedIndex = DEFAULT_FAILURE_INDEX; 
        }

        void ManufacturerIndexChanged(object sender, EventArgs e){
            bool isBradfordWhite = 
                manufacturer.Items[manufacturer.SelectedIndex] == EnumUtil.ParseManufacturerEnum(Manufacturer.BradfordWhite);

            serialNumber.IsEnabled = isBradfordWhite;
            serialYearKey.IsVisible = isBradfordWhite;
        }

        async void SaveClicked(object sender, EventArgs e){
            //Persist the new heater to the cloud
            WaterHeater heater = new WaterHeater
            {
                Capacity = (int)capacity.Value,
                ManufactureYear = Int32.Parse(manufactured.Items[manufactured.SelectedIndex]),
                Manufacturer = EnumUtil.ParseManufacturerString(manufacturer.Items[manufacturer.SelectedIndex]),
                HasSoftener = hasSoftener.IsToggled
            };

            SyncManager manager = new SyncManager();
            manager.createHeaterRecord(heater);

            await Navigation.PopAsync();
        }

        void SerialCompleted(object sender, EventArgs e){
            var serial = ((Entry)sender).Text;
            var year = getYearForSerialNumber(serial);
            manufactured.SelectedIndex = manufactured.Items.IndexOf(year.ToString());
        }

        int getYearForSerialNumber(string serial){
            var lookup = new Dictionary<string, int>
            {
                {"M", 1995},
                {"N", 1996},
                {"P", 1997},
                {"0", 1997}, //Due to a computer error there were some OA serial water heaters manufactured. They were built in January of 1997.
                {"S", 1998},
                {"T", 1999},
                {"W", 2000},
                {"X", 2001},
                {"Y", 2002},
                {"Z", 2003},
                {"A", 2004},
                {"B", 2005},
                {"C", 2006},
                {"D", 2007},
                {"E", 2008},
                {"F", 2009},
                {"G", 2010},
                {"H", 2011},
                {"J", 2012},
                {"K", 2013},
                {"L", 2014}
            };
            if(serial.Length > 0 && lookup.ContainsKey(serial[0].ToString().ToUpper()))
                return lookup[serial[0].ToString().ToUpper()];
            return Int32.Parse(manufactured.Items[DEFAULT_FAILURE_INDEX]);
        }

    }
}
