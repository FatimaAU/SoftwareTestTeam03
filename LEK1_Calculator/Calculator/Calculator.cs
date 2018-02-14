using System;

namespace Calculator
{
    public class Calculator
    {
        public double Accumulator { get; private set; } = 0;

        public double Add(double a, double b)
        {
            Accumulator = a + b;
            return Accumulator;
        }

        public double Subtract(double a, double b)
        {
            Accumulator = a - b;
            return Accumulator;
        }

        public double Multiply(double a, double b)
        {
            Accumulator = a * b;
            return Accumulator;
        }

        public double Power(double a, double b)
        {
            Accumulator = Math.Pow(a, b);
            return Accumulator;
        }

        public double Divide(double dividend, double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                Accumulator = dividend / divisor;
                return Accumulator;
            }
        }

        public void Clear()
        {
            Accumulator = 0;
        }

        public double Add(double addend) 
        {
            Accumulator = addend + Accumulator;
            return Accumulator;
        }

        public double Subtract(double subtractor) 
        {
            Accumulator = Accumulator - subtractor;
            return Accumulator;
        }

        public double Multiply(double multiplier) 
        {
            Accumulator = Accumulator * multiplier;
            return Accumulator;
        }

        public double Divide(double divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException();
            }
            else
            {
                Accumulator = Accumulator / divisor;
                return Accumulator;
            }
        }

        public double Power(double exponent)
        {
            Accumulator = Math.Pow(Accumulator, exponent);
            return Accumulator;
        }

    }
}
