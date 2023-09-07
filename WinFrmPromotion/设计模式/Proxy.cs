using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace WinFrmPromotion
{
    public interface ISubject//抽象主体类，是一个普通的业务类型定义
    {
         string  GetSomeThing();


        string  DoSomeThing();

    }
    public class RealSubject : ISubject
    {
        
        public string DoSomeThing()
        {
            Thread.Sleep(100);
            int index = 0;
            for (int i = 0; i < 1000; i++)
            {
                index=index+i;
            }
            return $"在RealSubject里做了计算，Index={index}";
        }

        public string GetSomeThing()
        {
            Thread.Sleep(1000);

            return $"在RealSubject里等待了1s";
        }
    }//具体的主题角色，是业务逻辑的具体执行者



    //[Proxy模式]解决对象调用的问题，可以扩展公共逻辑，坚决不增业务
    public class ProxySubject : ISubject
    //把所有抽象主题类定义的方法限制委托给真实主题角色实现，并且在真实主题角色处理完毕前后做预处理和善后处理工作
    {

        private  ISubject subject = new RealSubject();
        public string DoSomeThing()
        {
           return  $"DoSomeThing时包了一层：{subject.DoSomeThing()}";
        }

        public string GetSomeThing()
        {
            return $"GetSomeThing时包了一层：{subject.GetSomeThing()}"; 
        }
    }

}
