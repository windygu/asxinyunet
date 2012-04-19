namespace DotNet.WinForm
{
    partial class FrmUserAddToOrganize
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

        #region Windows 窗体设计器生成的主键

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用主键编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpRequestAnAccount = new System.Windows.Forms.GroupBox();
            this.ucWorkgroup = new DotNet.WinForm.UCOrganizeSelect();
            this.lblWorkgroup = new System.Windows.Forms.Label();
            this.ucDepartment = new DotNet.WinForm.UCOrganizeSelect();
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblRealName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnAddToOrganize = new System.Windows.Forms.Button();
            this.grpRequestAnAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(413, 335);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpRequestAnAccount
            // 
            this.grpRequestAnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRequestAnAccount.Controls.Add(this.ucWorkgroup);
            this.grpRequestAnAccount.Controls.Add(this.lblWorkgroup);
            this.grpRequestAnAccount.Controls.Add(this.ucDepartment);
            this.grpRequestAnAccount.Controls.Add(this.ucCompany);
            this.grpRequestAnAccount.Controls.Add(this.label4);
            this.grpRequestAnAccount.Controls.Add(this.txtDescription);
            this.grpRequestAnAccount.Controls.Add(this.lblDescription);
            this.grpRequestAnAccount.Controls.Add(this.lblDepartment);
            this.grpRequestAnAccount.Controls.Add(this.lblCompanyName);
            this.grpRequestAnAccount.Controls.Add(this.cmbRole);
            this.grpRequestAnAccount.Controls.Add(this.lblRole);
            this.grpRequestAnAccount.Controls.Add(this.txtRealName);
            this.grpRequestAnAccount.Controls.Add(this.chbEnabled);
            this.grpRequestAnAccount.Controls.Add(this.txtUserName);
            this.grpRequestAnAccount.Controls.Add(this.lblRealName);
            this.grpRequestAnAccount.Controls.Add(this.lblUserName);
            this.grpRequestAnAccount.Location = new System.Drawing.Point(10, 11);
            this.grpRequestAnAccount.Name = "grpRequestAnAccount";
            this.grpRequestAnAccount.Size = new System.Drawing.Size(479, 314);
            this.grpRequestAnAccount.TabIndex = 0;
            this.grpRequestAnAccount.TabStop = false;
            this.grpRequestAnAccount.Text = "用户";
            // 
            // ucWorkgroup
            // 
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.AllowSelect = true;
            this.ucWorkgroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWorkgroup.AutoSize = true;
            this.ucWorkgroup.CanEdit = false;
            this.ucWorkgroup.CheckMove = false;
            this.ucWorkgroup.Location = new System.Drawing.Point(116, 173);
            this.ucWorkgroup.MultiSelect = false;
            this.ucWorkgroup.Name = "ucWorkgroup";
            this.ucWorkgroup.OpenId = "";
            this.ucWorkgroup.PermissionItemScopeCode = "";
            this.ucWorkgroup.SelectedFullName = "";
            this.ucWorkgroup.SelectedId = "";
            this.ucWorkgroup.Size = new System.Drawing.Size(332, 23);
            this.ucWorkgroup.TabIndex = 12;
            // 
            // lblWorkgroup
            // 
            this.lblWorkgroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWorkgroup.Location = new System.Drawing.Point(0, 175);
            this.lblWorkgroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkgroup.Name = "lblWorkgroup";
            this.lblWorkgroup.Size = new System.Drawing.Size(114, 12);
            this.lblWorkgroup.TabIndex = 11;
            this.lblWorkgroup.Text = "所在工作组(&W)：";
            this.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucDepartment
            // 
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.AllowSelect = true;
            this.ucDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDepartment.AutoSize = true;
            this.ucDepartment.CanEdit = false;
            this.ucDepartment.CheckMove = false;
            this.ucDepartment.Location = new System.Drawing.Point(116, 144);
            this.ucDepartment.MultiSelect = false;
            this.ucDepartment.Name = "ucDepartment";
            this.ucDepartment.OpenId = "";
            this.ucDepartment.PermissionItemScopeCode = "";
            this.ucDepartment.SelectedFullName = "";
            this.ucDepartment.SelectedId = "";
            this.ucDepartment.Size = new System.Drawing.Size(332, 23);
            this.ucDepartment.TabIndex = 10;
            this.ucDepartment.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetDepartment);
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.AllowSelect = true;
            this.ucCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = false;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(116, 114);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(332, 23);
            this.ucCompany.TabIndex = 7;
            this.ucCompany.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetCompany);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(457, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "*";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(116, 228);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(332, 69);
            this.txtDescription.TabIndex = 15;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(17, 228);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(97, 12);
            this.lblDescription.TabIndex = 14;
            this.lblDescription.Text = "描述(&C)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(12, 147);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(102, 12);
            this.lblDepartment.TabIndex = 9;
            this.lblDepartment.Text = "所在部门(&D)：";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(12, 119);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(102, 12);
            this.lblCompanyName.TabIndex = 6;
            this.lblCompanyName.Text = "所在单位(&M)：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(116, 79);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(332, 20);
            this.cmbRole.TabIndex = 5;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(17, 83);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(97, 12);
            this.lblRole.TabIndex = 4;
            this.lblRole.Text = "职务(&T)：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(116, 47);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(332, 21);
            this.txtRealName.TabIndex = 3;
            // 
            // chbEnabled
            // 
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Location = new System.Drawing.Point(116, 205);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(48, 16);
            this.chbEnabled.TabIndex = 13;
            this.chbEnabled.Text = "有效";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.Location = new System.Drawing.Point(116, 19);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(332, 21);
            this.txtUserName.TabIndex = 1;
            // 
            // lblRealName
            // 
            this.lblRealName.Location = new System.Drawing.Point(17, 51);
            this.lblRealName.Name = "lblRealName";
            this.lblRealName.Size = new System.Drawing.Size(97, 12);
            this.lblRealName.TabIndex = 2;
            this.lblRealName.Text = "姓名(&N)：";
            this.lblRealName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(17, 23);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(97, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddToOrganize
            // 
            this.btnAddToOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToOrganize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnAddToOrganize.Location = new System.Drawing.Point(321, 335);
            this.btnAddToOrganize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnAddToOrganize.Name = "btnAddToOrganize";
            this.btnAddToOrganize.Size = new System.Drawing.Size(89, 23);
            this.btnAddToOrganize.TabIndex = 1;
            this.btnAddToOrganize.Text = "确定(&R)";
            this.btnAddToOrganize.Click += new System.EventHandler(this.btnAddToOrganize_Click);
            // 
            // FrmUserAddToOrganize
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(501, 367);
            this.Controls.Add(this.btnAddToOrganize);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpRequestAnAccount);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmUserAddToOrganize";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "用户兼任职务";
            this.grpRequestAnAccount.ResumeLayout(false);
            this.grpRequestAnAccount.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpRequestAnAccount;
        private System.Windows.Forms.Button btnAddToOrganize;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblRealName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label label4;
        private DotNet.WinForm.UCOrganizeSelect ucDepartment;
        private DotNet.WinForm.UCOrganizeSelect ucCompany;
        private System.Windows.Forms.Label lblWorkgroup;
        private DotNet.WinForm.UCOrganizeSelect ucWorkgroup;
    }
}