﻿namespace AsxinyuPlateForm
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.stausInfoShow1 = new DotNet.WinForm.Controls.StausInfoShow();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.基础数据ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lottickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资源管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.页面管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ed2k链接管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.资源管理ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.系统工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // stausInfoShow1
            // 
            this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stausInfoShow1.Location = new System.Drawing.Point(0, 739);
            this.stausInfoShow1.Name = "stausInfoShow1";
            this.stausInfoShow1.Size = new System.Drawing.Size(1010, 27);
            this.stausInfoShow1.TabIndex = 1;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.基础数据ToolStripMenuItem,
            this.lottickToolStripMenuItem,
            this.资源管理ToolStripMenuItem,
            this.资源管理ToolStripMenuItem1,
            this.系统工具ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1010, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 基础数据ToolStripMenuItem
            // 
            this.基础数据ToolStripMenuItem.Name = "基础数据ToolStripMenuItem";
            this.基础数据ToolStripMenuItem.Size = new System.Drawing.Size(92, 20);
            this.基础数据ToolStripMenuItem.Text = " 基础数据";
            // 
            // lottickToolStripMenuItem
            // 
            this.lottickToolStripMenuItem.Name = "lottickToolStripMenuItem";
            this.lottickToolStripMenuItem.Size = new System.Drawing.Size(76, 20);
            this.lottickToolStripMenuItem.Text = "Lottick";
            // 
            // 资源管理ToolStripMenuItem
            // 
            this.资源管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.页面管理ToolStripMenuItem,
            this.ed2k链接管理ToolStripMenuItem});
            this.资源管理ToolStripMenuItem.Name = "资源管理ToolStripMenuItem";
            this.资源管理ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.资源管理ToolStripMenuItem.Text = "资源采集";
            // 
            // 页面管理ToolStripMenuItem
            // 
            this.页面管理ToolStripMenuItem.Name = "页面管理ToolStripMenuItem";
            this.页面管理ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.页面管理ToolStripMenuItem.Text = "页面管理";
            this.页面管理ToolStripMenuItem.Click += new System.EventHandler(this.页面管理ToolStripMenuItem_Click);
            // 
            // ed2k链接管理ToolStripMenuItem
            // 
            this.ed2k链接管理ToolStripMenuItem.Name = "ed2k链接管理ToolStripMenuItem";
            this.ed2k链接管理ToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.ed2k链接管理ToolStripMenuItem.Text = "Ed2k链接管理";
            this.ed2k链接管理ToolStripMenuItem.Click += new System.EventHandler(this.ed2k链接管理ToolStripMenuItem_Click);
            // 
            // 资源管理ToolStripMenuItem1
            // 
            this.资源管理ToolStripMenuItem1.Name = "资源管理ToolStripMenuItem1";
            this.资源管理ToolStripMenuItem1.Size = new System.Drawing.Size(84, 20);
            this.资源管理ToolStripMenuItem1.Text = "资源管理";
            // 
            // 系统工具ToolStripMenuItem
            // 
            this.系统工具ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.数据转换ToolStripMenuItem});
            this.系统工具ToolStripMenuItem.Name = "系统工具ToolStripMenuItem";
            this.系统工具ToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.系统工具ToolStripMenuItem.Text = "系统工具";
            // 
            // 数据转换ToolStripMenuItem
            // 
            this.数据转换ToolStripMenuItem.Name = "数据转换ToolStripMenuItem";
            this.数据转换ToolStripMenuItem.Size = new System.Drawing.Size(156, 22);
            this.数据转换ToolStripMenuItem.Text = "数据库转换";
            this.数据转换ToolStripMenuItem.Click += new System.EventHandler(this.数据转换ToolStripMenuItem_Click);
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
            this.ClientSize = new System.Drawing.Size(1010, 766);
            this.Controls.Add(this.stausInfoShow1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Asxinyu个人管理系统";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DotNet.WinForm.Controls.StausInfoShow stausInfoShow1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 基础数据ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lottickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资源管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 系统工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 资源管理ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 页面管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ed2k链接管理ToolStripMenuItem;
    }
}

