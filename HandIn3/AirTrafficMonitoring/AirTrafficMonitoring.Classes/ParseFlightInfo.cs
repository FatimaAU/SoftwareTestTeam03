using System.Collections.Generic;
using System.Linq;

namespace AirTrafficMonitoring.Classes
{
    public static class ParseFlightInfo
    {
        public static List<string> Parse(string data)
        {
            List<string> FlightList = new List<string>();

            FlightList = data.Split(';').ToList();
            return FlightList;
        }
    }
}
