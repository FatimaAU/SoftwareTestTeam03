using System.Collections.Generic;
using AirTrafficMonitoring.Classes;
using NUnit.Framework;

namespace AirTrafficMonitoring.Test.Unit
{
    [TestFixture]
    public class FlightTrackingValidationTest
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
        public void FlightTrackingValidation_XCoordinateInsideUpperMonitor_ReturnsTrue()
        {
            _flightPosition[1] = "90000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateOutsideUpperMonitor_ReturnsFalse()
        {
            _flightPosition[1] = "90001";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateOutsideLowerMonitor_ReturnsFalse()
        {
            _flightPosition[1] = "9999";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_XCoordinateInsideLowerMonitor_ReturnsTrue()
        {
            _flightPosition[1] = "10000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateInsideUpperMonitor_ReturnsTrue()
        {
            _flightPosition[2] = "90000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateOutsideUpperMonitor_ReturnsFalse()
        {
            _flightPosition[2] = "90001";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateOutsideLowerMonitor_ReturnsFalse()
        {
            _flightPosition[2] = "9999";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_YCoordinateInsideLowerMonitor_ReturnsTrue()
        {
            _flightPosition[2] = "10000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeInsideUpperMonitor_ReturnsTrue()
        {
            _flightPosition[3] = "20000";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeOutsideUpperMonitor_ReturnsFalse()
        {
            _flightPosition[3] = "20001";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeOutsideLowerMonitor_ReturnsFalse()
        {
            _flightPosition[3] = "499";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(false));
        }

        [Test]
        public void FlightTrackingValidation_AltitudeInsideLowerMonitor_ReturnsTrue()
        {
            _flightPosition[3] = "500";
            Assert.That(FlightTrackingValidation.MonitoredFlightData(_flightPosition), Is.EqualTo(true));
        }

    }
}

