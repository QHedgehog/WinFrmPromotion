using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmPromotion
{
    public partial class 测试开始暂停停止 : Form
    {
        public 测试开始暂停停止()
        {
            InitializeComponent();
        }
        private CancellationTokenSource TokenSource;
        private ManualResetEvent ManualReset;
        private void btnStart_Click(object sender, EventArgs e)
        {
            //CancellationTokenSource:则是外部对Task的控制，如取消、定时取消
            //当一个任务超过了我们所设定的时间然后自动取消该任务的执行TokenSource = new CancellationTokenSource(5000);
            TokenSource = new CancellationTokenSource();
            ManualReset = new ManualResetEvent(true);
            int index = 0;
            Task.Run(()=> 
            {
                while (!TokenSource.Token.IsCancellationRequested)
                {
                    ManualReset.WaitOne();
                    Thread.Sleep(1000);
                    index = index + 1;
                    InvokeAppendLine($"线程ID是{Environment.CurrentManagedThreadId},这是第{index}次循环扫描");
                }
            }, TokenSource.Token);
        }

        private void 测试开始暂停停止_Load(object sender, EventArgs e)
        {

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

        private void btnSuspend_Click(object sender, EventArgs e)
        {
            ManualReset?.Reset();
        }

        private void btnContinue_Click(object sender, EventArgs e)
        {
            ManualReset?.Set();
        }
        private void btnStop_Click(object sender, EventArgs e)
        {
            TokenSource?.Cancel();
        }
    }

  
}
