using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Data;

using NPOI.Util;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using NPOI.HSSF;
using System.Web;

namespace DotNet.Core.Commons
{
	/// <summary>
	/// 常见的数据转换类
	/// 2011.06.12  更新人民币大小写转换算法集中文简体繁体转换算法
	/// 2011.04.27  人民币大小写转换
	/// 2010.12.30  汉字拼音转换
	/// 2010.12.31  相关数据转换,导出Excel算法,2011.1.2 修改为泛型方法
	/// 2011.01.03  改用NPOI开源类库,加快读写速度和减少对Excel的依赖性单独将导出到Excel作为一个类,便于管理
	/// </summary>
	public static class Convertor
	{
		#region 路径转换（转换成绝对路径）
		/// <summary>
		/// 路径转换（转换成绝对路径）
		/// </summary>
		/// <param name="path"></param>
		/// <returns></returns>
		public static string WebPathTran(string path)
		{
			try
			{			
				return HttpContext.Current.Server.MapPath(path);
			}
			catch
			{
				return path;
			}
		}
		#endregion
		
		#region 汉字转换拼音算法 ConvertToSpell  public string ConvertToSpell(string Chstr)
		#region  定义拼音区编码数组 与 定义拼音数组
		private static int[] getValue = new int[]
		{
			-20319,-20317,-20304,-20295,-20292,-20283,-20265,-20257,-20242,-20230,-20051,-20036,
			-20032,-20026,-20002,-19990,-19986,-19982,-19976,-19805,-19784,-19775,-19774,-19763,
			-19756,-19751,-19746,-19741,-19739,-19728,-19725,-19715,-19540,-19531,-19525,-19515,
			-19500,-19484,-19479,-19467,-19289,-19288,-19281,-19275,-19270,-19263,-19261,-19249,
			-19243,-19242,-19238,-19235,-19227,-19224,-19218,-19212,-19038,-19023,-19018,-19006,
			-19003,-18996,-18977,-18961,-18952,-18783,-18774,-18773,-18763,-18756,-18741,-18735,
			-18731,-18722,-18710,-18697,-18696,-18526,-18518,-18501,-18490,-18478,-18463,-18448,
			-18447,-18446,-18239,-18237,-18231,-18220,-18211,-18201,-18184,-18183, -18181,-18012,
			-17997,-17988,-17970,-17964,-17961,-17950,-17947,-17931,-17928,-17922,-17759,-17752,
			-17733,-17730,-17721,-17703,-17701,-17697,-17692,-17683,-17676,-17496,-17487,-17482,
			-17468,-17454,-17433,-17427,-17417,-17202,-17185,-16983,-16970,-16942,-16915,-16733,
			-16708,-16706,-16689,-16664,-16657,-16647,-16474,-16470,-16465,-16459,-16452,-16448,
			-16433,-16429,-16427,-16423,-16419,-16412,-16407,-16403,-16401,-16393,-16220,-16216,
			-16212,-16205,-16202,-16187,-16180,-16171,-16169,-16158,-16155,-15959,-15958,-15944,
			-15933,-15920,-15915,-15903,-15889,-15878,-15707,-15701,-15681,-15667,-15661,-15659,
			-15652,-15640,-15631,-15625,-15454,-15448,-15436,-15435,-15419,-15416,-15408,-15394,
			-15385,-15377,-15375,-15369,-15363,-15362,-15183,-15180,-15165,-15158,-15153,-15150,
			-15149,-15144,-15143,-15141,-15140,-15139,-15128,-15121,-15119,-15117,-15110,-15109,
			-14941,-14937,-14933,-14930,-14929,-14928,-14926,-14922,-14921,-14914,-14908,-14902,
			-14894,-14889,-14882,-14873,-14871,-14857,-14678,-14674,-14670,-14668,-14663,-14654,
			-14645,-14630,-14594,-14429,-14407,-14399,-14384,-14379,-14368,-14355,-14353,-14345,
			-14170,-14159,-14151,-14149,-14145,-14140,-14137,-14135,-14125,-14123,-14122,-14112,
			-14109,-14099,-14097,-14094,-14092,-14090,-14087,-14083,-13917,-13914,-13910,-13907,
			-13906,-13905,-13896,-13894,-13878,-13870,-13859,-13847,-13831,-13658,-13611,-13601,
			-13406,-13404,-13400,-13398,-13395,-13391,-13387,-13383,-13367,-13359,-13356,-13343,
			-13340,-13329,-13326,-13318,-13147,-13138,-13120,-13107,-13096,-13095,-13091,-13076,
			-13068,-13063,-13060,-12888,-12875,-12871,-12860,-12858,-12852,-12849,-12838,-12831,
			-12829,-12812,-12802,-12607,-12597,-12594,-12585,-12556,-12359,-12346,-12320,-12300,
			-12120,-12099,-12089,-12074,-12067,-12058,-12039,-11867,-11861,-11847,-11831,-11798,
			-11781,-11604,-11589,-11536,-11358,-11340,-11339,-11324,-11303,-11097,-11077,-11067,
			-11055,-11052,-11045,-11041,-11038,-11024,-11020,-11019,-11018,-11014,-10838,-10832,
			-10815,-10800,-10790,-10780,-10764,-10587,-10544,-10533,-10519,-10331,-10329,-10328,
			-10322,-10315,-10309,-10307,-10296,-10281,-10274,-10270,-10262,-10260,-10256,-10254
		};
		//定义拼音数组
		private static string[] getName = new string[]
		{
			"A","Ai","An","Ang","Ao","Ba","Bai","Ban","Bang","Bao","Bei","Ben",
			"Beng","Bi","Bian","Biao","Bie","Bin","Bing","Bo","Bu","Ba","Cai","Can",
			"Cang","Cao","Ce","Ceng","Cha","Chai","Chan","Chang","Chao","Che","Chen","Cheng",
			"Chi","Chong","Chou","Chu","Chuai","Chuan","Chuang","Chui","Chun","Chuo","Ci","Cong",
			"Cou","Cu","Cuan","Cui","Cun","Cuo","Da","Dai","Dan","Dang","Dao","De",
			"Deng","Di","Dian","Diao","Die","Ding","Diu","Dong","Dou","Du","Duan","Dui",
			"Dun","Duo","E","En","Er","Fa","Fan","Fang","Fei","Fen","Feng","Fo",
			"Fou","Fu","Ga","Gai","Gan","Gang","Gao","Ge","Gei","Gen","Geng","Gong",
			"Gou","Gu","Gua","Guai","Guan","Guang","Gui","Gun","Guo","Ha","Hai","Han",
			"Hang","Hao","He","Hei","Hen","Heng","Hong","Hou","Hu","Hua","Huai","Huan",
			"Huang","Hui","Hun","Huo","Ji","Jia","Jian","Jiang","Jiao","Jie","Jin","Jing",
			"Jiong","Jiu","Ju","Juan","Jue","Jun","Ka","Kai","Kan","Kang","Kao","Ke",
			"Ken","Keng","Kong","Kou","Ku","Kua","Kuai","Kuan","Kuang","Kui","Kun","Kuo",
			"La","Lai","Lan","Lang","Lao","Le","Lei","Leng","Li","Lia","Lian","Liang",
			"Liao","Lie","Lin","Ling","Liu","Long","Lou","Lu","Lv","Luan","Lue","Lun",
			"Luo","Ma","Mai","Man","Mang","Mao","Me","Mei","Men","Meng","Mi","Mian",
			"Miao","Mie","Min","Ming","Miu","Mo","Mou","Mu","Na","Nai","Nan","Nang",
			"Nao","Ne","Nei","Nen","Neng","Ni","Nian","Niang","Niao","Nie","Nin","Ning",
			"Niu","Nong","Nu","Nv","Nuan","Nue","Nuo","O","Ou","Pa","Pai","Pan",
			"Pang","Pao","Pei","Pen","Peng","Pi","Pian","Piao","Pie","Pin","Ping","Po",
			"Pu","Qi","Qia","Qian","Qiang","Qiao","Qie","Qin","Qing","Qiong","Qiu","Qu",
			"Quan","Que","Qun","Ran","Rang","Rao","Re","Ren","Reng","Ri","Rong","Rou",
			"Ru","Ruan","Rui","Run","Ruo","Sa","Sai","San","Sang","Sao","Se","Sen",
			"Seng","Sha","Shai","Shan","Shang","Shao","She","Shen","Sheng","Shi","Shou","Shu",
			"Shua","Shuai","Shuan","Shuang","Shui","Shun","Shuo","Si","Song","Sou","Su","Suan",
			"Sui","Sun","Suo","Ta","Tai","Tan","Tang","Tao","Te","Teng","Ti","Tian",
			"Tiao","Tie","Ting","Tong","Tou","Tu","Tuan","Tui","Tun","Tuo","Wa","Wai",
			"Wan","Wang","Wei","Wen","Weng","Wo","Wu","Xi","Xia","Xian","Xiang","Xiao",
			"Xie","Xin","Xing","Xiong","Xiu","Xu","Xuan","Xue","Xun","Ya","Yan","Yang",
			"Yao","Ye","Yi","Yin","Ying","Yo","Yong","You","Yu","Yuan","Yue","Yun",
			"Za", "Zai","Zan","Zang","Zao","Ze","Zei","Zen","Zeng","Zha","Zhai","Zhan",
			"Zhang","Zhao","Zhe","Zhen","Zheng","Zhi","Zhong","Zhou","Zhu","Zhua","Zhuai","Zhuan",
			"Zhuang","Zhui","Zhun","Zhuo","Zi","Zong","Zou","Zu","Zuan","Zui","Zun","Zuo"
		};
		#endregion
		/// <summary>
		/// 汉字转换成全拼的拼音: C#通用类库--汉字转拼音:
		/// 1.0 http://www.cnblogs.com/feiyangqingyun/archive/2010/12/23/1914538.html  作者游龙
		/// 1.1 董斌辉 12.28 整理
		/// 建立一个convertCh方法用于将汉字转换成全拼的拼音，其中，参数代表汉字字符串，此方法的返回值是转换后的拼音字符串
		/// </summary>
		/// <param name="Chstr">汉字字符串</param>
		/// <returns>转换后的拼音字符串</returns>
		public static string ConvertCharactersToSpell(string strText)
		{
			Regex reg = new Regex("^[\u4e00-\u9fa5]$");//验证是否输入汉字
			byte[] arr = new byte[2];
			string pystr = "";
			int asc = 0, M1 = 0, M2 = 0;
			char[] mChar = strText.ToCharArray();//获取汉字对应的字符数组
			for (int j = 0; j < mChar.Length; j++)
			{
				//如果输入的是汉字
				if (reg.IsMatch(mChar[j].ToString()))
				{
					arr = System.Text.Encoding.Default.GetBytes(mChar[j].ToString());
					M1 = (short)(arr[0]);
					M2 = (short)(arr[1]);
					asc = M1 * 256 + M2 - 65536;
					if (asc > 0 && asc < 160)
					{
						pystr += mChar[j];
					}
					else
					{
						switch (asc)
						{
							case -9254:
								pystr += "Zhen"; break;
							case -8985:
								pystr += "Qian"; break;
							case -5463:
								pystr += "Jia"; break;
							case -8274:
								pystr += "Ge"; break;
							case -5448:
								pystr += "Ga"; break;
							case -5447:
								pystr += "La"; break;
							case -4649:
								pystr += "Chen"; break;
							case -5436:
								pystr += "Mao"; break;
							case -5213:
								pystr += "Mao"; break;
							case -3597:
								pystr += "Die"; break;
							case -5659:
								pystr += "Tian"; break;
							default:
								for (int i = (getValue.Length - 1); i >= 0; i--)
								{
									if (getValue[i] <= asc)//判断汉字的拼音区编码是否在指定范围内
									{
										pystr += getName[i];//如果不超出范围则获取对应的拼音
										break;
									}
								}
								break;
						}
					}
				}
				else//如果不是汉字
				{
					pystr += mChar[j].ToString();//如果不是汉字则返回
				}
			}
			return pystr;//返回获取到的汉字拼音
		}
		
