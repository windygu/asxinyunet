/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-30
 * 时间: 11:18
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunST.Forms
{
	partial class OilTankSTManageForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OilTankSTManageForm));
            this.oilTankSTManage1 = new YoungRunST.Controls.OilTankSTManage();
            this.SuspendLayout();
            // 
            // oilTankSTManage1
            // 
            this.oilTankSTManage1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.oilTankSTManage1.Location = new System.Drawing.Point(0, 0);
            this.oilTankSTManage1.Name = "oilTankSTManage1";
            this.oilTankSTManage1.Size = new System.Drawing.Size(803, 522);
            this.oilTankSTManage1.TabIndex = 0;
            // 
            // OilTankSTManageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 522);
            this.Controls.Add(this.oilTankSTManage1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OilTankSTManageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加油罐液位数据";
            this.ResumeLayout(false);

		}
		private YoungRunST.Controls.OilTankSTManage oilTankSTManage1;
	}
}
