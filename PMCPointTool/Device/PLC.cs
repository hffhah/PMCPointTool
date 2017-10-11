using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    class PLC
    {
        string name;
        string deviceId;
        bool isFilter;
        List<Station> stations = new List<Station>();

        public bool IsFilter
        {
            get { return isFilter; }
            set { isFilter = value; }
        }
        public string DeviceId
        {
            get { return deviceId; }
            set { deviceId = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<Station> Stations
        {
            get { return stations; }
            set { stations = value; }
        }
    }
}
