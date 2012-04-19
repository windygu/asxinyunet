namespace DotNet.WinForm
{
    partial class FrmException
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
            this.btnClose = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblSoftFullName = new System.Windows.Forms.Label();
            this.lblOccurTime = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.txtSoft = new System.Windows.Forms.TextBox();
            this.txtOccurTime = new System.Windows.Forms.TextBox();
            this.lblExceptionInfo = new System.Windows.Forms.Label();
            this.txtException = new System.Windows.Forms.TextBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.lblOperator = new System.Windows.Forms.Label();
            this.btnPrintScreen = new System.Windows.Forms.Button();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(596, 447);
            this.btnClose.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 23);
            this.btnClose.TabIndex = 13;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnReport
            // 
            this.btnReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReport.Location = new System.Drawing.Point(485, 447);
            this.btnReport.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(109, 23);
            this.btnReport.TabIndex = 12;
            this.btnReport.Text = "反馈错误(&R)";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.Location = new System.Drawing.Point(31, 14);
            this.lblCustomer.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(89, 12);
            this.lblCustomer.TabIndex = 0;
            this.lblCustomer.Text = "公司：";
            this.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblSoftFullName
            // 
            this.lblSoftFullName.Location = new System.Drawing.Point(365, 14);
            this.lblSoftFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSoftFullName.Name = "lblSoftFullName";
            this.lblSoftFullName.Size = new System.Drawing.Size(113, 12);
            this.lblSoftFullName.TabIndex = 2;
            this.lblSoftFullName.Text = "软件名称：";
            this.lblSoftFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOccurTime
            // 
            this.lblOccurTime.Location = new System.Drawing.Point(365, 43);
            this.lblOccurTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOccurTime.Name = "lblOccurTime";
            this.lblOccurTime.Size = new System.Drawing.Size(113, 12);
            this.lblOccurTime.TabIndex = 6;
            this.lblOccurTime.Text = "发生时间：";
            this.lblOccurTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(124, 10);
            this.txtCustomer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(162, 21);
            this.txtCustomer.TabIndex = 1;
            // 
            // txtSoft
            // 
            this.txtSoft.Location = new System.Drawing.Point(486, 10);
            this.txtSoft.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSoft.Name = "txtSoft";
            this.txtSoft.ReadOnly = true;
            this.txtSoft.Size = new System.Drawing.Size(182, 21);
            this.txtSoft.TabIndex = 3;
            // 
            // txtOccurTime
            // 
            this.txtOccurTime.Location = new System.Drawing.Point(486, 38);
            this.txtOccurTime.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOccurTime.Name = "txtOccurTime";
            this.txtOccurTime.ReadOnly = true;
            this.txtOccurTime.Size = new System.Drawing.Size(182, 21);
            this.txtOccurTime.TabIndex = 7;
            // 
            // lblExceptionInfo
            // 
            this.lblExceptionInfo.Location = new System.Drawing.Point(31, 74);
            this.lblExceptionInfo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblExceptionInfo.Name = "lblExceptionInfo";
            this.lblExceptionInfo.Size = new System.Drawing.Size(89, 12);
            this.lblExceptionInfo.TabIndex = 8;
            this.lblExceptionInfo.Text = "错误信息：";
            this.lblExceptionInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtException
            // 
            this.txtException.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtException.Location = new System.Drawing.Point(124, 69);
            this.txtException.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtException.Multiline = true;
            this.txtException.Name = "txtException";
            this.txtException.ReadOnly = true;
            this.txtException.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtException.Size = new System.Drawing.Size(544, 368);
            this.txtException.TabIndex = 9;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(124, 38);
            this.txtUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUser.Name = "txtUser";
            this.txtUser.ReadOnly = true;
            this.txtUser.Size = new System.Drawing.Size(162, 21);
            this.txtUser.TabIndex = 5;
            // 
            // lblOperator
            // 
            this.lblOperator.Location = new System.Drawing.Point(31, 43);
            this.lblOperator.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOperator.Name = "lblOperator";
            this.lblOperator.Size = new System.Drawing.Size(89, 12);
            this.lblOperator.TabIndex = 4;
            this.lblOperator.Text = "用户：";
            this.lblOperator.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnPrintScreen
            // 
            this.btnPrintScreen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrintScreen.Location = new System.Drawing.Point(285, 447);
            this.btnPrintScreen.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPrintScreen.Name = "btnPrintScreen";
            this.btnPrintScreen.Size = new System.Drawing.Size(109, 23);
            this.btnPrintScreen.TabIndex = 10;
            this.btnPrintScreen.Text = "屏幕打印 (&S)";
            this.btnPrintScreen.UseVisualStyleBackColor = true;
            this.btnPrintScreen.Visible = false;
            this.btnPrintScreen.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(396, 447);
            this.btnPrint.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(87, 23);
            this.btnPrint.TabIndex = 11;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmException
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(684, 478);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.btnPrintScreen);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.lblOperator);
            this.Controls.Add(this.txtException);
            this.Controls.Add(this.lblExceptionInfo);
            this.Controls.Add(this.txtOccurTime);
            this.Controls.Add(this.txtSoft);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.lblOccurTime);
            this.Controls.Add(this.lblSoftFullName);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReport);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MinimumSize = new System.Drawing.Size(346, 209);
            this.Name = "FrmException";
            this.Text = "系统异常情况记录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label lblCustomer;
        private System.Windows.Forms.Label lblSoftFullName;
        private System.Windows.Forms.Label lblOccurTime;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.TextBox txtSoft;
        private System.Windows.Forms.TextBox txtOccurTime;
        private System.Windows.Forms.Label lblExceptionInfo;
        private System.Windows.Forms.TextBox txtException;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.Label lblOperator;
        private System.Windows.Forms.Button btnPrintScreen;
        private System.Windows.Forms.Button btnPrint;
    }
}