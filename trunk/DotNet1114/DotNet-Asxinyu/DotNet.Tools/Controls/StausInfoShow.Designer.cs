/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 8:52
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace DotNet.Tools.Controls
{
	partial class StausInfoShow
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the control.
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
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.firstInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.secondInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.thirdInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.firstInfo,
            this.toolStripStatusLabel2,
            this.secondInfo,
            this.toolStripStatusLabel4,
            this.thirdInfo});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(503, 24);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // firstInfo
            // 
            this.firstInfo.Name = "firstInfo";
            this.firstInfo.Size = new System.Drawing.Size(141, 19);
            this.firstInfo.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(17, 19);
            this.toolStripStatusLabel2.Text = "||";
            // 
            // secondInfo
            // 
            this.secondInfo.Name = "secondInfo";
            this.secondInfo.Size = new System.Drawing.Size(141, 19);
            this.secondInfo.Spring = true;
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(17, 19);
            this.toolStripStatusLabel4.Text = "||";
            // 
            // thirdInfo
            // 
            this.thirdInfo.Name = "thirdInfo";
            this.thirdInfo.Size = new System.Drawing.Size(141, 19);
            this.thirdInfo.Spring = true;
            // 
            // StausInfoShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.statusStrip1);
            this.Name = "StausInfoShow";
            this.Size = new System.Drawing.Size(503, 24);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ToolStripStatusLabel thirdInfo;
		private System.Windows.Forms.ToolStripStatusLabel secondInfo;
		private System.Windows.Forms.ToolStripStatusLabel firstInfo;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.StatusStrip statusStrip1;
	}
}
