using System.Linq;

namespace LotTick
{
    /// <summary>
    /// Index_红偶数个数，修改完成
    /// </summary>
    public class Index_红偶数个数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Where(n => ((int)n) % 2 == 0).Count();
        }     
    }
}