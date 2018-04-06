using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace AirTrafficMonitoring.Test.Unit
{
    [TestFixture]
    public class AirTrafficMonitoringUnitTest
    {
        private List<string> FlightPosition;

        [SetUp]
        public void Setup()
        {
            FlightPosition.Add("TAGGGG");
            FlightPosition.Add("50000");
            FlightPosition.Add("50000");
            FlightPosition.Add("5000");
            FlightPosition.Add("202012121212121");
        }

        [Test]
        public void FlightTrackingValidation_MonitoredFlightData_ReturnsTrue()
        {
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

    }
}
