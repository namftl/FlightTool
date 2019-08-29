using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    /// <summary>
    /// this class handles all the data and parameter passing between the file, calculator and input,
    /// returns data in result format
    /// </summary>
    class QuerryProcess
    {
        QuerryEnum Querry;
        string[] UserInput;
        Calculator Calculator;
        PrintEdit PrintEditor;
        CsvReader FileReader;
        List<FlightInfo> AlteredFlights;
        List<FlightInfo> OriginalFlights;
        object[] Results;

        /// <summary>
        /// init querry process with all data from file, create two lists for reset
        /// </summary>
        /// <param name="sourceFile"></param>
        public QuerryProcess(string sourceFile)
        {
            FileReader = new CsvReader(sourceFile);
            AlteredFlights = FileReader.ReadFromFile();
            OriginalFlights = AlteredFlights.ToList();
            Querry = QuerryEnum.NONE;
        }

        /// <summary>
        /// return all current (unique) source cities in "[city], [state]" format
        /// </summary>
        /// <param name="SrcCity"></param>
        /// <returns></returns>
        public string[] GetCityArray(bool SrcCity = true)
        {
            List<string> Cities = new List<string>();
            if (AlteredFlights != null)
            {
                foreach (FlightInfo flight in AlteredFlights)
                {
                    string city = SrcCity ? (flight.OriginCity + ", " + flight.OriginState) :
                                            (flight.DestCity + ", " + flight.DestState);
                    if (!Cities.Contains(city))
                        Cities.Add(city);
                }
            }
            return Cities.ToArray();
        }

        /// <summary>
        /// given a selected origin city - select only flights with it
        /// </summary>
        /// <param name="originCity"></param>
        public void SelectOriginCity(string originCity)
        {
            if ((originCity.Length == 0) || (!originCity.Contains(',')))
            {
                AlteredFlights = null;
                return;
            }
            string[] cityAndState = originCity.Split(',');
            cityAndState[1] = cityAndState[1].Trim();
            for(int i = 0; i < AlteredFlights.Count; )
            {
                if ((String.Compare(AlteredFlights[i].OriginCity,cityAndState[0]) != 0) || (String.Compare(AlteredFlights[i].OriginState,cityAndState[1])) != 0)
                    AlteredFlights.RemoveAt(i);
                else
                    i++;
            }
        }

        /// <summary>
        /// update userinput, according to querry perform calculation and save results
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public bool PerformQuery(string[] input)
        {
            UserInput = input;            

            if(Querry == QuerryEnum.AVG_DEP_DEL)
            {
                SelectDestCity(input[1]);
                if (AlteredFlights == null)
                    return false;
                Calculator = new Calculator(AlteredFlights);
                Results = Calculator.CalculateQuery(Querry);
            }
            if(Querry == QuerryEnum.MOST_fLIGHTS)
            {
                SelectOriginCity(input[0]);
                if (AlteredFlights == null)
                    return false;
                Calculator = new Calculator(AlteredFlights);
                Results = Calculator.CalculateQuery(Querry);
            }
            if(Querry == QuerryEnum.FARTHEST_DESTINATIONS)
            {
                SelectOriginCity(input[0]);
                if (AlteredFlights == null)
                    return false;
                Calculator = new Calculator(AlteredFlights);
                Results = Calculator.CalculateQuery(Querry);
            }

            return true;
        }

        /// <summary>
        /// given a destination city - select only flights with it
        /// </summary>
        /// <param name="destCity"></param>
        public void SelectDestCity(string destCity)
        {
            if ((destCity.Length == 0) || (!destCity.Contains(',')))
            {
                AlteredFlights = null;
                return;
            }
            string[] cityAndState = destCity.Split(',');
            cityAndState[1] = cityAndState[1].Trim();
            int originalLength = AlteredFlights.Count;
            for (int i = 0; i < AlteredFlights.Count;)
            {
                if ((String.Compare(AlteredFlights[i].DestCity, cityAndState[0]) != 0) || (String.Compare(AlteredFlights[i].DestState, cityAndState[1])) != 0)
                    AlteredFlights.RemoveAt(i);
                else
                    i++;
            }
        }

        /// <summary>
        /// defines current querry performed
        /// </summary>
        /// <param name="query"></param>
        public void StartQuery(QuerryEnum query)
        {
            Querry = query;            
        }
        
        /// <summary>
        /// return result according to querry member as formatted string
        /// </summary>
        /// <returns></returns>
        public string GetResults()
        {
            PrintEditor = new PrintEdit();
            return (PrintEditor.EditReuslts(UserInput, Results, Querry));
        }

        /// <summary>
        /// refill the flight list with all unfilterd flights
        /// </summary>
        public void ResetResults()
        {
            AlteredFlights = OriginalFlights.ToList();
        }

    }

    public enum QuerryEnum
    {
        NONE,
        AVG_DEP_DEL,
        MOST_fLIGHTS,
        FARTHEST_DESTINATIONS
    }
}
