/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-30
 * 时间: 12:13
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunST.Forms
{
	partial class OilTankInfoManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OilTankInfoManageForm));
            this.oilTankInfoManage1 = new YoungRunST.Controls.OilTankInfoManage();
            this.SuspendLayout();
            // 
            // oilTankInfoManage1
            // 
            this.oilTankInfoManage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oilTankInfoManage1.Location = new System.Drawing.Point(0, 0);
            this.oilTankInfoManage1.Name = "oilTankInfoManage1";
            this.oilTankInfoManage1.Size = new System.Drawing.Size(794, 487);
            this.oilTankInfoManage1.TabIndex = 0;
            // 
            // OilTankInfoManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 487);
            this.Controls.Add(this.oilTankInfoManage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OilTankInfoManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "油罐信息管理";
            this.ResumeLayout(false);

		}
		private YoungRunST.Controls.OilTankInfoManage oilTankInfoManage1;
	}
}
