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
    [TestFixture]
    class IT7_8_Button_Door
    {
        private IButton _pButton, _tButton, _scButton;
        private IDoor _door;
        private IUserInterface _userInterface;
        private ILight _light;
        private IDisplay _display;
        private CookController _cookController;
        private ITimer _timer;
        private IPowerTube _powerTube;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _timer = new Timer();
            _powerTube = new PowerTube(_output);
            _door = new Door();
            _pButton = new Button();
            _tButton = new Button();
            _scButton = new Button();
            _cookController = new CookController(_timer, _display, _powerTube);
            _display = new Display(_output);
            _light = new Light(_output);
            _userInterface = new UserInterface(_pButton, _tButton, _scButton, _door, _display, _light, _cookController);
            _cookController.UI = _userInterface;

        }

        // Door
        [Test]
        public void OpenDoor_DoorOpened_LightReceivedTurnOn()
        {
            _door.Open();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("Light is turned on")));
        }

        [Test]
        public void CloseDoor_DoorClosed_LightReceivedTurnOff()
        {
            _door.Open();
            _door.Close();

            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("Light is turned off")));
        }

        // PowerButton
        [Test]
        public void PressPowerButton_ShowPower_DisplayPowerCorrect()
        {
            _pButton.Press();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("50 W")));
        }

        // TimeButton
        [Test]
        public void PressTimeButton_ShowTime_DisplayTimeCorrect()
        {
            _pButton.Press();
            _tButton.Press();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("01:00")));
        }
        [Test]
        public void PressTimeButtonTwice_ShowTime_DisplayTimeCorrect()
        {
            _pButton.Press();
            _tButton.Press();
            _tButton.Press();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("02:00")));
        }

        // StartCancelButton
        [Test]
        public void PressStartCancelButton_LightReceivedTurnOn()
        {
            _pButton.Press();
            _tButton.Press();
            _scButton.Press();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("Light is turned on")));
        }
    }
}
