﻿/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-6
 * 时间: 10:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace CustomerMS.BasicForm
{
	partial class Form1
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
			this.getIndustryList1 = new CustomerMS.CustomerControl.GetIndustryList();
			this.SuspendLayout();
			// 
			// getIndustryList1
			// 
			this.getIndustryList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.getIndustryList1.Location = new System.Drawing.Point(0, 0);
			this.getIndustryList1.Name = "getIndustryList1";
			this.getIndustryList1.Size = new System.Drawing.Size(579, 480);
			this.getIndustryList1.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(579, 480);
			this.Controls.Add(this.getIndustryList1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);
		}
		private CustomerMS.CustomerControl.GetIndustryList getIndustryList1;
	}
}
