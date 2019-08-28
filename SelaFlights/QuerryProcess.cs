using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    class QuerryProcess
    {
        QueryEnum queryEnum;
        string[] UserInput;
        DataGetter dataGetter;
        Calculator calculator;
        PrintEdit printEditor;
        CsvReader FileReader;
        List<FlightInfo> flights;
        string resultString;        
        object[] results;

        public QuerryProcess(string sourceFile)
        {
            FileReader = new CsvReader(sourceFile);
            flights = FileReader.ReadFromFile();
            queryEnum = QueryEnum.NONE;
            resultString = "";            
        }

        public string[] GetCityArray(bool SrcCity = true)
        {
            List<string> Cities = new List<string>();
            foreach (FlightInfo flight in flights)
            {
                string city =  SrcCity?  (flight.OriginCity + ", " + flight.OriginState): 
                                        (flight.DestCity + ", " + flight.DestState);
                if (!Cities.Contains(city))
                    Cities.Add(city);
            }

            return Cities.ToArray();
        }

        public void SelectOriginCity(string originCity)
        {
            if (originCity.Length == 0)
                return;
            string[] cityAndState = originCity.Split(',');
            cityAndState[1] = cityAndState[1].Trim();
            int originalLength = flights.Count;
            for(int i = 0; i < flights.Count; )
            {
                if ((String.Compare(flights[i].OriginCity,cityAndState[0]) != 0) || (String.Compare(flights[i].OriginState,cityAndState[1])) != 0)
                    flights.RemoveAt(i);
                else
                    i++;
            }
        }

        public bool PerformQuery(string[] input)
        {
            UserInput = input;
            if(queryEnum == QueryEnum.AVG_DEP_DEL)
            {
                SelectDestCity(input[1]);
                calculator = new Calculator(flights);
                results = calculator.CalculateQuery(queryEnum);
            }
            if(queryEnum == QueryEnum.MOST_fLIGHTS)
            {
                SelectOriginCity(input[0]);
                calculator = new Calculator(flights);
                results = calculator.CalculateQuery(queryEnum);
            }
            if(queryEnum == QueryEnum.FARTHEST_DESTINATIONS)
            {
                SelectOriginCity(input[0]);
                calculator = new Calculator(flights);
                results = calculator.CalculateQuery(queryEnum);
            }

            return true;
        }

        public void SelectDestCity(string destCity)
        {
            if (destCity.Length == 0)
                return;
            string[] cityAndState = destCity.Split(',');
            cityAndState[1] = cityAndState[1].Trim();
            int originalLength = flights.Count;
            for (int i = 0; i < flights.Count;)
            {
                if ((String.Compare(flights[i].DestCity, cityAndState[0]) != 0) || (String.Compare(flights[i].DestState, cityAndState[1])) != 0)
                    flights.RemoveAt(i);
                else
                    i++;
            }
        }

        public void StartQuery(QueryEnum query)
        {
            queryEnum = query;            
        }
        
        public string GetResults()
        {
            printEditor = new PrintEdit();
            return (printEditor.EditReuslts(UserInput, results, queryEnum));
        }

    }

    public enum QueryEnum
    {
        NONE,
        AVG_DEP_DEL,
        MOST_fLIGHTS,
        FARTHEST_DESTINATIONS,
        SHORTEST_PATH
    }
}
