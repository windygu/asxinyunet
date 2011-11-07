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
using LotteryTicket.Entities;

namespace LotteryTicket
{
	/// <summary>
	/// 双色球彩票类型
	/// </summary>
	public class TwoColorBall :BaseLotTickClass
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
		public static double[][] GetRedBallData(int  selectLength = -1)
		{
			//获取数据 order by  desc 降序排列, asc 升序		
			ssq model = new ssq () ;//("select * from tb_ssq order by 期号 asc").Tables [0] ;
		    EntityList<ssq> list = ssq.FindAll("select * from tb_ssq order by 期号 asc");
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
            ssq model = new ssq();//("select * from tb_ssq order by 期号 asc").Tables [0] ;
            EntityList<ssq> list = ssq.FindAll("select * from tb_ssq order by 期号 asc");
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
            ssq model = new ssq();//("select * from tb_ssq order by 期号 asc").Tables [0] ;
            EntityList<ssq> list = ssq.FindAll("select * from tb_ssq order by 期号 asc");
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
		
		#region 奖项对比
		/// <summary>
		/// 对比单期号码与中奖号码,确定中奖等级
		/// </summary>
		/// <param name="prizeNo">中奖号码</param>
		/// <param name="testNo">需要测试对比的号码</param>
		/// <returns>中奖等级</returns>
		public static int GetPrizeGrade(double[] prizeNo,double[] testNo)
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
				grades [i ] = GetPrizeGrade (prizeNo,testNoes[i ]) ;
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
	}
}