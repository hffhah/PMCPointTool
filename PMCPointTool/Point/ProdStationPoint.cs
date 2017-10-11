using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PMCPointTool
{
    class ProdStationPoint : BasePoint
    {
        public ProdStationPoint(MainController mainController, MainFormOperation mainFormOperation, InterfaceEnum _interface)
            : base(mainController, mainFormOperation)
        {
        }

        public override void initPointNames()
        {
            #region 共同点
            //this.pointNames.Add(PointConstant.DEVICEUP);
            //this.pointNames.Add(PointConstant.ONLYONE_W);
            //this.pointNames.Add(PointConstant.GLOBAL__R);
            //this.pointNames.Add(PointConstant.VERSION_R);
            //this.pointNames.Add(PointConstant.STATION_ALARM);
            //this.pointNames.Add(PointConstant.STATION_PROD);
            this.pointNames.Add(PointConstant.MF00000_R);
            this.pointNames.Add(PointConstant.WN00000_R);
            //this.pointNames.Add(PointConstant.CONFIGR_R);
            this.pointNames.Add(PointConstant.CLS_SHIFT_ALL_W);
            this.pointNames.Add(PointConstant.CLS_SHIFT_1_W);
            this.pointNames.Add(PointConstant.CLS_SHIFT_2_W);
            this.pointNames.Add(PointConstant.CLS_SHIFT_3_W);
            this.pointNames.Add(PointConstant.WORK_SHIFT_1_W);
            this.pointNames.Add(PointConstant.WORK_SHIFT_2_W);
            this.pointNames.Add(PointConstant.WORK_SHIFT_3_W);
            this.pointNames.Add(PointConstant.WORK_SHIFT_W);
            this.pointNames.Add(PointConstant.RT00000_R);
            //this.pointNames.Add(PointConstant.HC00000_R);
            this.pointNames.Add(PointConstant.BD00001_R);
            this.pointNames.Add(PointConstant.BD00002_R);
            this.pointNames.Add(PointConstant.BD00003_R);
            this.pointNames.Add(PointConstant.SD00001_R);
            this.pointNames.Add(PointConstant.SD00002_R);
            this.pointNames.Add(PointConstant.SD00003_R);
            this.pointNames.Add(PointConstant.MD00001_R);
            this.pointNames.Add(PointConstant.MD00002_R);
            this.pointNames.Add(PointConstant.MD00003_R);
            this.pointNames.Add(PointConstant.PD00001_R);
            this.pointNames.Add(PointConstant.PD00002_R);
            this.pointNames.Add(PointConstant.PD00003_R);
            this.pointNames.Add(PointConstant.ED00001_R);
            this.pointNames.Add(PointConstant.ED00002_R);
            this.pointNames.Add(PointConstant.ED00003_R);
            this.pointNames.Add(PointConstant.AD00001_R);
            this.pointNames.Add(PointConstant.AD00002_R);
            this.pointNames.Add(PointConstant.AD00003_R);
            this.pointNames.Add(PointConstant.OD00001_R);
            this.pointNames.Add(PointConstant.OD00002_R);
            this.pointNames.Add(PointConstant.OD00003_R);
            this.pointNames.Add(PointConstant.CD00001_R);
            this.pointNames.Add(PointConstant.CD00002_R);
            this.pointNames.Add(PointConstant.CD00003_R);
            this.pointNames.Add(PointConstant.FD00001_R);
            this.pointNames.Add(PointConstant.FD00002_R);
            this.pointNames.Add(PointConstant.FD00003_R);
            this.pointNames.Add(PointConstant.BTRIGER_R);
            this.pointNames.Add(PointConstant.STRIGER_R);
            this.pointNames.Add(PointConstant.MTRIGER_R);
            this.pointNames.Add(PointConstant.PTRIGER_R);
            this.pointNames.Add(PointConstant.ETRIGER_R);
            this.pointNames.Add(PointConstant.ATRIGER_R);
            this.pointNames.Add(PointConstant.OTRIGER_R);
            this.pointNames.Add(PointConstant.CTRIGER_R);
            this.pointNames.Add(PointConstant.FTRIGER_R);
            this.pointNames.Add(PointConstant.ACOUNT__R);
            this.pointNames.Add(PointConstant.BCOUNT__R);
            this.pointNames.Add(PointConstant.CCOUNT__R);
            this.pointNames.Add(PointConstant.ECOUNT__R);
            this.pointNames.Add(PointConstant.FCOUNT__R);
            this.pointNames.Add(PointConstant.MCOUNT__R);
            this.pointNames.Add(PointConstant.OCOUNT__R);
            this.pointNames.Add(PointConstant.PCOUNT__R);
            this.pointNames.Add(PointConstant.SCOUNT__R);
            this.pointNames.Add(PointConstant.ATRIGER_V);
            this.pointNames.Add(PointConstant.BTRIGER_V);
            this.pointNames.Add(PointConstant.CTRIGER_V);
            this.pointNames.Add(PointConstant.ETRIGER_V);
            this.pointNames.Add(PointConstant.FTRIGER_V);
            this.pointNames.Add(PointConstant.MTRIGER_V);
            this.pointNames.Add(PointConstant.OTRIGER_V);
            this.pointNames.Add(PointConstant.PTRIGER_V);
            this.pointNames.Add(PointConstant.STRIGER_V);
            this.pointNames.Add(PointConstant.CLS_SHIFT_R);
            this.pointNames.Add(PointConstant.PCA0001_R);
            this.pointNames.Add(PointConstant.PCA0002_R);
            this.pointNames.Add(PointConstant.PCA0003_R);
            this.pointNames.Add(PointConstant.PCB0001_R);
            this.pointNames.Add(PointConstant.PCB0002_R);
            this.pointNames.Add(PointConstant.PCB0003_R);
            this.pointNames.Add(PointConstant.PCC0001_R);
            this.pointNames.Add(PointConstant.PCC0002_R);
            this.pointNames.Add(PointConstant.PCC0003_R);
            this.pointNames.Add(PointConstant.PCD0001_R);
            this.pointNames.Add(PointConstant.PCD0002_R);
            this.pointNames.Add(PointConstant.PCD0003_R);
            this.pointNames.Add(PointConstant.BC00001_R);
            this.pointNames.Add(PointConstant.BC00002_R);
            this.pointNames.Add(PointConstant.BC00003_R);
            this.pointNames.Add(PointConstant.BC00004_R);
            this.pointNames.Add(PointConstant.AD00000_R);
            this.pointNames.Add(PointConstant.BD00000_R);
            this.pointNames.Add(PointConstant.CD00000_R);
            this.pointNames.Add(PointConstant.ED00000_R);
            this.pointNames.Add(PointConstant.FD00000_R);
            this.pointNames.Add(PointConstant.MD00000_R);
            this.pointNames.Add(PointConstant.OD00000_R);
            this.pointNames.Add(PointConstant.PD00000_R);
            this.pointNames.Add(PointConstant.SD00000_R);
            this.pointNames.Add(PointConstant.PCA0000_R);
            this.pointNames.Add(PointConstant.PCB0000_R);
            this.pointNames.Add(PointConstant.PCC0000_R);
            this.pointNames.Add(PointConstant.PCD0000_R);
            this.pointNames.Add(PointConstant.FDMIN00_R);
            this.pointNames.Add(PointConstant.MTTR);
            this.pointNames.Add(PointConstant.MCBF);
            this.pointNames.Add(PointConstant.PC00001_R);
            this.pointNames.Add(PointConstant.PC00002_R);
            this.pointNames.Add(PointConstant.PC00003_R);
            this.pointNames.Add(PointConstant.PC00000_R);

            #endregion

            #region TIP点

            if (this.interfaceType == InterfaceEnum.AB)
            {
                //AB特有点
                this.pointNames.Add(PointConstant.HC00000_R);

                if (this.mainFormOperation.Tip_type != Constant.POINT_TYPE_TIP_NOT_CONTAIN)
                {
                    if (this.mainFormOperation.Tip_type == Constant.POINT_TYPE_TIP_JUST)
                        this.pointNames.Clear();

                    this.pointNames.Add(PointConstant.TIP_RDY_CYCLETIME);
                    this.pointNames.Add(PointConstant.TIP_FLT_BLOCK);
                    this.pointNames.Add(PointConstant.TIP_FLT_STARVE);
                    this.pointNames.Add(PointConstant.TIP_FLT_MACHINE);
                    this.pointNames.Add(PointConstant.TIP_FLT_PSTOP);
                    this.pointNames.Add(PointConstant.TIP_FLT_ESTOP);
                    this.pointNames.Add(PointConstant.TIP_FLT_ANDON);
                    this.pointNames.Add(PointConstant.TIP_FLT_OTHER);
                    this.pointNames.Add(PointConstant.TIP_FLT_OVERCYCLE);
                    this.pointNames.Add(PointConstant.TIP_FLT_ALL);
                    this.pointNames.Add(PointConstant.TIP_VAL_CYCLETIME);
                    this.pointNames.Add(PointConstant.TIP_VAL_PC00001);
                    this.pointNames.Add(PointConstant.TIP_VAL_PC00002);
                    this.pointNames.Add(PointConstant.TIP_VAL_PC00003);
                    this.pointNames.Add(PointConstant.TIP_VAL_CT);
                    this.pointNames.Add(PointConstant.TAKEON__R);
                    this.pointNames.Add(PointConstant.VM00000_R);
                    this.pointNames.Add(PointConstant.TIP_VAL_CURRENT_CYCLETIME);
                }
            }

            #endregion
        }

        public override void initSpecialPointName(int stationNo)
        {
            //第一个工位特殊点
            if (stationNo == 1)
            {
                if (this.mainFormOperation.Tip_type == Constant.POINT_TYPE_TIP_JUST)
                    return;

                if (this.interfaceType == InterfaceEnum.AB)
                {
                    this.spectialPointNames.Add(PointConstant.GLOBAL__R);
                    this.spectialPointNames.Add(PointConstant.ONLYONE_W);
                    this.spectialPointNames.Add(PointConstant.VERSION_R);
                    this.spectialPointNames.Add(PointConstant.CONFIGR_R);
                }

                this.spectialPointNames.Add(PointConstant.DEVICEUP);
                this.spectialPointNames.Add(PointConstant.STATION_ALARM);
                this.spectialPointNames.Add(PointConstant.STATION_PROD);
            }
        }

        public override void initPointAttr(string pointName, PointAttr rowAttr, string stationName, int stationNo, string resourceId, string deviceId)
        {
            try
            {
                switch (pointName)
                {
                    case PointConstant.DEVICEUP:
                        PointAttr.initAttr_DEVICEUP(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ONLYONE_W:
                        PointAttr.initAttr_ONLYONE_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.GLOBAL__R:
                        PointAttr.initAttr_GLOBAL__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.VERSION_R:
                        PointAttr.initAttr_VERSION_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.STATION_ALARM:
                        PointAttr.initAttr_STATION_ALARM(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.STATION_PROD:
                        PointAttr.initAttr_STATION_PROD(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MF00000_R: PointAttr.initAttr_MF00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.WN00000_R: PointAttr.initAttr_WN00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CONFIGR_R:
                        PointAttr.initAttr_CONFIGR_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CLS_SHIFT_ALL_W: PointAttr.initAttr_CLS_SHIFT_ALL_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CLS_SHIFT_1_W: PointAttr.initAttr_CLS_SHIFT_1_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CLS_SHIFT_2_W: PointAttr.initAttr_CLS_SHIFT_2_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CLS_SHIFT_3_W: PointAttr.initAttr_CLS_SHIFT_3_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.WORK_SHIFT_1_W: PointAttr.initAttr_WORK_SHIFT_1_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.WORK_SHIFT_2_W: PointAttr.initAttr_WORK_SHIFT_2_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.WORK_SHIFT_3_W: PointAttr.initAttr_WORK_SHIFT_3_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.WORK_SHIFT_W: PointAttr.initAttr_WORK_SHIFT_W(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.RT00000_R: PointAttr.initAttr_RT00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.HC00000_R: PointAttr.initAttr_HC00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BD00001_R: PointAttr.initAttr_BD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BD00002_R: PointAttr.initAttr_BD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BD00003_R: PointAttr.initAttr_BD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.SD00001_R: PointAttr.initAttr_SD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.SD00002_R: PointAttr.initAttr_SD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.SD00003_R: PointAttr.initAttr_SD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MD00001_R: PointAttr.initAttr_MD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MD00002_R: PointAttr.initAttr_MD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MD00003_R: PointAttr.initAttr_MD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PD00001_R: PointAttr.initAttr_PD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PD00002_R: PointAttr.initAttr_PD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PD00003_R: PointAttr.initAttr_PD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ED00001_R: PointAttr.initAttr_ED00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ED00002_R: PointAttr.initAttr_ED00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ED00003_R: PointAttr.initAttr_ED00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.AD00001_R: PointAttr.initAttr_AD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.AD00002_R: PointAttr.initAttr_AD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.AD00003_R: PointAttr.initAttr_AD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OD00001_R: PointAttr.initAttr_OD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OD00002_R: PointAttr.initAttr_OD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OD00003_R: PointAttr.initAttr_OD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CD00001_R: PointAttr.initAttr_CD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CD00002_R: PointAttr.initAttr_CD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CD00003_R: PointAttr.initAttr_CD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FD00001_R: PointAttr.initAttr_FD00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FD00002_R: PointAttr.initAttr_FD00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FD00003_R: PointAttr.initAttr_FD00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BTRIGER_R: PointAttr.initAttr_BTRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.STRIGER_R: PointAttr.initAttr_STRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MTRIGER_R: PointAttr.initAttr_MTRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PTRIGER_R: PointAttr.initAttr_PTRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ETRIGER_R: PointAttr.initAttr_ETRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ATRIGER_R: PointAttr.initAttr_ATRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OTRIGER_R: PointAttr.initAttr_OTRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CTRIGER_R: PointAttr.initAttr_CTRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FTRIGER_R: PointAttr.initAttr_FTRIGER_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ACOUNT__R: PointAttr.initAttr_ACOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BCOUNT__R: PointAttr.initAttr_BCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CCOUNT__R: PointAttr.initAttr_CCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ECOUNT__R: PointAttr.initAttr_ECOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FCOUNT__R: PointAttr.initAttr_FCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MCOUNT__R: PointAttr.initAttr_MCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OCOUNT__R: PointAttr.initAttr_OCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCOUNT__R: PointAttr.initAttr_PCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.SCOUNT__R: PointAttr.initAttr_SCOUNT__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ATRIGER_V: PointAttr.initAttr_ATRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BTRIGER_V: PointAttr.initAttr_BTRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CTRIGER_V: PointAttr.initAttr_CTRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ETRIGER_V: PointAttr.initAttr_ETRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FTRIGER_V: PointAttr.initAttr_FTRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MTRIGER_V: PointAttr.initAttr_MTRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OTRIGER_V: PointAttr.initAttr_OTRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PTRIGER_V: PointAttr.initAttr_PTRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.STRIGER_V: PointAttr.initAttr_STRIGER_V(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CLS_SHIFT_R: PointAttr.initAttr_CLS_SHIFT_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCA0001_R: PointAttr.initAttr_PCA0001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCA0002_R: PointAttr.initAttr_PCA0002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCA0003_R: PointAttr.initAttr_PCA0003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCB0001_R: PointAttr.initAttr_PCB0001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCB0002_R: PointAttr.initAttr_PCB0002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCB0003_R: PointAttr.initAttr_PCB0003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCC0001_R: PointAttr.initAttr_PCC0001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCC0002_R: PointAttr.initAttr_PCC0002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCC0003_R: PointAttr.initAttr_PCC0003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCD0001_R: PointAttr.initAttr_PCD0001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCD0002_R: PointAttr.initAttr_PCD0002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCD0003_R: PointAttr.initAttr_PCD0003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BC00001_R: PointAttr.initAttr_BC00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BC00002_R: PointAttr.initAttr_BC00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BC00003_R: PointAttr.initAttr_BC00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BC00004_R: PointAttr.initAttr_BC00004_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.AD00000_R: PointAttr.initAttr_AD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.BD00000_R: PointAttr.initAttr_BD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.CD00000_R: PointAttr.initAttr_CD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.ED00000_R: PointAttr.initAttr_ED00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FD00000_R: PointAttr.initAttr_FD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MD00000_R: PointAttr.initAttr_MD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.OD00000_R: PointAttr.initAttr_OD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PD00000_R: PointAttr.initAttr_PD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.SD00000_R: PointAttr.initAttr_SD00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCA0000_R: PointAttr.initAttr_PCA0000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCB0000_R: PointAttr.initAttr_PCB0000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCC0000_R: PointAttr.initAttr_PCC0000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PCD0000_R: PointAttr.initAttr_PCD0000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.FDMIN00_R: PointAttr.initAttr_FDMIN00_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MTTR: PointAttr.initAttr_MTTR(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.MCBF: PointAttr.initAttr_MCBF(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PC00001_R: PointAttr.initAttr_PC00001_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PC00002_R: PointAttr.initAttr_PC00002_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PC00003_R: PointAttr.initAttr_PC00003_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.PC00000_R: PointAttr.initAttr_PC00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;

                    case PointConstant.TIP_RDY_CYCLETIME: PointAttr.initAttr_TIP_RDY_CYCLETIME(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_BLOCK: PointAttr.initAttr_TIP_FLT_BLOCK(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_STARVE: PointAttr.initAttr_TIP_FLT_STARVE(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_MACHINE: PointAttr.initAttr_TIP_FLT_MACHINE(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_PSTOP: PointAttr.initAttr_TIP_FLT_PSTOP(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_ESTOP: PointAttr.initAttr_TIP_FLT_ESTOP(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_ANDON: PointAttr.initAttr_TIP_FLT_ANDON(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_OTHER: PointAttr.initAttr_TIP_FLT_OTHER(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_OVERCYCLE: PointAttr.initAttr_TIP_FLT_OVERCYCLE(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_FLT_ALL: PointAttr.initAttr_TIP_FLT_ALL(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_VAL_CYCLETIME: PointAttr.initAttr_TIP_VAL_CYCLETIME(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_VAL_PC00001: PointAttr.initAttr_TIP_VAL_PC00001(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_VAL_PC00002: PointAttr.initAttr_TIP_VAL_PC00002(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_VAL_PC00003: PointAttr.initAttr_TIP_VAL_PC00003(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_VAL_CT: PointAttr.initAttr_TIP_VAL_CT(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TAKEON__R: PointAttr.initAttr_TAKEON__R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.VM00000_R: PointAttr.initAttr_VM00000_R(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    case PointConstant.TIP_VAL_CURRENT_CYCLETIME: PointAttr.initAttr_TIP_VAL_CURRENT_CYCLETIME(rowAttr, stationName, stationNo, pointName, resourceId, deviceId); break;
                    default:
                        break;
                }
            }
            catch (Exception e)
            {
                throw new MyException(e.ToString());
            }

        }

    }
}
