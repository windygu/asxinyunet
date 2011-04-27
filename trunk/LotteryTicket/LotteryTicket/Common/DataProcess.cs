/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-19
 * Time: 17:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.IO ;

namespace LotteryTicket
{
	/// <summary>
	///数据的预处理
	/// </summary>
	public class DataProcess
	{
		//生成双色球全部数据,过滤掉3连号，均值小于12 和大于23的，跨度小于14的
		public static bool GetCombListToTxtFile(string folderName,int[] args,int fileLength)
		{	
			int curFileLength = 0  ;//当前文件的记录条数
			int fileCount = 1 ;//文件个数
			int allCount = 0 ;
			double sum = 0 ;
			StreamWriter sw = new StreamWriter (folderName+@"\1.txt");
			for (int i1 = 0 ; i1 <args.Length -5 ; i1 ++)
			{
				for (int i2 = i1 +1 ; i2 <args.Length -4 ; i2 ++)
				{
					for (int i3 = i2 +1 ; i3 <args.Length -3 ; i3 ++)
					{
						for (int i4 = i3 +1 ; i4<args.Length -2 ; i4 ++)
						{
							for (int i5 = i4 +1 ; i5 <args.Length -1 ; i5 ++ )
							{
								for (int i6 = i5 +1 ; i6 <args.Length  ; i6 ++)
								{
									//curArray =new int[]{args [i1],args [i2 ],args [i3 ],args [i4 ],args [i5 ],args [i6]} ;
									if(curFileLength > fileLength )
									{
										fileCount ++ ;
										sw.Close () ;
										sw = new StreamWriter (folderName+@"\"+fileCount .ToString ()+".txt");
										curFileLength = 0 ;										
									}	
									sum =((double )(args [i1]+args [i2 ]+args [i3 ]+args [i4 ]+args [i5 ]+args [i6]))/6 ;
									if ((sum >12)&&(sum <23)&&((args [i6]-args [i1])>14))
									{
										sw.WriteLine("{0},{1},{2},{3},{4},{5}",args [i1],args [i2 ],args [i3 ],args [i4 ],args [i5 ],args [i6]);
										curFileLength ++ ;
										allCount ++ ;
									}
								}
							}
						}
					}
				}
			}
			Console.WriteLine (allCount.ToString ());
			return true ;
		}
	}
}