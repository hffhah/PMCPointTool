using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    /// <summary>
    /// MainForm界面选择类
    /// </summary>
    public class MainFormOperation
    {
        private string plc_type;
        private string plc_addr_type;
        private string point_type;
        private string tip_type;
        private string alarm_start_addr;

        public string Alarm_start_addr
        {
            get { return alarm_start_addr; }
            set { alarm_start_addr = value; }
        }
        public string Tip_type
        {
            get { return tip_type; }
            set { tip_type = value; }
        }
        public string Plc_type
        {
            get { return plc_type; }
            set { plc_type = value; }
        }
        public string Plc_addr_type
        {
            get { return plc_addr_type; }
            set { plc_addr_type = value; }
        }
        public string Point_type
        {
            get { return point_type; }
            set { point_type = value; }
        }
  
    }
}