		/// <summary>
		/// 转换字符串为拼音首字母
		/// </summary>
		/// <param name="strText">汉字字符串</param>
		/// <returns>拼音首字母</returns>
		public static string ConvertStringsToShortSpell(string strText)
		{
			int len = strText.Length;
			string myStr = "";
			for (int i = 0; i < len; i++)
			{
				myStr += GetSpell(strText.Substring(i, 1));
			}
			return myStr;
		}
		/// <summary>
		/// 获取指定汉字的首字母
		/// </summary>
		/// <param name="cnChar">汉字</param>
		/// <returns>首字母-拼音</returns>
		public static string GetSpell(string cnChar)
		{
			byte[] arrCN = Encoding.Default.GetBytes(cnChar);
			if (arrCN.Length > 1)
			{
				int area = (short)arrCN[0];
				int pos = (short)arrCN[1];
				int code = (area << 8) + pos;
				int[] areacode ={ 45217, 45253, 45761, 46318, 46826,47010, 47297, 47614, 48119, 48119,
					49062, 49324, 49896, 50371, 50614, 50622, 50906, 51387, 51446, 52218,52698, 52698,
					52698, 52980, 53689, 54481 };
				for (int i = 0; i < 26; i++)
				{
					int max = 55290;
					if (i != 25)
						max = areacode[i + 1];
					if (areacode[i] <= code && code < max)
					{
						return Encoding.Default.GetString(new byte[]{ (byte)(65 + i) });
					}
				}
				return "*";
			}
			else
				return cnChar;
		}

