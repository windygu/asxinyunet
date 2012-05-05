using System.Linq;

namespace LotTick
{
    /// <summary>
    /// 红和值
    /// </summary>
    public class Index_红和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Sum();
        }        
    }

    /// <summary>
    /// 大号个数，>=17,修改完成
    /// </summary>
    public class Index_红大号个数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Where(k => k >= 17).Count();
        }
    }

    /// <summary>
    /// 红跨度和值
    /// </summary>
    public class Index_红跨度和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Last() - data.NormalData.First();
        }
    }
}