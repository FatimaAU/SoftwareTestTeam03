using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Controllers;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NSubstitute.Routing.Handlers;
using NUnit.Framework;
using NUnit.Framework.Internal.Execution;
using Timer = MicrowaveOvenClasses.Boundary.Timer;

namespace MicrowaveOven.Test.Integration
{
    class IT4_Timer
    {
        private ITimer _uut;
        private CookController _cookController;
        private IDisplay _display;
        private IPowerTube _powerTube;
        private event EventHandler TimerTick;

        [SetUp]
        public void Setup()
        {
            _display = Substitute.For<IDisplay>();
            _powerTube = Substitute.For<IPowerTube>();
            _uut = new Timer();

            _cookController = Substitute.For<CookController>(_uut, _display, _powerTube);
        }

        [Test]
        public void StartCook_StartTimer_Correct()
        {

            _uut.Start(5000);

            //_uut.TimeRemaining.Returns(200);
            //_uut.TimerTick += Raise.EventWith(this, EventArgs.Empty);

            ManualResetEvent pause = new ManualResetEvent(false);
            int notifications = 0;

            _uut.TimerTick += (sender, args) => notifications++;

            pause.WaitOne(2000);

            //_cookController.Received().OnTimerTick(_uut, EventArgs.Empty);
            //_cookController.OnTimerTick(_uut, EventArgs.Empty);

            _display.Received().ShowTime(3, 20);

            //ManualResetEvent pause = new ManualResetEvent(false);
            //int notifications = 0;

            //uut.Expired += (sender, args) => pause.Set();
            //uut.TimerTick += (sender, args) => notifications++;

            //uut.Start(2000);

            //// wait longer than expiration
            //Assert.That(pause.WaitOne(2100));
            //uut.Stop();

            //Assert.That(notifications, Is.EqualTo(2));

        }

        [Test]
        public void StopCook_StartTimer_Correct()
        {
            ManualResetEvent pause = new ManualResetEvent(false);

            _uut.Start(3000);

            //_uut.Expired += (sender, args) => pause.Set();

            //_uut.Stop();

            _cookController.Received().OnTimerExpired(_uut, EventArgs.Empty);
            //_uut.TimeRemaining.Returns(0);
            //_uut.Expired += Raise.EventWith(this, EventArgs.Empty);

            //_powerTube.Received().TurnOff();
        }
    }
}
