using System;

namespace TestingEventsWithIsoFW
{
    public class NumberChangedEventArgs : EventArgs
    {
        public int Number { get; set; }
    }

    public interface INumberSource
    {
        event EventHandler<NumberChangedEventArgs> NumberChanged;
    }
}