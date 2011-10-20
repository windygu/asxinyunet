/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-09-30 10:34:09
 * 版权：版权所有 (C) 新生命开发团队 2011
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoungRunEntity ;
using DotNet.Tools.Controls ;
using XCode ;
using NewLife ;
using YoungRunST.Forms ;


namespace YoungRunST.Controls
{
	public partial class OilTankSTManage : UserControl
	{
		#region 初始化
		public OilTankSTManage()
		{
			InitializeComponent();
			string maininfo = "油罐储量信息表" ;
			stausInfoShow1.SetAllToolInfo(maininfo, "YoungRun.NET管理系统",
			                              "当前系统时间：" + DateTime.Today.ToShortDateString());
			dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
				new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
				new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
			winPage.PageSize = 20 ;
			cutSql = string.Empty ;
		}
		List <tb_oiltankst> btList ;
		string cutSql  ;
		#endregion
		
		#region 菜单事件
		//获取数据并绑定到dgv
		void GetData()
		{
			winPage.RecordCount = tb_oiltankst.FindCount(cutSql,"","",0,0) ;
			btList = tb_oiltankst.FindAll(cutSql , "", "", (winPage.PageIndex - 1) * winPage.PageSize,
			                              winPage.PageSize);
			dgv.DataSource = btList ;
		}
		
		private void toolStripMenuEdit_Click(object sender, EventArgs e)
		{
			if (dgv.CurrentCell !=null ) {
				dgv.BeginEdit(false);
			}
		}
		private void toolStripMenuDelete_Click(object sender, EventArgs e)
		{
			WinFormHelper.DeleteDgvItems<tb_oiltankst>(sender, e, dgv, btList);
			ToolFindClick(sender, e);
		}
		#endregion
		
		#region 添加 查找 退出
		//添加
		void ToolAddClick(object sender, EventArgs e)
		{
			AddOilTankSTForm addForm = new AddOilTankSTForm () ;
			if (addForm.ShowDialog ()== DialogResult.OK ) {
				GetData () ;
			}
		}
		void ToolFindClick(object sender, EventArgs e)
		{
			GetData () ;
		}
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
		#endregion
		
		#region 搜索 分页
		//搜索事件
		void BtnSearchClick(object sender, EventArgs e)
		{
			GetData () ;
		}
		
		//数据分页事件
		void WinPagePageIndexChanged(object sender, EventArgs e)
		{
			GetData () ;
		}
		#endregion
		
		private void dgv_SelectionChanged(object sender, EventArgs e)
		{
            stausInfoShow1.SetToolInfo2("和值:" + WinFormHelper.GetDynamicSecletedInfo(dgv)[0].ToString());
		}
		
		void ToolExportToExcelClick(object sender, EventArgs e)
		{
			SearchConditionForm sf = new SearchConditionForm () ;
            sf.EntityName = typeof(tb_oiltankst );
            sf.CurConditions = cutSql ;
        	if (sf.ShowDialog ()== DialogResult.OK ) {
        		cutSql = sf.CurConditions ;
        		GetData () ;
        	}
		}
	}
}