/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 7:59
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO ;

namespace LotteryTicket
{
	/// <summary>
	/// 处理测试数据
	/// </summary>
	public class TestData
	{
		public static double[][] ReadTestDataFromTxt()
		{
			int NumberCount = 7 ;//定义的原始数据个数
			string path = @"../../TestData/AllDataCalculateData.txt" ;
			StreamReader sr = new StreamReader(path );
            string line = null;
            double[][] testData = new double[NumberCount][] ;
            int count = 0 ;
            while ( (line = sr.ReadLine())!=null )
            {
            	if (line.StartsWith("#")||(line.Length <4))
                {
                    continue;
                }
            	if (line.StartsWith ("&"))
            	{
            		string[] tempStr = line.Trim ().Substring (1).Split (',') ;
            		System.Collections.Generic.List<double > tempList = 
            			new System.Collections.Generic.List<double> ();
            		for (int i = 0 ; i <tempStr.Length ; i ++)
            		{
            			tempList.Add (Double.Parse (tempStr [i ])) ;
            		}
            		testData [count ++] = tempList.ToArray () ;
            		continue ;
            	}
            }
            sr.Close () ;
            return testData ;
		}
	}
}
