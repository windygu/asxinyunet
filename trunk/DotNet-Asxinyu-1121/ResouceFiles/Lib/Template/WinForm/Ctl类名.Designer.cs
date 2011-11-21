namespace <#=Config.NameSpace#>
{
    partial class Ctl<#=Table.Name#>
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

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ctl<#=Table.Name#>));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolFind = new System.Windows.Forms.ToolStripButton();
            this.toolExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.winPage = new EntLib.Controls.WinForm.WinFormPager();
            this.toolStrip1.SuspendLayout();
			//((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolAdd,
            this.toolFind,
            this.toolExportToExcel,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(600, 25);
            this.toolStrip1.TabIndex = 38;
            this.toolStrip1.Text = " ";
            // 
            // toolAdd
            // 
            this.toolAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolAdd.Image = global::<#=Config.NameSpace#>.CtlResources.toolAdd;
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(55, 22);
            this.toolAdd.Tag = "3";
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.ToolAddClick);
            // 
            // toolFind
            // 
            this.toolFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolFind.Image = global::<#=Config.NameSpace#>.CtlResources.toolFind;
            this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFind.Name = "toolFind";
            this.toolFind.Size = new System.Drawing.Size(55, 22);
            this.toolFind.Tag = "3";
            this.toolFind.Text = "查询";
            this.toolFind.Click += new System.EventHandler(this.ToolFindClick);
            // 
            // toolExportToExcel
            // 
			this.toolExportToExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolExportToExcel.Image = global::<#=Config.NameSpace#>.CtlResources.toolExportToExcel;
            this.toolExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExportToExcel.Name = "toolExportToExcel";
            this.toolExportToExcel.Size = new System.Drawing.Size(91, 22);
            this.toolExportToExcel.Text = "导出到Excel";
			this.toolExportToExcel.Click += new System.EventHandler(this.ExportToExcelClick);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolExit
            // 
            this.toolExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolExit.Image = global::<#=Config.NameSpace#>.CtlResources.toolExit;
            this.toolExit.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(55, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            this.toolExit.Click += new System.EventHandler(this.ToolExitClick);



            // 
            // splitContainer1
            // 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
			this.splitContainer1.IsSplitterFixed = true;
			this.splitContainer1.Location = new System.Drawing.Point(0, 25);
			this.splitContainer1.Name = "splitContainer1";
			this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            // 
            // splitContainer1.Panel2
            // 
			this.splitContainer1.Panel2.Controls.Add(this.winPage);
			this.splitContainer1.Size = new System.Drawing.Size(600, 422);
			this.splitContainer1.SplitterDistance = 394;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 41;
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(600, 255);
            this.dgv.TabIndex = 0;
            // 
            // winPage
            // 
            this.winPage.AutoSize = true;
            this.winPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.winPage.BackColor = System.Drawing.Color.Transparent;
            this.winPage.BackgroundImage = global::<#=Config.NameSpace#>.CtlResources.winPage;
            this.winPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.winPage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.winPage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.winPage.Location = new System.Drawing.Point(117, 0);
            this.winPage.Name = "winPage";
            this.winPage.RecordCount = 0;
            this.winPage.Size = new System.Drawing.Size(483, 30);
            this.winPage.TabIndex = 0;
            this.winPage.PageIndexChanged += new EntLib.Controls.WinForm.WinFormPager.EventHandler(this.WinPagePageIndexChanged);
			this.winPage.PageIndexChanged += new EntLib.Controls.WinForm.WinFormPager.EventHandler(this.WinPagePageIndexChanged);
            // 
            // BtTestDataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BtTestDataManage";
            this.Size = new System.Drawing.Size(600, 471);
			this.Load += new System.EventHandler(this.Ctl<#=Table.Name#>_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();

            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
			//((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripButton toolExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
		private EntLib.Controls.WinForm.WinFormPager winPage;
    }
}
