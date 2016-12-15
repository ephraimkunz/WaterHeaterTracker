using System;
namespace WaterHeaterTracker
{
    public class WaterHeater
    {
        public Manufacturer Manufacturer { get; set;}
        public int ManufactureYear { get; set;}
        public DateTime Created { get; set;}
        public int Capacity { get; set;}
        public Guid Id { get; set;}
        public bool HasSoftener { get; set;}

        public int Age
        {
            get
            {
                return DateTime.Now.Year - ManufactureYear;
            }
        }

        public override string ToString(){
            return String.Format("{0} - {1} gallons, {2} years, {3}", 
                                 EnumUtil.ParseManufacturerEnum(Manufacturer), 
                                 Capacity,
                                 Age,
                                 HasSoftener ? "has softener" : "no softener");
        }
    }


    public enum Manufacturer{
        Rheem,
        BradfordWhite,
        AOSmith,
        AmericanStandard,
        GE
    }
}
