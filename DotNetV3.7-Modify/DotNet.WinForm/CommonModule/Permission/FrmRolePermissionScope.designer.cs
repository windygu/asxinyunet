namespace DotNet.WinForm
{
    partial class FrmRolePermissionScope
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRolePermissionScope));
            this.btnInvertSelect = new System.Windows.Forms.Button();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.tvOrganize = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.lblRoleReq = new System.Windows.Forms.Label();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblPermissionScopeReq = new System.Windows.Forms.Label();
            this.ucPermissionScope = new DotNet.WinForm.UCScopePermissionSelect();
            this.lblPermissionScope = new System.Windows.Forms.Label();
            this.ucRole = new DotNet.WinForm.UCRoleSelect();
            this.grbPermissionScope = new System.Windows.Forms.GroupBox();
            this.rdbUserSubOrg = new System.Windows.Forms.RadioButton();
            this.rdbNone = new System.Windows.Forms.RadioButton();
            this.rdbDetail = new System.Windows.Forms.RadioButton();
            this.rdbUser = new System.Windows.Forms.RadioButton();
            this.rdbUserWorkgroup = new System.Windows.Forms.RadioButton();
            this.rdbUserDepartment = new System.Windows.Forms.RadioButton();
            this.rdbUserCompany = new System.Windows.Forms.RadioButton();
            this.rdbAll = new System.Windows.Forms.RadioButton();
            this.chkInnerOrganize = new System.Windows.Forms.CheckBox();
            this.grbPermissionScope.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnInvertSelect
            // 
            this.btnInvertSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnInvertSelect.Location = new System.Drawing.Point(116, 507);
            this.btnInvertSelect.Margin = new System.Windows.Forms.Padding(4);
            this.btnInvertSelect.Name = "btnInvertSelect";
            this.btnInvertSelect.Size = new System.Drawing.Size(133, 23);
            this.btnInvertSelect.TabIndex = 11;
            this.btnInvertSelect.Text = "反选(&I)";
            this.btnInvertSelect.UseVisualStyleBackColor = true;
            this.btnInvertSelect.Click += new System.EventHandler(this.btnInvertSelect_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Location = new System.Drawing.Point(6, 507);
            this.btnSelectAll.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(102, 23);
            this.btnSelectAll.TabIndex = 10;
            this.btnSelectAll.Text = "全选(&A)";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(603, 507);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 9;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(524, 507);
            this.btnBatchSave.Margin = new System.Windows.Forms.Padding(4);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 8;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // tvOrganize
            // 
            this.tvOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tvOrganize.CheckBoxes = true;
            this.tvOrganize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.tvOrganize.ImageIndex = 0;
            this.tvOrganize.ImageList = this.imageList;
            this.tvOrganize.Location = new System.Drawing.Point(7, 135);
            this.tvOrganize.Name = "tvOrganize";
            this.tvOrganize.SelectedImageIndex = 0;
            this.tvOrganize.Size = new System.Drawing.Size(671, 365);
            this.tvOrganize.TabIndex = 7;
            this.tvOrganize.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.tvOrganize_NodeMouseClick);
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "");
            this.imageList.Images.SetKeyName(1, "");
            this.imageList.Images.SetKeyName(2, "");
            this.imageList.Images.SetKeyName(3, "");
            this.imageList.Images.SetKeyName(4, "");
            this.imageList.Images.SetKeyName(5, "");
            this.imageList.Images.SetKeyName(6, "");
            this.imageList.Images.SetKeyName(7, "");
            this.imageList.Images.SetKeyName(8, "");
            this.imageList.Images.SetKeyName(9, "");
            this.imageList.Images.SetKeyName(10, "");
            this.imageList.Images.SetKeyName(11, "");
            this.imageList.Images.SetKeyName(12, "");
            this.imageList.Images.SetKeyName(13, "");
            this.imageList.Images.SetKeyName(14, "");
            this.imageList.Images.SetKeyName(15, "icon_messenger1.gif");
            this.imageList.Images.SetKeyName(16, "icon_messenger0.gif");
            this.imageList.Images.SetKeyName(17, "icon_messenger2.gif");
            this.imageList.Images.SetKeyName(18, "icon_messenger3.gif");
            this.imageList.Images.SetKeyName(19, "icon_messenger4.gif");
            this.imageList.Images.SetKeyName(20, "icon_messenger5.gif");
            this.imageList.Images.SetKeyName(21, "icon_messenger6.gif");
            this.imageList.Images.SetKeyName(22, "Role.gif");
            // 
            // lblRoleReq
            // 
            this.lblRoleReq.AutoSize = true;
            this.lblRoleReq.ForeColor = System.Drawing.Color.Red;
            this.lblRoleReq.Location = new System.Drawing.Point(442, 18);
            this.lblRoleReq.Name = "lblRoleReq";
            this.lblRoleReq.Size = new System.Drawing.Size(11, 12);
            this.lblRoleReq.TabIndex = 2;
            this.lblRoleReq.Text = "*";
            // 
            // lblRole
            // 
            this.lblRole.Location = new System.Drawing.Point(8, 18);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(119, 12);
            this.lblRole.TabIndex = 0;
            this.lblRole.Text = "角色：";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblPermissionScopeReq
            // 
            this.lblPermissionScopeReq.AutoSize = true;
            this.lblPermissionScopeReq.ForeColor = System.Drawing.Color.Red;
            this.lblPermissionScopeReq.Location = new System.Drawing.Point(442, 50);
            this.lblPermissionScopeReq.Name = "lblPermissionScopeReq";
            this.lblPermissionScopeReq.Size = new System.Drawing.Size(11, 12);
            this.lblPermissionScopeReq.TabIndex = 5;
            this.lblPermissionScopeReq.Text = "*";
            // 
            // ucPermissionScope
            // 
            this.ucPermissionScope.AllowNull = true;
            this.ucPermissionScope.AllowSelect = false;
            this.ucPermissionScope.Location = new System.Drawing.Point(130, 43);
            this.ucPermissionScope.MultiSelect = false;
            this.ucPermissionScope.Name = "ucPermissionScope";
            this.ucPermissionScope.SelectedFullName = "";
            this.ucPermissionScope.SelectedId = "";
            this.ucPermissionScope.Size = new System.Drawing.Size(305, 22);
            this.ucPermissionScope.TabIndex = 4;
            // 
            // lblPermissionScope
            // 
            this.lblPermissionScope.Location = new System.Drawing.Point(10, 46);
            this.lblPermissionScope.Name = "lblPermissionScope";
            this.lblPermissionScope.Size = new System.Drawing.Size(117, 12);
            this.lblPermissionScope.TabIndex = 3;
            this.lblPermissionScope.Text = "数据权限：";
            this.lblPermissionScope.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ucRole
            // 
            this.ucRole.AllowNull = true;
            this.ucRole.AllowSelect = false;
            this.ucRole.Location = new System.Drawing.Point(130, 12);
            this.ucRole.MultiSelect = false;
            this.ucRole.Name = "ucRole";
            this.ucRole.OpenId = "";
            this.ucRole.PermissionItemScopeCode = "";
            this.ucRole.RemoveIds = null;
            this.ucRole.SelectedFullName = "";
            this.ucRole.SelectedId = "";
            this.ucRole.SelectedIds = null;
            this.ucRole.ShowRoleOnly = true;
            this.ucRole.Size = new System.Drawing.Size(305, 22);
            this.ucRole.TabIndex = 1;
            // 
            // grbPermissionScope
            // 
            this.grbPermissionScope.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbPermissionScope.Controls.Add(this.rdbUserSubOrg);
            this.grbPermissionScope.Controls.Add(this.rdbNone);
            this.grbPermissionScope.Controls.Add(this.rdbDetail);
            this.grbPermissionScope.Controls.Add(this.rdbUser);
            this.grbPermissionScope.Controls.Add(this.rdbUserWorkgroup);
            this.grbPermissionScope.Controls.Add(this.rdbUserDepartment);
            this.grbPermissionScope.Controls.Add(this.rdbUserCompany);
            this.grbPermissionScope.Controls.Add(this.rdbAll);
            this.grbPermissionScope.Location = new System.Drawing.Point(8, 72);
            this.grbPermissionScope.Name = "grbPermissionScope";
            this.grbPermissionScope.Size = new System.Drawing.Size(670, 46);
            this.grbPermissionScope.TabIndex = 12;
            this.grbPermissionScope.TabStop = false;
            this.grbPermissionScope.Text = "权限范围";
            // 
            // rdbUserSubOrg
            // 
            this.rdbUserSubOrg.AutoSize = true;
            this.rdbUserSubOrg.Location = new System.Drawing.Point(176, 20);
            this.rdbUserSubOrg.Name = "rdbUserSubOrg";
            this.rdbUserSubOrg.Size = new System.Drawing.Size(95, 16);
            this.rdbUserSubOrg.TabIndex = 7;
            this.rdbUserSubOrg.Text = "所在分支机构";
            this.rdbUserSubOrg.UseVisualStyleBackColor = true;
            // 
            // rdbNone
            // 
            this.rdbNone.AutoSize = true;
            this.rdbNone.Location = new System.Drawing.Point(622, 20);
            this.rdbNone.Name = "rdbNone";
            this.rdbNone.Size = new System.Drawing.Size(35, 16);
            this.rdbNone.TabIndex = 6;
            this.rdbNone.Text = "无";
            this.rdbNone.UseVisualStyleBackColor = true;
            // 
            // rdbDetail
            // 
            this.rdbDetail.AutoSize = true;
            this.rdbDetail.Checked = true;
            this.rdbDetail.Location = new System.Drawing.Point(528, 20);
            this.rdbDetail.Name = "rdbDetail";
            this.rdbDetail.Size = new System.Drawing.Size(83, 16);
            this.rdbDetail.TabIndex = 5;
            this.rdbDetail.TabStop = true;
            this.rdbDetail.Text = "按明细设置";
            this.rdbDetail.UseVisualStyleBackColor = true;
            // 
            // rdbUser
            // 
            this.rdbUser.AutoSize = true;
            this.rdbUser.Location = new System.Drawing.Point(458, 20);
            this.rdbUser.Name = "rdbUser";
            this.rdbUser.Size = new System.Drawing.Size(59, 16);
            this.rdbUser.TabIndex = 4;
            this.rdbUser.Text = "仅本人";
            this.rdbUser.UseVisualStyleBackColor = true;
            // 
            // rdbUserWorkgroup
            // 
            this.rdbUserWorkgroup.AutoSize = true;
            this.rdbUserWorkgroup.Location = new System.Drawing.Point(364, 20);
            this.rdbUserWorkgroup.Name = "rdbUserWorkgroup";
            this.rdbUserWorkgroup.Size = new System.Drawing.Size(83, 16);
            this.rdbUserWorkgroup.TabIndex = 3;
            this.rdbUserWorkgroup.Text = "所在工作组";
            this.rdbUserWorkgroup.UseVisualStyleBackColor = true;
            // 
            // rdbUserDepartment
            // 
            this.rdbUserDepartment.AutoSize = true;
            this.rdbUserDepartment.Location = new System.Drawing.Point(282, 20);
            this.rdbUserDepartment.Name = "rdbUserDepartment";
            this.rdbUserDepartment.Size = new System.Drawing.Size(71, 16);
            this.rdbUserDepartment.TabIndex = 2;
            this.rdbUserDepartment.Text = "所在部门";
            this.rdbUserDepartment.UseVisualStyleBackColor = true;
            // 
            // rdbUserCompany
            // 
            this.rdbUserCompany.AutoSize = true;
            this.rdbUserCompany.Location = new System.Drawing.Point(94, 20);
            this.rdbUserCompany.Name = "rdbUserCompany";
            this.rdbUserCompany.Size = new System.Drawing.Size(71, 16);
            this.rdbUserCompany.TabIndex = 1;
            this.rdbUserCompany.Text = "所在公司";
            this.rdbUserCompany.UseVisualStyleBackColor = true;
            // 
            // rdbAll
            // 
            this.rdbAll.AutoSize = true;
            this.rdbAll.Location = new System.Drawing.Point(12, 20);
            this.rdbAll.Name = "rdbAll";
            this.rdbAll.Size = new System.Drawing.Size(71, 16);
            this.rdbAll.TabIndex = 0;
            this.rdbAll.Text = "所有数据";
            this.rdbAll.UseVisualStyleBackColor = true;
            // 
            // chkInnerOrganize
            // 
            this.chkInnerOrganize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkInnerOrganize.AutoSize = true;
            this.chkInnerOrganize.Checked = true;
            this.chkInnerOrganize.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInnerOrganize.Location = new System.Drawing.Point(541, 31);
            this.chkInnerOrganize.Name = "chkInnerOrganize";
            this.chkInnerOrganize.Size = new System.Drawing.Size(132, 16);
            this.chkInnerOrganize.TabIndex = 13;
            this.chkInnerOrganize.Text = "只显示内部组织机构";
            this.chkInnerOrganize.UseVisualStyleBackColor = true;
            this.chkInnerOrganize.CheckedChanged += new System.EventHandler(this.chkInnerOrganize_CheckedChanged);
            // 
            // FrmRolePermissionScope
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(684, 536);
            this.Controls.Add(this.chkInnerOrganize);
            this.Controls.Add(this.grbPermissionScope);
            this.Controls.Add(this.ucRole);
            this.Controls.Add(this.lblRoleReq);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.lblPermissionScopeReq);
            this.Controls.Add(this.ucPermissionScope);
            this.Controls.Add(this.lblPermissionScope);
            this.Controls.Add(this.btnInvertSelect);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.tvOrganize);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmRolePermissionScope";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "角色数据权限设置";
            this.Load += new System.EventHandler(this.FrmRolePermissionScope_Load);
            this.grbPermissionScope.ResumeLayout(false);
            this.grbPermissionScope.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnInvertSelect;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.TreeView tvOrganize;
        private System.Windows.Forms.Label lblRoleReq;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblPermissionScopeReq;
        private DotNet.WinForm.UCScopePermissionSelect ucPermissionScope;
        private System.Windows.Forms.Label lblPermissionScope;
        private DotNet.WinForm.UCRoleSelect ucRole;
        private System.Windows.Forms.GroupBox grbPermissionScope;
        private System.Windows.Forms.RadioButton rdbNone;
        private System.Windows.Forms.RadioButton rdbDetail;
        private System.Windows.Forms.RadioButton rdbUser;
        private System.Windows.Forms.RadioButton rdbUserWorkgroup;
        private System.Windows.Forms.RadioButton rdbUserDepartment;
        private System.Windows.Forms.RadioButton rdbUserCompany;
        private System.Windows.Forms.RadioButton rdbAll;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.RadioButton rdbUserSubOrg;
        private System.Windows.Forms.CheckBox chkInnerOrganize;
    }
}