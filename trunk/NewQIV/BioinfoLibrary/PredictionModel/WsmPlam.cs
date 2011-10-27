using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary.PredictionModel
{
    /// <summary>
    /// 预测模型基类,获取特征值，并对结果进行组合，得到网页代码
    /// </summary>
    public class BasicPredictionModel
    {
        //能够让预测模型之间自由组合,计算特征值
        //计算特征值后，进行预测，也是一致的
        /// <summary>
        /// 获得当前模型的特征值
        /// </summary>
        /// <param name="combFeatureList">特征算法组合列表</param>
        /// <param name="text">文本块</param>
        /// <returns>根据特征组合列表得到的特征值</returns>
        public double[][] GetCutModelFeature(BaseBioinfo[] combFeatureList,string text)
        {
            string[] seqsName;
            string[] str = SequenceProcess.SplitStringsByEnter(text, out seqsName);
            double[][] res = new double[str.Length ][] ;
            return res;
        }
    }

    /// <summary>
    /// Wsm-Plam模型
    /// </summary>
    public class WsmPlam
    {
        
    }
}
