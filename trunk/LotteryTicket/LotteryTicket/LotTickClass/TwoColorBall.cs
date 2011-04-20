﻿/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-18
 * Time: 21:08
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Data ;
using Maticsoft.DBUtility;

namespace LotteryTicket
{
	/// <summary>
	/// 双色球彩票类型
	/// </summary>
	public class TwoColorBall :BaseLotTickClass,IRedLotTick
	{
		public TwoColorBall () //double[][] Data
		{
			this.lotTickType = LotTickType.Range ;
			this.lotTickName = "彩票名称" ;
			this.lotTickRemark = "红球32选7,蓝球16选1" ;
			this.allBallNumber = 8 ;
			this.RedBallNumber = 7 ;
			this.BlueBallNumber = 1 ;
			this.RedNumRangeLimite = 32 ;
			this.BlueNumRangeLimite = 12 ;			
//			this.LotTickDatas = Data ;
			//this.CurrentDataNumbers = Data.Length ;//默认计算期数
			//过滤到期号及日期，得到处理前的数据
//			int length = Data[0].Length -2-BlueBallNumber ;//红球号码个数
//			this.redlotTickNoAfterFilt = new int[Data.Length ][] ;
//			for (int i = 0 ; i <Data.Length ;i ++ )
//			{
//				redlotTickNoAfterFilt [i ] = new int[length ] ;
//				for (int j = 2 ; j<length +2 ;j ++)
//				{
//					redlotTickNoAfterFilt [i][j-2 ] = Data [i][j ] ;
//				}
//			}
		}
		
		/// <summary>
		/// 将当前模式设置为计算指定期数据
		/// </summary>
		public void SetCurrentDataModel(int setLength)
		{
			IsAllDataUsed = false ;
			this.CurrentDataNumbers = setLength ;
		}
		
		public object Calculate(CalculateHandler calc )
		{
			//根据红球个数，args应该在传入前过滤掉期号及日期数据,只剩下号码
			//动态获取当前需要计算的数据,可在外部程序中调整期数
			return calc(this.CurrentData ) ;
		}
		
		#region 获取双色球计算数据		
		/// <summary>
		/// 从数据库获取指定期数红球数据
		/// </summary>
		/// <param name="length">最近的期数</param>
		/// <returns>交错数组数据</returns>
		public static double[][] GetRedBallData()
		{
			//获取数据 order by  desc 降序排列, asc 升序
			string con =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LotteryTicket.mdb;"+
				"Persist Security Info=False" ;
			DbHelperOleDb.connectionString = con ;
			DataTable dt = DbHelperOleDb.Query ("select * from tb_ssq order by 期号 asc").Tables [0] ;
			double[][] res = new double[dt.Rows.Count ][] ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = new double[6 ] ;
				for (int j = 0 ; j <res [i ].Length ; j ++)
				{
					res [i ][j ] =Convert.ToDouble(dt.Rows [i ][2+j ].ToString ()) ; ;
				}
			}
			return res ;
		}		
		
		public static double[][] GetRedBallData(int length)
		{
			//获取数据
			string con =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LotteryTicket.mdb;"+
				"Persist Security Info=False" ;
			DbHelperOleDb.connectionString = con ;
			DataTable dt = DbHelperOleDb.Query ("select * from tb_ssq order by 期号 asc").Tables [0] ;
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
		
		public static double[] GetBlueBallData()
		{
			string con =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LotteryTicket.mdb;"+
				"Persist Security Info=False" ;
			DbHelperOleDb.connectionString = con ;
			DataTable dt = DbHelperOleDb.Query ("select * from tb_ssq order by 期号 asc").Tables [0] ;
			double[] res = new double[dt.Rows.Count ] ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = Convert.ToDouble(dt.Rows [i ][8].ToString ()) ;
			}
			return res ;
		}
		
		public static double[] GetBlueBallData(int length)
		{
			string con =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LotteryTicket.mdb;"+
				"Persist Security Info=False" ;
			DbHelperOleDb.connectionString = con ;
			DataTable dt = DbHelperOleDb.Query ("select * from tb_ssq order by 期号 asc").Tables [0] ;
			double[] res = new double[length ] ;
			int k = dt.Rows.Count - length ;
			for (int i = 0 ; i <res.Length ; i ++)
			{
				res [i ] = Convert.ToDouble(dt.Rows [k + i][8].ToString ()) ;
			}
			return res ;
		}
		
		public static double[][] GetAllData()
		{
				//获取数据
			string con =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LotteryTicket.mdb;"+
				"Persist Security Info=False" ;
			DbHelperOleDb.connectionString = con ;
			DataTable dt = DbHelperOleDb.Query ("select * from tb_ssq order by 期号 asc").Tables [0] ;
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
		
		public static double[][] GetAllData(int length)
		{
			//获取数据
			string con =@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=LotteryTicket.mdb;"+
				"Persist Security Info=False" ;
			DbHelperOleDb.connectionString = con ;
			DataTable dt = DbHelperOleDb.Query ("select * from tb_ssq order by 期号 asc").Tables [0] ;
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
	}
}