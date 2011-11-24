/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-18
 * Time: 21:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Net.Cache;
using System.Threading;
using XCode ;
using HtmlAgilityPack;
using DotNet.Tools;

namespace LotteryTicket
{
    //七乐彩数据：http://kaijiang.zhcw.com/zhcw/html/qlc/list_1.html
    //双色球数据：http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html
    //福彩3D数据：http://kaijiang.zhcw.com/zhcw/html/3d/list_2.html	
    
	/// <summary>
	/// 双色球彩票类型
	/// </summary>
    public class TwoColorBall : BaseLotTickClass, IGetWebLotTickData
    {
        #region 初始化
        //相应的奖金
		private static double[] prizeReward = new double[7] {0,5000000,200000,3000,200,10,5};
			
		public TwoColorBall () //double[][] Data
		{
			this.lotTickType = LotTickType.Range ;
			this.lotTickName = "彩票名称" ;
			this.lotTickRemark = "红球32选7,蓝球16选1" ;
			this.allBallNumber = 8 ;
			this.RedBallNumber = 7 ;
			this.BlueBallNumber = 1 ;
			this.RedNumRangeLimite = 33 ;
			this.BlueNumRangeLimite = 12 ;	        
		}
		
		/// <summary>
		/// 将当前模式设置为计算指定期数据
		/// </summary>
		public void SetCurrentDataModel(int setLength)
		{
			IsAllDataUsed = false ;
			this.CurrentDataNumbers = setLength ;
		}
		#endregion
		
		#region 获取双色球计算数据
		/// <summary>
		/// 从数据库获取指定期数红球数据
		/// </summary>
		/// <param name="length">最近的期数</param>
		public static double[][] GetRedBallData(int selectLength = -1)
		{
			//获取数据 order by  desc 降序排列, asc 升序		
            tb_Ssq model = new tb_Ssq();//("select * from tb_ssq order by 期号 asc").Tables [0] ;
            EntityList<tb_Ssq> list = tb_Ssq.FindAll("select * from tb_ssq order by 期号 asc");//升序
            DataTable dt = list.ToDataTable () ;
			int length = selectLength <=0? dt.Rows.Count : selectLength ;
			double[][] res = new double[length ][] ;
			int k = dt.Rows.Count - length ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = new double[6 ] ;
				for (int j = 0 ; j < res[i ].Length ; j ++)
				{
					res [i ][j ] =Convert.ToDouble(dt.Rows [k + i][2+j ].ToString ()) ; ;
				}
			}
			return res ;
		}
		
