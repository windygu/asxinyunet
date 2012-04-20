
namespace LotTick
{
    /// <summary>
    /// Index_红质数个数
    /// </summary>
    public class Index_红质数个数 : LotIndex
    {
        public static readonly int[] PrimeNumbers = new int[] { 2, 3, 5, 7, 11, 13, 17, 19, 23, 29, 31 };
        public override int GetOneResult(LotTickData data)
        {
            return data.NormalData.Index_S序列重复个数(PrimeNumbers);
        }        
    }
}