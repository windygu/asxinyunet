using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioinfoLibrary
{
    /// <summary>
    /// 生物信息学常规帮助类,一些变量，规则等
    /// </summary>
    public class BioinfoHelper
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
        #endregion
    }
}
