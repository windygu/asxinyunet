#region
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using Microsoft.VisualBasic;
using System.Data;
using System.Windows.Forms;
using NPOI.Util;
using NPOI.HSSF.Model;
using NPOI.HSSF.UserModel;
using NPOI.HSSF;
using System.Web;
using System.Xml;
#endregion

/*更新历史：
 * 
 * 2011-04-27  增加人民币小写转换为大写
 * 2011-04-05  增加扩展方法ExtendProperty.cs
 * 2011-04-02  图形控件（永润石化灌区显示控件）
 * 2011-01-03  改用NPOI开源类库,加快读写速度和减少对Excel的依赖性，
 * 2010-12-31  相关数据转换,导出Excel算法,2011.1.2 修改为泛型方法
 * 2010-12-30  汉字拼音转换
 * 
 */
using HtmlAgilityPack;
using System.Collections;
using System.Linq;

namespace DotNet.Tools
{
    /// <summary>
    /// 扩展方法测试
    /// </summary>
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> Test<T>(this IEnumerable<T> source) where T:IComparable 
        {
            return source.Last() - source.First();
        }
    }

	class Program
	{
		static void Main(string[] args)
		{
//			YoungRunHelper.StockStatistics (DateTime.Parse ("2011-10-10 8:00:00")) ;
								
			Console.Write("Press any key to continue . . . ");
			Console.ReadKey(true);
		}
	}
	
}