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
	public partial class BtTestDataManage : UserControl
	{
		#region 初始化		
		public BtTestDataManage()
		{
			InitializeComponent();
			string maininfo = "白土车间测试管理" ;
			stausInfoShow1.SetAllToolInfo(maininfo, "YoungRun.NET管理系统",
			                              "当前系统时间：" + DateTime.Today.ToShortDateString());
			dgv.ContextMenuStrip = WinFormHelper.GetContextMenuStrip(
				new string[] { "Edit", "Delete" }, new string[] { "修改", "删除" },
				new EventHandler[] { toolStripMenuEdit_Click, toolStripMenuDelete_Click });
			winPage.PageSize = 20 ;
		}
		List <tb_bttestdata > btList ;
		#endregion
		
		#region 菜单事件
		//获取数据并绑定到dgv
		void GetData()
		{
			btList = tb_bttestdata.FindAll ();
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
		//添加
		void ToolAddClick(object sender, EventArgs e)
		{
			AddBtTestDataForm addForm = new AddBtTestDataForm () ;
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
			btList = tb_bttestdata.FindAll (GetSearchString(),"", "", 0,winPage.PageSize );
			dgv.DataSource = btList ;
		}
		//得到搜索条件
		string GetSearchString()
		{
			string res = "" ;
			if (combProductName.Text !="")
			{
				res += (tb_bttestdata._.ProductName +" like '%" +combProductName.Text.Trim ()+"%'") ;
			}
			if (combGetTime.Text !="") {
				if (res =="") {
					res +=String.Format(tb_bttestdata._.GetSampleTime +">{0}", 
					                    tb_bttestdata.Meta.FormatDateTime( DateTime.Now.AddDays(-1).Date)) ;                    
				}
				else 
					res +=(" and " + String.Format(tb_bttestdata._.GetSampleTime +">{0}", 
					                               tb_bttestdata.Meta.FormatDateTime( DateTime.Now.AddDays(-1).Date)));				
			}
			return res ;
		}
		//数据分页事件
		void WinPagePageIndexChanged(object sender, EventArgs e)
		{
			string sql = GetSearchString();
			winPage.RecordCount = tb_bttestdata.FindCount(sql,"","",0,0) ;
			btList = tb_bttestdata.FindAll(sql, "", "", (winPage.PageIndex -1)*winPage.PageSize ,
			                               winPage.PageSize );
			dgv.DataSource = btList ;
		}
		#endregion
	}
}