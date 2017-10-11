using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    /// <summary>
    /// 全局变量类
    /// </summary>
    public class Global
    {
        public static string OUTPUT_PATH;
        public static string[] CONFIG_PATH;


        public static string PLC_ADDR_TYPE_ALARM;
        public static string PLC_ADDR_TYPE_PROD;

        public static bool isReadMultiAlarmConfig;//同时读取多个报警配置文件

    }
}
