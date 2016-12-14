using System;
using System.Collections.Generic;
namespace WaterHeaterTracker
{
    public class EnumUtil
    {
        public EnumUtil()
        {
        }

        public static Manufacturer ParseManufacturer(string name){
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

        public static IList<String> GetManufacturerNames()
        {
            var names = new List<String>();
            foreach (string value in Enum.GetNames(typeof(Manufacturer)))
            {
                string stringValue;
                switch (value)
                {
                    case "AOSmith":
                        stringValue = "A.O. Smith";
                        break;
                    case "BradfordWhite":
                        stringValue = "Bradford White";
                        break;
                    case "AmericanStandard":
                        stringValue = "American Standard";
                        break;
                    default:
                        stringValue = value;
                        break;
                }
                names.Add(stringValue);
            }
            names.Sort();
            return names;
        }
    }
}
