﻿namespace LotteryTicketSoft.GraphForm
{
	partial class DataPrediction
	{
		/// <summary> 
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region 组件设计器生成的代码

		/// <summary> 
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
            this.SaveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // winPage
            // 
            this.winPage.Location = new System.Drawing.Point(232, 0);
            this.winPage.Size = new System.Drawing.Size(423, 25);
            // 
            // SaveFileDialog
            // 
            this.SaveFileDialog.CheckFileExists = true;
            this.SaveFileDialog.DefaultExt = "xml";
            this.SaveFileDialog.Filter = "\"XML文件|*.xml\"";
            this.SaveFileDialog.Title = "保存文件";
            this.SaveFileDialog.ValidateNames = false;
            // 
            // DataPrediction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "DataPrediction";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.SaveFileDialog SaveFileDialog;
	}
}
