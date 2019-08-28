using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    public class Calculator
    {
        List<FlightInfo> flights;
        public Calculator(List<FlightInfo> flightInfos)
        {
            flights = flightInfos.ToList();
        }

        public double CalculateAvgDelay(bool arrival = true)
        {
            int sum = 0;
            int missing = 0;
            foreach(FlightInfo flight in flights)
            {
                int delay = arrival ? flight.ArrDelay : flight.DepDelay;
                if (delay < 0)
                    missing++;
                else
                    sum += delay;
            }
            double avg = Math.Round((double)(sum) / (flights.Count - missing), 2);
            return (avg);
        }

        public KeyValuePair<string, int> HotDest()
        {
            KeyValuePair<string, int> dest;
            Dictionary<string, int> DestFlights = new Dictionary<string, int>();
            foreach(FlightInfo flight in flights)
            {
                string fullCity = flight.DestCity + ", " + flight.DestState;
                if (DestFlights.ContainsKey(fullCity))
                    DestFlights[fullCity] += 1;
                else
                    DestFlights.Add(fullCity, 1);
            }
            dest = DestFlights.Aggregate((x, y) => x.Value > y.Value ? x : y);
            return dest;
        }
       
        public string FiveFarthestDest()
        {
            string DestinationString = "";
            int maxDist = 0;
            FlightInfo currFarthest = new FlightInfo();
            
            for(int i = 0; i< 5; i++)
            {                
                foreach(FlightInfo flight in flights)
                {
                    if(flight.Distance > currFarthest.Distance)
                    {
                        maxDist = flight.Distance;
                        currFarthest = flight;
                    }                    
                }                
                flights.RemoveAll(x => (x.DestCity == currFarthest.DestCity) && (x.DestState == currFarthest.DestState));
                DestinationString += String.Format("\r\n{0}. {1}, {2} - {3} km", i+1, currFarthest.DestCity, currFarthest.DestState, currFarthest.Distance);
                currFarthest = new FlightInfo();
                
            }

            return DestinationString;
        }

        

        public object[] CalculateQuery(QueryEnum query)
        {
            object[] results = new object[1]; ;
            if (query == QueryEnum.AVG_DEP_DEL)
            {
                results = new object[3];
                results[0] = CalculateAvgDelay();
                results[1] = CalculateAvgDelay(false);
                results[2] = flights.Count();
            }
            if(query == QueryEnum.MOST_fLIGHTS)
            {
                results = new object[2];
                KeyValuePair<string, int> valuePair = HotDest();
                results[0] = valuePair.Key;
                results[1] = valuePair.Value;
            }
            if(query == QueryEnum.FARTHEST_DESTINATIONS)
            {
                results = new object[1];
                results[0] = FiveFarthestDest();
            }

            return results;
        }
    }

    
}
