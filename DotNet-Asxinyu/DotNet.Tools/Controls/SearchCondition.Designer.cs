namespace DotNet.Tools.Controls
{
    partial class SearchCondition
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtDatime = new System.Windows.Forms.DateTimePicker();
            this.btnReset = new System.Windows.Forms.Button();
            this.btnGetCondition = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.combColumType = new System.Windows.Forms.ComboBox();
            this.combColumName = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConditions = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnResetConditon = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtDatime);
            this.groupBox1.Controls.Add(this.btnReset);
            this.groupBox1.Controls.Add(this.btnGetCondition);
            this.groupBox1.Controls.Add(this.txtValue);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.combColumType);
            this.groupBox1.Controls.Add(this.combColumName);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(4, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.groupBox1.Size = new System.Drawing.Size(352, 84);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "条件";
            // 
            // dtDatime
            // 
            this.dtDatime.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtDatime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtDatime.Location = new System.Drawing.Point(209, 27);
            this.dtDatime.Name = "dtDatime";
            this.dtDatime.Size = new System.Drawing.Size(140, 23);
            this.dtDatime.TabIndex = 7;
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(208, 56);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(75, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnGetCondition
            // 
            this.btnGetCondition.Location = new System.Drawing.Point(89, 56);
            this.btnGetCondition.Name = "btnGetCondition";
            this.btnGetCondition.Size = new System.Drawing.Size(75, 23);
            this.btnGetCondition.TabIndex = 4;
            this.btnGetCondition.Text = "提交条件";
            this.btnGetCondition.UseVisualStyleBackColor = true;
            this.btnGetCondition.Click += new System.EventHandler(this.btnGetCondition_Click);
            // 
            // txtValue
            // 
            this.txtValue.Location = new System.Drawing.Point(209, 27);
            this.txtValue.Name = "txtValue";
            this.txtValue.Size = new System.Drawing.Size(140, 23);
            this.txtValue.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 14);
            this.label3.TabIndex = 4;
            this.label3.Text = "值";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(166, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "条件";
            // 
            // combColumType
            // 
            this.combColumType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combColumType.FormattingEnabled = true;
            this.combColumType.Location = new System.Drawing.Point(158, 28);
            this.combColumType.Name = "combColumType";
            this.combColumType.Size = new System.Drawing.Size(50, 22);
            this.combColumType.TabIndex = 2;
            // 
            // combColumName
            // 
            this.combColumName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combColumName.FormattingEnabled = true;
            this.combColumName.Location = new System.Drawing.Point(3, 28);
            this.combColumName.Name = "combColumName";
            this.combColumName.Size = new System.Drawing.Size(154, 22);
            this.combColumName.TabIndex = 1;
            this.combColumName.SelectedIndexChanged += new System.EventHandler(this.combColumName_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 0;
            this.label1.Text = "字段";
            // 
            // txtConditions
            // 
            this.txtConditions.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtConditions.Location = new System.Drawing.Point(4, 88);
            this.txtConditions.Multiline = true;
            this.txtConditions.Name = "txtConditions";
            this.txtConditions.Size = new System.Drawing.Size(350, 69);
            this.txtConditions.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(67, 162);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 2;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(253, 162);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(75, 23);
            this.btnCancle.TabIndex = 3;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
            // 
            // btnResetConditon
            // 
            this.btnResetConditon.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnResetConditon.Location = new System.Drawing.Point(158, 162);
            this.btnResetConditon.Name = "btnResetConditon";
            this.btnResetConditon.Size = new System.Drawing.Size(75, 23);
            this.btnResetConditon.TabIndex = 4;
            this.btnResetConditon.Text = "重置条件";
            this.btnResetConditon.UseVisualStyleBackColor = true;
            this.btnResetConditon.Click += new System.EventHandler(this.BtnResetConditonClick);
            // 
            // SearchCondition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnResetConditon);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtConditions);
            this.Controls.Add(this.groupBox1);
            this.Name = "SearchCondition";
            this.Size = new System.Drawing.Size(359, 188);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.DateTimePicker dtDatime;
        private System.Windows.Forms.Button btnResetConditon;

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtConditions;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox combColumName;
        private System.Windows.Forms.ComboBox combColumType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button btnGetCondition;
    }
}
