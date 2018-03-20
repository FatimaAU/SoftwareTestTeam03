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
    class IT5_CookController
    {
        private CookController _uut;
        private Timer _timer;
        private IDisplay _display;
        private PowerTube _powerTube;
        private IOutput _output;
        private IUserInterface _userInterface;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _display = Substitute.For<IDisplay>();
            _timer = new Timer();
            _userInterface = Substitute.For<IUserInterface>();
            _powerTube = new PowerTube(_output);
            _uut = new CookController(_timer, _display, _powerTube, _userInterface);
        }

        //[Test]
        //public void PowerPressed_ShowTime_DisplayCorrectOutput()
        //{
        //    _uut.OnTimerTick();
        //    _output.Received(1).OutputLine(Arg.Is<string>(str => str.Contains("on")));
        //}

        [Test]
        public void PowerPressed_ShowTime_DisplayCorrectOutput()
        {
            _uut.StartCooking(20, 20);//   _timer.Start(20);
            //_timer.TimeRemaining.Returns(19);
            _timer.TimerTick += Raise.EventWith(this, EventArgs.Empty);
            //_uut.OnTimerTick(_timer, System.EventArgs.Empty);
            //_uut.OnTimerTick(_timer, System.EventArgs.Empty);

            _display.Received().ShowTime(0, 20);
        }

    }
}
