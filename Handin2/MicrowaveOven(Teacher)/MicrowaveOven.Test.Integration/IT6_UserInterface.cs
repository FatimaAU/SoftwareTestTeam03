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
        private UserInterface _uut;
        private ICookController _cookController;
        private IButton _pButton, _tButton, _scButton;

        private IDisplay _display;
        private ILight _light;
        private IDoor _door;

        [SetUp]
        public void Setup()
        {
            _door = Substitute.For<IDoor>();
            _light = Substitute.For<ILight>();
            _display = Substitute.For<IDisplay>();
            _pButton = Substitute.For<IButton>();
            _tButton = Substitute.For<IButton>();
            _scButton = Substitute.For<IButton>();
            _cookController = Substitute.For<ICookController>();
            _uut = new UserInterface(_pButton, _tButton, _scButton, _door, _display, _light, _cookController);
        }

        [Test]
        public void OnDoorOpened_TurnOnLight_LightReceivedTurnOn()
        {
            _uut.OnDoorOpened(_door, EventArgs.Empty);
            _light.Received().TurnOn();
        }

        [Test]
        public void OnDoorClosed_TurnOffLight_LightReceivedTurnOff()
        {
            _uut.OnDoorClosed(_door, EventArgs.Empty);
            _light.Received().TurnOff();
        }

        //[Test]
        //public void OnStartCancelPressed_StartCooking_CookingCtrlReceivedCorrect()
        //{
        //    _scButton.Pressed += Raise.EventWith(_scButton, EventArgs.Empty);

        //    _uut.OnStartCancelPressed(_scButton, EventArgs.Empty);

        //    _cookController.Received().StartCooking(50,6000);
        //}
    }
}
