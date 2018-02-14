using System;
using Calculator;
using NUnit.Framework;


namespace Calculator.Test.Unit
{
    [TestFixture]
    [Author("Troels Jensen")]
    public class CalculatorUnitTests
    {
        private Calculator _uut;

        [SetUp]
        public void Setup()
        {
            _uut = new Calculator();
        }

        [TestCase(3, 2, 5)]
        [TestCase(-3, -2, -5)]
        [TestCase(-3, 2, -1)]
        [TestCase(3, -2, 1)]
        public void Add_AddPosAndNegNumbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Add(a, b), Is.EqualTo(result));
        }


        [TestCase(3, 2, 1)]
        [TestCase(-3, -2, -1)]
        [TestCase(-3, 2, -5)]
        [TestCase(3, -2, 5)]
        public void Subtract_SubtractPosAndNegNumbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Subtract(a, b), Is.EqualTo(result));
        }


        [TestCase(3, 2, 6)]
        [TestCase(-3, -2, 6)]
        [TestCase(-3, 2, -6)]
        [TestCase(3, -2, -6)]
        [TestCase(0, -2, 0)]
        [TestCase(-2, 0, 0)]
        [TestCase(0, 0, 0)]
        public void Multiply_MultiplyNunmbers_ResultIsCorrect(int a, int b, int result)
        {
            Assert.That(_uut.Multiply(a, b), Is.EqualTo(result));
        }


        [TestCase(2, 3, 8)]
        [TestCase(2, -3, 0.125)]
        [TestCase(-2, -3, -0.125)]
        [TestCase(1, 10, 1)]
        [TestCase(1, -10, 1)]
        [TestCase(10, 0, 1)]
        [TestCase(4, 0.5, 2.0)]
		[TestCase(9, 0.5, 3.0)]
        public void Power_RaiseNumbers_ResultIsCorrect(double x, double exp, double result)
        {
            Assert.That(_uut.Power(x, exp), Is.EqualTo(result));
        }

        [TestCase(1, 2, 3)]
        [TestCase(2, 4, 6)]
        public void Accumulator_AddNumbers_ResultIsCorrect(double first, double second, double result)
        {
            _uut.Add(first, second);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(1, 2, -1)]
        [TestCase(2, 4, -2)]
        public void Accumulator_SubtractNumbers_ResultIsCorrect(double first, double second, double result)
        {
            _uut.Subtract(first, second);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(1, 2, 1)]
        [TestCase(2, 2, 4)]
        public void Accumulator_PowerNumbers_ResultIsCorrect(double first, double second, double result)
        {
            _uut.Power(first, second);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(2, 2, 4)]
        [TestCase(3, 3, 9)]
        public void Accumulator_MultiplyNumbers_ResultIsCorrect(double first, double second, double result)
        {
            _uut.Multiply(first, second);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(6, 2, 3)]
        [TestCase(3, 1, 3)]
        public void Divide_DivideNumbers_ResultIsCorrect(double first, double second, double result)
        {
            Assert.That(_uut.Divide(first, second), Is.EqualTo(result));
        }

        [TestCase(5,0)]
        public void Divide_DivideBy0_ThowsException(double first, double second)
        {
            Assert.Throws<DivideByZeroException>(() => _uut.Divide(first, second));
        }


        [TestCase]
        public void Accumulator_ClearAccumulator_ResultIsCorrect()
        {
            _uut.Add(2, 3);
            _uut.Clear();
            Assert.That(_uut.Accumulator, Is.EqualTo(0));
        }

        [TestCase(2, 2)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        [TestCase(10, 10)]
        public void Add_AddNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            Assert.That(_uut.Add(first), Is.EqualTo(result));
        }

        [TestCase(1, -1)]
        [TestCase(3, -3)]
        [TestCase(6, -6)]
        [TestCase(5, -5)]
        [TestCase(10, -10)]
        public void Subtract_SubtractNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            Assert.That(_uut.Subtract(first), Is.EqualTo(result));
        }

        [TestCase(6, 0)]
        [TestCase(5, 0)]
        [TestCase(10, 0)]
        public void Multiply_MultiplyNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            Assert.That(_uut.Multiply(first), Is.EqualTo(result));
        }

        [TestCase(2, 7)]
        [TestCase(3, 8)]
        public void Accumulator_AddNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            _uut.Add(2, 3);
            _uut.Add(first);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(2, 3)]
        [TestCase(6, -1)]
        [TestCase(3, 2)]
        public void Accumulator_SubtractNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            _uut.Add(2, 3);
            _uut.Subtract(first);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(2, 4)]
        [TestCase(1, 2)]
        [TestCase(3, 6)]
        public void Accumulator_MultiplyNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            _uut.Add(2, 0);
            _uut.Multiply(first);
            Assert.That(_uut.Accumulator, Is.EqualTo(result));
        }

        [TestCase(2, 1)]
        [TestCase(10, 0.2)]
        [TestCase(0.2, 10)]
        public void Accumulator_DivideNumbersWithOverload_ResultIsCorrect(double first, double result)
        {
            _uut.Add(1, 1);
            Assert.That(_uut.Divide(first), Is.EqualTo(result));
        }

        [TestCase(1, 2)]
        [TestCase(2, 4)]
        [TestCase(3, 8)]
        public void Accumulator_PowerNumberWithOverload_ResultIsCorrect(double first, double result)
        {
            _uut.Add(1, 1);
            Assert.That(_uut.Power(first), Is.EqualTo(result));
        }

        [Test]
        public void Divide_DivideBy0WithOverload_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => _uut.Divide(1, 0));
        }
    }
}
