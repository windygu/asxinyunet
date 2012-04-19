namespace DotNet.WinForm
{
    partial class FrmItemDetailsAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grdItemDetails = new System.Windows.Forms.DataGridView();
            this.lblContents = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnUserResourcePermission = new System.Windows.Forms.Button();
            this.btnRoleResourcePermission = new System.Windows.Forms.Button();
            this.labelTarget = new System.Windows.Forms.Label();
            this.txtTargetTable = new System.Windows.Forms.TextBox();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colItemCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colItemValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEnabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.grdItemDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Location = new System.Drawing.Point(680, 553);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(75, 23);
            this.btnBatchSave.TabIndex = 11;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Location = new System.Drawing.Point(602, 553);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(75, 23);
            this.btnBatchDelete.TabIndex = 10;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Location = new System.Drawing.Point(410, 553);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 23);
            this.btnEdit.TabIndex = 8;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(758, 553);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Location = new System.Drawing.Point(332, 553);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 7;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grdItemDetails
            // 
            this.grdItemDetails.AllowUserToAddRows = false;
            this.grdItemDetails.AllowUserToDeleteRows = false;
            this.grdItemDetails.AllowUserToOrderColumns = true;
            this.grdItemDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdItemDetails.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdItemDetails.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdItemDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdItemDetails.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colItemCode,
            this.colItemName,
            this.colItemValue,
            this.colEnabled,
            this.colDescription});
            this.grdItemDetails.Location = new System.Drawing.Point(8, 41);
            this.grdItemDetails.MultiSelect = false;
            this.grdItemDetails.Name = "grdItemDetails";
            this.grdItemDetails.RowTemplate.Height = 23;
            this.grdItemDetails.Size = new System.Drawing.Size(826, 506);
            this.grdItemDetails.TabIndex = 5;
            this.grdItemDetails.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdItemDetails_CellDoubleClick);
            this.grdItemDetails.Sorted += new System.EventHandler(this.grdItemDetails_Sorted);
            this.grdItemDetails.UserDeletingRow += new System.Windows.Forms.DataGridViewRowCancelEventHandler(this.grdItemDetails_UserDeletingRow);
            // 
            // lblContents
            // 
            this.lblContents.Location = new System.Drawing.Point(8, 14);
            this.lblContents.Name = "lblContents";
            this.lblContents.Size = new System.Drawing.Size(73, 12);
            this.lblContents.TabIndex = 2;
            this.lblContents.Text = "查询内容(&C)：";
            this.lblContents.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(85, 10);
            this.txtSearch.MaxLength = 20;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(160, 21);
            this.txtSearch.TabIndex = 3;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Enabled = false;
            this.ucTableSort.Location = new System.Drawing.Point(8, 552);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = true;
            this.ucTableSort.SetDownEnabled = true;
            this.ucTableSort.SetTopEnabled = true;
            this.ucTableSort.SetUpEnabled = true;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 6;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Location = new System.Drawing.Point(488, 553);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(111, 23);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnUserResourcePermission
            // 
            this.btnUserResourcePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserResourcePermission.Enabled = false;
            this.btnUserResourcePermission.Location = new System.Drawing.Point(700, 10);
            this.btnUserResourcePermission.Name = "btnUserResourcePermission";
            this.btnUserResourcePermission.Size = new System.Drawing.Size(135, 23);
            this.btnUserResourcePermission.TabIndex = 1;
            this.btnUserResourcePermission.Text = "用户权限...";
            this.btnUserResourcePermission.UseVisualStyleBackColor = true;
            this.btnUserResourcePermission.Visible = false;
            this.btnUserResourcePermission.Click += new System.EventHandler(this.btnUserResourcePermission_Click);
            // 
            // btnRoleResourcePermission
            // 
            this.btnRoleResourcePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRoleResourcePermission.Enabled = false;
            this.btnRoleResourcePermission.Location = new System.Drawing.Point(562, 10);
            this.btnRoleResourcePermission.Name = "btnRoleResourcePermission";
            this.btnRoleResourcePermission.Size = new System.Drawing.Size(135, 23);
            this.btnRoleResourcePermission.TabIndex = 0;
            this.btnRoleResourcePermission.Text = "角色权限...";
            this.btnRoleResourcePermission.UseVisualStyleBackColor = true;
            this.btnRoleResourcePermission.Visible = false;
            this.btnRoleResourcePermission.Click += new System.EventHandler(this.btnRoleResourcePermission_Click);
            // 
            // labelTarget
            // 
            this.labelTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelTarget.Location = new System.Drawing.Point(274, 14);
            this.labelTarget.Name = "labelTarget";
            this.labelTarget.Size = new System.Drawing.Size(73, 12);
            this.labelTarget.TabIndex = 13;
            this.labelTarget.Text = "目标表(&T)：";
            this.labelTarget.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtTargetTable
            // 
            this.txtTargetTable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetTable.Location = new System.Drawing.Point(351, 10);
            this.txtTargetTable.MaxLength = 20;
            this.txtTargetTable.Name = "txtTargetTable";
            this.txtTargetTable.ReadOnly = true;
            this.txtTargetTable.Size = new System.Drawing.Size(203, 21);
            this.txtTargetTable.TabIndex = 14;
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colItemCode
            // 
            this.colItemCode.DataPropertyName = "ItemCode";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colItemCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.colItemCode.FillWeight = 180F;
            this.colItemCode.HeaderText = "编号";
            this.colItemCode.MaxInputLength = 20;
            this.colItemCode.Name = "colItemCode";
            this.colItemCode.Width = 180;
            // 
            // colItemName
            // 
            this.colItemName.DataPropertyName = "ItemName";
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colItemName.DefaultCellStyle = dataGridViewCellStyle3;
            this.colItemName.FillWeight = 180F;
            this.colItemName.HeaderText = "名称";
            this.colItemName.MaxInputLength = 80;
            this.colItemName.Name = "colItemName";
            this.colItemName.Width = 180;
            // 
            // colItemValue
            // 
            this.colItemValue.DataPropertyName = "ItemValue";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colItemValue.DefaultCellStyle = dataGridViewCellStyle4;
            this.colItemValue.HeaderText = "值";
            this.colItemValue.MaxInputLength = 100;
            this.colItemValue.Name = "colItemValue";
            this.colItemValue.Width = 140;
            // 
            // colEnabled
            // 
            this.colEnabled.DataPropertyName = "Enabled";
            this.colEnabled.HeaderText = "有效";
            this.colEnabled.Name = "colEnabled";
            this.colEnabled.ReadOnly = true;
            this.colEnabled.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.colEnabled.Width = 60;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle5;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 150;
            // 
            // FrmItemDetailsAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(844, 580);
            this.Controls.Add(this.labelTarget);
            this.Controls.Add(this.txtTargetTable);
            this.Controls.Add(this.btnUserResourcePermission);
            this.Controls.Add(this.btnRoleResourcePermission);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.lblContents);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.grdItemDetails);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmItemDetailsAdmin";
            this.Text = "选项明细管理";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmItemDetailsAdmin_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.grdItemDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.DataGridView grdItemDetails;
        private System.Windows.Forms.Label lblContents;
        private System.Windows.Forms.TextBox txtSearch;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnUserResourcePermission;
        private System.Windows.Forms.Button btnRoleResourcePermission;
        private System.Windows.Forms.Label labelTarget;
        private System.Windows.Forms.TextBox txtTargetTable;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colItemValue;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colEnabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
    }
}