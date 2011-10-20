/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-5
 * 时间: 13:19
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace CustomerMS.CustomerControl
{
	/// <summary>
	/// Description of GetIndustryList.
	/// </summary>
	public partial class GetIndustryList : UserControl
	{
		public GetIndustryList()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
	}
}
