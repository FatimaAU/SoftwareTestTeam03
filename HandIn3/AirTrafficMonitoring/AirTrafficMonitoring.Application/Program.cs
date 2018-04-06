using AirTrafficMonitoring.Classes;
using TransponderReceiver;

namespace AirTrafficMonitoring.Application
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransponderReceiver receiver = TransponderReceiverFactory.CreateTransponderDataReceiver();
            receiver.TransponderDataReady += receiver_TransponderDataReady;

            while (true) { }
        }

        private static void receiver_TransponderDataReady(object sender, RawTransponderDataEventArgs e)
        {
            //Traverse all elements
            foreach (var data in e.TransponderData)
            {
                // Return list of parsed flight info
                var parsedFlightList = ParseFlightInfo.Parse(data);

                // If inside the monitored area
                if (FlightTrackingValidation.MonitoredFlightData(parsedFlightList))
                {
                    // Format and return the date
                    var date = Date.FormatDate(parsedFlightList);

                    // Create track object and print info
                    Track myTrack = new Track(date);
                    myTrack.Print();
                }
            }
        } 
    }
}
