/*
 * 由SharpDevelop创建。
 * 用户： asxinyu}
 * 日期: 2011-9-25
 * 时间: 20:02
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using XCode.Configuration ;
using XCode ;
using NewLife.Configuration ;

namespace DotNet.Tools.Controls
{
	/// <summary>
	/// Description of ConfigForm.
	/// </summary>
	public partial class ConfigForm : UserControl
	{
		public ConfigForm()
		{
			InitializeComponent();			
		}
		
		void ToolAdd_Click(object sender, EventArgs e)
		{
			// TODO: Implement ToolAdd_Click
		}
		
		void ToolFind_Click(object sender, EventArgs e)
		{
			//加载所有的配置文件信息
			//建立配置文件数据表来操作更方便
		}
	}
}
