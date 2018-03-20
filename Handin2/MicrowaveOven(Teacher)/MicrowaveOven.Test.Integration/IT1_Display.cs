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
    public class IT1_Display
    {
        private Display _uut;
        private IOutput _output;

        [SetUp]
        public void Setup()
        {
            _output = Substitute.For<IOutput>();
            _uut = new Display(_output);
        }

       
        [Test]
        public void ShowTime_SomeMinuteSomeSecond_CorrectOutput()
        {
            _uut.ShowTime(11, 15);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("11:15")));
        }

        [Test]
        public void ShowPower_Zero_CorrectOutput()
        {
            _uut.ShowPower(30);
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("30 W")));
        }

        [Test]
        public void Clear_CorrectOutput()
        {
            _uut.Clear();
            _output.Received().OutputLine(Arg.Is<string>(str => str.Contains("cleared")));
        }
    }
}
