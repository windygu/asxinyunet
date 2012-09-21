using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BioInfo.Core
{      
    #region 特征提取基类
    /// <summary>
    /// 基类,封装所有基础的功能代码 
    /// </summary>
    public class BaseBioinfo
    {
        #region 提取一条序列的特征
        /// <summary>
        /// 获取一条序列的特征值
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="paramsVlue">其他参数设置</param>
        /// <returns>特征值</returns>
        public virtual double[] GetOneSequenceFeature(string strSequence, params object[] paramsVlue) { return null; }
        ///// <summary>
        ///// 获取一条序列的特征值
        ///// </summary>
        ///// <param name="strSequence">序列</param>
        ///// <returns>特征值</returns>
        //public virtual double[] GetOneSequenceFeature(string strSequence) { return GetOneSequenceFeature(strSequence); }
        #endregion

        #region 提取多条序列的特征
        /// <summary>
        /// 提取多条序列的特征值
        /// </summary>
        /// <param name="strSequence">多条序列数组</param>
        /// <param name="paramsVlue">其他参数设置</param>
        public virtual void GetMultiSequenceFeature(List<SequenceInfo> seq, params object[] paramsVlue)
        {
            foreach (var item in seq )
            {
                item.FeatureValue = GetOneSequenceFeature(item.Text);
            }                        
        }
        #endregion

        #region 提取整个文本块的特征,是否多余？因为序列需要切割之后，再计算特征值，先删除
        //public List<SequenceInfo> GetTextBlockFeature(string textBlock, params object[] paramsValue)
        //{
        //    //先分割文本框，为一个个的序列对象
        //    var temp = SequenceProcess.SplitBlockStringsByEnter(textBlock);
        //    foreach (var item in temp )
        //    {
        //        item.FeatureValue = GetOneSequenceFeature(item.Text, paramsValue);
        //    }
        //    return temp;
        //}

        /// <summary>
        /// 提取整个文件的特征值:先分割提取序列，然后提取序列的特征值
        /// </summary>
        /// <param name="fileName">序列所在的文件名</param>
        /// <returns>整个文件中所有序列的特征值</returns>
        //public List<SequenceInfo> GetTextBlockFeatureByFile(string fileName, params object[] paramsValue)
        //{
        //    using(StreamReader sr = new StreamReader (fileName))
        //    {
        //        return GetTextBlockFeature(sr.ReadToEnd(),paramsValue);
        //    }
        //}      
        #endregion     
    }
    #endregion
}