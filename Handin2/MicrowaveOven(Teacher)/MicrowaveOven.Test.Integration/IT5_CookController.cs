using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace MicrowaveOven.Test.Integration
{
    class IT5_CookController
    {
        private CookController _uut;
        private ITimer _timer;
        private IDisplay _display;
        private IPowerTube _powerTube;
        private IOutput _output;
        private IUserInterface _userInterface;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _display = Substitute.For<IDisplay>();
            _timer = Substitute.For<ITimer>();
            _userInterface = Substitute.For<IUserInterface>();
            _powerTube = Substitute.For<IPowerTube>();
            _uut = new CookController(_timer, _display, _powerTube, _userInterface);
        }

        [Test]
        public void OnTimerTick_ShowTime_DisplayCorrectOutput()
        {
            _uut.StartCooking(50, 6000);

            _timer.TimeRemaining.Returns(5000);
            _timer.TimerTick += Raise.EventWith(_timer, EventArgs.Empty);

            _display.Received().ShowTime(0,5);
          
        }

        [Test]
        public void StartCooking_TurnOnPowerTube_PowerTubeOn()
        {
            _uut.StartCooking(50, 5000);
            _powerTube.Received().TurnOn(50);
        }

        [Test]
        public void OnTimerExpired_TurnOffPowerTube_PowerTubeOff()
        {
            _uut.StartCooking(50, 1000);

            _timer.TimeRemaining.Returns(0);
            _timer.Expired += Raise.EventWith(_timer, EventArgs.Empty);

            _powerTube.Received().TurnOff();
        }

        [Test]
        public void CookingStart_TimerStarted_TimerReceivedStart()
        {
            _uut.StartCooking(50, 2000);

            _timer.Received().Start(2000);
        }

        [Test]
        public void CookingStop_TimerStopped_TimerReceivedStop()
        {
            _uut.StartCooking(50, 2000);
            _uut.Stop();

            _timer.Received().Stop();
        }

        [Test]
        public void OnTimerExpired_CookingIsDone_UIReceivedDone()
        {
            _uut.StartCooking(50, 2000);

            _timer.Expired += Raise.EventWith(_timer, EventArgs.Empty);

            _userInterface.Received().CookingIsDone();
        }

    }
}
