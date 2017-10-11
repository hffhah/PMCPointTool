using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    public class StationAddress
    {
        private int startAddress;
        private int stationNo;

        public int StartAddress
        {
            get { return startAddress; }
            set { startAddress = value; }
        }
        public int StationNo
        {
            get { return stationNo; }
            set { stationNo = value; }
        }
    }
}
