namespace DotNet.WinForm
{
    partial class FrmPermissionItemAdmin
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPermissionItemAdmin));
            this.btnMove = new System.Windows.Forms.Button();
            this.pnlPermission = new System.Windows.Forms.Panel();
            this.grdPermission = new System.Windows.Forms.DataGridView();
            this.colSelected = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colIsScope = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.colDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splPermission = new System.Windows.Forms.Splitter();
            this.tvPermission = new System.Windows.Forms.TreeView();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.btnBatchDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnBatchSave = new System.Windows.Forms.Button();
            this.cMnuPermission = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mItmAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmMove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmRootAdd = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmPermissionItems = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mItmModulePermission = new System.Windows.Forms.ToolStripMenuItem();
            this.mItmSetSortCode = new System.Windows.Forms.ToolStripMenuItem();
            this.ucTableSort = new DotNet.WinForm.UCTableSort();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnModulePermission = new System.Windows.Forms.Button();
            this.btnExportAll = new System.Windows.Forms.Button();
            this.btnUserPermissionItem = new System.Windows.Forms.Button();
            this.btnRolePermissionItem = new System.Windows.Forms.Button();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlPermission.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPermission)).BeginInit();
            this.cMnuPermission.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnMove
            // 
            this.btnMove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMove.Enabled = false;
            this.btnMove.Location = new System.Drawing.Point(395, 518);
            this.btnMove.Name = "btnMove";
            this.btnMove.Size = new System.Drawing.Size(81, 23);
            this.btnMove.TabIndex = 2;
            this.btnMove.Text = "移动(&M)...";
            this.btnMove.UseVisualStyleBackColor = true;
            this.btnMove.Click += new System.EventHandler(this.btnMove_Click);
            // 
            // pnlPermission
            // 
            this.pnlPermission.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlPermission.Controls.Add(this.grdPermission);
            this.pnlPermission.Controls.Add(this.splPermission);
            this.pnlPermission.Controls.Add(this.tvPermission);
            this.pnlPermission.Location = new System.Drawing.Point(8, 35);
            this.pnlPermission.Name = "pnlPermission";
            this.pnlPermission.Size = new System.Drawing.Size(923, 476);
            this.pnlPermission.TabIndex = 1;
            // 
            // grdPermission
            // 
            this.grdPermission.AllowUserToAddRows = false;
            this.grdPermission.AllowUserToDeleteRows = false;
            this.grdPermission.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdPermission.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdPermission.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPermission.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colSelected,
            this.colCode,
            this.colFullName,
            this.colIsScope,
            this.colDescription});
            this.grdPermission.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPermission.Location = new System.Drawing.Point(203, 0);
            this.grdPermission.MultiSelect = false;
            this.grdPermission.Name = "grdPermission";
            this.grdPermission.RowTemplate.Height = 23;
            this.grdPermission.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdPermission.Size = new System.Drawing.Size(720, 476);
            this.grdPermission.TabIndex = 2;
            this.grdPermission.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdPermission_CellDoubleClick);
            this.grdPermission.Sorted += new System.EventHandler(this.grdPermission_Sorted);
            this.grdPermission.Click += new System.EventHandler(this.grdPermission_Click);
            // 
            // colSelected
            // 
            this.colSelected.DataPropertyName = "Selected";
            this.colSelected.Frozen = true;
            this.colSelected.HeaderText = "选择";
            this.colSelected.Name = "colSelected";
            this.colSelected.Width = 50;
            // 
            // colCode
            // 
            this.colCode.DataPropertyName = "Code";
            this.colCode.FillWeight = 200F;
            this.colCode.HeaderText = "编号";
            this.colCode.MaxInputLength = 20;
            this.colCode.Name = "colCode";
            this.colCode.ReadOnly = true;
            this.colCode.Width = 200;
            // 
            // colFullName
            // 
            this.colFullName.DataPropertyName = "FullName";
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colFullName.DefaultCellStyle = dataGridViewCellStyle2;
            this.colFullName.HeaderText = "名称";
            this.colFullName.MaxInputLength = 50;
            this.colFullName.Name = "colFullName";
            this.colFullName.Width = 180;
            // 
            // colIsScope
            // 
            this.colIsScope.DataPropertyName = "IsScope";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle3.NullValue = false;
            this.colIsScope.DefaultCellStyle = dataGridViewCellStyle3;
            this.colIsScope.FalseValue = "0";
            this.colIsScope.HeaderText = "数据权限";
            this.colIsScope.Name = "colIsScope";
            this.colIsScope.TrueValue = "1";
            this.colIsScope.Width = 80;
            // 
            // colDescription
            // 
            this.colDescription.DataPropertyName = "Description";
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colDescription.DefaultCellStyle = dataGridViewCellStyle4;
            this.colDescription.FillWeight = 140F;
            this.colDescription.HeaderText = "描述";
            this.colDescription.MaxInputLength = 200;
            this.colDescription.Name = "colDescription";
            this.colDescription.Width = 140;
            // 
            // splPermission
            // 
            this.splPermission.Location = new System.Drawing.Point(200, 0);
            this.splPermission.Name = "splPermission";
            this.splPermission.Size = new System.Drawing.Size(3, 476);
            this.splPermission.TabIndex = 8;
            this.splPermission.TabStop = false;
            // 
            // tvPermission
            // 
            this.tvPermission.AllowDrop = true;
            this.tvPermission.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvPermission.HotTracking = true;
            this.tvPermission.ImageIndex = 0;
            this.tvPermission.ImageList = this.imageList;
            this.tvPermission.Location = new System.Drawing.Point(0, 0);
            this.tvPermission.Name = "tvPermission";
            this.tvPermission.SelectedImageIndex = 1;
            this.tvPermission.Size = new System.Drawing.Size(200, 476);
            this.tvPermission.TabIndex = 0;
            this.tvPermission.ItemDrag += new System.Windows.Forms.ItemDragEventHandler(this.tvPermission_ItemDrag);
            this.tvPermission.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPermission_AfterSelect);
            this.tvPermission.Click += new System.EventHandler(this.tvPermission_Click);
            this.tvPermission.DragDrop += new System.Windows.Forms.DragEventHandler(this.tvPermission_DragDrop);
            this.tvPermission.DragEnter += new System.Windows.Forms.DragEventHandler(this.tvPermission_DragEnter);
            this.tvPermission.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tvPermission_MouseDown);
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
            // 
            // btnBatchDelete
            // 
            this.btnBatchDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchDelete.Enabled = false;
            this.btnBatchDelete.Location = new System.Drawing.Point(593, 518);
            this.btnBatchDelete.Name = "btnBatchDelete";
            this.btnBatchDelete.Size = new System.Drawing.Size(81, 23);
            this.btnBatchDelete.TabIndex = 4;
            this.btnBatchDelete.Text = "删除(&D)";
            this.btnBatchDelete.UseVisualStyleBackColor = true;
            this.btnBatchDelete.Click += new System.EventHandler(this.btnBatchDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Enabled = false;
            this.btnEdit.Location = new System.Drawing.Point(314, 518);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(81, 23);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "编辑(&E)...";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(860, 518);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(233, 518);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(81, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "添加(&A)...";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnBatchSave
            // 
            this.btnBatchSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBatchSave.Enabled = false;
            this.btnBatchSave.Location = new System.Drawing.Point(779, 518);
            this.btnBatchSave.Name = "btnBatchSave";
            this.btnBatchSave.Size = new System.Drawing.Size(81, 23);
            this.btnBatchSave.TabIndex = 6;
            this.btnBatchSave.Text = "保存(&S)";
            this.btnBatchSave.UseVisualStyleBackColor = true;
            this.btnBatchSave.Click += new System.EventHandler(this.btnBatchSave_Click);
            // 
            // cMnuPermission
            // 
            this.cMnuPermission.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mItmAdd,
            this.mItmEdit,
            this.mItmDelete,
            this.mItmMove,
            this.toolStripSeparator3,
            this.mItmRootAdd,
            this.toolStripSeparator1,
            this.mItmPermissionItems,
            this.toolStripSeparator2,
            this.mItmModulePermission,
            this.mItmSetSortCode});
            this.cMnuPermission.Name = "cMnuModule";
            this.cMnuPermission.Size = new System.Drawing.Size(162, 220);
            // 
            // mItmAdd
            // 
            this.mItmAdd.Enabled = false;
            this.mItmAdd.Name = "mItmAdd";
            this.mItmAdd.Size = new System.Drawing.Size(161, 22);
            this.mItmAdd.Text = "添加(&A)...";
            this.mItmAdd.Click += new System.EventHandler(this.mItmAdd_Click);
            // 
            // mItmEdit
            // 
            this.mItmEdit.Enabled = false;
            this.mItmEdit.Name = "mItmEdit";
            this.mItmEdit.Size = new System.Drawing.Size(161, 22);
            this.mItmEdit.Text = "编辑(&E)...";
            this.mItmEdit.Click += new System.EventHandler(this.mItmEdit_Click);
            // 
            // mItmDelete
            // 
            this.mItmDelete.Enabled = false;
            this.mItmDelete.Name = "mItmDelete";
            this.mItmDelete.Size = new System.Drawing.Size(161, 22);
            this.mItmDelete.Text = "删除(&D)";
            this.mItmDelete.Click += new System.EventHandler(this.mItmDelete_Click);
            // 
            // mItmMove
            // 
            this.mItmMove.Enabled = false;
            this.mItmMove.Name = "mItmMove";
            this.mItmMove.Size = new System.Drawing.Size(161, 22);
            this.mItmMove.Text = "移动(&M)...";
            this.mItmMove.Click += new System.EventHandler(this.mItmMove_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(158, 6);
            // 
            // mItmRootAdd
            // 
            this.mItmRootAdd.Enabled = false;
            this.mItmRootAdd.Name = "mItmRootAdd";
            this.mItmRootAdd.Size = new System.Drawing.Size(161, 22);
            this.mItmRootAdd.Text = "添加根权限(&R)...";
            this.mItmRootAdd.Click += new System.EventHandler(this.mItmRootAdd_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(158, 6);
            // 
            // mItmPermissionItems
            // 
            this.mItmPermissionItems.Enabled = false;
            this.mItmPermissionItems.Name = "mItmPermissionItems";
            this.mItmPermissionItems.Size = new System.Drawing.Size(161, 22);
            this.mItmPermissionItems.Text = "操作权限分配...";
            this.mItmPermissionItems.Click += new System.EventHandler(this.mItmPermissionItemsClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(158, 6);
            // 
            // mItmModulePermission
            // 
            this.mItmModulePermission.Enabled = false;
            this.mItmModulePermission.Name = "mItmModulePermission";
            this.mItmModulePermission.Size = new System.Drawing.Size(161, 22);
            this.mItmModulePermission.Text = "关联菜单...";
            this.mItmModulePermission.Click += new System.EventHandler(this.mItmModulePermission_Click);
            // 
            // mItmSetSortCode
            // 
            this.mItmSetSortCode.Enabled = false;
            this.mItmSetSortCode.Name = "mItmSetSortCode";
            this.mItmSetSortCode.Size = new System.Drawing.Size(161, 22);
            this.mItmSetSortCode.Text = "保存排序顺序";
            this.mItmSetSortCode.Click += new System.EventHandler(this.mItmSetSortCode_Click);
            // 
            // ucTableSort
            // 
            this.ucTableSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ucTableSort.Location = new System.Drawing.Point(8, 517);
            this.ucTableSort.Margin = new System.Windows.Forms.Padding(0);
            this.ucTableSort.Name = "ucTableSort";
            this.ucTableSort.Padding = new System.Windows.Forms.Padding(1);
            this.ucTableSort.SetBottomEnabled = false;
            this.ucTableSort.SetDownEnabled = false;
            this.ucTableSort.SetTopEnabled = false;
            this.ucTableSort.SetUpEnabled = false;
            this.ucTableSort.Size = new System.Drawing.Size(99, 24);
            this.ucTableSort.TabIndex = 8;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Enabled = false;
            this.btnExport.Location = new System.Drawing.Point(476, 518);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(117, 23);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "导出Excel...";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnModulePermission
            // 
            this.btnModulePermission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModulePermission.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnModulePermission.Enabled = false;
            this.btnModulePermission.Location = new System.Drawing.Point(674, 518);
            this.btnModulePermission.Name = "btnModulePermission";
            this.btnModulePermission.Size = new System.Drawing.Size(105, 23);
            this.btnModulePermission.TabIndex = 5;
            this.btnModulePermission.Text = "关联菜单...";
            this.btnModulePermission.UseVisualStyleBackColor = true;
            this.btnModulePermission.Click += new System.EventHandler(this.btnModulePermission_Click);
            // 
            // btnExportAll
            // 
            this.btnExportAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportAll.Enabled = false;
            this.btnExportAll.Location = new System.Drawing.Point(3, 3);
            this.btnExportAll.Name = "btnExportAll";
            this.btnExportAll.Size = new System.Drawing.Size(141, 23);
            this.btnExportAll.TabIndex = 11;
            this.btnExportAll.Text = "全部导出Excel...";
            this.btnExportAll.UseVisualStyleBackColor = true;
            this.btnExportAll.Click += new System.EventHandler(this.btnExportAll_Click);
            // 
            // btnUserPermissionItem
            // 
            this.btnUserPermissionItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnUserPermissionItem.Enabled = false;
            this.btnUserPermissionItem.Location = new System.Drawing.Point(291, 3);
            this.btnUserPermissionItem.Name = "btnUserPermissionItem";
            this.btnUserPermissionItem.Size = new System.Drawing.Size(135, 23);
            this.btnUserPermissionItem.TabIndex = 9;
            this.btnUserPermissionItem.Text = "用户操作权限...";
            this.btnUserPermissionItem.UseVisualStyleBackColor = true;
            this.btnUserPermissionItem.Click += new System.EventHandler(this.btnUserPermissionItem_Click);
            // 
            // btnRolePermissionItem
            // 
            this.btnRolePermissionItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRolePermissionItem.Enabled = false;
            this.btnRolePermissionItem.Location = new System.Drawing.Point(150, 3);
            this.btnRolePermissionItem.Name = "btnRolePermissionItem";
            this.btnRolePermissionItem.Size = new System.Drawing.Size(135, 23);
            this.btnRolePermissionItem.TabIndex = 10;
            this.btnRolePermissionItem.Text = "角色操作权限...";
            this.btnRolePermissionItem.UseVisualStyleBackColor = true;
            this.btnRolePermissionItem.Click += new System.EventHandler(this.btnRolePermissionItem_Click);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.btnUserPermissionItem);
            this.flowLayoutPanel1.Controls.Add(this.btnRolePermissionItem);
            this.flowLayoutPanel1.Controls.Add(this.btnExportAll);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(505, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(429, 28);
            this.flowLayoutPanel1.TabIndex = 12;
            // 
            // FrmPermissionItemAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(939, 545);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.btnModulePermission);
            this.Controls.Add(this.ucTableSort);
            this.Controls.Add(this.btnBatchSave);
            this.Controls.Add(this.pnlPermission);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnBatchDelete);
            this.Controls.Add(this.btnMove);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.Name = "FrmPermissionItemAdmin";
            this.Padding = new System.Windows.Forms.Padding(8);
            this.Text = "操作权限项定义";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPermissionAdmin_FormClosing);
            this.pnlPermission.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPermission)).EndInit();
            this.cMnuPermission.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMove;
        private System.Windows.Forms.Panel pnlPermission;
        private System.Windows.Forms.Splitter splPermission;
        private System.Windows.Forms.TreeView tvPermission;
        private System.Windows.Forms.Button btnBatchDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnBatchSave;
        private System.Windows.Forms.ContextMenuStrip cMnuPermission;
        private System.Windows.Forms.ToolStripMenuItem mItmAdd;
        private System.Windows.Forms.ToolStripMenuItem mItmEdit;
        private System.Windows.Forms.ToolStripMenuItem mItmMove;
        private System.Windows.Forms.ToolStripMenuItem mItmDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mItmSetSortCode;
        private DotNet.WinForm.UCTableSort ucTableSort;
        private System.Windows.Forms.DataGridView grdPermission;
        private System.Windows.Forms.ToolStripMenuItem mItmRootAdd;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ToolStripMenuItem mItmPermissionItems;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Button btnModulePermission;
        private System.Windows.Forms.ToolStripMenuItem mItmModulePermission;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.Button btnExportAll;
        private System.Windows.Forms.Button btnUserPermissionItem;
        private System.Windows.Forms.Button btnRolePermissionItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colSelected;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn colIsScope;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescription;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
    }
}