using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace PMCPointTool
{
    abstract class BasePoint
    {

        /// <summary>
        /// CSV对象
        /// </summary>
        protected CSV mCSV = new CSV();

        /// <summary>
        /// 一般点名集合
        /// </summary>
        protected List<string> pointNames = new List<string>();

        /// <summary>
        /// 特殊点名集合
        /// </summary>
        protected List<string> spectialPointNames = new List<string>();

        /// <summary>
        /// 所有点名
        /// </summary>
        protected List<string> allPointNames = new List<string>();

        /// <summary>
        /// 点属性值集合
        /// </summary>
        protected List<Dictionary<string, PointAttr>> csvRowAttrs = new List<Dictionary<string, PointAttr>>();

        /// <summary>
        /// 界面控制器
        /// </summary>
        protected MainController mainController;

        protected MainFormOperation mainFormOperation;

        protected InterfaceEnum interfaceType;

        public CSV CSV
        {
            get { return mCSV; }
            set { mCSV = value; }
        }

        public BasePoint(MainController _mainController, MainFormOperation _mainFormOperation)
        {
            this.mainController = _mainController;
            this.mainFormOperation = _mainFormOperation;

            initPointNames();
        }

        public BasePoint(MainController _mainController, MainFormOperation _mainFormOperation, InterfaceEnum _interfaceType)
            : this(_mainController, _mainFormOperation)
        {
            this.interfaceType = _interfaceType;
        }


        private void startProgressBar(List<Area> areas)
        {
            //计算进度条刻度
            int maxValue = -1;
            for (int i = 0; i < areas.Count; i++)
            {
                List<PLC> plcs = areas[i].Plcs;
                for (int j = 0; j < plcs.Count; j++)
                {
                    List<Station> stations = plcs[j].Stations;
                    for (int k = 0; k < stations.Count; k++)
                    {
                        maxValue += 1;
                    }
                }
            }
            if (maxValue > int.MaxValue)
                maxValue = int.MaxValue;
            this.mainController.startProgressBar(maxValue);
        }

        /// <summary>
        /// 初始化点属性
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="stationNo"></param>
        /// <param name="resourceId"></param>
        /// <param name="deviceId"></param>
        private void initPointAttrs(string stationName, int stationNo, string resourceId, string deviceId)
        {
            if (this.pointNames.Count <= 0) return;

            this.allPointNames = this.pointNames;

            if (this.spectialPointNames.Count > 0)
                this.allPointNames.AddRange(this.spectialPointNames);

            for (int i = 0; i < this.allPointNames.Count; i++)
            {
                Dictionary<string, PointAttr> dictionary = new Dictionary<string, PointAttr>();
                PointAttr rowAttr = new PointAttr(this.mainFormOperation, this.interfaceType);

                initPointAttr(this.allPointNames[i], rowAttr, stationName, stationNo, resourceId, deviceId);

                dictionary.Add(stationName + this.allPointNames[i], rowAttr);
                this.csvRowAttrs.Add(dictionary);
            }
        }

        /// <summary>
        /// 生成工位点
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="stationNo"></param>
        /// <param name="resourceId"></param>
        /// <param name="deviceId"></param>
        private void generateStationInfoData(string stationName, int stationNo, string resourceId, string deviceId)
        {
            InterfaceFactory.getInstance(this.mainFormOperation,interfaceType).checkStationInfo(stationName, stationNo, resourceId, deviceId);

            for (int i = 0; i < this.pointNames.Count; i++)
            {
                Dictionary<string, PointAttr> dictionary = this.csvRowAttrs[i];
                List<PointAttr> csvRowAttrList = dictionary.Values.ToList();
                PointAttr csvRowAttr = csvRowAttrList[0];

                List<CSVCell> rows = new List<CSVCell>();

                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_id, csvRowAttr.Pt_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Access, csvRowAttr.Access));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Access_filter, csvRowAttr.Access_filter));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_hi, csvRowAttr.Ack_timeout_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_hihi, csvRowAttr.Ack_timeout_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_lo, csvRowAttr.Ack_timeout_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_lolo, csvRowAttr.Ack_timeout_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Addr, csvRowAttr.Addr));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Addr_offset, csvRowAttr.Addr_offset));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Addr_type, csvRowAttr.Addr_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_changeapproval, csvRowAttr.Alarm_changeapproval));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_hi, csvRowAttr.Alarm_delay_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_hihi, csvRowAttr.Alarm_delay_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_lo, csvRowAttr.Alarm_delay_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_lolo, csvRowAttr.Alarm_delay_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_hi, csvRowAttr.Alarm_delay_unit_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_hihi, csvRowAttr.Alarm_delay_unit_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_lo, csvRowAttr.Alarm_delay_unit_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_lolo, csvRowAttr.Alarm_delay_unit_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_publish, csvRowAttr.Alarm_publish));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_class, csvRowAttr.Alm_class));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_criteria, csvRowAttr.Alm_criteria));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_deadband, csvRowAttr.Alm_deadband));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_delay, csvRowAttr.Alm_delay));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_enable, csvRowAttr.Alm_enable));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_high_1, csvRowAttr.Alm_high_1));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_high_2, csvRowAttr.Alm_high_2));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_hlp_file, csvRowAttr.Alm_hlp_file));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_low_1, csvRowAttr.Alm_low_1));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_low_2, csvRowAttr.Alm_low_2));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_msg, csvRowAttr.Alm_msg));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_route_oper, csvRowAttr.Alm_route_oper));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_route_sysmgr, csvRowAttr.Alm_route_sysmgr));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_route_user, csvRowAttr.Alm_route_user));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_severity, csvRowAttr.Alm_severity));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_str, csvRowAttr.Alm_str));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_type, csvRowAttr.Alm_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_update_value, csvRowAttr.Alm_update_value));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Analog_deadband, csvRowAttr.Analog_deadband));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_count, csvRowAttr.Bfr_count));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_dur, csvRowAttr.Bfr_dur));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_period, csvRowAttr.Bfr_event_period));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_pt_id, csvRowAttr.Bfr_event_pt_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_type, csvRowAttr.Bfr_event_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_units, csvRowAttr.Bfr_event_units));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_gate_cond, csvRowAttr.Bfr_gate_cond));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_sync_time, csvRowAttr.Bfr_sync_time));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Calc_type, csvRowAttr.Calc_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Changeapproval, csvRowAttr.Changeapproval));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Conv_lim_high, csvRowAttr.Conv_lim_high));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Conv_lim_low, csvRowAttr.Conv_lim_low));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Conv_type, csvRowAttr.Conv_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delay_load, csvRowAttr.Delay_load));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_hi, csvRowAttr.Delete_req_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_hihi, csvRowAttr.Delete_req_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_lo, csvRowAttr.Delete_req_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_lolo, csvRowAttr.Delete_req_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Desc, csvRowAttr.Desc));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Deviation_pt, csvRowAttr.Deviation_pt));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Device_id, csvRowAttr.Device_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_lim_high, csvRowAttr.Disp_lim_high));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_lim_low, csvRowAttr.Disp_lim_low));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_type, csvRowAttr.Disp_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_width, csvRowAttr.Disp_width));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Elements, csvRowAttr.Elements));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Eng_units, csvRowAttr.Eng_units));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Enum_id, csvRowAttr.Enum_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Equation, csvRowAttr.Equation));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Extra, csvRowAttr.Extra));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Fw_conv_eq, csvRowAttr.Fw_conv_eq));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Gr_screen, csvRowAttr.Gr_screen));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Init_val, csvRowAttr.Init_val));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Justification, csvRowAttr.Justification));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Level, csvRowAttr.Level));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Local, csvRowAttr.Local));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_hi, csvRowAttr.Log_ack_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_hihi, csvRowAttr.Log_ack_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_lo, csvRowAttr.Log_ack_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_lolo, csvRowAttr.Log_ack_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_data, csvRowAttr.Log_data));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_hi, csvRowAttr.Log_del_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_hihi, csvRowAttr.Log_del_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_lo, csvRowAttr.Log_del_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_lolo, csvRowAttr.Log_del_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_hi, csvRowAttr.Log_gen_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_hihi, csvRowAttr.Log_gen_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_lo, csvRowAttr.Log_gen_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_lolo, csvRowAttr.Log_gen_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_hi, csvRowAttr.Log_reset_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_hihi, csvRowAttr.Log_reset_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_lo, csvRowAttr.Log_reset_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_lolo, csvRowAttr.Log_reset_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Max_stacked, csvRowAttr.Max_stacked));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Measurement_unit_id, csvRowAttr.Measurement_unit_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Misc_flags, csvRowAttr.Misc_flags));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Poll_after_set, csvRowAttr.Poll_after_set));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Precision, csvRowAttr.Precision));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Proc_id, csvRowAttr.Proc_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ptmgmt_proc_id, csvRowAttr.Ptmgmt_proc_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_enabled, csvRowAttr.Pt_enabled));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_origin, csvRowAttr.Pt_origin));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_set_interval, csvRowAttr.Pt_set_interval));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_set_time, csvRowAttr.Pt_set_time));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_type, csvRowAttr.Pt_type));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Range_high, csvRowAttr.Range_high));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Range_low, csvRowAttr.Range_low));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Raw_lim_high, csvRowAttr.Raw_lim_high));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Raw_lim_low, csvRowAttr.Raw_lim_low));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_hi, csvRowAttr.Rep_timeout_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_hihi, csvRowAttr.Rep_timeout_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_lo, csvRowAttr.Rep_timeout_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_lolo, csvRowAttr.Rep_timeout_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_hi, csvRowAttr.Reset_allowed_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_hihi, csvRowAttr.Reset_allowed_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_lo, csvRowAttr.Reset_allowed_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_lolo, csvRowAttr.Reset_allowed_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_cond, csvRowAttr.Reset_cond));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_pt, csvRowAttr.Reset_pt));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_hi, csvRowAttr.Reset_timeout_hi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_hihi, csvRowAttr.Reset_timeout_hihi));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_lo, csvRowAttr.Reset_timeout_lo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_lolo, csvRowAttr.Reset_timeout_lolo));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Resource_id, csvRowAttr.Resource_id));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rev_conv_eq, csvRowAttr.Rev_conv_eq));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rollover_val, csvRowAttr.Rollover_val));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Safety_pt, csvRowAttr.Safety_pt));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Sample_intv, csvRowAttr.Sample_intv));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Sample_intv_unit, csvRowAttr.Sample_intv_unit));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Scan_rate, csvRowAttr.Scan_rate));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Setpoint_high, csvRowAttr.Setpoint_high));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Setpoint_low, csvRowAttr.Setpoint_low));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Time_of_day, csvRowAttr.Time_of_day));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_ck_pt, csvRowAttr.Trig_ck_pt));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_pt, csvRowAttr.Trig_pt));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_rel, csvRowAttr.Trig_rel));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_val, csvRowAttr.Trig_val));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Uafset, csvRowAttr.Uafset));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Update_criteria, csvRowAttr.Update_criteria));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Variance_val, csvRowAttr.Variance_val));
                rows.Add(generateCSVCell(mCSV.PointAttrFiled.Vars, csvRowAttr.Vars));

                this.mCSV.createRow(rows);
            }

            csvRowAttrs.Clear();

        }

        #region 公有函数

        /// <summary>
        /// 获取根据配置文件生成的数据表
        /// </summary>
        /// <param name="areas"></param>
        /// <returns></returns>
        public virtual DataTable generateCSVData(List<Area> areas)
        {
            try
            {
                int progressValue = 0;
                startProgressBar(areas);

                for (int i = 0; i < areas.Count; i++)
                {
                    List<PLC> plcs = areas[i].Plcs;
                    for (int j = 0; j < plcs.Count; j++)
                    {
                        string deviceId = plcs[j].DeviceId;
                        bool isFilter = plcs[j].IsFilter;
                        List<Station> stations = plcs[j].Stations;
                        if (isFilter)
                            break;
                        for (int k = 0; k < stations.Count; k++)
                        {
                            string stationName = stations[k].Name;
                            int stationNo = stations[k].Number;

                            string resourceId = stations[k].ResourceId;
                            bool isFilterStation = stations[k].IsFilter;
                            bool isProdStation = stations[k].IsProdStation;

                            if (isFilterStation)
                                break;

                            List<AlarmDetail> alarmDetails = stations[k].AlarmDetails;

                            //产量点类型
                            if (this.GetType() == typeof(ProdStationPoint))
                            {
                                if (!isProdStation)
                                    continue;
                            }
                            //非产量点类型
                            else if (this.GetType() == typeof(NotProdStationPoint))
                            {
                                if (isProdStation)
                                    continue;
                            }

                            initSpecialPointName(stationNo);

                            initPointAttrs(stationName, stationNo, resourceId, deviceId);

                            generateStationInfoData(stationName, stationNo, resourceId, deviceId);

                            for (int l = 0; l < alarmDetails.Count; l++)
                            {
                                int alarmNumber = alarmDetails[l].Number;
                                string alarmDetail = alarmDetails[l].Detail;

                                generateAlarmInfoData(stationName, stationNo, resourceId, deviceId, alarmNumber, alarmDetail);
                            }

                            clearSpecialPointName();

                            this.mainController.reportProcess(progressValue++, "读取信息加入内存中... ");
                        }
                    }
                }
                this.mainController.stopProgressBar();
            }
            catch (Exception e)
            {
                OtherUtils.writeMsgByByte(Constant.LOG_PATH, e.ToString());
                mCSV.Dt = null;
            }
            return mCSV.Dt;
        }

        private void clearSpecialPointName()
        {
            if (this.spectialPointNames.Count > 0)
            {
                for (int i = 0; i < this.spectialPointNames.Count; i++)
                {
                    this.allPointNames.Remove(this.spectialPointNames[i]);
                }
                this.spectialPointNames.Clear();
            }
        }

        /// <summary>
        /// 生成报警点
        /// </summary>
        /// <param name="stationName"></param>
        /// <param name="stationNo"></param>
        /// <param name="resourceId"></param>
        /// <param name="deviceId"></param>
        /// <param name="alarmNumber"></param>
        /// <param name="alarmDetail"></param>
        public virtual void generateAlarmInfoData(string stationName, int stationNo, string resourceId, string deviceId, int alarmNumber = -1, string alarmDetail = "")
        {
        }

        /// <summary>
        /// 初始化点名
        /// </summary>
        public abstract void initPointNames();

        /// <summary>
        /// 初始化点属性
        /// </summary>
        /// <param name="pointName"></param>
        /// <param name="rowAttr"></param>
        /// <param name="stationName"></param>
        /// <param name="stationNo"></param>
        /// <param name="resourceId"></param>
        /// <param name="deviceId"></param>
        public abstract void initPointAttr(string pointName, PointAttr rowAttr, string stationName, int stationNo, string resourceId, string deviceId);

        /// <summary>
        /// 加载特殊工位的点
        /// </summary>
        public virtual void initSpecialPointName(int stationNo) { }

        /// <summary>
        /// 设置CSV单元格数据
        /// </summary>
        /// <param name="filed"></param>
        /// <param name="val"></param>
        /// <returns></returns>
        public CSVCell generateCSVCell(string filed, string val)
        {
            CSVCell cell = new CSVCell();
            cell.Filed = filed;
            cell.Val = val;
            return cell;
        }

        #endregion

    }
}
