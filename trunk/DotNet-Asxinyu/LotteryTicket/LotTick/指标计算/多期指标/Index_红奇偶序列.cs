using System.Linq;
using System.Collections.Generic;

namespace LotTick
{
    #region 红奇偶序列  需要比较参数
    /// <summary>
    /// 红奇偶序列 最近几期相同的个数,只需要重载一个方法即可
    /// </summary>
    public class Index_红奇偶序列 : Index_红多期序列基类 
    {
        public override string GetSequence(LotTickData data)
        {
            return data.NormalData.ParitySequence();
        }
    }
    #endregion

    #region 红素合序列  需要比较参数
    /// <summary>
    /// 红素合序列 与前几期相同的个数
    /// </summary>
    public class Index_红素合序列 : Index_红多期序列基类
    {
        public override string GetSequence(LotTickData data)
        {
            return data.NormalData.PrimesSequence ();
        }    
    }
    #endregion

    #region 红奇偶素合序列,需要比较参数
    /// <summary>
    /// 红奇偶素合序列 最近几期 相同的个数
    /// </summary>
    public class Index_红奇偶素合序列 : Index_红多期序列基类
    {
        public override string GetSequence(LotTickData data)
        {
            return data.NormalData.ParitySequence() + data.NormalData.PrimesSequence ();
        }        
    }
    #endregion
}