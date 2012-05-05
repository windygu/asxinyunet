namespace DotNet.Tools
{
    partial class DotWMITemplate
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtClassName = new System.Windows.Forms.TextBox();
            this.txtNameSpace = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.CombTemplate = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtOriginText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtOutputFolder = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnGeneration = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "封装的类名";
            // 
            // txtClassName
            // 
            this.txtClassName.Location = new System.Drawing.Point(93, 46);
            this.txtClassName.Name = "txtClassName";
            this.txtClassName.Size = new System.Drawing.Size(355, 23);
            this.txtClassName.TabIndex = 1;
            this.txtClassName.Text = "TestName";
            // 
            // txtNameSpace
            // 
            this.txtNameSpace.Location = new System.Drawing.Point(93, 8);
            this.txtNameSpace.Name = "txtNameSpace";
            this.txtNameSpace.Size = new System.Drawing.Size(355, 23);
            this.txtNameSpace.TabIndex = 3;
            this.txtNameSpace.Text = "DotNet.WMI";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 2;
            this.label2.Text = "命名空间";
            // 
            // CombTemplate
            // 
            this.CombTemplate.FormattingEnabled = true;
            this.CombTemplate.Items.AddRange(new object[] {
            "封装WMI模板",
            "封装WMI常量"});
            this.CombTemplate.Location = new System.Drawing.Point(93, 112);
            this.CombTemplate.Name = "CombTemplate";
            this.CombTemplate.Size = new System.Drawing.Size(355, 22);
            this.CombTemplate.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 5;
            this.label3.Text = "选择模板";
            // 
            // txtOriginText
            // 
            this.txtOriginText.Location = new System.Drawing.Point(42, 166);
            this.txtOriginText.Multiline = true;
            this.txtOriginText.Name = "txtOriginText";
            this.txtOriginText.Size = new System.Drawing.Size(406, 263);
            this.txtOriginText.TabIndex = 6;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(27, 147);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 14);
            this.label4.TabIndex = 7;
            this.label4.Text = "元数据(表结构)";
            // 
            // txtOutputFolder
            // 
            this.txtOutputFolder.Location = new System.Drawing.Point(92, 79);
            this.txtOutputFolder.Name = "txtOutputFolder";
            this.txtOutputFolder.Size = new System.Drawing.Size(355, 23);
            this.txtOutputFolder.TabIndex = 9;
            this.txtOutputFolder.Text = "GenereateFiles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(22, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 8;
            this.label5.Text = "输出目录";
            // 
            // btnGeneration
            // 
            this.btnGeneration.Location = new System.Drawing.Point(372, 435);
            this.btnGeneration.Name = "btnGeneration";
            this.btnGeneration.Size = new System.Drawing.Size(75, 23);
            this.btnGeneration.TabIndex = 10;
            this.btnGeneration.Text = "生成";
            this.btnGeneration.UseVisualStyleBackColor = true;
            this.btnGeneration.Click += new System.EventHandler(this.btnGeneration_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(280, 435);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 11;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // DotWMITemplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.btnGeneration);
            this.Controls.Add(this.txtOutputFolder);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtOriginText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.CombTemplate);
            this.Controls.Add(this.txtNameSpace);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtClassName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Name = "DotWMITemplate";
            this.Size = new System.Drawing.Size(464, 464);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtClassName;
        private System.Windows.Forms.TextBox txtNameSpace;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox CombTemplate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtOriginText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtOutputFolder;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnGeneration;
        private System.Windows.Forms.Button btnReset;
    }
}
