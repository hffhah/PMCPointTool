using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMCPointTool
{
    public class InterfaceFactory
    {
        private static BaseInterface baseInterface;  //接口类型
        private static string mAlarmStartAddr;       //报警首地址

        public static BaseInterface getInstance(MainFormOperation mainFormOperation, InterfaceEnum interfaceType)
        {
            if (mAlarmStartAddr != mainFormOperation.Alarm_start_addr)
            {
                if (null != baseInterface)
                    baseInterface = null;

                //计算报警首地址
                int alarmStartAddr;

                if (mainFormOperation.Alarm_start_addr == Constant.ALARM_START_ADDR_5)
                    alarmStartAddr = 5;
                else if (mainFormOperation.Alarm_start_addr == Constant.ALARM_START_ADDR_37)
                    alarmStartAddr = 37;
                else
                    alarmStartAddr = 5;

                //初始化接口对象
                switch (interfaceType)
                {
                    case InterfaceEnum.AB:
                        baseInterface = new ABInterface(alarmStartAddr);
                        break;
                    case InterfaceEnum.SIEMENS:
                        alarmStartAddr = 20;
                        baseInterface = new SiemensInterface(alarmStartAddr);
                        break;
                    default:
                        break;
                }

                mAlarmStartAddr = mainFormOperation.Alarm_start_addr;
            }

            return baseInterface;
        }
    }

    public enum InterfaceEnum
    {
        AB, SIEMENS
    }
}
