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
    public delegate void MyDele();
    public delegate double MyDelePara(int i, string str);

    public partial class Form2 : Form        //类：属性--->存储数据、方法--->做事情、事件-->通知别人
    {
        MyDelePara myDele2;
        public Form2()
        {
            InitializeComponent();
            //Timer timer = this.timer1;
            //timer.Interval = 1000;
            //Boy boy = new Boy();
            //timer.Tick += boy.Action;

            //Girl girl = new Girl();
            //timer.Tick += girl.Action;
            //timer.Start();
            MyDele myDele1 = new MyDele(() => { });
            //MyDelePara myDele2 = new MyDelePara((int index, string m) =>
            //{
            //    double s = 2 * index;
            //    return s;
            //});
            //myDele2 = new MyDelePara(Method);
            //string anyInfor = "可以随便传任何值";
            ////异步调用
            //IAsyncResult result = myDele2.BeginInvoke(2, "3", new AsyncCallback(CallBack), anyInfor);


        }

        private void CallBack(IAsyncResult ar)
        {
            string ms = ar.AsyncState.ToString();
            double sm = myDele2.EndInvoke(ar);
        }

        private double Method(int index, string str)
        {
            Thread.Sleep(5000);
            return 2 * index;
        }
        





    }
    

    //委托类型的实例间接的调用一些方法，方法的包装器，和函数签名很像
    //模板方法和回调方法
    //多播委托也是同步调用invoke方法
    //多播委托间接的同步调用invoke方法

    //分支线程是由beginInvoke方法endInvoke是隐式的异步调用==========>task的Async和await方法更好用
    //显示的异步调用：thread，task
    //用接口来取代委托


    //客户端程序----界面发生的逻辑，图形驱动的程序
    //事件：使对象或类具备通知能力的功能，EventArgs事件参数，事件处理器EventHander，用于类或对象之间的信息传递，发生响应模型（闹钟  响了  小明  起床  订阅关系）
    //设计模式：事件模式MVC,MVP,MVM是事件更高级和更高效的方式

    //事件是基于委托的，事件的对委托的一种约束
    public class CustomArgus : EventArgs
    {
        public string Name { get; set; }
        public string Food { get; set; }
    }

    public class Boy//事件的响应者
    {
        internal void Action(object sender, EventArgs e)
        {
            Console.WriteLine("Jump");
        }
    }

    [Serializable]
    public class Girl
    {
        internal void Action(object sender, EventArgs e)
        {
            Console.WriteLine("Sing");
        }
    }

    //抽象类：可以没有任何抽象方法，但是抽象方法必须存在于抽象类
    //抽象类---这种特性-多态(不同对象接收相同消息，产生不同行为称为多态)
    //多态与里式替换原则:
    class Animal
    {
        public Animal()
        {

        }
        public virtual void Introduce()
        {
            Console.WriteLine("我是动物");

        }
        //public abstract void Have();//抽象类不能是静态的static，也不能是sealed
    }
    class Cat : Animal//子类必须实现父类的抽象方法，除非子类也是抽象类
    {
        //public override void Have()
        //{
           
        //}
     
    }
    class Dog : Animal
    {
        //public override void Have()
        //{
          
        //}
        public override void  Introduce()
        {
            Console.WriteLine("我是dog");
        }
    }

    interface IMultiPrinter
    {
        void Print(string content);

        void Copy(string content);

        void Fax(string content);
    }
    class HPMultiPrinter : IMultiPrinter
    {
        public void Copy(string content)
        {
            Console.WriteLine("HP正在打印"+content);
        }

        public void Fax(string content)
        {
            throw new NotImplementedException();
        }

        public void Print(string content)
        {

        }
    }
}
