/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-26
 * 时间: 14:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using YoungRunEntity;
using DotNet.Tools.Controls ;

namespace YoungRunLab.Controls
{
	/// <summary>
	/// Description of AddOilData.
	/// </summary>
	public partial class AddOilData : UserControl
	{
		public AddOilData()
		{			
			InitializeComponent();
			IsFlag = false ;            
            dtTestTime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
		}
		bool IsFlag ;
        public bool IsNext
        {
            get;
            set;
        }     
        public string GetDataID()
        {
        	return txtDataID.Text.Trim () ;
        }
        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtDataID.Text !="" && combProductName.Text!="")
            {
                tb_oildata model = new tb_oildata();
                model.ID = txtDataID.Text.Trim();
                model.OilName = combProductName.Text.Trim();
                if (txtV40.Text .Trim ()!="")
                {
                    model.V40 = Convert.ToDouble(txtV40.Text.Trim());
                }
                if (txtV100.Text.Trim()!="")
                {
                    model.V100 = Convert.ToDouble(txtV100.Text.Trim());
                }
                if (txtAV.Text.Trim()!="")
                {
                    model.AV = Convert.ToDouble(txtAV.Text.Trim());
                }
                if (txtPP.Text.Trim() != "")
                {
                    model.PP = Convert.ToInt32(txtPP.Text.Trim());
                }
                if (txtFP.Text.Trim() != "")
                {
                    model.FP = Convert.ToInt32(txtFP.Text.Trim());
                }
                if (txtAV.Text.Trim() != "")
                {
                    model.AV = Convert.ToDouble(txtAV.Text.Trim());
                }
                if (txtWC.Text.Trim() != "")
                {
                    model.WC = Convert.ToDouble(txtWC.Text.Trim());
                }
                if (txtASTM.Text.Trim() != "")
                {
                    model.ASTM = txtASTM.Text.Trim();
                }
                if (txtD20.Text.Trim() != "")
                {
                    model.D20 = Convert.ToDouble(txtD20.Text.Trim());
                }
                if (txtMI.Text.Trim() != "")
                {
                    model.MI = Convert.ToDouble(txtMI.Text.Trim());
                }
                if (txtCR.Text.Trim() != "")
                {
                    model.CR = Convert.ToDouble(txtCR.Text.Trim());
                }
                if (txtWAA.Text.Trim() != "")
                {
                    model.WAA = txtWAA.Text.Trim();
                }
                if (txtV.Text.Trim() != "")
                {
                    model.V = txtV.Text.Trim();
                }
                if (txtDistillation.Text.Trim() != "")
                {
                    model.Distillation = txtDistillation.Text.Trim();
                }
                if (txtXZQD.Text.Trim() != "")
                {
                    model.XZQD = txtXZQD.Text.Trim();
                }
                if (txtOther.Text.Trim() != "")
                {
                    model.Other = txtOther.Text.Trim();
                }
                if (combTestPerson.Text.Trim() != "")
                {
                    model.TestPerson = combTestPerson.Text.Trim();
                }
                if (combRecordType.Text.Trim() != "")
                {
                    model.RecordType = combRecordType.Text.Trim();
                }
                model.TestDateTime = dtTestTime.Value;
                model.Remark = txtRemark.Text.Trim();
                model.Insert();
                MessageBox.Show ("添加成功") ;
                if (!IsNext)//不需要下一个
                {
                    this.ParentForm.DialogResult = DialogResult.OK;
                }
                else
                {
                    IsFlag = true;                    
                    AddOilData_Load(sender, e);
                }
            }
             
        }

        private void btnCancle_Click(object sender, EventArgs e)
        {
            if (IsFlag )
				this.ParentForm.DialogResult = DialogResult.OK  ;		
			else 
				this.ParentForm.DialogResult = DialogResult.Cancel ;	
			this.ParentForm.Visible = false  ;        
        }

        private void AddOilData_Load(object sender, EventArgs e)
        {
        	if (!DesignMode ) {
        		WinFormHelper.ResetFormControls(sender, e, this);
        		txtDataID.Text = YoungRunHelper.GetNextYoungRunDataId (YoungRunDataType.R203 ) ;
        		dtTestTime.Value =  YoungRunHelper.GetDBServerTime () ;
        		combRecordType.Items.AddRange(YoungRunHelper.GetDicValueList (YoungRunDicType.RecordType )) ;
        		combProductName.Items.AddRange(YoungRunHelper.GetDicValueList (YoungRunDicType.ProductName )) ;
        	}
        }
		
		void TxtV40KeyPress(object sender, KeyPressEventArgs e)
		{
			WinFormHelper.SetControlOnlyValue (sender,e ) ;
		}

        private void txtV100_TextChanged(object sender, EventArgs e)
        {
            if (txtV40.Text != "" && txtV100.Text != "")
            {
                txtVI.Text = YoungRunHelper.CalcuteVI(
                    Convert.ToDouble(txtV40.Text.Trim()),
                    Convert.ToDouble(txtV100.Text.Trim())).ToString();
            }
        }
	}
}
