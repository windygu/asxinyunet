namespace DotNet.WinForm
{
    partial class FrmFolderEdit
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
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.ucFolder = new DotNet.WinForm.UCFolderSelect();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(340, 225);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(259, 225);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 8;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(120, 151);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(294, 59);
            this.txtDescription.TabIndex = 7;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(120, 126);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 5;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtFolderName
            // 
            this.txtFolderName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFolderName.Location = new System.Drawing.Point(120, 95);
            this.txtFolderName.MaxLength = 50;
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(294, 21);
            this.txtFolderName.TabIndex = 3;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(418, 100);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 4;
            this.lblFullNameReq.Text = "*";
            // 
            // ucFolder
            // 
            this.ucFolder.AllowNull = true;
            this.ucFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFolder.CheckMove = false;
            this.ucFolder.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucFolder.Location = new System.Drawing.Point(120, 65);
            this.ucFolder.Name = "ucFolder";
            this.ucFolder.SelectedFullName = "";
            this.ucFolder.SelectedId = "";
            this.ucFolder.Size = new System.Drawing.Size(294, 22);
            this.ucFolder.TabIndex = 1;
            // 
            // lblParent
            // 
            this.lblParent.Location = new System.Drawing.Point(11, 70);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(103, 12);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "父节点(&P)：";
            this.lblParent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(3, 153);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(111, 12);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(3, 99);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(111, 12);
            this.lblFullName.TabIndex = 2;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmFolderEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(447, 259);
            this.Controls.Add(this.lblParent);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.ucFolder);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtFolderName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFolderEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "编辑文件夹";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label lblFullNameReq;
        private UCFolderSelect ucFolder;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
    }
}