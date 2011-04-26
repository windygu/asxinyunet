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
using Winista.Text.HtmlParser.Data;
using Winista.Text.HtmlParser.Filters;
using Winista.Text.HtmlParser.Lex;
using Winista.Text.HtmlParser.Nodes;
using Winista.Text.HtmlParser.Tags;
using Winista.Text.HtmlParser.Util;
using Winista.Text.HtmlParser;
using System.Text;
using System.IO;
using System.Net;
using XCode;
using DotNet.Tools.Web;
using NewLife;

namespace LotteryTicket.Data
{
	/// <summary>
	/// 获取数据类
	/// </summary>
	public class LotTickData
	{
		/// <summary>
		/// 从网页获取双色球数据，并添加到数据库中
		/// </summary>
		public class GetSSQDataFromWeb:BaseGetLotTicData ,IGetWebLotTickData
		{
			//七乐彩数据：http://kaijiang.zhcw.com/zhcw/html/qlc/list_1.html
			//双色球数据：http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html
			//福彩3D数据：http://kaijiang.zhcw.com/zhcw/html/3d/list_2.html	
			
			
			/// <summary>
			///网址:http://kaijiang.zhcw.com/zhcw/html/ssq/list_1.html
			/// </summary>
			/// <param name="connStr"></param>
			public void GetAllHistoryData(int pages)
			{
				string website ;//动态获取的网址
				string[] tempNo ;
                ssq model = new ssq();				
				for (int i =1 ; i <= pages ; i ++)
				{
					//福彩
					website = @"http://kaijiang.zhcw.com/zhcw/html/ssq/list_"+i.ToString ()+".html" ;
                    string txt = WebBasic.GetHtmlEx(website, Encoding.UTF8);
					Lexer lexer = new Lexer(txt );//获取源文件
					Parser parser = new Parser(lexer);
					//过滤
					TagNameFilter tab = new TagNameFilter ("TABLE");
					NodeList htmlNodes = parser.Parse(tab ) ;
					
					if (htmlNodes.Count > 0 )
					{
						TableTag tabTag = (TableTag )(htmlNodes [0] as TableTag ) ;
						for (int j = 2; j < tabTag.RowCount - 1 ; j ++)//前2行与后一行舍去
						{
//						Console.WriteLine ("当前状态：页面:"+i.ToString ()+"  ; 记录:"+j.ToString ()) ;
							//复制
							TableRow tb =tabTag.Rows [j ] ;
                            model.开奖日期 = Convert.ToDateTime(tb.Columns[0].ToPlainTextString().Trim());
                            model.期号 = Convert.ToInt32(tb.Columns[1].ToPlainTextString().Trim());
						
								tempNo = tb.Columns [2].ToPlainTextString ().Replace (" ","")
									.Trim ().Replace ("\r\n\r\n","|").Split('|') ;
                                model.号码1 = Convert.ToInt32(tempNo[0]);
                                model.号码2 = Convert.ToInt32(tempNo[1]);
                                model.号码3 = Convert.ToInt32(tempNo[2]);
                                model.号码4 = Convert.ToInt32(tempNo[3]);
                                model.号码5 = Convert.ToInt32(tempNo[4]);
                                model.号码6 = Convert.ToInt32(tempNo[5]);
                                model.红球 = Convert.ToInt32(tempNo[6]);
                                model.Save();//自动判断是否存在                                
							
						}
					}
				}
			}
			public void UpdateRecentData(int pages)
			{
				GetAllHistoryData(pages) ;
			}
		}
	}
}
