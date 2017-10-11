using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PMCPointTool
{
    public partial class MainForm : Form
    {

        /// <summary>
        /// 事件管理器
        /// </summary>
        FormEvent fromEvent;

        /// <summary>
        /// 事件委托
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="eventName"></param>
        public delegate void TriggerEventHandler(object sender, MyEventArgs e, string eventName);

        /// <summary>
        /// 事件
        /// </summary>
        public event TriggerEventHandler triggerEvent;

        public MainForm()
        {
            InitializeComponent();
            init();
        }

        private void init()
        {
            //窗体样式
            this.Text = Constant.APP_NAME + " v" + Constant.APP_VERSION;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            //注册界面处理事件
            fromEvent = new MainController(this);
            this.triggerEvent += new TriggerEventHandler(fromEvent.triggerEvent);

            //初始化控件
            this.progressBar1.Visible = false;
            this.panel1.AutoScroll = true;

            this.comboxPointType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboxPointType.Items.Add(Constant.POINT_TYPE_ALARM);
            this.comboxPointType.Items.Add(Constant.POINT_TYPE_PROD);
            this.comboxPointType.Items.Add(Constant.POINT_TYPE_NOT_PROD);
            this.comboxPointType.Text = comboxPointType.Items[0].ToString();

            this.comboxPLCType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboxPLCType.Items.Add(Constant.PLC_TYPE_AB);
            this.comboxPLCType.Items.Add(Constant.PLC_TYPE_SIEMENS);
            this.comboxPLCType.Text = comboxPLCType.Items[0].ToString();

            this.comboxTIP.DropDownStyle = ComboBoxStyle.DropDownList;

            this.comboxABType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.comboxABType.Items.Add(Constant.PLC_AB_ADDR_ARRAY_ALARM);
            this.comboxABType.Items.Add(Constant.PLC_AB_ADDR_N200);
            this.comboxABType.Text = comboxABType.Items[0].ToString();

            this.picBoxOpenFile.Visible = false;

            //更新状态
            updateStatus("选择了 " + this.comboxPointType.Text);
        }

        #region 公共函数

        public BackgroundWorker getBgdWorker()
        {
            return this.backgroundWorker1;
        }

        public ProgressBar getProgressBar()
        {
            return this.progressBar1;
        }

        public ComboBox getPointTypeComboBox()
        {
            return this.comboxPointType;
        }

        public Label getLableStatus()
        {
            return this.lblStatus;
        }

        public void startProgressBar(int maxValue)
        {
            if (maxValue < 0) return;
            if (this.InvokeRequired) //跨线程调用UI控件
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.progressBar1.Visible = true;
                    this.progressBar1.Maximum = maxValue;
                }));
            }
            else
            {
                this.progressBar1.Visible = true;
                this.progressBar1.Maximum = maxValue;
            }
        }

        public void stopProgressBar()
        {
            if (this.InvokeRequired) //跨线程调用UI控件
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.progressBar1.Visible = false;
                    this.progressBar1.Value = 0;
                }));
            }
            else
            {
                this.progressBar1.Visible = false;
                this.progressBar1.Value = 0;
            }
        }

        public void updateProgressBar(int progressValue, string status)
        {
            if (this.InvokeRequired) //跨线程调用UI控件
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.progressBar1.Value = progressValue;
                    this.lblStatus.Text = status;
                }));
            }
            else
            {
                this.progressBar1.Value = progressValue;
                this.lblStatus.Text = status;
            }
        }

        public void updateStatus(string s)
        {
            if (this.InvokeRequired) //跨线程调用UI控件
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.lblStatus.Text = s;
                }));
            }
            else
            {
                this.lblStatus.Text = s;
            }
        }

        public int getComboBoxIndex()
        {
            int index = -1;
            if (this.InvokeRequired) //跨线程调用UI控件
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    index = this.comboxPointType.SelectedIndex;
                }));
            }
            else
            {
                index = this.comboxPointType.SelectedIndex;
            }
            return index;
        }

        public string getComboBoxText()
        {
            string s = "选择了 ";
            if (this.InvokeRequired) //跨线程调用UI控件
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    s = s + this.comboxPointType.Text;
                }));
            }
            else
            {
                s = s + this.comboxPointType.Text;
            }
            return s;
        }

        public void setGenerateButtenEnable(bool enable)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.btnGenerate.Enabled = enable;
                }));
            }
            else
            {
                this.btnGenerate.Enabled = enable;
            }
        }

        public void setReadConfigButtenEnable(bool enable)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.btnConfig.Enabled = enable;
                }));
            }
            else
            {
                this.btnConfig.Enabled = enable;
            }
        }

        public void setComboxTipVisible(bool visible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.comboxTIP.Visible = visible;
                }));
            }
            else
            {
                this.comboxTIP.Visible = visible;
            }
        }

        public void setPicBoxOutputFileVisible(bool visible)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    this.picBoxOpenFile.Visible = visible;
                }));
            }
            else
            {
                this.picBoxOpenFile.Visible = visible;
            }
        }

        /// <summary>
        /// 获取主界面控件对象
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public object getMainFormControl(string name)
        {
            object obj = null;
            Control.ControlCollection controls = this.Controls;

            for (int i = 0; i < controls.Count; i++)
            {
                if (controls[i].Name == name)
                {
                    obj = controls[i];
                    break;
                }
            }
            return obj;
        }

        #endregion

        #region 事件

        private void btnConfig_Click(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            this.triggerEvent(sender, args, "读取配置");
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            this.triggerEvent(sender, args, "生成文件");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            this.triggerEvent(sender, args, "取消");
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            this.triggerEvent(sender, args, "退出");
        }

        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            this.triggerEvent(sender, args, "关于");
        }

        private void comboxPLCType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            args.Paras = new object[2];
            args.Paras[0] = this.comboxPLCType.SelectedIndex;
            args.Paras[1] = this.comboxPLCType.Text;

            this.triggerEvent(sender, args, "选择了PLC类型");

            if (this.comboxPLCType.Text == Constant.PLC_TYPE_AB)
                this.comboxABType.Visible = true;
            else
                this.comboxABType.Visible = false;
        }

        private void comboxABType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            args.Paras = new object[2];
            args.Paras[0] = this.comboxABType.SelectedIndex;
            args.Paras[1] = this.comboxABType.Text;

            this.triggerEvent(sender, args, "选择了AB报警类型");
        }

        private void comboxPointType_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            args.Paras = new object[2];
            args.Paras[0] = this.comboxPointType.SelectedIndex;
            args.Paras[1] = this.comboxPointType.Text;

            this.triggerEvent(sender, args, "选择了点类型");

            //comboxTIP变化情况
            if (this.comboxPointType.Text == Constant.POINT_TYPE_NOT_PROD)
                this.comboxTIP.Visible = false;
            else
            {
                this.comboxTIP.Items.Clear();

                if (this.comboxPointType.Text==Constant.POINT_TYPE_PROD)
                {
                    this.comboxTIP.Items.Add(Constant.POINT_TYPE_TIP_NOT_CONTAIN);
                    this.comboxTIP.Items.Add(Constant.POINT_TYPE_TIP_CONTAIN);
                    this.comboxTIP.Items.Add(Constant.POINT_TYPE_TIP_JUST);
                }
                else
                {
                    this.comboxTIP.Items.Add(Constant.ALARM_START_ADDR_5);
                    this.comboxTIP.Items.Add(Constant.ALARM_START_ADDR_37);
                }

                this.comboxTIP.Text = comboxTIP.Items[0].ToString();
                this.comboxTIP.Visible = true;
            }
        }

        private void comboxTIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            MyEventArgs args = new MyEventArgs();
            args.Paras = new object[2];
            args.Paras[0] = this.comboxTIP.SelectedIndex;
            args.Paras[1] = this.comboxTIP.Text;

            this.triggerEvent(sender, args, "选择了TIP或报警类型");
        }

        private void picBoxOpenFile_Click(object sender, EventArgs e)
        {
            this.triggerEvent(sender, new MyEventArgs(), "打开输出路径");
        }

        #endregion

        
       
    }
}
