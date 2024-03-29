﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    /// <summary>
    /// this class handles formatting raw results into a specific string depending on the querry
    /// </summary>
    class PrintEdit
    {
        ResultFormats MsgFormat;
        public PrintEdit()
        {
            MsgFormat = new ResultFormats();
        }

        /// <summary>
        /// given input, querry, results - return a parsed results string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="results"></param>
        /// <param name="queryEnum"></param>
        /// <returns></returns>
        public string EditReuslts(string[] input, object[] results, QuerryEnum queryEnum)
        {
            string msg = MsgFormat.GetFormat(queryEnum);
            if (queryEnum == QuerryEnum.AVG_DEP_DEL)
                msg = String.Format(msg, (int)results[2], input[0], input[1], (double)results[0], (double)results[1]);
            else if (queryEnum == QuerryEnum.MOST_fLIGHTS)
                msg = String.Format(msg, input[0], results[0], results[1]);
            else if (queryEnum == QuerryEnum.FARTHEST_DESTINATIONS)
                msg = String.Format(msg, input[0], (string)results[0]);
            return msg;
        }
    }

    /// <summary>
    /// this class outlines the string format for each querry
    /// </summary>
    public class ResultFormats
    {
        const string AvgDepDel = "Based on {0} flights from {1} to  {2}: \r\nAvg departure delay is {3} min \r\nAvg arrival delay is {4} min";
        const string MostFlights = "{0} Has the most outgoing flights to \r\n{1} - {2} flights";
        const string FiveDestinations = "From city {0}, the 5 farthest destinations are:{1}";
        List<KeyValuePair<QuerryEnum, string>> FormatList;
        string[] resultFormats;

        /// <summary>
        /// fills the member formatlist with all required formats
        /// </summary>
        public ResultFormats()
        {
            FormatList = new List<KeyValuePair<QuerryEnum, string>>()
            {
                new KeyValuePair<QuerryEnum, string>(QuerryEnum.AVG_DEP_DEL, AvgDepDel),
                new KeyValuePair<QuerryEnum, string>(QuerryEnum.MOST_fLIGHTS, MostFlights),
                new KeyValuePair<QuerryEnum, string>(QuerryEnum.FARTHEST_DESTINATIONS, FiveDestinations)
            };
            resultFormats = new string[]{ AvgDepDel, MostFlights, FiveDestinations };
        }

        /// <summary>
        /// given a querry return the appropriate format
        /// </summary>
        /// <param name="queryEnum"></param>
        /// <returns></returns>
        public string GetFormat(QuerryEnum queryEnum)
        {
            int queryIndex = (int)queryEnum - 1;
            return FormatList.Where(x => x.Key == queryEnum).First().Value;
        }
    }
    
}
