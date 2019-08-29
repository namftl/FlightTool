using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    /// <summary>
    /// this class performs the querry calculation and returns the results, holds flight list as member 
    /// </summary>
    public class Calculator
    {
        List<FlightInfo> Flights;
        object[] Input;
        /// <summary>
        /// inits calculator with relevant flight list
        /// </summary>
        /// <param name="flightInfos"></param>
        public Calculator(List<FlightInfo> flightInfos)
        {
            Flights = flightInfos.ToList();
        }

        /// <summary>
        /// calculates desired querry based on given flight list
        /// </summary>
        /// <param name="querry"></param>
        /// <returns>returns an object array with all results relevant to querry</returns>
        public object[] CalculateQuery(QuerryEnum querry, object[] input = null)
        {
            object[] results = new object[1];
            Input = input;
            if (querry == QuerryEnum.AVG_DEP_DEL)
            {
                results = new object[3];
                results[0] = CalculateAvgDelay();
                results[1] = CalculateAvgDelay(false);
                results[2] = Flights.Count();
            }
            if (querry == QuerryEnum.MOST_fLIGHTS)
            {
                results = new object[2];
                KeyValuePair<string, int> valuePair = HotDest();
                results[0] = valuePair.Key;
                results[1] = valuePair.Value;
            }
            if (querry == QuerryEnum.FARTHEST_DESTINATIONS)
            {
                results = new object[1];
                results[0] = FiveFarthestDest();
            }
            if(querry == QuerryEnum.SHORTEST_PATH)
            {
                KeyValuePair<string, double> trip = MinDelayTrip();
                results = new object[2];
                results[0] = trip.Key;
                results[1] = trip.Value;
            }

            return results;
        }

        private KeyValuePair<string, double> MinDelayTrip()
        {
            KeyValuePair<string, double> trip = new KeyValuePair<string, double>("aaa", 2 );
            List<FlightInfo> firstFlight = new List<FlightInfo>();
            string[] cityAndStateSrc = ((string)Input[0]).Split(',');
            cityAndStateSrc[1] = cityAndStateSrc[1].Trim();
            List<FlightInfo> secondFlight = new List<FlightInfo>();
            string[] cityAndStateDest = ((string)Input[0]).Split(',');
            cityAndStateDest[1] = cityAndStateDest[1].Trim();
            foreach (FlightInfo flight in Flights)
            {
                if ((String.Compare(flight.OriginCity, cityAndStateSrc[0]) != 0) || (String.Compare(flight.OriginState, cityAndStateSrc[1])) != 0)
                    firstFlight.Add(flight);
                if ((String.Compare(flight.DestCity, cityAndStateDest[0]) != 0) || (String.Compare(flight.OriginState, cityAndStateDest[1])) != 0)
                    secondFlight.Add(flight);
            }
            
            return trip;
        }

        /// <summary>
        /// calculates avg delay - arrival or departure according to input
        /// </summary>
        /// <param name="arrival"></param>
        /// <returns></returns>
        private double CalculateAvgDelay(bool arrival = true)
        {
            int sum = 0;
            int missing = 0;
            foreach(FlightInfo flight in Flights)
            {
                int delay = arrival ? flight.ArrDelay : flight.DepDelay;
                if (delay < 0)
                    missing++;
                else
                    sum += delay;
            }
            double avg = Math.Round((double)(sum) / (Flights.Count - missing), 2);
            return (avg);
        }

        /// <summary>
        /// returns the most frequent destination from the current flight list in [destination, flights] format
        /// </summary>
        /// <returns></returns>
        private KeyValuePair<string, int> HotDest()
        {
            KeyValuePair<string, int> dest;
            Dictionary<string, int> DestFlights = new Dictionary<string, int>();
            foreach(FlightInfo flight in Flights)
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
       
        /// <summary>
        /// returns the five farthest destinations int string format
        /// </summary>
        /// <returns></returns>
        private string FiveFarthestDest()
        {
            string DestinationString = "";
            int maxDist = 0;
            FlightInfo currFarthest = new FlightInfo();
            
            for(int i = 0; i< 5; i++)
            {                
                foreach(FlightInfo flight in Flights)
                {
                    if(flight.Distance > currFarthest.Distance)
                    {
                        maxDist = flight.Distance;
                        currFarthest = flight;
                    }                    
                }                
                Flights.RemoveAll(x => (x.DestCity == currFarthest.DestCity) && (x.DestState == currFarthest.DestState));
                DestinationString += String.Format("\r\n{0}. {1}, {2} - {3} km", i+1, currFarthest.DestCity, currFarthest.DestState, currFarthest.Distance);
                currFarthest = new FlightInfo();
                
            }

            return DestinationString;
        }                
    }    
}
