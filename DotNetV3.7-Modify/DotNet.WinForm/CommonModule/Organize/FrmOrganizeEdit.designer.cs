namespace DotNet.WinForm
{
    partial class FrmOrganizeEdit
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
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtWeb = new System.Windows.Forms.TextBox();
            this.lblWeb = new System.Windows.Forms.Label();
            this.txtPostalcode = new System.Windows.Forms.TextBox();
            this.lblPostalcode = new System.Windows.Forms.Label();
            this.lblParentReq = new System.Windows.Forms.Label();
            this.ucParent = new DotNet.WinForm.UCOrganizeSelect();
            this.chkIsInnerOrganize = new System.Windows.Forms.CheckBox();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.lblParentOrganize = new System.Windows.Forms.Label();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtInnerPhone = new System.Windows.Forms.TextBox();
            this.txtOuterPhone = new System.Windows.Forms.TextBox();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.lblInnerPhone = new System.Windows.Forms.Label();
            this.lblOuterPhone = new System.Windows.Forms.Label();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblFullName = new System.Windows.Forms.Label();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSystemManager = new System.Windows.Forms.Button();
            this.btnAccounting = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.btnFinancial = new System.Windows.Forms.Button();
            this.btnAssistantManager = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnAssistantLeadership = new System.Windows.Forms.Button();
            this.btnLeadership = new System.Windows.Forms.Button();
            this.grbOrganize = new System.Windows.Forms.GroupBox();
            this.txtLeadership = new System.Windows.Forms.TextBox();
            this.txtAssistantLeadership = new System.Windows.Forms.TextBox();
            this.txtManager = new System.Windows.Forms.TextBox();
            this.txtAssistantManager = new System.Windows.Forms.TextBox();
            this.txtFinancial = new System.Windows.Forms.TextBox();
            this.txtAccounting = new System.Windows.Forms.TextBox();
            this.txtCashier = new System.Windows.Forms.TextBox();
            this.txtSystemManager = new System.Windows.Forms.TextBox();
            this.grbDuty = new System.Windows.Forms.GroupBox();
            this.btnPermission = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.grbOrganize.SuspendLayout();
            this.grbDuty.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.Location = new System.Drawing.Point(128, 286);
            this.txtAddress.MaxLength = 20;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(285, 21);
            this.txtAddress.TabIndex = 23;
            // 
            // lblAddress
            // 
            this.lblAddress.Location = new System.Drawing.Point(23, 289);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(99, 12);
            this.lblAddress.TabIndex = 22;
            this.lblAddress.Text = "地址：";
            this.lblAddress.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtWeb
            // 
            this.txtWeb.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtWeb.Location = new System.Drawing.Point(128, 313);
            this.txtWeb.MaxLength = 200;
            this.txtWeb.Name = "txtWeb";
            this.txtWeb.Size = new System.Drawing.Size(285, 21);
            this.txtWeb.TabIndex = 25;
            // 
            // lblWeb
            // 
            this.lblWeb.Location = new System.Drawing.Point(23, 317);
            this.lblWeb.Name = "lblWeb";
            this.lblWeb.Size = new System.Drawing.Size(99, 12);
            this.lblWeb.TabIndex = 24;
            this.lblWeb.Text = "网址：";
            this.lblWeb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtPostalcode
            // 
            this.txtPostalcode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPostalcode.Location = new System.Drawing.Point(128, 259);
            this.txtPostalcode.MaxLength = 20;
            this.txtPostalcode.Name = "txtPostalcode";
            this.txtPostalcode.Size = new System.Drawing.Size(285, 21);
            this.txtPostalcode.TabIndex = 21;
            // 
            // lblPostalcode
            // 
            this.lblPostalcode.Location = new System.Drawing.Point(23, 264);
            this.lblPostalcode.Name = "lblPostalcode";
            this.lblPostalcode.Size = new System.Drawing.Size(99, 12);
            this.lblPostalcode.TabIndex = 20;
            this.lblPostalcode.Text = "邮编：";
            this.lblPostalcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblParentReq
            // 
            this.lblParentReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblParentReq.AutoSize = true;
            this.lblParentReq.ForeColor = System.Drawing.Color.Red;
            this.lblParentReq.Location = new System.Drawing.Point(417, 68);
            this.lblParentReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblParentReq.Name = "lblParentReq";
            this.lblParentReq.Size = new System.Drawing.Size(11, 12);
            this.lblParentReq.TabIndex = 2;
            this.lblParentReq.Text = "*";
            // 
            // ucParent
            // 
            this.ucParent.AllowNull = true;
            this.ucParent.AllowSelect = true;
            this.ucParent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucParent.AutoSize = true;
            this.ucParent.CanEdit = false;
            this.ucParent.CheckMove = false;
            this.ucParent.Location = new System.Drawing.Point(128, 63);
            this.ucParent.MultiSelect = false;
            this.ucParent.Name = "ucParent";
            this.ucParent.OpenId = "";
            this.ucParent.PermissionItemScopeCode = "";
            this.ucParent.SelectedFullName = "";
            this.ucParent.SelectedId = "";
            this.ucParent.Size = new System.Drawing.Size(285, 23);
            this.ucParent.TabIndex = 1;
            // 
            // chkIsInnerOrganize
            // 
            this.chkIsInnerOrganize.AutoSize = true;
            this.chkIsInnerOrganize.Checked = true;
            this.chkIsInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsInnerOrganize.Location = new System.Drawing.Point(231, 343);
            this.chkIsInnerOrganize.Name = "chkIsInnerOrganize";
            this.chkIsInnerOrganize.Size = new System.Drawing.Size(72, 16);
            this.chkIsInnerOrganize.TabIndex = 27;
            this.chkIsInnerOrganize.Text = "内部组织";
            this.chkIsInnerOrganize.UseVisualStyleBackColor = true;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(417, 97);
            this.lblFullNameReq.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 5;
            this.lblFullNameReq.Text = "*";
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(128, 343);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 26;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // lblParentOrganize
            // 
            this.lblParentOrganize.Location = new System.Drawing.Point(23, 67);
            this.lblParentOrganize.Name = "lblParentOrganize";
            this.lblParentOrganize.Size = new System.Drawing.Size(99, 12);
            this.lblParentOrganize.TabIndex = 0;
            this.lblParentOrganize.Text = "父节点(&P)：";
            this.lblParentOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmbCategory
            // 
            this.cmbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Location = new System.Drawing.Point(128, 146);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(285, 20);
            this.cmbCategory.TabIndex = 9;
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(23, 149);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(99, 12);
            this.lblCategory.TabIndex = 8;
            this.lblCategory.Text = "分类(&G)：";
            this.lblCategory.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtInnerPhone
            // 
            this.txtInnerPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInnerPhone.Location = new System.Drawing.Point(128, 205);
            this.txtInnerPhone.MaxLength = 20;
            this.txtInnerPhone.Name = "txtInnerPhone";
            this.txtInnerPhone.Size = new System.Drawing.Size(285, 21);
            this.txtInnerPhone.TabIndex = 17;
            // 
            // txtOuterPhone
            // 
            this.txtOuterPhone.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOuterPhone.Location = new System.Drawing.Point(128, 178);
            this.txtOuterPhone.MaxLength = 20;
            this.txtOuterPhone.Name = "txtOuterPhone";
            this.txtOuterPhone.Size = new System.Drawing.Size(285, 21);
            this.txtOuterPhone.TabIndex = 15;
            // 
            // txtFax
            // 
            this.txtFax.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFax.Location = new System.Drawing.Point(128, 232);
            this.txtFax.MaxLength = 20;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(285, 21);
            this.txtFax.TabIndex = 19;
            // 
            // lblInnerPhone
            // 
            this.lblInnerPhone.Location = new System.Drawing.Point(23, 209);
            this.lblInnerPhone.Name = "lblInnerPhone";
            this.lblInnerPhone.Size = new System.Drawing.Size(99, 12);
            this.lblInnerPhone.TabIndex = 16;
            this.lblInnerPhone.Text = "内线(&I)：";
            this.lblInnerPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOuterPhone
            // 
            this.lblOuterPhone.Location = new System.Drawing.Point(23, 182);
            this.lblOuterPhone.Name = "lblOuterPhone";
            this.lblOuterPhone.Size = new System.Drawing.Size(99, 12);
            this.lblOuterPhone.TabIndex = 14;
            this.lblOuterPhone.Text = "电话(&O)：";
            this.lblOuterPhone.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFax
            // 
            this.lblFax.Location = new System.Drawing.Point(23, 236);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(99, 12);
            this.lblFax.TabIndex = 18;
            this.lblFax.Text = "传真(&F)：";
            this.lblFax.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(128, 367);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(285, 45);
            this.txtDescription.TabIndex = 29;
            // 
            // txtFullName
            // 
            this.txtFullName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFullName.Location = new System.Drawing.Point(128, 92);
            this.txtFullName.MaxLength = 80;
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(285, 21);
            this.txtFullName.TabIndex = 4;
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(128, 119);
            this.txtCode.MaxLength = 20;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(285, 21);
            this.txtCode.TabIndex = 7;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(23, 369);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(99, 12);
            this.lblDescription.TabIndex = 28;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(23, 94);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(99, 12);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "名称(&F)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(23, 122);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(99, 12);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "编号(&E)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(354, 444);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 31;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(270, 444);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSystemManager
            // 
            this.btnSystemManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemManager.Location = new System.Drawing.Point(13, 336);
            this.btnSystemManager.Name = "btnSystemManager";
            this.btnSystemManager.Size = new System.Drawing.Size(91, 23);
            this.btnSystemManager.TabIndex = 14;
            this.btnSystemManager.Text = "系统管理员";
            this.btnSystemManager.UseVisualStyleBackColor = true;
            this.btnSystemManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccounting.Location = new System.Drawing.Point(13, 246);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Size = new System.Drawing.Size(91, 23);
            this.btnAccounting.TabIndex = 10;
            this.btnAccounting.Text = "会计";
            this.btnAccounting.UseVisualStyleBackColor = true;
            this.btnAccounting.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCashier.Location = new System.Drawing.Point(13, 291);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(91, 23);
            this.btnCashier.TabIndex = 12;
            this.btnCashier.Text = "出纳";
            this.btnCashier.UseVisualStyleBackColor = true;
            this.btnCashier.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnFinancial
            // 
            this.btnFinancial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancial.Location = new System.Drawing.Point(13, 201);
            this.btnFinancial.Name = "btnFinancial";
            this.btnFinancial.Size = new System.Drawing.Size(91, 23);
            this.btnFinancial.TabIndex = 8;
            this.btnFinancial.Text = "财务主管";
            this.btnFinancial.UseVisualStyleBackColor = true;
            this.btnFinancial.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAssistantManager
            // 
            this.btnAssistantManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantManager.Location = new System.Drawing.Point(13, 156);
            this.btnAssistantManager.Name = "btnAssistantManager";
            this.btnAssistantManager.Size = new System.Drawing.Size(91, 23);
            this.btnAssistantManager.TabIndex = 6;
            this.btnAssistantManager.Text = "副主管";
            this.btnAssistantManager.UseVisualStyleBackColor = true;
            this.btnAssistantManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnManager
            // 
            this.btnManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManager.Location = new System.Drawing.Point(13, 111);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(91, 23);
            this.btnManager.TabIndex = 4;
            this.btnManager.Text = "主管";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAssistantLeadership
            // 
            this.btnAssistantLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantLeadership.Location = new System.Drawing.Point(13, 66);
            this.btnAssistantLeadership.Name = "btnAssistantLeadership";
            this.btnAssistantLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnAssistantLeadership.TabIndex = 2;
            this.btnAssistantLeadership.Text = "分管领导";
            this.btnAssistantLeadership.UseVisualStyleBackColor = true;
            this.btnAssistantLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnLeadership
            // 
            this.btnLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeadership.Location = new System.Drawing.Point(13, 21);
            this.btnLeadership.Name = "btnLeadership";
            this.btnLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnLeadership.TabIndex = 0;
            this.btnLeadership.Text = "领导";
            this.btnLeadership.UseVisualStyleBackColor = true;
            this.btnLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // grbOrganize
            // 
            this.grbOrganize.Controls.Add(this.txtId);
            this.grbOrganize.Controls.Add(this.lblId);
            this.grbOrganize.Location = new System.Drawing.Point(10, 12);
            this.grbOrganize.Name = "grbOrganize";
            this.grbOrganize.Size = new System.Drawing.Size(419, 419);
            this.grbOrganize.TabIndex = 0;
            this.grbOrganize.TabStop = false;
            this.grbOrganize.Text = "组织机构";
            // 
            // txtLeadership
            // 
            this.txtLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLeadership.BackColor = System.Drawing.Color.Bisque;
            this.txtLeadership.Location = new System.Drawing.Point(13, 45);
            this.txtLeadership.MaxLength = 80;
            this.txtLeadership.Name = "txtLeadership";
            this.txtLeadership.ReadOnly = true;
            this.txtLeadership.Size = new System.Drawing.Size(120, 21);
            this.txtLeadership.TabIndex = 1;
            // 
            // txtAssistantLeadership
            // 
            this.txtAssistantLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssistantLeadership.BackColor = System.Drawing.Color.Bisque;
            this.txtAssistantLeadership.Location = new System.Drawing.Point(13, 90);
            this.txtAssistantLeadership.MaxLength = 80;
            this.txtAssistantLeadership.Name = "txtAssistantLeadership";
            this.txtAssistantLeadership.ReadOnly = true;
            this.txtAssistantLeadership.Size = new System.Drawing.Size(120, 21);
            this.txtAssistantLeadership.TabIndex = 3;
            // 
            // txtManager
            // 
            this.txtManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtManager.BackColor = System.Drawing.Color.OldLace;
            this.txtManager.Location = new System.Drawing.Point(13, 135);
            this.txtManager.MaxLength = 80;
            this.txtManager.Name = "txtManager";
            this.txtManager.ReadOnly = true;
            this.txtManager.Size = new System.Drawing.Size(120, 21);
            this.txtManager.TabIndex = 5;
            // 
            // txtAssistantManager
            // 
            this.txtAssistantManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAssistantManager.Location = new System.Drawing.Point(13, 180);
            this.txtAssistantManager.MaxLength = 80;
            this.txtAssistantManager.Name = "txtAssistantManager";
            this.txtAssistantManager.ReadOnly = true;
            this.txtAssistantManager.Size = new System.Drawing.Size(120, 21);
            this.txtAssistantManager.TabIndex = 7;
            // 
            // txtFinancial
            // 
            this.txtFinancial.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFinancial.Location = new System.Drawing.Point(13, 225);
            this.txtFinancial.MaxLength = 80;
            this.txtFinancial.Name = "txtFinancial";
            this.txtFinancial.ReadOnly = true;
            this.txtFinancial.Size = new System.Drawing.Size(120, 21);
            this.txtFinancial.TabIndex = 9;
            // 
            // txtAccounting
            // 
            this.txtAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAccounting.Location = new System.Drawing.Point(13, 270);
            this.txtAccounting.MaxLength = 80;
            this.txtAccounting.Name = "txtAccounting";
            this.txtAccounting.ReadOnly = true;
            this.txtAccounting.Size = new System.Drawing.Size(120, 21);
            this.txtAccounting.TabIndex = 11;
            // 
            // txtCashier
            // 
            this.txtCashier.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCashier.Location = new System.Drawing.Point(13, 315);
            this.txtCashier.MaxLength = 80;
            this.txtCashier.Name = "txtCashier";
            this.txtCashier.ReadOnly = true;
            this.txtCashier.Size = new System.Drawing.Size(120, 21);
            this.txtCashier.TabIndex = 13;
            // 
            // txtSystemManager
            // 
            this.txtSystemManager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSystemManager.Location = new System.Drawing.Point(13, 360);
            this.txtSystemManager.MaxLength = 80;
            this.txtSystemManager.Name = "txtSystemManager";
            this.txtSystemManager.ReadOnly = true;
            this.txtSystemManager.Size = new System.Drawing.Size(120, 21);
            this.txtSystemManager.TabIndex = 15;
            // 
            // grbDuty
            // 
            this.grbDuty.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbDuty.Controls.Add(this.txtSystemManager);
            this.grbDuty.Controls.Add(this.btnLeadership);
            this.grbDuty.Controls.Add(this.txtCashier);
            this.grbDuty.Controls.Add(this.btnAssistantLeadership);
            this.grbDuty.Controls.Add(this.txtAccounting);
            this.grbDuty.Controls.Add(this.btnManager);
            this.grbDuty.Controls.Add(this.txtFinancial);
            this.grbDuty.Controls.Add(this.btnAssistantManager);
            this.grbDuty.Controls.Add(this.txtAssistantManager);
            this.grbDuty.Controls.Add(this.btnFinancial);
            this.grbDuty.Controls.Add(this.txtManager);
            this.grbDuty.Controls.Add(this.btnCashier);
            this.grbDuty.Controls.Add(this.txtAssistantLeadership);
            this.grbDuty.Controls.Add(this.btnAccounting);
            this.grbDuty.Controls.Add(this.txtLeadership);
            this.grbDuty.Controls.Add(this.btnSystemManager);
            this.grbDuty.Location = new System.Drawing.Point(441, 12);
            this.grbDuty.Name = "grbDuty";
            this.grbDuty.Size = new System.Drawing.Size(146, 419);
            this.grbDuty.TabIndex = 1;
            this.grbDuty.TabStop = false;
            this.grbDuty.Text = "岗位";
            // 
            // btnPermission
            // 
            this.btnPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnPermission.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnPermission.Location = new System.Drawing.Point(10, 444);
            this.btnPermission.Name = "btnPermission";
            this.btnPermission.Size = new System.Drawing.Size(104, 23);
            this.btnPermission.TabIndex = 32;
            this.btnPermission.Text = "权限(&P)...";
            this.btnPermission.UseVisualStyleBackColor = true;
            this.btnPermission.Click += new System.EventHandler(this.btnPermission_Click);
            // 
            // txtId
            // 
            this.txtId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtId.Location = new System.Drawing.Point(119, 20);
            this.txtId.MaxLength = 50;
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(283, 21);
            this.txtId.TabIndex = 34;
            this.txtId.TabStop = false;
            // 
            // lblId
            // 
            this.lblId.Location = new System.Drawing.Point(33, 23);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(79, 12);
            this.lblId.TabIndex = 33;
            this.lblId.Text = "主键：";
            this.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FrmOrganizeEdit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(590, 479);
            this.Controls.Add(this.btnPermission);
            this.Controls.Add(this.txtAddress);
            this.Controls.Add(this.lblAddress);
            this.Controls.Add(this.txtWeb);
            this.Controls.Add(this.lblWeb);
            this.Controls.Add(this.txtPostalcode);
            this.Controls.Add(this.lblPostalcode);
            this.Controls.Add(this.lblParentReq);
            this.Controls.Add(this.ucParent);
            this.Controls.Add(this.chkIsInnerOrganize);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.lblParentOrganize);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.txtInnerPhone);
            this.Controls.Add(this.txtOuterPhone);
            this.Controls.Add(this.txtFax);
            this.Controls.Add(this.lblInnerPhone);
            this.Controls.Add(this.lblOuterPhone);
            this.Controls.Add(this.lblFax);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtFullName);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbOrganize);
            this.Controls.Add(this.grbDuty);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmOrganizeEdit";
            this.Text = "编辑组织机构";
            this.grbOrganize.ResumeLayout(false);
            this.grbOrganize.PerformLayout();
            this.grbDuty.ResumeLayout(false);
            this.grbDuty.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtWeb;
        private System.Windows.Forms.Label lblWeb;
        private System.Windows.Forms.TextBox txtPostalcode;
        private System.Windows.Forms.Label lblPostalcode;
        private System.Windows.Forms.Label lblParentReq;
        private DotNet.WinForm.UCOrganizeSelect ucParent;
        private System.Windows.Forms.CheckBox chkIsInnerOrganize;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label lblParentOrganize;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.TextBox txtInnerPhone;
        private System.Windows.Forms.TextBox txtOuterPhone;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.Label lblInnerPhone;
        private System.Windows.Forms.Label lblOuterPhone;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSystemManager;
        private System.Windows.Forms.Button btnAccounting;
        private System.Windows.Forms.Button btnCashier;
        private System.Windows.Forms.Button btnFinancial;
        private System.Windows.Forms.Button btnAssistantManager;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnAssistantLeadership;
        private System.Windows.Forms.Button btnLeadership;
        private System.Windows.Forms.GroupBox grbOrganize;
        private System.Windows.Forms.TextBox txtLeadership;
        private System.Windows.Forms.TextBox txtAssistantLeadership;
        private System.Windows.Forms.TextBox txtManager;
        private System.Windows.Forms.TextBox txtAssistantManager;
        private System.Windows.Forms.TextBox txtFinancial;
        private System.Windows.Forms.TextBox txtAccounting;
        private System.Windows.Forms.TextBox txtCashier;
        private System.Windows.Forms.TextBox txtSystemManager;
        private System.Windows.Forms.GroupBox grbDuty;
        private System.Windows.Forms.Button btnPermission;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;

    }
}