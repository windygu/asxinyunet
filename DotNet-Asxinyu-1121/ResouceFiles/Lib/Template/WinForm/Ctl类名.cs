using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using NewLife.CommonEntity ;
using EntLib.Controls.WinForm ;
using XCode ;
using NewLife ;

namespace <#=Config.NameSpace#>
{
	public partial class Ctl<#=Table.Name#>: UserControl
	{
		#region 初始化		
		public Ctl<#=Table.Name#>()
		{
			InitializeComponent();
			dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
				new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
				new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
			winPage.PageSize = 20 ;
		}
		List < <#=Table.Alias#> > btList ;

		private void Ctl<#=Table.Name#>_Load(object sender, EventArgs e)
		{
			GetData() ;
		}

		#endregion
		
		#region 菜单事件
		void GetData()
		{
			btList = <#=Table.Alias#>.FindAll ();
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
			try
			{
				if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
				    == DialogResult.Yes)
				{
					int count = dgv.SelectedCells.Count ;
					List <int > index = new List<int> () ;
					for (int i = 0; i < count ; i++)
					{
						int RowIndex = dgv.SelectedCells[i].RowIndex;
						if (!index.Contains (RowIndex )) {
							btList[RowIndex ].Delete () ;
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
		
		#region 添加 查找 退出
		//这里需要更改
		void ToolAddClick(object sender, EventArgs e)
		{
			<#=Table.Name#> _CurrEntity;
			var frm = new AddForm<#=Table.Name#> { BaseFormType = 0, formTitle = "<#=Table.Description#>-增加" };
			frm.ShowDialog();
			if (frm.DialogResult == DialogResult.Yes)
			{
				_CurrEntity = frm.CurrEntity;

				if (_CurrEntity != null)
				{
					GetData() ;
				}
			}
		}

		private void ExportToExcelClick(object sender, EventArgs e)
		{
			dgv.ToXLS("项目列表");
		}

		void ToolFindClick(object sender, EventArgs e)
		{
			GetData() ;
		}
		void ToolExitClick(object sender, EventArgs e)
		{
			this.ParentForm.Close () ;
		}
		#endregion
		
		#region 搜索 分页
		void BtnSearchClick(object sender, EventArgs e)
		{
			
			btList = <#=Table.Alias#>.FindAll (GetSearchString(),"", "", 0,winPage.PageSize );
			dgv.DataSource = btList ;
		}
		//搜索条件需要更新需要改
		string GetSearchString()
		{
			//string res = "" ;
			//if (combProductName.Text !="")
			//{
			//    res += (tb_bttestdata._.ProductName +" like '%" +combProductName.Text.Trim ()+"%'") ;
			//}
			//if (combGetTime.Text !="") {
			//    if (res =="") {
			//        res +=String.Format(tb_bttestdata._.GetSampleTime +">{0}", 
			//                            tb_bttestdata.Meta.FormatDateTime( DateTime.Now.AddDays(-1).Date)) ;                    
			//    }
			//    else 
			//        res +=(" and " + String.Format(tb_bttestdata._.GetSampleTime +">{0}", 
			//                                       tb_bttestdata.Meta.FormatDateTime( DateTime.Now.AddDays(-1).Date)));				
			//}
			//return res ;
			return "" ;
		}
		
		void WinPagePageIndexChanged(object sender, EventArgs e)
		{
			string sql = GetSearchString();
			winPage.RecordCount = <#=Table.Alias#>.FindCount(sql,"","",0,0) ;
			btList = <#=Table.Alias#>.FindAll(sql, "", "", (winPage.PageIndex -1)*winPage.PageSize ,
			                               winPage.PageSize );
			dgv.DataSource = btList ;
		}
		#endregion
	}
}
