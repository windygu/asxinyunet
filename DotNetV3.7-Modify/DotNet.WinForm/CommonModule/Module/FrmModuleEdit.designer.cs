namespace DotNet.WinForm
{
    partial class FrmModuleEdit
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
            this.txtNavigateUrl = new System.Windows.Forms.TextBox();
            this.lblNavigateUrl = new System.Windows.Forms.Label();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblParent = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.ucParent = new DotNet.WinForm.UCModuleSelect();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.btnAccessPermission = new System.Windows.Forms.Button();
            this.grbModule = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // txtNavigateUrl
            // 
            this.txtNavigateUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavigateUrl.Location = new System.Drawing.Point(138, 167);
            this.txtNavigateUrl.MaxLength = 200;
            this.txtNavigateUrl.Name = "txtNavigateUrl";
            this.txtNavigateUrl.Size = new System.Drawing.Size(443, 21);
            this.txtNavigateUrl.TabIndex = 11;
            // 
            // lblNavigateUrl
            // 
            this.lblNavigateUrl.Location = new System.Drawing.Point(30, 170);
            this.lblNavigateUrl.Name = "lblNavigateUrl";
            this.lblNavigateUrl.Size = new System.Drawing.Size(106, 12);
            this.lblNavigateUrl.TabIndex = 10;
            this.lblNavigateUrl.Text = "Web网址：";
            this.lblNavigateUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarget.Location = new System.Drawing.Point(138, 198);
            this.txtTarget.MaxLength = 100;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(443, 21);
            this.txtTarget.TabIndex = 13;
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(30, 201);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(106, 12);
            this.lblTarget.TabIndex = 12;
            this.lblTarget.Text = "目标(&T)：";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(30, 45);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(106, 12);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "父节点(&P)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(138, 259);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(443, 51);
            this.txtDescription.TabIndex = 17;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(138, 101);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(443, 21);
            this.txtFullName.TabIndex = 5;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(138, 132);
            this.txtCode.MaxLength = 100;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(443, 21);
            this.txtCode.TabIndex = 8;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(30, 259);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(106, 12);
            this.lblDescription.TabIndex = 16;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(30, 104);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(106, 12);
            this.lblFullName.TabIndex = 4;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(30, 135);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(106, 12);
            this.lblCode.TabIndex = 7;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(529, 340);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(448, 340);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(586, 105);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 6;
            this.lblFullNameReq.Text = "*";
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(586, 136);
            this.lblCodeReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 9;
            this.lblCodeReq.Text = "*";
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.AllowSelect = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.CheckMove = true;
            this.ucParent.Location = new System.Drawing.Point(138, 42);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.SelectedCode = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.Size = new System.Drawing.Size(443, 22);
            this.ucParent.TabIndex = 1;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Location = new System.Drawing.Point(233, 234);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(48, 16);
            this.chkIsPublic.TabIndex = 15;
            this.chkIsPublic.Text = "公开";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            this.chkIsPublic.CheckedChanged += new System.EventHandler(this.chkIsPublic_CheckedChanged);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(138, 234);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 14;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(30, 75);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(106, 12);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "主键：";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(138, 71);
            this.txtId.MaxLength = 100;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(443, 21);
            this.txtId.TabIndex = 3;
            // 
            // btnAccessPermission
            // 
            this.btnAccessPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAccessPermission.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnAccessPermission.Location = new System.Drawing.Point(12, 340);
            this.btnAccessPermission.Name = "btnAccessPermission";
            this.btnAccessPermission.Size = new System.Drawing.Size(134, 23);
            this.btnAccessPermission.TabIndex = 18;
            this.btnAccessPermission.Text = "访问权限(&P)...";
            this.btnAccessPermission.UseVisualStyleBackColor = true;
            this.btnAccessPermission.Click += new System.EventHandler(this.btnAccessPermission_Click);
            // 
            // grbModule
            // 
            this.grbModule.Location = new System.Drawing.Point(14, 15);
            this.grbModule.Name = "grbModule";
            this.grbModule.Size = new System.Drawing.Size(589, 310);
            this.grbModule.TabIndex = 22;
            this.grbModule.TabStop = false;
            this.grbModule.Text = "模块菜单";
            // 
            // FrmModuleEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(622, 381);
            this.Controls.Add(this.btnAccessPermission);
            this.Controls.Add(this.txtId);
            this.Controls.Add(this.lblId);
            this.Controls.Add(this.chkIsPublic);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.ucParent);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.lblCodeReq);
            this.Controls.Add(this.txtNavigateUrl);
            this.Controls.Add(this.lblNavigateUrl);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbModule);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModuleEdit";
            this.Text = "编辑菜单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNavigateUrl;
        private System.Windows.Forms.Label lblNavigateUrl;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblCodeReq;
        private DotNet.WinForm.UCModuleSelect ucParent;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button btnAccessPermission;
        private System.Windows.Forms.GroupBox grbModule;

    }
}