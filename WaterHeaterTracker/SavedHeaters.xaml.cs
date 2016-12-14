using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WaterHeaterTracker
{
    public partial class SavedHeaters : ContentPage
    {
        public static IList<String> SavedHeaterItems { get; set; }
        public SavedHeaters()
        {
            InitializeComponent();
            SavedHeaterItems = new List<String> { "test 1", "test 2", "test 3" };
        }
    }
}
