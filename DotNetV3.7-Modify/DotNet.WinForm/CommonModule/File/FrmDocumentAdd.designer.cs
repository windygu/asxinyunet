namespace DotNet.WinForm
{
    partial class FrmDocumentAdd
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtContent = new System.Windows.Forms.TextBox();
            this.lblContent = new System.Windows.Forms.Label();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(548, 393);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(627, 393);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(469, 393);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 8;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(88, 307);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(613, 78);
            this.txtDescription.TabIndex = 6;
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblDescription.Location = new System.Drawing.Point(2, 310);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(80, 12);
            this.lblDescription.TabIndex = 5;
            this.lblDescription.Text = "描述(&D):";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(704, 17);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 2;
            this.lblFullNameReq.Text = "*";
            // 
            // txtTitle
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Location = new System.Drawing.Point(88, 13);
            this.txtFileName.MaxLength = 50;
            this.txtFileName.Name = "txtTitle";
            this.txtFileName.Size = new System.Drawing.Size(613, 21);
            this.txtFileName.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(2, 16);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(80, 12);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "标题(&T):";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtContent
            // 
            this.txtContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtContent.Location = new System.Drawing.Point(88, 41);
            this.txtContent.MaxLength = 800;
            this.txtContent.Multiline = true;
            this.txtContent.Name = "txtContent";
            this.txtContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtContent.Size = new System.Drawing.Size(613, 259);
            this.txtContent.TabIndex = 4;
            // 
            // lblContent
            // 
            this.lblContent.Location = new System.Drawing.Point(2, 44);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(80, 12);
            this.lblContent.TabIndex = 3;
            this.lblContent.Text = "内容(&C):";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbEnabled
            // 
            this.chbEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Location = new System.Drawing.Point(88, 395);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(48, 16);
            this.chbEnabled.TabIndex = 7;
            this.chbEnabled.Text = "有效";
            // 
            // FrmDocumentAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(726, 423);
            this.Controls.Add(this.chbEnabled);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmDocumentAdd";
            this.Text = "添加文本文档";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtContent;
        private System.Windows.Forms.Label lblContent;
        private System.Windows.Forms.CheckBox chbEnabled;
    }
}