namespace DotNet.WinForm
{
    partial class FrmWorkFlowWaitForAudit
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnClose = new System.Windows.Forms.Button();
            this.grdWorkFlowCurrent = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colObjectFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSendDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditIder = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToDepartmentName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToRoleRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colToUserRealName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colAuditState = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ucFreeWorkFlow = new DotNet.WinForm.UCFreeWorkFlow();
            this.ucAutoWorkFlow = new DotNet.WinForm.UCAutoWorkFlow();
            this.rbByUser = new System.Windows.Forms.RadioButton();
            this.rbByRole = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlowCurrent)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(825, 521);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "取消";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // grdWorkFlowCurrent
            // 
            this.grdWorkFlowCurrent.AllowUserToAddRows = false;
            this.grdWorkFlowCurrent.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(168)))), ((int)(((byte)(255)))));
            this.grdWorkFlowCurrent.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.grdWorkFlowCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdWorkFlowCurrent.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdWorkFlowCurrent.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.grdWorkFlowCurrent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdWorkFlowCurrent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colObjectFullName,
            this.colSendDate,
            this.colAuditUserRealName,
            this.colAuditIder,
            this.colToDepartmentName,
            this.colToRoleRealName,
            this.colToUserRealName,
            this.colAuditState});
            this.grdWorkFlowCurrent.Location = new System.Drawing.Point(6, 11);
            this.grdWorkFlowCurrent.MultiSelect = false;
            this.grdWorkFlowCurrent.Name = "grdWorkFlowCurrent";
            this.grdWorkFlowCurrent.RowTemplate.Height = 23;
            this.grdWorkFlowCurrent.Size = new System.Drawing.Size(895, 467);
            this.grdWorkFlowCurrent.TabIndex = 0;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.FillWeight = 50F;
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colObjectFullName
            // 
            this.colObjectFullName.DataPropertyName = "ObjectFullName";
            this.colObjectFullName.FillWeight = 120F;
            this.colObjectFullName.Frozen = true;
            this.colObjectFullName.HeaderText = "名称";
            this.colObjectFullName.Name = "colObjectFullName";
            this.colObjectFullName.ReadOnly = true;
            this.colObjectFullName.Width = 120;
            // 
            // colSendDate
            // 
            this.colSendDate.DataPropertyName = "AuditDate";
            this.colSendDate.FillWeight = 110F;
            this.colSendDate.Frozen = true;
            this.colSendDate.HeaderText = "审核日期";
            this.colSendDate.MaxInputLength = 50;
            this.colSendDate.Name = "colSendDate";
            this.colSendDate.ReadOnly = true;
            this.colSendDate.Width = 110;
            // 
            // colAuditUserRealName
            // 
            this.colAuditUserRealName.DataPropertyName = "AuditUserRealName";
            this.colAuditUserRealName.HeaderText = "审核人";
            this.colAuditUserRealName.MaxInputLength = 20;
            this.colAuditUserRealName.Name = "colAuditUserRealName";
            this.colAuditUserRealName.ReadOnly = true;
            this.colAuditUserRealName.Width = 80;
            // 
            // colAuditIder
            // 
            this.colAuditIder.DataPropertyName = "AuditIdea";
            this.colAuditIder.FillWeight = 150F;
            this.colAuditIder.HeaderText = "批示";
            this.colAuditIder.MaxInputLength = 600;
            this.colAuditIder.Name = "colAuditIder";
            this.colAuditIder.ReadOnly = true;
            this.colAuditIder.Width = 150;
            // 
            // colToDepartmentName
            // 
            this.colToDepartmentName.DataPropertyName = "ToDepartmentName";
            this.colToDepartmentName.FillWeight = 80F;
            this.colToDepartmentName.HeaderText = "待审部门";
            this.colToDepartmentName.MaxInputLength = 50;
            this.colToDepartmentName.Name = "colToDepartmentName";
            this.colToDepartmentName.ReadOnly = true;
            this.colToDepartmentName.Width = 80;
            // 
            // colToRoleRealName
            // 
            this.colToRoleRealName.DataPropertyName = "ToRoleRealName";
            this.colToRoleRealName.FillWeight = 80F;
            this.colToRoleRealName.HeaderText = "待审角色";
            this.colToRoleRealName.Name = "colToRoleRealName";
            this.colToRoleRealName.ReadOnly = true;
            this.colToRoleRealName.Width = 80;
            // 
            // colToUserRealName
            // 
            this.colToUserRealName.DataPropertyName = "ToUserRealName";
            this.colToUserRealName.FillWeight = 80F;
            this.colToUserRealName.HeaderText = "待审人";
            this.colToUserRealName.MaxInputLength = 50;
            this.colToUserRealName.Name = "colToUserRealName";
            this.colToUserRealName.ReadOnly = true;
            this.colToUserRealName.Width = 80;
            // 
            // colAuditState
            // 
            this.colAuditState.DataPropertyName = "AuditState";
            this.colAuditState.FillWeight = 80F;
            this.colAuditState.HeaderText = "审核状态";
            this.colAuditState.MaxInputLength = 200;
            this.colAuditState.Name = "colAuditState";
            this.colAuditState.ReadOnly = true;
            this.colAuditState.Width = 80;
            // 
            // ucFreeWorkFlow
            // 
            this.ucFreeWorkFlow.AllowNull = false;
            this.ucFreeWorkFlow.AllowSelect = true;
            this.ucFreeWorkFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucFreeWorkFlow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucFreeWorkFlow.Location = new System.Drawing.Point(3, 521);
            this.ucFreeWorkFlow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ucFreeWorkFlow.MultiSelect = true;
            this.ucFreeWorkFlow.Name = "ucFreeWorkFlow";
            this.ucFreeWorkFlow.OpenId = "";
            this.ucFreeWorkFlow.PermissionAuditing = false;
            this.ucFreeWorkFlow.PermissionItemScopeCode = "";
            this.ucFreeWorkFlow.RemoveIds = null;
            this.ucFreeWorkFlow.SelectedFullName = "";
            this.ucFreeWorkFlow.SelectedId = "";
            this.ucFreeWorkFlow.SelectedIds = null;
            this.ucFreeWorkFlow.SetSelectIds = null;
            this.ucFreeWorkFlow.ShowAuditDetail = true;
            this.ucFreeWorkFlow.ShowAuditIdea = true;
            this.ucFreeWorkFlow.ShowAuditQuash = true;
            this.ucFreeWorkFlow.ShowAuditReject = true;
            this.ucFreeWorkFlow.ShowSendTo = true;
            this.ucFreeWorkFlow.Size = new System.Drawing.Size(688, 23);
            this.ucFreeWorkFlow.TabIndex = 4;
            this.ucFreeWorkFlow.WorkFlowCategory = "ByRole";
            this.ucFreeWorkFlow.BeforBtnAuditPassClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditPassClickEventHandler(this.ucWorkFlowUser_BeforBtnAuditPassClick);
            this.ucFreeWorkFlow.AfterBtnAuditPassClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditPassClickEventHandler(this.ucWorkFlowUser_AfterBtnAuditPassClick);
            this.ucFreeWorkFlow.BeforBtnAuditRejectClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditRejectClickEventHandler(this.ucWorkFlowUser_BeforBtnAuditRejectClick);
            this.ucFreeWorkFlow.AfterBtnAuditRejectClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditRejectClickEventHandler(this.ucWorkFlowUser_AfterBtnAuditRejectClick);
            this.ucFreeWorkFlow.BeforBtnTransmitClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonTransmitClickEventHandler(this.ucWorkFlowUser_BeforBtnTransmitClick);
            this.ucFreeWorkFlow.AfterBtnTransmitClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonTransmitClickEventHandler(this.ucWorkFlowUser_AfterBtnTransmitClick);
            this.ucFreeWorkFlow.BeforBtnAuditCompleteClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditCompleteClickEventHandler(this.ucWorkFlowUser_BeforBtnAuditCompleteClick);
            this.ucFreeWorkFlow.AfterBtnAuditCompleteClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditCompleteClickEventHandler(this.ucWorkFlowUser_AfterBtnAuditCompleteClick);
            this.ucFreeWorkFlow.BeforBtnAuditQuashClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditQuashClickEventHandler(this.ucWorkFlowUser_BeforBtnAuditQuashClick);
            this.ucFreeWorkFlow.AfterBtnAuditQuashClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditQuashClickEventHandler(this.ucWorkFlowUser_AfterBtnAuditQuashClick);
            this.ucFreeWorkFlow.BeforBtnAuditDetailClick += new DotNet.WinForm.UCFreeWorkFlow.ButtonAuditDetailClickEventHandler(this.ucWorkFlowUser_BeforBtnAuditDetailClick);
            // 
            // ucAutoWorkFlow
            // 
            this.ucAutoWorkFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucAutoWorkFlow.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucAutoWorkFlow.Location = new System.Drawing.Point(328, 489);
            this.ucAutoWorkFlow.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ucAutoWorkFlow.Name = "ucAutoWorkFlow";
            this.ucAutoWorkFlow.SelectedIds = null;
            this.ucAutoWorkFlow.SetSelectIds = null;
            this.ucAutoWorkFlow.ShowAuditDetail = true;
            this.ucAutoWorkFlow.ShowAuditIdea = true;
            this.ucAutoWorkFlow.ShowAuditReject = true;
            this.ucAutoWorkFlow.Size = new System.Drawing.Size(366, 23);
            this.ucAutoWorkFlow.TabIndex = 3;
            this.ucAutoWorkFlow.WorkFlowCategory = "ByRole";
            this.ucAutoWorkFlow.BeforBtnAuditPassClick += new DotNet.WinForm.UCAutoWorkFlow.ButtonAuditPassClickEventHandler(this.ucAutoWorkFlow_BeforBtnAuditPassClick);
            this.ucAutoWorkFlow.AfterBtnAuditPassClick += new DotNet.WinForm.UCAutoWorkFlow.ButtonAuditPassClickEventHandler(this.ucAutoWorkFlow_AfterBtnAuditPassClick);
            // 
            // rbByUser
            // 
            this.rbByUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbByUser.AutoSize = true;
            this.rbByUser.Location = new System.Drawing.Point(156, 491);
            this.rbByUser.Name = "rbByUser";
            this.rbByUser.Size = new System.Drawing.Size(125, 16);
            this.rbByUser.TabIndex = 2;
            this.rbByUser.Text = "ByUser 按用户审核";
            this.rbByUser.UseVisualStyleBackColor = true;
            this.rbByUser.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // rbByRole
            // 
            this.rbByRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rbByRole.AutoSize = true;
            this.rbByRole.Checked = true;
            this.rbByRole.Location = new System.Drawing.Point(11, 491);
            this.rbByRole.Name = "rbByRole";
            this.rbByRole.Size = new System.Drawing.Size(125, 16);
            this.rbByRole.TabIndex = 1;
            this.rbByRole.TabStop = true;
            this.rbByRole.Text = "ByRole 按角色审核";
            this.rbByRole.UseVisualStyleBackColor = true;
            this.rbByRole.CheckedChanged += new System.EventHandler(this.rb_CheckedChanged);
            // 
            // FrmWorkFlowWaitForAudit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(909, 553);
            this.Controls.Add(this.rbByUser);
            this.Controls.Add(this.rbByRole);
            this.Controls.Add(this.ucAutoWorkFlow);
            this.Controls.Add(this.ucFreeWorkFlow);
            this.Controls.Add(this.grdWorkFlowCurrent);
            this.Controls.Add(this.btnClose);
            this.Name = "FrmWorkFlowWaitForAudit";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "待审批流程";
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkFlowCurrent)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.DataGridView grdWorkFlowCurrent;
        private UCFreeWorkFlow ucFreeWorkFlow;
        private UCAutoWorkFlow ucAutoWorkFlow;
        private System.Windows.Forms.RadioButton rbByUser;
        private System.Windows.Forms.RadioButton rbByRole;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colObjectFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colSendDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditIder;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToDepartmentName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToRoleRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colToUserRealName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colAuditState;
    }
}