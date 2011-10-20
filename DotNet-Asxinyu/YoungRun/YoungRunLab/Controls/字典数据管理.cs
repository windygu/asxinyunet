﻿/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-09-27 16:02:25
 * 版权：版权所有 (C) 新生命开发团队 2011
*/
/*
 * XCoder v4.3.2011.0915
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-09-26 13:16:31
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
using YoungRunLab.Forms ;
using YoungRunEntity ;
using DotNet.Tools.Controls ;
using XCode ;
using NewLife ;

namespace YoungRunLab.Controls
{
	public partial class DicTypeManage:UserControl
	{
		#region 初始化
        public DicTypeManage()
		{
			InitializeComponent();
			string maininfo = "字典数据" ;
			stausInfoShow1.SetAllToolInfo(maininfo, "YoungRun.NET管理系统",
			                              "当前系统时间：" + DateTime.Today.ToShortDateString());
			dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
				new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
				new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
			winPage.PageSize = 20 ;
			cutSql = string.Empty ;
		}
		List < tb_dictype > btList ;
		#endregion
		
		#region 菜单事件
		void GetData()
		{
			winPage.RecordCount =tb_dictype.FindCount(cutSql ,"","",0,0) ;
			btList = tb_dictype.FindAll(cutSql, "", "", (winPage.PageIndex -1)*winPage.PageSize ,
			                               winPage.PageSize );
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

            WinFormHelper.DeleteDgvItems<tb_dictype>(sender, e, dgv, btList);
            ToolFindClick(sender, e);
		}
		#endregion
		
		#region 添加 查找 退出
		//这里需要更改
		void toolAdd_Click(object sender, System.EventArgs e)
		{
			AddDicKeyForm kqform = new AddDicKeyForm();
			if(kqform.ShowDialog ()== DialogResult.OK )
			{
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
		void BtnSearchClick(object sender, EventArgs e)
		{			
			GetData () ;
		}			
		
		void winPage_PageIndexChanged(object sender, EventArgs e)
		{			
			GetData () ;
		}
		#endregion
		string cutSql ; 
		void ToolExportToExcelClick(object sender, EventArgs e)
		{
			SearchConditionForm sf = new SearchConditionForm () ;
            sf.EntityName = typeof(tb_dictype );
            sf.CurConditions = cutSql ;
        	if (sf.ShowDialog ()== DialogResult.OK ) {
        		cutSql = sf.CurConditions ;
        		GetData () ;
        	}     
		}
	}
}
