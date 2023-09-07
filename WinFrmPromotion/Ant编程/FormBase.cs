using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmPromotion
{
    public partial class FormBase : Form
    {

        public FormBase()
        {
            InitializeComponent();

        }

        private void FormBase_Load(object sender, EventArgs e)
        {
            //Trace.WriteLine(testMethod.random.Next());
            //testMethod test = new testMethod(1, "晓晓");
            //test.showStr += delegateMetnod;      //委托实例和委托方法绑定
            //test.ShowINfor += ActioneMetnod;    //Action
            //test.testEvent += EventHanderMetnod; //EventHander
            //test.Print();
            //StudentBase objstu = new StudentBase() { };
            //objstu["Name"] = "明日复明日";
            //objstu["Address"] = "苏州";
            //objstu["Sex"] = "123";

            Worker obj = new Worker(1);
        }

        void delegateMetnod(StudentBase stu)
        {
            MessageBox.Show($"{stu.ID },{stu.Address}");
        }
        void ActioneMetnod(object sender, StudentBase stu)
        {
            testMethod obj = (testMethod)sender;
            MessageBox.Show($"{obj.Name},{stu.ID },{stu.Address}");
        }
        void EventHanderMetnod(object sender, StudentBase str)
        {
            testMethod obj = (testMethod)sender;
            MessageBox.Show($"{obj.Name},{str.ID },{str.Address}");
        }
    }
    public class testMethod
    {
        public static Random random;
        static testMethod()//静态构造函数常用来初始化静态变量
        {
            random = new Random();
        }

        //自动属性
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; } = 5000;

        public testMethod(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;

        }
        public void Print()
        {

            Console.WriteLine($"ID{this.ID},Name{this.Name}，交税{Tax(this)}");

            //showStr(new StudentBase() { ID = 123, Address = "苏州" });
            //ShowINfor(this, new StudentBase() { ID = 1234, Address = "杭州" });
            //testEvent(this ,new StudentBase() { ID = 12345, Address = "台州" });
        }
        private double Tax(testMethod infor)
        {
            return infor.Salary * 0.1;
        }



        public delegate void StringProcessor(StudentBase str);//自己定义委托
        public event StringProcessor showStr;                           //在自己定义委托下定义事件

        public event Action<object, StudentBase> ShowINfor;     //定义系统的Action委托事件

        public event EventHandler<StudentBase> testEvent;       //定义系统的EventHandler委托事件


    }

    public class StudentBase : EventArgs
    {
        public int ID { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }

        #region 普通索引器


        public string this[string str]
        {
            set
            {
                switch (str)
                {
                    case "Address":
                        Address = value;
                        break;
                    case "Name":
                        Name = value;
                        break;
                    case "Sex":
                        Sex = value;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(str);
                }
            }
            get
            {
                switch (str)
                {
                    case "Address":
                        return Address;
                    case "Name":
                        return Address;
                    case "Sex":
                        return Address;
                    default:
                        throw new ArgumentOutOfRangeException(str);
                }
            }
        }

        #endregion

        private object[] argus = new object[100];
        //public object this[int index] { get { return argus[index]; } set { argus[index]=value; } }
        public object this[int index]
        {
            get => argus[index];
            set => argus[index] = value;
        }
        public int MyProperty { get; }
    }


    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string Job { get; set; }
        public virtual void Show()
        {
            Console.WriteLine("我是基类的虚方法");
        }
        public Person()
        {

        }
        public Person(int m)
        {
            Console.WriteLine($"我是基类里有1个参数的构造方法{m},");
        }

    }
    public class Worker : Person
    {
        public string Company { get; set; }

        public new string Job { get; set; } = string.Empty;

        public override void Show()
        {
            Console.WriteLine("我是派生类的重构方法");
        }

        public Worker()
        {
            Console.WriteLine($"我是派生类的无参数的构造放法");
        }
        public Worker(int index, string n) : base(index)
        {
            Console.WriteLine($"我是派生类的有2个参数的构造放法{index},{n}");
        }
        public Worker(int index) :this(index,"vbnm")
        {
            Console.WriteLine($"我是派生类的有1个参数的构造放法{index}");
        }
    }
}
