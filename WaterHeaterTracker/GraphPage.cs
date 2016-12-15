using System;
using OxyPlot.Xamarin.Forms;
using Xamarin.Forms;
using OxyPlot;
using System.Collections.Generic;
using System.Linq;
using OxyPlot.Axes;
using OxyPlot.Series;

namespace WaterHeaterTracker
{
    public class GraphPage : ContentPage
    {
     

        public async void GenerateGraph()
        {
            SyncManager manager = new SyncManager();
            IList<WaterHeater> allHeaters = await manager.GetAllHeaters();

            var model = new PlotModel { 
                Title = "Water Heater Lifespan",
                LegendPlacement = LegendPlacement.Outside,
                LegendPosition = LegendPosition.BottomCenter,
                LegendOrientation = LegendOrientation.Horizontal,
                LegendBorderThickness = 0
            };

            var s1 = new BarSeries { Title = "A.O. Smith", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Purple };
            AddSegmentedBucketItems( s1, allHeaters.Where(arg => arg.Manufacturer == Manufacturer.AOSmith));

            var s2 = new BarSeries { Title = "American Standard", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Green };
            AddSegmentedBucketItems( s2, allHeaters.Where(arg => arg.Manufacturer == Manufacturer.AmericanStandard));

            var s3 = new BarSeries { Title = "Bradford White", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Orange };
            AddSegmentedBucketItems( s3, allHeaters.Where(arg => arg.Manufacturer == Manufacturer.BradfordWhite));

            var s4 = new BarSeries { Title = "GE", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Black };
            AddSegmentedBucketItems( s4, allHeaters.Where(arg => arg.Manufacturer == Manufacturer.GE));

            var s5 = new BarSeries { Title = "Rheem", StrokeColor = OxyColors.Black, StrokeThickness = 1, FillColor = OxyColors.Red };
            AddSegmentedBucketItems( s5, allHeaters.Where(arg => arg.Manufacturer == Manufacturer.Rheem));

            var categoryAxis = new CategoryAxis { Position = AxisPosition.Left };
            categoryAxis.Labels.Add("0-10");
            categoryAxis.Labels.Add("11-15");
            categoryAxis.Labels.Add("16-20");
            categoryAxis.Labels.Add("20 +");
            categoryAxis.Title = "Years in service";

            var valueAxis = new LinearAxis { Position = AxisPosition.Bottom, MinimumPadding = 0, MaximumPadding = 0.06, AbsoluteMinimum = 0, Title = "Count"};
            model.Series.Add(s1);
            model.Series.Add(s2);
            model.Series.Add(s3);
            model.Series.Add(s4);
            model.Series.Add(s5);

            model.Axes.Add(categoryAxis);
            model.Axes.Add(valueAxis);

            Content = new PlotView
            {
                Model = model,
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
            };
        }

        public void AddSegmentedBucketItems(BarSeries s, IEnumerable<WaterHeater> heaterData){
            s.Items.Add(new BarItem { Value = heaterData.Where(arg => arg.Age <= 10).Count() });
            s.Items.Add(new BarItem { Value = heaterData.Where(arg => arg.Age > 10 && arg.Age <= 15).Count() });
            s.Items.Add(new BarItem { Value = heaterData.Where(arg => arg.Age > 15 && arg.Age <= 20).Count() });
            s.Items.Add(new BarItem { Value = heaterData.Where(arg => arg.Age > 20).Count() });
        }
    }
}

