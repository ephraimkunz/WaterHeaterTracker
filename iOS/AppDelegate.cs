using System;
using System.Collections.Generic;
using System.Linq;
using OxyPlot.Xamarin.Forms.Platform.iOS;
using XLabs.Ioc;
using XLabs.Platform.Device;

using Foundation;
using UIKit;

namespace WaterHeaterTracker.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : XLabs.Forms.XFormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();
            global::Xamarin.Forms.Forms.Init();
            OxyPlot.Xamarin.Forms.Platform.iOS.PlotViewRenderer.Init();

            var container = new SimpleContainer();
            container.Register<IDevice>(t => AppleDevice.CurrentDevice);
            Resolver.SetResolver(container.GetResolver());

            LoadApplication(new App());

            return base.FinishedLaunching(app, options);
        }
    }
}
