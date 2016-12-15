using System;
using OxyPlot.Xamarin.Forms;
using Xamarin.Forms;
using OxyPlot;

namespace WaterHeaterTracker
{
    public class GraphPage : ContentPage
    {
        public GraphPage()
        {
            Content = new PlotView
            {
                Model = new PlotModel { Title = "Hello, Forms!" },
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
            };
        }
    }
}

