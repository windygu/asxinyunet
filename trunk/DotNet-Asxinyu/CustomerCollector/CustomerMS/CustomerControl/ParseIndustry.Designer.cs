/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-5
 * 时间: 13:27
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace CustomerMS.CustomerControl
{
	partial class ParseIndustry
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
			this.btnExit = new System.Windows.Forms.Button();
			this.btnParse = new System.Windows.Forms.Button();
			this.txtIndustry = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnExit
			// 
			this.btnExit.Location = new System.Drawing.Point(361, 271);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(75, 23);
			this.btnExit.TabIndex = 6;
			this.btnExit.Text = "退出";
			this.btnExit.UseVisualStyleBackColor = true;
			this.btnExit.Click += new System.EventHandler(this.BtnExitClick);
			// 
			// btnParse
			// 
			this.btnParse.Location = new System.Drawing.Point(135, 271);
			this.btnParse.Name = "btnParse";
			this.btnParse.Size = new System.Drawing.Size(75, 23);
			this.btnParse.TabIndex = 5;
			this.btnParse.Text = "解析";
			this.btnParse.UseVisualStyleBackColor = true;
			this.btnParse.Click += new System.EventHandler(this.BtnParseClick);
			// 
			// txtIndustry
			// 
			this.txtIndustry.Dock = System.Windows.Forms.DockStyle.Top;
			this.txtIndustry.Location = new System.Drawing.Point(0, 0);
			this.txtIndustry.Multiline = true;
			this.txtIndustry.Name = "txtIndustry";
			this.txtIndustry.Size = new System.Drawing.Size(570, 265);
			this.txtIndustry.TabIndex = 4;
			// 
			// ParseIndustry
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnParse);
			this.Controls.Add(this.txtIndustry);
			this.Name = "ParseIndustry";
			this.Size = new System.Drawing.Size(570, 303);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.TextBox txtIndustry;
		private System.Windows.Forms.Button btnParse;
		private System.Windows.Forms.Button btnExit;
	}
}
