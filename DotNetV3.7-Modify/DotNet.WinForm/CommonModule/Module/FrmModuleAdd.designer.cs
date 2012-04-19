namespace DotNet.WinForm
{
    partial class FrmModuleAdd
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
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblParent = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.chkIsPublic = new System.Windows.Forms.CheckBox();
            this.txtTarget = new System.Windows.Forms.TextBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.txtNavigateUrl = new System.Windows.Forms.TextBox();
            this.lblNavigateUrl = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.ucParent = new DotNet.WinForm.UCModuleSelect();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grbModule = new System.Windows.Forms.GroupBox();
            this.SuspendLayout();
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(139, 196);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 11;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            this.chkEnabled.CheckedChanged += new System.EventHandler(this.chkEnabled_CheckedChanged);
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(22, 33);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(112, 12);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "父模块(&P)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(139, 227);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(427, 60);
            this.txtDescription.TabIndex = 14;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(139, 64);
            this.txtFullName.MaxLength = 50;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(424, 21);
            this.txtFullName.TabIndex = 3;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(139, 95);
            this.txtCode.MaxLength = 100;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(424, 21);
            this.txtCode.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(22, 227);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(112, 12);
            this.lblDescription.TabIndex = 13;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(22, 67);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(112, 12);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(22, 98);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(112, 12);
            this.lblCode.TabIndex = 5;
            this.lblCode.Text = "编号(&O)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkIsPublic
            // 
            this.chkIsPublic.AutoSize = true;
            this.chkIsPublic.Location = new System.Drawing.Point(218, 196);
            this.chkIsPublic.Name = "chkIsPublic";
            this.chkIsPublic.Size = new System.Drawing.Size(48, 16);
            this.chkIsPublic.TabIndex = 12;
            this.chkIsPublic.Text = "公开";
            this.chkIsPublic.UseVisualStyleBackColor = true;
            // 
            // txtTarget
            // 
            this.txtTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarget.Location = new System.Drawing.Point(139, 158);
            this.txtTarget.MaxLength = 100;
            this.txtTarget.Name = "txtTarget";
            this.txtTarget.Size = new System.Drawing.Size(424, 21);
            this.txtTarget.TabIndex = 10;
            this.txtTarget.Text = "fraContent";
            // 
            // lblTarget
            // 
            this.lblTarget.Location = new System.Drawing.Point(22, 161);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(112, 12);
            this.lblTarget.TabIndex = 9;
            this.lblTarget.Text = "目标(&T)：";
            this.lblTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtNavigateUrl
            // 
            this.txtNavigateUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNavigateUrl.Location = new System.Drawing.Point(139, 127);
            this.txtNavigateUrl.MaxLength = 200;
            this.txtNavigateUrl.Name = "txtNavigateUrl";
            this.txtNavigateUrl.Size = new System.Drawing.Size(424, 21);
            this.txtNavigateUrl.TabIndex = 8;
            // 
            // lblNavigateUrl
            // 
            this.lblNavigateUrl.Location = new System.Drawing.Point(22, 130);
            this.lblNavigateUrl.Name = "lblNavigateUrl";
            this.lblNavigateUrl.Size = new System.Drawing.Size(112, 12);
            this.lblNavigateUrl.TabIndex = 7;
            this.lblNavigateUrl.Text = "Web网址：";
            this.lblNavigateUrl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(566, 67);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 4;
            this.lblFullNameReq.Text = "*";
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.AllowSelect = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.CheckMove = false;
            this.ucParent.Location = new System.Drawing.Point(140, 30);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.SelectedCode = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.Size = new System.Drawing.Size(423, 22);
            this.ucParent.TabIndex = 1;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(435, 316);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 19;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(514, 316);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 20;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(356, 316);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grbModule
            // 
            this.grbModule.Location = new System.Drawing.Point(17, 11);
            this.grbModule.Name = "grbModule";
            this.grbModule.Size = new System.Drawing.Size(573, 292);
            this.grbModule.TabIndex = 21;
            this.grbModule.TabStop = false;
            this.grbModule.Text = "模块菜单";
            // 
            // FrmModuleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(607, 352);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.ucParent);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.txtNavigateUrl);
            this.Controls.Add(this.lblNavigateUrl);
            this.Controls.Add(this.txtTarget);
            this.Controls.Add(this.lblTarget);
            this.Controls.Add(this.chkIsPublic);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.grbModule);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmModuleAdd";
            this.Text = "添加菜单";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.CheckBox chkIsPublic;
        private System.Windows.Forms.TextBox txtTarget;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.TextBox txtNavigateUrl;
        private System.Windows.Forms.Label lblNavigateUrl;
        private System.Windows.Forms.Label lblFullNameReq;
        private DotNet.WinForm.UCModuleSelect ucParent;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.GroupBox grbModule;
    }
}