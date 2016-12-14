using System;
using Microsoft.WindowsAzure.MobileServices;
using System.Collections.Generic;
using System.Threading.Tasks;
namespace WaterHeaterTracker
{
    public class SyncManager
    {
        public static MobileServiceClient MobileService { get; set; }
        IMobileServiceTable<WaterHeater> heaterTable;

        public SyncManager()
        {
            MobileService = new MobileServiceClient("https://waterheatertracker.azurewebsites.net");
            heaterTable = MobileService.GetTable<WaterHeater>();
        }

        public void createHeaterRecord(WaterHeater heater)
        {
            heaterTable.InsertAsync(heater);
        }

        public async Task<IList<WaterHeater>> GetAllHeaters(){
            return await heaterTable.ToListAsync(); 
        }
    }
}