		#endregion
		
		#region 数据导出到Excel: bool ConvertDataToExcel()
		// 将数据集转换到Excel： ConvertDataTableToExcel   ConvertDataGridViewToExcel
		// 目前支持的数据类型有:DataTable,二维数组,二维交错数组,DataGridView,ArrayList
		// 2010.01.03 采用NPOI类库，改善操作速度,便于扩展

		/// <summary>
		/// 将数据集导出到Excel文件
		/// </summary>
		/// <param name="data">一维数组</param>
		/// <param name="xlsSaveFileName">Excel文件名称</param>
		/// <param name="sheetName">工作簿名称</param>
		/// <returns>是否转换成功</returns>
		public static bool ConvertToExcel<T>(T[] data,string xlsSaveFileName,string sheetName)
		{
			FileStream fs = new FileStream (xlsSaveFileName, FileMode.Create ) ;
			try
			{
				HSSFWorkbook newBook = new HSSFWorkbook () ;
				
				HSSFSheet    newSheet =(HSSFSheet ) newBook.CreateSheet (sheetName ) ;//新建工作簿
				HSSFRow      newRow = (HSSFRow )newSheet.CreateRow(0) ;//创建行
				for (int i = 0 ; i <data.Length ; i ++ )
				{
					newSheet.GetRow (0).CreateCell (i ).SetCellValue (Convert.ToDouble (data [i ].ToString ())) ;//写入数据
				}
				newBook .Write (fs ) ;
				return true ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到Excel失败："+err.Message ) ;
			}
			finally
			{
				fs.Close () ;
			}
		}
		
