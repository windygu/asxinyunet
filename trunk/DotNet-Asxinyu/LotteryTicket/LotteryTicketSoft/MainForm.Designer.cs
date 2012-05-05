/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LottAnalysis
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
            this.StausShow = new DotNet.WinForm.Controls.StausInfoShow();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基本信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指标信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规则信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.验证过滤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.验证过滤管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.指标信息管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.历史数据预览ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新最近ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.更新所有ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常规参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StausShow
            // 
            this.StausShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StausShow.Location = new System.Drawing.Point(0, 631);
            this.StausShow.Name = "StausShow";
            this.StausShow.Size = new System.Drawing.Size(980, 32);
            this.StausShow.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本信息ToolStripMenuItem,
            this.验证过滤ToolStripMenuItem,
            this.系统设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(980, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基本信息ToolStripMenuItem
            // 
            this.基本信息ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.指标信息ToolStripMenuItem,
            this.规则信息ToolStripMenuItem});
            this.基本信息ToolStripMenuItem.Name = "基本信息ToolStripMenuItem";
            this.基本信息ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.基本信息ToolStripMenuItem.Text = "基本信息";
            // 
            // 指标信息ToolStripMenuItem
            // 
            this.指标信息ToolStripMenuItem.Name = "指标信息ToolStripMenuItem";
            this.指标信息ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.指标信息ToolStripMenuItem.Text = "指标信息";
            this.指标信息ToolStripMenuItem.Click += new System.EventHandler(this.指标信息ToolStripMenuItem_Click);
            // 
            // 规则信息ToolStripMenuItem
            // 
            this.规则信息ToolStripMenuItem.Name = "规则信息ToolStripMenuItem";
            this.规则信息ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.规则信息ToolStripMenuItem.Text = "规则信息";
            // 
            // 验证过滤ToolStripMenuItem
            // 
            this.验证过滤ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.验证过滤管理ToolStripMenuItem,
            this.指标信息管理ToolStripMenuItem,
            this.toolStripSeparator1,
            this.历史数据预览ToolStripMenuItem});
            this.验证过滤ToolStripMenuItem.Name = "验证过滤ToolStripMenuItem";
            this.验证过滤ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.验证过滤ToolStripMenuItem.Text = "验证过滤";
            // 
            // 验证过滤管理ToolStripMenuItem
            // 
            this.验证过滤管理ToolStripMenuItem.Name = "验证过滤管理ToolStripMenuItem";
            this.验证过滤管理ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.验证过滤管理ToolStripMenuItem.Text = "验证过滤管理";
            this.验证过滤管理ToolStripMenuItem.Click += new System.EventHandler(this.验证过滤管理ToolStripMenuItem_Click);
            // 
            // 指标信息管理ToolStripMenuItem
            // 
            this.指标信息管理ToolStripMenuItem.Name = "指标信息管理ToolStripMenuItem";
            this.指标信息管理ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.指标信息管理ToolStripMenuItem.Text = "指标信息管理";
            this.指标信息管理ToolStripMenuItem.Click += new System.EventHandler(this.指标信息管理ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(169, 6);
            // 
            // 历史数据预览ToolStripMenuItem
            // 
            this.历史数据预览ToolStripMenuItem.Name = "历史数据预览ToolStripMenuItem";
            this.历史数据预览ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.历史数据预览ToolStripMenuItem.Text = "历史数据预览";
            this.历史数据预览ToolStripMenuItem.Click += new System.EventHandler(this.历史数据预览ToolStripMenuItem_Click);
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据更新ToolStripMenuItem,
            this.常规参数设置ToolStripMenuItem,
            this.关于ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 数据更新ToolStripMenuItem
            // 
            this.数据更新ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.更新最近ToolStripMenuItem,
            this.更新所有ToolStripMenuItem});
            this.数据更新ToolStripMenuItem.Name = "数据更新ToolStripMenuItem";
            this.数据更新ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.数据更新ToolStripMenuItem.Text = "数据更新";
            // 
            // 更新最近ToolStripMenuItem
            // 
            this.更新最近ToolStripMenuItem.Name = "更新最近ToolStripMenuItem";
            this.更新最近ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.更新最近ToolStripMenuItem.Text = "更新最近";
            this.更新最近ToolStripMenuItem.Click += new System.EventHandler(this.更新最近ToolStripMenuItem_Click);
            // 
            // 更新所有ToolStripMenuItem
            // 
            this.更新所有ToolStripMenuItem.Name = "更新所有ToolStripMenuItem";
            this.更新所有ToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.更新所有ToolStripMenuItem.Text = "更新所有";
            this.更新所有ToolStripMenuItem.Click += new System.EventHandler(this.更新所有ToolStripMenuItem_Click);
            // 
            // 常规参数设置ToolStripMenuItem
            // 
            this.常规参数设置ToolStripMenuItem.Name = "常规参数设置ToolStripMenuItem";
            this.常规参数设置ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.常规参数设置ToolStripMenuItem.Text = "常规参数设置";
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.关于ToolStripMenuItem.Text = "关于";
            this.关于ToolStripMenuItem.Click += new System.EventHandler(this.关于ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(980, 663);
            this.Controls.Add(this.StausShow);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 常规参数设置ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 数据更新ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private DotNet.WinForm.Controls.StausInfoShow StausShow;
        private System.Windows.Forms.ToolStripMenuItem 基本信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指标信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 规则信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 验证过滤ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 验证过滤管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 指标信息管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新最近ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 更新所有ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 历史数据预览ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
	}
}
