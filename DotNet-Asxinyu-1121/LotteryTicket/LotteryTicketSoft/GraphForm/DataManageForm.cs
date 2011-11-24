/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2011-10-5
 * 时间: 14:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using XCode;
using DotNet.Tools.Controls;

namespace LotteryTicketSoft.GraphForm
{
	/// <summary>
	/// Description of TestControlForm.
	/// </summary>
	public partial class DataManageForm : Form
	{
		public DataManageForm()
		{
			InitializeComponent();           
		}
		/// <summary>
		/// 初始化配置
		/// </summary>
        /// <param name="dcp">参数类</param>
        public void InitializeSettings(DataControlParams dcp)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = dcp.ManageFormTitleText;//标题
            this.DataManageControl.InitializeSettings(dcp);
        }
	}
}