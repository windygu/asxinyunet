using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Cache;
using System.Threading;
using XCode;
using HtmlAgilityPack;
using System.Linq;
using DotNet.Tools;
using Kw.Combinatorics;

namespace LotTick
{
    /// <summary>
    /// 双色球彩票类
    /// </summary>
    public class TwoColorBall : BasicLotTick
    {
        #region 公共变量
        private static int[] prizeReward = new int[7] { 0, 5000000, 200000, 3000, 200, 10, 5 };
        #endregion

        #region 构造函数
        /// <summary>
        /// 双色球构造函数
        /// </summary>
        public TwoColorBall(int calcuteRows)
        {
            //双色球有特殊的蓝球号码
            //this.IsSpecailMode = true;
            this.CalcuteRows = calcuteRows;
            //获取数据集,分别填充NormalData和SpecialData 
            this.LotData = GetBallData(calcuteRows);
        }

        #region 获取计算数据
        /// <summary>
        /// 从数据库获取指定期数红球数据
        /// </summary>
        /// <param name="length">最近的期数</param>
        public static LotTickData[] GetBallData(int selectLength = -1)
        {
            //获取数据 order by  desc 降序排列, asc 升序		
            EntityList<tb_Ssq> list = tb_Ssq.FindAll("", tb_Ssq._.期号 + " asc", "", 0, selectLength);
         // EntityList<tb_Ssq> list = tb_Ssq.FindAll("select * from tb_ssq order by 期号 asc");//升序
            LotTickData[] data = new LotTickData[list.Count];
            for (int i = 0; i < list.Count ; i++)
            {
                data[i] = new LotTickData();
                data[i].NormalData = new int[] { list[i].号码1, list[i].号码2, list[i].号码3, list[i].号码4,
                list[i].号码5 ,list[i].号码6};
                data[i].SpecialData = list[i].蓝球;
            }
            return data ;
        }
        #endregion
        #endregion

        #region 对规则列表进行验证和过滤
        public override bool[][] ValidateRuleList(RuleInfo[] ruleList)
        {
            bool[][] res = new bool[ruleList.Length][];
            for (int i = 0; i < ruleList.Length; i++)
            {
                //首先获取计算的数据,直接从data中获取
                LotTickData[] curData = new LotTickData[ruleList[i].CalcuteRows + ruleList[i].NeedRows];
                this.LotData.CopyTo(curData, LotData.Length  - this.CalcuteRows - ruleList[i].NeedRows);
                ruleList[i].IndexSelector.RuleInfoParams = ruleList[i]; 
                res[i] = ruleList[i].IndexSelector.GetValidateResult(curData);
            }
            return res;
        }
        public override LotTickData[] FilteByRuleList(RuleInfo[] ruleList)
        {
            //先按照优先级进行划分,对最高级进行处理后,组合为LotTickData[]，再进行其他的过滤
            //LotTickData[] res ;
            //for (int i = 0; i < ruleList.Length; i++)
            //{
            //    //首先获取计算的数据,直接从data中获取
            //    LotTickData[] curData = new LotTickData[ruleList[i].NeedRows];
            //    this.LotData.CopyTo(curData, LotData.Length + 1 - ruleList[i].NeedRows);
            //    res[i] = ruleList[i].IndexSelector.GetValidateResult(curData);
            //}
            //return res;
            return base.FilteByRuleList(ruleList);
        }
        public static int[][] GetInitiaData()
        {
            int[] data = new int[33];
            //初始化
            for (int i = 0; i < data.Length; i++) { data[i] = i + 1; }
            //迭代获取所有组合序列,并对每个序列进行判断         
            return new Combination(data.Length, 6).Rows.Select(n => n.ToArray()).ToArray();
        }
        #endregion

        #region 兑奖验证
        public override int GetPrizeGrade(LotTickData prizeNo, LotTickData testNo)
        {
            //循环的方式，蓝球分开，直接对比最后一位
            int n = prizeNo.NormalData.Index_S序列重复个数(testNo.NormalData);//红号相同个数
            int m = prizeNo.SpecialData == testNo.SpecialData ? 1 : 0;
            string str = string.Format("{0}-{1}", n, m);
            if ("0-0,1-0".Contains(str)) return 0;
            else if ("1-1,0-1,2-1".Contains(str)) return 6;
            else if ("3-1,4-0".Contains(str)) return 5;
            else if ("4-1,5-0".Contains(str)) return 4;
            else if ("5-1".Contains(str)) return 3;
            else if ("6-0".Contains(str)) return 2;
            else if ("6-1".Contains(str)) return 1;
            else return 0;
        }
        public override int[] GetAllPrizeGradesCount(LotTickData prizeNo, LotTickData[] testNoes)
        {
            int[] res = testNoes.Select(n => GetPrizeGrade(prizeNo, n)).ToArray();//每一注的结果，然后统计下
            int[] last = new int[7];
            foreach (var item in res) last[item]++;
            return last;
        }
        public override int GetAllPrizeReward(LotTickData prizeNo, LotTickData[] testNoes)
        {
            int[] gradeNum = GetAllPrizeGradesCount(prizeNo, testNoes);
            int sum = 0;
            for (int i = 0; i < gradeNum.Length; i++) sum += gradeNum[i] * prizeReward[i];//次数*单次的金额,并累加
            return sum;
        }
        #endregion

