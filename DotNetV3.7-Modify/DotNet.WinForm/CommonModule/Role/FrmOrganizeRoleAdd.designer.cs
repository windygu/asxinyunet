namespace DotNet.WinForm
{
    partial class FrmOrganizeRoleAdd
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
            this.txtRealName = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblOrganize = new System.Windows.Forms.Label();
            this.lblFullNameReq = new System.Windows.Forms.Label();
            this.lblOrganizeReq = new System.Windows.Forms.Label();
            this.ucOrganize = new DotNet.WinForm.UCOrganizeSelect();
            this.lblCodeReq = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnLeadership = new System.Windows.Forms.Button();
            this.btnAssistantLeadership = new System.Windows.Forms.Button();
            this.btnManager = new System.Windows.Forms.Button();
            this.btnAssistantManager = new System.Windows.Forms.Button();
            this.btnAccounting = new System.Windows.Forms.Button();
            this.btnCashier = new System.Windows.Forms.Button();
            this.btnFinancial = new System.Windows.Forms.Button();
            this.btnSystemManager = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRealName
            // 
            this.txtRealName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRealName.Location = new System.Drawing.Point(99, 51);
            this.txtRealName.MaxLength = 50;
            this.txtRealName.Name = "txtRealName";
            this.txtRealName.Size = new System.Drawing.Size(270, 21);
            this.txtRealName.TabIndex = 4;
            // 
            // lblFullName
            // 
            this.lblFullName.Location = new System.Drawing.Point(12, 54);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(75, 12);
            this.lblFullName.TabIndex = 3;
            this.lblFullName.Text = "名称(&F)：";
            this.lblFullName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Checked = true;
            this.chkEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnabled.Location = new System.Drawing.Point(99, 120);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(48, 16);
            this.chkEnabled.TabIndex = 9;
            this.chkEnabled.Text = "有效";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(99, 152);
            this.txtDescription.MaxLength = 200;
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtDescription.Size = new System.Drawing.Size(270, 65);
            this.txtDescription.TabIndex = 11;
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(12, 154);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(75, 12);
            this.lblDescription.TabIndex = 10;
            this.lblDescription.Text = "描述(&D)：";
            this.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(294, 232);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 14;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(135, 232);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "添加(&A)";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblOrganize
            // 
            this.lblOrganize.Location = new System.Drawing.Point(12, 17);
            this.lblOrganize.Name = "lblOrganize";
            this.lblOrganize.Size = new System.Drawing.Size(75, 12);
            this.lblOrganize.TabIndex = 0;
            this.lblOrganize.Text = "部门(&O)：";
            this.lblOrganize.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblFullNameReq
            // 
            this.lblFullNameReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFullNameReq.AutoSize = true;
            this.lblFullNameReq.ForeColor = System.Drawing.Color.Red;
            this.lblFullNameReq.Location = new System.Drawing.Point(375, 56);
            this.lblFullNameReq.Name = "lblFullNameReq";
            this.lblFullNameReq.Size = new System.Drawing.Size(11, 12);
            this.lblFullNameReq.TabIndex = 5;
            this.lblFullNameReq.Text = "*";
            // 
            // lblOrganizeReq
            // 
            this.lblOrganizeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOrganizeReq.AutoSize = true;
            this.lblOrganizeReq.ForeColor = System.Drawing.Color.Red;
            this.lblOrganizeReq.Location = new System.Drawing.Point(375, 20);
            this.lblOrganizeReq.Name = "lblOrganizeReq";
            this.lblOrganizeReq.Size = new System.Drawing.Size(11, 12);
            this.lblOrganizeReq.TabIndex = 2;
            this.lblOrganizeReq.Text = "*";
            // 
            // ucOrganize
            // 
            this.ucOrganize.AllowNull = true;
            this.ucOrganize.AutoSize = true;
            this.ucOrganize.CanEdit = false;
            this.ucOrganize.CheckMove = false;
            this.ucOrganize.Location = new System.Drawing.Point(99, 14);
            this.ucOrganize.MultiSelect = false;
            this.ucOrganize.Name = "ucOrganize";
            this.ucOrganize.OpenId = "";
            this.ucOrganize.PermissionItemScopeCode = "";
            this.ucOrganize.SelectedFullName = "";
            this.ucOrganize.SelectedId = "";
            this.ucOrganize.Size = new System.Drawing.Size(270, 23);
            this.ucOrganize.TabIndex = 1;
            // 
            // lblCodeReq
            // 
            this.lblCodeReq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCodeReq.AutoSize = true;
            this.lblCodeReq.ForeColor = System.Drawing.Color.Red;
            this.lblCodeReq.Location = new System.Drawing.Point(375, 90);
            this.lblCodeReq.Name = "lblCodeReq";
            this.lblCodeReq.Size = new System.Drawing.Size(11, 12);
            this.lblCodeReq.TabIndex = 8;
            this.lblCodeReq.Text = "*";
            // 
            // txtCode
            // 
            this.txtCode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCode.Location = new System.Drawing.Point(99, 85);
            this.txtCode.MaxLength = 50;
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(270, 21);
            this.txtCode.TabIndex = 7;
            // 
            // lblCode
            // 
            this.lblCode.Location = new System.Drawing.Point(12, 88);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(75, 12);
            this.lblCode.TabIndex = 6;
            this.lblCode.Text = "编号(&C)：";
            this.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnSave.Location = new System.Drawing.Point(215, 232);
            this.btnSave.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(74, 23);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "保存(&S)";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnLeadership
            // 
            this.btnLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLeadership.Location = new System.Drawing.Point(10, 271);
            this.btnLeadership.Name = "btnLeadership";
            this.btnLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnLeadership.TabIndex = 15;
            this.btnLeadership.Text = "领导";
            this.btnLeadership.UseVisualStyleBackColor = true;
            this.btnLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAssistantLeadership
            // 
            this.btnAssistantLeadership.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantLeadership.Location = new System.Drawing.Point(103, 271);
            this.btnAssistantLeadership.Name = "btnAssistantLeadership";
            this.btnAssistantLeadership.Size = new System.Drawing.Size(91, 23);
            this.btnAssistantLeadership.TabIndex = 16;
            this.btnAssistantLeadership.Text = "分管领导";
            this.btnAssistantLeadership.UseVisualStyleBackColor = true;
            this.btnAssistantLeadership.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnManager
            // 
            this.btnManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManager.Location = new System.Drawing.Point(196, 271);
            this.btnManager.Name = "btnManager";
            this.btnManager.Size = new System.Drawing.Size(91, 23);
            this.btnManager.TabIndex = 17;
            this.btnManager.Text = "主管";
            this.btnManager.UseVisualStyleBackColor = true;
            this.btnManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAssistantManager
            // 
            this.btnAssistantManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssistantManager.Location = new System.Drawing.Point(289, 271);
            this.btnAssistantManager.Name = "btnAssistantManager";
            this.btnAssistantManager.Size = new System.Drawing.Size(91, 23);
            this.btnAssistantManager.TabIndex = 18;
            this.btnAssistantManager.Text = "副主管";
            this.btnAssistantManager.UseVisualStyleBackColor = true;
            this.btnAssistantManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnAccounting
            // 
            this.btnAccounting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAccounting.Location = new System.Drawing.Point(103, 296);
            this.btnAccounting.Name = "btnAccounting";
            this.btnAccounting.Size = new System.Drawing.Size(91, 23);
            this.btnAccounting.TabIndex = 20;
            this.btnAccounting.Text = "会计";
            this.btnAccounting.UseVisualStyleBackColor = true;
            this.btnAccounting.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnCashier
            // 
            this.btnCashier.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCashier.Location = new System.Drawing.Point(196, 296);
            this.btnCashier.Name = "btnCashier";
            this.btnCashier.Size = new System.Drawing.Size(91, 23);
            this.btnCashier.TabIndex = 21;
            this.btnCashier.Text = "出纳";
            this.btnCashier.UseVisualStyleBackColor = true;
            this.btnCashier.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnFinancial
            // 
            this.btnFinancial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinancial.Location = new System.Drawing.Point(10, 296);
            this.btnFinancial.Name = "btnFinancial";
            this.btnFinancial.Size = new System.Drawing.Size(91, 23);
            this.btnFinancial.TabIndex = 19;
            this.btnFinancial.Text = "财务主管";
            this.btnFinancial.UseVisualStyleBackColor = true;
            this.btnFinancial.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // btnSystemManager
            // 
            this.btnSystemManager.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSystemManager.Location = new System.Drawing.Point(289, 296);
            this.btnSystemManager.Name = "btnSystemManager";
            this.btnSystemManager.Size = new System.Drawing.Size(91, 23);
            this.btnSystemManager.TabIndex = 22;
            this.btnSystemManager.Text = "系统管理员";
            this.btnSystemManager.UseVisualStyleBackColor = true;
            this.btnSystemManager.Click += new System.EventHandler(this.btnRole_Click);
            // 
            // FrmOrganizeRoleAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(391, 330);
            this.Controls.Add(this.btnSystemManager);
            this.Controls.Add(this.btnAccounting);
            this.Controls.Add(this.btnCashier);
            this.Controls.Add(this.btnFinancial);
            this.Controls.Add(this.btnAssistantManager);
            this.Controls.Add(this.btnManager);
            this.Controls.Add(this.btnAssistantLeadership);
            this.Controls.Add(this.btnLeadership);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblCodeReq);
            this.Controls.Add(this.txtCode);
            this.Controls.Add(this.lblCode);
            this.Controls.Add(this.ucOrganize);
            this.Controls.Add(this.lblFullNameReq);
            this.Controls.Add(this.lblOrganizeReq);
            this.Controls.Add(this.lblOrganize);
            this.Controls.Add(this.txtRealName);
            this.Controls.Add(this.lblFullName);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmOrganizeRoleAdd";
            this.Text = "添加岗位";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmOrganizeRoleAdd_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRealName;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Label lblOrganize;
        private System.Windows.Forms.Label lblFullNameReq;
        private System.Windows.Forms.Label lblOrganizeReq;
        private DotNet.WinForm.UCOrganizeSelect ucOrganize;
        private System.Windows.Forms.Label lblCodeReq;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLeadership;
        private System.Windows.Forms.Button btnAssistantLeadership;
        private System.Windows.Forms.Button btnManager;
        private System.Windows.Forms.Button btnAssistantManager;
        private System.Windows.Forms.Button btnAccounting;
        private System.Windows.Forms.Button btnCashier;
        private System.Windows.Forms.Button btnFinancial;
        private System.Windows.Forms.Button btnSystemManager;


    }
}