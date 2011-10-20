/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-26
 * 时间: 15:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YoungRunLab.Forms;
using YoungRunEntity ;
using DotNet.Tools.Controls;

namespace YoungRunLab.Controls
{
	/// <summary>
	/// Description of AddOilSampleTest.
	/// </summary>
	public partial class AddTankTest : UserControl
	{
		public AddTankTest()
		{
			InitializeComponent();
			IsFlag = false ;
		}
		bool IsFlag ;
		private void btnInputData_Click(object sender, EventArgs e)
		{
			//输入全套检测数据
			AddOilDataForm addform = new AddOilDataForm();
            addform.IsNext = false ;
			if (addform.ShowDialog ()== DialogResult.OK )
			{
				//返回ID后关闭
				txtDataID.Text = addform.GetDataID () ;
				addform.Close();
			}
		}

		private void btnOK_Click(object sender, EventArgs e)
		{
			//添加数据
			if (txtRecordID .Text.Trim ()!="" && txtDataID.Text.Trim ()!="") {
				tb_oilsampletest model = new tb_oilsampletest () ;
				model.ID = txtRecordID.Text.Trim () ;
				model.RecordType = "灌区检测" ;
				model.OilName = txtOilName.Text.Trim () ;
				model.Provider = txtProvider.Text.Trim () ;
				model.DataID = txtDataID.Text.Trim () ;
				model.SendDateTime = dtSendTime.Value  ;
				model.SendPerson = txtSendPerson.Text.Trim () ;
				model.Remark = txtRemark .Text.Trim() ;
				model.Insert () ;
				IsFlag = true ;
				MessageBox.Show ("添加成功") ;
			}
			AddOilSampleTest_Load(sender,e);
		}

		private void AddOilSampleTest_Load(object sender, EventArgs e)
		{
			if (!DesignMode ) {
				WinFormHelper.ResetFormControls(sender, e, this);				
				txtRecordID.Text =YoungRunHelper.GetNextYoungRunDataId (YoungRunDataType.R204 ) ;
				dtSendTime.Value =  YoungRunHelper.GetDBServerTime () ;		
				txtProvider.Items.Clear () ;
				txtProvider.Items.AddRange (YoungRunHelper.GetDicValueList (YoungRunDicType.TankId )) ;
                txtOilName.Items.Clear();
                txtOilName.Items.AddRange(YoungRunHelper.GetDicValueList(YoungRunDicType.ProductName));
			}
		}

		private void btnCancle_Click(object sender, EventArgs e)
		{
			if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;
			else
				this.ParentForm.DialogResult = DialogResult.Cancel ;
			this.ParentForm.Close () ;
		}	
		
	}
}
