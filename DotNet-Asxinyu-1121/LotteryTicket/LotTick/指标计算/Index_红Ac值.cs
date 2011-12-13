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
                    if (!list.Contains(temp))
                    {
                        list.Add(temp);
                    }
                }
            }
            return list.Count - (data.NormalData .Length - 1);
        }       
    }
}