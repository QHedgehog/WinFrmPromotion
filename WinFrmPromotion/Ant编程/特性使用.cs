using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace WinFrmPromotion
{
    public partial class 特性使用 : Form
    {
        public 特性使用()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            #region 特性的使用
            InfoLever my = InfoLever.Stop;
            InvokeAppendLine($"{my.GetRemark()}");
            #endregion

            DataOperate data = new DataOperate();
            InvokeAppendLine($"{data.GetShow()}");

            StudentInfor stu = new StudentInfor() { ID = "123", Name = "child", PhoneNum = "12345678901" };
            InvokeAppendLine($"{ stu.Valitate()}");
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
    }

    #region 【1】创建特性

    #region 抽象类可以查找多个类型的特性
    public abstract class abstrctAttribute : Attribute//抽象类
    {
        public abstract bool Validate(object objValue);
    }
    public class LongAttribute : abstrctAttribute
    {
        private long _long = 0;
        public LongAttribute(long phoneLength)
        {
            this._long = phoneLength;
        }
        public override bool Validate(object objValue)
        {
            return objValue != null && objValue.ToString().Length == 11;
        }
    }
    public class RequiredAttribute : abstrctAttribute
    {
        public override bool Validate(object objValue)
        {
            return objValue != null && !string.IsNullOrWhiteSpace(objValue.ToString());
        }
    }
    public class StringLengthAttribute : abstrctAttribute
    {
        public int Min = 0, Max = 0;
        public StringLengthAttribute(int min, int max)
        {
            this.Min = min;
            this.Max = max;
        }
        public override bool Validate(object objValue)
        {
            return objValue != null && objValue.ToString().Length >= Min && objValue.ToString().Length <= Max;
        }
    }
    #endregion

    [AttributeUsage(AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    public class RemarkAttribute : Attribute
    {
        public string Description { get; set; }
        public RemarkAttribute(string description)
        {
            Description = description;
        }
    }

    [AttributeUsage(AttributeTargets.All, AllowMultiple = true, Inherited = true)]
    public class ShowAttribute : Attribute
    {
        public string ShowInfor { get; set; }
        public string ShowMetnod()
        {
            return ShowInfor;//返回标记的属性
        }
    }
    #endregion

    #region 【2】标记特性
    public enum InfoLever
    {
        [Remark("报警")]
        Error = 1,
        [Remark("正常")]
        Normal = 2,
        [Remark("停止")]
        Stop = 3,
        [Remark("未知")]
        UnKnown = 4,
    }

    [Show(ShowInfor = "显示标记在类上的内容")]
    [Show(ShowInfor = "数据操作")]
    public class DataOperate
    {
        public DataOperate()
        {

        }

        [Show(ShowInfor = "显示标记在属性上的内容")]
        [Show(ShowInfor = "比例")]
        public int Scale { get; set; } = 100;

        [Show(ShowInfor = "显示标记在字段上的内容")]
        [Show(ShowInfor = "名称")]
        public string name;

        [Show(ShowInfor = "显示标记在方法上的内容")]
        [Show(ShowInfor = "加法运算")]
        public int Calculate(int x, int y)
        {
            return (x + y) * Scale;
        }
    }

    public class StudentInfor
    {
        [Required(), StringLength(3, 5)]
        public string Name { get; set; }
        public string ID { get; set; }

        [Long(11), Required(), StringLength(8, 11)]
        public string PhoneNum { get; set; }
    }
    #endregion

    #region 【3】调用特性（使用的是扩展方法）
    public static class AttributeInvoke
    {
        public static string GetRemark(this InfoLever inforLevel)
        {
            //获取某个枚举变量上的的特性
            Type type = inforLevel.GetType();
            var field = type.GetField(inforLevel.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute temp = (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                return temp.Description;
            }
            else
            {
                return inforLevel.ToString();
            }

        }
        public static string GetShow<T>(this T data) where T : new()//泛型方法查找特性
        {
            StringBuilder strBuilder = new StringBuilder();
            strBuilder.Clear();

            Type type = data.GetType();
            //获取类上标记的特性
            if (type.IsDefined(typeof(ShowAttribute), true))
            {
                object[] classAttributes = type.GetCustomAttributes(typeof(ShowAttribute), true);
                foreach (ShowAttribute attribute in classAttributes)
                {
                    strBuilder.AppendLine(attribute.ShowMetnod());
                }
            }
            //获取方法上标记的特性
            foreach (MethodInfo method in type.GetMethods())
            {
                if (method.IsDefined(typeof(ShowAttribute), true))
                {
                    object[] methodAttributes = method.GetCustomAttributes(typeof(ShowAttribute), true);
                    foreach (ShowAttribute attribute in methodAttributes)
                    {
                        strBuilder.AppendLine(attribute.ShowMetnod());
                    }
                }
            }

            //获取属性上标记的特性
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.IsDefined(typeof(ShowAttribute), true))
                {
                    object[] propertyAttributes = property.GetCustomAttributes(typeof(ShowAttribute), true);
                    foreach (ShowAttribute attribute in propertyAttributes)
                    {
                        strBuilder.AppendLine(attribute.ShowMetnod());
                    }
                }
            }
            //获取字段上标记的特性
            foreach (FieldInfo field in type.GetFields())
            {
                if (field.IsDefined(typeof(ShowAttribute), true))
                {
                    object[] propertyAttributes = field.GetCustomAttributes(typeof(ShowAttribute), true);
                    foreach (ShowAttribute attribute in propertyAttributes)
                    {
                        strBuilder.AppendLine(attribute.ShowMetnod());
                    }
                }
            }
            return strBuilder.ToString();
        }
        //特性验证
        public static bool Valitate<T>(this T data) where T : new()
        {
            Type type = data.GetType();
            foreach (PropertyInfo property in type.GetProperties())
            {
                if (property.IsDefined(typeof(abstrctAttribute), true))
                {
                    object[] propertyAttributes = property.GetCustomAttributes(typeof(abstrctAttribute), true);
                    object objValue = property.GetValue(data);
                    foreach (abstrctAttribute attribute in propertyAttributes)
                    {
                        if (!attribute.Validate(objValue))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

    }
    #endregion

}
