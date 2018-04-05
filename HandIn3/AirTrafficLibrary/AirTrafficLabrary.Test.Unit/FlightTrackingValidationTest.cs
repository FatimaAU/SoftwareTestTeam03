using System;
using System.Collections.Generic;
using AirTrafficLibrary;
using NUnit.Framework;

namespace AirTrafficLabrary.Test.Unit
{
    [TestFixture]
    public class FlightTrackingValidationTest
    {
        private List<string> FlightPosition;

        [SetUp]
        public void Setup()
        {
            FlightPosition = new List<string>();
            FlightPosition.Add("TAGGGG");
            FlightPosition.Add("50000");
            FlightPosition.Add("50000");
            FlightPosition.Add("5000");
            FlightPosition.Add("202012121212121");
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateInsideUpperMonitor_ReturnsTrue()
        {
            FlightPosition[1] = "90000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateOutsideUpperMonitor_ReturnsFalse()
        {
            FlightPosition[1] = "90001";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateOutsideLowerMonitor_ReturnsFalse()
        {
            FlightPosition[1] = "9999";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateInsideLowerMonitor_ReturnsTrue()
        {
            FlightPosition[1] = "10000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateInsideUpperMonitor_ReturnsTrue()
        {
            FlightPosition[2] = "90000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateOutsideUpperMonitor_ReturnsFalse()
        {
            FlightPosition[2] = "90001";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateOutsideLowerMonitor_ReturnsFalse()
        {
            FlightPosition[2] = "9999";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateInsideLowerMonitor_ReturnsTrue()
        {
            FlightPosition[2] = "10000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeInsideUpperMonitor_ReturnsTrue()
        {
            FlightPosition[3] = "20000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeOutsideUpperMonitor_ReturnsFalse()
        {
            FlightPosition[3] = "20001";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeOutsideLowerMonitor_ReturnsFalse()
        {
            FlightPosition[3] = "499";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeInsideLowerMonitor_ReturnsTrue()
        {
            FlightPosition[3] = "500";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(FlightPosition), Is.EqualTo(true));
        }

    }
}

