/*
 * Created by SharpDevelop.
 * User: asxinyu
 * Date: 2011-8-31
 * Time: 19:39
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Threading ;

namespace ResouceCollector
{
	class Program
	{
		public static void Main(string[] args)
		{	
			VeryCdResouce.StartCollectResouceList() ;
//			for (int i = 0; i <20; i++)
//			{		
//				Thread.Sleep (1000) ;
//				Thread thread=new Thread(VeryCdResouce.StartCollectResouceDownLoadLink);
//				thread.Start();
//			}			
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
}