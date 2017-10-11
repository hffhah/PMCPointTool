using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    /// <summary>
    /// 全局常量类
    /// </summary>
    public class Constant
    {
        public static string APP_NAME = System.Windows.Forms.Application.ProductName;
        public static string APP_VERSION = System.Windows.Forms.Application.ProductVersion;

        public static int CONFIG_ALARM_DETAILS_MAX = 9000; //最大报警条数.

        public const int CSV_FILED_COUNT = 140;
        public const int ALARM_NUMBER_COUNT_MAX = 1024;
        public const int ALARM_NUMBER_COUNT_MIN = 1;

        public const string CONFIG_STATION_INFO = "station_info";
        public const string CONFIG_STATION_ALARM = "station_alarm";

        public const string POINT_TYPE_ALARM = "报警点";
        public const string POINT_TYPE_PROD = "产量工位点";
        public const string POINT_TYPE_NOT_PROD = "非产量工位点";

        public const string PLC_TYPE_AB = "AB";
        public const string PLC_TYPE_SIEMENS = "SIEMENS";

        public const string POINT_TYPE_TIP_NOT_CONTAIN = "不含TIP点";
        public const string POINT_TYPE_TIP_CONTAIN = "含TIP点";
        public const string POINT_TYPE_TIP_JUST = "仅含TIP点";

        public const string ALARM_START_ADDR_5 = "首地址为 5";
        public const string ALARM_START_ADDR_37 = "首地址为 37";

        public const string PLC_AB_ADDR_ARRAY_ALARM = "PMC_ARRAY_ALARM";
        public const string PLC_AB_ADDR_ARRAY_PROD = "PMC_ARRAY_PROD";
        public const string PLC_AB_ADDR_N200 = "N200";
        public const string PLC_AB_ADDR_N201 = "N201";

        public const string PLC_SIEMENS_ALARM_DB = "DB10";
        public const string PLC_SIEMENS_INFO_DB = "DB11";
        public const string PLC_SIEMENS_TIP_DB = "DB12";
        public const string PLC_SIEMENS_BTS_DB = "DB13";

        public static string ROOT_PATH = Directory.GetCurrentDirectory();
        public static string LOG_PATH = Path.GetFullPath(@"Log\Log_" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt");

        public static string SHEET_NAME = "Sheet1";
    }

}
