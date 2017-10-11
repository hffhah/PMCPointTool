using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    class Station
    {
        string name;
        int number;
        string resourceId;
        bool isFilter;
        bool isProdStation;

        List<AlarmDetail> alarmDetails = new List<AlarmDetail>();

        public bool IsFilter
        {
            get { return isFilter; }
            set { isFilter = value; }
        }

        public int Number
        {
            get { return number; }
            set { number = value; }
        }

        public string ResourceId
        {
            get { return resourceId; }
            set { resourceId = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool IsProdStation
        {
            get { return isProdStation; }
            set { isProdStation = value; }
        }

        public List<AlarmDetail> AlarmDetails
        {
            get { return alarmDetails; }
            set { alarmDetails = value; }
        }
    }
}
