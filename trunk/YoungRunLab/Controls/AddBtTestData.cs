using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using YoungRunEntity;
using DotNet.Tools.Controls ;

namespace YoungRunLab.Controls
{
	//白土车间检测数据
	public partial class AddBtTestData : UserControl
	{
		public AddBtTestData()
		{
			InitializeComponent();
			IsFlag = false ;
			dtGetTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
			dtTestTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
		}
		bool IsFlag ;
		#region 限制文本框只输入数字
		private void txtV40_KeyPress(object sender, KeyPressEventArgs e)
		{
			WinFormHelper.SetControlOnlyValue(sender, e);
		}
		
		#endregion

		private void AddBtTestData_Load(object sender, EventArgs e)
		{
			if (!DesignMode ) {				        
				//初始化
				WinFormHelper.ResetFormControls(sender, e,this );
				//数据编号
				txtDataID.Text = YoungRunHelper.GetNextYoungRunDataId(YoungRunDataType.R202 ) ;
				dtGetTime.Value = YoungRunHelper.GetDBServerTime () ;
				dtTestTime.Value = dtGetTime.Value ;
				combProductName.Items.AddRange(YoungRunHelper.GetDicValueList (YoungRunDicType.ProductName )) ;
				combGetLoacation.Items.AddRange(YoungRunHelper.GetDicValueList (YoungRunDicType.BtGetSampleLocate )) ;
			}
		}

		//提交数据
		private void btnOK_Click(object sender, EventArgs e)
		{
			if (txtDataID.Text !="" || combProductName .Text !="" )
			{
				tb_bttestdata model = new tb_bttestdata();
				model.ID = txtDataID.Text.Trim();
				model.ProductName = combProductName.Text.Trim();
				if ( txtASTM.Text.Trim()!="") {
					model.ASTM = txtASTM.Text.Trim();
				}
				if ( txtAV.Text.Trim()!="") {
					model.AV = Convert.ToDouble(txtAV.Text.Trim());
				}
				if ( combGetLoacation.Text.Trim()!="") {
					model.GetSamLocation = combGetLoacation.Text.Trim();
				}
				if ( combGetPerson.Text.Trim()!="") {
					model.GetSampPerson = combGetPerson.Text.Trim();
				}
				if ( txtV40.Text.Trim()!="") {
					model.V40 =Convert.ToDouble ( txtV40.Text.Trim());
				}
				if ( txtV100.Text.Trim()!="") {
					model.V100 =Convert.ToDouble (txtV100.Text.Trim());
				}
				if ( combTestPerson.Text.Trim()!="") {
					model.TestPerson = combTestPerson.Text.Trim();
				}
				model.GetSampleTime = dtGetTime.Value ;
				model.UpdateTime = dtTestTime.Value ;
				model.Remark = txtRemark.Text.Trim() ;
				model.VI = YoungRunHelper.CalcuteVI(model.V40, model.V100) ;
				model.Insert() ;
				IsFlag = true ;
				MessageBox.Show ("添加成功") ;
				AddBtTestData_Load(sender, e);
			}
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;
			else
				this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close();
		}

		private void txtV100_Validated(object sender, EventArgs e)
		{
			if (txtV40.Text !="" && txtV100.Text !="")
			{
				txtVI.Text = YoungRunHelper.CalcuteVI(
					Convert.ToDouble(txtV40.Text.Trim()),
					Convert.ToDouble(txtV100.Text.Trim())).ToString () ;
			}
		}
	}
}
