using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MicrowaveOvenClasses.Boundary;
using MicrowaveOvenClasses.Interfaces;
using NSubstitute;
using NUnit.Framework;

namespace MicrowaveOven.Test.Integration
{
    [TestFixture]
    class IT3_Light
    {
        private Light _uut;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Light(_output);
        }

        [Test]
        public void TurnOn_WasOff_CorrectOutput()
        {
            _uut.TurnOn();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("on")));
        }

        [Test]
        public void TurnOff_WasOn_CorrectOutput()
        {
            _uut.TurnOn();
            _uut.TurnOff();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("off")));
        }

    }

   
}
