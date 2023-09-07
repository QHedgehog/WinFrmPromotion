using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmPromotion
{
    #region 声明事件CustomerEventArgs
    public class CustomerEventArgs : EventArgs
    {
        public string Message { get; set; }
        public CustomerEventArgs(string message)
        {
            Message = message;
        }

    }
    #endregion
 
    #region 事件的发布者
    public class Publisher
    {
        // public delegate void EventHandler<TEventArgs>(object sender, TEventArgs e);//EventHandler本身就是个泛型委托
        public event EventHandler<CustomerEventArgs> CustomEvent;//定义事件
        public virtual void OnCustomEvent(CustomerEventArgs e)//虚方法
        {
            CustomEvent?.Invoke(this, e);  //调用事件
        }
        public void DoSomething()
        {
            OnCustomEvent(new CustomerEventArgs("我是发布者，我进行了事件发布"));
            //CustomEvent?.Invoke(this, new CustomerEventArgs("我是发布者，我进行了事件发布"));  //调用事件
        }
    }
    #endregion



    #region  事件的订阅者
    public class Subscriber
    {
        private readonly string Str;//只读属性允许在声明时赋值/在构造函数里赋值
        public Subscriber(string str, Publisher publisher)
        {
            //订阅事件
            Str = str;
        }
        public void HanderCustomEvent(object sender, CustomerEventArgs e)
        {
            Console.WriteLine($"发布者的类型---->{sender.GetType()},订阅者---->{Str},参数是---->{e.Message}");
        }
    }
    #endregion

    #region 事件的订阅者
    public class Subscriber2
    {
        private readonly string Str;
        public Subscriber2(string str, Publisher publisher)
        {
            //订阅事件
            Str = str;
        }
        public void HanderCustomEvent(object sender, CustomerEventArgs e)
        {
            Console.WriteLine($"发布者的类型---->{sender.GetType()},订阅者---->{Str},参数是---->{e.Message}");
        }
    }
    #endregion

}
