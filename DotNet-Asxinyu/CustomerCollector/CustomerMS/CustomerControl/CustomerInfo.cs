/*
 * 由SharpDevelop创建
 * 用户：asxinyu
 * 日期: 2011-9-5
 * 时间: 13:31
 * 
 * 
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using CustomerEntity;
using Kenny.Controls.WinForm ;
using DotNet.Tools.Controls ;
using System.Collections.Generic;

namespace CustomerMS.CustomerControl
{
	///<summary>
	///客户资料管理区
	///</summary>
	public partial class CustomerInfo : UserControl
	{
		#region 初始化
		public CustomerInfo()
		{
			InitializeComponent();
		}

		List <string > removeColumnList ;//需要移除的列名称
		
		List<tb_companyinfo> compList ;		
		void CustomerInfoLoad(object sender, EventArgs e)
		{
			//初始化
//			SetGrpTextBoxFalse (grpCompanyInfo,false ) ;//设置文本框可用状态
			SetBtnStatus(0);//设置按钮状态
			removeColumnList = new List<string > () ;
			removeColumnList.AddRange (new string []{tb_companyinfo._.UserName ,tb_companyinfo._.RootClass ,
			                           	tb_companyinfo._.UpdateTime ,tb_companyinfo._.WebSite,
			                           	tb_companyinfo._.PostalCode ,tb_companyinfo._.InfoOrigin ,
			                           	tb_companyinfo._.Industry ,tb_companyinfo._.Email,
			                           	tb_companyinfo._.SubIndustry }) ;
			stausInfoShow1.SetAllToolInfo ("销售客户管理","宁波永润石化-经营部",DateTime.Today.ToShortDateString ()) ;
			
			toolAmend.Enabled = false;
			Pager.RecordCount = 0 ;
			Pager.PageSize = 50 ;		   
			dgvCustomerInfo.ContextMenuStrip = WinFormHelper.GetContextMenuStrip (
				new string[]{"Edit","Delete"},new string[]{"修改","删除"},
				new EventHandler []{toolStripMenuEdit_Click,toolStripMenuDelete_Click});
		}
		#endregion
		
		#region 辅助代码
		void SetGrpTextBoxFalse(GroupBox gpb,bool bValue)
		{
			foreach (Control e in gpb.Controls) {
				if (e.GetType()==typeof (TextBox )) {
					e.Enabled = bValue ;
				}
			}
		}
		/// <summary>
		/// 按钮状态
		/// </summary>
		/// <param name="codeStatus">状态编码</param>
		void SetBtnStatus(int codeStatus)
		{
			if (codeStatus ==0 )//开始
			{
				toolSave.Enabled = false;
				toolCancel.Enabled = false;
				toolDelete.Enabled = false;
//				toolAmend.Enabled = false;
				
			}
			else if (codeStatus == 1) // 搜索浏览
			{
				//编辑可用,其他不可用
//				toolAmend.Enabled = true;
				toolDelete.Enabled = true ;
				toolSave.Enabled = false;
				toolCancel.Enabled = false;
			
			}
			else if (codeStatus ==2 )//编辑事件时
			{
				toolSave.Enabled = true ;
				toolCancel.Enabled = true ;
				toolDelete.Enabled = false  ;
//				toolAmend.Enabled = false;
				
			}
			else if (codeStatus == 3)//保存和取消事件时
			{
				toolSave.Enabled = false ;
				toolCancel.Enabled = false ;
				toolDelete.Enabled = true ;
//				toolAmend.Enabled = true ;
				
			}
			
		}

		//获取搜索字符串
		string GetConditionStr()
		{
			string res = "";
			if (txtSCompanyName .Text !="")
			{
				if (res =="")
					res +=(tb_companyinfo._.CompanyName +" like '%" + txtSCompanyName.Text.Trim ()+"%'") ;
				else
					res +=(" and  " + tb_companyinfo._.CompanyName +" like '%" + txtSCompanyName.Text.Trim ()+"%'") ;
			}
			if (txtSIndustryName.Text != "")
			{
				if (res == "")
					res += (tb_companyinfo._.SubIndustry + " like '%" + txtSIndustryName.Text.Trim() + "%' or "+
					        tb_companyinfo._.SubCategory + " like '%" + txtSIndustryName.Text.Trim() + "%'");
				else
					res += ("and " + tb_companyinfo._.SubIndustry + " like '%" + txtSIndustryName.Text.Trim() + "%' or " +
					        tb_companyinfo._.SubCategory + " like '%" + txtSIndustryName.Text.Trim() + "%'");
			}
			if (txtSAddress .Text != "")
			{
				if (res == "")
					res += (tb_companyinfo._.Address  + " like '%" + txtSAddress .Text.Trim() + "%'");
				else
					res += (" and  " + tb_companyinfo._.Address + " like '%" + txtSAddress.Text.Trim() + "%'");
			}
			if (txtSRemark.Text != "")
			{
				if (res == "")
					res += (tb_companyinfo._.Remark + " like '%" + txtSRemark.Text.Trim() + "%'");
				else
					res += (" and  " + tb_companyinfo._.Remark + " like '%" + txtSRemark.Text.Trim() + "%'");
			}
			return res;
		}
		#endregion

		#region 其他小事件
		//退出
		private void toolExit_Click(object sender, EventArgs e)
		{
			this.ParentForm.Close();
		}

		private void btnReset_Click(object sender, EventArgs e)
		{
			txtSAddress.Text = string.Empty;
			txtSCompanyName.Text = string.Empty;
			txtSIndustryName.Text = string.Empty;
			txtSRemark.Text = string.Empty;
		}
		#endregion

		#region 搜索公司
		private void btnSearch_Click(object sender, EventArgs e)
		{
			string sql = GetConditionStr();
			Pager.RecordCount = tb_companyinfo .FindCount(sql,"","",0,0) ;
			compList = tb_companyinfo.FindAll(sql, "", "", 0, Pager.PageSize );
			BandingListToDgv (dgvCustomerInfo ,compList ) ;
			SetBtnStatus(1);//更新状态
		}
		
		void BandingListToDgv(DataGridView dgv,List<tb_companyinfo > complist)
		{
			dgv.DataSource = complist; //绑定到datagridview
//			for (int i = 0; i < removeColumnList.Count ; i++) {
//				dgv.Columns.Remove(removeColumnList[i]) ;//移除不需要的列
//			}
//			//设置列宽度
//			dgv.Columns [tb_companyinfo._.CompanyName ].Width = 150 ;
//			dgv.Columns [tb_companyinfo._.UserType ].Width = 80 ;
//			dgv.Columns [tb_companyinfo._.LinkMan  ].Width = 80 ;
//			dgv.Columns [tb_companyinfo._.MainProductAndService ].Width = 120 ;
//			dgv.Columns [tb_companyinfo._.CallName  ].Width = 80 ;
//			dgv.Columns [tb_companyinfo._.Tel  ].Width = 100 ;
//			DgvDataBanding (complist ) ;
		}
		#endregion
		
		#region 绑定数据到文本框
		void DgvDataBanding(List<tb_companyinfo > compList )
		{
			txtCompanyName.DataBindings.Clear () ;
			txtCompanyName.DataBindings.Add ("Text",compList ,tb_companyinfo._.CompanyName ) ;
			txtAddress .DataBindings .Clear () ;
			txtAddress .DataBindings .Add ("Text",compList ,tb_companyinfo ._.Address ) ;
			txtBusinessMode .DataBindings .Clear () ;
			txtBusinessMode .DataBindings .Add ("Text",compList ,tb_companyinfo ._.BusinessModel ) ;
			txtFax. DataBindings.Clear () ;
			txtFax .DataBindings .Add ("Text",compList ,tb_companyinfo ._.Fax ) ;
			txtLinkMan .DataBindings .Clear () ;
			txtLinkMan .DataBindings .Add ("Text",compList ,tb_companyinfo ._.LinkMan ) ;
			txtMainProduct .DataBindings .Clear () ;
			txtMainProduct .DataBindings .Add ("Text",compList ,tb_companyinfo ._.MainProductAndService ) ;
			txtMobile .DataBindings .Clear () ;
			txtMobile .DataBindings .Add ("Text",compList ,tb_companyinfo ._.Mobile ) ;
			txtPosition .DataBindings .Clear () ;
			txtPosition .DataBindings .Add ("Text",compList ,tb_companyinfo ._.Position ) ;
			txtRemark .DataBindings .Clear () ;
			txtRemark .DataBindings .Add ("Text",compList ,tb_companyinfo ._.Remark ) ;
			txtSubIndustryName .DataBindings .Clear () ;
			txtSubIndustryName .DataBindings .Add ("Text",compList ,tb_companyinfo ._.SubCategory ) ;
			txtTel.DataBindings .Clear () ;
			txtTel.DataBindings .Add ("Text",compList ,tb_companyinfo ._.Tel ) ;
		}
		#endregion
		
		#region 修改按钮
		void ToolAmendClick(object sender, EventArgs e)
		{
			SetBtnStatus (2) ;
			SetGrpTextBoxFalse (grpCompanyInfo ,true ) ;
//			txtCompanyName.Enabled = false ;//一直不可用
		}
		#endregion
		
		#region 分页事件
		void PagerPageIndexChanged(object sender, EventArgs e)
		{
			string sql = GetConditionStr();
			Pager.RecordCount = tb_companyinfo.FindCount(sql,"","",0,0) ;
			compList = tb_companyinfo.FindAll(sql, "", "", (Pager.PageIndex -1)*Pager.PageSize ,
			                                  Pager.PageSize );
			BandingListToDgv (dgvCustomerInfo ,compList ) ;
		}
		#endregion
		
		#region 菜单事件
		private void toolStripMenuEdit_Click(object sender, EventArgs e)
		{
			dgvCustomerInfo.BeginEdit(false);
		}
		private void toolStripMenuDelete_Click(object sender, EventArgs e)
		{
			try
			{
				if (MessageBox.Show("是否删除选中记录,删除后不可恢复,确认请点'是'", "提示", MessageBoxButtons.YesNo)
				    == DialogResult.Yes)
				{
					int count = dgvCustomerInfo.SelectedCells.Count ;
					List <int > index = new List<int> () ;
					for (int i = 0; i < count ; i++)
					{
						int RowIndex = dgvCustomerInfo.SelectedCells[i].RowIndex ;
						if (!index.Contains (RowIndex )) {					
							compList[RowIndex ].Delete () ;
					    }
						
						
					}
					btnSearch_Click(sender, e) ;
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
	}
}