namespace DotNet.WinForm
{
    partial class FrmRequestAnAccount
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
            this.grpRequestAnAccount = new System.Windows.Forms.GroupBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.lblTelephone = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblConfirmPasswordReq = new System.Windows.Forms.Label();
            this.lblPasswordReq = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobilePhone = new System.Windows.Forms.Label();
            this.ucWorkgroup = new DotNet.WinForm.UCOrganizeSelect();
            this.lblWorkgroup = new System.Windows.Forms.Label();
            this.ucDepartment = new DotNet.WinForm.UCOrganizeSelect();
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblE_mail = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblUserName = new System.Windows.Forms.Label();
            this.btnRequestAnAccount = new System.Windows.Forms.Button();
            this.chkClose = new System.Windows.Forms.CheckBox();
            this.rbtnUserInput = new System.Windows.Forms.RadioButton();
            this.rbtnDefaultPassword = new System.Windows.Forms.RadioButton();
            this.rbtnUserNamePassword = new System.Windows.Forms.RadioButton();
            this.grpRequestAnAccount.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(359, 495);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpRequestAnAccount
            // 
            this.grpRequestAnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRequestAnAccount.Controls.Add(this.cmbGender);
            this.grpRequestAnAccount.Controls.Add(this.lblGender);
            this.grpRequestAnAccount.Controls.Add(this.txtTelephone);
            this.grpRequestAnAccount.Controls.Add(this.lblTelephone);
            this.grpRequestAnAccount.Controls.Add(this.txtCode);
            this.grpRequestAnAccount.Controls.Add(this.lblCode);
            this.grpRequestAnAccount.Controls.Add(this.lblConfirmPasswordReq);
            this.grpRequestAnAccount.Controls.Add(this.lblPasswordReq);
            this.grpRequestAnAccount.Controls.Add(this.txtMobile);
            this.grpRequestAnAccount.Controls.Add(this.lblMobilePhone);
            this.grpRequestAnAccount.Controls.Add(this.ucWorkgroup);
            this.grpRequestAnAccount.Controls.Add(this.lblWorkgroup);
            this.grpRequestAnAccount.Controls.Add(this.ucDepartment);
            this.grpRequestAnAccount.Controls.Add(this.ucCompany);
            this.grpRequestAnAccount.Controls.Add(this.txtEmail);
            this.grpRequestAnAccount.Controls.Add(this.lblE_mail);
            this.grpRequestAnAccount.Controls.Add(this.label4);
            this.grpRequestAnAccount.Controls.Add(this.txtDescription);
            this.grpRequestAnAccount.Controls.Add(this.lblDescription);
            this.grpRequestAnAccount.Controls.Add(this.label1);
            this.grpRequestAnAccount.Controls.Add(this.lblUserNameReq);
            this.grpRequestAnAccount.Controls.Add(this.lblDepartment);
            this.grpRequestAnAccount.Controls.Add(this.lblCompanyName);
            this.grpRequestAnAccount.Controls.Add(this.txtConfirmPassword);
            this.grpRequestAnAccount.Controls.Add(this.lblConfirmPassword);
            this.grpRequestAnAccount.Controls.Add(this.txtPassword);
            this.grpRequestAnAccount.Controls.Add(this.lblPassword);
            this.grpRequestAnAccount.Controls.Add(this.cmbRole);
            this.grpRequestAnAccount.Controls.Add(this.lblRole);
            this.grpRequestAnAccount.Controls.Add(this.txtRealName);
            this.grpRequestAnAccount.Controls.Add(this.chkEnabled);
            this.grpRequestAnAccount.Controls.Add(this.txtUserName);
            this.grpRequestAnAccount.Controls.Add(this.lblFullName);
            this.grpRequestAnAccount.Controls.Add(this.lblUserName);
            this.grpRequestAnAccount.Location = new System.Drawing.Point(10, 31);
            this.grpRequestAnAccount.Name = "grpRequestAnAccount";
            this.grpRequestAnAccount.Size = new System.Drawing.Size(435, 458);
            this.grpRequestAnAccount.TabIndex = 1;
            this.grpRequestAnAccount.TabStop = false;
            this.grpRequestAnAccount.Text = "用户";
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(135, 74);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(269, 20);
            this.cmbGender.TabIndex = 7;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(75, 78);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(59, 12);
            this.lblGender.TabIndex = 6;
            this.lblGender.Text = "性别(&G)：";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTelephone.Location = new System.Drawing.Point(135, 185);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtTelephone.MaxLength = 50;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(269, 21);
            this.txtTelephone.TabIndex = 15;
            // 
            // lblTelephone
            // 
            this.lblTelephone.Location = new System.Drawing.Point(10, 188);
            this.lblTelephone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTelephone.Name = "lblTelephone";
            this.lblTelephone.Size = new System.Drawing.Size(124, 12);
            this.lblTelephone.TabIndex = 14;
            this.lblTelephone.Text = "电话(&T)：";
            this.lblTelephone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(135, 101);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(269, 21);
            this.txtCode.TabIndex = 9;
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(10, 105);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(124, 12);
            this.lblCode.TabIndex = 8;
            this.lblCode.Text = "工号(编号)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblConfirmPasswordReq
            // 
            this.lblConfirmPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConfirmPasswordReq.AutoSize = true;
            this.lblConfirmPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblConfirmPasswordReq.Location = new System.Drawing.Point(413, 271);
            this.lblConfirmPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConfirmPasswordReq.Name = "lblConfirmPasswordReq";
            this.lblConfirmPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblConfirmPasswordReq.TabIndex = 23;
            this.lblConfirmPasswordReq.Text = "*";
            // 
            // lblPasswordReq
            // 
            this.lblPasswordReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPasswordReq.AutoSize = true;
            this.lblPasswordReq.ForeColor = System.Drawing.Color.Red;
            this.lblPasswordReq.Location = new System.Drawing.Point(413, 244);
            this.lblPasswordReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPasswordReq.Name = "lblPasswordReq";
            this.lblPasswordReq.Size = new System.Drawing.Size(11, 12);
            this.lblPasswordReq.TabIndex = 20;
            this.lblPasswordReq.Text = "*";
            // 
            // txtMobile
            // 
            this.txtMobile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMobile.Location = new System.Drawing.Point(135, 131);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMobile.MaxLength = 50;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(269, 21);
            this.txtMobile.TabIndex = 11;
            // 
            // lblMobilePhone
            // 
            this.lblMobilePhone.Location = new System.Drawing.Point(10, 134);
            this.lblMobilePhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMobilePhone.Name = "lblMobilePhone";
            this.lblMobilePhone.Size = new System.Drawing.Size(124, 12);
            this.lblMobilePhone.TabIndex = 10;
            this.lblMobilePhone.Text = "手机(&M)：";
            this.lblMobilePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucWorkgroup
            // 
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWorkgroup.AutoSize = true;
            this.ucWorkgroup.CanEdit = false;
            this.ucWorkgroup.CheckMove = false;
            this.ucWorkgroup.Location = new System.Drawing.Point(135, 354);
            this.ucWorkgroup.MultiSelect = false;
            this.ucWorkgroup.Name = "ucWorkgroup";
            this.ucWorkgroup.OpenId = "";
            this.ucWorkgroup.PermissionItemScopeCode = "";
            this.ucWorkgroup.SelectedFullName = "";
            this.ucWorkgroup.SelectedId = "";
            this.ucWorkgroup.Size = new System.Drawing.Size(269, 23);
            this.ucWorkgroup.TabIndex = 30;
            // 
            // lblWorkgroup
            // 
            this.lblWorkgroup.Location = new System.Drawing.Point(10, 358);
            this.lblWorkgroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkgroup.Name = "lblWorkgroup";
            this.lblWorkgroup.Size = new System.Drawing.Size(124, 12);
            this.lblWorkgroup.TabIndex = 29;
            this.lblWorkgroup.Text = "所在工作组：";
            this.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucDepartment
            // 
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucDepartment.AutoSize = true;
            this.ucDepartment.CanEdit = false;
            this.ucDepartment.CheckMove = false;
            this.ucDepartment.Location = new System.Drawing.Point(135, 325);
            this.ucDepartment.MultiSelect = false;
            this.ucDepartment.Name = "ucDepartment";
            this.ucDepartment.OpenId = "";
            this.ucDepartment.PermissionItemScopeCode = "";
            this.ucDepartment.SelectedFullName = "";
            this.ucDepartment.SelectedId = "";
            this.ucDepartment.Size = new System.Drawing.Size(269, 23);
            this.ucDepartment.TabIndex = 28;
            this.ucDepartment.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetDepartment);
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = false;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(135, 295);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(269, 23);
            this.ucCompany.TabIndex = 25;
            this.ucCompany.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetCompany);
            // 
            // txtEmail
            // 
            this.txtEmail.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmail.Location = new System.Drawing.Point(135, 158);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(269, 21);
            this.txtEmail.TabIndex = 13;
            // 
            // lblE_mail
            // 
            this.lblE_mail.Location = new System.Drawing.Point(10, 161);
            this.lblE_mail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblE_mail.Name = "lblE_mail";
            this.lblE_mail.Size = new System.Drawing.Size(124, 12);
            this.lblE_mail.TabIndex = 12;
            this.lblE_mail.Text = "E_mail(&E)：";
            this.lblE_mail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(413, 302);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(11, 12);
            this.label4.TabIndex = 26;
            this.label4.Text = "*";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(135, 406);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(269, 40);
            this.txtDescription.TabIndex = 33;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(10, 406);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(124, 12);
            this.lblDescription.TabIndex = 32;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(413, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "*";
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(413, 24);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblUserNameReq.TabIndex = 2;
            this.lblUserNameReq.Text = "*";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(10, 329);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(124, 12);
            this.lblDepartment.TabIndex = 27;
            this.lblDepartment.Text = "所在部门：";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(10, 299);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(124, 12);
            this.lblCompanyName.TabIndex = 24;
            this.lblCompanyName.Text = "所在单位：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtConfirmPassword.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtConfirmPassword.Location = new System.Drawing.Point(135, 267);
            this.txtConfirmPassword.MaxLength = 32;
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '*';
            this.txtConfirmPassword.Size = new System.Drawing.Size(269, 21);
            this.txtConfirmPassword.TabIndex = 22;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.Location = new System.Drawing.Point(10, 270);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(124, 12);
            this.lblConfirmPassword.TabIndex = 21;
            this.lblConfirmPassword.Text = "确认密码(&C)：";
            this.lblConfirmPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtPassword.Location = new System.Drawing.Point(135, 239);
            this.txtPassword.MaxLength = 32;
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(269, 21);
            this.txtPassword.TabIndex = 19;
            // 
            // lblPassword
            // 
            this.lblPassword.Location = new System.Drawing.Point(10, 244);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(124, 12);
            this.lblPassword.TabIndex = 18;
            this.lblPassword.Text = "密码(&P)：";
            this.lblPassword.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(135, 212);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(269, 20);
            this.cmbRole.TabIndex = 17;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(10, 215);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(124, 12);
            this.lblRole.TabIndex = 16;
            this.lblRole.Text = "默认角色(&R)：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtRealName.Location = new System.Drawing.Point(135, 47);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(269, 21);
            this.txtRealName.TabIndex = 4;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(135, 386);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 31;
            this.chkEnabled.Text = "有效";
            // 
            // txtUserName
            // 
            this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUserName.BackColor = System.Drawing.Color.LemonChiffon;
            this.txtUserName.Location = new System.Drawing.Point(135, 19);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(269, 21);
            this.txtUserName.TabIndex = 1;
            this.txtUserName.Leave += new System.EventHandler(this.txtUserName_Leave);
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(10, 51);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(124, 12);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "姓名(&F)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(10, 24);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(124, 12);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "登录用户名(&U)：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnRequestAnAccount
            // 
            this.btnRequestAnAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRequestAnAccount.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnRequestAnAccount.Location = new System.Drawing.Point(240, 495);
            this.btnRequestAnAccount.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnRequestAnAccount.Name = "btnRequestAnAccount";
            this.btnRequestAnAccount.Size = new System.Drawing.Size(116, 23);
            this.btnRequestAnAccount.TabIndex = 2;
            this.btnRequestAnAccount.Text = "申请用户(&S)";
            this.btnRequestAnAccount.Click += new System.EventHandler(this.btnRequestAnAccount_Click);
            // 
            // chkClose
            // 
            this.chkClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkClose.AutoSize = true;
            this.chkClose.Checked = true;
            this.chkClose.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkClose.Enabled = false;
            this.chkClose.Location = new System.Drawing.Point(10, 499);
            this.chkClose.Name = "chkClose";
            this.chkClose.Size = new System.Drawing.Size(132, 16);
            this.chkClose.TabIndex = 4;
            this.chkClose.Text = "申请成功后关闭窗体";
            // 
            // rbtnUserInput
            // 
            this.rbtnUserInput.AutoSize = true;
            this.rbtnUserInput.Checked = true;
            this.rbtnUserInput.Location = new System.Drawing.Point(128, 9);
            this.rbtnUserInput.Name = "rbtnUserInput";
            this.rbtnUserInput.Size = new System.Drawing.Size(71, 16);
            this.rbtnUserInput.TabIndex = 5;
            this.rbtnUserInput.TabStop = true;
            this.rbtnUserInput.Text = "用户输入";
            this.rbtnUserInput.UseVisualStyleBackColor = true;
            this.rbtnUserInput.CheckedChanged += new System.EventHandler(this.rbtnUserInput_CheckedChanged);
            // 
            // rbtnDefaultPassword
            // 
            this.rbtnDefaultPassword.AutoSize = true;
            this.rbtnDefaultPassword.Location = new System.Drawing.Point(213, 9);
            this.rbtnDefaultPassword.Name = "rbtnDefaultPassword";
            this.rbtnDefaultPassword.Size = new System.Drawing.Size(95, 16);
            this.rbtnDefaultPassword.TabIndex = 6;
            this.rbtnDefaultPassword.Text = "系统默认密码";
            this.rbtnDefaultPassword.UseVisualStyleBackColor = true;
            this.rbtnDefaultPassword.CheckedChanged += new System.EventHandler(this.rbtnDefaultPassword_CheckedChanged);
            // 
            // rbtnUserNamePassword
            // 
            this.rbtnUserNamePassword.AutoSize = true;
            this.rbtnUserNamePassword.Location = new System.Drawing.Point(322, 9);
            this.rbtnUserNamePassword.Name = "rbtnUserNamePassword";
            this.rbtnUserNamePassword.Size = new System.Drawing.Size(119, 16);
            this.rbtnUserNamePassword.TabIndex = 7;
            this.rbtnUserNamePassword.Text = "用户名与密码相同";
            this.rbtnUserNamePassword.UseVisualStyleBackColor = true;
            this.rbtnUserNamePassword.CheckedChanged += new System.EventHandler(this.rbtnUserNamePassword_CheckedChanged);
            // 
            // FrmRequestAnAccount
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(457, 522);
            this.Controls.Add(this.rbtnUserNamePassword);
            this.Controls.Add(this.rbtnDefaultPassword);
            this.Controls.Add(this.rbtnUserInput);
            this.Controls.Add(this.chkClose);
            this.Controls.Add(this.btnRequestAnAccount);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpRequestAnAccount);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.HelpButton = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmRequestAnAccount";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "申请用户";
            this.grpRequestAnAccount.ResumeLayout(false);
            this.grpRequestAnAccount.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox grpRequestAnAccount;
        private System.Windows.Forms.Button btnRequestAnAccount;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblE_mail;
        private System.Windows.Forms.Label label4;
        private DotNet.WinForm.UCOrganizeSelect ucDepartment;
        private DotNet.WinForm.UCOrganizeSelect ucCompany;
        private System.Windows.Forms.Label lblWorkgroup;
        private DotNet.WinForm.UCOrganizeSelect ucWorkgroup;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobilePhone;
        private System.Windows.Forms.Label lblConfirmPasswordReq;
        private System.Windows.Forms.Label lblPasswordReq;
        private System.Windows.Forms.CheckBox chkClose;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtTelephone;
        private System.Windows.Forms.Label lblTelephone;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.RadioButton rbtnUserInput;
        private System.Windows.Forms.RadioButton rbtnDefaultPassword;
        private System.Windows.Forms.RadioButton rbtnUserNamePassword;
    }
}