namespace DotNet.Tools
{
    partial class StringToConst
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnConvert = new System.Windows.Forms.Button();
            this.txtNewText = new System.Windows.Forms.TextBox();
            this.txtOriginText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(294, 14);
            this.label2.TabIndex = 5;
            this.label2.Text = "说明：将单个字符串转换为常量,逗号为分隔符";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "需要转换的字符串";
            // 
            // btnConvert
            // 
            this.btnConvert.Location = new System.Drawing.Point(336, 32);
            this.btnConvert.Name = "btnConvert";
            this.btnConvert.Size = new System.Drawing.Size(87, 27);
            this.btnConvert.TabIndex = 8;
            this.btnConvert.Text = "转换";
            this.btnConvert.UseVisualStyleBackColor = true;
            this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
            // 
            // txtNewText
            // 
            this.txtNewText.Location = new System.Drawing.Point(6, 142);
            this.txtNewText.Multiline = true;
            this.txtNewText.Name = "txtNewText";
            this.txtNewText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtNewText.Size = new System.Drawing.Size(417, 292);
            this.txtNewText.TabIndex = 10;
            // 
            // txtOriginText
            // 
            this.txtOriginText.Location = new System.Drawing.Point(6, 65);
            this.txtOriginText.Multiline = true;
            this.txtOriginText.Name = "txtOriginText";
            this.txtOriginText.Size = new System.Drawing.Size(417, 71);
            this.txtOriginText.TabIndex = 9;
            // 
            // StringToConst
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtNewText);
            this.Controls.Add(this.txtOriginText);
            this.Controls.Add(this.btnConvert);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "StringToConst";
            this.Size = new System.Drawing.Size(430, 443);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnConvert;
        private System.Windows.Forms.TextBox txtNewText;
        private System.Windows.Forms.TextBox txtOriginText;
    }
}