		/// <summary>
		/// 将数据集导出到Excel文件
		/// </summary>
		/// <param name="data">二维数组</param>
		/// <param name="xlsSaveFileName">Excel文件名称</param>
		/// <param name="sheetName">工作簿名称</param>
		/// <returns>是否转换成功</returns>
		public static bool ConvertToExcel<T>(T[,]  data,string xlsSaveFileName,string sheetName)
		{
			FileStream fs = new FileStream (xlsSaveFileName, FileMode.Create ) ;
			try
			{
				HSSFWorkbook newBook = new HSSFWorkbook () ;
				HSSFSheet    newSheet =(HSSFSheet ) newBook.CreateSheet (sheetName ) ;//新建工作簿
				for (int i = 0 ; i <data.GetLength (0) ; i ++ )
				{
					HSSFRow  newRow = (HSSFRow )newSheet.CreateRow(i ) ;//创建行
					for (int j = 0 ; j <data.GetLength (1) ; j ++ )
					{
						newSheet.GetRow (i ).CreateCell (j ).SetCellValue (Convert.ToDouble (data [i,j ].ToString ())) ;//写入数据
					}
				}
				newBook .Write (fs ) ;
				return true ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到Excel失败："+err.Message ) ;
			}
			finally
			{
				fs.Close () ;
			}
		}
		
		/// <summary>
		/// 		/// <summary>
		/// 将数据集导出到Excel文件
		/// </summary>
		/// <param name="data">交错数组</param>
		/// <param name="xlsSaveFileName">Excel文件名称</param>
		/// <param name="sheetName">工作簿名称</param>
		/// <returns>是否转换成功</returns>
		/// </summary>
		public static bool ConvertToExcel<T>(T[][] data,string xlsSaveFileName,string sheetName)
		{
			FileStream fs = new FileStream (xlsSaveFileName, FileMode.Create ) ;
			try
			{
				HSSFWorkbook newBook = new HSSFWorkbook () ;
				HSSFSheet    newSheet =(HSSFSheet ) newBook.CreateSheet (sheetName ) ;//新建工作簿
				for (int i = 0 ; i <data.GetLength (0) ; i ++ )
				{
					HSSFRow  newRow = (HSSFRow )newSheet.CreateRow(i ) ;//创建行
					for (int j = 0 ; j <data[i ].Length ; j ++ )
					{
						newSheet.GetRow (i ).CreateCell (j ).SetCellValue (Convert.ToDouble (data [i][j ].ToString ())) ;//写入数据
					}
				}
				newBook .Write (fs ) ;
				return true ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到Excel失败："+err.Message ) ;
			}
			finally
			{
				fs.Close () ;
			}
		}
		
