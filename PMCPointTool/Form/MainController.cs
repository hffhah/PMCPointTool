using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data;
using System.ComponentModel;

namespace PMCPointTool
{
    class MainController : FormEvent
    {
        private MainForm main;
        private List<Area> areas = new List<Area>();
        private DataTable dtStationInfo = new DataTable();
        private DataTable dtStationAlarm = new DataTable();
        private BasePoint pmcPoint;
        private BackgroundWorker bgdWorker;
        private InterfaceEnum interfaceType;

        private MainFormOperation mainFormOperation = new MainFormOperation();

        public MainController(MainForm main)
        {
            this.main = main;
            this.bgdWorker = main.getBgdWorker();
            registerWork(this.bgdWorker);
        }

        private void registerWork(BackgroundWorker bgdWorker)
        {
            bgdWorker.WorkerReportsProgress = true;
            bgdWorker.WorkerSupportsCancellation = true;

            bgdWorker.DoWork += new DoWorkEventHandler(DoWork);
            bgdWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
            bgdWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
        }

        private void DoWork(object sender, DoWorkEventArgs e)
        {
            string eventName = e.Argument.ToString();
            string status;
            bool outputFileVisible = false;

            switch (eventName)
            {
                case "读取配置":
                    this.main.setReadConfigButtenEnable(false);

                    if (readConfig(Global.CONFIG_PATH, out status))
                    {
                        if (string.IsNullOrEmpty(status))
                            status = "读取配置 ";

                        for (int i = 0; i < Global.CONFIG_PATH.Length; i++)
                        {
                            if (i < Global.CONFIG_PATH.Length - 1)
                                status += Global.CONFIG_PATH[i].Substring(Global.CONFIG_PATH[i].LastIndexOf("\\") + 1) + "、";
                            else
                                status += Global.CONFIG_PATH[i].Substring(Global.CONFIG_PATH[i].LastIndexOf("\\") + 1);
                        }
                        status += " 成功!";
                    }
                    else
                    {
                        status += ",读取失败!";
                        clearMemory();
                    }
                    this.main.updateStatus(status);

                    break;

                case "生成文件":
                    this.main.setGenerateButtenEnable(false);

                    if (generate(Global.OUTPUT_PATH, out status))
                    {
                        status = "生成文件成功,请去" + Global.OUTPUT_PATH + " 查看!";
                        outputFileVisible = true;
                    }
                    else
                    {
                        status = "生成文件失败," + status;
                        outputFileVisible = false;
                        clearMemory();
                    }
                    this.main.updateStatus(status);
                    this.main.setPicBoxOutputFileVisible(outputFileVisible);

                    break;

                default:
                    break;
            }
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            string status = "";
            int progressPercentage = e.ProgressPercentage;
            if (e.UserState is string)
                status = e.UserState.ToString();
            this.main.updateProgressBar(progressPercentage, status);
        }

        private void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopProgressBar();
            this.main.setGenerateButtenEnable(true);
            this.main.setReadConfigButtenEnable(true);
        }

        private void fillAreaDatasTest()
        {
            string areaName = "MC__";
            string plcName = "MC010_";
            string deviceId = "W103_UR___AB_UR020__0022";
            string stationName = "UR___SYUR020_";
            string resource = "UR___TLUR020_R";
            int stationNo = 1;
            int alarmNumber = 1;
            string alarmDetail = "报警测试...";

            AlarmDetail ad = new AlarmDetail();
            ad.Number = alarmNumber;
            ad.Detail = alarmDetail;

            Station s = new Station();
            s.Number = stationNo;
            s.Name = stationName;
            s.ResourceId = resource;
            s.AlarmDetails.Add(ad);

            PLC plc = new PLC();
            plc.Name = plcName;
            plc.DeviceId = deviceId;
            plc.Stations.Add(s);

            Area area = new Area();
            area.Name = areaName;
            area.Plcs.Add(plc);
            this.areas.Add(area);
        }

