using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    class Area
    {
        string name;
        List<PLC> plcs = new List<PLC>();

        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public List<PLC> Plcs
        {
            get { return plcs; }
            set { plcs = value; }
        }
    }
}
