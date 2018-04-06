using NSubstitute;
using NUnit.Framework;

namespace TestingEventsWithIsoFW.Test.Unit
{
    [TestFixture]
    public class SummatorUnitTest
    {
        private Summator _uut;
        private INumberSource _numberSource;
        private int _sum;
        private int _nEventsReceived;

        [SetUp]
        public void SetUp()
        {
            _sum = 0;
            _nEventsReceived = 0;
            _numberSource = Substitute.For<INumberSource>();
            _uut = new Summator(_numberSource);

            _uut.SumChanged += (o, args) => 
            {
                _sum = args.Sum;
                ++_nEventsReceived;
            };
        }

        [Test]
        public void Initial_NumberChangedOnce_SumIsCorrect()
        {
            var args = new NumberChangedEventArgs() {Number = 4};

            _numberSource.NumberChanged += Raise.EventWith(args);

            Assert.That(_sum, Is.EqualTo(4));
        }

        [Test]
        public void Initial_NumberChangedTwice_SumIsCorrect()
        {
            var args = new NumberChangedEventArgs() { Number = 4 };

            _numberSource.NumberChanged += Raise.EventWith(args);
            args.Number = 3;
            _numberSource.NumberChanged += Raise.EventWith(args);

            Assert.That(_sum, Is.EqualTo(7));
        }

        [Test]
        public void Initial_NumberChangedTwice_NumberOfEventsReceivedIsCorrect()
        {
            var args = new NumberChangedEventArgs() { Number = 4 };

            _numberSource.NumberChanged += Raise.EventWith(args);
            args.Number = 3;
            _numberSource.NumberChanged += Raise.EventWith(args);

            Assert.That(_nEventsReceived, Is.EqualTo(2));
        }

        [Test]
        public void Initial_NumberChangedTwiceSecondTimeIsZero_SumIsCorrect()
        {
            var args = new NumberChangedEventArgs() { Number = 4 };

            _numberSource.NumberChanged += Raise.EventWith(args);
            args.Number = 0;
            _numberSource.NumberChanged += Raise.EventWith(args);

            Assert.That(_sum, Is.EqualTo(4));
        }

        [Test]
        public void Initial_NumberChangedTwiceSecondTimeIsZero_NumberOfEventsReceivedIsCorrect0()
        {
            var args = new NumberChangedEventArgs() { Number = 4 };

            _numberSource.NumberChanged += Raise.EventWith(args);
            args.Number = 0;
            _numberSource.NumberChanged += Raise.EventWith(args);

            Assert.That(_nEventsReceived, Is.EqualTo(1));
        }

    }
}
