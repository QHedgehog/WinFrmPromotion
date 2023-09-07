using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.ComponentModel;

namespace WinFrmPromotion
{
    #region 静态类下的静态方法


    public static class SampleSortFirst
    {
        //冒泡排序方法
        public static void BubbleSort(int[] source)
        {
            //23,12,67,39,45,29,89
            int temp;
            for (int i = 0; i < source.Length; i++)//冒泡排序
            {
                for (int j = i; j < source.Length; j++)
                {
                    if (source[j] < source[i])
                    {
                        temp = source[j];
                        source[j] = source[i];
                        source[i] = temp;
                    }
                }
            }
        }
    }
    #endregion

    #region 枚举排序

    [Description("排序类型")]
    public enum SortType
    {
        [Description("升序")]
        Ascending,
        [Description("降序")]
        Descending
    }
    public class SampleSortSecond
    {
        public static void BubbleSort(int[] source, SortType sortType)
        {
            //23,12,67,39,45,29,89
            int temp;
            for (int i = 0; i < source.Length; i++)//冒泡排序
            {
                for (int j = i; j < source.Length; j++)
                {
                    bool swap = false;
                    switch (sortType)
                    {
                        case SortType.Ascending:
                            swap = source[i] < source[j];
                            break;
                        case SortType.Descending:
                            swap = source[i] > source[j];
                            break;
                        default:
                            break;
                    }
                    if (swap)
                    {
                        temp = source[j];
                        source[j] = source[i];
                        source[i] = temp;
                    }
                }
            }


        }

    }
    #endregion


    #region 委托排序



    public delegate bool CreateCompareDele(int i, int j);//定义委托
    public class DelegateSort
    {
        public static void BubbleSort(int[] source, CreateCompareDele _CreateCompareDele)
        {
            //23,12,67,39,45,29,89
            int temp;
            for (int i = 0; i < source.Length; i++)//冒泡排序
            {
                for (int j = i; j < source.Length; j++)
                {
                    if (_CreateCompareDele(source[j], source[i]))
                    {
                        temp = source[j];
                        source[j] = source[i];
                        source[i] = temp;
                    }
                }
            }
        }
    }

    #endregion

}