		/// <summary>
		/// 将数据集导出到Excel文件
		/// </summary>
		/// <param name="dt">DataTable对象</param>
		/// <param name="xlsSaveFileName">Excel文件名称</param>
		/// <param name="sheetName">工作簿名称</param>
		/// <returns>是否转换成功</returns>
		public static bool ConvertToExcel(System.Data.DataTable dt, string xlsSaveFileName,string sheetName)
		{
			FileStream fs = new FileStream (xlsSaveFileName, FileMode.Create ) ;
			try
			{
				HSSFWorkbook newBook = new HSSFWorkbook () ;
				HSSFSheet    newSheet =(HSSFSheet ) newBook.CreateSheet (sheetName ) ;//新建工作簿
				for (int i = 0 ; i <dt.Rows.Count  ; i ++ )
				{
					HSSFRow  newRow = (HSSFRow )newSheet.CreateRow(i ) ;//创建行
					for (int j = 0 ; j <dt.Columns.Count ; j ++ )
					{
						newSheet.GetRow (i ).CreateCell (j ).SetCellValue (dt.Rows [i ][j].ToString ()) ;//写入数据
					}
				}
				newBook .Write (fs ) ;
				return true ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到Excel失败："+err.Message ) ;
			}
			finally
			{
				fs.Close () ;
			}
		}
		
		/// <summary>
		/// 将数据集导出到Excel文件
		/// </summary>
		/// <param name="dt">DataGridView对象</param>
		/// <param name="xlsSaveFileName">Excel文件名称</param>
		/// <param name="sheetName">工作簿名称</param>
		/// <returns>是否转换成功</returns>
		public static bool ConvertToExcel(System.Windows.Forms.DataGridView dgv, string xlsSaveFileName,string sheetName)
		{
			return ConvertToExcel((System.Data.DataTable )dgv.DataSource  ,xlsSaveFileName,sheetName )  ;
		}
		#endregion
		
		#region 数据导出到DataTable中 DataTable ConvertToDataTable
		/// <summary>
		/// 将数据导出到DataTable中
		/// </summary>
		/// <param name="data">二维数组数据</param>
		/// <param name="columnsName">列名</param>
		/// <returns>DataTable对象</returns>
		public static System.Data.DataTable ConvertToDataTable<T>(T[,] data , string[] columnsName)
		{
			System.Data.DataTable dt = new System.Data.DataTable () ;
			if (data.GetLength (1)>columnsName.Length )
			{
				throw new Exception ("列名长度不足");
			}
			try
			{
				//先添加列名
				for (int i = 0 ; i <data.GetLength (1) ; i ++)
				{
					DataColumn dc = new DataColumn (columnsName [i ],typeof (System.String ) ) ;
					dt.Columns.Add (dc ) ;
				}
				//添加数据
				for (int i = 0 ;i <data.GetLength (0) ;i ++ )
				{
					DataRow dr = dt.Rows.Add () ;
					for (int j =0 ; j <data.GetLength (1); j ++)
					{
						dr [j ] = data[i,j ].ToString () ;
					}
					dt.Rows.Add (dr ) ;
				}
				return dt ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到DataTable失败："+err.Message ) ;
			}
		}
		
