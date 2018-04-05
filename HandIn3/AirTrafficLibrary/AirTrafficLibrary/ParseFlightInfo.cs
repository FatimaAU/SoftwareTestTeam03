using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirTrafficLibrary
{
    static class ParseFlightInfo
    {
        public static List<string> Parse(string data)
        {
            List<string> FlightList = new List<string>();

            FlightList = data.Split(';').ToList();
            return FlightList;
        }
    }
}
