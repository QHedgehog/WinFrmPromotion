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
    public partial class FrmBackgroundWorker : Form
    {


        public FrmBackgroundWorker()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox2.Clear();
            this.button2.Enabled = true;
            this.progressBar1.Maximum = 100;
            StartBackGroundWorker(this.backgroundWorker1);

        }
        private void button2_Click(object sender, EventArgs e)
        {

            CancelBackGroundWorker(this.backgroundWorker1);

        }

        /// <summary>
        /// 启动
        /// </summary>
        /// <param name="back"></param>
        private void StartBackGroundWorker(BackgroundWorker bgWorker)
        {

            ///WorkerReportsProgress,bool类型，指示BackgroundWorker是否可以报告进度更新
            //当该属性值为True是，将可以成功调用ReportProgress方法，否则将引发InvalidOperationException异常
            bgWorker.WorkerReportsProgress = true;
            bgWorker.WorkerSupportsCancellation = true;


            //DoWork
            //用于承载异步操作。当调用BackgroundWorker.RunWorkerAsync()时触发。
            //需要注意的是，由于DoWork事件内部的代码运行在非UI线程之上，所以在DoWork事件内部应避免于用户界面交互
            //而于用户界面交互的操作应放置在ProgressChanged和RunWorkerCompleted事件中。
            bgWorker.DoWork += Back_DoWork;


            //ProgressChanged
            //当调用BackgroundWorker.ReportProgress(int percentProgress)方式时触发该事件。
            //该事件的ProgressChangedEventArgs.ProgressPercentage属性可以接收来自ReportProgress方法传递的percentProgress参数值,ProgressChangedEventArgs.UserState属性可以接收来自ReportProgress方法传递的userState参数。
            bgWorker.ProgressChanged += Back_ProgressChanged;

            //RunWorkerCompleted
            //异步操作完成或取消时执行的操作，当调用DoWork事件执行完成时触发。
            //该事件的RunWorkerCompletedEventArgs参数包含三个常用的属性Error,Cancelled,Result。其中，Error表示在执行异步操作期间发生的错误；Cancelled用于判断用户是否取消了异步操作；Result属性接收来自DoWork事件的DoWorkEventArgs参数的Result属性值，可用于传递异步操作的执行结果。
            bgWorker.RunWorkerCompleted += Back_RunWorkerCompleted;

            bgWorker.RunWorkerAsync(Convert.ToInt32(textBox1.Text));

        }
        //取消
        private void CancelBackGroundWorker(BackgroundWorker bgWorker)
        {
            //CancellationPendingbool类型，指示应用程序是否已请求取消后台操作。
            //此属性通常放在用户执行的异步操作内部，用来判断用户是否取消执行异步操作。当执行BackgroundWorker.CancelAsync()方法时，该属性值将变为True。
            bgWorker.CancelAsync();
        }
        //backworke的完成事件
        private void Back_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                //do sonmething
            }
            //计算已经结束，需要禁用取消按钮。
            this.button2.Enabled = false;
            this.textBox2.Text = 0.ToString();
            this.progressBar1.Value = 0;

            //计算过程中的异常会被抓住，在这里可以进行处理。
            if (e.Error != null)
            {
                Type errorType = e.Error.GetType();
                switch (errorType.Name)
                {
                    case "ArgumentNullException":
                    case "MyException":
                        //do something.
                        break;
                    default:
                        //do something.
                        break;
                }
            }
        }

        //进度改变
        private void Back_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.textBox2.Text = progressBar1.Value.ToString();
        }

        //用于承载异步操作。当调用BackgroundWorker.RunWorkerAsync() 时触发。
        private void Back_DoWork(object sender, DoWorkEventArgs e)
        {
            int para = (int)e.Argument;
            BackgroundWorker bgWorker = (BackgroundWorker)sender;
            if (e.Argument == null)
            {
                return;
            }
            int sum = 0;
            for (int i = 0; i < 100; i++)
            {
                //CancellationPendingbool类型，指示应用程序是否已请求取消后台操作。
                //此属性通常放在用户执行的异步操作内部，用来判断用户是否取消执行异步操作。当执行BackgroundWorker.CancelAsync()方法时，该属性值将变为True。
                if (bgWorker.CancellationPending == true)
                {
                    e.Cancel = true;
                    break;
                }
                sum = sum + i;
                //报告操作进度。调用该方法后，将触发BackgroundWorker. ProgressChanged事件。
                //另外，该方法包含了一个int类型的参数percentProgress，用来表示当前异步操作所执行的进度百分比
                bgWorker.ReportProgress((i + 1));
                Thread.Sleep(200);

            }


        }


    }
}