		/// <summary>
		/// 将数据导出到DataTable中
		/// </summary>
		/// <param name="data">二维数组数据</param>
		/// <returns>DataTable对象</returns>
		public static System.Data.DataTable ConvertToDataTable<T>(T[,] data )
		{
			System.Data.DataTable dt = new System.Data.DataTable () ;
			try
			{
				//先添加列名
				for (int i = 0 ; i <data.GetLength (1) ; i ++)
				{
					DataColumn dc = new DataColumn() ;
					dt.Columns.Add (dc ) ;
				}
				//添加数据
				for (int i = 0 ;i <data.GetLength (0) ;i ++ )
				{
					DataRow dr = dt.Rows.Add () ;
					for (int j =0 ; j <data.GetLength (1); j ++)
					{
						dr [j ] = data[i,j ].ToString () ;
					}
					dt.Rows.Add (dr ) ;
				}
				return dt ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到DataTable失败："+err.Message ) ;
			}
		}
		/// <summary>
		/// 将数据导出到DataTable中
		/// </summary>
		/// <param name="data">交错数组数据</param>
		/// <param name="columnsName">列名</param>
		/// <returns>DataTable对象</returns>
		public static System.Data.DataTable ConvertToDataTable<T>(T[][] data , string[] columnsName)
		{
			System.Data.DataTable dt = new System.Data.DataTable () ;
			if (data[0].Length >columnsName.Length )
			{
				throw new Exception ("列名长度不足");
			}
			try
			{
				//先添加列名
				for (int i = 0 ; i <data[0].Length  ; i ++)
				{
					DataColumn dc = new DataColumn (columnsName [i ],typeof (System.String ) ) ;
					dt.Columns.Add (dc ) ;
				}
				//添加数据
				for (int i = 0 ;i <data.GetLength (0) ;i ++ )
				{
					DataRow dr = dt.NewRow();
					for (int j =0 ; j <data[i].Length ; j ++)
					{
						dr [j ] = data[i][j ].ToString () ;
					}
					dt.Rows.Add (dr ) ;
				}
				return dt ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到DataTable失败："+err.Message ) ;
			}
		}
		
		/// <summary>
		/// 将数据导出到DataTable中
		/// </summary>
		/// <param name="data">交错数组数据</param>
		/// <returns>DataTable对象</returns>
		public static System.Data.DataTable ConvertToDataTable<T>(T[][] data)
		{
			System.Data.DataTable dt = new System.Data.DataTable () ;
			try
			{
				//先添加列名
				for (int i = 0 ; i <data[0].Length  ; i ++)
				{
					DataColumn dc = new DataColumn ( ) ;
					dt.Columns.Add (dc ) ;
				}
				//添加数据
				for (int i = 0 ;i <data.GetLength (0) ;i ++ )
				{
					DataRow dr = dt.NewRow();
					for (int j =0 ; j <data[i].Length ; j ++)
					{
						dr [j ] = data[i][j ].ToString () ;
					}
					dt.Rows.Add (dr ) ;
				}
				return dt ;
			}
			catch (Exception err)
			{
				throw new Exception ("转换数据到DataTable失败："+err.Message ) ;
			}
		}
		
		#endregion

		#region 人民币小写转换为大写
		/// <summary>
		/// 人民币大小写转换。
		/// </summary>
		/// <param name="r">货币金额</param>
		/// <returns>人民币大写字符串</returns>
		/// <remarks>
		/// 超过两位的小数会自动进行四舍五入。
		/// </remarks>
		public static string RMBDecimalToChinese(decimal value)
		{
			try
			{
				if (value == 0) return "零元";

				string[] cnShuzi = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖" };
				string[] cnDanwei = {  "分", "角", "元", "拾", "佰", "仟", "万", "拾万", "佰万", "仟万",
					"亿", "拾亿", "佰亿", "仟亿", "万亿", "拾万亿", "佰万亿", "仟万亿", "万万亿" };

				char[] arr = decimal.ToInt64(decimal.Round(value, 2) * 100).ToString().ToCharArray();
				Array.Reverse(arr);

				StringBuilder rmb = new StringBuilder();

				for (int i = 0; i < arr.Length; i++)
				{
					int num = int.Parse(arr[i].ToString());

					if (num != 0)
					{
						if (i > 6 && i < 10 && rmb.ToString().IndexOf("万") >= 0)
							rmb.Insert(0, cnShuzi[num] + cnDanwei[i][0]);
						else if (i > 10 && i < 14 && rmb.ToString().IndexOf("亿") >= 0)
							rmb.Insert(0, cnShuzi[num] + cnDanwei[i][0]);
						else if (i > 14 && rmb.ToString().IndexOf("万亿") >= 0)
							rmb.Insert(0, cnShuzi[num] + cnDanwei[i].Substring(0, 2));
						else
							rmb.Insert(0, cnShuzi[num] + cnDanwei[i]);
					}
					else
					{
						if (i == 2)
						{
							if (arr[1] == '0')
								rmb.Insert(0, "元");
							else
								rmb.Insert(0, "元零");
						}

						if (rmb.Length > 0)
						{
							if (rmb[0] != '零' && rmb[0] != '元')
								rmb.Insert(0, "零");
						}
					}
				}

				return rmb[rmb.Length - 1] == '元' ? rmb.ToString() + "整" : rmb.ToString();
			}
			catch
			{
				return "数值过大，无法转换！";
			}
		}
		
