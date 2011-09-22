/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-4-6
 * Time: 14:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework ;

namespace DotNet.Tools.Test
{
	/// <summary>
	/// 类库单元测试类
	/// </summary>
	[TestFixture]
	public class LibTest
	{
		[Test]
		public void ExtendPropertyTest()
		{
			string str = "2.1,3.3,4.5,8.8,9.0" ;
			double[] res = new double[] {2.1,3.3,4.5,8.8,9.0 } ;
			double[] calValue = str.ConvertStrToDoubleList(',');
			Assert.AreEqual(res,calValue) ;
			string intStr = "1,2,3,4,5,6" ;
			int[] resInt = new int[] {1,2,3,4,5,6} ;			
			Assert.AreEqual (resInt ,intStr.ConvertStrToIntList(',')) ;
		}
	}
}