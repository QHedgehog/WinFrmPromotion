using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
namespace WinFrmPromotion
{
    class MulticastDelegate
    {
        public MulticastDelegate()
        {
            //系统自带的委托
            Action action = new Action(Method);
            action += Method2;
            action += Method3;
            action.Invoke();
            //   Func<string,string> func = new Func<string, string>(Method4);
            Func<string, string> func = ((str =>
            {
                Console.WriteLine(str);
                return str; 
            }));
            func.Invoke ("123456789");

        }
        public void Method()
        {
            Console.WriteLine("我是委托方法1");
        }
        public void Method2()
        {
            Console.WriteLine("我是委托方法2");
        }
        public void Method3()
        {
            Console.WriteLine("我是委托方法3");
        }
        public string Method4(string str)
        {
            return str;
        }

    }
}
