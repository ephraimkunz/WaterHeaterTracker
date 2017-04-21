using System;
using System.Collections.Generic;
namespace WaterHeaterTracker
{
    public class EnumUtil
    {
        public EnumUtil()
        {
        }

        public static Manufacturer ParseManufacturerString(string name){
            switch(name){
                case "A.O. Smith":
                    return Manufacturer.AOSmith;
                case "Bradford White":
                    return Manufacturer.BradfordWhite;
                case "American Standard":
                    return Manufacturer.AmericanStandard;
                default:
                    Manufacturer result = Manufacturer.AmericanStandard; //Default if we can't parse anything
                    Enum.TryParse(name, out result);
                    return result;
            }
        }

        public static String ParseManufacturerEnum(Manufacturer man){
            switch (man)
            {
                case Manufacturer.AOSmith:
                    return "A.O. Smith";
                case Manufacturer.BradfordWhite:
                    return "Bradford White";
                case Manufacturer.AmericanStandard:
                    return "American Standard";
                default:
                    return man.ToString();
            }
        }

        public static IList<String> GetManufacturerNames()
        {
            var names = new List<String>();
            foreach (Manufacturer value in Enum.GetValues(typeof(Manufacturer)))
            {
                
                names.Add(ParseManufacturerEnum(value));
            }
            names.Sort();
            return names;
        }
    }
}
