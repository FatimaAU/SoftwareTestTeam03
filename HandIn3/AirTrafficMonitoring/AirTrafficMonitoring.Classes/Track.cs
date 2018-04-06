using System;
using System.Collections.Generic;

namespace AirTrafficMonitoring.Classes
{
    public class Track
    {
        private string Tag;
        private string XCoordinate;
        private string YCoordinate;
        private string Altitude;
        private string TimeStamp;

        public Track(List<string> strList)
        {
            Tag = strList[0];
            XCoordinate = strList[1];
            YCoordinate = strList[2];
            Altitude = strList[3];
            TimeStamp = strList[4];
        }

        public void Print()
        {
            Console.WriteLine("Tag:\t\t" + Tag);
            Console.WriteLine("X coordinate:\t" + XCoordinate + " meters");
            Console.WriteLine("Y coordinate:\t" + YCoordinate + " meters");
            Console.WriteLine("Altitide:\t" + Altitude + " meters");
            Console.WriteLine("Timestamp:\t" + TimeStamp);
            Console.WriteLine();
        }
    }


}
