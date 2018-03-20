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
    class IT4_CookController
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
        public void PowerPressed_ShowTime_DisplayCorrectOutput()
        {
            ManualResetEvent pause = new ManualResetEvent(false);


            _uut.StartCooking(50, 5000);

            pause.WaitOne(2000);

            _uut.OnTimerTick(_timer, EventArgs.Empty);

            _display.Received().ShowTime(0,3);
          
        }

        //[Test]
        //public void PowerPressed_ShowTime_DisplayCorrectOutput()
        //{
        //    _uut.StartCooking(20, 20);//   _timer.Start(20);
        //    //_timer.TimeRemaining.Returns(19);
        //    _timer.TimerTick += Raise.EventWith(this, EventArgs.Empty);
        //    //_uut.OnTimerTick(_timer, System.EventArgs.Empty);
        //    //_uut.OnTimerTick(_timer, System.EventArgs.Empty);

        //    _display.Received().ShowTime(0, 20);
        //}

    }
}
