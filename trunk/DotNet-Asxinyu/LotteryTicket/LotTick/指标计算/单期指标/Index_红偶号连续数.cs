using System.Linq;

namespace LotTick
{
    #region 偶号连续数
    /// <summary>
    /// 偶号连续数,修改完成
    /// </summary>
    public class Index_红偶号连续数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            bool[] res = data.NormalData.Select(n => n % 2 == 0).ToArray();
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }       
    }
    #endregion

    #region 红偶数个数
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
    #endregion

    #region 红奇号连续数
    /// <summary>
    /// Index_红奇号连续数
    /// </summary>
    public class Index_红奇号连续数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            bool[] res = data.NormalData.Select(n => n % 2 == 1).ToArray();//是否是奇数
            int count = 0;
            for (int i = 0; i < res.Length - 1; i++)
            {
                if (res[i + 1] && res[i]) count++;
            }
            return count;
        }
    }
    #endregion
}