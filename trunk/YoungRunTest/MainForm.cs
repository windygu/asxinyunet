/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-10-12
 * 时间: 9:54
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using DotNet.Tools.Controls ;
using NewLife.CommonEntity ;
using XCode ;
using XCode.DataAccessLayer ;

namespace YoungRunTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void Button1Click(object sender, EventArgs e)
		{	
//			Administrator admin = new Administrator () ;
//			admin.Name = "aa" ;
//			admin.IsEnable = true ;
//			admin.DisplayName ="aa" ;
//			admin.Save ();
			NewLife.CommonEntity.Menu me = new NewLife.CommonEntity.Menu () ;
			me.Permission = "a";
			me.ParentMenuName ="asdfsa";
			me.Save () ;
//			AddBttestdataForm testform = new AddBttestdataForm () ;
//			testform.InitializeSettings (FormShowMode.ReadOnlyForOne ,"","") ;
//			testform.ShowDialog () ;
		}
	}
}
