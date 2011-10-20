/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-13
 * 时间: 16:17
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.生产检测数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.糠醛车间检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.白土车间检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.油罐检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.油样全套检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.油样检测登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.研发实验检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.检测数据管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.字典管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.原料进厂检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// stausInfoShow1
			// 
			this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.stausInfoShow1.Location = new System.Drawing.Point(0, 622);
			this.stausInfoShow1.Name = "stausInfoShow1";
			this.stausInfoShow1.Size = new System.Drawing.Size(1017, 24);
			this.stausInfoShow1.TabIndex = 0;
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.生产检测数据ToolStripMenuItem,
									this.油样全套检测ToolStripMenuItem,
									this.研发实验检测ToolStripMenuItem,
									this.帮助ToolStripMenuItem,
									this.退出ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1017, 24);
			this.menuStrip1.TabIndex = 2;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 生产检测数据ToolStripMenuItem
			// 
			this.生产检测数据ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.糠醛车间检测ToolStripMenuItem,
									this.白土车间检测ToolStripMenuItem,
									this.toolStripSeparator1,
									this.油罐检测ToolStripMenuItem,
									this.原料进厂检测ToolStripMenuItem});
			this.生产检测数据ToolStripMenuItem.Name = "生产检测数据ToolStripMenuItem";
			this.生产检测数据ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.生产检测数据ToolStripMenuItem.Text = "生产检测数据";
			// 
			// 糠醛车间检测ToolStripMenuItem
			// 
			this.糠醛车间检测ToolStripMenuItem.Name = "糠醛车间检测ToolStripMenuItem";
			this.糠醛车间检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.糠醛车间检测ToolStripMenuItem.Text = "糠醛车间检测";
			this.糠醛车间检测ToolStripMenuItem.Click += new System.EventHandler(this.糠醛车间检测ToolStripMenuItemClick);
			// 
			// 白土车间检测ToolStripMenuItem
			// 
			this.白土车间检测ToolStripMenuItem.Name = "白土车间检测ToolStripMenuItem";
			this.白土车间检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.白土车间检测ToolStripMenuItem.Text = "白土车间检测";
			this.白土车间检测ToolStripMenuItem.Click += new System.EventHandler(this.白土车间检测ToolStripMenuItemClick);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
			// 
			// 油罐检测ToolStripMenuItem
			// 
			this.油罐检测ToolStripMenuItem.Name = "油罐检测ToolStripMenuItem";
			this.油罐检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.油罐检测ToolStripMenuItem.Text = "油罐检测";
			this.油罐检测ToolStripMenuItem.Click += new System.EventHandler(this.油罐检测ToolStripMenuItemClick);
			// 
			// 油样全套检测ToolStripMenuItem
			// 
			this.油样全套检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.油样检测登记ToolStripMenuItem});
			this.油样全套检测ToolStripMenuItem.Name = "油样全套检测ToolStripMenuItem";
			this.油样全套检测ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.油样全套检测ToolStripMenuItem.Text = "油样全套检测";
			// 
			// 油样检测登记ToolStripMenuItem
			// 
			this.油样检测登记ToolStripMenuItem.Name = "油样检测登记ToolStripMenuItem";
			this.油样检测登记ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.油样检测登记ToolStripMenuItem.Text = "油样检测登记";
			this.油样检测登记ToolStripMenuItem.Click += new System.EventHandler(this.油样检测登记ToolStripMenuItemClick);
			// 
			// 研发实验检测ToolStripMenuItem
			// 
			this.研发实验检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.检测数据管理ToolStripMenuItem});
			this.研发实验检测ToolStripMenuItem.Name = "研发实验检测ToolStripMenuItem";
			this.研发实验检测ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.研发实验检测ToolStripMenuItem.Text = "研发实验检测";
			// 
			// 检测数据管理ToolStripMenuItem
			// 
			this.检测数据管理ToolStripMenuItem.Name = "检测数据管理ToolStripMenuItem";
			this.检测数据管理ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
			this.检测数据管理ToolStripMenuItem.Text = "检测数据管理";
			this.检测数据管理ToolStripMenuItem.Click += new System.EventHandler(this.检测数据管理ToolStripMenuItemClick);
			// 
			// 帮助ToolStripMenuItem
			// 
			this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.用户管理ToolStripMenuItem,
									this.testToolStripMenuItem,
									this.字典管理ToolStripMenuItem});
			this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
			this.帮助ToolStripMenuItem.Text = "系统设置";
			// 
			// 用户管理ToolStripMenuItem
			// 
			this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
			this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.用户管理ToolStripMenuItem.Text = "用户管理";
			this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
			// 
			// testToolStripMenuItem
			// 
			this.testToolStripMenuItem.Name = "testToolStripMenuItem";
			this.testToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.testToolStripMenuItem.Text = "test";
			this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
			// 
			// 字典管理ToolStripMenuItem
			// 
			this.字典管理ToolStripMenuItem.Name = "字典管理ToolStripMenuItem";
			this.字典管理ToolStripMenuItem.Size = new System.Drawing.Size(118, 22);
			this.字典管理ToolStripMenuItem.Text = "字典管理";
			this.字典管理ToolStripMenuItem.Click += new System.EventHandler(this.字典管理ToolStripMenuItem_Click);
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItemClick);
			// 
			// 原料进厂检测ToolStripMenuItem
			// 
			this.原料进厂检测ToolStripMenuItem.Name = "原料进厂检测ToolStripMenuItem";
			this.原料进厂检测ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.原料进厂检测ToolStripMenuItem.Text = "原料进厂检测";
			this.原料进厂检测ToolStripMenuItem.Click += new System.EventHandler(this.原料进厂检测ToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1017, 646);
			this.Controls.Add(this.stausInfoShow1);
			this.Controls.Add(this.menuStrip1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "YoungRunLab";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
        }
		private System.Windows.Forms.ToolStripMenuItem 原料进厂检测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 检测数据管理ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 油样检测登记ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 油罐检测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem 白土车间检测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 糠醛车间检测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 研发实验检测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 油样全套检测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 生产检测数据ToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字典管理ToolStripMenuItem;



       
	}
}
