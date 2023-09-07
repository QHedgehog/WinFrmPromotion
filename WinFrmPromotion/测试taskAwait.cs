using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace WinFrmPromotion
{
    public partial class 测试taskAwait : Form
    {
        public 测试taskAwait()
        {
            InitializeComponent();
        }
        private readonly StringBuilder strResult = new StringBuilder();
        private void btnRun_Click(object sender, EventArgs e)
        {
            strResult.Clear();
            Stopwatch sw = Stopwatch.StartNew();
            strResult.AppendLine($"{(chkAwait.Checked ? "await等待" : "No await")}，ConfigureAwait={chkConfigureAwait.Checked}\r\n{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】主线程开始运行   ");
            childMethodAsync();
            strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】主线程开始等待");
            //var res = Task.Run(async () =>//主线程task.dela不会等待，只有在获取其结果的时候会阻塞等到子线程完成
            //  {
            //      await Task.Delay(3000);
            //      return true ;
            //  }).Result;

            Thread.Sleep(3000);
            strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】主线程等待结束");
            sw.Stop();
            strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】主线程共用时{sw.ElapsedMilliseconds}ms");
            MessageBox.Show("运行结束", "提示", MessageBoxButtons.YesNo);
            InvokeAppendLine(strResult.ToString());
        }
        private async void childMethodAsync()
        {
            strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】childMethod开始运行");
            Stopwatch sw = Stopwatch.StartNew();
            if (chkAwait.Checked)
            {
                await Task.Run(/*async*/ () =>
               {
                   strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】子线程开始等待");
                   Thread.Sleep(2000);//task.delay是异步延迟（不会等延时完成就会执行后续代码），thread.sleep是同步延迟
                   //await Task.Delay(2000);
                   strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】子线程延时2000ms结束");
               }).ConfigureAwait(chkConfigureAwait.Checked);
            }
            else
            {
                Task.Run(() =>
               {
                   strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】子线程开始等待");
                   Thread.Sleep(2000);
                   strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】子线程延时2000ms结束");
               }).ConfigureAwait(chkConfigureAwait.Checked);
            }
            sw.Stop();
            strResult.AppendLine($"{DateTime.Now.ToString("HH:mm:ss:fff")}--->【{Environment.CurrentManagedThreadId}】childMethod共用时{sw.ElapsedMilliseconds}ms");

        }
        private void InvokeAppendLine(string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                txtResult.AppendText(string.IsNullOrEmpty(txtResult.Text) ? str : $"{Environment.NewLine + str}");
                txtResult.ScrollToCaret();
                txtResult.Refresh();
            }));
        }

        private void 测试taskAwait_Load(object sender, EventArgs e)
        {

        }
    }
}
