using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    public class SiemensInterface : BaseInterface
    {

        public SiemensInterface(int alarmStartAddr)
            : base(alarmStartAddr)
        {

        }

        public override int getSummaryBitNumber(int stationNo)
        {
            return base.getSummaryBitNumber(stationNo, 8);
        }

        public override int getSummaryByteNumber(int stationNo, string summaryType)
        {
            //return base.getSummaryByteNumber(stationNo, summaryType, 8);

            int number = -1;

            if (!checkStationNo(stationNo))
                return number;

            if (summaryType == "MF")
            {
                if (stationNo <= 8)
                {
                    number = 2;
                }
                else if (stationNo > 8 && stationNo <= 16)
                {
                    number = 3;
                }
                else if (stationNo > 17 && stationNo <= 24)
                {
                    number = 4;
                }
                else if (stationNo > 25 && stationNo <= 32)
                {
                    number = 5;
                }
            }
            else if (summaryType == "WN")
            {
                if (stationNo <= 8)
                {
                    number = 6;
                }
                else if (stationNo > 8 && stationNo <= 16)
                {
                    number = 7;
                }
                else if (stationNo > 17 && stationNo <= 24)
                {
                    number = 8;
                }
                else if (stationNo > 25 && stationNo <= 32)
                {
                    number = 9;
                }
            }

            return number;
        }

        public override void initStartAddr()
        {
            //this.alarmDetail_start_address = 20;
            this.control_start_address = 322;  //clear word
            this.rootcase_start_address = -1;  //2*(stationNo-1)
            this.downtime1_start_address = 98; //block stop
            this.downtime2_start_address = 130;
            this.downtime3_start_address = 162;
            this.prod1_start_address = 194;    //summary
            this.prod2_start_address = 226;
            this.prod3_start_address = 258;
            this.downtime_triger_start_address = 326;
            this.prod1_module1_start_address = 196;
            this.prod2_module1_start_address = 228;
            this.prod3_module1_start_address = 260;
            this.buffer_counter1_start_address = 290;

            this.station_alarmDetail_interval = 416; //byte
            this.station_info_interval = 352;        //byte
        }
    }
}
