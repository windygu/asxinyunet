/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-28
 * 时间: 15:37
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using YoungRunST.Controls ;
using YoungRunST.Forms;
using XCode ;
using YoungRunEntity ;
using XCode.Configuration;
using DotNet.Tools.Controls ;

namespace YoungRunST
{
	/// <summary>
	/// 储运部信息管理
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}      
		private void button1_Click(object sender, EventArgs e)
		{			
            
		}
		
		void Button2Click(object sender, EventArgs e)
		{
			OilTankSTManageForm a = new OilTankSTManageForm () ;
			a.ShowDialog () ;
		}
		void Button3Click(object sender, EventArgs e)
		{
			OilTankInfoManageForm b = new OilTankInfoManageForm () ;
			b.ShowDialog () ;
		}

        private void button4_Click(object sender, EventArgs e)
        {
//        	DataManageForm dt = new DataManageForm () ;
//        	dt.IsHaveMenu = true ;
//        	dt.FormAssemblyName = "YoungRunST.exe" ;
//        	dt.FormName = "YoungRunST.Forms.AddOilTankInfoForm" ;
//        	dt.EntityType = typeof (tb_oiltankinfo ) ;
//        	dt.ShowDialog () ;
        }
	}
}