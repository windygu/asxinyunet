/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-4-5
 * Time: 9:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace LotteryTicketSoft.GraphForm
{
	partial class DataPredict
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDataCount = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtDataCount);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(6, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "设置";
            // 
            // txtDataCount
            // 
            this.txtDataCount.Location = new System.Drawing.Point(97, 16);
            this.txtDataCount.Name = "txtDataCount";
            this.txtDataCount.Size = new System.Drawing.Size(48, 23);
            this.txtDataCount.TabIndex = 1;
            this.txtDataCount.Text = "100";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "计算数据期数";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.comboBox1);
            this.groupBox2.Controls.Add(this.txtConditions);
            this.groupBox2.Controls.Add(this.btnCalculate);
            this.groupBox2.Location = new System.Drawing.Point(6, 73);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 337);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "计算指标";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "和值范围"});
            this.comboBox1.Location = new System.Drawing.Point(26, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(140, 22);
            this.comboBox1.TabIndex = 2;
            // 
            // txtConditions
            // 
            this.txtConditions.Location = new System.Drawing.Point(174, 48);
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(116, 23);
            this.txtConditions.TabIndex = 1;
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(203, 174);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(87, 27);
            this.btnCalculate.TabIndex = 0;
            this.btnCalculate.Text = "计算";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.BtnCalculateClick);
            // 
            // DataPredict
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 407);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "DataPredict";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "数据预测计算";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.TextBox txtConditions;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TextBox txtDataCount;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox1;
	}
}
