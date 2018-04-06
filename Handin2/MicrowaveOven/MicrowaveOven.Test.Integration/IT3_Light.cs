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
    class IT3_Light
    {
        private ILight _uut;
        private IOutput _output;
        private ICookController _cookController;
        private IUserInterface _userInterface;
        private IButton _tButton;
        private IButton _pButton;
        private IButton _scButton;
        private IDoor _door;
        private IDisplay _display;


        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Light(_output);
            _tButton = Substitute.For<IButton>();
            _pButton = Substitute.For<IButton>();
            _scButton = Substitute.For<IButton>();
            _door = Substitute.For<IDoor>();
            _display = Substitute.For<IDisplay>();
            _cookController = Substitute.For<ICookController>();
            _userInterface = new UserInterface(_pButton, _tButton, _scButton, _door, _display, _uut, _cookController);
        }

        [Test]
        public void TurnOn_WasNotff_CorrectOutput()
        {
            // Calls TurnOn() on Light
            _userInterface.OnDoorOpened(_door, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("on")));
        }

        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            // Calls TurnOn() on Light
            _userInterface.OnDoorOpened(_door, EventArgs.Empty);
            // Calls TurnOff() on Light
            _userInterface.OnDoorClosed(_door, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

    }

   
}
