/*
 * Created by SharpDevelop.
 * User: dbh
 * Date: 2008-5-24
 * Time: 22:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace zedDataProcess
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
			this.基本数据分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.均值与线性复杂度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.最近2次的冗余度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.最近3次的冗余度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.最近4次的冗余度ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.周期统计分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.单个数字频数分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.单个数相同周期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.两个数相同周期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.三个数相同周期ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.twoSameInOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.其它分析ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.测试ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// 基本数据分析ToolStripMenuItem
			// 
			this.基本数据分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.均值与线性复杂度ToolStripMenuItem,
									this.最近2次的冗余度ToolStripMenuItem,
									this.最近3次的冗余度ToolStripMenuItem,
									this.最近4次的冗余度ToolStripMenuItem});
			this.基本数据分析ToolStripMenuItem.Name = "基本数据分析ToolStripMenuItem";
			this.基本数据分析ToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
			this.基本数据分析ToolStripMenuItem.Text = "随机性分析";
			// 
			// 均值与线性复杂度ToolStripMenuItem
			// 
			this.均值与线性复杂度ToolStripMenuItem.Name = "均值与线性复杂度ToolStripMenuItem";
			this.均值与线性复杂度ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.均值与线性复杂度ToolStripMenuItem.Text = "均值与线性复杂度";
			this.均值与线性复杂度ToolStripMenuItem.Click += new System.EventHandler(this.均值与线性复杂度ToolStripMenuItemClick);
			// 
			// 最近2次的冗余度ToolStripMenuItem
			// 
			this.最近2次的冗余度ToolStripMenuItem.Name = "最近2次的冗余度ToolStripMenuItem";
			this.最近2次的冗余度ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.最近2次的冗余度ToolStripMenuItem.Text = "最近2次的冗余度";
			this.最近2次的冗余度ToolStripMenuItem.Click += new System.EventHandler(this.最近2次的冗余度ToolStripMenuItemClick);
			// 
			// 最近3次的冗余度ToolStripMenuItem
			// 
			this.最近3次的冗余度ToolStripMenuItem.Name = "最近3次的冗余度ToolStripMenuItem";
			this.最近3次的冗余度ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.最近3次的冗余度ToolStripMenuItem.Text = "最近3次的冗余度";
			this.最近3次的冗余度ToolStripMenuItem.Click += new System.EventHandler(this.最近3次的冗余度ToolStripMenuItemClick);
			// 
			// 最近4次的冗余度ToolStripMenuItem
			// 
			this.最近4次的冗余度ToolStripMenuItem.Name = "最近4次的冗余度ToolStripMenuItem";
			this.最近4次的冗余度ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.最近4次的冗余度ToolStripMenuItem.Text = "最近4次的冗余度";
			this.最近4次的冗余度ToolStripMenuItem.Click += new System.EventHandler(this.最近4次的冗余度ToolStripMenuItemClick);
			// 
			// menuStrip1
			// 
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.基本数据分析ToolStripMenuItem,
									this.周期统计分析ToolStripMenuItem,
									this.其它分析ToolStripMenuItem,
									this.帮助ToolStripMenuItem,
									this.退出ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(734, 24);
			this.menuStrip1.TabIndex = 4;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 周期统计分析ToolStripMenuItem
			// 
			this.周期统计分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.单个数字频数分析ToolStripMenuItem,
									this.单个数相同周期ToolStripMenuItem,
									this.两个数相同周期ToolStripMenuItem,
									this.三个数相同周期ToolStripMenuItem,
									this.twoSameInOneToolStripMenuItem});
			this.周期统计分析ToolStripMenuItem.Name = "周期统计分析ToolStripMenuItem";
			this.周期统计分析ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.周期统计分析ToolStripMenuItem.Text = "周期统计分析";
			// 
			// 单个数字频数分析ToolStripMenuItem
			// 
			this.单个数字频数分析ToolStripMenuItem.Name = "单个数字频数分析ToolStripMenuItem";
			this.单个数字频数分析ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.单个数字频数分析ToolStripMenuItem.Text = "单个数字频数分析";
			this.单个数字频数分析ToolStripMenuItem.Click += new System.EventHandler(this.单个数字频数分析ToolStripMenuItemClick);
			// 
			// 单个数相同周期ToolStripMenuItem
			// 
			this.单个数相同周期ToolStripMenuItem.Name = "单个数相同周期ToolStripMenuItem";
			this.单个数相同周期ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.单个数相同周期ToolStripMenuItem.Text = "OneInterval";
			this.单个数相同周期ToolStripMenuItem.Click += new System.EventHandler(this.单个数相同周期ToolStripMenuItemClick);
			// 
			// 两个数相同周期ToolStripMenuItem
			// 
			this.两个数相同周期ToolStripMenuItem.Name = "两个数相同周期ToolStripMenuItem";
			this.两个数相同周期ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.两个数相同周期ToolStripMenuItem.Text = "TwoInterval";
			this.两个数相同周期ToolStripMenuItem.Click += new System.EventHandler(this.两个数相同周期ToolStripMenuItemClick);
			// 
			// 三个数相同周期ToolStripMenuItem
			// 
			this.三个数相同周期ToolStripMenuItem.Name = "三个数相同周期ToolStripMenuItem";
			this.三个数相同周期ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.三个数相同周期ToolStripMenuItem.Text = "ThreeInterval";
			this.三个数相同周期ToolStripMenuItem.Click += new System.EventHandler(this.三个数相同周期ToolStripMenuItemClick);
			// 
			// twoSameInOneToolStripMenuItem
			// 
			this.twoSameInOneToolStripMenuItem.Name = "twoSameInOneToolStripMenuItem";
			this.twoSameInOneToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
			this.twoSameInOneToolStripMenuItem.Text = "TwoSameInOnce";
			this.twoSameInOneToolStripMenuItem.Click += new System.EventHandler(this.TwoSameInOneToolStripMenuItemClick);
			// 
			// 其它分析ToolStripMenuItem
			// 
			this.其它分析ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.测试ToolStripMenuItem,
									this.toolStripMenuItem2,
									this.toolStripMenuItem3,
									this.toolStripMenuItem4,
									this.toolStripMenuItem5,
									this.toolStripMenuItem6,
									this.toolStripMenuItem7,
									this.toolStripMenuItem8,
									this.toolStripMenuItem9,
									this.toolStripMenuItem10});
			this.其它分析ToolStripMenuItem.Name = "其它分析ToolStripMenuItem";
			this.其它分析ToolStripMenuItem.Size = new System.Drawing.Size(89, 20);
			this.其它分析ToolStripMenuItem.Text = "单个数字分析";
			// 
			// 测试ToolStripMenuItem
			// 
			this.测试ToolStripMenuItem.Name = "测试ToolStripMenuItem";
			this.测试ToolStripMenuItem.Size = new System.Drawing.Size(76, 22);
			this.测试ToolStripMenuItem.Text = "1";
			this.测试ToolStripMenuItem.Click += new System.EventHandler(this.测试ToolStripMenuItemClick);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem2.Text = "2";
			this.toolStripMenuItem2.Click += new System.EventHandler(this.ToolStripMenuItem2Click);
			// 
			// toolStripMenuItem3
			// 
			this.toolStripMenuItem3.Name = "toolStripMenuItem3";
			this.toolStripMenuItem3.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem3.Text = "3";
			this.toolStripMenuItem3.Click += new System.EventHandler(this.ToolStripMenuItem3Click);
			// 
			// toolStripMenuItem4
			// 
			this.toolStripMenuItem4.Name = "toolStripMenuItem4";
			this.toolStripMenuItem4.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem4.Text = "4";
			this.toolStripMenuItem4.Click += new System.EventHandler(this.ToolStripMenuItem4Click);
			// 
			// toolStripMenuItem5
			// 
			this.toolStripMenuItem5.Name = "toolStripMenuItem5";
			this.toolStripMenuItem5.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem5.Text = "5";
			this.toolStripMenuItem5.Click += new System.EventHandler(this.ToolStripMenuItem5Click);
			// 
			// toolStripMenuItem6
			// 
			this.toolStripMenuItem6.Name = "toolStripMenuItem6";
			this.toolStripMenuItem6.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem6.Text = "6";
			this.toolStripMenuItem6.Click += new System.EventHandler(this.ToolStripMenuItem6Click);
			// 
			// toolStripMenuItem7
			// 
			this.toolStripMenuItem7.Name = "toolStripMenuItem7";
			this.toolStripMenuItem7.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem7.Text = "7";
			this.toolStripMenuItem7.Click += new System.EventHandler(this.ToolStripMenuItem7Click);
			// 
			// toolStripMenuItem8
			// 
			this.toolStripMenuItem8.Name = "toolStripMenuItem8";
			this.toolStripMenuItem8.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem8.Text = "8";
			this.toolStripMenuItem8.Click += new System.EventHandler(this.ToolStripMenuItem8Click);
			// 
			// toolStripMenuItem9
			// 
			this.toolStripMenuItem9.Name = "toolStripMenuItem9";
			this.toolStripMenuItem9.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem9.Text = "9";
			this.toolStripMenuItem9.Click += new System.EventHandler(this.ToolStripMenuItem9Click);
			// 
			// toolStripMenuItem10
			// 
			this.toolStripMenuItem10.Name = "toolStripMenuItem10";
			this.toolStripMenuItem10.Size = new System.Drawing.Size(76, 22);
			this.toolStripMenuItem10.Text = "0";
			this.toolStripMenuItem10.Click += new System.EventHandler(this.ToolStripMenuItem10Click);
			// 
			// 帮助ToolStripMenuItem
			// 
			this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.关于ToolStripMenuItem,
									this.说明ToolStripMenuItem});
			this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.帮助ToolStripMenuItem.Text = "帮助";
			// 
			// 关于ToolStripMenuItem
			// 
			this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
			this.关于ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
			this.关于ToolStripMenuItem.Text = "关于";
			// 
			// 说明ToolStripMenuItem
			// 
			this.说明ToolStripMenuItem.Name = "说明ToolStripMenuItem";
			this.说明ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
			this.说明ToolStripMenuItem.Text = "说明";
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItemClick);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(734, 633);
			this.Controls.Add(this.menuStrip1);
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "随机性统计分析软件";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripMenuItem 最近4次的冗余度ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 最近3次的冗余度ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 最近2次的冗余度ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem9;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem8;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem7;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
		private System.Windows.Forms.ToolStripMenuItem 测试ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem twoSameInOneToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 三个数相同周期ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 两个数相同周期ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 单个数相同周期ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 单个数字频数分析ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 说明ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 其它分析ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 周期统计分析ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 均值与线性复杂度ToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem 基本数据分析ToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStrip1;
	}
}
