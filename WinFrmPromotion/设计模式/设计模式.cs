using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmPromotion
{
    public partial class 设计模式 : Form
    {
        public 设计模式()
        {
            InitializeComponent();

        }

        #region 结构型设计模式-----包治百病

        //【1】适配器模式：组合优于继承，相对灵活一些
        //核心套路：没有什么技术问题是包一层不能解决的，如果有就再包一层

        //类适配器（继承）·
        //继承最大的问题是：侵入性，只能为单一类型服务

        //对象适配器       
        //组合的不好：其实是产生了新类
        //三种组合方式：可以换不同实例（子类或者抽象类）
        //1.私有属性或者字段注入-----------不可能为空
        //2.构造函数的注入-----------构造就得传进来不可能为空，可变的
        //3.公共方法注入-----------可能为空，需要才注入
        //属于补救模式，全新引用组件或者第三方类库的时候使用
        //对象适配器：解决的是对象适配问题，是新增业务，不是去扩展公共逻辑


        //[2]代理模式Proxy
        //代理模式给某一个对象提供一个代理对象，并由代理对象控制对原对象的引用
        //可以随意加日志、异常处理、权限、单例、缓存、事务
        //只要不是业务逻辑，都可以在这里扩展，而不影响实际的执行逻辑
        //代理模式：解决对象调用的问题，可以扩展公共逻辑，坚决不增业务


        //[3]装饰器模式
        //继承+组合的融合应用，可以任意的扩展和调整
        //装饰器：抽象类 is a 类型
        //很典型的，需要增加功能，但是对象不变的情况

        #endregion

        #region 行为型设计模式----甩锅大法
        //走一步看一步
        //关注的是对象和行为的分离，指的是方法放在哪个类里面


        //观察者模式：定义对象间的一对多的依赖关系，当一个对象的状态发生变化时，所有依赖他的对象都得到通知并自动更新
        //一个类里的方法过多依赖，过渡依赖
        //职责分析，  封装转移
        //事件是观察者模式的优雅实现，多播委托（1对多）
        //如果某件事发生了，希望触发一些列动作，观察者模式，观察者能做到随意增减的动作，
        //如果在流程中，有扩展业务的需求，观察者模式-------------几乎框架中所有使用event的地方，都是此用途
        //被观察者/主题，观察者有多少不知道，观察者之间和被观察者之间是松耦合的


        //模板方法：定义一个操作算法中框架，而将这些步骤延迟加载到子类中
        //抽象类-------------普通方法，抽象方法，虚方法
        //普通方法：子类都相同，看父类
        //抽象方法：子类都不相同，用子类
        //虚方法：大部分相同，子类和父类都有

        //普通方法是在编译时决定的，看左边
        //虚方法中和abstract是有运行时决定的，看右边（多态的，override----非常态）


        //行为型模式的巅峰之作---无止境的行为封装转移
        //context上下文，责任链模式
        //保证环节的稳定，可以灵活配置环节
        //流程式处理:：一个请求多个环节都参与处理
        //多规则处理：一个请求从多个环节中选择一个处理

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            //Test();
            //TestEvent();
            // MethodAdapter();
            //MethodProxy();
            MethodDecorator();
        }

        #region Adapter模式-----用于新增业务
        private void MethodAdapter()
        {
            //IHelper helper = new SqlHelper();
            //ShowMsg(helper.Add<设计模式>());
            ShowMsg("-----------------------------------------");

            IHelper helper2 = new RedisHelperInherit();
            ShowMsg(helper2.Add<设计模式>());

            //对象适配器的继承的缺点
            RedisHelperInherit redisHelperInherit = new RedisHelperInherit();
            ShowMsg(redisHelperInherit.AddRedis<设计模式>());//侵入性，可以直接访问到内部方法

            ShowMsg("-----------------------------------------");

            IHelper helper3 = new RedisHelperIObject();  //没有侵入性，缺点是：产生了一个新类
            ShowMsg(helper3.Add<设计模式>());

        }
        #endregion

        #region Proxy模式

        private void MethodProxy()
        {

            //ISubject subject = new RealSubject();
            //ShowMsg(subject.DoSomeThing());
            //ShowMsg(subject.GetSomeThing());
            ShowMsg("-----------------------------------------");

            ISubject subject1 = new ProxySubject();
            ShowMsg(subject1.DoSomeThing());
            ShowMsg(subject1.GetSomeThing());
        }
        #endregion


        #region Decorator模式
        private void MethodDecorator()
        {

            AbstractStudent student = new StudentFree() { ID = 123, Name = "天下" };
            //ShowMsg(student.Study());

            //AbstractStudent student1 = new StudentVip() { ID = 456, Name = "下午" };
            //ShowMsg(student1.Study());


            student = new StudentDecoratorVideo(student);//里式替换原则，派生类可以装进父类里
            student = new StudentDecoratorHomeWork(student);//引用指向新的对象
            ShowMsg(student.Study());


        }

        #endregion

        #region 测试  


        /// <summary>
        ///【1】 测试button事件
        /// </summary>
        private void TestEvent()
        {
            this.button1.Click += (o, eArgs) => { EventLog("Click", o, eArgs); };
            this.button1.KeyPress += (o, eArgs) => { EventLog("KeyPress", o, eArgs); };
            this.button1.MouseHover += (o, eArgs) => { EventLog("MouseHover", o, eArgs); };

        }
        private void EventLog(string title, object sender, EventArgs e)
        {
            ShowMsg($"Event--->{title}");
            ShowMsg($"Sender--->{sender}");
            ShowMsg($"Argument--->{e.GetType()}");
            foreach (PropertyDescriptor item in TypeDescriptor.GetProperties(e))
            {
                string name = item.DisplayName;
                object value = item.GetValue(e);
                ShowMsg($"Name={name},Value={value}");
            }
        }

        /// <summary>
        /// 【2】List集合的常用功能
        /// </summary>
        private void Test()
        {
            List<Infor> strList = new List<Infor>() {
                new Infor() { Name = "天下", Num = 1} ,
                new Infor() { Name = "江河", Num = 2} ,
                new Infor() { Name = "湖海", Num = 3} ,
               };
            Action<Infor> Print = (Infor X) => ShowMsg($"{X.Name},{X.Num}");//委托的lambda表达式

            strList.ForEach(Print);//遍历所有元素并显示

            //Predicate<Infor> match;
            strList.FindAll(new Predicate<Infor>((Infor X) => X.Num > 2)).ForEach(Print);  //返回所有Num>2的元素

            //Comparison<Infor> func = (Infor f1, Infor f2) => f1.Name.CompareTo(f2.Name);

            strList.Sort(new Comparison<Infor>((Infor f1, Infor f2) => f1.Name.CompareTo(f2.Name)));//按照Name进行排列

        }
        public class Infor
        {
            public string Name { get; set; }
            public int Num { get; set; }
        }
        #endregion

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="str"></param>
        private void ShowMsg(string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                txtResult.AppendText(string.IsNullOrEmpty(txtResult.Text) ? str : $"{Environment.NewLine + str}");
                txtResult.ScrollToCaret();
                txtResult.Refresh();
            }));
        }

    }
}
