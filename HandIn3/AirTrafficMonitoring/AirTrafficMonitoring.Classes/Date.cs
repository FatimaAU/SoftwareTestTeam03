using System;
using System.Collections.Generic;

namespace AirTrafficMonitoring.Classes
{
    public class Date
    {
        public static List<string> FormatDate(List<string> flightData)
        {
        //    if (flightData[4].Length != 15)
        //        throw 
            List<string> formattedFlightList = new List<string>();

            for (int i = 0; i < flightData.Count - 1; i++)
                formattedFlightList.Add(flightData[i]);

            string date = flightData[4];

            var year = date.Substring(0, 4);
            var month = date.Substring(4, 2);
            var day = date.Substring(6, 2);
            var hour = date.Substring(8, 2);
            var min = date.Substring(10, 2);
            var second = date.Substring(12, 2);
            var millisecond = date.Substring(14, 3);

            if (date.Substring(6, 1).Contains("0"))
                day = date.Substring(7, 1);

            //Parsing Month Enum to string

            Month m = (Month)Enum.Parse(typeof(Month), month);

            switch (date.Substring(7, 1))
            {
                case "1":
                    if (date.Substring(6, 1).Contains("1"))
                    {
                        day = day + "th";
                        break;
                    }
                    day = day + "st";
                    break;
                case "2":
                    if (date.Substring(6, 1).Contains("1"))
                    {
                        day = day + "th";
                        break;
                    }
                    day = day + "nd";
                    break;
                case "3":
                    if (date.Substring(6, 1).Contains("1"))
                    {
                        day = day + "th";
                        break;
                    }
                    day = day + "rd";
                    break;
                default:
                    day = day + "th";
                    break;
            }

            string dateOutput = m + " " + day + ", " + year + ", at " + hour + ":" + min + ":" + second + " and " +
                                millisecond + " milliseconds";

            formattedFlightList.Add(dateOutput);

            return formattedFlightList;

        }

        public enum Month
        {
            January = 01,
            February = 02,
            March = 03,
            April = 04,
            May = 05,
            June = 06,
            July = 07,
            August = 08,
            September = 09,
            October = 10,
            November = 11,
            December = 12
        }
    }
}
