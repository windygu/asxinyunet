using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LotTick
{
    /// <summary>
    /// 双色球彩票类
    /// </summary>
    public class TwoColorBall:BasicLotTick,IGetHistoryData 
    {
        /// <summary>
        /// 双色球构造函数
        /// </summary>
        public TwoColorBall()
        {
            //双色球有特殊的蓝球号码
            this.IsSpecailMode = true;
        }
        /// <summary>
        /// 获取所有历史数据
        /// </summary>
        public void UpdateAll()
        {

        }
        /// <summary>
        /// 获取最新数据
        /// </summary>
        public void UpdateRecent()
        {

        }
    }
}
