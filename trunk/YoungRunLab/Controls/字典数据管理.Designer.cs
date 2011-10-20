/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-19
 * 时间: 12:56
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab.Controls
{
    partial class DicTypeManage
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicTypeManage));
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolAdd = new System.Windows.Forms.ToolStripButton();
			this.toolFind = new System.Windows.Forms.ToolStripButton();
			this.toolExportToExcel = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolExit = new System.Windows.Forms.ToolStripButton();
			this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.winPage = new Kenny.Controls.WinForm.WinFormPager();
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
									this.toolStripSeparator2,
									this.toolExit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(486, 25);
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
			this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
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
			this.toolExportToExcel.Size = new System.Drawing.Size(73, 22);
			this.toolExportToExcel.Text = "搜索条件";
			this.toolExportToExcel.Click += new System.EventHandler(this.ToolExportToExcelClick);
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
			// stausInfoShow1
			// 
			this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.stausInfoShow1.Location = new System.Drawing.Point(0, 301);
			this.stausInfoShow1.Name = "stausInfoShow1";
			this.stausInfoShow1.Size = new System.Drawing.Size(486, 24);
			this.stausInfoShow1.TabIndex = 39;
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
			this.splitContainer1.Panel1.Controls.Add(this.dgv);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.winPage);
			this.splitContainer1.Size = new System.Drawing.Size(486, 276);
			this.splitContainer1.SplitterDistance = 247;
			this.splitContainer1.SplitterWidth = 1;
			this.splitContainer1.TabIndex = 40;
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgv.Location = new System.Drawing.Point(0, 0);
			this.dgv.Name = "dgv";
			this.dgv.RowTemplate.Height = 23;
			this.dgv.Size = new System.Drawing.Size(486, 247);
			this.dgv.TabIndex = 41;
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
			this.winPage.Location = new System.Drawing.Point(3, 0);
			this.winPage.Name = "winPage";
			this.winPage.PageSize = 20;
			this.winPage.RecordCount = 0;
			this.winPage.Size = new System.Drawing.Size(483, 28);
			this.winPage.TabIndex = 0;
			this.winPage.PageIndexChanged += new Kenny.Controls.WinForm.WinFormPager.EventHandler(this.winPage_PageIndexChanged);
			// 
			// DicTypeManage
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.splitContainer1);
			this.Controls.Add(this.stausInfoShow1);
			this.Controls.Add(this.toolStrip1);
			this.Name = "DicTypeManage";
			this.Size = new System.Drawing.Size(486, 325);
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
		private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
		private System.Windows.Forms.ToolStripButton toolExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolExportToExcel;
		private System.Windows.Forms.ToolStripButton toolFind;
		private System.Windows.Forms.ToolStripButton toolAdd;
		private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.SaveFileDialog saveFile;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private Kenny.Controls.WinForm.WinFormPager winPage;
        private System.Windows.Forms.DataGridView dgv;
		
	
	}
}
