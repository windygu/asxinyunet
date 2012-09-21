using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using BioInfo.Core;

namespace BioInfo.Forcast
{
    /// <summary>
    /// 直接对序列进行分割，进行特征值提取的，进行SVM预测
    /// 中心'N'，总长度21
    /// 2012-09-19：初始版本
    /// </summary>
    public class Gpcrgly
    {
        private static KDH Cha_Kdh = new KDH();
        public static List<SequenceInfo> SvmTest(string textBlock,int totalLength = 21 ,char desChar = 'N')
        {            
            //先将不同序列分割开，并提取序列编码
            List<SequenceInfo> list = SequenceProcess.SplitBlockStringsByEnter(textBlock );
            //目前默认的是提取中心序列，字符为N，长度为21
            var spliteValue = SequenceProcess.GetCentrlString(list, totalLength, desChar);
            //提取特征
            Cha_Kdh.GetMultiSequenceFeature(spliteValue);
            return spliteValue;
        }
    }
}