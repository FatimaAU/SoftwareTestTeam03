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
    class IT2_PowerTube
    {
        private IDisplay _display;
        private IOutput _output;
        private ITimer _timer;
        private IPowerTube _uut;
        private ICookController _cookController;
        private IUserInterface _userInterface;


        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _timer = Substitute.For<ITimer>();
            _display = Substitute.For<IDisplay>();
            _uut = new PowerTube(_output);
            _userInterface = Substitute.For<IUserInterface>();
            _cookController = new CookController(_timer, _display, _uut, _userInterface);
        }

        [Test]
        public void TurnOn_WasNotOff_CorrectOutput()
        {
            // Power is called with TurnOn(200/7)
            // Checks output
            _cookController.StartCooking(200, 40);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains((200/7).ToString())));
        }

        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            // Turn on
            _cookController.StartCooking(400, 50);
            // Turn off 
            _timer.TimeRemaining.Returns(0);
            _timer.Expired += Raise.EventWith(_timer, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }
    }
}
