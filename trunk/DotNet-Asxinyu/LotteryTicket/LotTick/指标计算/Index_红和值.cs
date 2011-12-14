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
}