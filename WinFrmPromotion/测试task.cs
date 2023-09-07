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
    public partial class 测试task : Form
    {
        public 测试task()
        {
            InitializeComponent();
        }

        public void Initialize()
        {

        }
        public readonly List<Book> bookList = new List<Book>()
        {
                      new Book("唐诗",1),
                      new Book("宋词",2),
                      new Book("元曲",1),
                      new Book("楚辞",2),
                      new Book("汉赋",1),
        };
        private void 测试task_Load(object sender, EventArgs e)
        {
            bookList.ForEach(book => book.EventCompleted += Book_EventCompleted);
        }

        /// <summary>
        /// 同步，UI界面会卡住
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSynch_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            AppendLine("同步检索开始");
            int idx = 0;
            bookList.ForEach(book => { AppendLine($"{++idx}.{ book.Search()}"); });
            sw.Stop();
            AppendLine($"同步检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }


        /// <summary>
        /// 异步模式，并不能提高效率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BtnAsynch_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            InvokeAppendLine("异步检索开始");
            InvokeAppendLine($"当前线程ID是{Environment.CurrentManagedThreadId}");
            int idx = 0;
            foreach (Book item in bookList)
            {
                var task = await Task.Run(item.Search).ConfigureAwait(true);
                InvokeAppendLine($"{++idx}.{ task} ,返回的线程ID是{Environment.CurrentManagedThreadId}");

            }
            // bookList.ForEach(async book =>
            //{
            //    AppendLine($"{++idx}.{await Task.Run(book.Search) }");
            //});
            sw.Stop();
            InvokeAppendLine($"异步检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }


        /// <summary>
        /// 并发方式(跑得快的线程必须等待慢的线程)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnconcurrenceAsync_Click(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            AppendLine("并发检索开始");
            int idx = 0;
            List<Task<string>> taskList = new List<Task<string>>();
            // bookList.ForEach(book =>
            //{
            //    taskList.Add(Task.Run(book.Search));
            //});
            foreach (Book book in bookList)
            {
                Task<string> task = Task.Run(book.Search);
                taskList.Add(task);
            }
            var result = await Task.WhenAll(taskList);//异步线程等待所有线程执行完成
            foreach (var item in result)
            {
                AppendLine($"{++idx}.{item }");
            }
            sw.Stop();

            AppendLine($"并发检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }
       

        /// <summary>
        /// 异步回调（主线程先执行了没有等其他线程）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnAsyncCallBack_ClickAsync(object sender, EventArgs e)
        {
            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            AppendLine("异步检索开始");
            int idx = 0;
            List<Task> taskList = new List<Task>();
            foreach (Book book in bookList)
            {
                taskList.Add( Task.Run(book.Search).ContinueWith(new Action<Task<string>>((str) =>
                  { InvokeAppendLine($"{++idx}.{str.Result}"); })));
            }
            await Task.WhenAll(taskList);
            sw.Stop();
            AppendLine($"异步检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }
       
        /// <summary>
        /// 事件检索开始，异步回调相比提升了效率
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnEvent_Click(object sender, EventArgs e)
        {

            Stopwatch sw = Stopwatch.StartNew();
            txtResult.Clear();
            AppendLine("事件检索开始");
            int idx = 0;
            List<Task> taskList = new List<Task>();
            taskList.Clear();
            foreach (Book item in bookList)
            {
                taskList.Add(Task.Run(item.SearchEvent));
            }
            await Task.WhenAll(taskList);

            sw.Stop();
            AppendLine($"事件检索结束，共计用时{sw.ElapsedMilliseconds}ms");
        }

        private void Book_EventCompleted(object arg1, EventArgs arg2)
        {
            InvokeAppendLine(arg1.ToString());
        }



        private void AppendLine(string str)
        {
            txtResult.AppendText(string.IsNullOrEmpty(txtResult.Text) ? str : $"{Environment.NewLine + str}");
            txtResult.ScrollToCaret();
            txtResult.Refresh();
        }
        private void InvokeAppendLine(string str)
        {
            this.Invoke(new Action(() =>{ AppendLine(str); }));
        }

    }



    public class Book
    {
        public event Action<object, EventArgs> EventCompleted;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 检索时间
        /// </summary>
        public int Duration { get; set; } = 0;

        public Book(string name, int second)
        {
            Name = name;
            Duration = second;
        }
        private string Result(double milliseconds)
        {
            return $"{Name.PadRight(12, '-')}用时：{milliseconds.ToString("f3")}ms";
        }

        public string Search()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Thread.Sleep(Duration * 1000);
            sw.Stop();
            //返回消息
            return Result(sw.ElapsedMilliseconds);
        }

        public void SearchEvent()
        {
            Stopwatch sw = Stopwatch.StartNew();
            Thread.Sleep(Duration * 1000);
            sw.Stop();
            //返回消息
            EventCompleted?.Invoke(Result(sw.ElapsedMilliseconds), new EventArgs());
        }
        public async Task<string> SearchAsync()
        {
            Stopwatch sw = Stopwatch.StartNew();
            await Task.Delay(Duration).ConfigureAwait(false);
            sw.Stop();
            return Result(sw.ElapsedMilliseconds);
        }
    }

}
