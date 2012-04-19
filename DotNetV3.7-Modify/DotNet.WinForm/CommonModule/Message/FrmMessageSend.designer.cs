namespace DotNet.WinForm
{
    partial class FrmMessageSend
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
            this.lblSendTo = new System.Windows.Forms.Label();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContents = new System.Windows.Forms.Label();
            this.lblStaffReq = new System.Windows.Forms.Label();
            this.ucUser = new DotNet.WinForm.UCUserSelect();
            this.lblContentReq = new System.Windows.Forms.Label();
            this.btnMsgFont = new System.Windows.Forms.Button();
            this.btnColor = new System.Windows.Forms.Button();
            this.colorDialogMsg = new System.Windows.Forms.ColorDialog();
            this.fontDialogMsg = new System.Windows.Forms.FontDialog();
            this.btnSelectFack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblSendTo
            // 
            this.lblSendTo.Location = new System.Drawing.Point(3, 18);
            this.lblSendTo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSendTo.Name = "lblSendTo";
            this.lblSendTo.Size = new System.Drawing.Size(90, 12);
            this.lblSendTo.TabIndex = 0;
            this.lblSendTo.Text = "发送给(&T)：";
            this.lblSendTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSend
            // 
            this.btnSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(403, 211);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送(&S)";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(484, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtContent
            // 
            this.txtContent.AllowDrop = true;
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(99, 49);
            this.txtContent.MaxLength = 800;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(460, 156);
            this.txtContent.TabIndex = 4;
            this.txtContent.TextChanged += new System.EventHandler(this.txtContent_TextChanged);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(3, 51);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(90, 12);
            this.lblContents.TabIndex = 3;
            this.lblContents.Text = "内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblStaffReq
            // 
            this.lblStaffReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblStaffReq.AutoSize = true;
            this.lblStaffReq.ForeColor = System.Drawing.Color.Red;
            this.lblStaffReq.Location = new System.Drawing.Point(401, 19);
            this.lblStaffReq.Name = "lblStaffReq";
            this.lblStaffReq.Size = new System.Drawing.Size(11, 12);
            this.lblStaffReq.TabIndex = 2;
            this.lblStaffReq.Text = "*";
            // 
            // ucUser
            // 
            this.ucUser.AllowNull = true;
            this.ucUser.AllowSelect = true;
            this.ucUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucUser.Location = new System.Drawing.Point(99, 15);
            this.ucUser.MultiSelect = false;
            this.ucUser.Name = "ucUser";
            this.ucUser.OpenId = "";
            this.ucUser.PermissionItemScopeCode = "";
            this.ucUser.RemoveIds = null;
            this.ucUser.SelectedFullName = "";
            this.ucUser.SelectedId = "";
            this.ucUser.SelectedIds = null;
            this.ucUser.SetSelectIds = null;
            this.ucUser.Size = new System.Drawing.Size(296, 22);
            this.ucUser.TabIndex = 1;
            this.ucUser.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetUser);
            // 
            // lblContentReq
            // 
            this.lblContentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContentReq.AutoSize = true;
            this.lblContentReq.ForeColor = System.Drawing.Color.Red;
            this.lblContentReq.Location = new System.Drawing.Point(562, 51);
            this.lblContentReq.Name = "lblContentReq";
            this.lblContentReq.Size = new System.Drawing.Size(11, 12);
            this.lblContentReq.TabIndex = 7;
            this.lblContentReq.Text = "*";
            // 
            // btnMsgFont
            // 
            this.btnMsgFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMsgFont.Location = new System.Drawing.Point(458, 14);
            this.btnMsgFont.Name = "btnMsgFont";
            this.btnMsgFont.Size = new System.Drawing.Size(48, 23);
            this.btnMsgFont.TabIndex = 11;
            this.btnMsgFont.Text = "字体";
            this.btnMsgFont.UseVisualStyleBackColor = true;
            this.btnMsgFont.Click += new System.EventHandler(this.btnMsgFont_Click);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Location = new System.Drawing.Point(512, 14);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(47, 23);
            this.btnColor.TabIndex = 10;
            this.btnColor.Text = "颜色";
            this.btnColor.UseVisualStyleBackColor = true;
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // btnSelectFack
            // 
            this.btnSelectFack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectFack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSelectFack.Image = global::DotNet.WinForm.Properties.Resources.Face_0;
            this.btnSelectFack.Location = new System.Drawing.Point(418, 9);
            this.btnSelectFack.Name = "btnSelectFack";
            this.btnSelectFack.Size = new System.Drawing.Size(34, 34);
            this.btnSelectFack.TabIndex = 13;
            this.btnSelectFack.UseVisualStyleBackColor = true;
            this.btnSelectFack.Visible = false;
            this.btnSelectFack.Click += new System.EventHandler(this.btnSelectFack_Click);
            // 
            // FrmMessageSend
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(571, 237);
            this.Controls.Add(this.btnSelectFack);
            this.Controls.Add(this.btnMsgFont);
            this.Controls.Add(this.btnColor);
            this.Controls.Add(this.lblContentReq);
            this.Controls.Add(this.ucUser);
            this.Controls.Add(this.lblStaffReq);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lblSendTo);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmMessageSend";
            this.Text = "发送信息";
            this.Load += new System.EventHandler(this.FrmMessageSend_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.FrmMessageSend_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.FrmMessageSend_DragOver);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSendTo;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.Label lblStaffReq;
        private DotNet.WinForm.UCUserSelect ucUser;
        private System.Windows.Forms.Label lblContentReq;
        private System.Windows.Forms.Button btnMsgFont;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.ColorDialog colorDialogMsg;
        private System.Windows.Forms.FontDialog fontDialogMsg;
        private System.Windows.Forms.Button btnSelectFack;
    }
}