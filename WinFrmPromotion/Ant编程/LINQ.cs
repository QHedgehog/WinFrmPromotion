using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFrmPromotion
{
    //年少喜欢李白的恣意洒脱，中年更喜欢高适的大器晚成
    //年少以为天生我才必有用，中年尽人事听天命  
   
    //Linq核心是对数据源的操作，和扩展方法委托息息相关
    //委托---lambda---linq
    //IEnumerable是可迭代类型，只要类实现了IEnumerable
    //IEnumerator 枚举器
    //Linq To Object(数组、List集合)--内存里面的数据，按需获取用的时候才会去读数据
    //Linq To SQL(查询数据库用的)----在数据库查询
    //Linq To XML(插XML文件使用)
    //IQueryable：可迭代类型是IEnumerable的扩展，针对SQL使用，功能更强大
    //IEnumerable是在内存里进行数据查询的，IQueryable是在数据库全部完成后才进行结果返回的
    public partial class LINQ : Form
    {
        public LINQ()
        {
            InitializeComponent();
        }
        public void button1_Click(object sender, EventArgs e)
        {
            List<StudentLinq> studentsList = new List<StudentLinq>() {
                new StudentLinq{ ID=1,Name="姓名1",ClassID=1,Age=3 },
                new StudentLinq{ ID=2,Name="姓名2",ClassID=1,Age=5 },
                new StudentLinq{ ID=3,Name="姓名3",ClassID=2,Age=12 },
                new StudentLinq{ ID=4,Name="姓名4",ClassID=2,Age=10 },
                new StudentLinq{ ID=5,Name="姓名5",ClassID=3,Age=40 },
                new StudentLinq{ ID=6,Name="姓名6",ClassID=3,Age=35 } };
            List<StudentClassLinq> studentsClassList = new List<StudentClassLinq>() {
                new StudentClassLinq{ ID=1,Name="C#初级培训" },
                new StudentClassLinq{ ID=2,Name="Python" },
                new StudentClassLinq{ ID=3,Name="计算机基础"},
              };

            #region LinQ的Where
            //---匿名方法--lambda

            //int[] array = { 1, 2, 3, 4 };//数组继承于Array类型
            //foreach (var item in array)
            //{
            //    InvokeAppendLine.WriteLine(item);
            //}
            //FruitShop fruitShop = new FruitShop();

            //foreach (Fruit f in fruitShop)
            //{
            //    InvokeAppendLine(f.fruitName + ": " + f.fruitPrice);
            //}

            //Calculate myCalculate = new Calculate();
            //myCalculate.AddMulti(1, 2, 3);



            ////用委托判断班级的逻辑----扩展方法式
            //Func<StudentLinq, bool> func = chaxun;
            //Func<StudentLinq, bool> func2 = chaxun2;

            ////List<StudentLinq> list1 = Logic.DefineWhere(studentsList, func).ToList();//普通方法
            ////List<StudentLinq>  list1 = studentsList.DefineWhere(func).ToList();//扩展方法

            //List<StudentLinq> list1 = studentsList.Where(item => item.Age < 20).ToList();//官方的lambda表达式
            //List<StudentLinq> list1 = studentsList.DefineWhere(item => item.Age < 20).ToList();//自定义的扩展方法的lambda表达式

            ////表达式(最后生成的代码和方法一样)
            //List<StudentLinq> list3 = (from c  in studentsList 
            //                                           where c.Age < 20 
            //                                           select c ).ToList();
            //foreach (var item in list1)
            //{
            //    InvokeAppendLine($"{item.ID.ToString()},{item.Name.ToString()},{item.ClassID.ToString()},{item.Age.ToString()}");
            //}

            //用事件判断班级的逻辑
            //Logic.FuncEvent += chaxun2;
            //var list2 = Logic.DefineWhereEvent(studentsList);
            #endregion

            #region LINQ的select
            //var list1=studentsList.Select(s=>s);//返回自身类

            //var temp = new { id = 1, EnlishName = "Jimmy" };   //匿名类
            //var list1 = studentsList.Select(s => new                   //返回个匿名类
            //{
            //    ID = s.ID,
            //    Name = s.Name,
            //    Age = s.Age,
            //    Type = s.Age < 20 ? "chirld" : "Worker"
            //});
            //扩展方法方式
            //var list1 = studentsList.Select(s => new StudentLinqModel //这种投影的方式用于model类，常用来表示传输的数据
            //{
            //    ID = s.ID,
            //    Name = s.Name,
            //    ClassGrade = s.ClassID == 1 ? "Top" : "Common"
            //});
            ////表达式方式
            //var list2 = from s in studentsList
            //            select new StudentLinqModel
            //            {
            //                ID = s.ID,
            //                Name = s.Name,
            //                ClassGrade = s.ClassID == 1 ? "Top" : "Common"
            //            };
            //foreach (var item in list2)
            //{
            //    InvokeAppendLine($"{item.ID.ToString()},{item.Name.ToString()},{item.ClassGrade.ToString()}");
            //}
            #endregion

            #region Linq的Join
            ////表达式
            //var list1 = (from s in studentsList
            //            join c in studentsClassList on s.ClassID equals c.ID
            //            select new { ID = s.ID, Name = s.Name, ClassID = s.ClassID,ClassName = c.Name }).ToList();

            ////方法的方式
            //var list2 = studentsList.Join(studentsClassList,s=>s.ClassID,c=>c.ID ,(s,c) => new { ID = s.ID, Name = s.Name, ClassID = s.ClassID, ClassName = c.Name }).ToList();

            //foreach (var item in list2)
            //{
            //    InvokeAppendLine($"{item.ID.ToString()},{item.Name.ToString()},{item.ClassID.ToString()},{item.ClassName.ToString()}");
            //}
            #endregion

            #region Linq的其他方法
            //var list1 = studentsList.Take(3).ToList();//获取前几条的数据
            //var list2 = studentsList.Skip(1).
            //                    Take(2).ToList();//跳过几条获取前几条的数据
            //var list3 = studentsList.OrderBy(s=>s.ClassID).OrderByDescending(s=>s.Age).ToList();//排序方法
            //var list4 = studentsList.Where(s=>s.Name.Contains("1")).ToList();//模糊查找
            #endregion

            foreach (var item in studentsList)
            {
                InvokeAppendLine($"{item.ID.ToString()},{item.Name.ToString()},{item.ClassID.ToString()},{item.ClassID.ToString()}");
            }
        }

        //判断年龄的逻辑
        public static bool chaxun(StudentLinq stu)
        {
            return stu.Age > 10 ? true : false;
        }
        //判断班级的逻辑
        public static bool chaxun2(StudentLinq stu)
        {
            return stu.ClassID == 3 ? true : false;
        }


        private void InvokeAppendLine(string str)
        {
            this.BeginInvoke(new Action(() =>
            {
                txtResult.AppendText(string.IsNullOrEmpty(txtResult.Text) ? str : $"{Environment.NewLine + str}");
                txtResult.ScrollToCaret();
                txtResult.Refresh();
            }));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.txtResult.Clear();
        }

        private void LINQ_Load(object sender, EventArgs e)
        {

        }
    }

    #region IEnumerable类型的实体例
    public class Fruit
    {
        public string fruitName;
        public string fruitPrice;
        public Fruit(string fruitName, string fruitPrice)
        {
            this.fruitName = fruitName;
            this.fruitPrice = fruitPrice;
        }
    }
    class FruitShop : IEnumerable
    {
        Fruit[] fruits = new Fruit[5];
        int startingPoint = 0;
        public FruitShop()
        {
            fruits[0] = (new Fruit("Apple", "10"));
            fruits[1] = (new Fruit("Pear", "12"));
            fruits[2] = (new Fruit("Grape", "15"));
            fruits[3] = (new Fruit("Orange", "18"));
            fruits[4] = (new Fruit("banana", "20"));

        }
        public IEnumerator GetEnumerator()
        {
            for (int index = 0; index < fruits.Length; index++)
            {
                yield return fruits[(index + startingPoint) % fruits.Length];
            }

        }
    }

    #endregion

    #region 扩展方法
    //静态类里的静态方法，参数列表前方加个新参数（this +要扩展的类型）
    //使用场景：在不修改源码的情况下为其他类型增加功能或者方法
    public class Calculate
    {
        private int Add(int x, int y)
        {
            return x + y;
        }
    }
    public static class CalculateExtend //对之前类的扩展，不改变原类型和原方法
    {

        public static int AddMulti(this Calculate calculate, int X, int Y, int Z)
        {
            return X + Y + Z;
        }
    }
    #endregion

    #region Linq
    public class StudentLinqModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string ClassGrade { get; set; }
    }
    public class StudentLinq
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int ClassID { get; set; }
        public int Age { get; set; }

    }

    public class StudentClassLinq
    {
        public int ID { get; set; }
        public string Name { get; set; }

    }
    public static class Logic
    {
        //【方式1】定义委托
        //public static List<StudentLinq> DefineWhere(this List<StudentLinq> stu, Func<StudentLinq, bool> funcDelegate)
        //{
        //    List<StudentLinq> students = new List<StudentLinq>();
        //    foreach (StudentLinq item in stu)
        //    {
        //        if (funcDelegate.Invoke(item))
        //        {
        //            students.Add(item);
        //        }
        //    }
        //    return students;
        //}
        public static IEnumerable<TSource> DefineWhere<TSource>(this IEnumerable<TSource> stu, Func<TSource, bool> funcDelegate)
        {
            List<TSource> students = new List<TSource>();
            foreach (TSource item in stu)
            {
                if (funcDelegate.Invoke(item))
                {
                    students.Add(item);
                }
            }
            return students;
        }
        //【方式2】定义事件委托
        public static event Func<StudentLinq, bool> FuncEvent;
        public static List<StudentLinq> DefineWhereEvent(List<StudentLinq> stu)
        {
            List<StudentLinq> students = new List<StudentLinq>();
            foreach (StudentLinq item in stu)
            {
                if (FuncEvent(item))
                {
                    students.Add(item);
                }
            }
            return students;
        }

    }

    #endregion
}
