/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-17
 * Time: 14:55
 * 
 * 单元测试程序
 */
using System;
using System.IO ;
using System.Collections ;
using NUnit.Framework ;
using LotteryTicket.Validate ;

namespace LotteryTicket.Test
{
	/// <summary>
	/// 主要的测试类：
	/// 分为数据属性计算测试;预测属性计算测试;单独计算测试;批量计算测试;数据比较测试;
	/// </summary>
	[TestFixture]
	public class LotteryTest
	{		
		
       #region  单期数据指标计算测试  A C 
		/// <summary>
		/// 单期数据指标计算测试:返回值都是object类型,需要手动进行转换
		/// </summary>
		[Test]
		public void PerIndexCalculateTestAB()
		{		
			string path = @"../../TestData/PerIndexCalculateDataAB.txt" ;//数据位置
			StreamReader sr = new StreamReader(path );
            string line = null;
            while ( (line = sr.ReadLine())!=null )
            {
            	if (line.StartsWith("#")||(line.Length <5))
                {
                    continue;
                }
                string[] str = line.Split(':');//第一次分割 
                IndexNameType typeName = (IndexNameType ) Enum.Parse(typeof(IndexNameType ), str [0].Trim (), false );
                char firType = str [0].Trim ()[0] ;//类型,用于确定预期值的数据类型
                
                string[] tdata = str[1].Split (',') ;//获取测试的计算数据
                System.Collections.Generic.List<double > listTestData = new System.Collections.Generic.List<double> ();
                for (int i = 0; i < tdata.Length; i++ )
                {
                	Console .WriteLine (tdata [i ]) ;
                    listTestData.Add(Double.Parse(tdata[i]));
                }
                double[] testData = listTestData.ToArray();//测试数据
                //获取预期数据
                if (firType =='A')
                {                
                	double expected = Double.Parse (str [2].Trim ()) ;
                	//测试
                	Assert.AreEqual (expected,IndexCalculate.CalculateIndex (testData ,typeName ));
                }
                else if (firType =='C')
                {
                	string[] expData = str[2].Split (',') ;//获取测试的计算数据
                	System.Collections.Generic.List<double > expectList = new System.Collections.Generic.List<double >();
                	for (int i = 0; i < expData.Length; i++ )
                	{
                		expectList.Add(Double.Parse(expData[i]));
                	}
                	double[] expected = expectList.ToArray();//测试数据
                	//测试
                	Assert.AreEqual (expected,IndexCalculate.CalculateIndex (testData ,typeName ));
                }             
                else
                {         	
                }
            }
            sr.Close();		
		}	
		#endregion
	
		#region 单期数据指标计算测试  B D 
		//[Test]
		public void PerIndexCalculateTestCD()
		{
			
		}
		#endregion
		
		#region 多期数据指标的计算测试  A
		[Test]
		public void AllDataCalculateTest()
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
                string[] str = line.Split(':');//第一次分割  
                IndexNameType typeName = (IndexNameType ) Enum.Parse(typeof(IndexNameType ), str [0].Trim (), false );
                char firType = str [0].Trim ()[0] ;//类型,用于确定预期值的数据类型                  
                System.Collections.Generic.List<double > listTestData =
                	new System.Collections.Generic.List<double> ();
                double[] testDataT ;
                if (str [1].Trim ()!="Null")
                {
                	string[] tdata = str[1].Split (',') ;//获取测试的计算数据
                	for (int i = 0; i < tdata.Length; i++ )
                	{
                		listTestData.Add(Double.Parse(tdata[i]));
                	}
                	testDataT = listTestData.ToArray();//测试数据
                }               
                //获取预期数据               
                string[] expData = str[2].Split (',') ;//获取测试的计算数据
                System.Collections.Generic.List<double > expectList = 
                	new System.Collections.Generic.List<double >();
                for (int i = 0; i < expData.Length; i++ )
                {
                	expectList.Add(Double.Parse(expData[i]));
                }
                double[] expected = expectList.ToArray();//测试数据
                //测试
                Assert.AreEqual (expected,IndexCalculate.CalculateAllData(testData ,typeName,0));                
            }
            sr.Close();		
		}
		#endregion
		
		#region 预测验证方法的计算测试 ABCD,整体数据集测试
		[Test]
		public void PredictValidateTest()
		{
			int NumberCount = 7 ;//定义的原始数据个数
			string path = @"../../TestData/PredictValidateData.txt" ;
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
                string[] str = line.Split(':');//第一次分割  
                IndexNameType typeName = (IndexNameType ) Enum.Parse(typeof (IndexNameType ), str [0].Trim (), false );
                IndexNameType compName = (IndexNameType ) Enum.Parse(typeof (IndexNameType ), str [1].Trim (), false ) ;
                FilterRuleType ruleType =( FilterRuleType)Enum.Parse(typeof (FilterRuleType), str [2].Trim (), false ) ;
                int needRow = Int32.Parse (str[3] ) ;                                
                //获取预期数据
                string[] expData = str[4].Split (',') ;
                System.Collections.Generic.List<bool > expectList = 
                	new System.Collections.Generic.List<bool >();
                for (int i = 0; i < expData.Length; i++ )
                {
                	expectList.Add(bool.Parse(expData[i]));
                }
                bool[] expected = expectList.ToArray();//测试数据
                //测试
                Assert.AreEqual (expected,PredictMethodsValidate.PredictValidate (testData ,typeName,compName,ruleType,needRow ));
            }
            sr.Close();		
		}
		#endregion
	}
}