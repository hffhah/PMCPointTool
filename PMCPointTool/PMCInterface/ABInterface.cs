using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    public class ABInterface : BaseInterface
    {
        public ABInterface(int alarmStartAddr)
            : base(alarmStartAddr)
        {

        }

        public override int getSummaryBitNumber(int stationNo)
        {
            return base.getSummaryBitNumber(stationNo, 16);
        }

        public override int getSummaryByteNumber(int stationNo, string summaryType)
        {
            return base.getSummaryByteNumber(stationNo, summaryType, 16);
        }

        public override void initStartAddr()
        {
            //this.alarmDetail_start_address = 5;   //37 金桥南北厂alarmStartAddr=37
            this.control_start_address = 129;
            this.rootcase_start_address = 136;
            this.downtime1_start_address = 17;
            this.downtime2_start_address = 33;
            this.downtime3_start_address = 49;
            this.prod1_start_address = 65;
            this.prod2_start_address = 81;
            this.prod3_start_address = 97;
            this.downtime_triger_start_address = 142;
            this.prod1_module1_start_address = 66;
            this.prod2_module1_start_address = 82;
            this.prod3_module1_start_address = 98;
            this.buffer_counter1_start_address = 113;
            this.tip_val_cycletime_start_address = 121;
            this.tip_car_type_start_address = 140;
            this.tip_current_cycletime = 16;

            this.station_alarmDetail_interval = 96;
            this.station_info_interval = 144;

        }

    }
}
