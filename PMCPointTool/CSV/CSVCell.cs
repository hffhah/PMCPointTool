using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    class CSVCell
    {
        private string filed;
        private string val;

        public string Val
        {
            get { return val; }
            set { val = value; }
        }

        public string Filed
        {
            get { return filed; }
            set { filed = value; }
        }
    }
}
