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
	/// tb_BtTestData
	/// </summary>
	public partial class AddBtTestDataForm : Form
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
            this.EntityControl = new YoungRunControl.Controls.AddBtTestData();
            this.addBtTestData1 = new YoungRunControl.Controls.AddBtTestData();
            this.SuspendLayout();
            // 
            // EntityControl
            // 
            this.EntityControl.CutModel = null;
            this.EntityControl.CutSearchCondition = " and ";
            this.EntityControl.CutShowMode = DotNet.Tools.Controls.FormShowMode.ContinueAdd;
            this.EntityControl.FixedSqlCondition = null;
            this.EntityControl.Location = new System.Drawing.Point(31, -10);
            this.EntityControl.Name = "EntityControl";
            this.EntityControl.Size = new System.Drawing.Size(398, 414);
            this.EntityControl.TabIndex = 0;
            // 
            // addBtTestData1
            // 
            this.addBtTestData1.CutModel = null;
            this.addBtTestData1.CutSearchCondition = "";
            this.addBtTestData1.CutShowMode = DotNet.Tools.Controls.FormShowMode.ContinueAdd;
            this.addBtTestData1.FixedSqlCondition = "";
            this.addBtTestData1.Location = new System.Drawing.Point(-2, 12);
            this.addBtTestData1.Name = "addBtTestData1";
            this.addBtTestData1.Size = new System.Drawing.Size(402, 326);
            this.addBtTestData1.TabIndex = 0;
            // 
            // AddBtTestDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 333);
            this.Controls.Add(this.addBtTestData1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddBtTestDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Form1";
            this.ResumeLayout(false);

		    }

            private AddBtTestData addBtTestData1;
		    private AddBtTestData EntityControl;		
		
		public AddBtTestDataForm ()
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
