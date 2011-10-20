/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-10-6
 * 时间: 15:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab.Forms
{
	partial class AddYLJCTestForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddYLJCTestForm));
            this.addYLJCTest1 = new YoungRunLab.Controls.AddYLJCTest();
            this.SuspendLayout();
            // 
            // addYLJCTest1
            // 
            this.addYLJCTest1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addYLJCTest1.Location = new System.Drawing.Point(0, 0);
            this.addYLJCTest1.Name = "addYLJCTest1";
            this.addYLJCTest1.Size = new System.Drawing.Size(257, 282);
            this.addYLJCTest1.TabIndex = 0;
            // 
            // AddYLJCTestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(257, 282);
            this.Controls.Add(this.addYLJCTest1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddYLJCTestForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "原料进厂检测";
            this.ResumeLayout(false);

		}

        private Controls.AddYLJCTest addYLJCTest1;
	}
}
