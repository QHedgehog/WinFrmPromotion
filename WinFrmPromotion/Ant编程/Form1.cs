using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Diagnostics;
using MySqlHelper;
namespace WinFrmPromotion
{
    //委托是一个引用类型，是一个类，保存方法的指针，他指向一个方法，当我们调用委托的时候这个方法就立即被执行
    public delegate void helloDelegate(string msg);//定义委托，和方法的签名一致
    public delegate bool IsVipDelegate(LearnVip learnVip);//定义委托

    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void EventTest_actionEvent()
        {
            Console.WriteLine("EventTest---->我是这个委托事件的具体实现方法");
        }
        public bool CreateCompare(int i, int j)
        {
            return i > j;
        }
        public void hello(string s)
        {
            txtInfor.Text = s;
        }

        //泛型方法
        public void Show<T, T2, T3>(T t)
        {
            Console.WriteLine("这是泛型方法----->" + t);
        }


        //委托的方法
        public bool getVip(LearnVip learnVip)
        {
            if (learnVip.Price >= 100)
            {
                return true;
            }
            else { return false; }
        }
        public bool getVip2(LearnVip learnVip)
        {
            if (learnVip.Price >= 400)
            {
                return true;
            }
            else { return false; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region 深拷贝和浅拷贝验证

            //Teacher teacher = new Teacher()
            //{
            //    ID = 123,
            //    Name = "张三",
            //    student = new Student()
            //    {
            //        ID = 1234,
            //        Name = "张同学",
            //    },
            //};
            //Teacher teacher2 = teacher;
            //teacher2.ID = 456;
            //teacher2.Name = "李四";
            //teacher2.student.ID = 4567;
            //teacher2.student.Name = "李同学";

            #endregion

            #region 泛型

            //什么是泛型
            //List<string> strList = new List<string>() { "今天", "开", "空调啦" };
            //foreach (var item in strList)
            //{
            //    Console.WriteLine(item);
            //}
            //List<object> objList = new List<object>() { "123", true };//object类型做数据转换的时候有拆装箱的操作，有性能损耗，且类型不安全

            //泛型Dictionnary<K,V>键值对
            //Dictionary<int, string> directory = new Dictionary<int, string>();
            //directory.Add(1, "程序");//key可以是任何类型，但是不能重复
            //foreach (var item in directory)
            //{
            //    Console.WriteLine(item.Key.ToString() + item.Value);
            //}
            //directory.ContainsValue("程序");
            //自定义泛型
            //MyTest<double, int, string> obj = new MyTest<double, int, string>(1.2345678, 1, "kongkong");
            //obj.show();
            #endregion

            #region 反射工具

            //反射是操作元数据的一个类库， 动态编程，读取私有的信息时
            #region 【1.】通过反射加载dll文件
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.Clear();
            ////Assembly assembly = Assembly.Load("MySqlHelper");//加载方式一
            ////Assembly assembly = Assembly.LoadFile("C:\\Users\\12851\\source\\repos\\WinFrmPromotion\\WinFrmPromotion\\bin\\Debug\\MySqlHelper.dll");//加载方式二      
            //Assembly assembly = Assembly.LoadFrom("MySqlHelper.dll");//加载方式三，推荐
            //foreach (var item in assembly.GetTypes())
            //{
            //    strBuilder.AppendLine(item.Name);
            //    foreach (var mtehod in item.GetMethods())
            //    {
            //        strBuilder.AppendLine(mtehod.Name);
            //    }
            //}
            //txtInfor.Text = strBuilder.ToString();

            #endregion
            #region 【2】使用反射创建对象
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.Clear();
            //Assembly assembly = Assembly.LoadFrom("MySqlHelper.dll");//加载方式三，推荐
            //Type type = assembly.GetType("MySqlHelper.MySqlHelper");//获取类型，完整的类型名称
            //object objSqlHelper= Activator.CreateInstance(type);//C#是强类型语言
            //IDBHlper objDBHelper = (IDBHlper)objSqlHelper;
            //objDBHelper.Query();


            #endregion
            #region 【3】使用反射创建带有参数对象
            //StringBuilder strBuilder = new StringBuilder();
            //strBuilder.Clear();
            //Assembly assembly = Assembly.LoadFrom("MySqlHelper.dll");//加载方式三，推荐

            //Type type = assembly.GetType("MySqlHelper.ReflectionTest");//获取类型，完整的类型名称

            //foreach (ConstructorInfo ctor in type.GetConstructors())
            //{
            //    Trace.WriteLine(ctor.Name);
            //    foreach (ParameterInfo para in ctor.GetParameters())
            //    {
            //        Trace.WriteLine($"参数名字-->{para.Name}   类型-->{para.ParameterType}");
            //    }
            //}
            //object objSqlHelper = Activator.CreateInstance(type,true);//创建对象-----True可以访问私有的构造函数（反射可以用来破坏单例）
            //object objSqlHelper2 = Activator.CreateInstance(type,new object[] { "123"});//创建对象
            //object objSqlHelper3 = Activator.CreateInstance(type, new object[] { 111 });//创建对象
            //object objSqlHelper4 = Activator.CreateInstance(type, new object[] {"123编程" ,111 });//创建对象

            #endregion
            #region 【4】使用反射创建泛型类、泛型方法
            //Assembly assembly = Assembly.LoadFrom("MySqlHelper.dll");//加载方式三，推荐
            //Type type = assembly.GetType("MySqlHelper.GenericClass`3");//获取类型，`3代表的是有3个泛型参数的类
            //Type Maketype = type.MakeGenericType(new Type[] { typeof(string), typeof(int), typeof(double) });//获取类型，`3代表的是有3个泛型参数的类
            //object objSqlHelper = Activator.CreateInstance(Maketype, new object[] { "123", 456, 78.87 });//创建对象-----True可以访问私有的构造函数（反射可以用来破坏单例）
            

            //MethodInfo objMethod = Maketype.GetMethod("GenericMethod");//方法
            //MethodInfo objMethodGeneric = objMethod.MakeGenericMethod(new Type[] { typeof(double), typeof(int) });//泛型类里的泛型方法---指定泛型方法的类型
            //objMethodGeneric.Invoke(objSqlHelper, new object[] { 12.34, 567 });
            #endregion
            #region 【5】使用反射调用方法
            //Assembly assembly = Assembly.LoadFrom("MySqlHelper.dll");//加载方式三，推荐
            //Type type = assembly.GetType("MySqlHelper.ReflectionTest");//获取类型，`3代表的是有3个泛型参数的类

            //object objSqlHelper = Activator.CreateInstance(type, true);//创建对象-----True可以访问私有的构造函数（反射可以用来破坏单例）
            //foreach (MethodInfo mtehod in type.GetMethods())
            //{
            //    Trace.WriteLine(mtehod.Name);
            //    foreach (ParameterInfo para in mtehod.GetParameters())
            //    {
            //        Trace.WriteLine(para.Name + "    " + para.ParameterType);
            //    }
            //}
            ////普通方法
            //MethodInfo objMethod = type.GetMethod("Test1");//调用无参数的方法
            //objMethod.Invoke(objSqlHelper, null);

            //MethodInfo objMethod2 = type.GetMethod("Test2");//调用有两个参数的方法
            //objMethod2.Invoke(objSqlHelper, new object[] { "123" ,123});

            ////重载方法
            //MethodInfo objMethod3 = type.GetMethod("Test3", new Type[] {});//调用同名的重载方法（重载方法要告知参数类型）
            //objMethod3.Invoke(objSqlHelper, null);

            //MethodInfo objMethod4 = type.GetMethod("Test3", new Type[] { typeof(string) });//调用同名的重载方法（重载方法要告知参数类型）
            //objMethod4.Invoke(objSqlHelper, new object[] { "123" });

            //MethodInfo objMethod5 = type.GetMethod("Test3", new Type[] { typeof(string), typeof(int) });//调用同名的重载方法（重载方法要告知参数类型）
            //objMethod5.Invoke(objSqlHelper, new object[] { "123", 456 });

            ////静态方法
            //MethodInfo objMethod6 = type.GetMethod("Test4", new Type[] { });//调用同名的静态重载方法（重载方法要告知参数类型）
            //objMethod6.Invoke(objSqlHelper, null);//等价于objMethod6.Invoke(null, null);

            //MethodInfo objMethod7 = type.GetMethod("Test4", new Type[] { typeof(string) });//调用同名的静态重载方法（重载方法要告知参数类型）
            //objMethod7.Invoke(objSqlHelper, new object[] { "123" });// 等价于objMethod7.Invoke(null, new object[] { "123" })

            //MethodInfo objMethod8= type.GetMethod("Test4", new Type[] { typeof(string), typeof(int) });//调用同名的静态重载方法（重载方法要告知参数类型）
            //objMethod8.Invoke(objSqlHelper, new object[] { "123", 456 });//等价于objMethod8.Invoke(null, new object[] { "123", 456 })

            ////私有方法
            //MethodInfo objMethod9 = type.GetMethod("Test5", BindingFlags.Instance|BindingFlags.NonPublic);//私有方法是实例时指定Instance，是静态时指定Static
            //objMethod9.Invoke(objSqlHelper, new object[] { "123", 456 });

            ////泛型方法
            //MethodInfo objMethod10 = type.GetMethod("Test6");
            //MethodInfo objMethodGeneric = objMethod10.MakeGenericMethod(new Type[] { typeof(double),typeof(int)});
            //objMethodGeneric.Invoke(objSqlHelper,new object[] {12.34,567 });
            #endregion



            #endregion

            #region 委托
            int[] source = new int[] { 23, 12, 67, 39, 45, 29, 89 };
            // SampleSortFirst.BubbleSort(source);

            //委托可以作为参数给给函数，把逻辑给分裂出来
            //CreateCompareDele _createDele = new CreateCompareDele(CreateCompare);
            //DelegateSort.BubbleSort(source, _createDele);
            //for (int i = 0; i < source.Length; i++)
            //{
            //    txtInfor.Text = txtInfor.Text + source[i] + ",";
            //}
            #endregion

            #region 委托可以简化逻辑
            //helloDelegate objhellowDelegate = new helloDelegate(hello);//创建委托实例,委托是和方法是成组实现的
            //objhellowDelegate.Invoke("你好，委托");//调用委托

            //List<LearnVip> objLearnVIPList = new List<LearnVip>();
            //objLearnVIPList.Add(new LearnVip() { id = 1, StudentName = "Ant1", Price = 700 });
            //objLearnVIPList.Add(new LearnVip() { id = 2, StudentName = "Ant2", Price = 400 });
            //objLearnVIPList.Add(new LearnVip() { id = 3, StudentName = "Ant3", Price = 800 });
            ////LearnVip.CheckVIP(objLearnVIPList);

            //IsVipDelegate IsVipDelegate = new IsVipDelegate(getVip2);
            //LearnVip.CheckVIP(objLearnVIPList, IsVipDelegate);

            #endregion

            #region 泛型委托
            //GenericDelegate _genericDelegate = new GenericDelegate();
            //textBox1.Text = _genericDelegate.InvokeDele<string>();
            #endregion

            #region 多播委托
            //带返回值的多播委托只返回最后一个方法的值
            //用匿名方法时生成的是不同的方法实例
            //给委托传递相同的方法时生成的委托实例也是相同的
            //MulticastDelegate multicastDelegate = new MulticastDelegate();

            #endregion

            #region 委托事件
            //【1】事件是 委托的安全版本，在定义事件类的外部。只能用+=来操作，关键字Event

            EventTest eventTest = new EventTest();
            eventTest.actionEvent += EventTest_actionEvent;//事件的订阅
            eventTest.sendEvent();
            #endregion

            #region 自定义的委托事件

            Publisher publisher = new Publisher();

            Subscriber subscriber = new Subscriber("1", publisher);
            Subscriber2 subscriber2 = new Subscriber2("2", publisher);

            publisher.CustomEvent += subscriber.HanderCustomEvent;  //事件订阅到方法
            publisher.CustomEvent += subscriber2.HanderCustomEvent; //事件订阅到方法
            publisher.DoSomething();

            #endregion

        }
   
    }

