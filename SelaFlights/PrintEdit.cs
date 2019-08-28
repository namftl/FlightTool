﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    class PrintEdit
    {
        int member;
        ResultFormats MsgFormat;
        public PrintEdit()
        {
            MsgFormat = new ResultFormats();
            member = 2;
        }

        public string EditReuslts(string[] input, object[] results, QueryEnum queryEnum)
        {
            string msg = MsgFormat.GetFormat(queryEnum);
            if (queryEnum == QueryEnum.AVG_DEP_DEL)
                msg = String.Format(msg, (int)results[2],input[0], input[1], (double)results[0], (double)results[1]);
            else if (queryEnum == QueryEnum.MOST_fLIGHTS)
                msg = String.Format(msg, input[0], results[0], results[1]);
            else if (queryEnum == QueryEnum.FARTHEST_DESTINATIONS)
                msg = String.Format(msg, input[0], (string)results[0]);
            return msg;
        }
    }

    public class ResultFormats
    {
        const string AvgDepDel = "Based on {0} flights from {1} to  {2}: \r\nAvg departure delay is {3} min \r\nAvg arrival delay is {4} min";
        const string MostFlights = "{0} Has the most outgoing flights to \r\n{1} - {2} flights";
        const string FiveDestinations = "From city {0}, the 5 farthest destinations are:{1}";
        List<KeyValuePair<QueryEnum, string>> FormatList;
        string[] resultFormats;
        public ResultFormats()
        {
            FormatList = new List<KeyValuePair<QueryEnum, string>>()
            {
                new KeyValuePair<QueryEnum, string>(QueryEnum.AVG_DEP_DEL, AvgDepDel),
                new KeyValuePair<QueryEnum, string>(QueryEnum.MOST_fLIGHTS, MostFlights),
                new KeyValuePair<QueryEnum, string>(QueryEnum.FARTHEST_DESTINATIONS, FiveDestinations)
            };
            resultFormats = new string[]{ AvgDepDel, MostFlights, FiveDestinations };
        }
        public string GetFormat(QueryEnum queryEnum)
        {
            int queryIndex = (int)queryEnum - 1;
            return FormatList.Where(x => x.Key == queryEnum).First().Value;
        }
    }
    
}