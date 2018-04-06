using System.Collections.Generic;
using NUnit.Framework;

namespace AirTrafficLabrary.Test.Unit
{
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
            _flightPosition.Add("202012121212121");
        }

        [Test]
        public void Date__ReturnsTrue()
        {
            //_flightPosition[1] = "90000";
            //Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

    }
}
