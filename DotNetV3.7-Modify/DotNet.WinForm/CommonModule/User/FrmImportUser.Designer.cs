namespace DotNet.WinForm
{
    partial class FrmImportUser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmImportUser));
            this.btnClose = new System.Windows.Forms.Button();
            this.grbImport = new System.Windows.Forms.GroupBox();
            this.grbFile = new System.Windows.Forms.GroupBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.grpData = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.grbFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(619, 382);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grbImport
            // 
            this.grbImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbImport.Location = new System.Drawing.Point(10, 324);
            this.grbImport.Name = "grbImport";
            this.grbImport.Size = new System.Drawing.Size(684, 47);
            this.grbImport.TabIndex = 2;
            this.grbImport.TabStop = false;
            this.grbImport.Text = "导入进度";
            // 
            // grbFile
            // 
            this.grbFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbFile.Controls.Add(this.btnDownload);
            this.grbFile.Controls.Add(this.btnBrowse);
            this.grbFile.Controls.Add(this.txtFile);
            this.grbFile.Controls.Add(this.lblFile);
            this.grbFile.Location = new System.Drawing.Point(10, 10);
            this.grbFile.Name = "grbFile";
            this.grbFile.Size = new System.Drawing.Size(683, 57);
            this.grbFile.TabIndex = 0;
            this.grbFile.TabStop = false;
            this.grbFile.Text = "导入数据文件";
            // 
            // btnDownload
            // 
            this.btnDownload.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownload.Location = new System.Drawing.Point(583, 23);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(90, 23);
            this.btnDownload.TabIndex = 3;
            this.btnDownload.Text = "下载模板";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(503, 23);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "浏览...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtFile
            // 
            this.txtFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFile.BackColor = System.Drawing.SystemColors.Control;
            this.txtFile.Location = new System.Drawing.Point(72, 25);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(427, 21);
            this.txtFile.TabIndex = 1;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Location = new System.Drawing.Point(7, 29);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(65, 12);
            this.lblFile.TabIndex = 0;
            this.lblFile.Text = "导入文件：";
            // 
            // grpData
            // 
            this.grpData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpData.Location = new System.Drawing.Point(9, 73);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(684, 245);
            this.grpData.TabIndex = 1;
            this.grpData.TabStop = false;
            this.grpData.Text = "导入数据预览";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnImport.Location = new System.Drawing.Point(505, 382);
            this.btnImport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(111, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "导入数据(&I)";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // FrmImportUser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(703, 417);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.grpData);
            this.Controls.Add(this.grbImport);
            this.Controls.Add(this.grbFile);
            this.Controls.Add(this.btnClose);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmImportUser";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "导入用户数据";
            this.grbFile.ResumeLayout(false);
            this.grbFile.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox grbImport;
        private System.Windows.Forms.GroupBox grbFile;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.GroupBox grpData;
        private System.Windows.Forms.Button btnImport;
    }
}