		/// <summary>
		/// 人民币大小写转换。
		/// </summary>
		public static string RmbToChinese(decimal rmbDouble)
		{
			string s = rmbDouble.ToString("#L#E#D#C#K#E#D#C#J#E#D#C#I#E#D#C#H#E#D#C#G#E#D#C#F#E#D#C#.0B0A");
			string d = Regex.Replace(s, @"((?<=-|^)[^1-9]*)|((?'z'0)[0A-E]*((?=[1-9])|(?'-z'(?=[F-L\.]|$))))|((?'b'[F-L])(?'z'0)[0A-L]*((?=[1-9])|(?'-z'(?=[\.]|$))))", "${b}${z}");
			string value = Regex.Replace(d, ".", delegate(Match m)
			                             { return "负元空零壹贰叁肆伍陆柒捌玖空空空空空空空分角拾佰仟万亿兆京垓秭穰"[m.Value[0] - '-'].ToString(); });
			return value;
		}
		#endregion

		#region  将全角数字转换为数字
		/// <summary>
		/// 将全角数字转换为数字
		/// </summary>
		/// <param name="SBCCase"></param>
		/// <returns></returns>
		public static string SBCCaseToNumberic(string SBCCase)
		{
			char[] c = SBCCase.ToCharArray();
			for (int i = 0; i < c.Length; i++)
			{
				byte[] b = System.Text.Encoding.Unicode.GetBytes(c, i, 1);
				if (b.Length == 2)
				{
					if (b[1] == 255)
					{
						b[0] = (byte)(b[0] + 32);
						b[1] = 0;
						c[i] = System.Text.Encoding.Unicode.GetChars(b)[0];
					}
				}
			}
			return new string(c);
		}

		#endregion
		
		#region 简体中文与繁体中文转换
		/// <summary>
		/// 转换为简体中文
		/// </summary>
		public static string ToSChinese(string str)
		{
			return Strings.StrConv(str, VbStrConv.SimplifiedChinese, 0);
		}

		/// <summary>
		/// 转换为繁体中文
		/// </summary>
		public static string ToTChinese(string str)
		{
			return Strings.StrConv(str, VbStrConv.TraditionalChinese, 0);
		}
		#endregion 
		
		#region 日期时间的相关转换
		#region 忽略转换为decimal时的错误
		/// <summary>
		/// 忽略转换为decimal时的错误
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static decimal InDecimal(object obj)
		{
			try
			{
				return Convert.ToDecimal(obj);
			}
			catch (Exception)
			{
				return 0;
			}
		}
		#endregion
		
		#region 转为double, 0时返回 "" (返回string类型的)
		/// <summary>
		/// 转为double, 0时返回 "" (返回string类型的)
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDoubleInStrNo0(object obj)
		{
			double tmp = ToDoubleIgnErr(obj);
			if (tmp == 0)
				return "";
			else
				return tmp.ToString();
		}
		#endregion
		
		#region 2位小数double(返回string类型的)
		/// <summary>
		/// 2位小数double(返回string类型的)
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDoubleDigit2Str(object obj)
		{
			if (obj == null)
			{
				return "";
			}
			double tmp = Convert.ToDouble(obj);
			return tmp.ToString("f2");
		}
		#endregion
		
		#region 2位小数的double
		/// <summary>
		/// 2位小数的double
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static double ToDoubleDigit2(object obj)
		{
			if (obj == null)
			{
				return 0;
			}
			double tmp = Convert.ToDouble(obj);
			return Convert.ToDouble(tmp.ToString("f2"));
		}
		#endregion
		
		#region 格式化double为指定位数的double
		/// <summary>
		/// 格式化double为指定位数的double
		/// </summary>
		/// <param name="number"></param>
		/// <param name="digit"></param>
		public static void ToDoubleDigit(ref double number, int digit)
		{
			number = ToDoubleDigit(number, digit);
		}
		#endregion
		
