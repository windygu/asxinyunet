/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-8-24
 * Time: 22:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CustomerMS
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
			this.customerInfo1 = new CustomerMS.CustomerControl.CustomerInfo();
			this.SuspendLayout();
			// 
			// customerInfo1
			// 
			this.customerInfo1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.customerInfo1.Location = new System.Drawing.Point(0, 0);
			this.customerInfo1.Name = "customerInfo1";
			this.customerInfo1.Size = new System.Drawing.Size(1036, 668);
			this.customerInfo1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1036, 668);
			this.Controls.Add(this.customerInfo1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "销售客户管理";
			this.ResumeLayout(false);
		}
		private CustomerMS.CustomerControl.CustomerInfo customerInfo1;
	}
}
