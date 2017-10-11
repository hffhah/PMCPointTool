using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    public class CSVRow
    {
        string rowName;
        PointAttr csvRowAttr;

        public string RowName
        {
            get { return rowName; }
            set { rowName = value; }
        }
        PointAttr CsvRowAttr
        {
            get { return csvRowAttr; }
            set { csvRowAttr = value; }
        }
    }
}
