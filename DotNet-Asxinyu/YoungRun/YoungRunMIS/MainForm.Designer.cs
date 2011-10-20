/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-27
 * 时间: 10:05
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunMIS
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
			this.menuStrip1 = new System.Windows.Forms.MenuStrip();
			this.技术部ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.糠醛车间检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.白土车间检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.灌区采样检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.原料进厂检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.油样检测登记ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.研发实验管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.产品配方信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.生产储运ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.储运灌区信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.灌区日常测量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.系统配置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.系统设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.系统字典ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.StatusInfo = new DotNet.Tools.Controls.StausInfoShow();
			this.menuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStrip1
			// 
			this.menuStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.技术部ToolStripMenuItem,
									this.生产储运ToolStripMenuItem,
									this.系统配置ToolStripMenuItem,
									this.帮助ToolStripMenuItem,
									this.退出ToolStripMenuItem});
			this.menuStrip1.Location = new System.Drawing.Point(0, 0);
			this.menuStrip1.Name = "menuStrip1";
			this.menuStrip1.Size = new System.Drawing.Size(1041, 24);
			this.menuStrip1.TabIndex = 3;
			this.menuStrip1.Text = "menuStrip1";
			// 
			// 技术部ToolStripMenuItem
			// 
			this.技术部ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.糠醛车间检测ToolStripMenuItem,
									this.白土车间检测ToolStripMenuItem,
									this.灌区采样检测ToolStripMenuItem,
									this.原料进厂检测ToolStripMenuItem,
									this.toolStripSeparator1,
									this.油样检测登记ToolStripMenuItem,
									this.研发实验管理ToolStripMenuItem,
									this.产品配方信息ToolStripMenuItem});
			this.技术部ToolStripMenuItem.Name = "技术部ToolStripMenuItem";
			this.技术部ToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.技术部ToolStripMenuItem.Text = "技术部";
			// 
			// 糠醛车间检测ToolStripMenuItem
			// 
			this.糠醛车间检测ToolStripMenuItem.Name = "糠醛车间检测ToolStripMenuItem";
			this.糠醛车间检测ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.糠醛车间检测ToolStripMenuItem.Text = "糠醛车间检测";
			this.糠醛车间检测ToolStripMenuItem.Click += new System.EventHandler(this.糠醛车间检测ToolStripMenuItem_Click);
			// 
			// 白土车间检测ToolStripMenuItem
			// 
			this.白土车间检测ToolStripMenuItem.Name = "白土车间检测ToolStripMenuItem";
			this.白土车间检测ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.白土车间检测ToolStripMenuItem.Text = "白土车间检测";
			this.白土车间检测ToolStripMenuItem.Click += new System.EventHandler(this.白土车间检测ToolStripMenuItem_Click);
			// 
			// 灌区采样检测ToolStripMenuItem
			// 
			this.灌区采样检测ToolStripMenuItem.Name = "灌区采样检测ToolStripMenuItem";
			this.灌区采样检测ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.灌区采样检测ToolStripMenuItem.Text = "灌区采样检测";
			this.灌区采样检测ToolStripMenuItem.Click += new System.EventHandler(this.灌区采样检测ToolStripMenuItem_Click);
			// 
			// 原料进厂检测ToolStripMenuItem
			// 
			this.原料进厂检测ToolStripMenuItem.Name = "原料进厂检测ToolStripMenuItem";
			this.原料进厂检测ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.原料进厂检测ToolStripMenuItem.Text = "原料进厂检测";
			this.原料进厂检测ToolStripMenuItem.Click += new System.EventHandler(this.原料进厂检测ToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
			// 
			// 油样检测登记ToolStripMenuItem
			// 
			this.油样检测登记ToolStripMenuItem.Name = "油样检测登记ToolStripMenuItem";
			this.油样检测登记ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.油样检测登记ToolStripMenuItem.Text = "油样检测登记";
			this.油样检测登记ToolStripMenuItem.Click += new System.EventHandler(this.油样检测登记ToolStripMenuItem_Click);
			// 
			// 研发实验管理ToolStripMenuItem
			// 
			this.研发实验管理ToolStripMenuItem.Name = "研发实验管理ToolStripMenuItem";
			this.研发实验管理ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.研发实验管理ToolStripMenuItem.Text = "研发实验管理";
			// 
			// 产品配方信息ToolStripMenuItem
			// 
			this.产品配方信息ToolStripMenuItem.Name = "产品配方信息ToolStripMenuItem";
			this.产品配方信息ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.产品配方信息ToolStripMenuItem.Text = "产品配方信息";
			this.产品配方信息ToolStripMenuItem.Click += new System.EventHandler(this.产品配方信息ToolStripMenuItem_Click);
			// 
			// 生产储运ToolStripMenuItem
			// 
			this.生产储运ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.储运灌区信息ToolStripMenuItem,
									this.灌区日常测量ToolStripMenuItem});
			this.生产储运ToolStripMenuItem.Name = "生产储运ToolStripMenuItem";
			this.生产储运ToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.生产储运ToolStripMenuItem.Text = "生产储运";
			// 
			// 储运灌区信息ToolStripMenuItem
			// 
			this.储运灌区信息ToolStripMenuItem.Name = "储运灌区信息ToolStripMenuItem";
			this.储运灌区信息ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.储运灌区信息ToolStripMenuItem.Text = "储运灌区信息";
			this.储运灌区信息ToolStripMenuItem.Click += new System.EventHandler(this.储运灌区信息ToolStripMenuItem_Click);
			// 
			// 灌区日常测量ToolStripMenuItem
			// 
			this.灌区日常测量ToolStripMenuItem.Name = "灌区日常测量ToolStripMenuItem";
			this.灌区日常测量ToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
			this.灌区日常测量ToolStripMenuItem.Text = "灌区日常测量";
			this.灌区日常测量ToolStripMenuItem.Click += new System.EventHandler(this.灌区日常测量ToolStripMenuItem_Click);
			// 
			// 系统配置ToolStripMenuItem
			// 
			this.系统配置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.用户管理ToolStripMenuItem,
									this.系统设置ToolStripMenuItem,
									this.系统字典ToolStripMenuItem});
			this.系统配置ToolStripMenuItem.Name = "系统配置ToolStripMenuItem";
			this.系统配置ToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
			this.系统配置ToolStripMenuItem.Text = "系统配置";
			// 
			// 用户管理ToolStripMenuItem
			// 
			this.用户管理ToolStripMenuItem.Enabled = false;
			this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
			this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.用户管理ToolStripMenuItem.Text = "用户管理";
			this.用户管理ToolStripMenuItem.Click += new System.EventHandler(this.用户管理ToolStripMenuItem_Click);
			// 
			// 系统设置ToolStripMenuItem
			// 
			this.系统设置ToolStripMenuItem.Enabled = false;
			this.系统设置ToolStripMenuItem.Name = "系统设置ToolStripMenuItem";
			this.系统设置ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.系统设置ToolStripMenuItem.Text = "系统设置";
			// 
			// 系统字典ToolStripMenuItem
			// 
			this.系统字典ToolStripMenuItem.Name = "系统字典ToolStripMenuItem";
			this.系统字典ToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
			this.系统字典ToolStripMenuItem.Text = "系统字典";
			this.系统字典ToolStripMenuItem.Click += new System.EventHandler(this.系统字典ToolStripMenuItem_Click);
			// 
			// 帮助ToolStripMenuItem
			// 
			this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
			this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.帮助ToolStripMenuItem.Text = "帮助";
			// 
			// 退出ToolStripMenuItem
			// 
			this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
			this.退出ToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
			this.退出ToolStripMenuItem.Text = "退出";
			this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
			// 
			// StatusInfo
			// 
			this.StatusInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.StatusInfo.Location = new System.Drawing.Point(0, 642);
			this.StatusInfo.Name = "StatusInfo";
			this.StatusInfo.Size = new System.Drawing.Size(1041, 24);
			this.StatusInfo.TabIndex = 1;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1041, 666);
			this.Controls.Add(this.StatusInfo);
			this.Controls.Add(this.menuStrip1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.IsMdiContainer = true;
			this.MainMenuStrip = this.menuStrip1;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "宁波永润石化科技有限公司-数据管理-0.1测试版";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.menuStrip1.ResumeLayout(false);
			this.menuStrip1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private DotNet.Tools.Controls.StausInfoShow StatusInfo;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 技术部ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 生产储运ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统配置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 糠醛车间检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 白土车间检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灌区采样检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 原料进厂检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 油样检测登记ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 研发实验管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 储运灌区信息ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 灌区日常测量ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统字典ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 产品配方信息ToolStripMenuItem;
	}
}
