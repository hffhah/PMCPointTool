using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PMCPointTool
{
    /// <summary>
    /// 点属性类
    /// </summary>
    public class PointAttr : PointAttrFiled
    {
        private static BaseInterface pmcInterface = null;
        private static InterfaceEnum mInterfaceType;

        /// <summary>
        /// 初始化一行点属性(以MF00000_R为模板)
        /// 140列属性
        /// e.g.
        ///     MC___CEMC10CE_MF00000_R,R,E,,,,,PMC_Array_Alarm[1].1,0,FQ,NONE,0,0,0,0,,,,,,,,,0,,,,,,,,,,,0,1,,0,0,0,0,0,,1,0,0,0,,NONE,,,NO,0,,,,,,,W103_MC___AB_MC010__0007,,,d,,1,,,,0,,,,LEFT,0,,,,,,0,,,,,,,,,,,,,,,0,0,,,,1,D,,,BOOL,1,0,,,,,,,,,,,,,,,,,MC___TLMC010_R,,,,0,,1,,,,,,NO,,,OC,,1
        /// </summary>
        /// <param name="rowAttr">行属性对象</param>
        /// <param name="pointName">点名</param>
        /// <param name="resourceId">资源名</param>
        /// <param name="pointAttrs">要修改的属性集合</param>
        public static void initCommAttr(PointAttr rowAttr, string pointName, string resourceId, Dictionary<string, string> pointAttrs)
        {
            //建点必备
            rowAttr.Pt_id = pointName;
            rowAttr.Resource_id = resourceId;

            if (pointAttrs.ContainsKey(rowAttr.Access))
                rowAttr.Access = pointAttrs[rowAttr.Access];
            else
                rowAttr.Access = "R";

            if (pointAttrs.ContainsKey(rowAttr.Access_filter))
                rowAttr.Access_filter = pointAttrs[rowAttr.Access_filter];
            else
                rowAttr.Access_filter = "E";

            if (pointAttrs.ContainsKey(rowAttr.Ack_timeout_hi))
                rowAttr.Ack_timeout_hi = pointAttrs[rowAttr.Ack_timeout_hi];
            else
                rowAttr.Ack_timeout_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Ack_timeout_hihi))
                rowAttr.Ack_timeout_hihi = pointAttrs[rowAttr.Ack_timeout_hihi];
            else
                rowAttr.Ack_timeout_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Ack_timeout_lo))
                rowAttr.Ack_timeout_lo = pointAttrs[rowAttr.Ack_timeout_lo];
            else
                rowAttr.Ack_timeout_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Ack_timeout_lolo))
                rowAttr.Ack_timeout_lolo = pointAttrs[rowAttr.Ack_timeout_lolo];
            else
                rowAttr.Ack_timeout_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Addr))
                rowAttr.Addr = pointAttrs[rowAttr.Addr];
            else
                rowAttr.Addr = "";

            if (pointAttrs.ContainsKey(rowAttr.Addr_offset))
                rowAttr.Addr_offset = pointAttrs[rowAttr.Addr_offset];
            else
                rowAttr.Addr_offset = "0";

            if (pointAttrs.ContainsKey(rowAttr.Addr_type))
                rowAttr.Addr_type = pointAttrs[rowAttr.Addr_type];
            else
                rowAttr.Addr_type = "FQ";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_changeapproval))
                rowAttr.Alarm_changeapproval = pointAttrs[rowAttr.Alarm_changeapproval];
            else
                rowAttr.Alarm_changeapproval = "NONE";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_hi))
                rowAttr.Alarm_delay_hi = pointAttrs[rowAttr.Alarm_delay_hi];
            else
                rowAttr.Alarm_delay_hi = "0";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_hihi))
                rowAttr.Alarm_delay_hihi = pointAttrs[rowAttr.Alarm_delay_hihi];
            else
                rowAttr.Alarm_delay_hihi = "0";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_lo))
                rowAttr.Alarm_delay_lo = pointAttrs[rowAttr.Alarm_delay_lo];
            else
                rowAttr.Alarm_delay_lo = "0";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_lolo))
                rowAttr.Alarm_delay_lolo = pointAttrs[rowAttr.Alarm_delay_lolo];
            else
                rowAttr.Alarm_delay_lolo = "0";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_unit_hi))
                rowAttr.Alarm_delay_unit_hi = pointAttrs[rowAttr.Alarm_delay_unit_hi];
            else
                rowAttr.Alarm_delay_unit_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_unit_hihi))
                rowAttr.Alarm_delay_unit_hihi = pointAttrs[rowAttr.Alarm_delay_unit_hihi];
            else
                rowAttr.Alarm_delay_unit_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_unit_lo))
                rowAttr.Alarm_delay_unit_lo = pointAttrs[rowAttr.Alarm_delay_unit_lo];
            else
                rowAttr.Alarm_delay_unit_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_delay_unit_lolo))
                rowAttr.Alarm_delay_unit_lolo = pointAttrs[rowAttr.Alarm_delay_unit_lolo];
            else
                rowAttr.Alarm_delay_unit_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Alarm_publish))
                rowAttr.Alarm_publish = pointAttrs[rowAttr.Alarm_publish];
            else
                rowAttr.Alarm_publish = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_class))
                rowAttr.Alm_class = pointAttrs[rowAttr.Alm_class];
            else
                rowAttr.Alm_class = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_criteria))
                rowAttr.Alm_criteria = pointAttrs[rowAttr.Alm_criteria];
            else
                rowAttr.Alm_criteria = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_deadband))
                rowAttr.Alm_deadband = pointAttrs[rowAttr.Alm_deadband];
            else
                rowAttr.Alm_deadband = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_delay))
                rowAttr.Alm_delay = pointAttrs[rowAttr.Alm_delay];
            else
                rowAttr.Alm_delay = "0";

            if (pointAttrs.ContainsKey(rowAttr.Alm_enable))
                rowAttr.Alm_enable = pointAttrs[rowAttr.Alm_enable];
            else
                rowAttr.Alm_enable = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_high_1))
                rowAttr.Alm_high_1 = pointAttrs[rowAttr.Alm_high_1];
            else
                rowAttr.Alm_high_1 = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_high_2))
                rowAttr.Alm_high_2 = pointAttrs[rowAttr.Alm_high_2];
            else
                rowAttr.Alm_high_2 = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_hlp_file))
                rowAttr.Alm_hlp_file = pointAttrs[rowAttr.Alm_hlp_file];
            else
                rowAttr.Alm_hlp_file = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_low_1))
                rowAttr.Alm_low_1 = pointAttrs[rowAttr.Alm_low_1];
            else
                rowAttr.Alm_low_1 = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_low_2))
                rowAttr.Alm_low_2 = pointAttrs[rowAttr.Alm_low_2];
            else
                rowAttr.Alm_low_2 = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_msg))
                rowAttr.Alm_msg = pointAttrs[rowAttr.Alm_msg];
            else
                rowAttr.Alm_msg = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_route_oper))
                rowAttr.Alm_route_oper = pointAttrs[rowAttr.Alm_route_oper];
            else
                rowAttr.Alm_route_oper = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_route_sysmgr))
                rowAttr.Alm_route_sysmgr = pointAttrs[rowAttr.Alm_route_sysmgr];
            else
                rowAttr.Alm_route_sysmgr = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_route_user))
                rowAttr.Alm_route_user = pointAttrs[rowAttr.Alm_route_user];
            else
                rowAttr.Alm_route_user = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_severity))
                rowAttr.Alm_severity = pointAttrs[rowAttr.Alm_severity];
            else
                rowAttr.Alm_severity = "0";

            if (pointAttrs.ContainsKey(rowAttr.Alm_str))
                rowAttr.Alm_str = pointAttrs[rowAttr.Alm_str];
            else
                rowAttr.Alm_str = "1";

            if (pointAttrs.ContainsKey(rowAttr.Alm_type))
                rowAttr.Alm_type = pointAttrs[rowAttr.Alm_type];
            else
                rowAttr.Alm_type = "";

            if (pointAttrs.ContainsKey(rowAttr.Alm_update_value))
                rowAttr.Alm_update_value = pointAttrs[rowAttr.Alm_update_value];
            else
                rowAttr.Alm_update_value = "0";

            if (pointAttrs.ContainsKey(rowAttr.Analog_deadband))
                rowAttr.Analog_deadband = pointAttrs[rowAttr.Analog_deadband];
            else
                rowAttr.Analog_deadband = "0";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_count))
                rowAttr.Bfr_count = pointAttrs[rowAttr.Bfr_count];
            else
                rowAttr.Bfr_count = "0";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_dur))
                rowAttr.Bfr_dur = pointAttrs[rowAttr.Bfr_dur];
            else
                rowAttr.Bfr_dur = "0";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_event_period))
                rowAttr.Bfr_event_period = pointAttrs[rowAttr.Bfr_event_period];
            else
                rowAttr.Bfr_event_period = "0";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_event_pt_id))
                rowAttr.Bfr_event_pt_id = pointAttrs[rowAttr.Bfr_event_pt_id];
            else
                rowAttr.Bfr_event_pt_id = "";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_event_type))
                rowAttr.Bfr_event_type = pointAttrs[rowAttr.Bfr_event_type];
            else
                rowAttr.Bfr_event_type = "1";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_event_units))
                rowAttr.Bfr_event_units = pointAttrs[rowAttr.Bfr_event_units];
            else
                rowAttr.Bfr_event_units = "0";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_gate_cond))
                rowAttr.Bfr_gate_cond = pointAttrs[rowAttr.Bfr_gate_cond];
            else
                rowAttr.Bfr_gate_cond = "0";

            if (pointAttrs.ContainsKey(rowAttr.Bfr_sync_time))
                rowAttr.Bfr_sync_time = pointAttrs[rowAttr.Bfr_sync_time];
            else
                rowAttr.Bfr_sync_time = "0";

            if (pointAttrs.ContainsKey(rowAttr.Calc_type))
                rowAttr.Calc_type = pointAttrs[rowAttr.Calc_type];
            else
                rowAttr.Calc_type = "";

            if (pointAttrs.ContainsKey(rowAttr.Changeapproval))
                rowAttr.Changeapproval = pointAttrs[rowAttr.Changeapproval];
            else
                rowAttr.Changeapproval = "NONE";

            if (pointAttrs.ContainsKey(rowAttr.Conv_lim_high))
                rowAttr.Conv_lim_high = pointAttrs[rowAttr.Conv_lim_high];
            else
                rowAttr.Conv_lim_high = "";

            if (pointAttrs.ContainsKey(rowAttr.Conv_lim_low))
                rowAttr.Conv_lim_low = pointAttrs[rowAttr.Conv_lim_low];
            else
                rowAttr.Conv_lim_low = "";

            if (pointAttrs.ContainsKey(rowAttr.Conv_type))
                rowAttr.Conv_type = pointAttrs[rowAttr.Conv_type];
            else
                rowAttr.Conv_type = "NO";

            if (pointAttrs.ContainsKey(rowAttr.Delay_load))
                rowAttr.Delay_load = pointAttrs[rowAttr.Delay_load];
            else
                rowAttr.Delay_load = "0";

            if (pointAttrs.ContainsKey(rowAttr.Delete_req_hi))
                rowAttr.Delete_req_hi = pointAttrs[rowAttr.Delete_req_hi];
            else
                rowAttr.Delete_req_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Delete_req_hihi))
                rowAttr.Delete_req_hihi = pointAttrs[rowAttr.Delete_req_hihi];
            else
                rowAttr.Delete_req_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Delete_req_lo))
                rowAttr.Delete_req_lo = pointAttrs[rowAttr.Delete_req_lo];
            else
                rowAttr.Delete_req_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Delete_req_lolo))
                rowAttr.Delete_req_lolo = pointAttrs[rowAttr.Delete_req_lolo];
            else
                rowAttr.Delete_req_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Desc))
                rowAttr.Desc = pointAttrs[rowAttr.Desc];
            else
                rowAttr.Desc = "";

            if (pointAttrs.ContainsKey(rowAttr.Deviation_pt))
                rowAttr.Deviation_pt = pointAttrs[rowAttr.Deviation_pt];
            else
                rowAttr.Deviation_pt = "";

            if (pointAttrs.ContainsKey(rowAttr.Device_id))
                rowAttr.Device_id = pointAttrs[rowAttr.Device_id];
            else
                rowAttr.Device_id = "";

            if (pointAttrs.ContainsKey(rowAttr.Disp_lim_high))
                rowAttr.Disp_lim_high = pointAttrs[rowAttr.Disp_lim_high];
            else
                rowAttr.Disp_lim_high = "";

            if (pointAttrs.ContainsKey(rowAttr.Disp_lim_low))
                rowAttr.Disp_lim_low = pointAttrs[rowAttr.Disp_lim_low];
            else
                rowAttr.Disp_lim_low = "";

            if (pointAttrs.ContainsKey(rowAttr.Disp_type))
                rowAttr.Disp_type = pointAttrs[rowAttr.Disp_type];
            else
                rowAttr.Disp_type = "d";

            if (pointAttrs.ContainsKey(rowAttr.Disp_width))
                rowAttr.Disp_width = pointAttrs[rowAttr.Disp_width];
            else
                rowAttr.Disp_width = "";

            if (pointAttrs.ContainsKey(rowAttr.Elements))
                rowAttr.Elements = pointAttrs[rowAttr.Elements];
            else
                rowAttr.Elements = "1";

            if (pointAttrs.ContainsKey(rowAttr.Eng_units))
                rowAttr.Eng_units = pointAttrs[rowAttr.Eng_units];
            else
                rowAttr.Eng_units = "";

            if (pointAttrs.ContainsKey(rowAttr.Enum_id))
                rowAttr.Enum_id = pointAttrs[rowAttr.Enum_id];
            else
                rowAttr.Enum_id = "";

            if (pointAttrs.ContainsKey(rowAttr.Equation))
                rowAttr.Equation = pointAttrs[rowAttr.Equation];
            else
                rowAttr.Equation = "";

            if (pointAttrs.ContainsKey(rowAttr.Extra))
                rowAttr.Extra = pointAttrs[rowAttr.Extra];
            else
                rowAttr.Extra = "0";

            if (pointAttrs.ContainsKey(rowAttr.Fw_conv_eq))
                rowAttr.Fw_conv_eq = pointAttrs[rowAttr.Fw_conv_eq];
            else
                rowAttr.Fw_conv_eq = "";

            if (pointAttrs.ContainsKey(rowAttr.Gr_screen))
                rowAttr.Gr_screen = pointAttrs[rowAttr.Gr_screen];
            else
                rowAttr.Gr_screen = "";

            if (pointAttrs.ContainsKey(rowAttr.Init_val))
                rowAttr.Init_val = pointAttrs[rowAttr.Init_val];
            else
                rowAttr.Init_val = "";

            if (pointAttrs.ContainsKey(rowAttr.Justification))
                rowAttr.Justification = pointAttrs[rowAttr.Justification];
            else
                rowAttr.Justification = "LEFT";

            if (pointAttrs.ContainsKey(rowAttr.Level))
                rowAttr.Level = pointAttrs[rowAttr.Level];
            else
                rowAttr.Level = "0";

            if (pointAttrs.ContainsKey(rowAttr.Local))
                rowAttr.Local = pointAttrs[rowAttr.Local];
            else
                rowAttr.Local = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_ack_hi))
                rowAttr.Log_ack_hi = pointAttrs[rowAttr.Log_ack_hi];
            else
                rowAttr.Log_ack_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_ack_hihi))
                rowAttr.Log_ack_hihi = pointAttrs[rowAttr.Log_ack_hihi];
            else
                rowAttr.Log_ack_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_ack_lo))
                rowAttr.Log_ack_lo = pointAttrs[rowAttr.Log_ack_lo];
            else
                rowAttr.Log_ack_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_ack_lolo))
                rowAttr.Log_ack_lolo = pointAttrs[rowAttr.Log_ack_lolo];
            else
                rowAttr.Log_ack_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_data))
                rowAttr.Log_data = pointAttrs[rowAttr.Log_data];
            else
                rowAttr.Log_data = "0";

            if (pointAttrs.ContainsKey(rowAttr.Log_del_hi))
                rowAttr.Log_del_hi = pointAttrs[rowAttr.Log_del_hi];
            else
                rowAttr.Log_del_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_del_hihi))
                rowAttr.Log_del_hihi = pointAttrs[rowAttr.Log_del_hihi];
            else
                rowAttr.Log_del_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_del_lo))
                rowAttr.Log_del_lo = pointAttrs[rowAttr.Log_del_lo];
            else
                rowAttr.Log_del_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_del_lolo))
                rowAttr.Log_del_lolo = pointAttrs[rowAttr.Log_del_lolo];
            else
                rowAttr.Log_del_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_gen_hi))
                rowAttr.Log_gen_hi = pointAttrs[rowAttr.Log_gen_hi];
            else
                rowAttr.Log_gen_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_gen_hihi))
                rowAttr.Log_gen_hihi = pointAttrs[rowAttr.Log_gen_hihi];
            else
                rowAttr.Log_gen_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_gen_lo))
                rowAttr.Log_gen_lo = pointAttrs[rowAttr.Log_gen_lo];
            else
                rowAttr.Log_gen_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_gen_lolo))
                rowAttr.Log_gen_lolo = pointAttrs[rowAttr.Log_gen_lolo];
            else
                rowAttr.Log_gen_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_reset_hi))
                rowAttr.Log_reset_hi = pointAttrs[rowAttr.Log_reset_hi];
            else
                rowAttr.Log_reset_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_reset_hihi))
                rowAttr.Log_reset_hihi = pointAttrs[rowAttr.Log_reset_hihi];
            else
                rowAttr.Log_reset_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_reset_lo))
                rowAttr.Log_reset_lo = pointAttrs[rowAttr.Log_reset_lo];
            else
                rowAttr.Log_reset_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Log_reset_lolo))
                rowAttr.Log_reset_lolo = pointAttrs[rowAttr.Log_reset_lolo];
            else
                rowAttr.Log_reset_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Max_stacked))
                rowAttr.Max_stacked = pointAttrs[rowAttr.Max_stacked];
            else
                rowAttr.Max_stacked = "";

            if (pointAttrs.ContainsKey(rowAttr.Measurement_unit_id))
                rowAttr.Measurement_unit_id = pointAttrs[rowAttr.Measurement_unit_id];
            else
                rowAttr.Measurement_unit_id = "";

            if (pointAttrs.ContainsKey(rowAttr.Misc_flags))
                rowAttr.Misc_flags = pointAttrs[rowAttr.Misc_flags];
            else
                rowAttr.Misc_flags = "0";

            if (pointAttrs.ContainsKey(rowAttr.Poll_after_set))
                rowAttr.Poll_after_set = pointAttrs[rowAttr.Poll_after_set];
            else
                rowAttr.Poll_after_set = "0";

            if (pointAttrs.ContainsKey(rowAttr.Precision))
                rowAttr.Precision = pointAttrs[rowAttr.Precision];
            else
                rowAttr.Precision = "";

            if (pointAttrs.ContainsKey(rowAttr.Proc_id))
                rowAttr.Proc_id = pointAttrs[rowAttr.Proc_id];
            else
                rowAttr.Proc_id = "";

            if (pointAttrs.ContainsKey(rowAttr.Ptmgmt_proc_id))
                rowAttr.Ptmgmt_proc_id = pointAttrs[rowAttr.Ptmgmt_proc_id];
            else
                rowAttr.Ptmgmt_proc_id = "";

            if (pointAttrs.ContainsKey(rowAttr.Pt_enabled))
                rowAttr.Pt_enabled = pointAttrs[rowAttr.Pt_enabled];
            else
                rowAttr.Pt_enabled = "1";

            if (pointAttrs.ContainsKey(rowAttr.Pt_origin))
                rowAttr.Pt_origin = pointAttrs[rowAttr.Pt_origin];
            else
                rowAttr.Pt_origin = "D";

            if (pointAttrs.ContainsKey(rowAttr.Pt_set_interval))
                rowAttr.Pt_set_interval = pointAttrs[rowAttr.Pt_set_interval];
            else
                rowAttr.Pt_set_interval = "";

            if (pointAttrs.ContainsKey(rowAttr.Pt_set_time))
                rowAttr.Pt_set_time = pointAttrs[rowAttr.Pt_set_time];
            else
                rowAttr.Pt_set_time = "";

            if (pointAttrs.ContainsKey(rowAttr.Pt_type))
                rowAttr.Pt_type = pointAttrs[rowAttr.Pt_type];
            else
                rowAttr.Pt_type = "BOOL";

            if (pointAttrs.ContainsKey(rowAttr.Range_high))
                rowAttr.Range_high = pointAttrs[rowAttr.Range_high];
            else
                rowAttr.Range_high = "1";

            if (pointAttrs.ContainsKey(rowAttr.Range_low))
                rowAttr.Range_low = pointAttrs[rowAttr.Range_low];
            else
                rowAttr.Range_low = "0";

            if (pointAttrs.ContainsKey(rowAttr.Raw_lim_high))
                rowAttr.Raw_lim_high = pointAttrs[rowAttr.Raw_lim_high];
            else
                rowAttr.Raw_lim_high = "";

            if (pointAttrs.ContainsKey(rowAttr.Raw_lim_low))
                rowAttr.Raw_lim_low = pointAttrs[rowAttr.Raw_lim_low];
            else
                rowAttr.Raw_lim_low = "";

            if (pointAttrs.ContainsKey(rowAttr.Rep_timeout_hi))
                rowAttr.Rep_timeout_hi = pointAttrs[rowAttr.Rep_timeout_hi];
            else
                rowAttr.Rep_timeout_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Rep_timeout_hihi))
                rowAttr.Rep_timeout_hihi = pointAttrs[rowAttr.Rep_timeout_hihi];
            else
                rowAttr.Rep_timeout_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Rep_timeout_lo))
                rowAttr.Rep_timeout_lo = pointAttrs[rowAttr.Rep_timeout_lo];
            else
                rowAttr.Rep_timeout_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Rep_timeout_lolo))
                rowAttr.Rep_timeout_lolo = pointAttrs[rowAttr.Rep_timeout_lolo];
            else
                rowAttr.Rep_timeout_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_allowed_hi))
                rowAttr.Reset_allowed_hi = pointAttrs[rowAttr.Reset_allowed_hi];
            else
                rowAttr.Reset_allowed_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_allowed_hihi))
                rowAttr.Reset_allowed_hihi = pointAttrs[rowAttr.Reset_allowed_hihi];
            else
                rowAttr.Reset_allowed_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_allowed_lo))
                rowAttr.Reset_allowed_lo = pointAttrs[rowAttr.Reset_allowed_lo];
            else
                rowAttr.Reset_allowed_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_allowed_lolo))
                rowAttr.Reset_allowed_lolo = pointAttrs[rowAttr.Reset_allowed_lolo];
            else
                rowAttr.Reset_allowed_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_cond))
                rowAttr.Reset_cond = pointAttrs[rowAttr.Reset_cond];
            else
                rowAttr.Reset_cond = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_pt))
                rowAttr.Reset_pt = pointAttrs[rowAttr.Reset_pt];
            else
                rowAttr.Reset_pt = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_timeout_hi))
                rowAttr.Reset_timeout_hi = pointAttrs[rowAttr.Reset_timeout_hi];
            else
                rowAttr.Reset_timeout_hi = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_timeout_hihi))
                rowAttr.Reset_timeout_hihi = pointAttrs[rowAttr.Reset_timeout_hihi];
            else
                rowAttr.Reset_timeout_hihi = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_timeout_lo))
                rowAttr.Reset_timeout_lo = pointAttrs[rowAttr.Reset_timeout_lo];
            else
                rowAttr.Reset_timeout_lo = "";

            if (pointAttrs.ContainsKey(rowAttr.Reset_timeout_lolo))
                rowAttr.Reset_timeout_lolo = pointAttrs[rowAttr.Reset_timeout_lolo];
            else
                rowAttr.Reset_timeout_lolo = "";

            if (pointAttrs.ContainsKey(rowAttr.Rev_conv_eq))
                rowAttr.Rev_conv_eq = pointAttrs[rowAttr.Rev_conv_eq];
            else
                rowAttr.Rev_conv_eq = "";

            if (pointAttrs.ContainsKey(rowAttr.Rollover_val))
                rowAttr.Rollover_val = pointAttrs[rowAttr.Rollover_val];
            else
                rowAttr.Rollover_val = "";

            if (pointAttrs.ContainsKey(rowAttr.Safety_pt))
                rowAttr.Safety_pt = pointAttrs[rowAttr.Safety_pt];
            else
                rowAttr.Safety_pt = "";

            if (pointAttrs.ContainsKey(rowAttr.Sample_intv))
                rowAttr.Sample_intv = pointAttrs[rowAttr.Sample_intv];
            else
                rowAttr.Sample_intv = "0";

            if (pointAttrs.ContainsKey(rowAttr.Sample_intv_unit))
                rowAttr.Sample_intv_unit = pointAttrs[rowAttr.Sample_intv_unit];
            else
                rowAttr.Sample_intv_unit = "";

            if (pointAttrs.ContainsKey(rowAttr.Scan_rate))
                rowAttr.Scan_rate = pointAttrs[rowAttr.Scan_rate];
            else
                rowAttr.Scan_rate = "1";

            if (pointAttrs.ContainsKey(rowAttr.Setpoint_high))
                rowAttr.Setpoint_high = pointAttrs[rowAttr.Setpoint_high];
            else
                rowAttr.Setpoint_high = "";

            if (pointAttrs.ContainsKey(rowAttr.Setpoint_low))
                rowAttr.Setpoint_low = pointAttrs[rowAttr.Setpoint_low];
            else
                rowAttr.Setpoint_low = "";

            if (pointAttrs.ContainsKey(rowAttr.Time_of_day))
                rowAttr.Time_of_day = pointAttrs[rowAttr.Time_of_day];
            else
                rowAttr.Time_of_day = "";

            if (pointAttrs.ContainsKey(rowAttr.Trig_ck_pt))
                rowAttr.Trig_ck_pt = pointAttrs[rowAttr.Trig_ck_pt];
            else
                rowAttr.Trig_ck_pt = "";

            if (pointAttrs.ContainsKey(rowAttr.Trig_pt))
                rowAttr.Trig_pt = pointAttrs[rowAttr.Trig_pt];
            else
                rowAttr.Trig_pt = "";

            if (pointAttrs.ContainsKey(rowAttr.Trig_rel))
                rowAttr.Trig_rel = pointAttrs[rowAttr.Trig_rel];
            else
                rowAttr.Trig_rel = "NO";

            if (pointAttrs.ContainsKey(rowAttr.Trig_val))
                rowAttr.Trig_val = pointAttrs[rowAttr.Trig_val];
            else
                rowAttr.Trig_val = "";

            if (pointAttrs.ContainsKey(rowAttr.Uafset))
                rowAttr.Uafset = pointAttrs[rowAttr.Uafset];
            else
                rowAttr.Uafset = "";

            if (pointAttrs.ContainsKey(rowAttr.Update_criteria))
                rowAttr.Update_criteria = pointAttrs[rowAttr.Update_criteria];
            else
                rowAttr.Update_criteria = "OC";

            if (pointAttrs.ContainsKey(rowAttr.Variance_val))
                rowAttr.Variance_val = pointAttrs[rowAttr.Variance_val];
            else
                rowAttr.Variance_val = "";

            if (pointAttrs.ContainsKey(rowAttr.Vars))
                rowAttr.Vars = pointAttrs[rowAttr.Vars];
            else
                rowAttr.Vars = "1";
        }

        public PointAttr(MainFormOperation mainFormOperation, InterfaceEnum interfaceType)
        {
            mInterfaceType = interfaceType;
            pmcInterface = InterfaceFactory.getInstance(mainFormOperation, interfaceType);
        }

        #region 成员方法

        public static void initAttr_ALLDATA(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            pointNameNew = stationName + PointConstant.ALLDATA_R;

            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_ALARM + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_AlarmDetail) + "]{96}";
                else
                {
                    address = Global.PLC_ADDR_TYPE_ALARM + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_AlarmDetail);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }

                pointAttrs.Add(rowAttr.Elements, "96");
                pointAttrs.Add(rowAttr.Pt_type, "UINT");
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_ALARM_DB + ",B" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_AlarmDetail) + ",416";

                pointAttrs.Add(rowAttr.Elements, "416");
                pointAttrs.Add(rowAttr.Pt_type, "USINT");
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Desc, "ALLDATA POINT");
            pointAttrs.Add(rowAttr.Disp_type, "u");

            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_DEVICEUP(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            address = "$DEVICE_UP";
            pointNameNew = stationName + PointConstant.DEVICEUP;

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Device Up Status");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Pt_origin, "I");
            pointAttrs.Add(rowAttr.Update_criteria, "OS");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ONLYONE_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[129].0";
            pointNameNew = stationName + PointConstant.ONLYONE_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[129].0";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":129";
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                //无此点
            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "1 for Only One Alarm And 0 for All Alarm");
            pointAttrs.Add(rowAttr.Device_id, deviceId);

            resourceId = resourceId.Replace("_R", "_W");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_GLOBAL__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[141].0";
            pointNameNew = stationName + PointConstant.GLOBAL__R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[141].0";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":141";
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                //无此点
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "1 for Global Standard And 0 for Non Global Standard");
            pointAttrs.Add(rowAttr.Device_id, deviceId);

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);

        }

        public static void initAttr_VERSION_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[144]";
            pointNameNew = stationName + PointConstant.VERSION_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[144]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":144";
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                //无此点
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Pmc Interface Version No, Only Used In 1St Station");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_STATION_ALARM(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_ALARM + "[0]";
            pointNameNew = stationName + PointConstant.STATION_ALARM;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_ALARM + "[0]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_ALARM + ":0";
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_ALARM_DB + ",W0,1";

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "PLC Alarm Station Number");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_STATION_PROD(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[0]";
            pointNameNew = stationName + PointConstant.STATION_PROD;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[0]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":0";
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W0,1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "PLC Production Station Number");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MF00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_ALARM + "[" + pmcInterface.getSummaryByteNumber(stationNo, "MF") + "]." + pmcInterface.getSummaryBitNumber(stationNo);
            pointNameNew = stationName + PointConstant.MF00000_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_ALARM + "[" + pmcInterface.getSummaryByteNumber(stationNo, "MF") + "]." + pmcInterface.getSummaryBitNumber(stationNo);
                else
                {
                    address = Global.PLC_ADDR_TYPE_ALARM + ":" + pmcInterface.getSummaryByteNumber(stationNo, "MF");
                    pointAttrs.Add(rowAttr.Addr_offset, pmcInterface.getSummaryBitNumber(stationNo) + "");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_ALARM_DB + ",X" + pmcInterface.getSummaryByteNumber(stationNo, "MF") + "." + pmcInterface.getSummaryBitNumber(stationNo) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Device_id, deviceId);

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_WN00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_ALARM + "[" + pmcInterface.getSummaryByteNumber(stationNo, "WN") + "]." + pmcInterface.getSummaryBitNumber(stationNo);
            pointNameNew = stationName + PointConstant.WN00000_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_ALARM + "[" + pmcInterface.getSummaryByteNumber(stationNo, "WN") + "]." + pmcInterface.getSummaryBitNumber(stationNo);
                else
                {
                    address = Global.PLC_ADDR_TYPE_ALARM + ":" + pmcInterface.getSummaryByteNumber(stationNo, "WN");
                    pointAttrs.Add(rowAttr.Addr_offset, pmcInterface.getSummaryBitNumber(stationNo) + "");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_ALARM_DB + ",X" + pmcInterface.getSummaryByteNumber(stationNo, "WN") + "." + pmcInterface.getSummaryBitNumber(stationNo) + ",1";

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CONFIGR_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            if (stationNo != 1)
                return;

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[129]{16}";
            pointNameNew = stationName + PointConstant.CONFIGR_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[129]{16}";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":129";
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                //无此点
            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "PLC Initial Paraments");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Elements, "16");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            resourceId = resourceId.Replace("_R", "_W");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CLS_SHIFT_ALL_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].2";
            pointNameNew = stationName + PointConstant.CLS_SHIFT_ALL_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].2";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "2");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + ".2,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Clear All Shift Counter/Timer Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CLS_SHIFT_1_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].3";
            pointNameNew = stationName + PointConstant.CLS_SHIFT_1_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].3";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "3");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + ".3,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Clear Shift1 Counter/Timer Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CLS_SHIFT_2_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].4";
            pointNameNew = stationName + PointConstant.CLS_SHIFT_2_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].4";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "4");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + ".4,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Clear Shift2 Counter/Timer Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CLS_SHIFT_3_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].5";
            pointNameNew = stationName + PointConstant.CLS_SHIFT_3_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].5";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "5");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + ".5,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Clear Shift3 Counter/Timer Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_WORK_SHIFT_1_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].8";
            pointNameNew = stationName + PointConstant.WORK_SHIFT_1_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].8";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "8");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + 1) + ".0,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Shift 1 is Working Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_WORK_SHIFT_2_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].9";
            pointNameNew = stationName + PointConstant.WORK_SHIFT_2_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].9";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "9");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + 1) + ".1,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Shift 2 is Working Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_WORK_SHIFT_3_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].10";
            pointNameNew = stationName + PointConstant.WORK_SHIFT_3_W;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].10";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "10");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + 1) + ".2,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Shift 3 is Working Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_WORK_SHIFT_W(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].11";
            pointNameNew = stationName + PointConstant.WORK_SHIFT_W;


            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].11";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "11");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + 1) + ".3,1";

            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "In Working Bit");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_RT00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_RootCase) + "]";
            pointNameNew = stationName + PointConstant.RT00000_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_RootCase) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_RootCase);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_TIP_DB + ",W" + 2 * (stationNo - 1) + ",1";

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Root Alarm Cause");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_HC00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_RootCase) + 1) + "]";
            pointNameNew = stationName + PointConstant.HC00000_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_RootCase) + 1) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_RootCase) + 1);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                //无此点
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Root High Cause");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + "]";
            pointNameNew = stationName + PointConstant.BD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Block Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + "]";
            pointNameNew = stationName + PointConstant.BD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Block Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + "]";
            pointNameNew = stationName + PointConstant.BD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Block Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_SD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 1) + "]";
            pointNameNew = stationName + PointConstant.SD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 1) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 1);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Starve Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_SD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 1) + "]";
            pointNameNew = stationName + PointConstant.SD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 1) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 1);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Starve Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_SD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 1) + "]";
            pointNameNew = stationName + PointConstant.SD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 1) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 1);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Starve Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 2) + "]";
            pointNameNew = stationName + PointConstant.MD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 2) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 2);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Machine Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Range_high, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 2) + "]";
            pointNameNew = stationName + PointConstant.MD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 2) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 2);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Machine Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 2) + "]";
            pointNameNew = stationName + PointConstant.MD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 2) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 2);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Machine Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 3) + "]";
            pointNameNew = stationName + PointConstant.PD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 3) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 3);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 6) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Production Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 3) + "]";
            pointNameNew = stationName + PointConstant.PD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 3) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 3);

                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 6) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Production Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 3) + "]";
            pointNameNew = stationName + PointConstant.PD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 3) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 3);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 6) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Production Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ED00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 4) + "]";
            pointNameNew = stationName + PointConstant.ED00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 4) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 4);

                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 8) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Emergency Stop Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ED00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 4) + "]";
            pointNameNew = stationName + PointConstant.ED00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 4) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 4);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 8) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Emergency Stop Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ED00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 4) + "]";
            pointNameNew = stationName + PointConstant.ED00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 4) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 4);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 8) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Emergency Stop Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_AD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 5) + "]";
            pointNameNew = stationName + PointConstant.AD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 5) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 5);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 10) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Andon Stop Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_AD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 5) + "]";
            pointNameNew = stationName + PointConstant.AD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 5) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 5);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 10) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Andon Stop Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_AD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 5) + "]";
            pointNameNew = stationName + PointConstant.AD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 5) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 5);

                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 10) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Andon Stop Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 6) + "]";
            pointNameNew = stationName + PointConstant.OD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 6) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 6);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 12) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Other Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 6) + "]";
            pointNameNew = stationName + PointConstant.OD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 6) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 6);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 12) + ",1";
            }
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Other Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 6) + "]";
            pointNameNew = stationName + PointConstant.OD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 6) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 6);

                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 12) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Other Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 7) + "]";
            pointNameNew = stationName + PointConstant.CD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 7) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 7);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 14) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Over Cycle Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 7) + "]";
            pointNameNew = stationName + PointConstant.CD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 7) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 7);

                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 14) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Over Cycle Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 7) + "]";
            pointNameNew = stationName + PointConstant.CD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 7) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 7);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 14) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Over Cycle Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FD00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {

            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 15) + "]";
            pointNameNew = stationName + PointConstant.FD00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 15) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 15);

                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift1) + 30) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "All Duration for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FD00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 15) + "]";
            pointNameNew = stationName + PointConstant.FD00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 15) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 15);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift2) + 30) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "All Duration for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FD00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 15) + "]";
            pointNameNew = stationName + PointConstant.FD00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 15) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 15);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTime_Shift3) + 30) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "All Duration for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BTRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].0";
            pointNameNew = stationName + PointConstant.BTRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].0";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".0,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "block stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_STRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].1";
            pointNameNew = stationName + PointConstant.STRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].1";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "1");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".1,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "starve stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MTRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].2";
            pointNameNew = stationName + PointConstant.MTRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].2";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "2");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".2,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "machine stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PTRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].3";
            pointNameNew = stationName + PointConstant.PTRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].3";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);

                    pointAttrs.Add(rowAttr.Addr_offset, "3");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".3,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "production stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ETRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].4";
            pointNameNew = stationName + PointConstant.ETRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].4";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);

                    pointAttrs.Add(rowAttr.Addr_offset, "4");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".4,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "emergency stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ATRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].5";
            pointNameNew = stationName + PointConstant.ATRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].5";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);

                    pointAttrs.Add(rowAttr.Addr_offset, "5");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".5,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "andon stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OTRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].6";
            pointNameNew = stationName + PointConstant.OTRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].6";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "6");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".6,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "other stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CTRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].7";
            pointNameNew = stationName + PointConstant.CTRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].7";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "7");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + ".7,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "over cycle time trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FTRIGER_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.FTRIGER_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].15";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "15");
                }
            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",X" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + 1) + ".7,1";
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "full stop trigger");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ACOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.ACOUNT__R;
            string equation = stationName + "_ATRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Andon Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);

        }

        public static void initAttr_BCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.BCOUNT__R;
            string equation = stationName + "_BTRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "block Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.CCOUNT__R;
            string equation = stationName + "_CTRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "over cycle Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ECOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {

            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.ECOUNT__R;
            string equation = stationName + "_ETRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Emergency Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.FCOUNT__R;
            string equation = stationName + "_FTRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "all Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.MCOUNT__R;
            string equation = stationName + "_MTRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Machine Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointNameNew = stationName + PointConstant.OCOUNT__R;
            string equation = stationName + "_OTRIGER_R";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Other Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_SCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.SCOUNT__R;
            string equation = stationName + "_STRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Starve Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCOUNT__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PCOUNT__R;
            string equation = stationName + "_PTRIGER_R";
            string reset_pt = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "T_H");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Production Fault Counter for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, reset_pt);
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ATRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_ATRIGER_R)?" + stationName + "_ATRIGER_R:0"; //IsAvailable(UBTL_TLDA10MC_ATRIGER_R) ? UBTL_TLDA10MC_ATRIGER_R : 0
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.ATRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of Andon Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BTRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_BTRIGER_R)?" + stationName + "_BTRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.BTRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of BLOCK Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CTRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_CTRIGER_R)?" + stationName + "_CTRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.CTRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of OVERCYCLE Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ETRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_ETRIGER_R)?" + stationName + "_ETRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.ETRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of emergency Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FTRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_FTRIGER_R)?" + stationName + "_FTRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.FTRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of all Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MTRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_MTRIGER_R)?" + stationName + "_MTRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.MTRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of machine Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OTRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_OTRIGER_R)?" + stationName + "_OTRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.OTRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of other Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PTRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_PTRIGER_R)?" + stationName + "_PTRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PTRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of production Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_STRIGER_V(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = "IsAvailable(" + stationName + "_STRIGER_R)?" + stationName + "_STRIGER_R:0";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.STRIGER_V;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");

            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "The Trigger Signal Of starve Downtime(IsAvailable)");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CLS_SHIFT_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            string equation = stationName + "_CLS_SHIFT_1_W OR " + stationName + "_CLS_SHIFT_2_W OR " + stationName + "_CLS_SHIFT_3_W";
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.CLS_SHIFT_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Clear Counter For HMI When Shift Start");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCA0001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + "]";
            pointNameNew = stationName + PointConstant.PCA0001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1);
                }

                pointAttrs.Add(rowAttr.Reset_cond, "UN");
                pointAttrs.Add(rowAttr.Addr_offset, "0");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model01 Actual Production Count for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCA0002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + "]";
            pointNameNew = stationName + PointConstant.PCA0002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2);
                }

                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model01 Actual Production Count for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCA0003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + "]";
            pointNameNew = stationName + PointConstant.PCA0003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3);
                }

                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model01 Actual Production Count for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");


            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCB0001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 1) + "]";
            pointNameNew = stationName + PointConstant.PCB0001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 1) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 1);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model02 Actual Production Count for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCB0002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 1) + "]";
            pointNameNew = stationName + PointConstant.PCB0002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 1) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 1);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model02 Actual Production Count for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCB0003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 1) + "]";
            pointNameNew = stationName + PointConstant.PCB0003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 1) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 1);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 2) + ",1";
            }


            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model02 Actual Production Count for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCC0001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 2) + "]";
            pointNameNew = stationName + PointConstant.PCC0001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 2) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 2);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model03 Actual Production Count for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCC0002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 2) + "]";
            pointNameNew = stationName + PointConstant.PCC0002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 2) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 2);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model03 Actual Production Count for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCC0003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 2) + "]";
            pointNameNew = stationName + PointConstant.PCC0003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 2) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 2);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model03 Actual Production Count for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCD0001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 3) + "]";
            pointNameNew = stationName + PointConstant.PCD0001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 3) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 3);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + 6) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model04 Actual Production Count for Shift 1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCD0002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 3) + "]";
            pointNameNew = stationName + PointConstant.PCD0002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 3) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 3);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 6) + ",1";
            }


            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model04 Actual Production Count for Shift 2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCD0003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 3) + "]";
            pointNameNew = stationName + PointConstant.PCD0003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 3) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + 3);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + 6) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "Model04 Actual Production Count for Shift 3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BC00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + "]";
            pointNameNew = stationName + PointConstant.BC00001_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "buffer counter1");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BC00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 1) + "]";
            pointNameNew = stationName + PointConstant.BC00002_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 1) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 1);

                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 2) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "buffer counter2");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BC00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 2) + "]";
            pointNameNew = stationName + PointConstant.BC00003_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 2) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 2);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 4) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "buffer counter3");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BC00004_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            //address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 3) + "]";
            pointNameNew = stationName + PointConstant.BC00004_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 3) + "]";
                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 3);
                }
                pointAttrs.Add(rowAttr.Reset_cond, "UN");

            }
            else
            {

                string plcName = stationName.Substring(5, 6);
                address = "S7:[" + plcName + "]" + Constant.PLC_SIEMENS_INFO_DB + ",W" + (pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_buffer1) + 6) + ",1";
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Desc, "buffer counter4");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "0");

            resourceId = resourceId.Replace("_R", "_W");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_AD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.AD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.AD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.AD00002_R + "):(" + stationName + PointConstant.AD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Andon Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_BD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.BD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.BD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.BD00002_R + "):(" + stationName + PointConstant.BD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "BLOCK Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_CD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.CD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.CD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.CD00002_R + "):(" + stationName + PointConstant.CD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "OVER CYCLE TIME Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_ED00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.ED00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.ED00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.ED00002_R + "):(" + stationName + PointConstant.ED00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "EMERGENCY Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.FD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.FD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.FD00002_R + "):(" + stationName + PointConstant.FD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "ALL Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.MD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.MD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.MD00002_R + "):(" + stationName + PointConstant.MD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "MACHINE Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_OD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.OD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.OD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.OD00002_R + "):(" + stationName + PointConstant.OD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "OTHER Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.PD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.PD00002_R + "):(" + stationName + PointConstant.PD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "PRODUCTION Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_SD00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.SD00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_AD00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_AD00002_R) : (UBTL_TLDA10MC_AD00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.SD00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.SD00002_R + "):(" + stationName + PointConstant.SD00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "STARVE Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCA0000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PCA0000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_PCA0001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_PCA0002_R) : (UBTL_TLDA10MC_PCA0003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.PCA0001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.PCA0002_R + "):(" + stationName + PointConstant.PCA0003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Model01 Actual Production Count for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCB0000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PCB0000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_PCA0001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_PCA0002_R) : (UBTL_TLDA10MC_PCA0003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.PCB0001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.PCB0002_R + "):(" + stationName + PointConstant.PCB0003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Model02 Actual Production Count for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCC0000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PCC0000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_PCA0001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_PCA0002_R) : (UBTL_TLDA10MC_PCA0003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.PCC0001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.PCC0002_R + "):(" + stationName + PointConstant.PCC0003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Model03 Actual Production Count for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PCD0000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PCD0000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_PCA0001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_PCA0002_R) : (UBTL_TLDA10MC_PCA0003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.PCD0001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.PCD0002_R + "):(" + stationName + PointConstant.PCD0003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Model04 Actual Production Count for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_FDMIN00_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.FDMIN00_R;
            //UBTL_TLDA10MC_FD00000_R / 60
            string equation = stationName + PointConstant.FD00000_R + "/60";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Fault Duration for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MTTR(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.MTTR;
            //(UBTL_TLDA10MC_FCOUNT__R NE 0) ? (UBTL_TLDA10MC_FD00000_R / UBTL_TLDA10MC_FCOUNT__R / 60):(0)
            string equation = "(" + stationName + PointConstant.FCOUNT__R + " NE 0) ? (" + stationName + PointConstant.FD00000_R + "/" + stationName + PointConstant.FCOUNT__R + "/60):(0)";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Mean Time To Repair (Minutes)");
            pointAttrs.Add(rowAttr.Disp_type, "f");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "REAL");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_MCBF(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.MCBF;
            //(UBTL_TLDA10MC_FCOUNT__R NE 0) ? (UBTL_TLDA10MC_FD00000_R / UBTL_TLDA10MC_FCOUNT__R / 60):(0)
            string equation = "(" + stationName + PointConstant.FCOUNT__R + " NE 0) ? (" + stationName + PointConstant.PC00000_R + "/" + stationName + PointConstant.FCOUNT__R + "):(0)";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Mean Cycles Between Failures");
            pointAttrs.Add(rowAttr.Disp_type, "f");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "REAL");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PC00001_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PC00001_R;
            //UBTL_TLDA10MC_PCA0001_R + UBTL_TLDA10MC_PCB0001_R + UBTL_TLDA10MC_PCC0001_R + UBTL_TLDA10MC_PCD0001_R
            string equation = stationName + PointConstant.PCA0001_R + " + " + stationName + PointConstant.PCB0001_R + " + " + stationName + PointConstant.PCC0001_R + " + " + stationName + PointConstant.PCD0001_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Production Count for Shift 1");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PC00002_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PC00002_R;
            //UBTL_TLDA10MC_PCA0001_R + UBTL_TLDA10MC_PCB0001_R + UBTL_TLDA10MC_PCC0001_R + UBTL_TLDA10MC_PCD0001_R
            string equation = stationName + PointConstant.PCA0002_R + " + " + stationName + PointConstant.PCB0002_R + " + " + stationName + PointConstant.PCC0002_R + " + " + stationName + PointConstant.PCD0002_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Production Count for Shift 2");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PC00003_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PC00003_R;
            //UBTL_TLDA10MC_PCA0001_R + UBTL_TLDA10MC_PCB0001_R + UBTL_TLDA10MC_PCC0001_R + UBTL_TLDA10MC_PCD0001_R
            string equation = stationName + PointConstant.PCA0003_R + " + " + stationName + PointConstant.PCB0003_R + " + " + stationName + PointConstant.PCC0003_R + " + " + stationName + PointConstant.PCD0003_R;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Production Count for Shift 3");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_PC00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.PC00000_R;
            //(UBTL_CLOCK_SHFT EQ 1) ? (UBTL_TLDA10MC_PC00001_R) : ((UBTL_CLOCK_SHFT EQ 2) ? (UBTL_TLDA10MC_PC00002_R) : (UBTL_TLDA10MC_PC00003_R))
            string area = stationName.Substring(0, 4);
            string equation = "(" + area + "_CLOCK_SHFT EQ 1) ? (" + stationName + PointConstant.PC00001_R + "):((" + area + "_CLOCK_SHFT EQ 2) ? (" + stationName + PointConstant.PC00002_R + "):(" + stationName + PointConstant.PC00003_R + "))";

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "Actual Production Count for Current Shift");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Equation, equation);
            pointAttrs.Add(rowAttr.Init_val, "");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "R");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");
            pointAttrs.Add(rowAttr.Reset_pt, "");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        //TIP 
        public static void initAttr_TIP_RDY_CYCLETIME(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_RDY_CYCLETIME;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord) + "].12";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_ControlWord);
                    pointAttrs.Add(rowAttr.Addr_offset, "12");

                }
            }

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Desc, "TIP Ready Signal of Cycletime");
            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Device_id, deviceId);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_BLOCK(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_BLOCK;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].0";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "0");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Blocked");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Blocked");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_STARVE(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_STARVE;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].1";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "1");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Sarver");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Sarver");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_MACHINE(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_MACHINE;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].2";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "2");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Machine fault");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Machine fault");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_PSTOP(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_PSTOP;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].3";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "3");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Production Fault");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Production Fault");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_ESTOP(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_ESTOP;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].4";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "4");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of E_stop");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of E_stop");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_TIP_FLT_ANDON(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_ANDON;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].5";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "5");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Andon");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Andon");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_OTHER(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_OTHER;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].6";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "6");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Other");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Other");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_OVERCYCLE(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_OVERCYCLE;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].7";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "7");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of Over cycle");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of Over cycle");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_FLT_ALL(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_FLT_ALL;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger) + "].15";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_DownTimeTrigger);
                    pointAttrs.Add(rowAttr.Addr_offset, "15");

                }
            }

            pointAttrs.Add(rowAttr.Ack_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Ack_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Alarm_publish, "N");
            pointAttrs.Add(rowAttr.Alm_class, "MF");
            pointAttrs.Add(rowAttr.Alm_criteria, "ABS");
            pointAttrs.Add(rowAttr.Alm_enable, "1");
            pointAttrs.Add(rowAttr.Alm_high_2, "1");
            pointAttrs.Add(rowAttr.Alm_hlp_file, "\\" + pointNameNew);
            pointAttrs.Add(rowAttr.Alm_msg, "TIP Fault Signal of All");
            pointAttrs.Add(rowAttr.Alm_route_oper, "1");
            pointAttrs.Add(rowAttr.Alm_route_sysmgr, "1");
            pointAttrs.Add(rowAttr.Alm_route_user, "1");
            pointAttrs.Add(rowAttr.Alm_type, "AL");
            pointAttrs.Add(rowAttr.Delete_req_hi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_hihi, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lo, "AR");
            pointAttrs.Add(rowAttr.Delete_req_lolo, "AR");
            pointAttrs.Add(rowAttr.Desc, "TIP Fault Signal of All");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Log_ack_hi, "0");
            pointAttrs.Add(rowAttr.Log_ack_hihi, "0");
            pointAttrs.Add(rowAttr.Log_ack_lo, "0");
            pointAttrs.Add(rowAttr.Log_ack_lolo, "0");
            pointAttrs.Add(rowAttr.Log_del_hi, "0");
            pointAttrs.Add(rowAttr.Log_del_hihi, "0");
            pointAttrs.Add(rowAttr.Log_del_lo, "0");
            pointAttrs.Add(rowAttr.Log_del_lolo, "0");
            pointAttrs.Add(rowAttr.Log_gen_hi, "0");
            pointAttrs.Add(rowAttr.Log_gen_hihi, "0");
            pointAttrs.Add(rowAttr.Log_gen_lo, "0");
            pointAttrs.Add(rowAttr.Log_gen_lolo, "0");
            pointAttrs.Add(rowAttr.Log_reset_hi, "0");
            pointAttrs.Add(rowAttr.Log_reset_hihi, "0");
            pointAttrs.Add(rowAttr.Log_reset_lo, "0");
            pointAttrs.Add(rowAttr.Log_reset_lolo, "0");
            pointAttrs.Add(rowAttr.Max_stacked, "5");
            pointAttrs.Add(rowAttr.Rep_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Rep_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Reset_allowed_hi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_hihi, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lo, "0");
            pointAttrs.Add(rowAttr.Reset_allowed_lolo, "0");
            pointAttrs.Add(rowAttr.Reset_timeout_hi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_hihi, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lo, "-1");
            pointAttrs.Add(rowAttr.Reset_timeout_lolo, "-1");
            pointAttrs.Add(rowAttr.Sample_intv_unit, "SEC");
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_VAL_CYCLETIME(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_VAL_CYCLETIME;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_tip_val_cycletime) + "]{8}";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_tip_val_cycletime);
                }
            }

            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Elements, "8");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Desc, "TIP Station Cycletime");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_VAL_PC00001(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_VAL_PC00001;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1) + "]{8}";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift1);
                }
            }
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Elements, "8");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Desc, "TIP Station Shift 1 Count");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_VAL_PC00002(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_VAL_PC00002;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2) + "]{8}";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift2);
                }
            }
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Elements, "8");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Desc, "TIP Station Shift 2 Count");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_VAL_PC00003(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_VAL_PC00003;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3) + "]{8}";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_moduleA_shift3);
                }
            }
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Elements, "8");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Desc, "TIP Station Shift 3 Count");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TIP_VAL_CT(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            //CIM脚本赋值
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_VAL_CT;

            pointAttrs.Add(rowAttr.Access, "W");
            pointAttrs.Add(rowAttr.Addr_offset, "");
            pointAttrs.Add(rowAttr.Addr_type, "");
            pointAttrs.Add(rowAttr.Analog_deadband, "");
            pointAttrs.Add(rowAttr.Calc_type, "EQU");
            pointAttrs.Add(rowAttr.Conv_type, "");
            pointAttrs.Add(rowAttr.Delay_load, "");
            pointAttrs.Add(rowAttr.Desc, "TIP Value CycleTime");
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Elements, "8");
            pointAttrs.Add(rowAttr.Init_val, "0");
            pointAttrs.Add(rowAttr.Local, "0");
            pointAttrs.Add(rowAttr.Poll_after_set, "");
            pointAttrs.Add(rowAttr.Proc_id, "MASTER_PTDP_RP");
            pointAttrs.Add(rowAttr.Ptmgmt_proc_id, "MASTER_PTM0_RP");
            pointAttrs.Add(rowAttr.Pt_origin, "G");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "SI");
            pointAttrs.Add(rowAttr.Rollover_val, "0");
            pointAttrs.Add(rowAttr.Scan_rate, "");
            pointAttrs.Add(rowAttr.Trig_rel, "");
            pointAttrs.Add(rowAttr.Update_criteria, "");
            pointAttrs.Add(rowAttr.Variance_val, "0");

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_TAKEON__R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TAKEON__R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getTokenByteNumber(stationNo) + "]." + pmcInterface.getTokenBitNumber(stationNo);

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getTokenByteNumber(stationNo);
                    pointAttrs.Add(rowAttr.Addr_offset, pmcInterface.getTokenBitNumber(stationNo) + "");
                }
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Occupancy Signal(1 = Occpuancy,0 = Empty)");
            pointAttrs.Add(rowAttr.Device_id, deviceId);

            //resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        public static void initAttr_VM00000_R(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.VM00000_R;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_tip_car_type) + "]";
                else
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_tip_car_type);
            }

            pointAttrs.Add(rowAttr.Addr, address);
            pointAttrs.Add(rowAttr.Desc, "Car model Information for MIL code");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Disp_type, "u");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Reset_cond, "UN");

            //resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }

        public static void initAttr_TIP_VAL_CURRENT_CYCLETIME(PointAttr rowAttr, string stationName, int stationNo, string pointName, string resourceId, string deviceId)
        {
            string address = null;
            string pointNameNew = null;
            Dictionary<string, string> pointAttrs = new Dictionary<string, string>();

            pointNameNew = stationName + PointConstant.TIP_VAL_CURRENT_CYCLETIME;

            if (mInterfaceType == InterfaceEnum.AB)
            {
                if (Global.PLC_ADDR_TYPE_ALARM == Constant.PLC_AB_ADDR_ARRAY_ALARM)
                    address = Global.PLC_ADDR_TYPE_PROD + "[" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_tip_current_cycletime) + "]";

                else
                {
                    address = Global.PLC_ADDR_TYPE_PROD + ":" + pmcInterface.getStartAddress(stationNo, pmcInterface.StationAddrs_tip_current_cycletime);
                }
            }
            pointAttrs.Add(rowAttr.Disp_type, "u");
            //pointAttrs.Add(rowAttr.Elements, "8");
            pointAttrs.Add(rowAttr.Pt_type, "UINT");
            pointAttrs.Add(rowAttr.Range_high, "");
            pointAttrs.Add(rowAttr.Range_low, "");
            pointAttrs.Add(rowAttr.Desc, "TIP CURRENT CYCLETIME");
            pointAttrs.Add(rowAttr.Device_id, deviceId);
            pointAttrs.Add(rowAttr.Addr, address);

            resourceId = resourceId.Replace("_R", "__T");
            initCommAttr(rowAttr, pointNameNew, resourceId, pointAttrs);
        }
        #endregion
    }
}
