using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelaFlights
{
    class DataGetter
    {
        List<DataFormat> member;
        public DataGetter()
        {
            member = new List<DataFormat>();
            member.Add(new DataFormat(2));
        }

        public List<DataFormat> GetData()
        {
            return member;
        }
    }

    public struct DataFormat
    {
        public int member;
        public DataFormat(int param)
        {
            member = param;
        }
    }
}
