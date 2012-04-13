/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2010-8-24
 * Time: 11:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Windows.Forms;

namespace YR_CalcuteVI
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
            DateTime dt0 = new DateTime(2012, 3, 30);
            DateTime dt1 = new DateTime(2013, 6, 30);
            if ((DateTime.Compare (DateTime.Today ,dt0 )>0)&&(DateTime.Compare (DateTime.Today ,dt1 )<0))
            {
                Application.Run(new MainForm());                
            }		
		}		
	}
}
