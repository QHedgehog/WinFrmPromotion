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
using System.Collections.Concurrent;
namespace WinFrmPromotion
{
    public partial class 阻塞队列 : Form
    {
        BlockingQueue<string> testQueue = new BlockingQueue<string>();
        public 阻塞队列()
        {
            InitializeComponent();
        }

        private CancellationTokenSource TokenSource1, TokenSource2, TokenSource3;
        private ManualResetEvent ManualReset1, ManualReset2, ManualReset3;
        private List<Button> btnList;
        private void btnStartQueue_Click(object sender, EventArgs e)
        {
            testQueue.Open();
            btnList = new List<Button>() { this.btnContinue1, this.btnContinue2, this.btnPause1, this.btnPause2 };
            foreach (Button item in btnList)
            {
                item.BackColor = SystemColors.ControlLight;
                if (item.Text.ToString().Contains("暂停"))
                {
                    item.Enabled = true;
                }
                else
                {
                    item.Enabled = false;
                }
            }

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            testQueue.Close();

            TokenSource3.Cancel();//停止出队的线程
            TokenSource2.Cancel();//停止入队的线程
            TokenSource1.Cancel();//停止入队的线程
        }

        private void btnEnqueue_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ManualReset1 = new ManualResetEvent(true);
                TokenSource1 = new CancellationTokenSource();
                int index = 1;
                while (!TokenSource1.IsCancellationRequested)
                {
                    try
                    {
                        ManualReset1.WaitOne();
                        testQueue.Enqueue($"ID{Environment.CurrentManagedThreadId}第{index}次数据");
                        index = index + 1;
                    }
                    catch (AggregateException ex)
                    {

                        InvokeAppendLine(txtResult, ex.Message);
                    }

                    Thread.Sleep(100);
                }


            });

        }

        private void btnEnqueue2_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ManualReset2 = new ManualResetEvent(true);
                TokenSource2 = new CancellationTokenSource();
                int index = 1;
                while (!TokenSource2.IsCancellationRequested)
                {
                    try
                    {
                        ManualReset2.WaitOne();
                        testQueue.Enqueue($"ID{Environment.CurrentManagedThreadId}第{index}次数据");
                        index = index + 1;
                    }
                    catch (AggregateException ex)
                    {

                        InvokeAppendLine(txtResult, ex.Message);
                    }

                    Thread.Sleep(100);
                }


            });
        }

        private void btnDequeue_Click(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                ManualReset3 = new ManualResetEvent(true);
                TokenSource3 = new CancellationTokenSource();
                while (!TokenSource3.IsCancellationRequested)
                {
                    ManualReset3.WaitOne();
                    string result = "";
                    testQueue.Dequeue(ref result);
                    InvokeAppendLine(txtResult, "出队：" + result);
                    Thread.Sleep(1000);
                }
            });
        }
       
        private void btnStopEnqueue_Click(object sender, EventArgs e)
        {
            
            Button button = (Button)sender;
            button.BackColor = Color.Red;
           // button.Enabled = false;
            switch (button.Tag)
            {
                case "1":
                    ManualReset1?.Reset();
                    btnContinue1.Enabled = true;
                    btnContinue1.BackColor = SystemColors.ControlLight;
                    break;
                case "2":
                    ManualReset2?.Reset();
                    btnContinue2.Enabled = true;
                    btnContinue2.BackColor = SystemColors.ControlLight;
                    break;
                case "3":
                    ManualReset3?.Reset();
                    btnContinue3.Enabled = true;
                    btnContinue3.BackColor = SystemColors.ControlLight;
                    break;
                default:
                    break;
            }

        }
        private void btnContinueEnqueue_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            button.BackColor = Color.Green;
            button.Enabled = false;
            switch (button.Tag)
            {
                case "1":
                    ManualReset1?.Set();
                    btnPause1.BackColor = SystemColors.ControlLight;
                    btnPause1.Enabled = true;
                    break;
                case "2":
                    ManualReset2?.Set();
                    btnPause2.BackColor = SystemColors.ControlLight;
                    btnPause2.Enabled = true;
                    break;
                case "3":
                    ManualReset3?.Set();
                    btnPause3.BackColor = SystemColors.ControlLight;
                    btnPause3.Enabled = true;
                    break;
                default:
                    break;
            }
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
    }

    /// <summary>
    /// Description: 阻塞队列（泛型），有界队列
    ///主要实现了队列为空时出队阻塞，队列为满时入队阻塞
    /// </summary>

    public class BlockingQueue<T>
    {
        #region Fields & Properties

        private string name;       //队列名称

        private readonly int maxSize;  //队列最大长度

        private Queue<T> queue;//FIFO队列

        private bool isRunning;//是否运行中

        private ManualResetEvent enqueueWait;//入队手动复位事件

        private ManualResetEvent dequeueWait;   //出队手动复位事件


        /// <summary>
        /// 队列长度
        /// </summary>
        public int Count => queue.Count;
        #endregion

        #region 构造函数
        public BlockingQueue(int maxsize=1000, string m_name= "BlockingQueue", bool isrunning = false)
        {
            maxSize = maxsize;
            name = m_name;
            queue = new Queue<T>(maxSize);
            isRunning = isrunning;
            //初始化时队列阻塞出队和入队
            enqueueWait = new ManualResetEvent(false); // 无信号，入队waitOne阻塞
            dequeueWait = new ManualResetEvent(false); // 无信号, 出队waitOne阻塞
        }
        #endregion

        #region Public Method

        /// <summary>
        /// 开启阻塞队列
        /// </summary>
        public void Open()
        {
            isRunning = true;
        }

        /// <summary>
        /// 关闭阻塞队列
        /// </summary>
        public void Close()
        {
            // 停止队列
            isRunning = false;
            // 发送信号，通知出队阻塞waitOne可继续执行，可进行出队操作
            dequeueWait.Set();
        }

        /// <summary>
        /// 入队
        /// </summary>
        /// <param name="item"></param>
        public void Enqueue(T item)
        {
            if (!isRunning)
            {
                // 处理方式一 可直接抛出异常
                throw new ArgumentException("队列终止，不允许入队");
            }

            while (true)
            {
                lock (queue)
                {
                    // 如果队列未满，继续入队
                    if (queue.Count < maxSize)
                    {
                        queue.Enqueue(item);
                        enqueueWait.Reset();// 设置为无信号，入队暂停
                        dequeueWait.Set();// 发送信号，通知出队阻塞waitOne可继续执行，可进行出队操作
                        break;
                    }
                }
                enqueueWait.WaitOne();// 如果队列已满，则阻塞队列，停止入队，等待信号
            }
        }

        /// <summary>
        /// 出队
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Dequeue(ref T item)
        {
            while (true)
            {
                if (!isRunning)
                {
                    lock (queue) return false;
                }
                lock (queue)
                {
                    // 如果队列有数据，则执行出队
                    if (queue.Count > 0)
                    {
                        item = queue.Dequeue();

                        dequeueWait.Reset();    // 置为无信号，出队阻塞                      
                        enqueueWait.Set();// 发送信号，通知入队阻塞waitOne可继续执行，可进行入队操作
                        return true;
                    }
                }
                // 如果队列无数据，则阻塞队列，停止出队，等待信号
                dequeueWait.WaitOne();
            }
        }

        /// <summary>
        /// 清空队列
        /// </summary>
        public void clear()
        {
            lock (queue)
            {
                if (Count > 0)
                {
                    queue.Clear();
                }
            }
        }

        #endregion
    }

}
