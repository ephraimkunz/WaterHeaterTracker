using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using OxyPlot.Xamarin.Android;
using XLabs.Ioc;
using XLabs.Platform.Device;
using Xamarin;

namespace WaterHeaterTracker.Droid
{
    [Activity(Label = "WaterHeaterTracker.Droid", Icon = "@drawable/icon", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : XFormsAppCompatDroid    {
        protected override void OnCreate(Bundle bundle)
        {
            Insights.Initialize("Your API key", this);
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);                                              

            global::Xamarin.Forms.Forms.Init(this, bundle);
            OxyPlot.Xamarin.Forms.Platform.Android.PlotViewRenderer.Init();

            var container = new SimpleContainer();
            container.Register<IDevice>(t => AndroidDevice.CurrentDevice);
            Resolver.SetResolver(container.GetResolver());

            LoadApplication(new App());
        }
    }
}