        #region 历史开奖数据更新
        /// <summary>
        /// 获取所有历史数据
        /// </summary>
        public static void UpdateAll()
        {
            string website;//动态获取的网址				
            tb_Ssq model = new tb_Ssq();
            int pages = GetAllPageNumbers();
            for (int i = 1; i <= pages; i++)
            {
                //福彩 /html[1]/body[1]/table[1]/tr[7]
                website = @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_" + i.ToString() + ".html";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(website);
                HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(@"/html[1]/body[1]/table[1]")[0].SelectNodes(@"tr");
                for (int j = 2; j < hc.Count - 1; j++)
                {
                    HtmlNodeCollection hc1 = hc[j].SelectNodes(@"td");
                    model.开奖日期 = Convert.ToDateTime(hc1[0].InnerText.Trim());
                    model.期号 = Convert.ToInt32(hc1[1].InnerText.Trim());
                    double[] tempNo = hc1[2].InnerText.Replace("\r\n", "").Trim().ConvertStrToDoubleList(' ');
                    model.号码1 = Convert.ToInt32(tempNo[0]);
                    model.号码2 = Convert.ToInt32(tempNo[1]);
                    model.号码3 = Convert.ToInt32(tempNo[2]);
                    model.号码4 = Convert.ToInt32(tempNo[3]);
                    model.号码5 = Convert.ToInt32(tempNo[4]);
                    model.号码6 = Convert.ToInt32(tempNo[5]);
                    model.蓝球 = Convert.ToInt32(tempNo[6]);
                    if (!model.Exist(new string[] { tb_Ssq._.期号 }))
                    {
                        model.Insert();//自动判断是否存在         
                    }
                    Console.WriteLine("第 " + i.ToString() + "页，第 " + j.ToString() + " 条");
                }
            }
        }
        public static int GetAllPageNumbers()
        {
            string allPagesPath = @"/html[1]/body[1]/table[1]/tr[23]/td[1]/p[2]/strong[1]";
            string website = @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html";
            HtmlWeb web = new HtmlWeb();
            HtmlDocument doc = web.Load(website);
            return Convert.ToInt32(doc.DocumentNode.SelectSingleNode(allPagesPath).InnerText);
        }
        /// <summary>
        /// 获取最新数据
        /// </summary>
        public static void UpdateRecent()
        {
            string website;//动态获取的网址				
            tb_Ssq model = new tb_Ssq();
            int pages = GetAllPageNumbers();
            for (int i = 1; i <= pages; i++)
            {
                //福彩 /html[1]/body[1]/table[1]/tr[7]
                website = @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_" + i.ToString() + ".html";
                HtmlWeb web = new HtmlWeb();
                HtmlDocument doc = web.Load(website);
                HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(@"/html[1]/body[1]/table[1]")[0].SelectNodes(@"tr");
                for (int j = 2; j < hc.Count - 1; j++)
                {
                    HtmlNodeCollection hc1 = hc[j].SelectNodes(@"td");
                    model.开奖日期 = Convert.ToDateTime(hc1[0].InnerText.Trim());
                    model.期号 = Convert.ToInt32(hc1[1].InnerText.Trim());
                    double[] tempNo = hc1[2].InnerText.Replace("\r\n", "").Trim().ConvertStrToDoubleList(' ');
                    model.号码1 = Convert.ToInt32(tempNo[0]);
                    model.号码2 = Convert.ToInt32(tempNo[1]);
                    model.号码3 = Convert.ToInt32(tempNo[2]);
                    model.号码4 = Convert.ToInt32(tempNo[3]);
                    model.号码5 = Convert.ToInt32(tempNo[4]);
                    model.号码6 = Convert.ToInt32(tempNo[5]);
                    model.蓝球 = Convert.ToInt32(tempNo[6]);
                    if (!model.Exist(new string[] { tb_Ssq._.期号 })) model.Insert();//自动判断是否存在
                    else return;
                    Console.WriteLine("第 " + i.ToString() + "页，第 " + j.ToString() + " 条");
                }
            }
        }
        #endregion
    }
}