        private void fillAreaDatas(List<Area> areas, DataTable dtStationInfo, DataTable dtStationAlarm)
        {
            int dtStationInfoRows = dtStationInfo.Rows.Count;
            int dtStationAlarmRows = 0;

            int progressMaxValue;
            if (null != dtStationAlarm)
            {
                dtStationAlarmRows = dtStationAlarm.Rows.Count;
                progressMaxValue = dtStationAlarmRows + dtStationInfoRows;
            }
            else
                progressMaxValue = dtStationInfoRows;

            startProgressBar(progressMaxValue);

            loadStationInfo(areas, dtStationInfo);

            loadStationAlarm(areas, dtStationAlarm, dtStationInfoRows, progressMaxValue);
        }

        private void loadStationAlarm(List<Area> areas, DataTable dtStationAlarm, int dtStationInfoRows, int progressMaxValue)
        {
            List<PLC> plcs = null;
            List<Station> stations = new List<Station>();
            List<AlarmDetail> alarmDetails = null;
            int rowNumberThisPlc = 1;    //当前plc报警详细数量行,初始带标题+1
            int rowNumbersAllPlc = 0;    //所有plc报警详细数量行累加之和,带标题

            Area area = null;
            PLC plc = null;
            Station station = null;
            AlarmDetail ad = null;

            bool readMultiPlcConfig = Global.isReadMultiAlarmConfig;
            int excelNumber = 0;


            if (null == dtStationAlarm || dtStationAlarm.Rows.Count == 0)
                return;

            string plcNamePrev = null;
            int stationNoPrev = -1;

            string[] fileds = new string[] { "PLC", "IP", "StationNo", "StationName", "AlarmId", "Description" };
            if (!checkTitle(dtStationAlarm, fileds, 6))
                throw new MyException(Constant.CONFIG_STATION_ALARM + "标题不符合要求!");

            //2017/9/30
            if (dtStationAlarm.Rows.Count == 0)
                throw new MyException(Constant.CONFIG_STATION_ALARM + "读取数据为空,请检查Sheet名是否为" + Constant.SHEET_NAME);

            //dtStationAlarm.Rows.Count 总数量不带标题
            for (int m = 0; m < dtStationAlarm.Rows.Count; m++)
            {
                string plcName = dtStationAlarm.Rows[m]["PLC"].ToString().Trim();
                string sStationNo = dtStationAlarm.Rows[m]["StationNo"].ToString().Trim();
                string sAlarmIdConfig1 = dtStationAlarm.Rows[m]["AlarmId"].ToString().Trim();
                string alarmDetail = dtStationAlarm.Rows[m]["Description"].ToString().Trim();
                int stationNo = -1;
                int result = -1;
                bool flag;

                //获取plcName,不切换plc时
                if (string.IsNullOrEmpty(plcName))   //支持多PLC在一个配置文件中 2017/9/21
                {
                    if (!string.IsNullOrEmpty(plcNamePrev))
                    {
                        plcName = plcNamePrev;
                    }
                    rowNumberThisPlc++;
                }
                else
                    rowNumberThisPlc = (readMultiPlcConfig == true ? 2 : 1);

                //设置Excel号
                rowNumbersAllPlc = m + 1 + 1;    //序号+1,标题+1
                excelNumber = (readMultiPlcConfig == true ? rowNumberThisPlc : rowNumbersAllPlc);

                //获取stationNo
                if (!string.IsNullOrEmpty(sStationNo))
                {
                    result = -1;
                    flag = int.TryParse(sStationNo, out result);
                    if (!flag)
                        throw new MyException(Constant.CONFIG_STATION_ALARM + "文件中配置了错误的StationNo。Excel行号=" + excelNumber + ",plcName=" + plcName);

                    stationNo = result;
                }
                else
                {
                    if (stationNoPrev > 0)
                        stationNo = stationNoPrev;
                }

                //获取alarmId
                if (!sAlarmIdConfig1.ToUpper().Contains("ALARM"))
                    throw new MyException(Constant.CONFIG_STATION_ALARM + "文件中配置了错误的AlarmId。Excel行号=" + excelNumber + ",AlarmId=" + sAlarmIdConfig1 + ",plcName=" + plcName);

                sAlarmIdConfig1 = sAlarmIdConfig1.Replace("ALARM", "");
                string sAlarmIdConfig2 = OtherUtils.getStringBetweenBracket(sAlarmIdConfig1);

                flag = int.TryParse(sAlarmIdConfig2, out result);

                if (!flag || result < Constant.ALARM_NUMBER_COUNT_MIN || result > Constant.ALARM_NUMBER_COUNT_MAX)
                    throw new MyException(Constant.CONFIG_STATION_ALARM + "文件中配置了错误的AlarmId。Excel行号=" + excelNumber + ",AlarmId=" + result + ",plcName=" + plcName);
                int alarmId = result;

                //对报警描述处理
                //仅支持80个字符。
                if (alarmDetail.Length > 80)
                    alarmDetail = alarmDetail.Substring(0, 79);

                //处理特殊字符
                List<string> specialChars = InterfaceFactory.getInstance(this.mainFormOperation,this.interfaceType).SpecialChar.specialChars;
                for (int i = 0; i < specialChars.Count; i++)
                {
                    if (alarmDetail.Contains(specialChars[i]))
                    {
                        alarmDetail = alarmDetail.Replace(specialChars[i], "");
                        OtherUtils.writeMsgByByte(Constant.LOG_PATH, "检测到报警描述中含有特殊字符=" + specialChars[i] + ",已经删除。Excel行号=" + excelNumber + ",AlarmId=" + alarmId + ",plcName=" + plcName);
                    }
                }

                bool noPlcExist = true;

                if (!string.IsNullOrEmpty(sStationNo))
                {
                    for (int n = 0; n < areas.Count; n++)
                    {
                        area = areas[n];
                        plcs = areas[n].Plcs;
                        for (int o = 0; o < plcs.Count; o++)
                        {
                            if (plcName == plcs[o].Name)
                            {
                                noPlcExist = false;

                                plc = plcs[o];
                                stations = plc.Stations;
                                for (int p = 0; p < stations.Count; p++)
                                {
                                    if (stations[p].Number == stationNo)         //两个配置文件中的工位号必须保持一致
                                    {
                                        station = stations[p];
                                        alarmDetails = station.AlarmDetails;     //直接操作了areas里的AlarmDetails
                                        ad = getAlarmDetail(alarmId, alarmDetail);
                                        alarmDetails.Add(ad);
                                        break;
                                    }
                                }
                                break;
                            }
                        }
                    }

                    if (noPlcExist)
                        throw new MyException(Constant.CONFIG_STATION_ALARM + "文件中无匹配的PLC存在。Excel行号=" + excelNumber + ",plcName=" + plcName);

                    plcNamePrev = plcName;
                    stationNoPrev = stationNo;
                }
                else
                {
                    //配置文件中的报警号=当前工位号,否则不加入
                    if (stationNo == station.Number)
                    {
                        ad = getAlarmDetail(alarmId, alarmDetail);
                        alarmDetails.Add(ad);
                    }
                }

                //判断退出之前更新进度条
                int progressVlaue = dtStationInfoRows + m + 1;
                reportProcess(progressVlaue, "读取station alarm中... area=" + area.Name + ",plcName=" + plc.Name + ",station=" + station.Name + "alarmId=" + alarmId + ",alarm=" + alarmDetail + ",Excel行号=" + excelNumber);

                //最后一行退出
                if (m == dtStationAlarm.Rows.Count - 1)
                {
                    if (this.main.getProgressBar().Value < progressMaxValue)
                        this.main.stopProgressBar();
                    return;
                }

                //判断空行
                string plcNameNext = dtStationAlarm.Rows[m + 1]["PLC"].ToString().Trim();
                string sStationNoNext = dtStationAlarm.Rows[m + 1]["StationNo"].ToString().Trim();
                string sAlarmIdNext = dtStationAlarm.Rows[m + 1]["AlarmId"].ToString().Trim();
                string alarmDetailNext = dtStationAlarm.Rows[m + 1]["Description"].ToString().Trim();

                if (string.IsNullOrEmpty(sAlarmIdNext) && string.IsNullOrEmpty(alarmDetailNext))
                    throw new MyException(Constant.CONFIG_STATION_ALARM + "文件中包含空行。Excel行号=" + (rowNumberThisPlc + 1) + ",plcName=" + plcName);

            }
        }

