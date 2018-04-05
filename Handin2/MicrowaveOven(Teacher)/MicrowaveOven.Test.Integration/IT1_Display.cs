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
    public class IT1_Display
    {
        private IDisplay _uut;
        private IOutput _output;
        private ITimer _timer;
        private IPowerTube _powerTube;
        private ICookController _cookController;
        private IUserInterface _userInterface;


        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _timer = Substitute.For<ITimer>();
            _uut = new Display(_output);
            _powerTube = Substitute.For<IPowerTube>();
            _userInterface = Substitute.For<IUserInterface>();
            _cookController = new CookController(_timer, _uut, _powerTube, _userInterface);
        }

       
        [Test]
        public void ShowTime_SomeMinuteSomeSecond_CorrectOutput()
        {
            // Calls OnTimerTick on CC which calls ShowTime()
            _timer.TimeRemaining.Returns(50000);
            _timer.TimerTick += Raise.EventWith(_timer, EventArgs.Empty);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("00:50")));
        }

        //[Test]
        //public void ShowPower_Zero_CorrectOutput()
        //{
        //    // Calls OnTimerTick on CC which calls ShowTime()
        //    _timer.TimeRemaining.Returns(0);
        //    _timer.Expired += Raise.EventWith(_timer, EventArgs.Empty);
        //    _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("30 W")));
        //}

        //[Test]
        //public void Clear_CorrectOutput()
        //{
        //    _uut.Clear();
        //    _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("cleared")));
        //}
    }
}
