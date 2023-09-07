using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading.Tasks.Dataflow;
using System.Diagnostics;
using Octokit;
using log4net;
using System.Reflection;

namespace WinFrmPromotion
{
    public partial class 属性控件 : Form
    {
        public 属性控件()
        {
            InitializeComponent();

        }


        /// <summary>
        /// 不需要同步，非并发代码
        /// </summary>
        /// <returns></returns>
        private async Task TestSyncAsync()
        {
            int val = 10;
            await Task.Delay(TimeSpan.FromSeconds(1));
            val = val + 1;
            await Task.Delay(TimeSpan.FromSeconds(1));
            val = val - 1;
            await Task.Delay(TimeSpan.FromSeconds(1));
            Trace.WriteLine(val);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 【1】Log4的nuget包应用

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        this.listBox1.BeginInvoke(new Action(() =>
            //        {
            //            string info = $"{DateTime.Now.ToString("MM:dd:HH：mm：sss.ffff")}信息提示是OK的";
            //            this.listBox1.ForeColor = Color.Green;
            //            this.listBox1.Items.Add(info);//写到主界面上的显示
            //            Logger.WriteInfo(info);//写成本地Log
            //            Trace.WriteLine(info);//写到调试的输出窗口
            //        }));
            //    }
            //});
            #endregion

            #region 【2】属性控件和特性的结合应用

            RunStation _runStation = new RunStation();
            this.propertyGrid1.SelectedObject = _runStation;
            #endregion
        }

    }
    public class RunStation
    {
        [Category("A工位"), Description("产品SN"), ReadOnly(false)]
        public string SerialNum { get; set; } = "123";

        private string _name = "deraf";
        [Category("外观"), Description("位置"), ReadOnly(false)]
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        [Category("其他"), Description("字体")]
        public Font UseFont { get; set; }

        [Category("其他")]
        [Description("颜色")]
        public Color UseColor { get; set; }
    }

}