        private void loadStationInfo(List<Area> areas, DataTable dtStationInfo)
        {
            List<Station> stations = new List<Station>();
            Area area = null;
            PLC plc = null;
            Station station = null;

            string[] fileds = new string[] { "Area", "PLC", "StationNo", "StationName", "ResourceId", "DeviceId", "IsFilter", "IsProdStation" };
            if (!checkTitle(dtStationInfo, fileds, 8))
                throw new MyException(Constant.CONFIG_STATION_INFO + "标题不符合要求!");

            if (dtStationInfo.Rows.Count == 0)
                throw new MyException(Constant.CONFIG_STATION_INFO + "读取数据为空,请检查Sheet名是否为" + Constant.SHEET_NAME);

            for (int i = 0; i < this.dtStationInfo.Rows.Count; i++)
            {
                string areaName = dtStationInfo.Rows[i]["Area"].ToString().Trim();
                string stationNo = dtStationInfo.Rows[i]["StationNo"].ToString().Trim();
                string stationName = dtStationInfo.Rows[i]["StationName"].ToString().Trim();
                string resourceId = dtStationInfo.Rows[i]["ResourceId"].ToString().Trim();
                string sIsFilterStation = dtStationInfo.Rows[i]["IsFilter"].ToString().Trim();
                string sIsProdStation = dtStationInfo.Rows[i]["IsProdStation"].ToString().Trim();

                bool isFilterStation = false; //默认为false
                bool isProdStation = false; //默认为false

                if (sIsFilterStation.Trim().ToUpper() == "TRUE")
                    isFilterStation = true;
                if (sIsProdStation.Trim().ToUpper() == "TRUE")
                    isProdStation = true;

                int result = -1;
                bool flag = int.TryParse(stationNo, out result);

                if (!flag)
                    throw new MyException(Constant.CONFIG_STATION_INFO + "文件中配置了错误的StationNo.Excel行号=" + (i + 2) + ",StationNo=" + stationNo); ////标题行+从0开始+本行

                station = generateStation(result, stationName, resourceId, isFilterStation, isProdStation);

                if (!string.IsNullOrEmpty(areaName))
                {
                    area = getArea(this.areas, areaName);
                    area.Name = areaName;

                    plc = new PLC();
                    string plcName = dtStationInfo.Rows[i]["PLC"].ToString().Trim();
                    string deviceId = dtStationInfo.Rows[i]["DeviceId"].ToString().Trim();
                    string isFilterDevice = dtStationInfo.Rows[i]["IsFilter"].ToString().Trim();

                    if (string.IsNullOrEmpty(plcName) || string.IsNullOrEmpty(deviceId) || string.IsNullOrEmpty(isFilterDevice) || string.IsNullOrEmpty(stationNo) || string.IsNullOrEmpty(stationName))
                        throw new MyException(Constant.CONFIG_STATION_INFO + "文件中配置了空的PLC、DeviceId、IsFilter、StationNo、StationName.Excel行号=" + (i + 2));
                    else
                    {
                        plc.Name = plcName;
                        plc.DeviceId = deviceId;
                        bool bResult;
                        flag = bool.TryParse(isFilterDevice, out bResult);
                        if (!flag)
                            throw new MyException(Constant.CONFIG_STATION_INFO + "文件中配置了错误的IsFilter.Excel行号=" + (i + 2) + ",IsFilter=" + bResult);
                        plc.IsFilter = bResult;
                    }
                }
                //过滤设置
                if (!plc.IsFilter)
                {
                    if (!station.IsFilter)
                        stations.Add(station);
                }

                //最后一行
                if (i == dtStationInfo.Rows.Count - 1)
                {
                    //加入PLC
                    plc.Stations = stations;
                    if (!plc.IsFilter)
                        area.Plcs.Add(plc);

                    //加入Area
                    if (!existArea(area.Name))
                        areas.Add(area);
                    break;
                }

                //判断下一个PLC
                string areaNameNext = dtStationInfo.Rows[i + 1]["Area"].ToString().Trim();
                string stationNoNext = dtStationInfo.Rows[i + 1]["StationNo"].ToString().Trim();
                string stationNameNext = dtStationInfo.Rows[i + 1]["StationName"].ToString().Trim();
                string resourceIdNext = dtStationInfo.Rows[i + 1]["ResourceId"].ToString().Trim();

                if (!string.IsNullOrEmpty(areaNameNext))
                {
                    //加入PLC
                    plc.Stations = stations;
                    if (!plc.IsFilter)
                        area.Plcs.Add(plc);

                    //加入Area
                    if (!existArea(area.Name))
                        areas.Add(area);

                    stations = new List<Station>();
                }

                //判断空行
                if (string.IsNullOrEmpty(stationNoNext) && string.IsNullOrEmpty(stationNameNext) && string.IsNullOrEmpty(resourceIdNext))
                    throw new MyException(Constant.CONFIG_STATION_INFO + "文件中包含空行。Excel行号=" + (i + 3));  //下一行


                //进度条
                int progressVlaue = i + 1;
                reportProcess(progressVlaue, "读取station info中... area=" + area.Name + ",plc=" + plc.Name + ",station=" + station.Name + ",行号=" + (i + 2));
            }
        }

