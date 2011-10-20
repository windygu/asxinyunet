/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-8-24
 * Time: 22:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;
using CustomerMS.BasicForm;
using XCode;
using NewLife.Reflection;
using XCode.DataAccessLayer;

namespace CustomerMS
{
	/// <summary>
	/// Class with program entry point.
	/// </summary>
	internal sealed class Program
	{
		/// <summary>
		/// Program entry point.
		/// </summary>
		[STAThread]
		private static void Main(string[] args)
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
//            string connStr = "DRIVER={MySQL ODBC 3.51 Driver};" + "SERVER=localhost;" + "DATABASE=customerdb;" + "UID=root;" + "PASSWORD=111;";
         //   String connStr = "providerName=mysql.data;Server=localhost;Database=customerdb; User=root;Password=111";
//            DAL.AddConnStr("CustomerEntity", connStr, null, "mysql.data");
			Application.Run(new MainForm ());//IndustryListForm
		}		
	}
}
