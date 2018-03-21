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
        private Button _pButton, _tButton, _scButton;
        private Door _door;
        private UserInterface _userInterface;
        private ILight _light;
        private IDisplay _display;
        private ICookController _cookController;

        [SetUp]
        public void Setup()
        {
            _door = new Door();
            _pButton = new Button();
            _tButton = new Button();
            _scButton = new Button();
            _cookController = Substitute.For<ICookController>();
            _display = Substitute.For<IDisplay>();
            _light = Substitute.For<ILight>();
            //_userInterface = Substitute.For<IUserInterface>();
            _userInterface = new UserInterface(_pButton, _tButton, _scButton, _door, _display, _light, _cookController);
            
        }

        [Test]
        public void OpenDoor_UserInterfaceReceivedOnDoorOpened()
        {
            _door.Open();
            _light.Received().TurnOn();
        }

        [Test]
        public void CloseDoor_UserInterfaceReceivedOnDoorClosed()
        {
            _door.Open();
            _door.Close();
            _light.Received().TurnOff();
        }

        [Test]
        public void PressPowerButton_UserInterfaceReceivedOnPowerPressed()
        {
            _pButton.Press();
            _display.Received().ShowPower(50);
        }

        [Test]
        public void PressTimeButton_UserInterfaceReceivedOnTimePressed()
        {
            _pButton.Press();
            _tButton.Press();
            _display.Received().ShowTime(1,0);
        }

        [Test]
        public void PressStartCancelButton_UserInterfaceReceivedOnTimePressed()
        {
            _pButton.Press();
            _tButton.Press();
            _scButton.Press();
            _light.Received().TurnOn();
        }
    }
}
