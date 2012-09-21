using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioInfo.Core
{
    #region 常规静态字段以系统信息
    /// <summary>
    /// 常规静态字段以系统信息
    /// </summary>
    public class NormalField
    {
        #region 静态变量
        /// <summary>
        /// 氨基酸序列(20条):已经排除掉非氨基酸字母
        /// </summary>
        public static string NormalSeqence = "ACDEFGHIKLMNPQRSTVWY";
        /// <summary>
        /// 相对氨基酸序列的非法字符,即需要排除的序列，另外就是排除所有非字母字符
        /// </summary>
        public static string RemoveCharacters = "BJOUXZ";
        /// <summary>
        /// Svm测试结果显示的默认列名称
        /// </summary>
        public static string[] DefaultSvmDisplayColumnsNames = { };
        /// <summary>
        /// Svm测试结果显示的特殊列名称:多一列
        /// </summary>
        public static string[] SpecialSvmDisplayColumnsNames = { };
        #endregion
    }
    #endregion

    #region 序列信息类
    /// <summary>
    /// 基本序列信息
    /// 序列的预测信息,主要用于截取后的序列，预测后的值
    /// </summary>
    public class SequenceInfo
    {
        public string Name { get; set; }
        public string Text { get; set; }
        /// <summary>
        /// 该条序列的特征值
        /// </summary>
        public double[] FeatureValue { get; set; }
        public string HtmlText { get; set; }
        public int Position { get; set; }
        public double Probability { get; set; }
        public SequenceInfo()
        { }
        public SequenceInfo(string name, string text)
        {
            this.Name = name;
            this.Text = text;
        }
    }
    #endregion

    #region 特征提取类型枚举
    /// <summary>
    /// 特征提取类型枚举
    /// </summary>
    public enum FeatureExtractionType
    {
        /// <summary>
        /// 氨基酸疏水性
        /// </summary>
        KDH,
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
}
