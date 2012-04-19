//--------------------------------------------------------------------
// All Rights Reserved ,Copyright (C) 2011 , Hairihan TECH, Ltd. .
//--------------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// FormSubmitTest.cs
    /// 工作流测试-测试窗体
    ///		
    /// 修改记录
    ///
    ///     2007.07.25 版本：1.0 JiRiGaLa  页面编写。
    ///		
    /// 版本：1.1
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.07.25</date>
    /// </author> 
    /// </summary> 
    public partial class FrmWorkFlowStatr : BaseForm
    {
        public FrmWorkFlowStatr()
        {
            InitializeComponent();
        }

        private void FormSubmitTest_Load(object sender, EventArgs e)
        {
            this.ucFreeStatr.CategoryId = this.txtCategoryId.Text;
            this.ucFreeStatr.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucFreeStatr.ObjectId = this.txtObjectId.Text;
            this.ucFreeStatr.ObjectFullName = this.txtObjectFullName.Text;
            // this.ucFreeStatr.DefaultUser = "10000000";
            this.ucFreeStatr.Init();
        }

        private bool ucAutoStatr_BeforBtnSendToClick(string categoryId, string objectId)
        {
            this.ucAutoStatr.WorkFlowCode = this.txtWorkFlowCode.Text;
            this.ucAutoStatr.CategoryId = this.txtCategoryId.Text;
            this.ucAutoStatr.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucAutoStatr.ObjectId = this.txtObjectId.Text;
            this.ucAutoStatr.ObjectFullName = this.txtObjectFullName.Text;
            return true;
        }

        private bool ucUserStatr_BeforBtnSendToClick(string categoryId, string objectId, string sendToUserId)
        {
            this.ucFreeStatr.CategoryId = this.txtCategoryId.Text;
            this.ucFreeStatr.CategoryFullName = this.txtCategoryFullName.Text;
            this.ucFreeStatr.ObjectId = this.txtObjectId.Text;
            this.ucFreeStatr.ObjectFullName = this.txtObjectFullName.Text;
            return true;
        }

        private void rb_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rbByUser.Checked)
            {
                this.ucFreeStatr.WorkFlowCategory = "ByUser";
            }
            else
            {
                this.ucFreeStatr.WorkFlowCategory = "ByRole";
            }
        }
    }
}