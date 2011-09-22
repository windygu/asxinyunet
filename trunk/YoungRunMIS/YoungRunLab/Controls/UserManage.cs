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
		public UserManage()
		{		
			InitializeComponent();
			stausInfoShow1.SetAllToolInfo("资源采集列表", "KP.NET 资源采集管理系统",
			                              "当前系统时间：" + DateTime.Today.ToShortDateString());
			dgvUser.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
				new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
				new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
		}
		List <tb_user > userList ;
		
		void ToolFindClick(object sender, EventArgs e)
		{
			userList = tb_user.FindAll () ;
			dgvUser.DataSource = userList ;
		}
		
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
		#region 菜单事件
		private void toolStripMenuEdit_Click(object sender, EventArgs e)
		{
			if (dgvUser.CurrentCell !=null ) {
				dgvUser.BeginEdit(false);
			}
		}
		private void toolStripMenuDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
				    == DialogResult.Yes)
				{
					int count = dgvUser.SelectedCells.Count ;
					List <int > index = new List<int> () ;
					for (int i = 0; i < count ; i++)
					{
                        int RowIndex = dgvUser.SelectedCells[i].RowIndex;
                        if (!index.Contains (RowIndex )) {					
                            userList[RowIndex ].Delete () ;
                        }											
					}
                    ToolFindClick(sender, e);
				}
				else
					return;
			}
			catch (Exception err)
			{
				MessageBox.Show("删除出错:" + err.Message);
			}
		}
		#endregion

        private void toolAdd_Click(object sender, EventArgs e)
        {
            AddUserForm form = new AddUserForm();
            if ( form.ShowDialog()== DialogResult.OK )
            {
                ToolFindClick(sender, e);
            }
        }		
	}
}