        private AlarmDetail getAlarmDetail(int alarmId, string detail)
        {
            AlarmDetail alarmDetail = new AlarmDetail();
            alarmDetail.Number = alarmId;
            alarmDetail.Detail = detail;
            return alarmDetail;
        }

        /// <summary>
        /// 生成一个station对象
        /// </summary>
        /// <param name="stationNo"></param>
        /// <param name="stationName"></param>
        /// <param name="resourceId"></param>
        /// <param name="isFilter"></param>
        /// <param name="isProdStation"></param>
        /// <returns></returns>
        private Station generateStation(int stationNo, string stationName, string resourceId, bool isFilter, bool isProdStation)
        {
            Station station = new Station();
            station.Number = stationNo;
            station.Name = stationName;
            station.ResourceId = resourceId;
            station.IsFilter = isFilter;
            station.IsProdStation = isProdStation;

            return station;
        }

        /// <summary>
        /// 从成员变量areas中获取area
        /// </summary>
        /// <param name="areaName"></param>
        /// <returns></returns>
        private Area getArea(List<Area> areas, string areaName)
        {
            Area area = null;

            int k = 0;
            for (int j = 0; j < areas.Count; j++)
            {
                if (areas[j].Name != areaName)
                    k++;
                else
                {
                    area = areas[j];
                    break;
                }
            }

            if (k == areas.Count)
                area = new Area();
            return area;
        }