		/// <summary>
		/// 获取所有的蓝球数据,单独
		/// </summary>
		/// <param name="length">指定的期数据,最近期开始,默认为-1,代表期所有的数据</param>
		public static double[] GetBlueBallData(int selectLength = -1 )
		{
            tb_Ssq model = new tb_Ssq();//("select * from tb_ssq order by 期号 asc").Tables [0] ;
            EntityList<tb_Ssq> list = tb_Ssq.FindAll("select * from tb_ssq order by 期号 asc");
            DataTable dt = list.ToDataTable();
			int length = selectLength <=0? dt.Rows.Count : selectLength ;
			double[] res = new double[length ] ;
			int k = dt.Rows.Count - length ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = Convert.ToDouble(dt.Rows [k + i][8].ToString ()) ;
			}
			return res ;
		}
		
		/// <summary>
		/// 获取指定期的数据：所有历史数据，红号+蓝号
		/// </summary>
		/// <param name="length">指定的期数据,最近期开始,默认为-1,代表所有期的数据</param>
		public static double[][] GetAllData(int selectLength = -1 )
		{
			//获取数据
            tb_Ssq model = new tb_Ssq();//("select * from tb_ssq order by 期号 asc").Tables [0] ;
            EntityList<tb_Ssq> list = tb_Ssq.FindAll("select * from tb_ssq order by 期号 asc");
            DataTable dt = list.ToDataTable();
			int length = selectLength <=0? dt.Rows.Count : selectLength ;
			double[][] res = new double[length ][] ;
			int k = dt.Rows.Count - length ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = new double[7 ] ;
				for (int j = 0 ; j < res[i ].Length ; j ++)
				{
					res [i ][j ] =Convert.ToDouble(dt.Rows [k + i][2+j ].ToString ()) ; ;
				}
			}
			return res ;
		}
		#endregion

        #region 获取单个指标的数据
        #endregion

        #region 奖项对比
        /// <summary>
		/// 对比单期号码与中奖号码,确定中奖等级
		/// </summary>
		/// <param name="prizeNo">中奖号码</param>
		/// <param name="testNo">需要测试对比的号码</param>
		/// <returns>中奖等级</returns>
		public static int GetPrizeGradeForOne(double[] prizeNo,double[] testNo)
		{
			//循环的方式，蓝球分开，直接对比最后一位
			int countR = 0 ;
			for (int i = 0; i < testNo .Length -1 ; i++) {
				for (int j = 0; j < prizeNo.Length -1 ; j++) {
					if (testNo [i ]==prizeNo [j ]) {
						countR ++ ;
						break ;//跳出当前循环,进入下一次迭代对比
					}
				}
			}
			int countN = prizeNo [prizeNo.Length -1] == testNo [testNo.Length -1] ? 1:0 ;
			string str = countR.ToString ()+"-"+countN.ToString () ;//奖项特征
			if("0-0,1-0".Contains (str ))
			{
				return 0 ;
			}
			else if ("1-1,0-1,2-1".Contains (str )) {
				return 6 ;
			}
			else if ("3-1,4-0".Contains (str )) {
				return 5 ;
			}
			else if ("4-1,5-0".Contains (str )) {
				return 4 ;
			}
			else if ("5-1".Contains (str )) {
				return 3 ;
			}
			else if ("6-0".Contains (str )) {
				return 2 ;
			}
			else if ("6-1".Contains (str )) {
				return 1 ;
			}
			else 
				return 0 ;
		}
		
		/// <summary>
		/// 一次测试多个号码的等级，最终返回各个等级中奖号码的个数
		/// </summary>
		/// <param name="prizeNo">中奖号码</param>
		/// <param name="testNoes">需要测试对比的号码</param>
		/// <returns>中奖等级</returns>
		public static int[] GetPrizeGrade(double[] prizeNo,double[][] testNoes)
		{
			int[] grades = new int[testNoes.Length ] ;
			for (int i = 0; i < testNoes.Length ; i++) {
				grades [i ] = GetPrizeGradeForOne (prizeNo,testNoes[i ]) ;
			}
			//统计结果
			int[] res = new int[7] ;
			for (int i = 0; i < grades.Length ; i++) {
				res [grades[i ]] ++ ; //奖项大小的在对应位置加1
			}
			return res ;
		}
		//根据测试号码和中奖号码，统计总共的中奖金额
		public static double GetAllPrizeReward(double[] prizeNo,double[][] testNoes)
		{
			int[] gradeNum = GetPrizeGrade (prizeNo,testNoes ) ;
			double sum = 0 ;
			for (int i = 0; i < gradeNum.Length ; i++) {
				sum += gradeNum [i ]* prizeReward [i ] ;//次数*单次的金额,并累加
			}
			return sum ;
		}
		#endregion

        #region 开奖数据更新--接口实现
        /// <summary>
        /// 获取所有历史数据：网址:http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html
        /// </summary>
        /// <param name="pages">需要获取的页数</param>
        public void GetAllHistoryData(int pages = -1)
        {
            //TODO:自动获取总页数            
            string website;//动态获取的网址				
            tb_Ssq model = new tb_Ssq();
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
                    model.红球 = Convert.ToInt32(tempNo[6]);
                    if (!model.Exist(new string[] { tb_Ssq._.期号 }))
                    {
                        model.Insert();//自动判断是否存在         
                    }
                    Console.WriteLine("第 " + i.ToString() + "页，第 " + j.ToString() + " 条");
                }
            }
        }
        /// <summary>
        /// 获取最新的数据
        /// </summary>
        /// <param name="pages">需要更新的页数</param>
        public void UpdateRecentData(int pages = 1)
        {
            GetAllHistoryData(pages);
        }
        #endregion 
    }
}