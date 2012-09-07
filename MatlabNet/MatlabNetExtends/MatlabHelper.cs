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
    /// 
    /// TODO:将Matlab中的内置函数名做成枚举类型
    /// </summary>
    public static class MatlabHelper
    {
        /// <summary>
        /// 将MWNumericArray类型的数组转换为.NET下的数组
        /// 不需要任何方法，直接进行转换即可
        /// 比如(double[,])mw.ToArray(MWArrayComponent.Real);
        /// </summary>
        /// <param name="mw">MWNumericArray数组</param>
        static void Mh_ConvertToArray<T>(this MWNumericArray mw)
        {
            if ((mw.Dimensions[0] == 1) || (mw.Dimensions[1] == 1))
            {               
                var t = (T[])mw.ToArray(MWArrayComponent.Real );
            }
            else //多维情况
            {
                var t = (T[,])mw.ToArray(MWArrayComponent.Real);
            }
        }
    }
}