        private bool existArea(string areaName)
        {
            bool exist = false;
            for (int j = 0; j < areas.Count; j++)
            {
                if (areas[j].Name == areaName)
                {
                    exist = true;
                    break;
                }
            }
            return exist;
        }

        private bool readConfig(string[] path, out string errorString)
        {
            errorString = "";
            bool flag = false;
            int configCount = path.Length;
            int multiAlarmConfig = 0;

            try
            {
                //开启进度条
                startProgressBar(configCount);

                for (int i = 0; i < configCount; i++)
                {
                    DataTable dt = FileUtils.readExcelByOleDb(path[i], Constant.SHEET_NAME, true);
                    // DataTable dt = FileUtils.readExcelByCom(path[i], 1, "", true);
                    string status = "";
                    string filaName = path[i].Substring(path[i].LastIndexOf("\\") + 1);

                    if (path[i].Contains(Constant.CONFIG_STATION_INFO))
                    {
                        this.dtStationInfo = dt;
                        flag = true;
                        status = "读取" + filaName + "中...";
                    }
                    else if (path[i].Contains(Constant.CONFIG_STATION_ALARM))
                    {
                        //支持一个station_info文件,多个station_alarm文件的读取。
                        //若仅读取一个station_alarm,则以最后读取的有效。
                        if (configCount == 1)
                        {
                            if (this.dtStationAlarm.Rows.Count > 0)
                            {
                                this.dtStationAlarm.Clear();
                            }
                        }

                        this.dtStationAlarm.Merge(dt, true, MissingSchemaAction.Add);  //若发现列架构不一致,则默认增加
                        flag = true;
                        multiAlarmConfig++;
                        status = "读取" + filaName + "中...";
                    }
                    reportProcess(i + 1, status);
                }

                if (multiAlarmConfig > 1)
                    Global.isReadMultiAlarmConfig = true;
                else
                    Global.isReadMultiAlarmConfig = false;

            }
            catch (ArgumentNullException ex)
            {
                flag = false;
                errorString = ex.Message + ",请检查表名是否为" + Constant.SHEET_NAME;
                OtherUtils.writeMsgByByte(Constant.LOG_PATH, ex.ToString());
            }
            catch (Exception e)
            {
                flag = false;
                errorString = e.Message;
                OtherUtils.writeMsgByByte(Constant.LOG_PATH, e.ToString());
            }
            finally
            {
                //手动关闭进度条
                if (this.main.getProgressBar().Value == this.main.getProgressBar().Maximum)
                    stopProgressBar();
            }

            return flag;
        }

