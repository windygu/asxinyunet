namespace DotNet.WinForm
{
    partial class FrmBusinessCardEdit
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
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.txtTitle = new System.Windows.Forms.TextBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.txtBankAccount = new System.Windows.Forms.TextBox();
            this.lblBankAccount = new System.Windows.Forms.Label();
            this.txtTaxAccount = new System.Windows.Forms.TextBox();
            this.lblTaxAccount = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBank = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtPostalcode = new System.Windows.Forms.TextBox();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.txtOfficePhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblOuterPhone = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtQQ = new System.Windows.Forms.TextBox();
            this.lblQQ = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblMail = new System.Windows.Forms.Label();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblCompany = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.chkPersonal = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(619, 372);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 35;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(541, 372);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 34;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = true;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(101, 135);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(592, 23);
            this.ucCompany.TabIndex = 9;
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(441, 69);
            this.txtTitle.MaxLength = 40;
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(252, 21);
            this.txtTitle.TabIndex = 3;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(356, 74);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(84, 12);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "职位：";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBankAccount
            // 
            this.txtBankAccount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtBankAccount.Location = new System.Drawing.Point(101, 310);
            this.txtBankAccount.MaxLength = 40;
            this.txtBankAccount.Name = "txtBankAccount";
            this.txtBankAccount.Size = new System.Drawing.Size(252, 21);
            this.txtBankAccount.TabIndex = 27;
            // 
            // lblBankAccount
            // 
            this.lblBankAccount.Location = new System.Drawing.Point(1, 316);
            this.lblBankAccount.Name = "lblBankAccount";
            this.lblBankAccount.Size = new System.Drawing.Size(96, 12);
            this.lblBankAccount.TabIndex = 26;
            this.lblBankAccount.Text = "帐号：";
            this.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTaxAccount
            // 
            this.txtTaxAccount.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtTaxAccount.Location = new System.Drawing.Point(101, 337);
            this.txtTaxAccount.MaxLength = 40;
            this.txtTaxAccount.Name = "txtTaxAccount";
            this.txtTaxAccount.Size = new System.Drawing.Size(252, 21);
            this.txtTaxAccount.TabIndex = 29;
            // 
            // lblTaxAccount
            // 
            this.lblTaxAccount.Location = new System.Drawing.Point(1, 342);
            this.lblTaxAccount.Name = "lblTaxAccount";
            this.lblTaxAccount.Size = new System.Drawing.Size(96, 12);
            this.lblTaxAccount.TabIndex = 28;
            this.lblTaxAccount.Text = "税号：";
            this.lblTaxAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBankName
            // 
            this.txtBankName.Location = new System.Drawing.Point(101, 283);
            this.txtBankName.MaxLength = 40;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(252, 21);
            this.txtBankName.TabIndex = 25;
            // 
            // lblBank
            // 
            this.lblBank.Location = new System.Drawing.Point(1, 288);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(96, 12);
            this.lblBank.TabIndex = 24;
            this.lblBank.Text = "开户行：";
            this.lblBank.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtAddress
            // 
            this.txtAddress.Location = new System.Drawing.Point(101, 163);
            this.txtAddress.MaxLength = 200;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(378, 21);
            this.txtAddress.TabIndex = 11;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(1, 167);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(96, 12);
            this.lblAddress.TabIndex = 10;
            this.lblAddress.Text = "地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeb
            // 
            this.txtWeb.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtWeb.Location = new System.Drawing.Point(441, 215);
            this.txtWeb.MaxLength = 40;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(252, 21);
            this.txtWeb.TabIndex = 21;
            // 
            // lblWeb
            // 
            this.lblWeb.Location = new System.Drawing.Point(360, 220);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(80, 12);
            this.lblWeb.TabIndex = 20;
            this.lblWeb.Text = "网址：";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPostalcode.Location = new System.Drawing.Point(565, 162);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(127, 21);
            this.txtPostalcode.TabIndex = 13;
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.Location = new System.Drawing.Point(485, 167);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(80, 12);
            this.lblPostalcode.TabIndex = 12;
            this.lblPostalcode.Text = "邮编：";
            this.lblPostalcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOfficePhone
            // 
            this.txtOfficePhone.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtOfficePhone.Location = new System.Drawing.Point(101, 189);
            this.txtOfficePhone.MaxLength = 40;
            this.txtOfficePhone.Name = "txtOfficePhone";
            this.txtOfficePhone.Size = new System.Drawing.Size(252, 21);
            this.txtOfficePhone.TabIndex = 15;
            // 
            // txtFax
            // 
            this.txtFax.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtFax.Location = new System.Drawing.Point(441, 190);
            this.txtFax.MaxLength = 40;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(252, 21);
            this.txtFax.TabIndex = 17;
            // 
            // lblOuterPhone
            // 
            this.lblOuterPhone.Location = new System.Drawing.Point(-1, 194);
            this.lblOuterPhone.Name = "lblOuterPhone";
            this.lblOuterPhone.Size = new System.Drawing.Size(98, 12);
            this.lblOuterPhone.TabIndex = 14;
            this.lblOuterPhone.Text = "办公电话：";
            this.lblOuterPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(358, 194);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(77, 12);
            this.lblFax.TabIndex = 16;
            this.lblFax.Text = "传真(&F):";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQQ
            // 
            this.txtQQ.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtQQ.Location = new System.Drawing.Point(441, 95);
            this.txtQQ.MaxLength = 40;
            this.txtQQ.Name = "txtQQ";
            this.txtQQ.Size = new System.Drawing.Size(252, 21);
            this.txtQQ.TabIndex = 7;
            // 
            // lblQQ
            // 
            this.lblQQ.Location = new System.Drawing.Point(388, 100);
            this.lblQQ.Name = "lblQQ";
            this.lblQQ.Size = new System.Drawing.Size(52, 12);
            this.lblQQ.TabIndex = 6;
            this.lblQQ.Text = "QQ：";
            this.lblQQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtMobile.Location = new System.Drawing.Point(101, 215);
            this.txtMobile.MaxLength = 40;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(252, 21);
            this.txtMobile.TabIndex = 19;
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(1, 221);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(96, 12);
            this.lblMobile.TabIndex = 18;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtEmail.Location = new System.Drawing.Point(101, 241);
            this.txtEmail.MaxLength = 50;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(592, 21);
            this.txtEmail.TabIndex = 23;
            // 
            // lblMail
            // 
            this.lblMail.Location = new System.Drawing.Point(1, 245);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(96, 12);
            this.lblMail.TabIndex = 22;
            this.lblMail.Text = "邮箱：";
            this.lblMail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPhone
            // 
            this.txtPhone.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.txtPhone.Location = new System.Drawing.Point(101, 94);
            this.txtPhone.MaxLength = 40;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(252, 21);
            this.txtPhone.TabIndex = 5;
            // 
            // lblPhone
            // 
            this.lblPhone.Location = new System.Drawing.Point(-1, 98);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(98, 12);
            this.lblPhone.TabIndex = 4;
            this.lblPhone.Text = "私人电话：";
            this.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompany
            // 
            this.lblCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCompany.Location = new System.Drawing.Point(5, 140);
            this.lblCompany.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompany.Name = "lblCompany";
            this.lblCompany.Size = new System.Drawing.Size(92, 12);
            this.lblCompany.TabIndex = 8;
            this.lblCompany.Text = "公司(&C)：";
            this.lblCompany.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(441, 283);
            this.txtDescription.MaxLength = 800;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(252, 77);
            this.txtDescription.TabIndex = 31;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(358, 287);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(82, 12);
            this.lblDescription.TabIndex = 30;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(355, 73);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 2;
            this.lblFullNameReq.Text = "*";
            // 
            // txtFullName
            // 
            this.txtFullName.Location = new System.Drawing.Point(101, 69);
            this.txtFullName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtFullName.MaxLength = 40;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(252, 21);
            this.txtFullName.TabIndex = 1;
            // 
            // lblFullName
            // 
            this.lblFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullName.Location = new System.Drawing.Point(5, 73);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(92, 12);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "名称(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkPersonal
            // 
            this.chkPersonal.AutoSize = true;
            this.chkPersonal.Location = new System.Drawing.Point(101, 375);
            this.chkPersonal.Name = "chkPersonal";
            this.chkPersonal.Size = new System.Drawing.Size(72, 16);
            this.chkPersonal.TabIndex = 32;
            this.chkPersonal.Text = "私人名片";
            this.chkPersonal.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.Location = new System.Drawing.Point(463, 372);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 23);
            this.btnPrint.TabIndex = 33;
            this.btnPrint.Text = "打印(&P)";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // FrmBusinessCardEdit
            // 
            this.BackgroundImage = global::DotNet.WinForm.Properties.Resources.Head;
            this.ClientSize = new System.Drawing.Size(722, 404);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkPersonal);
            this.Controls.Add(this.ucCompany);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtBankAccount);
            this.Controls.Add(this.lblBankAccount);
            this.Controls.Add(this.txtTaxAccount);
            this.Controls.Add(this.lblTaxAccount);
            this.Controls.Add(this.txtBankName);
            this.Controls.Add(this.lblBank);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtWeb);
            this.Controls.Add(this.lblWeb);
            this.Controls.Add(this.txtPostalcode);
            this.Controls.Add(this.lblPostalcode);
            this.Controls.Add(this.txtOfficePhone);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.lblOuterPhone);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtQQ);
            this.Controls.Add(this.lblQQ);
            this.Controls.Add(this.txtMobile);
            this.Controls.Add(this.lblMobile);
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.lblMail);
            this.Controls.Add(this.txtPhone);
            this.Controls.Add(this.lblPhone);
            this.Controls.Add(this.lblCompany);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmBusinessCardEdit";
            this.Text = "编辑名片";
            this.Load += new System.EventHandler(this.FrmBusinessCardEdit_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private DotNet.WinForm.UCOrganizeSelect ucCompany;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.TextBox txtBankAccount;
        private System.Windows.Forms.Label lblBankAccount;
        private System.Windows.Forms.TextBox txtTaxAccount;
        private System.Windows.Forms.Label lblTaxAccount;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.TextBox txtPostalcode;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.TextBox txtOfficePhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblOuterPhone;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtQQ;
        private System.Windows.Forms.Label lblQQ;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblCompany;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.CheckBox chkPersonal;
        private System.Windows.Forms.Button btnPrint;
    }
}