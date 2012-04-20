using System.Linq;

namespace LotTick
{
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
}