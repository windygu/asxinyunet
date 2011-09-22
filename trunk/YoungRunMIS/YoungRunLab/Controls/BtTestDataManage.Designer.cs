namespace YoungRunLab.Controls
{
    partial class BtTestDataManage
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
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BtTestDataManage));
        	this.toolStrip1 = new System.Windows.Forms.ToolStrip();
        	this.toolAdd = new System.Windows.Forms.ToolStripButton();
        	this.toolFind = new System.Windows.Forms.ToolStripButton();
        	this.toolExportToExcel = new System.Windows.Forms.ToolStripButton();
        	this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
        	this.toolExit = new System.Windows.Forms.ToolStripButton();
        	this.grpSearch = new System.Windows.Forms.GroupBox();
        	this.combGetTime = new System.Windows.Forms.ComboBox();
        	this.combProductName = new System.Windows.Forms.ComboBox();
        	this.btnReset = new System.Windows.Forms.Button();
        	this.btnSearch = new System.Windows.Forms.Button();
        	this.label2 = new System.Windows.Forms.Label();
        	this.lblProName = new System.Windows.Forms.Label();
        	this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
        	this.splitContainer1 = new System.Windows.Forms.SplitContainer();
        	this.dgv = new System.Windows.Forms.DataGridView();
        	this.winPage = new Kenny.Controls.WinForm.WinFormPager();
        	this.toolStrip1.SuspendLayout();
        	this.grpSearch.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
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
        	this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
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
        	this.toolFind.Image = ((System.Drawing.Image)(resources.GetObject("toolFind.Image")));
        	this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolFind.Name = "toolFind";
        	this.toolFind.Size = new System.Drawing.Size(55, 22);
        	this.toolFind.Tag = "3";
        	this.toolFind.Text = "查询";
        	this.toolFind.Click += new System.EventHandler(this.ToolFindClick);
        	// 
        	// toolExportToExcel
        	// 
        	this.toolExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolExportToExcel.Image")));
        	this.toolExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
        	this.toolExportToExcel.Name = "toolExportToExcel";
        	this.toolExportToExcel.Size = new System.Drawing.Size(91, 22);
        	this.toolExportToExcel.Text = "导出到Excel";
        	// 
        	// toolStripSeparator2
        	// 
        	this.toolStripSeparator2.Name = "toolStripSeparator2";
        	this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
        	this.toolExit.Click += new System.EventHandler(this.ToolExitClick);
        	// 
        	// grpSearch
        	// 
        	this.grpSearch.Controls.Add(this.combGetTime);
        	this.grpSearch.Controls.Add(this.combProductName);
        	this.grpSearch.Controls.Add(this.btnReset);
        	this.grpSearch.Controls.Add(this.btnSearch);
        	this.grpSearch.Controls.Add(this.label2);
        	this.grpSearch.Controls.Add(this.lblProName);
        	this.grpSearch.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.grpSearch.Location = new System.Drawing.Point(3, 28);
        	this.grpSearch.Name = "grpSearch";
        	this.grpSearch.Size = new System.Drawing.Size(594, 133);
        	this.grpSearch.TabIndex = 39;
        	this.grpSearch.TabStop = false;
        	// 
        	// combGetTime
        	// 
        	this.combGetTime.FormattingEnabled = true;
        	this.combGetTime.Items.AddRange(new object[] {
        	        	        	"今天",
        	        	        	"昨天",
        	        	        	"本周",
        	        	        	"上周",
        	        	        	"本月",
        	        	        	"上月"});
        	this.combGetTime.Location = new System.Drawing.Point(82, 46);
        	this.combGetTime.Name = "combGetTime";
        	this.combGetTime.Size = new System.Drawing.Size(144, 22);
        	this.combGetTime.TabIndex = 31;
        	// 
        	// combProductName
        	// 
        	this.combProductName.FormattingEnabled = true;
        	this.combProductName.Items.AddRange(new object[] {
        	        	        	"减二线基础油",
        	        	        	"46#-2",
        	        	        	"MVI-150",
        	        	        	"MVI-250",
        	        	        	"减三线基础油",
        	        	        	"F100(A)"});
        	this.combProductName.Location = new System.Drawing.Point(82, 14);
        	this.combProductName.Name = "combProductName";
        	this.combProductName.Size = new System.Drawing.Size(144, 22);
        	this.combProductName.TabIndex = 30;
        	// 
        	// btnReset
        	// 
        	this.btnReset.Location = new System.Drawing.Point(138, 94);
        	this.btnReset.Name = "btnReset";
        	this.btnReset.Size = new System.Drawing.Size(75, 23);
        	this.btnReset.TabIndex = 29;
        	this.btnReset.Text = "重置";
        	this.btnReset.UseVisualStyleBackColor = true;
        	// 
        	// btnSearch
        	// 
        	this.btnSearch.Location = new System.Drawing.Point(32, 94);
        	this.btnSearch.Name = "btnSearch";
        	this.btnSearch.Size = new System.Drawing.Size(75, 23);
        	this.btnSearch.TabIndex = 28;
        	this.btnSearch.Text = "搜索";
        	this.btnSearch.UseVisualStyleBackColor = true;
        	this.btnSearch.Click += new System.EventHandler(this.BtnSearchClick);
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Location = new System.Drawing.Point(16, 51);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(63, 14);
        	this.label2.TabIndex = 23;
        	this.label2.Text = "采样时间";
        	// 
        	// lblProName
        	// 
        	this.lblProName.AutoSize = true;
        	this.lblProName.Location = new System.Drawing.Point(16, 19);
        	this.lblProName.Name = "lblProName";
        	this.lblProName.Size = new System.Drawing.Size(63, 14);
        	this.lblProName.TabIndex = 22;
        	this.lblProName.Text = "产品名称";
        	// 
        	// stausInfoShow1
        	// 
        	this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.stausInfoShow1.Location = new System.Drawing.Point(0, 447);
        	this.stausInfoShow1.Name = "stausInfoShow1";
        	this.stausInfoShow1.Size = new System.Drawing.Size(600, 24);
        	this.stausInfoShow1.TabIndex = 40;
        	// 
        	// splitContainer1
        	// 
        	this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
        	this.splitContainer1.IsSplitterFixed = true;
        	this.splitContainer1.Location = new System.Drawing.Point(0, 161);
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
        	this.splitContainer1.Size = new System.Drawing.Size(600, 286);
        	this.splitContainer1.SplitterDistance = 255;
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
        	this.winPage.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("winPage.BackgroundImage")));
        	this.winPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        	this.winPage.Dock = System.Windows.Forms.DockStyle.Right;
        	this.winPage.ImeMode = System.Windows.Forms.ImeMode.Disable;
        	this.winPage.Location = new System.Drawing.Point(117, 0);
        	this.winPage.Name = "winPage";
        	this.winPage.RecordCount = 0;
        	this.winPage.Size = new System.Drawing.Size(483, 30);
        	this.winPage.TabIndex = 0;
        	this.winPage.PageIndexChanged += new Kenny.Controls.WinForm.WinFormPager.EventHandler(this.WinPagePageIndexChanged);
        	// 
        	// BtTestDataManage
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.splitContainer1);
        	this.Controls.Add(this.stausInfoShow1);
        	this.Controls.Add(this.grpSearch);
        	this.Controls.Add(this.toolStrip1);
        	this.Name = "BtTestDataManage";
        	this.Size = new System.Drawing.Size(600, 471);
        	this.toolStrip1.ResumeLayout(false);
        	this.toolStrip1.PerformLayout();
        	this.grpSearch.ResumeLayout(false);
        	this.grpSearch.PerformLayout();
        	this.splitContainer1.Panel1.ResumeLayout(false);
        	this.splitContainer1.Panel2.ResumeLayout(false);
        	this.splitContainer1.Panel2.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
        	this.splitContainer1.ResumeLayout(false);
        	((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ComboBox combGetTime;
        private System.Windows.Forms.ComboBox combProductName;
        private System.Windows.Forms.Label lblProName;
        private System.Windows.Forms.DataGridView dgv;
        private Kenny.Controls.WinForm.WinFormPager winPage;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripButton toolExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label2;
        private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
    }
}
