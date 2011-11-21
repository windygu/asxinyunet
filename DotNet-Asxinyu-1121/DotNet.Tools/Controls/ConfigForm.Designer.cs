/*
 * 由SharpDevelop创建。
 * 用户： ${asxinyu}
 * 日期: 2011-9-25
 * 时间: 20:02
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace DotNet.Tools.Controls
{
	partial class ConfigForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ConfigForm));
			this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.toolStrip1 = new System.Windows.Forms.ToolStrip();
			this.toolAdd = new System.Windows.Forms.ToolStripButton();
			this.toolFind = new System.Windows.Forms.ToolStripButton();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.toolExit = new System.Windows.Forms.ToolStripButton();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.toolStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// stausInfoShow1
			// 
			this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.stausInfoShow1.Location = new System.Drawing.Point(0, 283);
			this.stausInfoShow1.Name = "stausInfoShow1";
			this.stausInfoShow1.Size = new System.Drawing.Size(413, 24);
			this.stausInfoShow1.TabIndex = 0;
			// 
			// dgv
			// 
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
			this.dgv.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			this.dgv.Location = new System.Drawing.Point(0, 25);
			this.dgv.Name = "dgv";
			this.dgv.RowTemplate.Height = 23;
			this.dgv.Size = new System.Drawing.Size(413, 258);
			this.dgv.TabIndex = 43;
			// 
			// toolStrip1
			// 
			this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.toolAdd,
									this.toolFind,
									this.toolStripSeparator2,
									this.toolExit});
			this.toolStrip1.Location = new System.Drawing.Point(0, 0);
			this.toolStrip1.Name = "toolStrip1";
			this.toolStrip1.Size = new System.Drawing.Size(413, 25);
			this.toolStrip1.TabIndex = 42;
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
			this.toolAdd.Click += new System.EventHandler(this.ToolAdd_Click);
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
			this.toolFind.Click += new System.EventHandler(this.ToolFind_Click);
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
			// 
			// ConfigForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dgv);
			this.Controls.Add(this.toolStrip1);
			this.Controls.Add(this.stausInfoShow1);
			this.Name = "ConfigForm";
			this.Size = new System.Drawing.Size(413, 307);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.toolStrip1.ResumeLayout(false);
			this.toolStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripButton toolExit;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripButton toolFind;
		private System.Windows.Forms.ToolStripButton toolAdd;
		private System.Windows.Forms.ToolStrip toolStrip1;
		private System.Windows.Forms.DataGridView dgv;
		private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
	}
}
