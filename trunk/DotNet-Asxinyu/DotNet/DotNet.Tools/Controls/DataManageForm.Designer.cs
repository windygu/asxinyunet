/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2011-10-5
 * 时间: 14:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace DotNet.Tools.Controls
{
	partial class DataManageForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataManageForm));
			this.DataManageControl = new DotNet.Tools.Controls.DataManage();
			this.SuspendLayout();
			// 
			// DataManageControl
			// 
			this.DataManageControl.AutoSize = true;
			this.DataManageControl.Dock = System.Windows.Forms.DockStyle.Fill;	
			
			
			this.DataManageControl.Location = new System.Drawing.Point(0, 0);
			this.DataManageControl.Name = "DataManageControl";
			this.DataManageControl.Size = new System.Drawing.Size(708, 431);
			this.DataManageControl.TabIndex = 0;
			// 
			// DataManageForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(708, 431);
			this.Controls.Add(this.DataManageControl);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "DataManageForm";
			this.Text = "TestControlForm";
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private DotNet.Tools.Controls.DataManage DataManageControl;
	}
}
