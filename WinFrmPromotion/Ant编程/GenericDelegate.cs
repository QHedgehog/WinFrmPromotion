using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFrmPromotion
{
    public delegate T GenericDele<T>(T t);//声明泛型委托
 
    [Description("泛型委托")]
   public  class GenericDelegate
    {
        [Description("泛型方法，返回值是泛型")]
        public T InvokeDele<T>()
        {
            GenericDele<string> genericDele = new GenericDele<string>(Method);
            return (T)(object)genericDele("泛型委托---string类型");

            //GenericDele<int[]> genericDele2 = new GenericDele<int[]>(Method2);
            //int[] m = genericDele2(new int[] { 1, 2, 3, 4 });
            //string s = "'";
            //foreach (int item in m)
            //{
            //    s = s + item.ToString() + ",";
            //}
            //return (T)(object)s;
        }
        public string Method(string s)
        {
            return s;
        }
        public int[] Method2(int[] s)
        {

            return s;
        }
    }
}
