using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
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
        private IPowerTube _powerTube;
        private IOutput _output;
        private IUserInterface _userInterface;
        private IButton _tButton;
        private IButton _pButton;
        private IButton _scButton;
        private IDoor _door;
        private IDisplay _display;
        private ITimer _timer;
        private ILight _light;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _display = new Display(_output);
            _powerTube = new PowerTube(_output);
            _timer = Substitute.For<ITimer>();
            _tButton = Substitute.For<IButton>();
            _pButton = Substitute.For<IButton>();
            _scButton = Substitute.For<IButton>();
            _door = Substitute.For<IDoor>();
            _light = Substitute.For<ILight>();
            _uut = new CookController(_timer, _display, _powerTube);
            _userInterface = new UserInterface(_pButton, _tButton, _scButton, _door, _display, _light, _uut);
            _uut.UI = _userInterface;
        }

        [Test]
        public void OnTimerTick_ShowTime_DisplayCorrectOutput()
        {
            // FROM UI THROUGH CC: 50 W, 1 minute, start
            _userInterface.OnPowerPressed(_pButton, EventArgs.Empty);
            _userInterface.OnTimePressed(_tButton, EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_scButton, EventArgs.Empty);

            _timer.TimeRemaining.Returns(55 * 1000);
            _timer.TimerTick += Raise.EventWith(_timer, EventArgs.Empty);

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("00:55")));

        }

        [Test]
        public void OnTimerExpired_TurnOffPowerTube_PowerTubeOff()
        {
            // FROM UI THROUGH CC: 50 W, 1 minute, start
            _userInterface.OnPowerPressed(_pButton, EventArgs.Empty);
            _userInterface.OnTimePressed(_tButton, EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_scButton, EventArgs.Empty);

            _timer.TimeRemaining.Returns(0);

            _timer.Expired += Raise.EventWith(_timer, EventArgs.Empty);

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));

            //_uut.StartCooking(50, 10);

            //_timer.TimeRemaining.Returns(0);

            //_powerTube.Received().TurnOff();
        }

        [Test]
        public void StartCooking_TurnOnPowerTube_PowerTubeOn()
        {
            // FROM UI THROUGH CC: 50 W, 1 minute, start
            _userInterface.OnPowerPressed(_pButton, EventArgs.Empty);
            _userInterface.OnTimePressed(_tButton, EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_scButton, EventArgs.Empty);

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains( (50 / 7).ToString() )));
        }

        [Test]
        public void CookingStart_TimerStarted_TimerReceivedStart()
        {
            // FROM UI THROUGH CC: 50 W, 1 minute, start
            _userInterface.OnPowerPressed(_pButton, EventArgs.Empty);
            _userInterface.OnTimePressed(_tButton, EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_scButton, EventArgs.Empty);

            //_uut.StartCooking(50, 50);
            _timer.Received().Start(60*1000);
        }

        [Test]
        public void CookingStop_TimerStopped_TimerReceivedStop()
        {
            // FROM UI THROUGH CC: 50 W, 1 minute, start
            _userInterface.OnPowerPressed(_pButton, EventArgs.Empty);
            _userInterface.OnTimePressed(_tButton, EventArgs.Empty);
            _userInterface.OnStartCancelPressed(_scButton, EventArgs.Empty);
            _userInterface.OnDoorOpened(_door, EventArgs.Empty);
            //_uut.StartCooking(50, 50);
            //_uut.Stop();

            _timer.Received().Stop();
        }

        // IDK ABOUT THIS ONE, CHECK TOMORROW
        [Test]
        public void OnTimerExpired_CookingIsDone_UIReceivedDone()
        {
            _uut.StartCooking(50, 30);

            _timer.Expired += Raise.EventWith(_timer, EventArgs.Empty);

            _userInterface.Received().CookingIsDone();
        }

    }
}
