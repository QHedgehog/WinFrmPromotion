using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmPromotion
{
    //装饰器模式
    //向一个现有的对象添加新的功能，同时又不改变其功能，也就是在程序运行时能动态的扩展功能
    //组合+继承的融合应用，结构型设计模式的巅峰应用

    #region 实体类
    public abstract class AbstractStudent//实体抽象类
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public abstract string  Study();

       
    }

    //对象1
    public class StudentFree : AbstractStudent
    {      
        public override string Study()
        {
           
            return  $"{base.Name}is a Free Student,studying .net Free";
        }
    }

    //对象2
    public class StudentVip : AbstractStudent
    {
        public override string Study()
        {
          
            return $"{base.Name}is a VIP Student,studying .net VIP";
        }
    }
    #endregion

    //除了学习以外，需要扩展其他功能------比如获取视频观看
    //[方法1] 继承
    public class StudentVipVideo:StudentVip
    {
        public override string Study()
        {
            return $"{base.Study()}\r\n获取视频课件代码回看" ;    
        }
    }

    //[方法2] 组合,构造函数注入的方式
    public class StudentCombination
    {
        private AbstractStudent _student = null;
        public StudentCombination(AbstractStudent  student)
        {
            this._student = student;
        }
        public string Study()
        {
            return $"{this._student.Study()}\r\n获取视频课件代码回看";
        }
    
    }



    //除了学习以外，需要扩展其他功能------以任意的扩展和调整
    //使用装饰器模式的实现方式
    //装饰器的基类,abstract是为了避免外部直接使用
    public  class AbstractDecorator : AbstractStudent
    {
        private AbstractStudent _student = null;
        public AbstractDecorator(AbstractStudent student)
        {
            this._student = student;
            
        }
        public override string Study()
        {
            return this._student.Study();    
        }
    }
    
    //学生装饰器类：获取video
    public class StudentDecoratorVideo : AbstractDecorator
    {
       private AbstractStudent _student = null;
        public StudentDecoratorVideo(AbstractStudent student) :base(student)
        {
           _student = student;
        }
        public override string Study()
        {
            return $"{base.Study()}\r\n获取视频课件回看";
        }
    }

    //学生装饰器类：获取家庭作业
    public class StudentDecoratorHomeWork : AbstractDecorator
    {
        private AbstractStudent _student = null;
        public StudentDecoratorHomeWork(AbstractStudent student) : base(student)
        {
            _student = student;
        }
        public override string Study()
        {
            return $"{base.Study()}\r\n获取家庭作业并修改";
            //return $"{base.Study()}\r\n获取家庭作业";
        }
    }

}
