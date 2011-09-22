/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-18
 * 时间: 13:42
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace ResouceManagement
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
			this.veryCdTypeList1 = new ResouceManagement.Controls.VeryCdTypeList();
			this.SuspendLayout();
			// 
			// veryCdTypeList1
			// 
			this.veryCdTypeList1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.veryCdTypeList1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.veryCdTypeList1.Location = new System.Drawing.Point(0, 0);
			this.veryCdTypeList1.Name = "veryCdTypeList1";
			this.veryCdTypeList1.Size = new System.Drawing.Size(674, 446);
			this.veryCdTypeList1.TabIndex = 0;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(674, 446);
			this.Controls.Add(this.veryCdTypeList1);
			this.Name = "MainForm";
			this.Text = "ResouceManagement";
			this.Load += new System.EventHandler(this.MainForm_Load);
			this.ResumeLayout(false);
        }

        private Controls.VeryCdTypeList veryCdTypeList1;

//        private Controls.VeryCdTypeList veryCdTypeList1;
      
	}
}
