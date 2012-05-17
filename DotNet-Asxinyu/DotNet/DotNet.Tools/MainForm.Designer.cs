namespace DotNet.Tools
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.wMI代码生成ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stringBuilder转换ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.字符串转换为常量ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.wMI代码生成ToolStripMenuItem,
            this.stringBuilder转换ToolStripMenuItem,
            this.字符串转换为常量ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(684, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // wMI代码生成ToolStripMenuItem
            // 
            this.wMI代码生成ToolStripMenuItem.Name = "wMI代码生成ToolStripMenuItem";
            this.wMI代码生成ToolStripMenuItem.Size = new System.Drawing.Size(83, 20);
            this.wMI代码生成ToolStripMenuItem.Text = "WMI代码生成";
            this.wMI代码生成ToolStripMenuItem.Click += new System.EventHandler(this.wMI代码生成ToolStripMenuItem_Click);
            // 
            // stringBuilder转换ToolStripMenuItem
            // 
            this.stringBuilder转换ToolStripMenuItem.Name = "stringBuilder转换ToolStripMenuItem";
            this.stringBuilder转换ToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.stringBuilder转换ToolStripMenuItem.Text = "StringBuilder转换";
            this.stringBuilder转换ToolStripMenuItem.Click += new System.EventHandler(this.stringBuilder转换ToolStripMenuItem_Click);
            // 
            // 字符串转换为常量ToolStripMenuItem
            // 
            this.字符串转换为常量ToolStripMenuItem.Name = "字符串转换为常量ToolStripMenuItem";
            this.字符串转换为常量ToolStripMenuItem.Size = new System.Drawing.Size(113, 20);
            this.字符串转换为常量ToolStripMenuItem.Text = "字符串转换为常量";
            this.字符串转换为常量ToolStripMenuItem.Click += new System.EventHandler(this.字符串转换为常量ToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 469);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DotNet工具集合";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem wMI代码生成ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stringBuilder转换ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 字符串转换为常量ToolStripMenuItem;
    }
}

