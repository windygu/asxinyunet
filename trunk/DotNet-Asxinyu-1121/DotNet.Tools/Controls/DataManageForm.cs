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

namespace DotNet.Tools.Controls
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
		/// <param name="entityType">实体类型</param>
		/// <param name="formAssemblyName">窗体程序集名称</param>
		/// <param name="formName">窗体名称</param>
		/// <param name="IsHaveDgvMenu">是否显示菜单</param>
		/// <param name="pageSize">分页数</param>
		public void InitializeSettings(Type entityType,string formAssemblyName = "",string formName="",
		                               bool IsHaveDgvMenu = false,bool IsHaveSelectSum =false,int pageSize = 20,
		                              string firStatus="数据管理模块",string secStatus="",string thirdStatus="开发:asxinyu@qq.com")
		{
			this.StartPosition = FormStartPosition.CenterParent;
			this.DataManageControl .InitializeSettings (entityType,formAssemblyName,formName,IsHaveDgvMenu,IsHaveSelectSum,pageSize,
			                                            firStatus,secStatus,thirdStatus );
		}
	}
}