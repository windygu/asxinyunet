namespace DotNet.WinForm
{
    partial class FrmWorkFlowStatr
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblObjectFullName = new System.Windows.Forms.Label();
            this.lblObjectId = new System.Windows.Forms.Label();
            this.lblCategoryFullName = new System.Windows.Forms.Label();
            this.lblCategoryId = new System.Windows.Forms.Label();
            this.txtObjectId = new System.Windows.Forms.TextBox();
            this.txtCategoryFullName = new System.Windows.Forms.TextBox();
            this.txtObjectFullName = new System.Windows.Forms.TextBox();
            this.txtCategoryId = new System.Windows.Forms.TextBox();
            this.rbByRole = new System.Windows.Forms.RadioButton();
            this.rbByUser = new System.Windows.Forms.RadioButton();
            this.ucAutoStatr = new DotNet.WinForm.UCAutoWorkFlowStatr();
            this.ucFreeStatr = new DotNet.WinForm.UCFreeWorkFlowStatr();
            this.lblWorkFlowCode = new System.Windows.Forms.Label();
            this.txtWorkFlowCode = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lblObjectFullName
            // 
            this.lblObjectFullName.Location = new System.Drawing.Point(116, 130);
            this.lblObjectFullName.Name = "lblObjectFullName";
            this.lblObjectFullName.Size = new System.Drawing.Size(258, 12);
            this.lblObjectFullName.TabIndex = 6;
            this.lblObjectFullName.Text = "订单名称 ObjectFullName:";
            this.lblObjectFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblObjectId
            // 
            this.lblObjectId.Location = new System.Drawing.Point(116, 103);
            this.lblObjectId.Name = "lblObjectId";
            this.lblObjectId.Size = new System.Drawing.Size(258, 12);
            this.lblObjectId.TabIndex = 4;
            this.lblObjectId.Text = "订单代码（Id）ObjectId:";
            this.lblObjectId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategoryFullName
            // 
            this.lblCategoryFullName.Location = new System.Drawing.Point(116, 57);
            this.lblCategoryFullName.Name = "lblCategoryFullName";
            this.lblCategoryFullName.Size = new System.Drawing.Size(258, 12);
            this.lblCategoryFullName.TabIndex = 2;
            this.lblCategoryFullName.Text = "单据分类名称 CategoryFullName:";
            this.lblCategoryFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCategoryId
            // 
            this.lblCategoryId.Location = new System.Drawing.Point(116, 28);
            this.lblCategoryId.Name = "lblCategoryId";
            this.lblCategoryId.Size = new System.Drawing.Size(258, 12);
            this.lblCategoryId.TabIndex = 0;
            this.lblCategoryId.Text = "单据分类代码（表名） CategoryId:";
            this.lblCategoryId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtObjectId
            // 
            this.txtObjectId.Location = new System.Drawing.Point(380, 97);
            this.txtObjectId.Name = "txtObjectId";
            this.txtObjectId.Size = new System.Drawing.Size(155, 21);
            this.txtObjectId.TabIndex = 5;
            this.txtObjectId.Text = "JHD-0001";
            // 
            // txtCategoryFullName
            // 
            this.txtCategoryFullName.Location = new System.Drawing.Point(380, 51);
            this.txtCategoryFullName.Name = "txtCategoryFullName";
            this.txtCategoryFullName.Size = new System.Drawing.Size(155, 21);
            this.txtCategoryFullName.TabIndex = 3;
            this.txtCategoryFullName.Text = "进货单";
            // 
            // txtObjectFullName
            // 
            this.txtObjectFullName.Location = new System.Drawing.Point(380, 124);
            this.txtObjectFullName.Name = "txtObjectFullName";
            this.txtObjectFullName.Size = new System.Drawing.Size(155, 21);
            this.txtObjectFullName.TabIndex = 7;
            this.txtObjectFullName.Text = "进货单(JHD-0001)";
            // 
            // txtCategoryId
            // 
            this.txtCategoryId.Location = new System.Drawing.Point(380, 24);
            this.txtCategoryId.Name = "txtCategoryId";
            this.txtCategoryId.Size = new System.Drawing.Size(155, 21);
            this.txtCategoryId.TabIndex = 1;
            this.txtCategoryId.Text = "ERP_JHD";
            // 
            // rbByRole
            // 
            this.rbByRole.AutoSize = true;
            this.rbByRole.Checked = true;
            this.rbByRole.Location = new System.Drawing.Point(309, 247);
            this.rbByRole.Name = "rbByRole";
            this.rbByRole.Size = new System.Drawing.Size(125, 16);
            this.rbByRole.TabIndex = 9;
            this.rbByRole.TabStop = true;
            this.rbByRole.Text = "ByRole 按角色审核";
            this.rbByRole.UseVisualStyleBackColor = true;
            this.rbByRole.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbByUser
            // 
            this.rbByUser.AutoSize = true;
            this.rbByUser.Location = new System.Drawing.Point(455, 247);
            this.rbByUser.Name = "rbByUser";
            this.rbByUser.Size = new System.Drawing.Size(125, 16);
            this.rbByUser.TabIndex = 10;
            this.rbByUser.Text = "ByUser 按用户审核";
            this.rbByUser.UseVisualStyleBackColor = true;
            this.rbByUser.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // ucAutoStatr
            // 
            this.ucAutoStatr.Location = new System.Drawing.Point(232, 405);
            this.ucAutoStatr.Name = "ucAutoStatr";
            this.ucAutoStatr.SelectedIds = null;
            this.ucAutoStatr.SetSelectIds = null;
            this.ucAutoStatr.Size = new System.Drawing.Size(274, 23);
            this.ucAutoStatr.TabIndex = 11;
            this.ucAutoStatr.BeforBtnSendToClick += new DotNet.WinForm.UCAutoWorkFlowStatr.ButtonSendToClickEventHandler(this.ucAutoStatr_BeforBtnSendToClick);
            // 
            // ucFreeStatr
            // 
            this.ucFreeStatr.AllowNull = true;
            this.ucFreeStatr.AllowSelect = false;
            this.ucFreeStatr.Location = new System.Drawing.Point(33, 269);
            this.ucFreeStatr.MultiSelect = false;
            this.ucFreeStatr.Name = "ucFreeStatr";
            this.ucFreeStatr.OpenId = "";
            this.ucFreeStatr.PermissionItemScopeCode = "";
            this.ucFreeStatr.RemoveIds = null;
            this.ucFreeStatr.SelectedFullName = "";
            this.ucFreeStatr.SelectedId = "";
            this.ucFreeStatr.SelectedIds = null;
            this.ucFreeStatr.SetSelectIds = null;
            this.ucFreeStatr.Size = new System.Drawing.Size(599, 26);
            this.ucFreeStatr.TabIndex = 8;
            this.ucFreeStatr.WorkFlowCategory = "ByRole";
            this.ucFreeStatr.BeforBtnSendToClick += new DotNet.WinForm.UCFreeWorkFlowStatr.ButtonSendToClickEventHandler(this.ucUserStatr_BeforBtnSendToClick);
            // 
            // lblWorkFlowCode
            // 
            this.lblWorkFlowCode.Location = new System.Drawing.Point(51, 382);
            this.lblWorkFlowCode.Name = "lblWorkFlowCode";
            this.lblWorkFlowCode.Size = new System.Drawing.Size(258, 12);
            this.lblWorkFlowCode.TabIndex = 12;
            this.lblWorkFlowCode.Text = "走哪个工作流(是按工作流编号来确认的):";
            this.lblWorkFlowCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWorkFlowCode
            // 
            this.txtWorkFlowCode.Location = new System.Drawing.Point(309, 378);
            this.txtWorkFlowCode.Name = "txtWorkFlowCode";
            this.txtWorkFlowCode.Size = new System.Drawing.Size(301, 21);
            this.txtWorkFlowCode.TabIndex = 13;
            this.txtWorkFlowCode.Text = "KaiFaBu_QingJiaLiuCheng";
            // 
            // FrmWorkFlowStatr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 471);
            this.Controls.Add(this.lblWorkFlowCode);
            this.Controls.Add(this.txtWorkFlowCode);
            this.Controls.Add(this.ucAutoStatr);
            this.Controls.Add(this.rbByUser);
            this.Controls.Add(this.rbByRole);
            this.Controls.Add(this.ucFreeStatr);
            this.Controls.Add(this.lblObjectFullName);
            this.Controls.Add(this.lblObjectId);
            this.Controls.Add(this.lblCategoryFullName);
            this.Controls.Add(this.lblCategoryId);
            this.Controls.Add(this.txtObjectId);
            this.Controls.Add(this.txtCategoryFullName);
            this.Controls.Add(this.txtObjectFullName);
            this.Controls.Add(this.txtCategoryId);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmWorkFlowStatr";
            this.Text = "启动审批流程";
            this.Load += new System.EventHandler(this.FormSubmitTest_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblObjectFullName;
        private System.Windows.Forms.Label lblObjectId;
        private System.Windows.Forms.Label lblCategoryFullName;
        private System.Windows.Forms.Label lblCategoryId;
        private System.Windows.Forms.TextBox txtObjectId;
        private System.Windows.Forms.TextBox txtCategoryFullName;
        private System.Windows.Forms.TextBox txtObjectFullName;
        private System.Windows.Forms.TextBox txtCategoryId;
        private UCFreeWorkFlowStatr ucFreeStatr;
        private System.Windows.Forms.RadioButton rbByRole;
        private System.Windows.Forms.RadioButton rbByUser;
        private UCAutoWorkFlowStatr ucAutoStatr;
        private System.Windows.Forms.Label lblWorkFlowCode;
        private System.Windows.Forms.TextBox txtWorkFlowCode;
    }
}