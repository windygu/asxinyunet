namespace DotNet.WinForm
{
    partial class FrmStaffEdit
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
            this.btnUserPermission = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.grpStaffAdd = new System.Windows.Forms.GroupBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTitle = new System.Windows.Forms.ComboBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.cmbDuty = new System.Windows.Forms.ComboBox();
            this.lblDuty = new System.Windows.Forms.Label();
            this.txtCarCode = new System.Windows.Forms.TextBox();
            this.lblCarCode = new System.Windows.Forms.Label();
            this.txtEmergencyContact = new System.Windows.Forms.TextBox();
            this.lblEmergencyContact = new System.Windows.Forms.Label();
            this.txtHomeAddress = new System.Windows.Forms.TextBox();
            this.lblHomeAddress = new System.Windows.Forms.Label();
            this.txtHomePhone = new System.Windows.Forms.TextBox();
            this.lblHomePhone = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtMajor = new System.Windows.Forms.TextBox();
            this.lblMajor = new System.Windows.Forms.Label();
            this.cmbDegree = new System.Windows.Forms.ComboBox();
            this.lblDegree = new System.Windows.Forms.Label();
            this.cmbEducation = new System.Windows.Forms.ComboBox();
            this.lblEducation = new System.Windows.Forms.Label();
            this.txtSchool = new System.Windows.Forms.TextBox();
            this.lblSchool = new System.Windows.Forms.Label();
            this.txtShortNumber = new System.Windows.Forms.TextBox();
            this.lblShortNumber = new System.Windows.Forms.Label();
            this.txtIdCard = new System.Windows.Forms.TextBox();
            this.lblIdCard = new System.Windows.Forms.Label();
            this.cmbParty = new System.Windows.Forms.ComboBox();
            this.lblParty = new System.Windows.Forms.Label();
            this.cmbWorkingProperty = new System.Windows.Forms.ComboBox();
            this.lblWorkingProperty = new System.Windows.Forms.Label();
            this.dtpJoinInDate = new System.Windows.Forms.DateTimePicker();
            this.lblJoinInDate = new System.Windows.Forms.Label();
            this.txtOfficePhone = new System.Windows.Forms.TextBox();
            this.lblOfficePhone = new System.Windows.Forms.Label();
            this.txtBankCode = new System.Windows.Forms.TextBox();
            this.lblBankCode = new System.Windows.Forms.Label();
            this.dtpWorkingDate = new System.Windows.Forms.DateTimePicker();
            this.lblWorkingDate = new System.Windows.Forms.Label();
            this.cmbNationality = new System.Windows.Forms.ComboBox();
            this.lblNationality = new System.Windows.Forms.Label();
            this.dtpBirthday = new System.Windows.Forms.DateTimePicker();
            this.lblBirthday = new System.Windows.Forms.Label();
            this.txtOICQ = new System.Windows.Forms.TextBox();
            this.lblOICQ = new System.Windows.Forms.Label();
            this.txtMobile = new System.Windows.Forms.TextBox();
            this.lblMobile = new System.Windows.Forms.Label();
            this.ucPicture = new DotNet.WinForm.UCPicture();
            this.txtIdentificationCode = new System.Windows.Forms.TextBox();
            this.lblIdentificationCode = new System.Windows.Forms.Label();
            this.ucWorkgroup = new DotNet.WinForm.UCOrganizeSelect();
            this.lblWorkgroup = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblUserNameReq = new System.Windows.Forms.Label();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRole = new System.Windows.Forms.Label();
            this.chbCreateUser = new System.Windows.Forms.CheckBox();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.ucDepartment = new DotNet.WinForm.UCOrganizeSelect();
            this.ucCompany = new DotNet.WinForm.UCOrganizeSelect();
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDepartmentReq = new System.Windows.Forms.Label();
            this.lblCompanyNameReq = new System.Windows.Forms.Label();
            this.lblDepartment = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.chbEnabled = new System.Windows.Forms.CheckBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.btnDeleteStaffUser = new System.Windows.Forms.Button();
            this.btnUserProperty = new System.Windows.Forms.Button();
            this.btnSetStaffUser = new System.Windows.Forms.Button();
            this.btnUpdateUser = new System.Windows.Forms.Button();
            this.grpStaffAdd.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnUserPermission
            // 
            this.btnUserPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUserPermission.Location = new System.Drawing.Point(178, 500);
            this.btnUserPermission.Name = "btnUserPermission";
            this.btnUserPermission.Size = new System.Drawing.Size(97, 23);
            this.btnUserPermission.TabIndex = 5;
            this.btnUserPermission.Text = "用户权限(&P)...";
            this.btnUserPermission.UseVisualStyleBackColor = true;
            this.btnUserPermission.Click += new System.EventHandler(this.btnUserPermission_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(876, 500);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConfirm.Location = new System.Drawing.Point(797, 500);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 1;
            this.btnConfirm.Text = "保存(&S)";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // grpStaffAdd
            // 
            this.grpStaffAdd.Controls.Add(this.lblFullNameReq);
            this.grpStaffAdd.Controls.Add(this.label1);
            this.grpStaffAdd.Controls.Add(this.label2);
            this.grpStaffAdd.Controls.Add(this.cmbTitle);
            this.grpStaffAdd.Controls.Add(this.lblTitle);
            this.grpStaffAdd.Controls.Add(this.cmbDuty);
            this.grpStaffAdd.Controls.Add(this.lblDuty);
            this.grpStaffAdd.Controls.Add(this.txtCarCode);
            this.grpStaffAdd.Controls.Add(this.lblCarCode);
            this.grpStaffAdd.Controls.Add(this.txtEmergencyContact);
            this.grpStaffAdd.Controls.Add(this.lblEmergencyContact);
            this.grpStaffAdd.Controls.Add(this.txtHomeAddress);
            this.grpStaffAdd.Controls.Add(this.lblHomeAddress);
            this.grpStaffAdd.Controls.Add(this.txtHomePhone);
            this.grpStaffAdd.Controls.Add(this.lblHomePhone);
            this.grpStaffAdd.Controls.Add(this.txtDescription);
            this.grpStaffAdd.Controls.Add(this.lblDescription);
            this.grpStaffAdd.Controls.Add(this.txtMajor);
            this.grpStaffAdd.Controls.Add(this.lblMajor);
            this.grpStaffAdd.Controls.Add(this.cmbDegree);
            this.grpStaffAdd.Controls.Add(this.lblDegree);
            this.grpStaffAdd.Controls.Add(this.cmbEducation);
            this.grpStaffAdd.Controls.Add(this.lblEducation);
            this.grpStaffAdd.Controls.Add(this.txtSchool);
            this.grpStaffAdd.Controls.Add(this.lblSchool);
            this.grpStaffAdd.Controls.Add(this.txtShortNumber);
            this.grpStaffAdd.Controls.Add(this.lblShortNumber);
            this.grpStaffAdd.Controls.Add(this.txtIdCard);
            this.grpStaffAdd.Controls.Add(this.lblIdCard);
            this.grpStaffAdd.Controls.Add(this.cmbParty);
            this.grpStaffAdd.Controls.Add(this.lblParty);
            this.grpStaffAdd.Controls.Add(this.cmbWorkingProperty);
            this.grpStaffAdd.Controls.Add(this.lblWorkingProperty);
            this.grpStaffAdd.Controls.Add(this.dtpJoinInDate);
            this.grpStaffAdd.Controls.Add(this.lblJoinInDate);
            this.grpStaffAdd.Controls.Add(this.txtOfficePhone);
            this.grpStaffAdd.Controls.Add(this.lblOfficePhone);
            this.grpStaffAdd.Controls.Add(this.txtBankCode);
            this.grpStaffAdd.Controls.Add(this.lblBankCode);
            this.grpStaffAdd.Controls.Add(this.dtpWorkingDate);
            this.grpStaffAdd.Controls.Add(this.lblWorkingDate);
            this.grpStaffAdd.Controls.Add(this.cmbNationality);
            this.grpStaffAdd.Controls.Add(this.lblNationality);
            this.grpStaffAdd.Controls.Add(this.dtpBirthday);
            this.grpStaffAdd.Controls.Add(this.lblBirthday);
            this.grpStaffAdd.Controls.Add(this.txtOICQ);
            this.grpStaffAdd.Controls.Add(this.lblOICQ);
            this.grpStaffAdd.Controls.Add(this.txtMobile);
            this.grpStaffAdd.Controls.Add(this.lblMobile);
            this.grpStaffAdd.Controls.Add(this.ucPicture);
            this.grpStaffAdd.Controls.Add(this.txtIdentificationCode);
            this.grpStaffAdd.Controls.Add(this.lblIdentificationCode);
            this.grpStaffAdd.Controls.Add(this.ucWorkgroup);
            this.grpStaffAdd.Controls.Add(this.lblWorkgroup);
            this.grpStaffAdd.Controls.Add(this.txtEmail);
            this.grpStaffAdd.Controls.Add(this.lblEmail);
            this.grpStaffAdd.Controls.Add(this.txtUserName);
            this.grpStaffAdd.Controls.Add(this.lblUserName);
            this.grpStaffAdd.Controls.Add(this.lblUserNameReq);
            this.grpStaffAdd.Controls.Add(this.cmbRole);
            this.grpStaffAdd.Controls.Add(this.lblRole);
            this.grpStaffAdd.Controls.Add(this.chbCreateUser);
            this.grpStaffAdd.Controls.Add(this.cmbGender);
            this.grpStaffAdd.Controls.Add(this.lblGender);
            this.grpStaffAdd.Controls.Add(this.ucDepartment);
            this.grpStaffAdd.Controls.Add(this.ucCompany);
            this.grpStaffAdd.Controls.Add(this.txtRealName);
            this.grpStaffAdd.Controls.Add(this.txtCode);
            this.grpStaffAdd.Controls.Add(this.lblDepartmentReq);
            this.grpStaffAdd.Controls.Add(this.lblCompanyNameReq);
            this.grpStaffAdd.Controls.Add(this.lblDepartment);
            this.grpStaffAdd.Controls.Add(this.lblCompanyName);
            this.grpStaffAdd.Controls.Add(this.chbEnabled);
            this.grpStaffAdd.Controls.Add(this.lblCode);
            this.grpStaffAdd.Controls.Add(this.lblFullName);
            this.grpStaffAdd.Location = new System.Drawing.Point(11, 11);
            this.grpStaffAdd.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.grpStaffAdd.Name = "grpStaffAdd";
            this.grpStaffAdd.Padding = new System.Windows.Forms.Padding(0);
            this.grpStaffAdd.Size = new System.Drawing.Size(940, 483);
            this.grpStaffAdd.TabIndex = 0;
            this.grpStaffAdd.TabStop = false;
            this.grpStaffAdd.Text = "员工";
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(261, 23);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 77;
            this.lblFullNameReq.Text = "*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(481, 116);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(11, 12);
            this.label1.TabIndex = 79;
            this.label1.Text = "*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(481, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(11, 12);
            this.label2.TabIndex = 78;
            this.label2.Text = "*";
            // 
            // cmbTitle
            // 
            this.cmbTitle.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTitle.FormattingEnabled = true;
            this.cmbTitle.Location = new System.Drawing.Point(599, 107);
            this.cmbTitle.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbTitle.Name = "cmbTitle";
            this.cmbTitle.Size = new System.Drawing.Size(126, 20);
            this.cmbTitle.TabIndex = 76;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(499, 114);
            this.lblTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(97, 12);
            this.lblTitle.TabIndex = 75;
            this.lblTitle.Text = "职称：";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDuty
            // 
            this.cmbDuty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDuty.FormattingEnabled = true;
            this.cmbDuty.Location = new System.Drawing.Point(599, 79);
            this.cmbDuty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbDuty.Name = "cmbDuty";
            this.cmbDuty.Size = new System.Drawing.Size(126, 20);
            this.cmbDuty.TabIndex = 73;
            // 
            // lblDuty
            // 
            this.lblDuty.Location = new System.Drawing.Point(499, 85);
            this.lblDuty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDuty.Name = "lblDuty";
            this.lblDuty.Size = new System.Drawing.Size(97, 12);
            this.lblDuty.TabIndex = 74;
            this.lblDuty.Text = "职务：";
            this.lblDuty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtCarCode
            // 
            this.txtCarCode.Location = new System.Drawing.Point(799, 383);
            this.txtCarCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCarCode.MaxLength = 20;
            this.txtCarCode.Name = "txtCarCode";
            this.txtCarCode.Size = new System.Drawing.Size(126, 21);
            this.txtCarCode.TabIndex = 63;
            // 
            // lblCarCode
            // 
            this.lblCarCode.Location = new System.Drawing.Point(696, 390);
            this.lblCarCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCarCode.Name = "lblCarCode";
            this.lblCarCode.Size = new System.Drawing.Size(101, 14);
            this.lblCarCode.TabIndex = 62;
            this.lblCarCode.Text = "车牌号：";
            this.lblCarCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmergencyContact
            // 
            this.txtEmergencyContact.Location = new System.Drawing.Point(474, 416);
            this.txtEmergencyContact.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmergencyContact.MaxLength = 200;
            this.txtEmergencyContact.Name = "txtEmergencyContact";
            this.txtEmergencyContact.Size = new System.Drawing.Size(451, 21);
            this.txtEmergencyContact.TabIndex = 67;
            // 
            // lblEmergencyContact
            // 
            this.lblEmergencyContact.Location = new System.Drawing.Point(361, 419);
            this.lblEmergencyContact.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmergencyContact.Name = "lblEmergencyContact";
            this.lblEmergencyContact.Size = new System.Drawing.Size(109, 12);
            this.lblEmergencyContact.TabIndex = 66;
            this.lblEmergencyContact.Text = "紧急联系：";
            this.lblEmergencyContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHomeAddress
            // 
            this.txtHomeAddress.Location = new System.Drawing.Point(473, 352);
            this.txtHomeAddress.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHomeAddress.MaxLength = 200;
            this.txtHomeAddress.Name = "txtHomeAddress";
            this.txtHomeAddress.Size = new System.Drawing.Size(451, 21);
            this.txtHomeAddress.TabIndex = 56;
            // 
            // lblHomeAddress
            // 
            this.lblHomeAddress.Location = new System.Drawing.Point(360, 359);
            this.lblHomeAddress.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHomeAddress.Name = "lblHomeAddress";
            this.lblHomeAddress.Size = new System.Drawing.Size(109, 12);
            this.lblHomeAddress.TabIndex = 55;
            this.lblHomeAddress.Text = "住宅地址：";
            this.lblHomeAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtHomePhone
            // 
            this.txtHomePhone.Location = new System.Drawing.Point(473, 383);
            this.txtHomePhone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtHomePhone.MaxLength = 50;
            this.txtHomePhone.Name = "txtHomePhone";
            this.txtHomePhone.Size = new System.Drawing.Size(175, 21);
            this.txtHomePhone.TabIndex = 61;
            // 
            // lblHomePhone
            // 
            this.lblHomePhone.Location = new System.Drawing.Point(360, 390);
            this.lblHomePhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblHomePhone.Name = "lblHomePhone";
            this.lblHomePhone.Size = new System.Drawing.Size(109, 12);
            this.lblHomePhone.TabIndex = 60;
            this.lblHomePhone.Text = "住宅电话：";
            this.lblHomePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(474, 449);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(451, 24);
            this.txtDescription.TabIndex = 71;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(360, 452);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(109, 12);
            this.lblDescription.TabIndex = 70;
            this.lblDescription.Text = "描述：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMajor
            // 
            this.txtMajor.Location = new System.Drawing.Point(475, 290);
            this.txtMajor.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMajor.MaxLength = 100;
            this.txtMajor.Name = "txtMajor";
            this.txtMajor.Size = new System.Drawing.Size(175, 21);
            this.txtMajor.TabIndex = 46;
            // 
            // lblMajor
            // 
            this.lblMajor.Location = new System.Drawing.Point(361, 295);
            this.lblMajor.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMajor.Name = "lblMajor";
            this.lblMajor.Size = new System.Drawing.Size(109, 12);
            this.lblMajor.TabIndex = 45;
            this.lblMajor.Text = "所学专业：";
            this.lblMajor.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbDegree
            // 
            this.cmbDegree.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDegree.FormattingEnabled = true;
            this.cmbDegree.Location = new System.Drawing.Point(800, 324);
            this.cmbDegree.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbDegree.Name = "cmbDegree";
            this.cmbDegree.Size = new System.Drawing.Size(126, 20);
            this.cmbDegree.TabIndex = 52;
            // 
            // lblDegree
            // 
            this.lblDegree.Location = new System.Drawing.Point(695, 326);
            this.lblDegree.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDegree.Name = "lblDegree";
            this.lblDegree.Size = new System.Drawing.Size(101, 14);
            this.lblDegree.TabIndex = 51;
            this.lblDegree.Text = "学位：";
            this.lblDegree.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbEducation
            // 
            this.cmbEducation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEducation.FormattingEnabled = true;
            this.cmbEducation.Location = new System.Drawing.Point(475, 322);
            this.cmbEducation.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbEducation.Name = "cmbEducation";
            this.cmbEducation.Size = new System.Drawing.Size(126, 20);
            this.cmbEducation.TabIndex = 50;
            // 
            // lblEducation
            // 
            this.lblEducation.Location = new System.Drawing.Point(360, 328);
            this.lblEducation.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEducation.Name = "lblEducation";
            this.lblEducation.Size = new System.Drawing.Size(109, 12);
            this.lblEducation.TabIndex = 49;
            this.lblEducation.Text = "学历：";
            this.lblEducation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSchool
            // 
            this.txtSchool.Location = new System.Drawing.Point(475, 256);
            this.txtSchool.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtSchool.MaxLength = 200;
            this.txtSchool.Name = "txtSchool";
            this.txtSchool.Size = new System.Drawing.Size(451, 21);
            this.txtSchool.TabIndex = 42;
            // 
            // lblSchool
            // 
            this.lblSchool.Location = new System.Drawing.Point(360, 265);
            this.lblSchool.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSchool.Name = "lblSchool";
            this.lblSchool.Size = new System.Drawing.Size(109, 12);
            this.lblSchool.TabIndex = 41;
            this.lblSchool.Text = "毕业学校：";
            this.lblSchool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtShortNumber
            // 
            this.txtShortNumber.Location = new System.Drawing.Point(475, 230);
            this.txtShortNumber.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtShortNumber.MaxLength = 20;
            this.txtShortNumber.Name = "txtShortNumber";
            this.txtShortNumber.Size = new System.Drawing.Size(250, 21);
            this.txtShortNumber.TabIndex = 38;
            // 
            // lblShortNumber
            // 
            this.lblShortNumber.Location = new System.Drawing.Point(361, 237);
            this.lblShortNumber.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblShortNumber.Name = "lblShortNumber";
            this.lblShortNumber.Size = new System.Drawing.Size(109, 12);
            this.lblShortNumber.TabIndex = 37;
            this.lblShortNumber.Text = "短号：";
            this.lblShortNumber.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIdCard
            // 
            this.txtIdCard.Location = new System.Drawing.Point(475, 170);
            this.txtIdCard.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIdCard.MaxLength = 20;
            this.txtIdCard.Name = "txtIdCard";
            this.txtIdCard.Size = new System.Drawing.Size(250, 21);
            this.txtIdCard.TabIndex = 30;
            // 
            // lblIdCard
            // 
            this.lblIdCard.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblIdCard.Location = new System.Drawing.Point(361, 175);
            this.lblIdCard.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdCard.Name = "lblIdCard";
            this.lblIdCard.Size = new System.Drawing.Size(109, 12);
            this.lblIdCard.TabIndex = 29;
            this.lblIdCard.Text = "身份证：";
            this.lblIdCard.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbParty
            // 
            this.cmbParty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbParty.FormattingEnabled = true;
            this.cmbParty.Location = new System.Drawing.Point(367, 49);
            this.cmbParty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbParty.Name = "cmbParty";
            this.cmbParty.Size = new System.Drawing.Size(126, 20);
            this.cmbParty.TabIndex = 10;
            // 
            // lblParty
            // 
            this.lblParty.Location = new System.Drawing.Point(280, 51);
            this.lblParty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParty.Name = "lblParty";
            this.lblParty.Size = new System.Drawing.Size(74, 12);
            this.lblParty.TabIndex = 9;
            this.lblParty.Text = "政治面貌：";
            this.lblParty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbWorkingProperty
            // 
            this.cmbWorkingProperty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWorkingProperty.Location = new System.Drawing.Point(127, 202);
            this.cmbWorkingProperty.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbWorkingProperty.Name = "cmbWorkingProperty";
            this.cmbWorkingProperty.Size = new System.Drawing.Size(207, 20);
            this.cmbWorkingProperty.TabIndex = 32;
            // 
            // lblWorkingProperty
            // 
            this.lblWorkingProperty.Location = new System.Drawing.Point(11, 206);
            this.lblWorkingProperty.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkingProperty.Name = "lblWorkingProperty";
            this.lblWorkingProperty.Size = new System.Drawing.Size(116, 12);
            this.lblWorkingProperty.TabIndex = 31;
            this.lblWorkingProperty.Text = "用工性质：";
            this.lblWorkingProperty.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpJoinInDate
            // 
            this.dtpJoinInDate.Checked = false;
            this.dtpJoinInDate.CustomFormat = "yyyy-MM-dd";
            this.dtpJoinInDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpJoinInDate.Location = new System.Drawing.Point(127, 170);
            this.dtpJoinInDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpJoinInDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpJoinInDate.Name = "dtpJoinInDate";
            this.dtpJoinInDate.ShowCheckBox = true;
            this.dtpJoinInDate.Size = new System.Drawing.Size(126, 21);
            this.dtpJoinInDate.TabIndex = 28;
            // 
            // lblJoinInDate
            // 
            this.lblJoinInDate.Location = new System.Drawing.Point(11, 175);
            this.lblJoinInDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJoinInDate.Name = "lblJoinInDate";
            this.lblJoinInDate.Size = new System.Drawing.Size(116, 12);
            this.lblJoinInDate.TabIndex = 27;
            this.lblJoinInDate.Text = "加入本单位：";
            this.lblJoinInDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOfficePhone
            // 
            this.txtOfficePhone.Location = new System.Drawing.Point(127, 230);
            this.txtOfficePhone.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOfficePhone.MaxLength = 20;
            this.txtOfficePhone.Name = "txtOfficePhone";
            this.txtOfficePhone.Size = new System.Drawing.Size(207, 21);
            this.txtOfficePhone.TabIndex = 36;
            // 
            // lblOfficePhone
            // 
            this.lblOfficePhone.Location = new System.Drawing.Point(11, 237);
            this.lblOfficePhone.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOfficePhone.Name = "lblOfficePhone";
            this.lblOfficePhone.Size = new System.Drawing.Size(116, 12);
            this.lblOfficePhone.TabIndex = 35;
            this.lblOfficePhone.Text = "办公电话：";
            this.lblOfficePhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtBankCode
            // 
            this.txtBankCode.Location = new System.Drawing.Point(127, 328);
            this.txtBankCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtBankCode.MaxLength = 20;
            this.txtBankCode.Name = "txtBankCode";
            this.txtBankCode.Size = new System.Drawing.Size(207, 21);
            this.txtBankCode.TabIndex = 48;
            // 
            // lblBankCode
            // 
            this.lblBankCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblBankCode.Location = new System.Drawing.Point(11, 330);
            this.lblBankCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBankCode.Name = "lblBankCode";
            this.lblBankCode.Size = new System.Drawing.Size(116, 12);
            this.lblBankCode.TabIndex = 47;
            this.lblBankCode.Text = "工资卡号：";
            this.lblBankCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpWorkingDate
            // 
            this.dtpWorkingDate.Checked = false;
            this.dtpWorkingDate.CustomFormat = "yyyy-MM-dd";
            this.dtpWorkingDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpWorkingDate.Location = new System.Drawing.Point(598, 139);
            this.dtpWorkingDate.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpWorkingDate.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpWorkingDate.Name = "dtpWorkingDate";
            this.dtpWorkingDate.ShowCheckBox = true;
            this.dtpWorkingDate.Size = new System.Drawing.Size(126, 21);
            this.dtpWorkingDate.TabIndex = 26;
            // 
            // lblWorkingDate
            // 
            this.lblWorkingDate.Location = new System.Drawing.Point(499, 144);
            this.lblWorkingDate.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkingDate.Name = "lblWorkingDate";
            this.lblWorkingDate.Size = new System.Drawing.Size(97, 12);
            this.lblWorkingDate.TabIndex = 25;
            this.lblWorkingDate.Text = "参加工作：";
            this.lblWorkingDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbNationality
            // 
            this.cmbNationality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbNationality.FormattingEnabled = true;
            this.cmbNationality.Location = new System.Drawing.Point(598, 47);
            this.cmbNationality.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbNationality.Name = "cmbNationality";
            this.cmbNationality.Size = new System.Drawing.Size(126, 20);
            this.cmbNationality.TabIndex = 12;
            // 
            // lblNationality
            // 
            this.lblNationality.Location = new System.Drawing.Point(499, 51);
            this.lblNationality.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNationality.Name = "lblNationality";
            this.lblNationality.Size = new System.Drawing.Size(97, 12);
            this.lblNationality.TabIndex = 11;
            this.lblNationality.Text = "民族：";
            this.lblNationality.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dtpBirthday
            // 
            this.dtpBirthday.Checked = false;
            this.dtpBirthday.CustomFormat = "yyyy-MM-dd";
            this.dtpBirthday.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpBirthday.Location = new System.Drawing.Point(598, 17);
            this.dtpBirthday.MaxDate = new System.DateTime(2099, 12, 31, 0, 0, 0, 0);
            this.dtpBirthday.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpBirthday.Name = "dtpBirthday";
            this.dtpBirthday.ShowCheckBox = true;
            this.dtpBirthday.Size = new System.Drawing.Size(126, 21);
            this.dtpBirthday.TabIndex = 6;
            // 
            // lblBirthday
            // 
            this.lblBirthday.Location = new System.Drawing.Point(499, 20);
            this.lblBirthday.Name = "lblBirthday";
            this.lblBirthday.Size = new System.Drawing.Size(97, 12);
            this.lblBirthday.TabIndex = 5;
            this.lblBirthday.Text = "生日：";
            this.lblBirthday.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtOICQ
            // 
            this.txtOICQ.Location = new System.Drawing.Point(475, 202);
            this.txtOICQ.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtOICQ.MaxLength = 20;
            this.txtOICQ.Name = "txtOICQ";
            this.txtOICQ.Size = new System.Drawing.Size(250, 21);
            this.txtOICQ.TabIndex = 34;
            // 
            // lblOICQ
            // 
            this.lblOICQ.Location = new System.Drawing.Point(365, 206);
            this.lblOICQ.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblOICQ.Name = "lblOICQ";
            this.lblOICQ.Size = new System.Drawing.Size(105, 12);
            this.lblOICQ.TabIndex = 33;
            this.lblOICQ.Text = "QQ：";
            this.lblOICQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtMobile
            // 
            this.txtMobile.Location = new System.Drawing.Point(127, 295);
            this.txtMobile.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtMobile.MaxLength = 20;
            this.txtMobile.Name = "txtMobile";
            this.txtMobile.Size = new System.Drawing.Size(207, 21);
            this.txtMobile.TabIndex = 44;
            // 
            // lblMobile
            // 
            this.lblMobile.Location = new System.Drawing.Point(11, 299);
            this.lblMobile.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMobile.Name = "lblMobile";
            this.lblMobile.Size = new System.Drawing.Size(116, 12);
            this.lblMobile.TabIndex = 43;
            this.lblMobile.Text = "手机：";
            this.lblMobile.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucPicture
            // 
            this.ucPicture.AllowDrop = true;
            this.ucPicture.FolderId = "";
            this.ucPicture.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPicture.Location = new System.Drawing.Point(737, 17);
            this.ucPicture.Name = "ucPicture";
            this.ucPicture.PictureId = "";
            this.ucPicture.Size = new System.Drawing.Size(189, 203);
            this.ucPicture.TabIndex = 72;
            // 
            // txtIdentificationCode
            // 
            this.txtIdentificationCode.Location = new System.Drawing.Point(127, 359);
            this.txtIdentificationCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtIdentificationCode.MaxLength = 20;
            this.txtIdentificationCode.Name = "txtIdentificationCode";
            this.txtIdentificationCode.Size = new System.Drawing.Size(207, 21);
            this.txtIdentificationCode.TabIndex = 54;
            // 
            // lblIdentificationCode
            // 
            this.lblIdentificationCode.Location = new System.Drawing.Point(11, 361);
            this.lblIdentificationCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblIdentificationCode.Name = "lblIdentificationCode";
            this.lblIdentificationCode.Size = new System.Drawing.Size(116, 12);
            this.lblIdentificationCode.TabIndex = 53;
            this.lblIdentificationCode.Text = "个人识别码：";
            this.lblIdentificationCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucWorkgroup
            // 
            this.ucWorkgroup.AllowNull = true;
            this.ucWorkgroup.AllowSelect = true;
            this.ucWorkgroup.AutoSize = true;
            this.ucWorkgroup.CanEdit = false;
            this.ucWorkgroup.CheckMove = false;
            this.ucWorkgroup.Location = new System.Drawing.Point(127, 138);
            this.ucWorkgroup.MultiSelect = false;
            this.ucWorkgroup.Name = "ucWorkgroup";
            this.ucWorkgroup.OpenId = "";
            this.ucWorkgroup.PermissionItemScopeCode = "";
            this.ucWorkgroup.SelectedFullName = "";
            this.ucWorkgroup.SelectedId = "";
            this.ucWorkgroup.Size = new System.Drawing.Size(352, 23);
            this.ucWorkgroup.TabIndex = 20;
            // 
            // lblWorkgroup
            // 
            this.lblWorkgroup.Location = new System.Drawing.Point(11, 144);
            this.lblWorkgroup.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWorkgroup.Name = "lblWorkgroup";
            this.lblWorkgroup.Size = new System.Drawing.Size(116, 12);
            this.lblWorkgroup.TabIndex = 19;
            this.lblWorkgroup.Text = "工作组：";
            this.lblWorkgroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(127, 265);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtEmail.MaxLength = 100;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(207, 21);
            this.txtEmail.TabIndex = 40;
            // 
            // lblEmail
            // 
            this.lblEmail.Location = new System.Drawing.Point(11, 268);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(116, 12);
            this.lblEmail.TabIndex = 39;
            this.lblEmail.Text = "电子邮件：";
            this.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(127, 390);
            this.txtUserName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtUserName.MaxLength = 50;
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(207, 21);
            this.txtUserName.TabIndex = 58;
            // 
            // lblUserName
            // 
            this.lblUserName.Location = new System.Drawing.Point(11, 392);
            this.lblUserName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(116, 12);
            this.lblUserName.TabIndex = 57;
            this.lblUserName.Text = "登录用户名：";
            this.lblUserName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblUserNameReq
            // 
            this.lblUserNameReq.AutoSize = true;
            this.lblUserNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblUserNameReq.Location = new System.Drawing.Point(332, 399);
            this.lblUserNameReq.Name = "lblUserNameReq";
            this.lblUserNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblUserNameReq.TabIndex = 59;
            this.lblUserNameReq.Text = "*";
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Location = new System.Drawing.Point(127, 419);
            this.cmbRole.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(207, 20);
            this.cmbRole.TabIndex = 65;
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(11, 423);
            this.lblRole.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(116, 12);
            this.lblRole.TabIndex = 64;
            this.lblRole.Text = "默认角色：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbCreateUser
            // 
            this.chbCreateUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbCreateUser.AutoSize = true;
            this.chbCreateUser.Checked = true;
            this.chbCreateUser.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbCreateUser.Location = new System.Drawing.Point(127, 450);
            this.chbCreateUser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chbCreateUser.Name = "chbCreateUser";
            this.chbCreateUser.Size = new System.Drawing.Size(72, 16);
            this.chbCreateUser.TabIndex = 68;
            this.chbCreateUser.Text = "创建用户";
            this.chbCreateUser.CheckedChanged += new System.EventHandler(this.chbIsUser_CheckedChanged);
            // 
            // cmbGender
            // 
            this.cmbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Location = new System.Drawing.Point(367, 17);
            this.cmbGender.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(126, 20);
            this.cmbGender.TabIndex = 4;
            // 
            // lblGender
            // 
            this.lblGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(321, 20);
            this.lblGender.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(41, 12);
            this.lblGender.TabIndex = 3;
            this.lblGender.Text = "性别：";
            // 
            // ucDepartment
            // 
            this.ucDepartment.AllowNull = true;
            this.ucDepartment.AllowSelect = true;
            this.ucDepartment.AutoSize = true;
            this.ucDepartment.CanEdit = false;
            this.ucDepartment.CheckMove = false;
            this.ucDepartment.Location = new System.Drawing.Point(127, 108);
            this.ucDepartment.MultiSelect = false;
            this.ucDepartment.Name = "ucDepartment";
            this.ucDepartment.OpenId = "";
            this.ucDepartment.PermissionItemScopeCode = "";
            this.ucDepartment.SelectedFullName = "";
            this.ucDepartment.SelectedId = "";
            this.ucDepartment.Size = new System.Drawing.Size(352, 23);
            this.ucDepartment.TabIndex = 17;
            this.ucDepartment.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetDepartment);
            // 
            // ucCompany
            // 
            this.ucCompany.AllowNull = true;
            this.ucCompany.AllowSelect = true;
            this.ucCompany.AutoSize = true;
            this.ucCompany.CanEdit = false;
            this.ucCompany.CheckMove = false;
            this.ucCompany.Location = new System.Drawing.Point(127, 81);
            this.ucCompany.MultiSelect = false;
            this.ucCompany.Name = "ucCompany";
            this.ucCompany.OpenId = "";
            this.ucCompany.PermissionItemScopeCode = "";
            this.ucCompany.SelectedFullName = "";
            this.ucCompany.SelectedId = "";
            this.ucCompany.Size = new System.Drawing.Size(352, 23);
            this.ucCompany.TabIndex = 14;
            this.ucCompany.SelectedIndexChanged += new DotNet.Utilities.BaseBusinessLogic.SelectedIndexChangedEventHandler(this.SetCompany);
            // 
            // txtRealName
            // 
            this.txtRealName.Location = new System.Drawing.Point(127, 17);
            this.txtRealName.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(130, 21);
            this.txtRealName.TabIndex = 1;
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(127, 49);
            this.txtCode.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(132, 21);
            this.txtCode.TabIndex = 8;
            // 
            // lblDepartmentReq
            // 
            this.lblDepartmentReq.AutoSize = true;
            this.lblDepartmentReq.ForeColor = System.Drawing.Color.Red;
            this.lblDepartmentReq.Location = new System.Drawing.Point(433, 110);
            this.lblDepartmentReq.Name = "lblDepartmentReq";
            this.lblDepartmentReq.Size = new System.Drawing.Size(11, 12);
            this.lblDepartmentReq.TabIndex = 18;
            this.lblDepartmentReq.Text = "*";
            // 
            // lblCompanyNameReq
            // 
            this.lblCompanyNameReq.AutoSize = true;
            this.lblCompanyNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblCompanyNameReq.Location = new System.Drawing.Point(433, 81);
            this.lblCompanyNameReq.Name = "lblCompanyNameReq";
            this.lblCompanyNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblCompanyNameReq.TabIndex = 15;
            this.lblCompanyNameReq.Text = "*";
            // 
            // lblDepartment
            // 
            this.lblDepartment.Location = new System.Drawing.Point(11, 113);
            this.lblDepartment.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDepartment.Name = "lblDepartment";
            this.lblDepartment.Size = new System.Drawing.Size(116, 12);
            this.lblDepartment.TabIndex = 16;
            this.lblDepartment.Text = "部门：";
            this.lblDepartment.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Location = new System.Drawing.Point(11, 82);
            this.lblCompanyName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(116, 12);
            this.lblCompanyName.TabIndex = 13;
            this.lblCompanyName.Text = "公司：";
            this.lblCompanyName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chbEnabled
            // 
            this.chbEnabled.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chbEnabled.AutoSize = true;
            this.chbEnabled.Checked = true;
            this.chbEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbEnabled.Location = new System.Drawing.Point(283, 451);
            this.chbEnabled.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.chbEnabled.Name = "chbEnabled";
            this.chbEnabled.Size = new System.Drawing.Size(48, 16);
            this.chbEnabled.TabIndex = 69;
            this.chbEnabled.Text = "有效";
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(11, 51);
            this.lblCode.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(116, 12);
            this.lblCode.TabIndex = 7;
            this.lblCode.Text = "编号、工号：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(11, 20);
            this.lblFullName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(116, 12);
            this.lblFullName.TabIndex = 0;
            this.lblFullName.Text = "姓名(&N)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnDeleteStaffUser
            // 
            this.btnDeleteStaffUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeleteStaffUser.Location = new System.Drawing.Point(277, 500);
            this.btnDeleteStaffUser.Name = "btnDeleteStaffUser";
            this.btnDeleteStaffUser.Size = new System.Drawing.Size(109, 23);
            this.btnDeleteStaffUser.TabIndex = 6;
            this.btnDeleteStaffUser.Text = "删除用户关联";
            this.btnDeleteStaffUser.UseVisualStyleBackColor = true;
            this.btnDeleteStaffUser.Click += new System.EventHandler(this.btnDeleteStaffUser_Click);
            // 
            // btnUserProperty
            // 
            this.btnUserProperty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUserProperty.Location = new System.Drawing.Point(99, 500);
            this.btnUserProperty.Name = "btnUserProperty";
            this.btnUserProperty.Size = new System.Drawing.Size(77, 23);
            this.btnUserProperty.TabIndex = 4;
            this.btnUserProperty.Text = "用户属性";
            this.btnUserProperty.UseVisualStyleBackColor = true;
            this.btnUserProperty.Click += new System.EventHandler(this.btnUserProperty_Click);
            // 
            // btnSetStaffUser
            // 
            this.btnSetStaffUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetStaffUser.Location = new System.Drawing.Point(10, 500);
            this.btnSetStaffUser.Name = "btnSetStaffUser";
            this.btnSetStaffUser.Size = new System.Drawing.Size(87, 23);
            this.btnSetStaffUser.TabIndex = 3;
            this.btnSetStaffUser.Text = "关联用户...";
            this.btnSetStaffUser.UseVisualStyleBackColor = true;
            this.btnSetStaffUser.Click += new System.EventHandler(this.btnSetStaffUser_Click);
            // 
            // btnUpdateUser
            // 
            this.btnUpdateUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnUpdateUser.Location = new System.Drawing.Point(388, 500);
            this.btnUpdateUser.Name = "btnUpdateUser";
            this.btnUpdateUser.Size = new System.Drawing.Size(109, 23);
            this.btnUpdateUser.TabIndex = 7;
            this.btnUpdateUser.Text = "更新用户信息";
            this.btnUpdateUser.UseVisualStyleBackColor = true;
            this.btnUpdateUser.Click += new System.EventHandler(this.btnUpdateUser_Click);
            // 
            // FrmStaffEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(962, 532);
            this.Controls.Add(this.btnUpdateUser);
            this.Controls.Add(this.btnSetStaffUser);
            this.Controls.Add(this.btnUserProperty);
            this.Controls.Add(this.btnDeleteStaffUser);
            this.Controls.Add(this.btnUserPermission);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.grpStaffAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmStaffEdit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "编辑员工";
            this.grpStaffAdd.ResumeLayout(false);
            this.grpStaffAdd.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnUserPermission;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.GroupBox grpStaffAdd;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.Label lblGender;
        private DotNet.WinForm.UCOrganizeSelect ucDepartment;
        private DotNet.WinForm.UCOrganizeSelect ucCompany;
        private DotNet.WinForm.UCOrganizeSelect ucWorkgroup;
        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDepartmentReq;
        private System.Windows.Forms.Label lblCompanyNameReq;
        private System.Windows.Forms.Label lblDepartment;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.CheckBox chbEnabled;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblUserNameReq;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.CheckBox chbCreateUser;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblWorkgroup;
        private System.Windows.Forms.Button btnDeleteStaffUser;
        private System.Windows.Forms.Button btnUserProperty;
        private System.Windows.Forms.Button btnSetStaffUser;
        private System.Windows.Forms.TextBox txtIdentificationCode;
        private System.Windows.Forms.Label lblIdentificationCode;
        private DotNet.WinForm.UCPicture ucPicture;
        private System.Windows.Forms.TextBox txtOICQ;
        private System.Windows.Forms.Label lblOICQ;
        private System.Windows.Forms.TextBox txtMobile;
        private System.Windows.Forms.Label lblMobile;
        private System.Windows.Forms.DateTimePicker dtpBirthday;
        private System.Windows.Forms.Label lblBirthday;
        private System.Windows.Forms.DateTimePicker dtpWorkingDate;
        private System.Windows.Forms.Label lblWorkingDate;
        private System.Windows.Forms.ComboBox cmbNationality;
        private System.Windows.Forms.Label lblNationality;
        private System.Windows.Forms.TextBox txtBankCode;
        private System.Windows.Forms.Label lblBankCode;
        private System.Windows.Forms.TextBox txtOfficePhone;
        private System.Windows.Forms.Label lblOfficePhone;
        private System.Windows.Forms.ComboBox cmbWorkingProperty;
        private System.Windows.Forms.Label lblWorkingProperty;
        private System.Windows.Forms.DateTimePicker dtpJoinInDate;
        private System.Windows.Forms.Label lblJoinInDate;
        private System.Windows.Forms.ComboBox cmbParty;
        private System.Windows.Forms.Label lblParty;
        private System.Windows.Forms.TextBox txtIdCard;
        private System.Windows.Forms.Label lblIdCard;
        private System.Windows.Forms.TextBox txtMajor;
        private System.Windows.Forms.Label lblMajor;
        private System.Windows.Forms.ComboBox cmbDegree;
        private System.Windows.Forms.Label lblDegree;
        private System.Windows.Forms.ComboBox cmbEducation;
        private System.Windows.Forms.Label lblEducation;
        private System.Windows.Forms.TextBox txtSchool;
        private System.Windows.Forms.Label lblSchool;
        private System.Windows.Forms.TextBox txtShortNumber;
        private System.Windows.Forms.Label lblShortNumber;
        private System.Windows.Forms.TextBox txtCarCode;
        private System.Windows.Forms.Label lblCarCode;
        private System.Windows.Forms.TextBox txtEmergencyContact;
        private System.Windows.Forms.Label lblEmergencyContact;
        private System.Windows.Forms.TextBox txtHomeAddress;
        private System.Windows.Forms.Label lblHomeAddress;
        private System.Windows.Forms.TextBox txtHomePhone;
        private System.Windows.Forms.Label lblHomePhone;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.ComboBox cmbTitle;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ComboBox cmbDuty;
        private System.Windows.Forms.Label lblDuty;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdateUser;


    }
}