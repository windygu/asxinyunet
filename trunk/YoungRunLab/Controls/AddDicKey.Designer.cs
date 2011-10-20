namespace YoungRunLab.Controls
{
    partial class AddDicKey
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
        	this.combTypeName = new System.Windows.Forms.ComboBox();
        	this.txtValue = new System.Windows.Forms.TextBox();
        	this.txtRemark = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.btnCancle = new System.Windows.Forms.Button();
        	this.btnOK = new System.Windows.Forms.Button();
        	this.SuspendLayout();
        	// 
        	// combTypeName
        	// 
        	this.combTypeName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.combTypeName.FormattingEnabled = true;
        	this.combTypeName.Location = new System.Drawing.Point(68, 9);
        	this.combTypeName.Name = "combTypeName";
        	this.combTypeName.Size = new System.Drawing.Size(194, 22);
        	this.combTypeName.TabIndex = 1;
        	// 
        	// txtValue
        	// 
        	this.txtValue.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtValue.Location = new System.Drawing.Point(68, 39);
        	this.txtValue.Name = "txtValue";
        	this.txtValue.Size = new System.Drawing.Size(194, 23);
        	this.txtValue.TabIndex = 2;
        	// 
        	// txtRemark
        	// 
        	this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtRemark.Location = new System.Drawing.Point(68, 68);
        	this.txtRemark.Name = "txtRemark";
        	this.txtRemark.Size = new System.Drawing.Size(194, 23);
        	this.txtRemark.TabIndex = 3;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label4.Location = new System.Drawing.Point(34, 72);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(35, 14);
        	this.label4.TabIndex = 29;
        	this.label4.Text = "备注";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label2.Location = new System.Drawing.Point(20, 43);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(49, 14);
        	this.label2.TabIndex = 25;
        	this.label2.Text = "数据值";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label1.Location = new System.Drawing.Point(6, 14);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(63, 14);
        	this.label1.TabIndex = 24;
        	this.label1.Text = "类型名称";
        	// 
        	// btnCancle
        	// 
        	this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnCancle.Location = new System.Drawing.Point(159, 97);
        	this.btnCancle.Name = "btnCancle";
        	this.btnCancle.Size = new System.Drawing.Size(78, 27);
        	this.btnCancle.TabIndex = 5;
        	this.btnCancle.Text = "取消";
        	this.btnCancle.UseVisualStyleBackColor = true;
        	this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
        	// 
        	// btnOK
        	// 
        	this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnOK.Location = new System.Drawing.Point(68, 97);
        	this.btnOK.Name = "btnOK";
        	this.btnOK.Size = new System.Drawing.Size(78, 27);
        	this.btnOK.TabIndex = 4;
        	this.btnOK.Text = "确定";
        	this.btnOK.UseVisualStyleBackColor = true;
        	this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        	// 
        	// AddDicKey
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.combTypeName);
        	this.Controls.Add(this.txtValue);
        	this.Controls.Add(this.txtRemark);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.btnCancle);
        	this.Controls.Add(this.btnOK);
        	this.Name = "AddDicKey";
        	this.Size = new System.Drawing.Size(272, 131);
        	this.Load += new System.EventHandler(this.AddDicKey_Load);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ComboBox combTypeName;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
    }
}
