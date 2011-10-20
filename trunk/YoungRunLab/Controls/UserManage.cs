/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-19
 * 时间: 12:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic ;
using DotNet.Tools.Controls ;
using YoungRunEntity ;
using YoungRunLab.Forms;


namespace YoungRunLab.Controls
{
	/// <summary>
	/// Description of UserManage.
	/// </summary>
	public partial class UserManage : UserControl
	{
		#region 初始化
		public UserManage()
		{		
			InitializeComponent();
			stausInfoShow1.SetAllToolInfo("用户管理", "YoungRun.NET管理系统",
			                              "当前系统时间：" + DateTime.Today.ToShortDateString());
			dgvUser.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
				new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
				new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
			cutSql= string.Empty ;
		}
		List <tb_user > userList ;
		#endregion
		
		#region 搜索
		void ToolFindClick(object sender, EventArgs e)
		{
			
		}
		void GetData()
		{		
			userList = tb_user.FindAll ();
			dgvUser.DataSource = userList ;
		}
		#endregion		
		
		#region 菜单事件
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
		private void toolStripMenuEdit_Click(object sender, EventArgs e)
		{
			if (dgvUser.CurrentCell !=null ) {
				dgvUser.BeginEdit(false);
			}
		}
		private void toolStripMenuDelete_Click(object sender, EventArgs e)
		{
            WinFormHelper.DeleteDgvItems<tb_user>(sender, e, dgvUser, userList);
            ToolFindClick(sender, e);
		}
		#endregion

		#region 添加
        private void toolAdd_Click(object sender, EventArgs e)
        {
        	AddUserForm form = new AddUserForm();
        	if(form.ShowDialog ()== DialogResult.OK ) 
            {
                ToolFindClick(sender, e);        	
			}                	
        }		
        #endregion        
		string cutSql ;
		void ToolExportToExcelClick(object sender, EventArgs e)
		{
			SearchConditionForm sf = new SearchConditionForm () ;
            sf.EntityName = typeof(tb_user );
            sf.CurConditions = cutSql ;
        	if (sf.ShowDialog ()== DialogResult.OK ) {
        		cutSql = sf.CurConditions ;
        		GetData () ;
        	}         
		}
	}
}