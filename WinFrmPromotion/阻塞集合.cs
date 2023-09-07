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
using System.Collections.Concurrent;
using System.Diagnostics;
namespace WinFrmPromotion
{
    public partial class 阻塞集合 : Form
    {
        public 阻塞集合()
        {
            InitializeComponent();
        }
        /// <summary>
        /// BlockingCollection的使用（解决多线程里数据丢失的问题）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void button1_Click(object sender, EventArgs e)
        {
            // Method1();       //【方法1】使用的是非现线程安全的类，必须要加lock
            // Method2();      //【2】线程安全集合提供阻塞和限制功能。
            Method3();         //【3】异步线程返回值
        }
        /// <summary>
        /// ConcurrentQueue类的用法
        /// </summary>
        public void ConCurrentQueueTest(object sender, EventArgs e)
        {
            // ConcurrentQueue表示线程安全的先进先出(FIFO) 集合。
            ConcurrentQueue<string> conCurrentQueue = new ConcurrentQueue<string>();

            //入队线程1
            Task.Run(async () =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    conCurrentQueue.Enqueue(DateTime.Now.ToString());
                }
            });

            //入队线程2
            Task.Run(async () =>
            {
                int index = 0;
                while (true)
                {
                    await Task.Delay(1000);
                    index = index + 1;
                    conCurrentQueue.Enqueue($"第{index}次");
                }
            });
            //出队线程
            Task.Run(async () =>
            {
                while (true)
                {
                    if (conCurrentQueue.TryDequeue(out string result))//如果队列为空则不会出队
                    {
                        InvokeAppendLine(textBox1, result);
                    }
                    await Task.Delay(2000);
                }
            });
        }

        private async void Method1()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<Task> taskList = new List<Task>();

            List<int> intList = new List<int>();

            for (int i = 0; i < 100; i++)
            {
                int value = i;
                Task tsk = Task.Run(async () =>
                {
                    await Task.Delay(200);
                    lock (intList)//【方法1】使用的是非现线程安全的类，必须要加lock
                    {
                        intList.Add(value);
                    }
                });
                taskList.Add(tsk);
            }
            await Task.WhenAll(taskList);
            sw.Stop();
            InvokeAppendLine(textBox1, $"数组里共有{intList.Count.ToString()}个数据");
            InvokeAppendLine(textBox1, $"任务里共有{taskList.Count.ToString()}个任务");
            InvokeAppendLine(textBox1, $"耗时{sw.ElapsedMilliseconds.ToString()}ms");
        }

        private async void Method2()
        {

            Stopwatch sw = Stopwatch.StartNew();

            List<Task> taskList = new List<Task>();

            //List<int> intList = new List<int>();

            //【2】线程安全集合提供阻塞和限制功能。
            #region 线程安全的类
            BlockingCollection<int> intList = new BlockingCollection<int>();
            #endregion

            for (int i = 0; i < 100; i++)
            {
                int value = i;
                Task tsk = Task.Run(async () =>
                {
                    await Task.Delay(200);
                    lock (intList)
                    {
                        intList.Add(value);
                    }
                });
                taskList.Add(tsk);
            }
            await Task.WhenAll(taskList);

            sw.Stop();
            InvokeAppendLine(textBox1, $"数组里共有{intList.Count.ToString()}个数据");
            InvokeAppendLine(textBox1, $"任务里共有{taskList.Count.ToString()}个任务");
            InvokeAppendLine(textBox1, $"耗时{sw.ElapsedMilliseconds.ToString()}ms");

        }
        private async void Method3()
        {
            Stopwatch sw = Stopwatch.StartNew();

            List<Task<int>> taskList = new List<Task<int>>();

            List<int> intList = new List<int>();

            //【3】异步线程返回值

            for (int i = 0; i < 100; i++)
            {
                int value = i;
                Task<int> tsk = Task<int>.Run(async () =>
                {
                    await Task.Delay(200);
                    return value;
                });
            
                taskList.Add(tsk);
                //int m = tsk.Result;
              
            }
            int[] result = await Task.WhenAll(taskList);

            sw.Stop();
            InvokeAppendLine(textBox1, $"数组里共有{result.Length.ToString()}个数据");
            InvokeAppendLine(textBox1, $"任务里共有{taskList.Count.ToString()}个任务");
            InvokeAppendLine(textBox1, $"耗时{sw.ElapsedMilliseconds.ToString()}ms");

        }
        private void InvokeAppendLine(TextBox textBox, string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                textBox.AppendText(string.IsNullOrEmpty(textBox.Text) ? str : $"{Environment.NewLine + str}");
                textBox.ScrollToCaret();
                textBox.Refresh();
            }));
        }
        private async void testTaskAsync()
        {
            List<Task> taskList = new List<Task>();

            Stopwatch sw = Stopwatch.StartNew();
            for (int i = 0; i < 3; i++)
            {
                //count是值类型，每次循环都会新开辟内存
                int count = i + 1;
                Task tak = Task.Run(async () =>
                {
                    await Task.Delay(count * 1000);
                    InvokeAppendLine(textBox1, $"线程{count}任务完成,count的值是{count},i的值是{i}");
                });
                taskList.Add(tak);
            }
            await Task.WhenAll(taskList); //异步等待所有的线程完成，会创建一个新的任务去等待，不阻塞主程序的执行
          // Task.WaitAll(taskList.ToArray());//会阻塞后续程序的执行，主程序不会执行
            sw.Stop();
            InvokeAppendLine(textBox1, sw.ElapsedMilliseconds.ToString());
        }
        private void btnTaskList_Click(object sender, EventArgs e)
        {
            testTaskAsync();
            InvokeAppendLine(textBox1, "继续执行。。。。。。");
        }
}
}
