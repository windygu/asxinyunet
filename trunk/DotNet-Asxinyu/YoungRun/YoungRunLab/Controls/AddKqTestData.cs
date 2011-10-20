/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-26
 * 时间: 13:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YoungRunEntity ;
using DotNet.Tools.Controls ;

namespace YoungRunLab.Controls
{
	/// <summary>
	/// Description of AddKqTestData.
	/// </summary>
	public partial class AddKqTestData : UserControl
	{
		public AddKqTestData()
		{
			InitializeComponent();			
			IsFlag = false ;
            dtGetTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            dtTestTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
		}
		bool IsFlag;
		void BtnOKClick(object sender, EventArgs e)
		{ 
			if (txtDataID.Text !="" || combProductName .Text !="" )
			{
				tb_kqtestdata model = new tb_kqtestdata () ;
				model.ID = txtDataID .Text.Trim () ;
				model.RawName = combProductName.Text.Trim () ;
				if (combJYHaveQ.Text !="") {
                    model.JQIsHaveKQ = combJYHaveQ.Text;
				}
				if (txtAVa.Text !="") {
					model.AV = Convert.ToDouble (txtAVa.Text.Trim ()) ;
				}
				if (combCYHaveQ.Text !="") {
                    model.CYIsHaveKQ = combCYHaveQ.Text;
				}
				if (combT8HaveQ.Text !="") {
                    model.T8WIsHaveKQ = combT8HaveQ.Text;
				}
				if (txtASTM.Text !="") {
					model.ASTM = txtASTM.Text.Trim () ;
				}
				model.GetSampleTime = dtGetTime.Value ;
				if (combGetPerson.Text !="") {
					model.GetSampPerson = combGetPerson .Text.Trim () ;
				}
				if (combTestPerson.Text !="") {
					model.TestPerson = combTestPerson.Text.Trim () ;
				}
				if (combGetLoacation.Text !="") {
					model.GetSampLocation = combGetLoacation .Text.Trim () ;
				}
				if (txtRemark.Text !="") {
					model.Remark = txtRemark.Text.Trim () ;
				}
				model.UpdateTime = dtTestTime.Value ;
				model.Insert () ;
				IsFlag = true ;
				MessageBox.Show ("添加成功") ;
			}
			//添加数据			
            AddKqTestData_Load(sender, e);
		}
		
		void TxtASTMKeyPress(object sender, KeyPressEventArgs e)
		{
			WinFormHelper.SetControlOnlyValue (sender,e ) ;
		}
		
		void BtnCancleClick(object sender, EventArgs e)
		{
			if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;		
			else 
				this.ParentForm.DialogResult = DialogResult.Cancel ;	
			this.ParentForm.Close () ;
		}

		private void AddKqTestData_Load(object sender, EventArgs e)
		{
			//初始化，输入数据编号
			if (!DesignMode ) {
				WinFormHelper.ResetFormControls(sender, e, this);
				txtDataID.Text = YoungRunHelper.GetNextYoungRunDataId (YoungRunDataType.R201 ) ;
				dtGetTime.Value = YoungRunHelper.GetDBServerTime () ;
				dtTestTime.Value = dtGetTime.Value ;
				combProductName.Items.AddRange(YoungRunHelper.GetDicValueList (YoungRunDicType.RawName )) ;
				combGetLoacation.Items.AddRange(YoungRunHelper.GetDicValueList (YoungRunDicType.KqGetSampleLoate  )) ;
			}
		}
	}
}