    #region 泛型类
    public class MyTest<T1, T2, T3>
    {
        private T1 t;
        private T2 t2;
        private T3 t3;
        public MyTest(T1 t, T2 t2, T3 t3)
        {
            this.t = t;
        }
        public void show()
        {
            Console.WriteLine("这是泛型类的输出------>" + t);
        }
    }

    #endregion

    #region  LearnVip类
    public class LearnVip
    {
        public string StudentName { get; set; }
        public int id { get; set; }

        public int Price { get; set; }

        public static void CheckVIP(List<LearnVip> _objLearnVipList, IsVipDelegate isVip)//定义委托变量
        {

            foreach (LearnVip item in _objLearnVipList)
            {
                if (isVip(item))    //if (item.Price>=599)
                {
                    Console.WriteLine($"Id：{item.id}+名字：{item.StudentName}是VIP学员");
                }
            }
        }
    }
    #endregion

    #region 委托的事件：先有委托后有事件
    public class EventTest
    {
        //Action是系统自带的泛型委托  public delegate void Action();
        public event Action actionEvent;//事件只能定义在类的内部
        public void sendEvent()
        {
            actionEvent?.Invoke();//?.Null检查空运算符
        }
    }
    #endregion

    #region LambdaTest
    public class LambdaTest
    {

        public void show()
        {

            //无参数的
            Action action = () => { Console.WriteLine("这是无参数"); };
            Action<string> action2 = (s) => { Console.WriteLine($"这是有1个参数{s}"); };

            Action<int, string> action3 = (i, s) => { Console.WriteLine($"这是有2个参数{s},{i}"); };

            Func<int, DateTime> func = (i) =>
            {
                Console.WriteLine($"这是有1个返回值{DateTime.Now},参数是{i}");
                return DateTime.Now;

            };
        }
    }
    #endregion

}
