using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace MicrowaveOven.Test.Integration
{
    class IT6_UserInterface
    {
        private IUserInterface _uut;
        private CookController _cookController;
        private IButton _pButton, _tButton, _scButton;
        private ITimer _timer;
        private IDisplay _display;
        private ILight _light;
        private IDoor _door;
        private IPowerTube _powerTube;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _powerTube = new PowerTube(_output);
            _door = Substitute.For<IDoor>();
            _timer = Substitute.For<ITimer>();
            _light = new Light(_output);
            _display = new Display(_output);
            _pButton = Substitute.For<IButton>();
            _tButton = Substitute.For<IButton>();
            _scButton = Substitute.For<IButton>();
            _cookController = new CookController(_timer, _display, _powerTube);
            _uut = new UserInterface(_pButton, _tButton, _scButton, _door, _display, _light, _cookController);
            _cookController.UI = _uut;
        }

        // Light
        [Test]
        public void OnDoorOpened_TurnOnLight_LightReceivedTurnOn()
        {
            _door.Opened += Raise.EventWith(_door, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("on")));

        }

        [Test]
        public void OnDoorClosed_TurnOffLight_LightReceivedTurnOff()
        {
            _door.Opened += Raise.EventWith(_door, EventArgs.Empty);
            _door.Closed += Raise.EventWith(_door, EventArgs.Empty);

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

        // Display
        [Test]
        public void OnPowerPressed_ShowPower_DisplayReceivedPowerCorrect()
        {
            _pButton.Pressed += Raise.EventWith(_pButton, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("50 W")));
        }

        [Test]
        public void OnTimePressed_ShowTime_DisplayReceivedTimeCorrect()
        {
            _pButton.Pressed += Raise.EventWith(_pButton, EventArgs.Empty);
            _tButton.Pressed += Raise.EventWith(_tButton, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("01:00")));
        }

        [Test]
        public void OnTimePressedTwice_ShowTime_DisplayReceivedTimeCorrect()
        {
            _pButton.Pressed += Raise.EventWith(_pButton, EventArgs.Empty);
            _tButton.Pressed += Raise.EventWith(_tButton, EventArgs.Empty);
            _tButton.Pressed += Raise.EventWith(_tButton, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("02:00")));
        }

        [Test]
        public void OnStartCancelPressed_Clear_DisplayReceivedClear()
        {
            _pButton.Pressed += Raise.EventWith(_pButton, EventArgs.Empty);
            _tButton.Pressed += Raise.EventWith(_tButton, EventArgs.Empty);
            _scButton.Pressed += Raise.EventWith(_scButton, EventArgs.Empty);

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("clear")));
        }

      

        [Test]
        public void OnDoorOpened_Stop_PowerTubeOff()
        {
            _pButton.Pressed += Raise.EventWith(_pButton, EventArgs.Empty);
            _tButton.Pressed += Raise.EventWith(_tButton, EventArgs.Empty);
            _scButton.Pressed += Raise.EventWith(_scButton, EventArgs.Empty);
            _scButton.Pressed += Raise.EventWith(_scButton, EventArgs.Empty);

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("PowerTube turned off")));
           
        }
    }
}
