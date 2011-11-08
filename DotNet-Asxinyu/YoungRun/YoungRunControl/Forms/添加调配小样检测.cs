/*
 * 由SharpDevelop创建。
 * 用户：asxinyu@qq.com
 * 日期: 2011-10-16
 * 时间: 12:56
 * 
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using DotNet.Tools.Controls ;
using YoungRunControl.Controls ;

namespace YoungRunControl.Forms
{

 
	/// <summary>
	/// tb_ReseachSample
	/// </summary>
	public partial class AddReseachSampleForm : Form
	{
	        #region 自动生成的代码,窗体初始化
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
				this.EntityControl = new AddReseachSample();
			this.SuspendLayout();
			// 
			// EntityControl
			// 						
			this.EntityControl.CutShowMode = DotNet.Tools.Controls.FormShowMode.ContinueDisplay;
			this.EntityControl.Dock = System.Windows.Forms.DockStyle.Fill;
			this.EntityControl.FixedSqlCondition = null;
			this.EntityControl.Location = new System.Drawing.Point(0, 0);
			this.EntityControl.Name = "EntityControl";
			this.EntityControl.Size = new System.Drawing.Size(400, 494);
			this.EntityControl.TabIndex = 0;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(400, 494);
			this.Controls.Add(this.EntityControl);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Form1";
			this.ResumeLayout(false);
		    }
		    private AddReseachSample EntityControl;		
		
		public AddReseachSampleForm ()
		{
			InitializeComponent();			
		}
		#endregion
		#region 设置,需要加上相关属性的设置，给控件传递参数
		public void InitializeSettings(FormShowMode showMode,string searcgCondtion = "",string fixCondition="")
		{
			this.EntityControl.InitializeSettings (showMode,searcgCondtion ,fixCondition ) ;
		}
		#endregion
	}
}
