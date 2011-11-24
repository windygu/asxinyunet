using DotNet.Tools.Controls;
namespace LotteryTicketSoft.GraphForm
{
    partial class DataManage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataManage));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolFind = new System.Windows.Forms.ToolStripButton();
            this.toolExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.winPage = new DotNet.Tools.Controls.WinFormPager();
            this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
            this.toolStrip1.SuspendLayout();
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
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(618, 25);
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
            this.toolExportToExcel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolExportToExcel.Image")));
            this.toolExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExportToExcel.Name = "toolExportToExcel";
            this.toolExportToExcel.Size = new System.Drawing.Size(83, 22);
            this.toolExportToExcel.Text = "查询条件";
            this.toolExportToExcel.Click += new System.EventHandler(this.ToolExportToExcelClick);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(73, 22);
            this.toolStripButton1.Text = "导出数据";
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
            this.splitContainer1.Size = new System.Drawing.Size(618, 332);
            this.splitContainer1.SplitterDistance = 306;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 41;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(618, 306);
            this.dgv.TabIndex = 42;
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
            this.winPage.Location = new System.Drawing.Point(135, 0);
            this.winPage.Name = "winPage";
            this.winPage.RecordCount = 0;
            this.winPage.Size = new System.Drawing.Size(483, 25);
            this.winPage.TabIndex = 0;
            this.winPage.PageIndexChanged += new DotNet.Tools.Controls.WinFormPager.EventHandler(this.winPage_PageIndexChanged);
            // 
            // stausInfoShow1
            // 
            this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stausInfoShow1.Location = new System.Drawing.Point(0, 357);
            this.stausInfoShow1.Name = "stausInfoShow1";
            this.stausInfoShow1.Size = new System.Drawing.Size(618, 24);
            this.stausInfoShow1.TabIndex = 40;
            // 
            // DataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stausInfoShow1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "DataManage";
            this.Size = new System.Drawing.Size(618, 381);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripButton toolExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
        private System.Windows.Forms.DataGridView dgv;
        private WinFormPager winPage;
    }
}
