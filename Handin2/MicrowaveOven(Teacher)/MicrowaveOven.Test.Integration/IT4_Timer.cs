using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace MicrowaveOven.Test.Integration
{
    class IT4_Timer
    {
        private ITimer _uut;
        private ICookController _cookController;
        private IDisplay _display;
        private IPowerTube _powerTube;
        private event EventHandler TimerTick;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _powerTube = Substitute.For<IPowerTube>();
            _uut = new Timer();
            _cookController = new CookController(_uut, _display, _powerTube);
        }

        [Test]
        public void TickReceived_TimerTick_DisplayReceivedCorrect()
        {
           ManualResetEvent pause = new ManualResetEvent(false);

            _uut.Start(5000);

            pause.WaitOne(2000);

            _display.Received().ShowTime(0, 3);
        }

        [Test]
        public void ExpiredReceived_TimerExpired_TurnOffPowerTube()
        {
            // Has to call StartCooking before being able to turn isCooking = true
            _cookController.StartCooking(50, 3000);
            ManualResetEvent pause = new ManualResetEvent(false);

            // Override StartCooking - test not dependant on CC
            _uut.Start(1000);

            pause.WaitOne(1500);

            _powerTube.Received().TurnOff();
        }
    }
}
