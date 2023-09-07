using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Windows.Forms;

namespace WinFrmPromotion
{
    //对象的复用
    //单例模式:构造函数私有法
    //提供公开的静态方法来提供实例
    //私有的静态字段：内存唯一，不会释放，且在第一次使用这个类被初始化且被初始化1次
    public partial class 单例实现 : Form
    {
        public 单例实现()
        {
            InitializeComponent();
        }

        private void TestSingleton()
        {

            SingletonModel _sample = SingletonModel.Instance;
            _sample.SetInfor("one",1);

            SingletonModel _sample2 = SingletonModel.Instance;
            _sample2.SetInfor("two", 2);

            ShowMsg($"Name:{_sample.Name},ID:{_sample.ID}");

            ShowMsg($"Name:{_sample2.Name},ID:{_sample2.ID}");

           bool res= object.ReferenceEquals(_sample,_sample2);//不是同一个对象，同一个为true

        }

        private void ShowMsg(string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                txtResult.AppendText(string.IsNullOrEmpty(txtResult.Text) ? str : $"{Environment.NewLine + str}");
                txtResult.ScrollToCaret();
                txtResult.Refresh();
            }));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            TestSingleton();
        }
    }






    //与静态类的区别是：可以继承其他父类和接口

    #region 【1】单例模式：双重锁是线程安全的
    /// <summary>
    /// 双重检查锁的方法解决了线程并发性问题，同时避免了在每次调用Instance属性方法时使用独占锁。
    /// </summary>
    public sealed class SingletonModel
    {
        private SingletonModel() { }//构造函数必须是私有的，禁止外部创建实体类

        //readonly只读字段--->可以在定义的同时赋值,或者在类的构造方法中给其赋值；
        private static volatile SingletonModel instance;  // volatile用于控制同步，是针对程序中一些敏感数据，不允许多线程同时访问
                                                          // 保证数据在任何访问时刻，最多有一个线程访问，以保证数据的完整性
        private static readonly object _locker = new object();//创建一把锁
        public  static SingletonModel Instance
        {
            get
            {
                //双重锁是线程安全的
                if (instance == null)
                {
                    lock (_locker)
                    {
                        if (instance == null)
                        {
                            instance = new SingletonModel();
                        }
                    }
                }
                //类是引用对象：是在堆上，不走构造函数，直接的内存复制，没有性能损失产生了一个新对象
                //MemberwiseClonen内存浅拷贝，只拷贝引用，不拷贝引用的值

                return instance.MemberwiseClone() as SingletonModel;//这句话就是原型模式

               //deepClone：1.直接new，2、每个子类都设计好自己的原型，3.序列化（不走构造函数）

            }
        }


        public int ID { get; set; }
        public string Name { get; set; }

        public void SetInfor(string name,int id)
        {
            this.ID = id;
            this.Name = name;
            
        
        }

    }

    #endregion

    #region 【2】懒汉(Lazy)模式是线程安全的
    public sealed class SingletonModel2
    {
        private SingletonModel2() { }//构造函数必须是私有的，禁止外部创建实体类

        private static readonly Lazy<SingletonModel2> instance = new Lazy<SingletonModel2>(() => new SingletonModel2());//私有变量
        public static SingletonModel2 Instance { get { return instance.Value; } }
    }
    #endregion

    #region 【3】饿汉模式(创建静态对象)
    public sealed class SingletonModel3   //sealed修饰类时说明该类将不能被继承或重写
                                                                 //修饰方法（函数或属性）时可防止扩充类重写此方法（函数或属性）
    {
        private SingletonModel3() { }//构造函数必须是私有的，禁止外部创建实体类  

        private static readonly SingletonModel3 instance = new SingletonModel3();//静态初始化
        public static SingletonModel3 Instance { get { return instance; } }

    }

    #endregion


}
