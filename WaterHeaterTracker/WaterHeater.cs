using System;
namespace WaterHeaterTracker
{
    public class WaterHeater
    {
        public Manufacturer Manufacturer { get; set;}
        public int ManufactureYear { get; set;}
        public DateTime Created { get; set;}
        public int Capacity { get; set;}
    }

    public enum Manufacturer{
        Rheem,
        BradfordWhite,
        AOSmith,
        AmericanStandard,
        GE
    }
}
