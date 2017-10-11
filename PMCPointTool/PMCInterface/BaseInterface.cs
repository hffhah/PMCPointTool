using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    public abstract class BaseInterface
    {
        protected SpecialChar specialChar;

        protected const int STATION_MAX_COUNT = 32;
        protected int alarmDetail_start_address;
        protected int control_start_address;
        protected int rootcase_start_address;
        protected int downtime1_start_address, downtime2_start_address, downtime3_start_address;
        protected int prod1_start_address, prod2_start_address, prod3_start_address;
        protected int downtime_triger_start_address;
        protected int prod1_module1_start_address, prod2_module1_start_address, prod3_module1_start_address;
        protected int buffer_counter1_start_address;
        protected int station_alarmDetail_interval; //工位详细报警间隔word
        protected int station_info_interval;        //工位信息间隔word
        protected int tip_val_cycletime_start_address;
        protected int tip_car_type_start_address;        //车型  
        protected int tip_current_cycletime;  //当前cycletime

        public SpecialChar SpecialChar
        {
            get { return specialChar; }
            set { specialChar = value; }
        }

        protected List<StationAddress> stationAddrs_AlarmDetail = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_ControlWord = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_RootCase = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_DownTime_Shift1 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_DownTime_Shift2 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_DownTime_Shift3 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_ProdCount_Shift1 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_ProdCount_Shift2 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_ProdCount_Shift3 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_DownTimeTrigger = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_moduleA_shift2 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_moduleA_shift1 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_moduleA_shift3 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_buffer1 = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_tip_val_cycletime = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_tip_car_type = new List<StationAddress>();
        protected List<StationAddress> stationAddrs_tip_current_cycletime = new List<StationAddress>();

        public List<StationAddress> StationAddrs_tip_current_cycletime
        {
            get { return stationAddrs_tip_current_cycletime; }
            set { stationAddrs_tip_current_cycletime = value; }
        }
        public List<StationAddress> StationAddrs_tip_car_type
        {
            get { return stationAddrs_tip_car_type; }
            set { stationAddrs_tip_car_type = value; }
        }
        public List<StationAddress> StationAddrs_tip_val_cycletime
        {
            get { return stationAddrs_tip_val_cycletime; }
            set { stationAddrs_tip_val_cycletime = value; }
        }
        public List<StationAddress> StationAddrs_DownTime_Shift2
        {
            get { return stationAddrs_DownTime_Shift2; }
            set { stationAddrs_DownTime_Shift2 = value; }
        }
        public List<StationAddress> StationAddrs_DownTime_Shift3
        {
            get { return stationAddrs_DownTime_Shift3; }
            set { stationAddrs_DownTime_Shift3 = value; }
        }
        public List<StationAddress> StationAddrs_ProdCount_Shift1
        {
            get { return stationAddrs_ProdCount_Shift1; }
            set { stationAddrs_ProdCount_Shift1 = value; }
        }
        public List<StationAddress> StationAddrs_ProdCount_Shift3
        {
            get { return stationAddrs_ProdCount_Shift3; }
            set { stationAddrs_ProdCount_Shift3 = value; }
        }
        public List<StationAddress> StationAddrs_DownTime_Shift1
        {
            get { return stationAddrs_DownTime_Shift1; }
            set { stationAddrs_DownTime_Shift1 = value; }
        }
        public List<StationAddress> StationAddrs_RootCase
        {
            get { return stationAddrs_RootCase; }
            set { stationAddrs_RootCase = value; }
        }
        public List<StationAddress> StationAddrs_ControlWord
        {
            get { return stationAddrs_ControlWord; }
            set { stationAddrs_ControlWord = value; }
        }
        public List<StationAddress> StationAddrs_AlarmDetail
        {
            get { return stationAddrs_AlarmDetail; }
            set { stationAddrs_AlarmDetail = value; }
        }
        public List<StationAddress> StationAddrs_DownTimeTrigger
        {
            get { return stationAddrs_DownTimeTrigger; }
            set { stationAddrs_DownTimeTrigger = value; }
        }
        public List<StationAddress> StationAddrs_moduleA_shift1
        {
            get { return stationAddrs_moduleA_shift1; }
            set { stationAddrs_moduleA_shift1 = value; }
        }
        public List<StationAddress> StationAddrs_moduleA_shift2
        {
            get { return stationAddrs_moduleA_shift2; }
            set { stationAddrs_moduleA_shift2 = value; }
        }
        public List<StationAddress> StationAddrs_moduleA_shift3
        {
            get { return stationAddrs_moduleA_shift3; }
            set { stationAddrs_moduleA_shift3 = value; }
        }
        public List<StationAddress> StationAddrs_buffer1
        {
            get { return stationAddrs_buffer1; }
            set { stationAddrs_buffer1 = value; }
        }

        public BaseInterface(int alarmStartAddr)
        {
            this.alarmDetail_start_address = alarmStartAddr;   //
            initStartAddr();
            setVars();
        }

        private void setVars()
        {
            specialChar = new SpecialChar();
            StationAddress sa = null;

            for (int i = 0; i < STATION_MAX_COUNT; i++)
            {
                sa = new StationAddress();
                sa.StationNo = i + 1;

                //详细报警 
                sa.StartAddress = alarmDetail_start_address + i * station_alarmDetail_interval;  //96 word = 64 fault+32 warn
                addStartAddr(sa, stationAddrs_AlarmDetail);

                //控制字地址
                sa.StartAddress = control_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_ControlWord);

                //RootCase
                sa.StartAddress = rootcase_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_RootCase);

                //downtime -shift 1
                sa.StartAddress = downtime1_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_DownTime_Shift1);

                sa.StartAddress = downtime2_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_DownTime_Shift2);

                sa.StartAddress = downtime3_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_DownTime_Shift3);

                //prod count -shift 1
                sa.StartAddress = prod1_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_ProdCount_Shift1);

                sa.StartAddress = prod2_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_ProdCount_Shift2);

                sa.StartAddress = prod3_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_ProdCount_Shift3);

                //down time trigger
                sa.StartAddress = downtime_triger_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_DownTimeTrigger);

                //module1 prod shift1
                sa.StartAddress = prod1_module1_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_moduleA_shift1);

                sa.StartAddress = prod2_module1_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_moduleA_shift2);

                sa.StartAddress = prod3_module1_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_moduleA_shift3);

                //buffer counter1
                sa.StartAddress = buffer_counter1_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_buffer1);

                //tip val cycletime
                sa.StartAddress = tip_val_cycletime_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_tip_val_cycletime);

                //tip car type
                sa.StartAddress = tip_car_type_start_address + i * station_info_interval;
                addStartAddr(sa, stationAddrs_tip_car_type);

                //tip current cycletime
                sa.StartAddress = tip_current_cycletime + i * station_info_interval;
                addStartAddr(sa, stationAddrs_tip_current_cycletime);
            }
        }

        protected bool checkStationNo(int stationNo)
        {
            if (stationNo < 0 || stationNo > 32)
                return false;
            else
                return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationNo"></param>
        /// <param name="summaryType"></param>
        /// <param name="bitMax">AB=16,SIEMENS=8</param>
        /// <returns></returns>
        protected int getSummaryByteNumber(int stationNo, string summaryType, int bitMax)
        {
            int number = -1;

            if (!checkStationNo(stationNo))
                return number;

            if (summaryType == "MF")
            {
                if (stationNo <= bitMax)
                    number = 1;
                else
                    number = 2;
            }
            else if (summaryType == "WN")
            {
                if (stationNo <= bitMax)
                    number = 3;
                else
                    number = 4;
            }
            return number;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="stationNo"></param>
        /// <param name="bitMax">AB=16,SIEMENS=8</param>
        /// <returns></returns>
        protected int getSummaryBitNumber(int stationNo, int bitMax)
        {
            int number = -1;

            if (!checkStationNo(stationNo))
                return number;

            if (stationNo <= bitMax)
                number = stationNo - 1;
            else
                number = (stationNo - 1) % bitMax;

            return number;
        }

        public int getTokenByteNumber(int stationNo)
        {
            int number = -1;

            if (!checkStationNo(stationNo))
                return number;

            if (stationNo <= 16)
                number = 1;
            else
                number = 2;

            return number;
        }

        public int getTokenBitNumber(int stationNo)
        {
            int number = -1;

            if (!checkStationNo(stationNo))
                return number;

            if (stationNo <= 16)
                number = stationNo - 1;
            else
                number = (stationNo - 1) % 16;

            return number;
        }

        protected void addStartAddr(StationAddress startAddr, List<StationAddress> list)
        {
            StationAddress startAddrNew = new StationAddress();

            startAddrNew.StartAddress = startAddr.StartAddress;
            startAddrNew.StationNo = startAddr.StationNo;

            list.Add(startAddrNew);
        }

        public abstract int getSummaryBitNumber(int stationNo);

        public abstract int getSummaryByteNumber(int stationNo, string summaryType);

        /// <summary>
        /// 初始化首地址
        /// </summary>
        public abstract void initStartAddr();

        public int getStartAddress(int stationNo, List<StationAddress> list)
        {
            int number = -1;
            if (!checkStationNo(stationNo))
                return number;

            return list[stationNo - 1].StartAddress;
        }

        /// <summary>
        /// 检查station信息
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="stationNo"></param>
        /// <param name="resourceId"></param>
        /// <param name="deviceId"></param>
        /// <param name="alarmNumber"></param>
        /// <param name="alarmDetail"></param>
        public void checkStationInfo(string stationName, int stationNo, string resourceId, string deviceId, int alarmNumber = -1, string alarmDetail = "")
        {
            if (!checkStationNo(stationNo))
                throw new MyException("工位号不符合规范。stationNo=" + stationNo);

            if (alarmNumber > 1024)
                throw new MyException("报警号不符合规范。alarmNumber=" + alarmNumber);

            if (String.IsNullOrEmpty(deviceId) || String.IsNullOrEmpty(resourceId) || String.IsNullOrEmpty(stationName))
                throw new MyException("工位名、设备名、资源名不可为空。stationName=" + stationName + ",deviceId=" + deviceId + ",resourceId=" + resourceId);
        }

    }
}
