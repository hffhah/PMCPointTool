using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PMCPointTool
{
    class AlarmPoint : BasePoint
    {
        BaseInterface pmcInterface;

        public AlarmPoint(MainController _mainController, MainFormOperation _mainFormOperation,InterfaceEnum _interface)
            : base(_mainController, _mainFormOperation)
        {
            pmcInterface = InterfaceFactory.getInstance(_mainFormOperation,this.interfaceType);
        }

        public override void generateAlarmInfoData(string stationName, int stationNo, string resourceId, string deviceId, int alarmNumber = -1, string alarmDetail = "")
        {
            pmcInterface.checkStationInfo(stationName, stationNo, resourceId, deviceId, alarmNumber, alarmDetail);

            List<CSVCell> rows = new List<CSVCell>();

            //TODO AB和SIMENS不同
            //0000,00 --> part1,part2 
            int overNumber_int = (alarmNumber - 1) / 16;
            int overNumber_decimal = (alarmNumber - 1) % 16;
            double bandAddress = Math.Pow(2, overNumber_decimal);

            //point name :UR___CEUR040__MF000500R
            string part1 = (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_AlarmDetail) + overNumber_int).ToString("0000");
            string part2 = overNumber_decimal.ToString("00");
            string pointName = stationName + "_MF" + part1 + part2 + "R";

            //point address :UR___CEUR040__ALLDATA_R[0] BAND 1
            string pointEquation = stationName + "_ALLDATA_R[" + overNumber_int + "] BAND " + bandAddress;
            string alarmClass = "MF";

            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_id, pointName));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Access, "R"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Access_filter, "E"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_hi, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_hihi, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_lo, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ack_timeout_lolo, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Addr, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Addr_offset, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Addr_type, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_changeapproval, "NONE"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_hi, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_hihi, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_lo, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_lolo, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_hi, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_hihi, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_lo, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_delay_unit_lolo, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alarm_publish, "N"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_class, alarmClass));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_criteria, "ABS"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_deadband, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_delay, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_enable, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_high_1, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_high_2, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_hlp_file, "\\" + pointName));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_low_1, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_low_2, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_msg, alarmDetail));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_route_oper, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_route_sysmgr, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_route_user, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_severity, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_str, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_type, "AL"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Alm_update_value, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Analog_deadband, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_count, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_dur, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_period, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_pt_id, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_type, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_event_units, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_gate_cond, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Bfr_sync_time, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Calc_type, "EQU"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Changeapproval, "NONE"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Conv_lim_high, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Conv_lim_low, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Conv_type, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delay_load, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_hi, "AR"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_hihi, "AR"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_lo, "AR"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Delete_req_lolo, "AR"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Desc, alarmDetail));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Deviation_pt, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Device_id, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_lim_high, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_lim_low, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_type, "d"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Disp_width, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Elements, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Eng_units, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Enum_id, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Equation, pointEquation));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Extra, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Fw_conv_eq, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Gr_screen, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Init_val, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Justification, "LEFT"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Level, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Local, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_hi, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_hihi, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_lo, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_ack_lolo, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_data, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_hi, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_hihi, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_lo, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_del_lolo, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_hi, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_hihi, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_lo, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_gen_lolo, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_hi, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_hihi, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_lo, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Log_reset_lolo, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Max_stacked, "5"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Measurement_unit_id, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Misc_flags, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Poll_after_set, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Precision, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Proc_id, "MASTER_PTDP_RP"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Ptmgmt_proc_id, "MASTER_PTM0_RP"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_enabled, "1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_origin, "R"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_set_interval, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_set_time, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Pt_type, "BOOL"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Range_high, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Range_low, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Raw_lim_high, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Raw_lim_low, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_hi, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_hihi, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_lo, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rep_timeout_lolo, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_hi, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_hihi, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_lo, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_allowed_lolo, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_cond, "IN"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_pt, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_hi, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_hihi, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_lo, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Reset_timeout_lolo, "-1"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Resource_id, resourceId));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rev_conv_eq, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Rollover_val, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Safety_pt, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Sample_intv, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Sample_intv_unit, "SEC"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Scan_rate, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Setpoint_high, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Setpoint_low, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Time_of_day, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_ck_pt, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_pt, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_rel, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Trig_val, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Uafset, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Update_criteria, ""));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Variance_val, "0"));
            rows.Add(generateCSVCell(mCSV.PointAttrFiled.Vars, "1"));

            this.mCSV.createRow(rows);
        }

        public override void initPointNames()
        {
            this.pointNames.Add(PointConstant.ALLDATA_R);
        }

        public override void initPointAttr(string pointName, PointAttr rowAttr, string stationName, int stationNo, string resourceId, string deviceId)
        {
            switch (pointName)
            {
                case PointConstant.ALLDATA_R:
                    PointAttr.initAttr_ALLDATA(rowAttr, stationName, stationNo, pointName, resourceId, deviceId);
                    break;
                default:
                    break;
            }
        }
    }
}
