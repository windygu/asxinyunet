/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-2-20
 * Time: 16:10
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LotteryTicketSoft
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
            this.StausShow = new DotNet.Tools.Controls.StausInfoShow();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基本指标计算ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.规律预测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选号过滤ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据更新ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.常规参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // StausShow
            // 
            this.StausShow.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StausShow.Location = new System.Drawing.Point(0, 590);
            this.StausShow.Name = "StausShow";
            this.StausShow.Size = new System.Drawing.Size(759, 24);
            this.StausShow.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基本指标计算ToolStripMenuItem,
            this.规律预测ToolStripMenuItem,
            this.选号过滤ToolStripMenuItem,
            this.系统设置ToolStripMenuItem,
            this.帮助ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(759, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基本指标计算ToolStripMenuItem
            // 
            this.基本指标计算ToolStripMenuItem.Name = "基本指标计算ToolStripMenuItem";
            this.基本指标计算ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
            this.基本指标计算ToolStripMenuItem.Text = "基本指标计算";
            // 
            // 规律预测ToolStripMenuItem
            // 
            this.规律预测ToolStripMenuItem.Name = "规律预测ToolStripMenuItem";
            this.规律预测ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.规律预测ToolStripMenuItem.Text = "数据趋势";
            // 
            // 选号过滤ToolStripMenuItem
            // 
            this.选号过滤ToolStripMenuItem.Name = "选号过滤ToolStripMenuItem";
            this.选号过滤ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.选号过滤ToolStripMenuItem.Text = "选号过滤";
            // 
            // 系统设置ToolStripMenuItem
            // 
            this.系统设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据更新ToolStripMenuItem,
            this.常规参数设置ToolStripMenuItem});
            this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
            this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.系统设置ToolStripMenuItem.Text = "系统设置";
            // 
            // 数据更新ToolStripMenuItem
            // 
            this.数据更新ToolStripMenuItem.Name = "数据更新ToolStripMenuItem";
            this.数据更新ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.数据更新ToolStripMenuItem.Text = "数据更新";
            this.数据更新ToolStripMenuItem.Click += new System.EventHandler(this.数据更新ToolStripMenuItem_Click_1);
            // 
            // 常规参数设置ToolStripMenuItem
            // 
            this.常规参数设置ToolStripMenuItem.Name = "常规参数设置ToolStripMenuItem";
            this.常规参数设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.常规参数设置ToolStripMenuItem.Text = "常规参数设置";
            this.常规参数设置ToolStripMenuItem.Click += new System.EventHandler(this.常规参数设置ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 614);
            this.Controls.Add(this.StausShow);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LotteryTicketSoft";
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
		private System.Windows.Forms.ToolStripMenuItem 选号过滤ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 规律预测ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 基本指标计算ToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
		private DotNet.Tools.Controls.StausInfoShow StausShow;
	}
}
