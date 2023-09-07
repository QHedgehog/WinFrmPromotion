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
namespace WinFrmPromotion
{
    public partial class 测试TaskWait : Form
    {
        public 测试TaskWait()
        {
            InitializeComponent();
        }
        public readonly List<Book> bookList = new List<Book>()
        {
                      new Book("唐诗",1),
                      new Book("宋词",2),
                      new Book("元曲",1),
                      new Book("楚辞",2),
                      new Book("汉赋",1),
        };
        /// <summary>
        /// wait其实是个同步阻塞
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWait_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            InvokeAppendLine("Wait检索开始");

            int idx = 0;
            foreach (Book item in bookList)
            {
                Task<string> task = Task.Run(() => { return item.Search(); });
                task.Wait();
                InvokeAppendLine($"{++idx}.{ task.Result} ");
            }
            sw.Stop();
            InvokeAppendLine($"Wait检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }

        private void btnWaitAll_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            InvokeAppendLine("WaitAll检索开始");
            List<Task<string>> taskList = new List<Task<string>>();
            int idx = 0;
            foreach (Book item in bookList)
            {
                Task<string> task = Task.Run(() => { return item.Search(); });
                taskList.Add(task);
            }
            Task.WaitAll(taskList.ToArray());
            foreach (var task in taskList)
            {
                AppendLine($"{++idx}.{task.Result }");
            }
            sw.Stop();
            InvokeAppendLine($"WaitAl检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }

        /// <summary>
        /// Task.Result是会堵塞，在获取result时也会阻塞等待所有线程执行完
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnWaitAny_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            InvokeAppendLine("WaitAny检索开始");
            List<Task<string>> taskList = new List<Task<string>>();
            int idx = 0;
            foreach (Book item in bookList)
            {
                Task<string> task = Task.Run(() => { return item.Search(); });
                taskList.Add(task);
            }
            Task.WaitAny(taskList.ToArray());
            foreach (var task in taskList)
            {
                AppendLine($"{++idx}.    {task.Result}    {task.Id },   {task.Status}  ");
            }
            sw.Stop();
            InvokeAppendLine($"WaitAny检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }

        private void AppendLine(string str)
        {
            txtResult.AppendText(string.IsNullOrEmpty(txtResult.Text) ? str : $"{Environment.NewLine + str}");
            txtResult.ScrollToCaret();
            txtResult.Refresh();
        }
        private void InvokeAppendLine(string str)
        {
            this.Invoke(new Action(() => { AppendLine(str); }));
        }
        /// <summary>
        /// 死锁的2种解决办法
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDeadLock_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            InvokeAppendLine("死锁验证开始");

            int idx = 0;
            foreach (Book item in bookList)
            {
                //【1.】第1种采用continuewith的委托方法
                var task = item.SearchAsync().ContinueWith(t => InvokeAppendLine($"{++idx}.{t.Result }"));

                Stopwatch swtime = Stopwatch.StartNew();
                Task<string>.Run(async () =>
                {
                    swtime.Restart();
                    await Task.Delay(100).ConfigureAwait(false);
                    sw.Stop();
                    return swtime.ElapsedMilliseconds.ToString();
                }).ContinueWith(t => InvokeAppendLine($"{++idx}.{t.Result }"));


                //【2.】第2种采用 await Task.Delay(Duration).ConfigureAwait(false)
                //var task = item.SearchAsync();
                //InvokeAppendLine($"{++idx}.{task.Result }");
            }
            sw.Stop();
            InvokeAppendLine($"死锁检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }

        StringBuilder str = new StringBuilder();

        private void button1_ClickAsync(object sender, EventArgs e)
        {
            str.Clear();
            Stopwatch sw = Stopwatch.StartNew();
            RealizeFunctionAsync();
            str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->后续动作开始执行");
            for (int i = 0; i < 5; i++)
            {
                Thread.Sleep(1000);
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->后续动作第{i + 1}步");
            }
            sw.Stop();
            str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->后续动作完成,耗时{sw.ElapsedMilliseconds}");

            MessageBox.Show("等待运行结束", "提示", MessageBoxButtons.YesNo);
            InvokeAppendLine(str.ToString());
        }

        private async void RealizeFunctionAsync()
        {

            List<Task> mytaskList = new List<Task>();

            Task task1 = Task.Run(async () =>
            {
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->任务1开始");
                await Task.Delay(1000);
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->任务1结束");
            });

            mytaskList.Add(task1);

            Task task2 = Task.Run(async () =>
            {
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->任务2开始");
                await Task.Delay(2000);
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->任务2结束");
            });
            mytaskList.Add(task2);

            Task task3 = Task.Run(async () =>
            {
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->任务3开始");
                await Task.Delay(3000);
                str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->任务3结束");
            });
            mytaskList.Add(task3);
            Dictionary<Task, Action> dictionary = new Dictionary<Task, Action>()
            {
                { task1, () => { str.AppendLine("task1执行完成之后，对应的Action执行了"); } },
                { task2, () => { str.AppendLine("task2执行完成之后，对应的Action执行了"); } },
                { task3, () => { str.AppendLine("task3执行完成之后，对应的Action执行了"); } },
            };
            //WhenAll测试
            await Task.WhenAll(mytaskList); //WhenAll返回一个新的任务，在这个任务中等待所有任务执行完
            str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->所有任务执行完毕");

            //WaitAll测试
            //Task.WaitAll(mytaskList.ToArray()); //WaitAll阻塞式等待所有任务执行完
            //str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->所有任务执行完毕");

            //WaitAny测试
            //int index = Task.WaitAny(mytaskList.ToArray());//WaitAny阻塞式等待任意任务执行完，返回值是这个执行完的任务的index，一旦有任务执行完了，就不阻塞了，
            //dictionary[mytaskList[index]]();
            //str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->某个任务执行完毕");

            //WhenAny测试
            //Task completedTask = await Task.WhenAny(mytaskList);//WhenAny返回一个新的任务，在这个任务中等待任意任务执行完，如果加上await，那么赋值号左侧接收到的就是这个最先执行完的任务
            //dictionary[completedTask]();
            //str.AppendLine($"{DateTime.Now.ToString("HH:mm：sss：fff")}-->某个任务执行完毕");
        }
    }
}
