using System.Collections;

namespace LotTick
{
    /// <summary>
    /// Index_红Ac值,修过完成
    /// </summary>
    public class Index_红Ac值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            ArrayList list = new ArrayList();
            int temp;
            for (int i = 0; i < data.NormalData .Length - 1; i++)
            {
                for (int j = i + 1; j < data.NormalData .Length; j++)
                {
                    temp = data.NormalData [j] - data.NormalData [i];
                    if (!list.Contains(temp))  list.Add(temp);//不存在即添加
                }
            }
            return list.Count - (data.NormalData .Length - 1);
        }
    }

    /// <summary>
    /// 尾数和值
    /// </summary>
    public class Index_红尾数和值 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Sum();
        }
    }

    /// <summary>
    /// 尾数组数
    /// </summary>
    public class Index_红尾数组数 : LotIndex
    {
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Select(n => n % 10).Distinct().Count();
        }
    }
}