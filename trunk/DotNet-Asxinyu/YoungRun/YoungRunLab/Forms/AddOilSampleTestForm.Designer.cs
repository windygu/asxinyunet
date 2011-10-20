/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-27
 * 时间: 9:44
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab.Forms
{
	partial class AddOilSampleTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddOilSampleTestForm));
            this.addOilSampleTest1 = new YoungRunLab.Controls.AddOilSampleTest();
            this.SuspendLayout();
            // 
            // addOilSampleTest1
            // 
            this.addOilSampleTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addOilSampleTest1.Location = new System.Drawing.Point(0, 0);
            this.addOilSampleTest1.Name = "addOilSampleTest1";
            this.addOilSampleTest1.Size = new System.Drawing.Size(393, 192);
            this.addOilSampleTest1.TabIndex = 0;
            // 
            // AddOilSampleTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 192);
            this.Controls.Add(this.addOilSampleTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOilSampleTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "添加油样检测数据";
            this.ResumeLayout(false);

		}
		private YoungRunLab.Controls.AddOilSampleTest addOilSampleTest1;
	}
}