        private bool generate(string path, out string result)
        {
            result = "";
            bool flag = false;
            string errString = null;

            try
            {
                if (this.dtStationAlarm.Rows.Count <= Constant.CONFIG_ALARM_DETAILS_MAX)
                    fillAreaDatas(this.areas, this.dtStationInfo, this.dtStationAlarm);
                else
                {
                    //当条数超过大约9000条后,this.mian对象被释放,导致后续状态错误,所以必须限制。+时间开发。
                    result = Constant.CONFIG_STATION_ALARM + "超过了" + Constant.CONFIG_ALARM_DETAILS_MAX + "条,生成点文件受限,解锁限制请联系管理员!";
                    return false;
                }

                if (null == this.pmcPoint)
                    this.pmcPoint = getPMCPointDataType(this.mainFormOperation.Point_type);

                DataTable dt = pmcPoint.generateCSVData(areas);

                if (null != dt)
                {
                    //进度条
                    string status = "生成文件中...";
                    startProgressBar(5);

                    setProgressBarValue(1, status);
                    object[,] obj = OtherUtils.convertDataTabelToArray(dt);

                    setProgressBarValue(2, status);
                    flag = FileUtils.createExcel(obj, Excel.XlFileFormat.xlCSV, path, out errString);

                    setProgressBarValue(4, status);

                    if (!flag)
                        MessageBox.Show(errString);
                    stopProgressBar();

                    flag = true;
                }
            }
            catch (Exception e)
            {
                flag = false;
                result = e.Message;
                OtherUtils.writeMsgByByte(Constant.LOG_PATH, result + "\r\n" + e.ToString());
            }
            finally
            {
                clearMemory();
            }
            return flag;
        }

        private void clearMemory()
        {
            if (null == this.areas || this.areas.Count > 0)
                this.areas = new List<Area>();

            if (null != this.pmcPoint)
                this.pmcPoint = null;

            //生成一次点文件,清空一次dtStationAlarm,否则再次读取的时候讲出现一些冗余信息。
            if (this.dtStationAlarm.Rows.Count > 0)
                this.dtStationAlarm.Clear();
        }

        private void cancel()
        {

        }

        private void exit()
        {
            this.main.Close();
            this.main.Dispose();
            Application.Exit();
        }

        private void about()
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.StartPosition = FormStartPosition.CenterParent;

