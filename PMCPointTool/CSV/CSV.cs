using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace PMCPointTool
{
    /// <summary>
    /// CSV文件类
    /// </summary>
    class CSV
    {
        private int filedCount = Constant.CSV_FILED_COUNT;
        private DataTable dt = new DataTable();                            //内容数据
        private List<CSVRow> rows = new List<CSVRow>();                    //行数据集合
        private string[] fileds = new string[Constant.CSV_FILED_COUNT];    //行属性数组形式
        private PointAttrFiled pointAttr = new PointAttrFiled();           //点属性列

        public PointAttrFiled PointAttrFiled
        {
            get { return pointAttr; }
            set { pointAttr = value; }
        }

        public List<CSVRow> Rows
        {
            get { return rows; }
            set { rows = value; }
        }

        public string[] Fileds
        {
            get { return fileds; }
            set { fileds = value; }
        }

        public System.Data.DataTable Dt
        {
            get { return dt; }
            set { dt = value; }
        }

        public CSV()
        {
            initFiled();
            init();
        }

        public void init()
        {
            createHead();
        }

        private void createHead()
        {
            for (int i = 0; i < fileds.Length; i++)
            {
                DataColumn dc = createHeadColumn(fileds[i], "System.String");
                dt.Columns.Add(dc);
            }

            createRow(new string[] { "##created by " + Constant.APP_NAME + Constant.APP_VERSION });
            createRow(new string[] { "##on " + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") }); //24h
            createRow(new string[] { "##user:" + System.Net.Dns.GetHostName() });
            createRow(fileds);
        }

        private DataColumn createHeadColumn(string filedName, string filedType)
        {
            if (String.IsNullOrEmpty(filedName) || String.IsNullOrEmpty(filedType))
                return null;
            DataColumn lNameColumn = new DataColumn();
            lNameColumn.DataType = System.Type.GetType(filedType);
            lNameColumn.ColumnName = filedName;
            return lNameColumn;
        }

        public void createRow(string[] rowData)
        {
            DataRow dr = dt.NewRow();
            dr.ItemArray = rowData;
            dt.Rows.Add(dr);
        }

        public void createRow(List<string[]> rowDatas)
        {
            for (int i = 0; i < rowDatas.Count; i++)
            {
                createRow(rowDatas[i]);
            }
        }

        public void createRow(List<CSVCell> cells)
        {
            string[] rowData = new string[filedCount];

            for (int i = 0; i < cells.Count; i++)
            {
                int filedIndex = findFiledIndex(cells[i].Filed);
                if (filedIndex < 0)
                    break;
                rowData[filedIndex] = cells[i].Val;
            }

            DataRow dr = dt.NewRow();
            dr.ItemArray = rowData;
            dt.Rows.Add(dr);
        }

        public void createRow(List<List<CSVCell>> listCells)
        {
            for (int i = 0; i < listCells.Count; i++)
            {
                createRow(listCells[i]);
            }
        }

        private void initFiled()
        {
            fileds[0] = pointAttr.Pt_id;
            fileds[1] = pointAttr.Access;
            fileds[2] = pointAttr.Access_filter;
            fileds[3] = pointAttr.Ack_timeout_hi;
            fileds[4] = pointAttr.Ack_timeout_hihi;
            fileds[5] = pointAttr.Ack_timeout_lo;
            fileds[6] = pointAttr.Ack_timeout_lolo;
            fileds[7] = pointAttr.Addr;
            fileds[8] = pointAttr.Addr_offset;
            fileds[9] = pointAttr.Addr_type;
            fileds[10] = pointAttr.Alarm_changeapproval;
            fileds[11] = pointAttr.Alarm_delay_hi;
            fileds[12] = pointAttr.Alarm_delay_hihi;
            fileds[13] = pointAttr.Alarm_delay_lo;
            fileds[14] = pointAttr.Alarm_delay_lolo;
            fileds[15] = pointAttr.Alarm_delay_unit_hi;
            fileds[16] = pointAttr.Alarm_delay_unit_hihi;
            fileds[17] = pointAttr.Alarm_delay_unit_lo;
            fileds[18] = pointAttr.Alarm_delay_unit_lolo;
            fileds[19] = pointAttr.Alarm_publish;
            fileds[20] = pointAttr.Alm_class;
            fileds[21] = pointAttr.Alm_criteria;
            fileds[22] = pointAttr.Alm_deadband;
            fileds[23] = pointAttr.Alm_delay;
            fileds[24] = pointAttr.Alm_enable;
            fileds[25] = pointAttr.Alm_high_1;
            fileds[26] = pointAttr.Alm_high_2;
            fileds[27] = pointAttr.Alm_hlp_file;
            fileds[28] = pointAttr.Alm_low_1;
            fileds[29] = pointAttr.Alm_low_2;
            fileds[30] = pointAttr.Alm_msg;
            fileds[31] = pointAttr.Alm_route_oper;
            fileds[32] = pointAttr.Alm_route_sysmgr;
            fileds[33] = pointAttr.Alm_route_user;
            fileds[34] = pointAttr.Alm_severity;
            fileds[35] = pointAttr.Alm_str;
            fileds[36] = pointAttr.Alm_type;
            fileds[37] = pointAttr.Alm_update_value;
            fileds[38] = pointAttr.Analog_deadband;
            fileds[39] = pointAttr.Bfr_count;
            fileds[40] = pointAttr.Bfr_dur;
            fileds[41] = pointAttr.Bfr_event_period;
            fileds[42] = pointAttr.Bfr_event_pt_id;
            fileds[43] = pointAttr.Bfr_event_type;
            fileds[44] = pointAttr.Bfr_event_units;
            fileds[45] = pointAttr.Bfr_gate_cond;
            fileds[46] = pointAttr.Bfr_sync_time;
            fileds[47] = pointAttr.Calc_type;
            fileds[48] = pointAttr.Changeapproval;
            fileds[49] = pointAttr.Conv_lim_high;
            fileds[50] = pointAttr.Conv_lim_low;
            fileds[51] = pointAttr.Conv_type;
            fileds[52] = pointAttr.Delay_load;
            fileds[53] = pointAttr.Delete_req_hi;
            fileds[54] = pointAttr.Delete_req_hihi;
            fileds[55] = pointAttr.Delete_req_lo;
            fileds[56] = pointAttr.Delete_req_lolo;
            fileds[57] = pointAttr.Desc;
            fileds[58] = pointAttr.Deviation_pt;
            fileds[59] = pointAttr.Device_id;
            fileds[60] = pointAttr.Disp_lim_high;
            fileds[61] = pointAttr.Disp_lim_low;
            fileds[62] = pointAttr.Disp_type;
            fileds[63] = pointAttr.Disp_width;
            fileds[64] = pointAttr.Elements;
            fileds[65] = pointAttr.Eng_units;
            fileds[66] = pointAttr.Enum_id;
            fileds[67] = pointAttr.Equation;
            fileds[68] = pointAttr.Extra;
            fileds[69] = pointAttr.Fw_conv_eq;
            fileds[70] = pointAttr.Gr_screen;
            fileds[71] = pointAttr.Init_val;
            fileds[72] = pointAttr.Justification;
            fileds[73] = pointAttr.Level;
            fileds[74] = pointAttr.Local;
            fileds[75] = pointAttr.Log_ack_hi;
            fileds[76] = pointAttr.Log_ack_hihi;
            fileds[77] = pointAttr.Log_ack_lo;
            fileds[78] = pointAttr.Log_ack_lolo;
            fileds[79] = pointAttr.Log_data;
            fileds[80] = pointAttr.Log_del_hi;
            fileds[81] = pointAttr.Log_del_hihi;
            fileds[82] = pointAttr.Log_del_lo;
            fileds[83] = pointAttr.Log_del_lolo;
            fileds[84] = pointAttr.Log_gen_hi;
            fileds[85] = pointAttr.Log_gen_hihi;
            fileds[86] = pointAttr.Log_gen_lo;
            fileds[87] = pointAttr.Log_gen_lolo;
            fileds[88] = pointAttr.Log_reset_hi;
            fileds[89] = pointAttr.Log_reset_hihi;
            fileds[90] = pointAttr.Log_reset_lo;
            fileds[91] = pointAttr.Log_reset_lolo;
            fileds[92] = pointAttr.Max_stacked;
            fileds[93] = pointAttr.Measurement_unit_id;
            fileds[94] = pointAttr.Misc_flags;
            fileds[95] = pointAttr.Poll_after_set;
            fileds[96] = pointAttr.Precision;
            fileds[97] = pointAttr.Proc_id;
            fileds[98] = pointAttr.Ptmgmt_proc_id;
            fileds[99] = pointAttr.Pt_enabled;
            fileds[100] = pointAttr.Pt_origin;
            fileds[101] = pointAttr.Pt_set_interval;
            fileds[102] = pointAttr.Pt_set_time;
            fileds[103] = pointAttr.Pt_type;
            fileds[104] = pointAttr.Range_high;
            fileds[105] = pointAttr.Range_low;
            fileds[106] = pointAttr.Raw_lim_high;
            fileds[107] = pointAttr.Raw_lim_low;
            fileds[108] = pointAttr.Rep_timeout_hi;
            fileds[109] = pointAttr.Rep_timeout_hihi;
            fileds[110] = pointAttr.Rep_timeout_lo;
            fileds[111] = pointAttr.Rep_timeout_lolo;
            fileds[112] = pointAttr.Reset_allowed_hi;
            fileds[113] = pointAttr.Reset_allowed_hihi;
            fileds[114] = pointAttr.Reset_allowed_lo;
            fileds[115] = pointAttr.Reset_allowed_lolo;
            fileds[116] = pointAttr.Reset_cond;
            fileds[117] = pointAttr.Reset_pt;
            fileds[118] = pointAttr.Reset_timeout_hi;
            fileds[119] = pointAttr.Reset_timeout_hihi;
            fileds[120] = pointAttr.Reset_timeout_lo;
            fileds[121] = pointAttr.Reset_timeout_lolo;
            fileds[122] = pointAttr.Resource_id;
            fileds[123] = pointAttr.Rev_conv_eq;
            fileds[124] = pointAttr.Rollover_val;
            fileds[125] = pointAttr.Safety_pt;
            fileds[126] = pointAttr.Sample_intv;
            fileds[127] = pointAttr.Sample_intv_unit;
            fileds[128] = pointAttr.Scan_rate;
            fileds[129] = pointAttr.Setpoint_high;
            fileds[130] = pointAttr.Setpoint_low;
            fileds[131] = pointAttr.Time_of_day;
            fileds[132] = pointAttr.Trig_ck_pt;
            fileds[133] = pointAttr.Trig_pt;
            fileds[134] = pointAttr.Trig_rel;
            fileds[135] = pointAttr.Trig_val;
            fileds[136] = pointAttr.Uafset;
            fileds[137] = pointAttr.Update_criteria;
            fileds[138] = pointAttr.Variance_val;
            fileds[139] = pointAttr.Vars;
        }

        private int findFiledIndex(string filedName)
        {
            int result = -1;
            for (int i = 0; i < fileds.Length; i++)
            {
                if (filedName == fileds[i])
                {
                    result = i;
                    break;
                }
            }
            return result;
        }
    }
}
