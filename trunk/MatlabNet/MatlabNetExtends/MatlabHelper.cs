/******************************************************************************
 *  作者：       asxiyu@qq.com
 *  创建时间：   2012/9/7 星期五 8:35:02
 *
 *  Matlab.NET扩展类库
 *  由于某些情况下Matlab自带的MWArray无法满足需求，无故报错，不转转换，导致和.NET
 *  混合编程出现错误，因此提供相关转换和扩展功能。
 *  
 *   注意：该类库并不是通用类库，只适用一定范围内，具体请咨询开发者，应用实际需谨慎
 ******************************************************************************/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using MathWorks.MATLAB.NET.Arrays;
using MathWorks.MATLAB.NET.Utility;

namespace MathWorks.MATLAB.NET.Extends
{
    /// <summary>
    /// 注意此类方法下的所有方法名，均以Mh_开头，便于区分和使用
    /// </summary>
    public static class MatlabHelper
    {
        /// <summary>
        /// 将MWNumericArray类型的数组转换为.NET下的数组
        /// 1.如果是1*N，则转换为单一数组，如果是M*N ，则转换为多维数组
        /// 2.暂时只支持常见的 整形,长整形，双精度型，单精度（后续继续支持 布尔型，字符串）
        /// 3.
        /// </summary>
        /// <param name="mw">MWNumericArray数组</param>
        public static T[] Mh_ConvertToArray<T>(this MWNumericArray mw)
        {
            if ((mw.Dimensions[0] == 1) || (mw.Dimensions[1] == 1))
            {
                ArrayList al = new ArrayList(mw.Dimensions[0] * mw.Dimensions[1]);
                al.AddRange(mw.ToString().Split(' '));
                return (T[])al.ToArray(typeof(T));
            }
            else
            {
                object[][] res = new object[mw.Dimensions[0]][];
                ArrayList temp = new ArrayList();
                for (int i = 0; i <= res.GetLength (1); i++)
                {
                    //temp.Clear();
                    //temp.AddRange (
                    //for (int j = 0; j <mw.Dimensions [1] ; j++)
                    //{
                    //    temp.a
                    //}
                }
                return (T[])new object();
            }
        }
    }
}
