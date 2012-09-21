using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace BioinfoLibrary
{
    #region 特征提取类型枚举
    /// <summary>
    /// 特征提取类型枚举
    /// </summary>
    public enum FeatureExtractionType
    {
        /// <summary>
        /// 小波分析
        /// </summary>
        WaveLet,
        /// <summary>
        /// 位置权重
        /// </summary>
        Wacc,
        /// <summary>
        /// 自相关
        /// </summary>
        ACF,
        /// <summary>
        /// 分组重量编码
        /// </summary>
        GroupWeight,
        /// <summary>
        /// 改进位置权重
        /// </summary>
        ImproveWacc
    }
    #endregion
       
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
        /// <summary>
        /// 获取一条序列的特征值
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <returns>特征值</returns>
        public virtual double[] GetOneSequenceFeature(string strSequence) { return null ; }
        #endregion

        #region 提取多条序列的特征
        /// <summary>
        /// 提取多条序列的特征值
        /// </summary>
        /// <param name="strSequence">多条序列数组</param>
        /// <param name="paramsVlue">其他参数设置</param>
        /// <returns>多条序列特征值</returns>
        public double[][] GetMultiSequenceFeature(string[] strSequence, params object[] paramsVlue)
        {
            double[][] res = new double[strSequence.Length][];
            for (int i = 0; i < strSequence.Length; i++)
            {
                res[i] = GetOneSequenceFeature(strSequence[i],paramsVlue);//逐一提取特征
            }
            return res ;
        }
        #endregion

        #region 提取整个文本块的特征
        /// <summary>
        /// 提取整个文本块的特征值:先分割提取序列，然后提取序列的特征值
        /// </summary>
        /// <param name="textBlock">文本块</param>
        /// <returns>整个文本块的特征值</returns>
        public double[][] GetTextBlockFeature(string textBlock)
        {
            return GetMultiSequenceFeature (SplitTextBlock (textBlock )) ;
        }

        /// <summary>
        ///  提取整个文本块的特征值:先分割提取序列，然后提取序列的特征值
        /// </summary>
        /// <param name="textBlock">文本块</param>
        /// <param name="strNames">返回对应序列的名称</param>
        /// <returns>整个文本块的特征值</returns>
        public double[][] GetTextBlockFeature(string textBlock, out string[] strNames)
        {
            return GetMultiSequenceFeature (SplitTextBlock (textBlock,out strNames)) ;
        }
        /// <summary>
        /// 提取整个文件的特征值:先分割提取序列，然后提取序列的特征值
        /// </summary>
        /// <param name="fileName">序列所在的文件名</param>
        /// <returns>整个文件中所有序列的特征值</returns>
        public double[][] GetTextBlockFeatureByFile(string fileName)
        {
            using(StreamReader sr = new StreamReader (fileName ))
            {
                return GetMultiSequenceFeature(SplitTextBlock (sr.ReadToEnd ())) ;
            }
        }

        /// <summary>
        ///  提取整个文件的特征值:先分割提取序列，然后提取序列的特征值
        /// </summary>
        /// <param name="fileName">序列所在的文件名</param>
        /// <param name="strNames">对应序列的名称</param>
        /// <returns>整个文件中所有序列的特征值</returns>
        public double[][] GetTextBlockFeatureByFile(string fileName,out string[] strNames)
        {
            using (StreamReader sr = new StreamReader(fileName))
            {
                return GetMultiSequenceFeature(SplitTextBlock(sr.ReadToEnd(), out strNames));
            }
        }
        #endregion

        #region 分割整个文本块得到序列集合
        /// <summary>
        /// 分割整个文本块得到序列集合
        /// </summary>
        /// <param name="textBlock">序列文本块</param>
        /// <returns>分割后的序列集合</returns>
        public string[] SplitTextBlock(string textBlock)
        {
            return SequenceProcess.SplitStringsByEnter(textBlock);
        }
        /// <summary>
        /// 分割整个文本块得到序列集合和对应序列的名称
        /// </summary>
        /// <param name="textBlock">序列文本块</param>
        /// <param name="strNames">对应序列的名称</param>
        /// <returns>分割后的序列集合</returns>
        public string[] SplitTextBlock(string textBlock, out string[] strNames)
        {
            return SequenceProcess.SplitStringsByEnter(textBlock, out strNames);
        }
        #endregion

        #region 序列截取
        /// <summary>
        /// 获取以指定元素为中心的左右序列，不足补O       
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="allLength">截取的总长度</param>
        /// <param name="desChar">截取目标字符串</param>
        /// <returns>截取序列集合</returns>
        public string[] PickOffSequence(string strSequence, int allLength, char desChar)
        {
            return SequenceProcess.GetCentrlString(strSequence, allLength, desChar);
        }
        /// <summary>
        /// 获取以指定元素为中心的左右序列，不足补O
        /// </summary>
        /// <param name="strSequence">序列</param>
        /// <param name="allLength">截取的总长度</param>
        /// <param name="desChar">截取目标字符串</param>
        /// <param name="pos">指定字符出现的位置</param>
        /// <returns>截取序列集合</returns>
        public string[] PickOffSequence(string strSequence, int allLength, char desChar, out int[] pos)
        {
            return SequenceProcess.GetCentrlString(strSequence, allLength, desChar, out pos);
        }
        #endregion
    }
    #endregion
}