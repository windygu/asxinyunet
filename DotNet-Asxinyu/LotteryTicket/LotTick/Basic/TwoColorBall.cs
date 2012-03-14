using System;
using System.Collections.Generic;
using System.Linq;
using DotNet.Tools;
using HtmlAgilityPack;
using Kw.Combinatorics;
using XCode;
using System.IO;
using System.Xml;

namespace LotTick
{
    /// <summary>
    /// 双色球彩票类
    /// </summary>
    [System.Runtime.InteropServices.GuidAttribute("3AAEA75F-E313-4290-81E3-C6D79F97A0F1")]
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
            this.CalcuteRows = calcuteRows;
            //获取数据集,分别填充NormalData和SpecialData 
            this.LotData = GetBallData(calcuteRows);
        }

        #region 获取计算数据
        /// <summary>
        /// 从数据库获取指定期数数据
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
        /// <summary>
        /// 获取计算所需数据,从已有的数据中直接获取,用于过滤
        /// </summary>        
       public static LotTickData[] GetNeedDataByCache(int needRows)
        {            
            if (needRows <= 0) return null;
            else
            {
                LotTickData[] data = GetBallData();
                LotTickData[] curData = new LotTickData[needRows];
                data.CopyTo(curData, data.Length - needRows);
                return curData;
            }
        }
        //根据期号获取最近的几期数据
        //public static LotTickData[] GetNeedDataByNo()
        //{
        //}
        #endregion
        #endregion

        #region 对规则列表进行验证和过滤
        #region 过滤方法-封装加载初始配置和不加载的情况
        /// <param name="ruleList">规则列表</param>
        public override bool[][] ValidateRuleList(RuleInfo[] ruleList)
        {
            bool[][] res = new bool[ruleList.Length][];
            for (int i = 0; i < ruleList.Length; i++)
            {
                //首先获取计算的数据,直接从data中获取              
                ruleList[i].IndexSelector.RuleInfoParams = ruleList[i];
                res[i] = ruleList[i].IndexSelector.GetValidateResult
                    (GetNeedDataByCache(ruleList[i].CalcuteRows + ruleList[i].NeedRows));
            }
            return res;
        }
        
        /// <summary>
        /// 根据过滤规则数据，对数据进行过滤:这是不使用提前方案
        /// 直接对所有数据过滤，速度较慢
        /// </summary>
        /// <param name="ruleList">规则列表</param>
        /// <param name="filterInfos">过滤信息</param>
        /// <returns>过滤后的数据集合</returns>
        /// <param name="fileName">需要加载的初始数据文件名称</param>
        public override LotTickData[] FilteByRuleList(RuleInfo[] ruleList, 
            out Dictionary<int, string> filterInfos,string fileName = null )
        {
            if (fileName == null)
                return FilterByNotUsePrepareData(ruleList, out filterInfos);//不使用预处理数据
            else
                return FilterByUsePrepareData(ruleList,out filterInfos,fileName );//使用初始数据
        }
        #endregion

        #region 不使用提前方案，直接进行过滤，需要对规则分类，杀号优先处理后，再组合
        private LotTickData[] FilterByNotUsePrepareData(RuleInfo[] ruleList, out Dictionary<int, string> filterInfos)
        {
            //先获取优先级列表,从指标数据表中获取           
            RuleInfo[] First = ruleList.Where(n => tb_IndexInfo.Find(tb_IndexInfo._.IndexName,
                n.IndexSelector.ToString().Replace("LotTick.Index_", "")).PriorLevel == 6).ToArray();
            RuleInfo[] Last = ruleList.Where(n => tb_IndexInfo.Find(tb_IndexInfo._.IndexName,
                n.IndexSelector.ToString().Replace("LotTick.Index_", "")).PriorLevel < 6).ToArray();           
            //先按照优先级进行划分,对最高级进行处理后,分为杀红号和杀蓝号
            LotTickData[] InitData = GetInitiaDataByNotUserPrepareData(First);
            //组合为LotTickData[]，再进行其他的过滤，并输出过滤信息,过滤前后的数目
            return FilterByRules(InitData, Last, out filterInfos);
        }
        #endregion

        #region 根据规则数组批量过滤
        public static LotTickData[] FilterByRules(LotTickData[] InitData,RuleInfo[] rules,
            out Dictionary<int, string> filterInfos)
        {
            filterInfos = new Dictionary<int, string>();
            for (int i = 0; i < rules.Length; i++)
            {
                //首先获取计算的数据,直接从data中获取              
                rules[i].IndexSelector.RuleInfoParams = rules[i];
                int firCount = InitData.Length;
                InitData = rules[i].IndexSelector.GetFilterResult(InitData,
                    GetNeedDataByCache(rules[i].NeedRows));
                int lastCount = InitData.Length;
                //如何返回过滤信息？用字典，加一个规则编号和结果信息
                filterInfos.Add(rules[i].RuleID, (firCount - lastCount).ToString());
            }
            return InitData;
        }
        #endregion

        #region 使用指定初始数据进行过滤
        private LotTickData[] FilterByUsePrepareData(RuleInfo[] ruleList,
            out Dictionary<int, string> filterInfos, string fileName )
        {
            //先加载初始数据，初始数据只有红球，然后对最高优先级进行处理，然后合并，再进行其他处理
            LotTickData[] firData = ReadData(fileName);
            //TODO:最高优先级处理，并杀号，再组合，并进行其他过滤
            RuleInfo[] First = ruleList.Where(n => tb_IndexInfo.Find(tb_IndexInfo._.IndexName,
                n.IndexSelector.ToString().Replace("LotTick.Index_", "")).PriorLevel == 6).ToArray();
            LotTickData[] secData = FilterByRules(firData, First, out filterInfos);//过滤
            //排序，按照优先级大小进行
            RuleInfo[] LastOrder = ruleList.OrderByDescending(n=>tb_IndexInfo.Find(tb_IndexInfo._.IndexName,
                n.IndexSelector.ToString().Replace("LotTick.Index_", "")).PriorLevel).ToArray();            
            return FilterByRules(firData, LastOrder, out filterInfos);
        }
        #endregion

        #region 最高优先级杀号处理
        public static LotTickData[] DeleteNoProcess(LotTickData[] preData, RuleInfo[] ruleList)
        {
            for (int i = 0; i < ruleList.Length; i++)
            {
                preData = ruleList[i].IndexSelector.GetFilterResult(preData);             
            }
            return preData;
        }
        #endregion

        #region 不是用预处理直接获取数据初始化
        /// <summary>
        /// 获取杀号类型规则后形成的列表:适用于不是用预处理直接获取数据的情况
        /// </summary>
        /// <param name="ruleList">杀号规则列表</param>
        public static LotTickData[] GetInitiaDataByNotUserPrepareData(RuleInfo[] ruleList)
        {
            List<int> RedBall = new List<int>(33);
            List<int> BlueBall = new List<int>(16);
            //初始化            
            for (int i = 0; i <33 ; i++) RedBall.Add (i +1);
            for (int i = 0; i <16 ; i++) BlueBall.Add (i +1);
            for (int i = 0; i < ruleList.Length ; i++)
            {
                LotTickData[] curData = new LotTickData[ruleList[i].CalcuteRows + ruleList[i].NeedRows];
                if (ruleList[i].IndexSelector.ToString().Contains("红")) //杀红
                    RedBall =RedBall.Except(ruleList[i].IndexSelector.DeleteNumbers(curData)).ToList ();
                else                                                     //杀篮
                    BlueBall =BlueBall.Except(ruleList[i].IndexSelector.DeleteNumbers(curData)).ToList ();
            }
            //对红和蓝进行组合、迭代获取所有组合序列,并对每个序列进行判断         
            int[][] Red = new Combination(RedBall.Count , 6).Rows.Select
                (n => Combination.Permute(n, RedBall ).ToArray()).ToArray();
            LotTickData[] res = new LotTickData[Red.GetLength(0) * BlueBall.Count];//总数
            int count = 0;
            for (int i = 0; i < Red.GetLength(0); i++)
            {
                for (int j = 0; j < BlueBall.Count ; j++)
                {
                    res[count] = new LotTickData();//红蓝组合
                    res[count].NormalData = Red[i];
                    res[count++].SpecialData = BlueBall[j];
                }
            }
            return res ;
        }
        #endregion
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
                    //bool s = !model.Exist(new string[] {tb_Ssq._.期号 });
                    if (tb_Ssq.FindBy期号(model.期号)==null )
                        model.Insert();//自动判断是否存在
                    else
                        return;
                    Console.WriteLine("第 " + i.ToString() + "页，第 " + j.ToString() + " 条");
                }
            }
        }
        #endregion      
        
        #region 规则验证与预测
        /// <summary>
        /// 获取交叉验证的概率
        /// </summary>
        /// <param name="result">交叉验证中每条规则的结果</param>
        /// <returns>成功率</returns>
        public static double CrossValidate(bool[][] result)
        {            
            //对Result结果进行处理，得到交叉验证的概率
            int count = 0;
            for (int i = 0; i < result[0].Length; i++)
            {
                bool flag = false;
                for (int j = 0; j < result.GetLength(0); j++)
                {
                    if (!result[j][i]) flag = true;
                }
                if (!flag)
                    count++;
            }
           return ((double)count) / (double)result[0].Length;           
        }
        #endregion

        #region 保存方案数据和规则
        /// <summary>
        /// 保存方案和数据
        /// </summary>
        /// <param name="ruleList">规则列表</param>
        /// <param name="fileName">保存的文件名称</param>
        /// <param name="isSaveData">是否保存数据,false则只保存规则</param>
        public void SaveProjectData(RuleInfo[] ruleList,string fileName ,bool isSaveData = false )
        {
            SaveRules(ruleList, fileName);//先保存规则信息
            if (isSaveData)
                SaveData(ruleList, fileName); //保存数据
        }
        private static void SaveRules(RuleInfo[] ruleList, string fileName)
        {
            //保存规则
            if (File.Exists(fileName)) File.Delete(fileName);
            NewLife.Xml.XmlWriterX xml = new NewLife.Xml.XmlWriterX();
            using (XmlWriter writer = XmlWriter.Create(fileName))
            {
                xml.Writer = writer;
                xml.WriteObject(ruleList, typeof(RuleInfo[]), null);
            }
        }
        //保存方案数据
        private void SaveData(RuleInfo[] ruleList, string fileName)
        {
            List<int> RedBall = new List<int>(33);
            for (int i = 0; i <33 ; i++) RedBall.Add (i +1);
            int[][] Red = new Combination(RedBall.Count , 6).Rows.Select
                (n => Combination.Permute(n, RedBall ).ToArray()).ToArray();
            LotTickData[] res = Red.Select (n=>new LotTickData (n )).ToArray ();
            Dictionary<int, string> filterInfos = new Dictionary<int,string> ();
            LotTickData[] data = FilterByRules(res ,ruleList , out filterInfos);
            //方案保存不涉及最高优先级的杀号，因此可以直接进行过滤操作
            if (!File.Exists(fileName)) throw new Exception("文件不存在");
            NewLife.Serialization.BinaryWriterX binX = new NewLife.Serialization.BinaryWriterX();
            FileStream fs = new FileStream(fileName, FileMode.Create);
            binX.Writer = new BinaryWriter(fs); 
            binX.WriteObject (ruleList,typeof (LotTickData[]),null );
        }
        //读取方案数据
        private static LotTickData[] ReadData(string fileName)
        {
            NewLife.Serialization.BinaryReaderX reader = new NewLife.Serialization.BinaryReaderX();
            FileStream fs = new FileStream(fileName, FileMode.Open );
            reader.Reader = new BinaryReader(fs);
            return (LotTickData[])reader.ReadObject(typeof(LotTickData[]));
        }
        #endregion
    }
}