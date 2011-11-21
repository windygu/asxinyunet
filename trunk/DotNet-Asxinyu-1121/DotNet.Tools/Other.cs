/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-19
 * 时间: 9:11
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
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

namespace DotNet.Tools
{
	/// <summary>
	/// Description of Other.
	/// </summary>
	public class Other
	{
		/// <summary>
		/// 将xml的客户名称转换为Excel格式
		/// </summary>
		public static void ConvertXmlToXls()
		{
			XmlDocument doc = new XmlDocument () ;
        	doc.Load ("User.xml") ;
        	XmlNodeList list = doc.GetElementsByTagName ("ITEM") ;        
        	FileStream fs = new FileStream ("z.xls", FileMode.Create ) ;        	
        	HSSFWorkbook newBook = new HSSFWorkbook () ;
        	HSSFSheet    newSheet =(HSSFSheet ) newBook.CreateSheet ("联系方式" ) ;//新建工作簿
        	int count = 0 ;
        	foreach(XmlNode node in list )
        	{
        		HSSFRow  newRow = (HSSFRow )newSheet.CreateRow(count  ) ;//创建行
        		newSheet.GetRow (count ).CreateCell (0 ).SetCellValue (node.Attributes ["UIN"].InnerText) ;
        		string[] names = node.Attributes ["NAME"].InnerText.Split ('『') ;
        		newSheet.GetRow (count ).CreateCell (1 ).SetCellValue (names [0].Trim ()) ;
        		newSheet.GetRow (count ).CreateCell (2 ).SetCellValue (names [1].Replace("』","")) ;
        		newSheet.GetRow (count ).CreateCell (3 ).SetCellValue (node.Attributes ["NICK"].InnerText) ;
        		newSheet.GetRow (count ).CreateCell (4 ).SetCellValue (node.Attributes ["MOBILE"].InnerText) ;
        		newSheet.GetRow (count ).CreateCell (5).SetCellValue (node.Attributes ["PHONE"].InnerText) ;
        		newSheet.GetRow (count ).CreateCell (6).SetCellValue (node.Attributes ["EMAIL"].InnerText) ;
        		count  ++ ;
        	}
        	newBook .Write (fs ) ;
        	fs.Close () ;
		}
			
	}
}