            DialogResult dr = aboutForm.ShowDialog();
        }

        private void setPlcAddrType(string plcAddrType)
        {
            if (plcAddrType == Constant.PLC_AB_ADDR_ARRAY_ALARM)
            {
                Global.PLC_ADDR_TYPE_ALARM = Constant.PLC_AB_ADDR_ARRAY_ALARM;
                Global.PLC_ADDR_TYPE_PROD = Constant.PLC_AB_ADDR_ARRAY_PROD;
            }
            else
            {
                Global.PLC_ADDR_TYPE_ALARM = Constant.PLC_AB_ADDR_N200;
                Global.PLC_ADDR_TYPE_PROD = Constant.PLC_AB_ADDR_N201;
            }
        }

        private void openOutputPath(string path)
        {
            if (System.IO.File.Exists(path))
            {
                //path = path.Substring(0, path.LastIndexOf("\\") + 1);
                //System.Diagnostics.Process.Start(path);
                System.Diagnostics.Process.Start("Explorer.exe", "/select," + path);  //2017/9/30
            }
            else
                this.main.updateStatus("输出路径: " + Global.OUTPUT_PATH + " 是非法路径！");
        }

        private BasePoint getPMCPointDataType(string pointType)
        {
            BasePoint pmcPoint = null;
            switch (pointType)
            {
                case Constant.POINT_TYPE_ALARM:
                    pmcPoint = new AlarmPoint(this, this.mainFormOperation, this.interfaceType);
                    break;
                case Constant.POINT_TYPE_PROD:
                    pmcPoint = new ProdStationPoint(this, this.mainFormOperation, this.interfaceType);
                    break;
                case Constant.POINT_TYPE_NOT_PROD:
                    pmcPoint = new NotProdStationPoint(this, this.mainFormOperation, this.interfaceType);
                    break;
                default:
                    break;
            }

            return pmcPoint;
        }

        private bool checkTitle(DataTable dt, string[] fileds, int filedLength)
        {
            bool flag = true;

            DataColumnCollection Columns = dt.Columns;
            string[] colNames = new string[filedLength];

            for (int i = 0; i < colNames.Length; i++)   //2017/9/26
                colNames[i] = dt.Columns[i].ToString();

            if (fileds.Length == colNames.Length)
            {
                for (int j = 0; j < fileds.Length; j++)
                {
                    if (fileds[j] != colNames[j])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else
                flag = false;

            return flag;
        }

        private void setInterfaceType(MainFormOperation mainFormOperation)
        {
            switch (mainFormOperation.Plc_type)
            {
                case Constant.PLC_TYPE_AB:
                    this.interfaceType = InterfaceEnum.AB;
                    break;
                case Constant.PLC_TYPE_SIEMENS:
                    this.interfaceType = InterfaceEnum.SIEMENS;
                    break;
                default:
                    break;
            }
        }

        #region 公共函数

        public void startProgressBar(int maxValue)
        {
            this.main.startProgressBar(maxValue);
        }

        public void stopProgressBar()
        {
            this.main.stopProgressBar();
        }

        public void setProgressBarValue(int val, string status)
        {
            this.main.updateProgressBar(val, status);
        }

        public void reportProcess(int percentProgress, object userState)
        {
            this.bgdWorker.ReportProgress(percentProgress, userState);
            //System.Threading.Thread.Sleep(1);//等待视图更新
        }

        #endregion

        public override void triggerEvent(object sender, MyEventArgs e, string eventName)
        {
            switch (eventName)
            {
                case "读取配置":
                    string[] path = FileUtils.getExcelPathByOfdlg();
                    if (null == path) break;

                    Global.CONFIG_PATH = path;

                    if (!this.bgdWorker.IsBusy)
                    {
                        this.bgdWorker.RunWorkerAsync(eventName);
                    }

                    break;

                case "生成文件":
                    if (null == this.dtStationInfo || this.dtStationInfo.Rows.Count == 0)
                    {
                        this.main.updateStatus("请先读取配置文件:" + Constant.CONFIG_STATION_INFO + ",检查Sheet名是否为" + Constant.SHEET_NAME);
                        return;
                    }

                    Global.OUTPUT_PATH = FileUtils.getSaveDlgPath();

                    if (string.IsNullOrEmpty(Global.OUTPUT_PATH)) break;

                    if (!this.bgdWorker.IsBusy)
                        this.bgdWorker.RunWorkerAsync(eventName);
                    else
                        this.main.updateStatus("选择的输出路径为 空!");

                    break;

                case "取消":
                    cancel();
                    break;

                case "退出":
                    exit();
                    break;

                case "关于":
                    about();
                    break;

                case "选择了PLC类型":
                    this.mainFormOperation.Plc_type = e.Paras[1].ToString();
                    setInterfaceType(this.mainFormOperation);

                    break;

                case "选择了AB报警类型":
                    this.mainFormOperation.Plc_addr_type = e.Paras[1].ToString();
                    setPlcAddrType(this.mainFormOperation.Plc_addr_type);

                    break;

                case "选择了点类型":
                    this.mainFormOperation.Point_type = e.Paras[1].ToString();
                    this.main.updateStatus("选择了 " + this.mainFormOperation.Point_type);

                    break;

                case "选择了TIP或报警类型":
                    this.mainFormOperation.Tip_type = e.Paras[1].ToString();
                    this.mainFormOperation.Alarm_start_addr = e.Paras[1].ToString();

                    break;

                case "打开输出路径":
                    openOutputPath(Global.OUTPUT_PATH);

                    break;
                default:
                    break;
            }
        }


    }
}
