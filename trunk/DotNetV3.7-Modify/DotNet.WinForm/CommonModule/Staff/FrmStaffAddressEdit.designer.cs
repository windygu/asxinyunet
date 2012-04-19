namespace DotNet.WinForm
{
    partial class FrmStaffAddressEdit
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStaffAddressEdit));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtOICQ = new System.Windows.Forms.TextBox();
            this.lblOICQ = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtOfficeTel = new System.Windows.Forms.TextBox();
            this.lblTEl = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblDep = new System.Windows.Forms.Label();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.lblDuty = new System.Windows.Forms.Label();
            this.txtCompany = new System.Windows.Forms.TextBox();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtDuty = new System.Windows.Forms.TextBox();
            this.txtShortNumber = new System.Windows.Forms.TextBox();
            this.lblShortNumber = new System.Windows.Forms.Label();
            this.ucPicture = new DotNet.WinForm.UCPicture();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(455, 337);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 22;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(376, 337);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 21;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(114, 273);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(408, 49);
            this.txtDescription.TabIndex = 19;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(6, 273);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(99, 12);
            this.lblDescription.TabIndex = 18;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOICQ
            // 
            this.txtOICQ.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOICQ.Location = new System.Drawing.Point(114, 245);
            this.txtOICQ.MaxLength = 20;
            this.txtOICQ.Name = "txtOICQ";
            this.txtOICQ.Size = new System.Drawing.Size(408, 21);
            this.txtOICQ.TabIndex = 17;
            // 
            // lblOICQ
            // 
            this.lblOICQ.Location = new System.Drawing.Point(6, 248);
            this.lblOICQ.Name = "lblOICQ";
            this.lblOICQ.Size = new System.Drawing.Size(99, 12);
            this.lblOICQ.TabIndex = 16;
            this.lblOICQ.Text = "QQ：";
            this.lblOICQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Location = new System.Drawing.Point(114, 161);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(219, 21);
            this.txtMobile.TabIndex = 11;
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(6, 164);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(99, 12);
            this.lblMobile.TabIndex = 10;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(114, 217);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(408, 21);
            this.txtEmail.TabIndex = 15;
            // 
            // lblMail
            // 
            this.lblMail.Location = new System.Drawing.Point(6, 220);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(99, 12);
            this.lblMail.TabIndex = 14;
            this.lblMail.Text = "电子邮箱：";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOfficeTel
            // 
            this.txtOfficeTel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOfficeTel.Location = new System.Drawing.Point(114, 133);
            this.txtOfficeTel.MaxLength = 20;
            this.txtOfficeTel.Name = "txtOfficeTel";
            this.txtOfficeTel.Size = new System.Drawing.Size(219, 21);
            this.txtOfficeTel.TabIndex = 9;
            // 
            // lblTEl
            // 
            this.lblTEl.Location = new System.Drawing.Point(6, 136);
            this.lblTEl.Name = "lblTEl";
            this.lblTEl.Size = new System.Drawing.Size(99, 12);
            this.lblTEl.TabIndex = 8;
            this.lblTEl.Text = "办公电话：";
            this.lblTEl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.CausesValidation = false;
            this.txtRealName.Location = new System.Drawing.Point(114, 21);
            this.txtRealName.MaxLength = 100;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.ReadOnly = true;
            this.txtRealName.Size = new System.Drawing.Size(219, 21);
            this.txtRealName.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(6, 24);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(99, 12);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "姓名：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblDep
            // 
            this.lblDep.Location = new System.Drawing.Point(6, 80);
            this.lblDep.Name = "lblDep";
            this.lblDep.Size = new System.Drawing.Size(99, 12);
            this.lblDep.TabIndex = 4;
            this.lblDep.Text = "部门：";
            this.lblDep.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDepartment
            // 
            this.txtDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDepartment.Location = new System.Drawing.Point(114, 77);
            this.txtDepartment.Name = "txtDepartment";
            this.txtDepartment.ReadOnly = true;
            this.txtDepartment.Size = new System.Drawing.Size(219, 21);
            this.txtDepartment.TabIndex = 5;
            // 
            // lblDuty
            // 
            this.lblDuty.Location = new System.Drawing.Point(6, 107);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(99, 12);
            this.lblDuty.TabIndex = 6;
            this.lblDuty.Text = "职位：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCompany
            // 
            this.txtCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCompany.Location = new System.Drawing.Point(114, 49);
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.ReadOnly = true;
            this.txtCompany.Size = new System.Drawing.Size(219, 21);
            this.txtCompany.TabIndex = 3;
            // 
            // lblCompany
            // 
            this.lblCompany.Location = new System.Drawing.Point(6, 52);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(99, 12);
            this.lblCompany.TabIndex = 2;
            this.lblCompany.Text = "公司：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDuty
            // 
            this.txtDuty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDuty.Location = new System.Drawing.Point(114, 104);
            this.txtDuty.Name = "txtDuty";
            this.txtDuty.ReadOnly = true;
            this.txtDuty.Size = new System.Drawing.Size(219, 21);
            this.txtDuty.TabIndex = 7;
            // 
            // txtShortNumber
            // 
            this.txtShortNumber.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtShortNumber.Location = new System.Drawing.Point(114, 188);
            this.txtShortNumber.MaxLength = 20;
            this.txtShortNumber.Name = "txtShortNumber";
            this.txtShortNumber.Size = new System.Drawing.Size(219, 21);
            this.txtShortNumber.TabIndex = 13;
            // 
            // lblShortNumber
            // 
            this.lblShortNumber.Location = new System.Drawing.Point(6, 191);
            this.lblShortNumber.Name = "lblShortNumber";
            this.lblShortNumber.Size = new System.Drawing.Size(99, 12);
            this.lblShortNumber.TabIndex = 12;
            this.lblShortNumber.Text = "短号：";
            this.lblShortNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucPicture
            // 
            this.ucPicture.AllowDrop = true;
            this.ucPicture.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ucPicture.PictureId = "";
            this.ucPicture.FolderId = "";
            this.ucPicture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPicture.Location = new System.Drawing.Point(341, 16);
            this.ucPicture.Name = "ucPicture";
            this.ucPicture.Size = new System.Drawing.Size(187, 195);
            this.ucPicture.TabIndex = 20;
            // 
            // FrmStaffAddressEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(542, 372);
            this.Controls.Add(this.ucPicture);
            this.Controls.Add(this.txtShortNumber);
            this.Controls.Add(this.lblShortNumber);
            this.Controls.Add(this.txtDuty);
            this.Controls.Add(this.txtCompany);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.lblDuty);
            this.Controls.Add(this.txtDepartment);
            this.Controls.Add(this.lblDep);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtOICQ);
            this.Controls.Add(this.lblOICQ);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtOfficeTel);
            this.Controls.Add(this.lblTEl);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.lblFullName);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStaffAddressEdit";
            this.Text = "编辑通讯录";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtOICQ;
        private System.Windows.Forms.Label lblOICQ;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtOfficeTel;
        private System.Windows.Forms.Label lblTEl;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblDep;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtDuty;
        private System.Windows.Forms.TextBox txtShortNumber;
        private System.Windows.Forms.Label lblShortNumber;
        private DotNet.WinForm.UCPicture ucPicture;

    }
}