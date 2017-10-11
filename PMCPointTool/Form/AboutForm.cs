using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PMCPointTool
{
    public partial class AboutForm : Form
    {
        const string url = "http://www.s-ap.com/cn/";

        public AboutForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Text = "关于";
            this.lblDateTime.Text = @"2017-08";
            this.lblVersion.Text = Constant.APP_VERSION;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string users = this.linkLabel1.Text;
            string cc = "hffhah@126.com";
            string subject = "关于" + Constant.APP_NAME + "工具的反馈";
            string body = "我电脑的MAC地址：" + Computer.GetMacAddress();

            string sEmail = "mailto:" + users + "?cc=" + cc + "&subject=" + subject + "&body=" + body;
            System.Diagnostics.Process.Start(sEmail);
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }
    }
}
