namespace DotNet.WinForm
{
    partial class FrmFileEdit
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
            this.lblSelect = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblSelectReq = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.ucFolder = new DotNet.WinForm.UCFolderSelect();
            this.btnDownLoad = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSelect
            // 
            this.lblSelect.Location = new System.Drawing.Point(11, 69);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(113, 12);
            this.lblSelect.TabIndex = 0;
            this.lblSelect.Text = "选择文件夹(&T):";
            this.lblSelect.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(340, 206);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(259, 206);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(130, 130);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(285, 59);
            this.txtDescription.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(4, 133);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(120, 12);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "描述(&B):";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFullName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(130, 98);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtFullName";
            this.txtFileName.Size = new System.Drawing.Size(285, 21);
            this.txtFileName.TabIndex = 4;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(2, 101);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(122, 12);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "名称(&N):";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSelectReq
            // 
            this.lblSelectReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSelectReq.AutoSize = true;
            this.lblSelectReq.ForeColor = System.Drawing.Color.Red;
            this.lblSelectReq.Location = new System.Drawing.Point(420, 71);
            this.lblSelectReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSelectReq.Name = "lblSelectReq";
            this.lblSelectReq.Size = new System.Drawing.Size(11, 12);
            this.lblSelectReq.TabIndex = 2;
            this.lblSelectReq.Text = "*";
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(420, 103);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 5;
            this.lblFullNameReq.Text = "*";
            // 
            // ucFolder
            // 
            this.ucFolder.AllowNull = true;
            this.ucFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucFolder.CheckMove = false;
            this.ucFolder.Font = new System.Drawing.Font("SimSun", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucFolder.Location = new System.Drawing.Point(130, 65);
            this.ucFolder.Name = "ucFolder";
            this.ucFolder.SelectedFullName = "";
            this.ucFolder.SelectedId = "";
            this.ucFolder.Size = new System.Drawing.Size(285, 22);
            this.ucFolder.TabIndex = 1;
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDownLoad.Location = new System.Drawing.Point(26, 206);
            this.btnDownLoad.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.Size = new System.Drawing.Size(87, 23);
            this.btnDownLoad.TabIndex = 8;
            this.btnDownLoad.Text = "下载(&D)";
            this.btnDownLoad.UseVisualStyleBackColor = true;
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // FrmFileEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(443, 241);
            this.Controls.Add(this.btnDownLoad);
            this.Controls.Add(this.ucFolder);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.lblSelectReq);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblFullName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "编辑文件";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblSelectReq;
        private System.Windows.Forms.Label lblFullNameReq;

        private UCFolderSelect ucFolder;
        private System.Windows.Forms.Button btnDownLoad;
    }
}