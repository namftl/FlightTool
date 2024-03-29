﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    /// <summary>
    /// this class reads a given file, split row by comma, select required (predetermined) info from line,
    /// return a list of all rows infos
    /// </summary>
    class CsvReader
    {
        string fileName;
        StreamReader streamReader;
        List<FlightInfo> FlightsInfo;
        const char SEPERATOR = ',';
        const string NA_FIELD = "NA";

        /// <summary>
        /// init with file name
        /// </summary>
        /// <param name="p_fileName"></param>
        public CsvReader(string p_fileName)
        {
            fileName = p_fileName;
        }
        
        /// <summary>
        /// parse each line for important info, return a list of it
        /// </summary>
        /// <returns></returns>
        public List<FlightInfo> ReadFromFile()
        {
            string line;
            FlightInfo flight;
            List<FlightInfo> flights = new List<FlightInfo>();
            streamReader = new StreamReader(fileName);
            streamReader.ReadLine();   //headers line
            while(!streamReader.EndOfStream)
            {
                line = streamReader.ReadLine();

                flight = GetFlightInfo(line, SEPERATOR);
                flights.Add(flight);
            }
            FlightsInfo = flights;
            return flights;
        }

        /// <summary>
        /// parse line into flightinfo format
        /// </summary>
        /// <param name="line"></param>
        /// <param name="seperator"></param>
        /// <returns></returns>
        private FlightInfo GetFlightInfo(string line, char seperator)
        {
            line = line.Replace("\"", "");
            string[] splittedLine = line.Split(seperator);
            FlightInfo flight = new FlightInfo();

            if (splittedLine[(int)eFlightFields.ArrDelay] != NA_FIELD)
                flight.ArrDelay = int.Parse(splittedLine[(int)eFlightFields.ArrDelay]);
            else
                flight.ArrDelay = -1;
            if (splittedLine[(int)eFlightFields.DepDelay] != NA_FIELD)
                flight.DepDelay = int.Parse(splittedLine[(int)eFlightFields.DepDelay]);
            else
                flight.DepDelay = -1;
            if (splittedLine[(int)eFlightFields.DestCity] != NA_FIELD)
            {
                flight.DestCity = splittedLine[(int)eFlightFields.DestCity];
                flight.DestState = splittedLine[(int)eFlightFields.DestState];
            }
            if (splittedLine[(int)eFlightFields.OriginCity] != NA_FIELD)
            {
                flight.OriginCity = splittedLine[(int)eFlightFields.OriginCity];
                flight.OriginState = splittedLine[(int)eFlightFields.OriginState];
            }
            if (splittedLine[(int)eFlightFields.Distance] != NA_FIELD)
                flight.Distance = int.Parse(splittedLine[(int)eFlightFields.Distance]);
            return flight;
        }
    }

    /// <summary>
    /// determines the required locations in splitted line of desired info
    /// </summary>
    public enum eFlightFields
    {
        FlightId = 0,
        OriginCity = 16,
        OriginState = 20,
        DestCity = 26,
        DestState = 30,
        DepDelay = 35,
        ArrDelay = 46,
        Distance = 57
    }

    /// <summary>
    /// this class contains all desired information from a row in the read file
    /// </summary>
    public class FlightInfo
    {
        public int FlightId { get; set; }
        public string OriginCity { get; set; }
        public string OriginState { get; set; }
        public string DestCity { get; set; }
        public string DestState { get; set; }
        public int DepDelay { get; set; }
        public int ArrDelay { get; set; }
        public int Distance { get; set; }

        public FlightInfo()
        {
            Distance = 0;
            ArrDelay = 0;
            DepDelay = 0;
            OriginCity = "";
            OriginState = "";
            DestCity = "";
            DestState = "";
        }
    }
}
