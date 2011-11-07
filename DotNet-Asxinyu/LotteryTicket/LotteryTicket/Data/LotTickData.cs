/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-4-26
 * Time: 8:04
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using LotTickEntity.Entities ;
using System.Text;
using System.IO;
using System.Net;
using XCode;
using NewLife.Reflection;
using XCode.DataAccessLayer;
using DotNet.Tools.Web;
using HtmlAgilityPack;
using DotNet.Tools;

namespace LotteryTicket.Data
{	
		/// <summary>
		/// 从网页获取双色球数据，并添加到数据库中
		/// </summary>
    public class GetSSQDataFromWeb : IGetWebLotTickData
		{
			//七乐彩数据：http://kaijiang.zhcw.com/zhcw/html/qlc/list_1.html
			//双色球数据：http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html
			//福彩3D数据：http://kaijiang.zhcw.com/zhcw/html/3d/list_2.html	
			
			/// <summary>
            /// 获取所有历史数据：网址:http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html
			/// </summary>
			/// <param name="pages">需要获取的页数</param>
			public void GetAllHistoryData(int pages)
			{
				string website ;//动态获取的网址				
                ssq model = new ssq();				
				for (int i =1 ; i <= pages ; i ++)
				{
                    //福彩 /html[1]/body[1]/table[1]/tr[7]
					website = @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_"+i.ToString ()+".html" ;
                    HtmlWeb web = new HtmlWeb();
                    HtmlDocument doc = web.Load(website);
                    HtmlNodeCollection hc = doc.DocumentNode.SelectNodes(@"/html[1]/body[1]/table[1]")[0].SelectNodes(@"tr");
                    for (int j  = 2; j <hc.Count -1; j ++)
                    {
                        HtmlNodeCollection hc1 = hc[j ].SelectNodes(@"td");
                        model.开奖日期 = Convert.ToDateTime(hc1[0].InnerText.Trim ());
                        model.期号 = Convert.ToInt32(hc1[1].InnerText.Trim());
                        double[] tempNo = hc1[2].InnerText.Replace("\r\n", "").Trim().ConvertStrToDoubleList(' ');                     
                        model.号码1 = Convert.ToInt32(tempNo[0]);
                        model.号码2 = Convert.ToInt32(tempNo[1]);
                        model.号码3 = Convert.ToInt32(tempNo[2]);
                        model.号码4 = Convert.ToInt32(tempNo[3]);
                        model.号码5 = Convert.ToInt32(tempNo[4]);
                        model.号码6 = Convert.ToInt32(tempNo[5]);
                        model.红球  = Convert.ToInt32(tempNo[6]);
                        model.Save();//自动判断是否存在         
                        Console.WriteLine("第 " + i.ToString() + "页，第 " + j.ToString() + " 条");
                    }                 
				}
			}
        /// <summary>
        /// 获取最新的数据
        /// </summary>
        /// <param name="pages">需要更新的页数</param>
            public void UpdateRecentData(int pages)
			{
				GetAllHistoryData(pages) ;
			}
		}

    /// <summary>
    /// 获取3D数据,并更新好数据库
    /// </summary>
    public class GetThreeDataFromWeb : IGetWebLotTickData
    {


        public void GetAllHistoryData(int pages)
        {
        }
        public void UpdateRecentData(int pages)
        {
            GetAllHistoryData(pages);
        }
    }
}