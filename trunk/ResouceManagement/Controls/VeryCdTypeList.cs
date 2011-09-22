/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-18
 * 时间: 10:58
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic ;
using DotNet.Tools.Controls ;
using ResouceCollector ;
using ResouceEntity ;

namespace ResouceManagement.Controls
{
	///<summary>
	///Description of VCTypeList
	///</summary>
	public partial class VeryCdTypeList : UserControl
	{
		#region 初始化
		List <tb_typelist > typeList ;
		public VeryCdTypeList()
		{
			InitializeComponent();
            stausInfoShow1.SetAllToolInfo("资源采集列表", "KP.NET 资源采集管理系统",
                                         "当前系统时间：" + DateTime.Today.ToShortDateString());
            dgvTypeList.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
            new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
            new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });                
		}
		#endregion
	
		#region 菜单事件
		private void toolStripMenuEdit_Click(object sender, EventArgs e)
		{
			if (dgvTypeList.CurrentCell !=null ) {
				dgvTypeList.BeginEdit(false);
			}
		}
		private void toolStripMenuDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
				    == DialogResult.Yes)
				{
					int count = dgvTypeList.SelectedCells.Count ;
					List <int > index = new List<int> () ;
					for (int i = 0; i < count ; i++)
					{
                        int RowIndex = dgvTypeList.SelectedCells[i].RowIndex ;
                        if (!index.Contains (RowIndex )) {					
                            typeList[RowIndex ].Delete () ;
                        }											
					}
                     toolFind_Click(sender, e ) ;
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

		#region 其他事件
        private void toolFind_Click(object sender, EventArgs e)
        {
            typeList = tb_typelist.FindAll();
            dgvTypeList.DataSource = typeList;
        }
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
		#endregion
	}
}