using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using AirTrafficLibrary;
using NUnit.Framework;

namespace AirTrafficLabrary.Test.Unit
{
    [TestFixture]
    class DateTest
    {
        private List<string> _flightPosition;

        [SetUp]
        public void Setup()
        {
            _flightPosition = new List<string>();
            _flightPosition.Add("TAGGGG");
            _flightPosition.Add("50000");
            _flightPosition.Add("50000");
            _flightPosition.Add("5000");
            _flightPosition.Add("20181111111111111");
        }

        [Test]
        public void Date__ReturnsTrue()
        {
            List<string> _flightList = new List<string>();

            
            _flightList.Add("TAGGGG");
            _flightList.Add("50000");
            _flightList.Add("50000");
            _flightList.Add("5000");
            _flightList.Add("November 11th, 2018, at 11:11:11 and 111 milliseconds");

            //List<string> _formattedFlightPosition = Date.FormatDate(_flightPosition);

            Assert.AreEqual(_flightList, Date.FormatDate(_flightPosition));
        }

    }
}
