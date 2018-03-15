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
        private Display uut;
        private IOutput output;

        [SetUp]
        public void Setup()
        {
            output = Substitute.For<IOutput>();
            uut = new Display(output);
        }

        [Test]
        public void ShowTime_ZeroMinuteZeroSeconds_CorrectOutput()
        {
            uut.ShowTime(0, 0);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("00:00")));
        }

        [Test]
        public void ShowTime_SomeMinuteSomeSecond_CorrectOutput()
        {
            uut.ShowTime(10, 15);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("10:15")));
        }

        [Test]
        public void ShowPower_Zero_CorrectOutput()
        {
            uut.ShowPower(0);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("0 W")));
        }

        [Test]
        public void ShowPower_NotZero_CorrectOutput()
        {
            uut.ShowPower(150);
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("150 W")));
        }

        [Test]
        public void Clear_CorrectOutput()
        {
            uut.Clear();
            output.Received().OutputLine(Arg.Is<string>(str => str.Contains("cleared")));
        }
    }
}
