/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-5
 * 时间: 13:31
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace CustomerMS.CustomerControl
{
	partial class CustomerInfo
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CustomerInfo));
			this.toolExit = new System.Windows.Forms.ToolStripButton();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.gpbSet = new System.Windows.Forms.GroupBox();
			this.grpSearch = new System.Windows.Forms.GroupBox();
			this.txtSRemark = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnSearch = new System.Windows.Forms.Button();
			this.txtSAddress = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSIndustryName = new System.Windows.Forms.TextBox();
			this.txtSCompanyName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.grpCompanyInfo = new System.Windows.Forms.GroupBox();
			this.txtFax = new System.Windows.Forms.TextBox();
			this.txtTel = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.txtMobile = new System.Windows.Forms.TextBox();
			this.txtPosition = new System.Windows.Forms.TextBox();
			this.txtLinkMan = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.txtMainProduct = new System.Windows.Forms.TextBox();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.txtAddress = new System.Windows.Forms.TextBox();
			this.txtBusinessMode = new System.Windows.Forms.TextBox();
			this.txtSubIndustryName = new System.Windows.Forms.TextBox();
			this.txtCompanyName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.lblBusinessMode = new System.Windows.Forms.Label();
			this.lblAddress = new System.Windows.Forms.Label();
			this.lblProduct = new System.Windows.Forms.Label();
			this.lblSubIndustryName = new System.Windows.Forms.Label();
			this.lblCompanyName = new System.Windows.Forms.Label();
			this.splitContainer2 = new System.Windows.Forms.SplitContainer();
			this.dgvCustomerInfo = new System.Windows.Forms.DataGridView();
			this.Pager = new Kenny.Controls.WinForm.WinFormPager();
			this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolDelete = new System.Windows.Forms.ToolStripButton();
			this.toolAmend = new System.Windows.Forms.ToolStripButton();
			this.toolExportToExcel = new System.Windows.Forms.ToolStripButton();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolSave = new System.Windows.Forms.ToolStripButton();
			this.toolCancel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolAdd = new System.Windows.Forms.ToolStripButton();
			this.toolFind = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			this.gpbSet.SuspendLayout();
			this.grpSearch.SuspendLayout();
			this.grpCompanyInfo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
			this.splitContainer2.Panel1.SuspendLayout();
			this.splitContainer2.Panel2.SuspendLayout();
			this.splitContainer2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// toolExit
			// 
			this.toolExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
			this.toolExit.ImageTransparentColor = System.Drawing.SystemColors.Control;
			this.toolExit.Name = "toolExit";
			this.toolExit.Size = new System.Drawing.Size(55, 22);
			this.toolExit.Tag = "7";
			this.toolExit.Text = "退出";
			this.toolExit.Click += new System.EventHandler(this.toolExit_Click);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.gpbSet);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.splitContainer2);
			this.splitContainer1.Panel2.Controls.Add(this.stausInfoShow1);
			this.splitContainer1.Size = new System.Drawing.Size(987, 658);
			this.splitContainer1.SplitterDistance = 173;
			this.splitContainer1.SplitterWidth = 2;
			this.splitContainer1.TabIndex = 38;
			// 
			// gpbSet
			// 
			this.gpbSet.Controls.Add(this.grpSearch);
			this.gpbSet.Controls.Add(this.grpCompanyInfo);
			this.gpbSet.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gpbSet.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.gpbSet.Location = new System.Drawing.Point(0, 0);
			this.gpbSet.Name = "gpbSet";
			this.gpbSet.Size = new System.Drawing.Size(987, 173);
			this.gpbSet.TabIndex = 36;
			this.gpbSet.TabStop = false;
			// 
			// grpSearch
			// 
			this.grpSearch.Controls.Add(this.txtSRemark);
			this.grpSearch.Controls.Add(this.label5);
			this.grpSearch.Controls.Add(this.btnReset);
			this.grpSearch.Controls.Add(this.btnSearch);
			this.grpSearch.Controls.Add(this.txtSAddress);
			this.grpSearch.Controls.Add(this.label4);
			this.grpSearch.Controls.Add(this.txtSIndustryName);
			this.grpSearch.Controls.Add(this.txtSCompanyName);
			this.grpSearch.Controls.Add(this.label2);
			this.grpSearch.Controls.Add(this.label3);
			this.grpSearch.Location = new System.Drawing.Point(1, 0);
			this.grpSearch.Name = "grpSearch";
			this.grpSearch.Size = new System.Drawing.Size(254, 172);
			this.grpSearch.TabIndex = 1;
			this.grpSearch.TabStop = false;
			// 
			// txtSRemark
			// 
			this.txtSRemark.Location = new System.Drawing.Point(67, 102);
			this.txtSRemark.Name = "txtSRemark";
			this.txtSRemark.Size = new System.Drawing.Size(181, 23);
			this.txtSRemark.TabIndex = 30;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(31, 106);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 14);
			this.label5.TabIndex = 26;
			this.label5.Text = "备注";
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(157, 140);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(75, 23);
			this.btnReset.TabIndex = 29;
			this.btnReset.Text = "重置";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
			// 
			// btnSearch
			// 
			this.btnSearch.Location = new System.Drawing.Point(47, 140);
			this.btnSearch.Name = "btnSearch";
			this.btnSearch.Size = new System.Drawing.Size(75, 23);
			this.btnSearch.TabIndex = 28;
			this.btnSearch.Text = "搜索";
			this.btnSearch.UseVisualStyleBackColor = true;
			this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
			// 
			// txtSAddress
			// 
			this.txtSAddress.Location = new System.Drawing.Point(67, 72);
			this.txtSAddress.Name = "txtSAddress";
			this.txtSAddress.Size = new System.Drawing.Size(181, 23);
			this.txtSAddress.TabIndex = 27;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(6, 76);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(63, 14);
			this.label4.TabIndex = 26;
			this.label4.Text = "公司地址";
			// 
			// txtSIndustryName
			// 
			this.txtSIndustryName.Location = new System.Drawing.Point(67, 42);
			this.txtSIndustryName.Name = "txtSIndustryName";
			this.txtSIndustryName.Size = new System.Drawing.Size(181, 23);
			this.txtSIndustryName.TabIndex = 25;
			// 
			// txtSCompanyName
			// 
			this.txtSCompanyName.Location = new System.Drawing.Point(67, 13);
			this.txtSCompanyName.Name = "txtSCompanyName";
			this.txtSCompanyName.Size = new System.Drawing.Size(181, 23);
			this.txtSCompanyName.TabIndex = 24;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(6, 46);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 14);
			this.label2.TabIndex = 23;
			this.label2.Text = "行业名称";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(6, 17);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 14);
			this.label3.TabIndex = 22;
			this.label3.Text = "公司名称";
			// 
			// grpCompanyInfo
			// 
			this.grpCompanyInfo.Controls.Add(this.txtFax);
			this.grpCompanyInfo.Controls.Add(this.txtTel);
			this.grpCompanyInfo.Controls.Add(this.label9);
			this.grpCompanyInfo.Controls.Add(this.label10);
			this.grpCompanyInfo.Controls.Add(this.txtMobile);
			this.grpCompanyInfo.Controls.Add(this.txtPosition);
			this.grpCompanyInfo.Controls.Add(this.txtLinkMan);
			this.grpCompanyInfo.Controls.Add(this.label6);
			this.grpCompanyInfo.Controls.Add(this.label7);
			this.grpCompanyInfo.Controls.Add(this.label8);
			this.grpCompanyInfo.Controls.Add(this.txtMainProduct);
			this.grpCompanyInfo.Controls.Add(this.txtRemark);
			this.grpCompanyInfo.Controls.Add(this.txtAddress);
			this.grpCompanyInfo.Controls.Add(this.txtBusinessMode);
			this.grpCompanyInfo.Controls.Add(this.txtSubIndustryName);
			this.grpCompanyInfo.Controls.Add(this.txtCompanyName);
			this.grpCompanyInfo.Controls.Add(this.label1);
			this.grpCompanyInfo.Controls.Add(this.lblBusinessMode);
			this.grpCompanyInfo.Controls.Add(this.lblAddress);
			this.grpCompanyInfo.Controls.Add(this.lblProduct);
			this.grpCompanyInfo.Controls.Add(this.lblSubIndustryName);
			this.grpCompanyInfo.Controls.Add(this.lblCompanyName);
			this.grpCompanyInfo.Location = new System.Drawing.Point(256, 0);
			this.grpCompanyInfo.Name = "grpCompanyInfo";
			this.grpCompanyInfo.Size = new System.Drawing.Size(730, 172);
			this.grpCompanyInfo.TabIndex = 0;
			this.grpCompanyInfo.TabStop = false;
			// 
			// txtFax
			// 
			this.txtFax.Location = new System.Drawing.Point(585, 142);
			this.txtFax.Name = "txtFax";
			this.txtFax.ReadOnly = true;
			this.txtFax.Size = new System.Drawing.Size(139, 23);
			this.txtFax.TabIndex = 35;
			// 
			// txtTel
			// 
			this.txtTel.Location = new System.Drawing.Point(585, 109);
			this.txtTel.Name = "txtTel";
			this.txtTel.ReadOnly = true;
			this.txtTel.Size = new System.Drawing.Size(139, 23);
			this.txtTel.TabIndex = 34;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(547, 147);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 14);
			this.label9.TabIndex = 33;
			this.label9.Text = "传真";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(547, 113);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(35, 14);
			this.label10.TabIndex = 32;
			this.label10.Text = "电话";
			// 
			// txtMobile
			// 
			this.txtMobile.Location = new System.Drawing.Point(585, 76);
			this.txtMobile.Name = "txtMobile";
			this.txtMobile.ReadOnly = true;
			this.txtMobile.Size = new System.Drawing.Size(139, 23);
			this.txtMobile.TabIndex = 31;
			// 
			// txtPosition
			// 
			this.txtPosition.Location = new System.Drawing.Point(585, 44);
			this.txtPosition.Name = "txtPosition";
			this.txtPosition.ReadOnly = true;
			this.txtPosition.Size = new System.Drawing.Size(139, 23);
			this.txtPosition.TabIndex = 30;
			// 
			// txtLinkMan
			// 
			this.txtLinkMan.Location = new System.Drawing.Point(585, 14);
			this.txtLinkMan.Name = "txtLinkMan";
			this.txtLinkMan.ReadOnly = true;
			this.txtLinkMan.Size = new System.Drawing.Size(139, 23);
			this.txtLinkMan.TabIndex = 29;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(547, 80);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(35, 14);
			this.label6.TabIndex = 28;
			this.label6.Text = "手机";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(547, 48);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(35, 14);
			this.label7.TabIndex = 27;
			this.label7.Text = "职务";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(533, 17);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(49, 14);
			this.label8.TabIndex = 26;
			this.label8.Text = "联系人";
			// 
			// txtMainProduct
			// 
			this.txtMainProduct.Location = new System.Drawing.Point(363, 13);
			this.txtMainProduct.Multiline = true;
			this.txtMainProduct.Name = "txtMainProduct";
			this.txtMainProduct.ReadOnly = true;
			this.txtMainProduct.Size = new System.Drawing.Size(164, 95);
			this.txtMainProduct.TabIndex = 25;
			// 
			// txtRemark
			// 
			this.txtRemark.Location = new System.Drawing.Point(69, 144);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.ReadOnly = true;
			this.txtRemark.Size = new System.Drawing.Size(458, 23);
			this.txtRemark.TabIndex = 24;
			// 
			// txtAddress
			// 
			this.txtAddress.Location = new System.Drawing.Point(69, 112);
			this.txtAddress.Name = "txtAddress";
			this.txtAddress.ReadOnly = true;
			this.txtAddress.Size = new System.Drawing.Size(458, 23);
			this.txtAddress.TabIndex = 23;
			// 
			// txtBusinessMode
			// 
			this.txtBusinessMode.Location = new System.Drawing.Point(69, 78);
			this.txtBusinessMode.Name = "txtBusinessMode";
			this.txtBusinessMode.ReadOnly = true;
			this.txtBusinessMode.Size = new System.Drawing.Size(225, 23);
			this.txtBusinessMode.TabIndex = 22;
			// 
			// txtSubIndustryName
			// 
			this.txtSubIndustryName.Location = new System.Drawing.Point(69, 44);
			this.txtSubIndustryName.Name = "txtSubIndustryName";
			this.txtSubIndustryName.ReadOnly = true;
			this.txtSubIndustryName.Size = new System.Drawing.Size(225, 23);
			this.txtSubIndustryName.TabIndex = 21;
			// 
			// txtCompanyName
			// 
			this.txtCompanyName.Location = new System.Drawing.Point(69, 10);
			this.txtCompanyName.Name = "txtCompanyName";
			this.txtCompanyName.ReadOnly = true;
			this.txtCompanyName.Size = new System.Drawing.Size(225, 23);
			this.txtCompanyName.TabIndex = 20;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(34, 149);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(35, 14);
			this.label1.TabIndex = 19;
			this.label1.Text = "备注";
			// 
			// lblBusinessMode
			// 
			this.lblBusinessMode.AutoSize = true;
			this.lblBusinessMode.Location = new System.Drawing.Point(6, 82);
			this.lblBusinessMode.Name = "lblBusinessMode";
			this.lblBusinessMode.Size = new System.Drawing.Size(63, 14);
			this.lblBusinessMode.TabIndex = 18;
			this.lblBusinessMode.Text = "经营模式";
			// 
			// lblAddress
			// 
			this.lblAddress.AutoSize = true;
			this.lblAddress.Location = new System.Drawing.Point(5, 116);
			this.lblAddress.Name = "lblAddress";
			this.lblAddress.Size = new System.Drawing.Size(63, 14);
			this.lblAddress.TabIndex = 17;
			this.lblAddress.Text = "公司地址";
			// 
			// lblProduct
			// 
			this.lblProduct.AutoSize = true;
			this.lblProduct.Location = new System.Drawing.Point(298, 16);
			this.lblProduct.Name = "lblProduct";
			this.lblProduct.Size = new System.Drawing.Size(63, 14);
			this.lblProduct.TabIndex = 16;
			this.lblProduct.Text = "产品服务";
			// 
			// lblSubIndustryName
			// 
			this.lblSubIndustryName.AutoSize = true;
			this.lblSubIndustryName.Location = new System.Drawing.Point(6, 47);
			this.lblSubIndustryName.Name = "lblSubIndustryName";
			this.lblSubIndustryName.Size = new System.Drawing.Size(63, 14);
			this.lblSubIndustryName.TabIndex = 15;
			this.lblSubIndustryName.Text = "行业名称";
			// 
			// lblCompanyName
			// 
			this.lblCompanyName.AutoSize = true;
			this.lblCompanyName.Location = new System.Drawing.Point(6, 13);
			this.lblCompanyName.Name = "lblCompanyName";
			this.lblCompanyName.Size = new System.Drawing.Size(63, 14);
			this.lblCompanyName.TabIndex = 14;
			this.lblCompanyName.Text = "公司名称";
			// 
			// splitContainer2
			// 
			this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer2.IsSplitterFixed = true;
			this.splitContainer2.Location = new System.Drawing.Point(0, 0);
			this.splitContainer2.Name = "splitContainer2";
			this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
			// 
			// splitContainer2.Panel1
			// 
			this.splitContainer2.Panel1.Controls.Add(this.dgvCustomerInfo);
			// 
			// splitContainer2.Panel2
			// 
			this.splitContainer2.Panel2.Controls.Add(this.Pager);
			this.splitContainer2.Size = new System.Drawing.Size(987, 459);
			this.splitContainer2.SplitterDistance = 426;
			this.splitContainer2.SplitterWidth = 1;
			this.splitContainer2.TabIndex = 3;
			// 
			// dgvCustomerInfo
			// 
			this.dgvCustomerInfo.AllowUserToAddRows = false;
			this.dgvCustomerInfo.AllowUserToDeleteRows = false;
			this.dgvCustomerInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvCustomerInfo.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgvCustomerInfo.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgvCustomerInfo.Location = new System.Drawing.Point(0, 0);
			this.dgvCustomerInfo.Name = "dgvCustomerInfo";
			this.dgvCustomerInfo.RowTemplate.Height = 23;
			this.dgvCustomerInfo.Size = new System.Drawing.Size(987, 426);
			this.dgvCustomerInfo.TabIndex = 0;
			// 
			// Pager
			// 
			this.Pager.AutoSize = true;
			this.Pager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Pager.BackColor = System.Drawing.Color.Transparent;
			this.Pager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Pager.BackgroundImage")));
			this.Pager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.Pager.Dock = System.Windows.Forms.DockStyle.Right;
			this.Pager.ImeMode = System.Windows.Forms.ImeMode.Disable;
			this.Pager.Location = new System.Drawing.Point(504, 0);
			this.Pager.Name = "Pager";
			this.Pager.RecordCount = 0;
			this.Pager.Size = new System.Drawing.Size(483, 32);
			this.Pager.TabIndex = 0;
			this.Pager.PageIndexChanged += new Kenny.Controls.WinForm.WinFormPager.EventHandler(this.PagerPageIndexChanged);
			// 
			// stausInfoShow1
			// 
			this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.stausInfoShow1.Location = new System.Drawing.Point(0, 459);
			this.stausInfoShow1.Name = "stausInfoShow1";
			this.stausInfoShow1.Size = new System.Drawing.Size(987, 24);
			this.stausInfoShow1.TabIndex = 2;
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
			// 
			// toolDelete
			// 
			this.toolDelete.Enabled = false;
			this.toolDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
			this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolDelete.Name = "toolDelete";
			this.toolDelete.Size = new System.Drawing.Size(55, 22);
			this.toolDelete.Tag = "3";
			this.toolDelete.Text = "删除";
			// 
			// toolAmend
			// 
			this.toolAmend.Enabled = false;
			this.toolAmend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolAmend.Image = ((System.Drawing.Image)(resources.GetObject("toolAmend.Image")));
			this.toolAmend.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolAmend.Name = "toolAmend";
			this.toolAmend.Size = new System.Drawing.Size(55, 22);
			this.toolAmend.Tag = "3";
			this.toolAmend.Text = "修改";
			this.toolAmend.Click += new System.EventHandler(this.ToolAmendClick);
			// 
			// toolExportToExcel
			// 
			this.toolExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolExportToExcel.Image")));
			this.toolExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolExportToExcel.Name = "toolExportToExcel";
			this.toolExportToExcel.Size = new System.Drawing.Size(91, 22);
			this.toolExportToExcel.Text = "导出到Excel";
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolSave,
									this.toolCancel,
									this.toolStripSeparator1,
									this.toolAdd,
									this.toolFind,
									this.toolExportToExcel,
									this.toolAmend,
									this.toolDelete,
									this.toolStripSeparator2,
									this.toolExit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(987, 25);
			this.toolStrip1.TabIndex = 37;
			this.toolStrip1.Text = " ";
			// 
			// toolSave
			// 
			this.toolSave.Enabled = false;
			this.toolSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
			this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolSave.Name = "toolSave";
			this.toolSave.Size = new System.Drawing.Size(55, 22);
			this.toolSave.Tag = "1";
			this.toolSave.Text = "保存";
			// 
			// toolCancel
			// 
			this.toolCancel.Enabled = false;
			this.toolCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
			this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolCancel.Name = "toolCancel";
			this.toolCancel.Size = new System.Drawing.Size(55, 22);
			this.toolCancel.Tag = "2";
			this.toolCancel.Text = "取消";
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
			// 
			// toolAdd
			// 
			this.toolAdd.Enabled = false;
			this.toolAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
			this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolAdd.Name = "toolAdd";
			this.toolAdd.Size = new System.Drawing.Size(55, 22);
			this.toolAdd.Tag = "3";
			this.toolAdd.Text = "添加";
			// 
			// toolFind
			// 
			this.toolFind.Enabled = false;
			this.toolFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.toolFind.Image = ((System.Drawing.Image)(resources.GetObject("toolFind.Image")));
			this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
			this.toolFind.Name = "toolFind";
			this.toolFind.Size = new System.Drawing.Size(55, 22);
			this.toolFind.Tag = "3";
			this.toolFind.Text = "查询";
			// 
			// CustomerInfo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "CustomerInfo";
			this.Size = new System.Drawing.Size(987, 683);
			this.Load += new System.EventHandler(this.CustomerInfoLoad);
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			this.gpbSet.ResumeLayout(false);
			this.grpSearch.ResumeLayout(false);
			this.grpSearch.PerformLayout();
			this.grpCompanyInfo.ResumeLayout(false);
			this.grpCompanyInfo.PerformLayout();
			this.splitContainer2.Panel1.ResumeLayout(false);
			this.splitContainer2.Panel2.ResumeLayout(false);
			this.splitContainer2.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
			this.splitContainer2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dgvCustomerInfo)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private Kenny.Controls.WinForm.WinFormPager Pager;
		private System.Windows.Forms.TextBox txtMainProduct;
		private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
		private System.Windows.Forms.SplitContainer splitContainer2;
		private System.Windows.Forms.GroupBox grpCompanyInfo;
		private System.Windows.Forms.GroupBox grpSearch;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtLinkMan;
		private System.Windows.Forms.TextBox txtPosition;
		private System.Windows.Forms.TextBox txtMobile;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTel;
		private System.Windows.Forms.TextBox txtFax;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtSRemark;
		private System.Windows.Forms.Button btnSearch;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtSAddress;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtSCompanyName;
		private System.Windows.Forms.TextBox txtSIndustryName;
		private System.Windows.Forms.Label lblAddress;
		private System.Windows.Forms.Label lblProduct;
		private System.Windows.Forms.TextBox txtBusinessMode;
		private System.Windows.Forms.Label lblBusinessMode;
		private System.Windows.Forms.TextBox txtSubIndustryName;
		private System.Windows.Forms.TextBox txtCompanyName;
		private System.Windows.Forms.Label lblSubIndustryName;
		private System.Windows.Forms.Label lblCompanyName;
		private System.Windows.Forms.ToolStripButton toolFind;
		private System.Windows.Forms.ToolStripButton toolAdd;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripButton toolCancel;
		private System.Windows.Forms.ToolStripButton toolSave;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.ToolStripButton toolExportToExcel;
		private System.Windows.Forms.ToolStripButton toolAmend;
		private System.Windows.Forms.ToolStripButton toolDelete;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtAddress;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.GroupBox gpbSet;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.DataGridView dgvCustomerInfo;
	}
}
