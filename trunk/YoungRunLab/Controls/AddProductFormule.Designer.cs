namespace YoungRunLab.Controls
{
    partial class AddProductFormule
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
            this.combProductName = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dtUpdateTime = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtT501Count = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.txtBtCount = new System.Windows.Forms.TextBox();
            this.txtT602Count = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtYJCount = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // combProductName
            // 
            this.combProductName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.combProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combProductName.FormattingEnabled = true;
            this.combProductName.Items.AddRange(new object[] {
            "宁波大榭"});
            this.combProductName.Location = new System.Drawing.Point(69, 7);
            this.combProductName.Name = "combProductName";
            this.combProductName.Size = new System.Drawing.Size(130, 22);
            this.combProductName.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 88;
            this.label5.Text = "产品名称";
            // 
            // dtUpdateTime
            // 
            this.dtUpdateTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtUpdateTime.CustomFormat = "";
            this.dtUpdateTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtUpdateTime.Location = new System.Drawing.Point(69, 166);
            this.dtUpdateTime.Name = "dtUpdateTime";
            this.dtUpdateTime.Size = new System.Drawing.Size(130, 23);
            this.dtUpdateTime.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(6, 171);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 87;
            this.label8.Text = "更新时间";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(44, 231);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 27);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(34, 203);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 86;
            this.label4.Text = "备注";
            // 
            // txtT501Count
            // 
            this.txtT501Count.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtT501Count.Location = new System.Drawing.Point(69, 70);
            this.txtT501Count.Name = "txtT501Count";
            this.txtT501Count.Size = new System.Drawing.Size(130, 23);
            this.txtT501Count.TabIndex = 3;
            this.txtT501Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBtCount_KeyPress);
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(69, 198);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(130, 23);
            this.txtRemark.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 85;
            this.label2.Text = "白土用量";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 84;
            this.label1.Text = "T501用量";
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(126, 231);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(62, 27);
            this.btnCancle.TabIndex = 9;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // txtBtCount
            // 
            this.txtBtCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtBtCount.Location = new System.Drawing.Point(69, 38);
            this.txtBtCount.Name = "txtBtCount";
            this.txtBtCount.Size = new System.Drawing.Size(130, 23);
            this.txtBtCount.TabIndex = 2;
            this.txtBtCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBtCount_KeyPress);
            // 
            // txtT602Count
            // 
            this.txtT602Count.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtT602Count.Location = new System.Drawing.Point(69, 102);
            this.txtT602Count.Name = "txtT602Count";
            this.txtT602Count.Size = new System.Drawing.Size(130, 23);
            this.txtT602Count.TabIndex = 4;
            this.txtT602Count.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBtCount_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(6, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 92;
            this.label3.Text = "T602用量";
            // 
            // txtYJCount
            // 
            this.txtYJCount.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtYJCount.Location = new System.Drawing.Point(69, 134);
            this.txtYJCount.Name = "txtYJCount";
            this.txtYJCount.Size = new System.Drawing.Size(130, 23);
            this.txtYJCount.TabIndex = 5;
            this.txtYJCount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBtCount_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(6, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 94;
            this.label6.Text = "液碱用量";
            // 
            // AddProductFormule
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtYJCount);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtT602Count);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtBtCount);
            this.Controls.Add(this.combProductName);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dtUpdateTime);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtT501Count);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancle);
            this.Name = "AddProductFormule";
            this.Size = new System.Drawing.Size(204, 264);
            this.Load += new System.EventHandler(this.AddProductFormule_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox combProductName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtUpdateTime;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtT501Count;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.TextBox txtBtCount;
        private System.Windows.Forms.TextBox txtT602Count;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtYJCount;
        private System.Windows.Forms.Label label6;
    }
}
