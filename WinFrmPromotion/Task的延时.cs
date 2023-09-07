using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;
namespace WinFrmPromotion
{
    public partial class Task的延时 : Form
    {
        public Task的延时()
        {
            InitializeComponent();

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

        StringBuilder strBuilder = new StringBuilder();

        /// <summary>
        /// 【1】同步和异步延时的对比
        /// </summary>
        private void ContrastTest()
        {

            //阻塞，出现CPU等待...
            Task.Factory.StartNew(() =>
            {
                strBuilder.AppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ****** Start Sleep()******");
                for (int i = 1; i <= 10; i++)
                {
                    InvokeAppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + "******Sleep******==>" + i);
                    Thread.Sleep(1000);//同步延迟，阻塞一秒
                }
                InvokeAppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ******End Sleep()******");
            });

            //不阻塞
            Task.Factory.StartNew(() =>
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ======StartDelay()======");
                for (int i = 1; i <= 10; i++)
                {
                    InvokeAppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ======Delay====== ==>" + i);
                    Task.Delay(1000);//异步延迟
                }
                InvokeAppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ======End Delay()======");
            });
        }

        /// <summary>
        /// 【2】TaskDelay的使用
        /// </summary>
        private void TaskDelay()
        {
            //不阻塞
            Task.Factory.StartNew(async () =>
            {
                Console.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ======StartDelay()======");
                for (int i = 1; i <= 10; i++)
                {
                    InvokeAppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ======Delay====== ==>" + i);
                    await Task.Delay(1000);//异步延迟
                }
                InvokeAppendLine(DateTime.Now.ToString("HH:mm:ss.fff") + " ======End Delay()======");
            });

        }

        private void button1_Click(object sender, EventArgs e)
        {
            strBuilder.Clear();
            #region 【1】同步和异步延时的对比
            //ContrastTest();
            #endregion

            #region 【2】TaskDelay的使用
            //TaskDelay();
            #endregion

            #region 【3.】同步和异步等待方法
            //2种办法解决死锁：
            //【1】使用await关键字让其也成为一个异步方法使用ConfigureAwait默认是true
            //Task tsak = Task.Run(async () =>
            //{
            //    await asyncTaskAsync();
            //});

            Task tsk = asyncTaskAsync();//【2】使用ConfigureAwait(False)忽略该异步方法的上下文
            ////调用同步等待方法
            syncCode();
            tsk.Wait();//阻塞方法
            #endregion


            MessageBox.Show("运行结束", "提示", MessageBoxButtons.YesNo);
            InvokeAppendLine(strBuilder.ToString());
        }

        #region 【4】取消Task延时



        private void btnThreadSleep_Click(object sender, EventArgs e)
        {
            Thread.Sleep(5000);//不能取消
            MessageBox.Show("Sleep : I am back");
        }

        //task可以取消
        public CancellationTokenSource cts = new CancellationTokenSource();

        private async Task PutTaskDelay()
        {
            try
            {
                await Task.Delay(5000, cts.Token);//需要.net4.5的支持
            }
            catch (TaskCanceledException ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void btnCancelTaskDelay_Click(object sender, EventArgs e)
        {
            cts.Cancel();
        }

        private async void btnTaskDelay_Click(object sender, EventArgs e)
        {
            await PutTaskDelay();
            MessageBox.Show("Delay : I am back");
        }
        #endregion

        #region 【3】同步和异步等待方法

        /// <summary>
        /// 异步等待方法
        /// </summary>
        private async Task asyncTaskAsync()
        {
            var sw = new Stopwatch();
            sw.Start();
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH:mm:sss.fff")}-->async: Starting *");
            Task delay = Task.Delay(3000);
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH: mm:sss.fff")}-->async: Running for { sw.Elapsed.TotalSeconds} seconds **");
            await delay.ConfigureAwait(false);
            sw.Stop();
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH: mm:sss.fff")}-->async: Running for {sw.Elapsed.TotalSeconds} seconds ***");
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH: mm:sss.fff")}-->async: Done ****");
        }
        /// <summary>
        /// 同步等待方法
        /// </summary>
        private void syncCode()
        {
            var sw = new Stopwatch();
            sw.Start();
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH: mm:sss.fff")}-->sync: Starting *****");
            Thread.Sleep(5000);
            sw.Stop();
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH: mm:sss.fff")}-->sync: Running for {sw.Elapsed.TotalSeconds} seconds ******");
            strBuilder.AppendLine($"{DateTime.Now.ToString("HH: mm:sss.fff")}-->sync: Done *******");
        }
        #endregion

        #region 【5】同步方法中调用异步方法
        private void button5_ClickAsync(object sender, EventArgs e)
        {
            //ProcessAsync().Wait();
            Thread thread = new Thread(() =>
           {
               while (true)
               {
                   Task.Run(() => //同步方法里调用了异步方法容易死锁
                   {
                       ProcessAsync().Wait();
                        //var result = ProcessAsync().Result;
                    });
                   Thread.Sleep(200);
               }
               //while (true)
               //{
               //    Task.Run(async () =>  //异步方式：调用异步方法
               //     {
               //         await ProcessAsync();
               //     });
               //    Thread.Sleep(200);
               //}
           });
            thread.Start();
            thread.IsBackground = true;
        }
        /// <summary>
        /// 异步方法
        /// </summary>
        /// <returns></returns>
        public async Task<bool> ProcessAsync()
        {
            await Task.Run(() =>
           {
               InvokeAppendLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}--->ID【{Environment.CurrentManagedThreadId}】Start");
               Thread.Sleep(1000);
               //await Task.Delay(1000);
           }).ConfigureAwait(false);
            //Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}--->ID【{Environment.CurrentManagedThreadId}】End");
            InvokeAppendLine($"{DateTime.Now.ToString("HH:mm:ss.fff")}--->ID【{Environment.CurrentManagedThreadId}】End");
            return true;
        }
        #endregion
    }
}


