using System.Collections.Generic;
using AirTrafficMonitoring.Classes;
using NUnit.Framework;

namespace AirTrafficMonitoring.Test.Unit
{
    [TestFixture]
    class DateTest
    {
        private List<string> _flightPosition;
        private List<string> _flightList;

        [SetUp]
        public void Setup()
        {
            _flightPosition = new List<string> {"TAGGGG", "50000", "50000", "5000" };
            // For testing that correct string is returned
            _flightList = new List<string> { "TAGGGG", "50000", "50000", "5000" };

        }

        [TestCase("01", "January")]
        [TestCase("02", "February")]
        [TestCase("03", "March")]
        [TestCase("04", "April")]
        [TestCase("05", "May")]
        [TestCase("06", "June")]
        [TestCase("07", "July")]
        [TestCase("08", "August")]
        [TestCase("09", "September")]
        [TestCase("10", "October")]
        [TestCase("11", "November")]
        [TestCase("12", "December")]
        public void Date_NumberOfMonthConverts_ReturnsFormattedOutput(string number, string month)
        {
            _flightList.Add($"{month} 11th, 2018, at 11:11:11 and 111 milliseconds"); 
            _flightPosition.Add($"2018{number}11111111111");

            Assert.AreEqual(_flightList, Date.FormatDate(_flightPosition));
        }

        [TestCase("01", "st", "1")]
        [TestCase("02", "nd", "2")]
        [TestCase("03", "rd", "3")]
        [TestCase("04", "th", "4")]
        [TestCase("05", "th", "5")]
        [TestCase("10", "th")]
        [TestCase("11", "th")]
        [TestCase("12", "th")]
        [TestCase("13", "th")]
        [TestCase("21", "st")]
        [TestCase("22", "nd")]
        [TestCase("23", "rd")]
        [TestCase("24", "th")]
        [TestCase("31", "st")]
        public void Date_DateOutputCorrect_ReturnsFormattedOutput(string number, string postfix, string shortNumber = null)
        {
            // If shortNumber is null assign "number" to it
            shortNumber = shortNumber ?? number;

            _flightList.Add($"November {shortNumber}{postfix}, 2018, at 11:11:11 and 111 milliseconds");
            _flightPosition.Add($"201811{number}111111111");

            Assert.AreEqual(_flightList, Date.FormatDate(_flightPosition));
        }

    }
}
