namespace DotNet.WinForm
{
    partial class FrmMessageRemind
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
            this.lblContents = new System.Windows.Forms.Label();
            this.btnReply = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.lblFrom = new System.Windows.Forms.Label();
            this.webBMsg = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(5, 9);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(73, 12);
            this.lblContents.TabIndex = 3;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnReply
            // 
            this.btnReply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReply.Location = new System.Drawing.Point(178, 207);
            this.btnReply.Name = "btnReply";
            this.btnReply.Size = new System.Drawing.Size(75, 23);
            this.btnReply.TabIndex = 2;
            this.btnReply.Text = "回复(&S)";
            this.btnReply.Click += new System.EventHandler(this.btnReply_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(340, 207);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(259, 207);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "确定";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // lblFrom
            // 
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(102, 67);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(0, 12);
            this.lblFrom.TabIndex = 5;
            // 
            // webBMsg
            // 
            this.webBMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBMsg.Location = new System.Drawing.Point(7, 9);
            this.webBMsg.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBMsg.Name = "webBMsg";
            this.webBMsg.Size = new System.Drawing.Size(409, 192);
            this.webBMsg.TabIndex = 6;
            this.webBMsg.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBMsg_DocumentCompleted);
            // 
            // FrmMessageRemind
            // 
            this.AcceptButton = this.btnConfirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(423, 235);
            this.Controls.Add(this.webBMsg);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.btnReply);
            this.Controls.Add(this.btnCancel);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmMessageRemind";
            this.Text = "消息提醒";
            this.Load += new System.EventHandler(this.FrmMessageRemind_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.Button btnReply;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.WebBrowser webBMsg;
    }
}