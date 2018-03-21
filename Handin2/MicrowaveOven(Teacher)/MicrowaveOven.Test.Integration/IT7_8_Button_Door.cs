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
        private IUserInterface _userInterface;

        [SetUp]
        public void Setup()
        {
            _door = new Door();
            _pButton = new Button();
            _tButton = new Button();
            _scButton = new Button();
            _userInterface = Substitute.For<IUserInterface>();
        }

        [Test]
        public void OpenDoor_UserInterfaceReveivedOnDoorOpened()
        {
            _door.Open
            //_userInterface.OnDoorOpened(_door,EventArgs.Empty);
            _userInterface.Received().OnDoorOpened(_door, EventArgs.Empty);
        }

        [Test]
        public void CloseDoor_UserInterfaceReveivedOnDoorClosed()
        {
            _door.Close();
            _userInterface.Received().OnDoorClosed(_door, EventArgs.Empty);
        }

        [Test]
        public void PressPowerButton_UserInterfaceReveivedOnPowerPressed()
        {
            _pButton.Press();
            _userInterface.Received().OnPowerPressed(_pButton, EventArgs.Empty);
        }
    }
}
