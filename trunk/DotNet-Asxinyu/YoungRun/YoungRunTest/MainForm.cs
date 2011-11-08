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
using XCode ;
using XCode.DataAccessLayer ;
using YoungRunControl.Forms;

namespace YoungRunTest
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		public MainForm()
		{			
			InitializeComponent();			
		}
		
		void Button1Click(object sender, EventArgs e)
		{
            AddBtTestDataForm a = new AddBtTestDataForm();
            a.InitializeSettings(FormShowMode.AddOne , "", "");
            a.Show();
		}

        private void MainForm_Load(object sender, EventArgs e)
        {

        }
	}
}
