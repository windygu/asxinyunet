namespace DotNet.WCFHost
{
    partial class FormWCFHost
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormWCFHost));
            this.txtWCFHost = new System.Windows.Forms.TextBox();
            this.lbInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtWCFHost
            // 
            this.txtWCFHost.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtWCFHost.Location = new System.Drawing.Point(0, 0);
            this.txtWCFHost.Multiline = true;
            this.txtWCFHost.Name = "txtWCFHost";
            this.txtWCFHost.ReadOnly = true;
            this.txtWCFHost.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtWCFHost.Size = new System.Drawing.Size(494, 312);
            this.txtWCFHost.TabIndex = 0;
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lbInformation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lbInformation.Location = new System.Drawing.Point(0, 314);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(274, 12);
            this.lbInformation.TabIndex = 1;
            this.lbInformation.Text = "WCF Client link to WCF Host。。。Please don\'t close it.";
            // 
            // FormWCFHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 326);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.txtWCFHost);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormWCFHost";
            this.Text = "WCF Host Service";
            this.Activated += new System.EventHandler(this.FormWCFHost_Activated);
            this.Load += new System.EventHandler(this.FormWCFHost_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtWCFHost;
        private System.Windows.Forms.Label lbInformation;
    }
}

