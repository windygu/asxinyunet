/*
 * 由SharpDevelop创建。
 * 用户： 董斌辉
 * 日期: 2011-10-4
 * 时间: 17:15
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace DotNet.Tools.Controls
{
	partial class SearchConditionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchConditionForm));
            this.searchCondition1 = new DotNet.Tools.Controls.SearchCondition();
            this.SuspendLayout();
            // 
            // searchCondition1
            // 
            this.searchCondition1.CurConditions = "";
            this.searchCondition1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.searchCondition1.IsAotoMode = false;
            this.searchCondition1.Location = new System.Drawing.Point(0, 0);
            this.searchCondition1.Name = "searchCondition1";
            this.searchCondition1.Size = new System.Drawing.Size(419, 221);
            this.searchCondition1.TabIndex = 0;
            // 
            // SearchConditionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 221);
            this.Controls.Add(this.searchCondition1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchConditionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "设置搜索条件";
            this.ResumeLayout(false);

		}
		private DotNet.Tools.Controls.SearchCondition searchCondition1;
	}
}
