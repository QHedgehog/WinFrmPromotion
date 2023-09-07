using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace MySqlHelper
{
    public interface IDBHlper
    {
        void Query();
    }
    public class MySqlHelper : IDBHlper
    {
        public MySqlHelper()
        {
            Trace.WriteLine($"{this.GetType().Name}被构造");
        }
        public MySqlHelper(string str)
        {
            Trace.WriteLine($"{this.GetType().Name}被构造,带1个参数{str}");
        }
        public void Query()
        {
            Trace.WriteLine($"{this.GetType().Name}.Query");
        }
    }

    public class ReflectionTest
    {
        private ReflectionTest()
        {
            Trace.WriteLine($"这是无参数的构造函数");
        }

        public ReflectionTest(string str)
        {
            Trace.WriteLine($"这是有一个参数的构造函数{str}");
        }
        public ReflectionTest(int id)
        {
            Trace.WriteLine($"这是有一个参数的构造函数{id}");
        }
        public ReflectionTest(string str, int id)
        {
            Trace.WriteLine($"这是有2个参数的构造函数{str},{id}");
        }

        public void Test1()
        {
            Trace.WriteLine($"这是无参数的方法");
        }
        public void Test2(string str, int id)
        {
            Trace.WriteLine($"这是有两个参数的方法{str}、{id}");
        }

        //重载方法
        public void Test3()
        {
            Trace.WriteLine($"这是无参数的重载方法");
        }

        public void Test3(string str)
        {
            Trace.WriteLine($"这是有一个参数的重载方法{str}");
        }

        public void Test3(string str, int id)
        {
            Trace.WriteLine($"这是有两个参数的重载方法{str}、{id}");
        }
        //静态方法
        public static void Test4()
        {
            Trace.WriteLine($"这是无参数的静态重载方法");
        }
        public static void Test4(string str)
        {
            Trace.WriteLine($"这是有一个参数的静态重载方法{str}");
        }

        public static void Test4(string str, int id)
        {
            Trace.WriteLine($"这是有两个参数的静态重载方法{str}、{id}");
        }
        //私有方法
        private void Test5(string str, int id)
        {
            Trace.WriteLine($"这是有两个参数的私有静态方法{str}、{id}");
        }

        //泛型方法
        public void Test6<T, W>(T t1, W w1)
        {
            Trace.WriteLine($"这是有2个参数的泛型方法{t1}、{w1}");
        }

    }


    public class GenericClass<T, W, S>
    {
        public GenericClass(T t1, W t2, S t3)
        {
            Trace.WriteLine($"这是有3个参数的构造方法{t1}、{t2}、{t3}");
        }
        public void GenericMethod<X, Y>(X t1,  Y w1)
        {

            Trace.WriteLine($"这是有2个参数的泛型方法{t1}、{w1}");
        }
    }
}
