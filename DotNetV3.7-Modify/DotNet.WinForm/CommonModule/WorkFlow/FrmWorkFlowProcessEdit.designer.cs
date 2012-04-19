namespace DotNet.WinForm
{
    partial class FrmWorkFlowProcessEdit
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
            this.lblParent = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            this.cmbWorkFlowCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(10, 21);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(105, 12);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "组织机构(&O)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(118, 76);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(323, 21);
            this.txtCode.TabIndex = 7;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(10, 78);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(105, 12);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(369, 233);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(288, 233);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(118, 162);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(323, 56);
            this.txtDescription.TabIndex = 13;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(10, 165);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(105, 12);
            this.lblDescription.TabIndex = 12;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(118, 136);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 11;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(118, 47);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(323, 21);
            this.txtFullName.TabIndex = 4;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(10, 49);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(105, 12);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(447, 50);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 5;
            this.lblFullNameReq.Text = "*";
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(447, 79);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 8;
            this.lblCodeReq.Text = "*";
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(447, 22);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 2;
            this.lblParentReq.Text = "*";
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = true;
            this.ucOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(118, 17);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(323, 23);
            this.ucOrganize.TabIndex = 1;
            // 
            // cmbWorkFlowCategory
            // 
            this.cmbWorkFlowCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWorkFlowCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkFlowCategory.Location = new System.Drawing.Point(118, 106);
            this.cmbWorkFlowCategory.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbWorkFlowCategory.Name = "cmbWorkFlowCategory";
            this.cmbWorkFlowCategory.Size = new System.Drawing.Size(323, 20);
            this.cmbWorkFlowCategory.TabIndex = 10;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(10, 111);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(105, 12);
            this.lblCategory.TabIndex = 9;
            this.lblCategory.Text = "分类：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmWorkFlowProcessEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(467, 269);
            this.Controls.Add(this.cmbWorkFlowCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.ucOrganize);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.lblCodeReq);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmWorkFlowProcessEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "编辑审批流程";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.Label lblParentReq;
        private DotNet.WinForm.UCOrganizeSelect ucOrganize;
        private System.Windows.Forms.ComboBox cmbWorkFlowCategory;
        private System.Windows.Forms.Label lblCategory;

    }
}