		#region 格式化double为2位数的double
		/// <summary>
		/// 格式化double为2位数的double
		/// </summary>
		/// <param name="number"></param>
		public static void ToDoubleDigit(ref double number)
		{
			ToDoubleDigit(ref number, 2);
		}
		#endregion
		
		#region 格式化为指定位数的double
		/// <summary>
		/// 格式化为指定位数的double
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="digit"></param>
		/// <returns></returns>
		public static double ToDoubleDigit(object obj, int digit)
		{
			if (obj == null)
			{
				return 0;
			}
			double tmp = Convert.ToDouble(obj);
			return Convert.ToDouble(tmp.ToString("f" + digit.ToString()));
		}
		#endregion
		
		#region 格式化为2位数的double
		/// <summary>
		/// 格式化为2位数的double
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static double ToDoubleDigit(object obj)
		{
			return ToDoubleDigit(obj, 2);
		}
		#endregion
		
		#region 转化为double,忽略错误
		/// <summary>
		/// 转化为double,忽略错误
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static double ToDoubleIgnErr(string str)
		{
			if (string.IsNullOrEmpty(str))
				return 0;

			double t = 0;
			if (double.TryParse(str, out t))
				return t;
			else
				return 0;
		}

		/// <summary>
		/// 转化为int,忽略错误
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static int ToInt32IgnErr(string str)
		{
			if (string.IsNullOrEmpty(str))
				return 0;

			int rtnValue = 0;
			return int.TryParse(str, out rtnValue) ? rtnValue : 0;
		}

		/// <summary>
		/// 转化为double,忽略错误
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static double ToDoubleIgnErr(object obj)
		{
			return obj == null ? 0 : ToDoubleIgnErr(obj.ToString());
		}

		#endregion
		
		#region 转化为金额数据
		/// <summary>
		/// 转化为金额数据
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToMoneyCHN(object obj)
		{
			return ToMoneyCHN(ToDoubleIgnErr(obj));
		}

		/// <summary>
		/// 转化为金额数据
		/// </summary>
		/// <param name="money"></param>
		/// <returns></returns>
		public static string ToMoneyCHN(double money)
		{
			return money.ToString("c");
		}
		#endregion
		
		#region yy-MM-dd HH:mm 格式
		/// <summary>
		/// yy-MM-dd HH:mm 格式
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDateTimeMinuteShort(object obj)
		{
			try
			{
				DateTime dtime = Convert.ToDateTime(obj);
				return dtime.ToString("yy-MM-dd HH:mm");
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// yy-MM-dd
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDateTimeDayShort(object obj)
		{
			try
			{
				DateTime dtime = Convert.ToDateTime(obj);
				return dtime.ToString("yy-MM-dd");
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// yyyy-MM-dd HH:mm
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDateTimeMinute(object obj)
		{
			try
			{
				DateTime dtime = Convert.ToDateTime(obj);
				return dtime.ToString("yyyy-MM-dd HH:mm");
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// yyyy-MM-dd 或自定义格式 ; 转化错误时返回""
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDateTimeIgnErr(object obj)
		{
			return ToDateTimeIgnErr(obj, "yyyy-MM-dd");
		}

		/// <summary>
		/// yyyy-MM-dd 或自定义格式 ; 转化错误时返回""
		/// </summary>
		/// <param name="obj"></param>
		/// <param name="format">格式</param>
		/// <returns></returns>
		public static string ToDateTimeIgnErr(object obj, string format)
		{
			try
			{
				DateTime dtime = Convert.ToDateTime(obj);
				return dtime.ToString(format);
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// yyyy-MM-dd
		/// </summary>
		/// <param name="obj"></param>
		/// <returns></returns>
		public static string ToDateTimeDay(object obj)
		{
			try
			{
				DateTime dtime = Convert.ToDateTime(obj);
				return dtime.ToString("yyyy-MM-dd");
			}
			catch (Exception)
			{
				return "";
			}
		}

		/// <summary>
		/// yyyy-MM-dd
		/// </summary>
		/// <param name="str"></param>
		/// <returns></returns>
		public static string ToDateTimeDay(string str)
		{
			try
			{
				DateTime dtime = Convert.ToDateTime(str);
				return dtime.ToString("yyyy-MM-dd");
			}
			catch (Exception)
			{
				return "";
			}
		}

		#endregion
		
		#endregion
	}
}