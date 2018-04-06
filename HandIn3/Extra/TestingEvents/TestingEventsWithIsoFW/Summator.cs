using System;

namespace TestingEventsWithIsoFW
{

    // Event arguments for the "outgoing" event
    public class SumChangedEventArgs : EventArgs
    {
        public int Sum { get; set; }
    }



    // Summator subscribes to "incloming" events from a source 
    // and raises an "outgoing" event as a consequence hereof
    public class Summator
    {
        private int _sum;
        
        // The event that Summator will raise when the sum changes (i.e., the "outgoing" event)
        public event EventHandler<SumChangedEventArgs> SumChanged;

        // Constructor. Attaches UpdateSum() to the number source's event (the "incoming" event)
        public Summator(INumberSource numberSource)
        {
            numberSource.NumberChanged += UpdateSum;
        }

        // This is the event handler which gets called when the source raises its "incoming event"
        // This event handler raises the "outgoing" OnSumChanged-event.
        private void UpdateSum(object o, NumberChangedEventArgs args)
        {
            if (args.Number != 0)
            {
                _sum += args.Number;
                OnSumChanged(new SumChangedEventArgs {Sum = _sum});
            }
        }

        // This is a helper method which actually raises the "outgoing" event
        private void OnSumChanged(SumChangedEventArgs sum)
        {
            var handler = SumChanged;
            handler?.Invoke(this, sum);
        }
    }

}
