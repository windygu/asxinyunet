/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-5
 * 时间: 13:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CustomerCollector ;

namespace CustomerMS.CustomerControl
{
	/// <summary>
	/// Description of ParseIndustry.
	/// </summary>
	public partial class ParseIndustry : UserControl
	{
		public ParseIndustry()
		{			
			InitializeComponent();			
		}
		
		void BtnParseClick(object sender, EventArgs e)
		{
			  //解析并添加到数据库            
            AlibabaInfo.GetIndustryList(txtIndustry.Text.Trim());     
		}
		
		void BtnExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close ();
		}
	}
}
