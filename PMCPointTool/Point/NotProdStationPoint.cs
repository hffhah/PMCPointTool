using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    class NotProdStationPoint : BasePoint
    {
        public NotProdStationPoint(MainController _mainController, MainFormOperation _mainFormOperation, InterfaceEnum _interface)
            : base(_mainController, _mainFormOperation)
        {
        }

        public override void initPointNames()
        {
            this.pointNames.Add(PointConstant.MF00000_R);
            this.pointNames.Add(PointConstant.WN00000_R);
        }

        public override void initPointAttr(string pointName, PointAttr rowAttr, string stationName, int stationNo, string resourceId, string deviceId)
        {
            switch (pointName)
            {
                case PointConstant.MF00000_R:
                    PointAttr.initAttr_MF00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId);

                    break;
                case PointConstant.WN00000_R:
                    PointAttr.initAttr_WN00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId);

                    break;
                default:
                    break;
            }
        }
    }
}
