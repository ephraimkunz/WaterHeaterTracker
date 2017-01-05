using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;
using XLabs.Ioc;
using XLabs.Platform.Device;
using XLabs.Platform.Services;

namespace WaterHeaterTracker
{
    public class SyncManager
    {
        public static MobileServiceClient MobileService { get; set; }
        public static IMobileServiceTable<WaterHeater> heaterTable;

        public SyncManager()
        {
            MobileService = new MobileServiceClient("https://waterheatertracker.azurewebsites.net");
            heaterTable = MobileService.GetTable<WaterHeater>();

        }

        /// <summary>
        /// Creates the heater record.
        /// </summary>
        /// <returns><c>true</c>, if heater record was created, <c>false</c> otherwise.</returns>
        /// <param name="heater">Heater.</param>
        public bool createHeaterRecord(WaterHeater heater)
        {
            var device = Resolver.Resolve<IDevice>();
            NetworkStatus networkStatus = device.Network.InternetConnectionStatus();

            if (networkStatus == NetworkStatus.NotReachable)
            {
                return false;
            }

            heaterTable.InsertAsync(heater);
            return true;
        }

        public async Task<IList<WaterHeater>> GetAllHeaters(){
            return await heaterTable.ToListAsync();
        }
    }
}
