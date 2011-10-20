using System.Globalization;
using System.Threading;
namespace YoungRunLab.Controls
{
    partial class AddBtTestData
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
        	this.components = new System.ComponentModel.Container();
        	this.combGetPerson = new System.Windows.Forms.ComboBox();
        	this.txtRemark = new System.Windows.Forms.TextBox();
        	this.txtDataID = new System.Windows.Forms.TextBox();
        	this.label4 = new System.Windows.Forms.Label();
        	this.label5 = new System.Windows.Forms.Label();
        	this.label3 = new System.Windows.Forms.Label();
        	this.label2 = new System.Windows.Forms.Label();
        	this.label1 = new System.Windows.Forms.Label();
        	this.btnCancle = new System.Windows.Forms.Button();
        	this.btnOK = new System.Windows.Forms.Button();
        	this.label7 = new System.Windows.Forms.Label();
        	this.label8 = new System.Windows.Forms.Label();
        	this.groupBox1 = new System.Windows.Forms.GroupBox();
        	this.txtVI = new System.Windows.Forms.TextBox();
        	this.label12 = new System.Windows.Forms.Label();
        	this.txtV100 = new System.Windows.Forms.TextBox();
        	this.label11 = new System.Windows.Forms.Label();
        	this.txtV40 = new System.Windows.Forms.TextBox();
        	this.label10 = new System.Windows.Forms.Label();
        	this.txtASTM = new System.Windows.Forms.TextBox();
        	this.label9 = new System.Windows.Forms.Label();
        	this.txtAV = new System.Windows.Forms.TextBox();
        	this.label6 = new System.Windows.Forms.Label();
        	this.dtGetTime = new System.Windows.Forms.DateTimePicker();
        	this.dtTestTime = new System.Windows.Forms.DateTimePicker();
        	this.combProductName = new System.Windows.Forms.ComboBox();
        	this.combGetLoacation = new System.Windows.Forms.ComboBox();
        	this.combTestPerson = new System.Windows.Forms.ComboBox();
        	this.label13 = new System.Windows.Forms.Label();
        	this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
        	this.groupBox1.SuspendLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
        	this.SuspendLayout();
        	// 
        	// combGetPerson
        	// 
        	this.combGetPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.combGetPerson.FormattingEnabled = true;
        	this.combGetPerson.Items.AddRange(new object[] {
        	        	        	"白土车间"});
        	this.combGetPerson.Location = new System.Drawing.Point(298, 39);
        	this.combGetPerson.Name = "combGetPerson";
        	this.combGetPerson.Size = new System.Drawing.Size(129, 22);
        	this.combGetPerson.TabIndex = 3;
        	// 
        	// txtRemark
        	// 
        	this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtRemark.Location = new System.Drawing.Point(75, 240);
        	this.txtRemark.Name = "txtRemark";
        	this.txtRemark.Size = new System.Drawing.Size(349, 23);
        	this.txtRemark.TabIndex = 12;
        	// 
        	// txtDataID
        	// 
        	this.txtDataID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtDataID.Location = new System.Drawing.Point(73, 9);
        	this.txtDataID.Name = "txtDataID";
        	this.txtDataID.ReadOnly = true;
        	this.txtDataID.Size = new System.Drawing.Size(142, 23);
        	this.txtDataID.TabIndex = 0;
        	// 
        	// label4
        	// 
        	this.label4.AutoSize = true;
        	this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label4.Location = new System.Drawing.Point(38, 244);
        	this.label4.Name = "label4";
        	this.label4.Size = new System.Drawing.Size(35, 14);
        	this.label4.TabIndex = 21;
        	this.label4.Text = "备注";
        	// 
        	// label5
        	// 
        	this.label5.AutoSize = true;
        	this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label5.Location = new System.Drawing.Point(236, 13);
        	this.label5.Name = "label5";
        	this.label5.Size = new System.Drawing.Size(63, 14);
        	this.label5.TabIndex = 18;
        	this.label5.Text = "采样地点";
        	// 
        	// label3
        	// 
        	this.label3.AutoSize = true;
        	this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label3.Location = new System.Drawing.Point(248, 42);
        	this.label3.Name = "label3";
        	this.label3.Size = new System.Drawing.Size(49, 14);
        	this.label3.TabIndex = 15;
        	this.label3.Text = "采样人";
        	// 
        	// label2
        	// 
        	this.label2.AutoSize = true;
        	this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label2.Location = new System.Drawing.Point(9, 42);
        	this.label2.Name = "label2";
        	this.label2.Size = new System.Drawing.Size(63, 14);
        	this.label2.TabIndex = 12;
        	this.label2.Text = "产品名称";
        	// 
        	// label1
        	// 
        	this.label1.AutoSize = true;
        	this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label1.Location = new System.Drawing.Point(9, 13);
        	this.label1.Name = "label1";
        	this.label1.Size = new System.Drawing.Size(63, 14);
        	this.label1.TabIndex = 11;
        	this.label1.Text = "数据编号";
        	// 
        	// btnCancle
        	// 
        	this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnCancle.Location = new System.Drawing.Point(265, 275);
        	this.btnCancle.Name = "btnCancle";
        	this.btnCancle.Size = new System.Drawing.Size(78, 27);
        	this.btnCancle.TabIndex = 14;
        	this.btnCancle.Text = "取消";
        	this.btnCancle.UseVisualStyleBackColor = true;
        	this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
        	// 
        	// btnOK
        	// 
        	this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.btnOK.Location = new System.Drawing.Point(108, 275);
        	this.btnOK.Name = "btnOK";
        	this.btnOK.Size = new System.Drawing.Size(78, 27);
        	this.btnOK.TabIndex = 13;
        	this.btnOK.Text = "确定";
        	this.btnOK.UseVisualStyleBackColor = true;
        	this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
        	// 
        	// label7
        	// 
        	this.label7.AutoSize = true;
        	this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label7.Location = new System.Drawing.Point(12, 189);
        	this.label7.Name = "label7";
        	this.label7.Size = new System.Drawing.Size(63, 14);
        	this.label7.TabIndex = 23;
        	this.label7.Text = "采样时间";
        	// 
        	// label8
        	// 
        	this.label8.AutoSize = true;
        	this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label8.Location = new System.Drawing.Point(12, 215);
        	this.label8.Name = "label8";
        	this.label8.Size = new System.Drawing.Size(63, 14);
        	this.label8.TabIndex = 24;
        	this.label8.Text = "检测时间";
        	// 
        	// groupBox1
        	// 
        	this.groupBox1.Controls.Add(this.txtVI);
        	this.groupBox1.Controls.Add(this.label12);
        	this.groupBox1.Controls.Add(this.txtV100);
        	this.groupBox1.Controls.Add(this.label11);
        	this.groupBox1.Controls.Add(this.txtV40);
        	this.groupBox1.Controls.Add(this.label10);
        	this.groupBox1.Controls.Add(this.txtASTM);
        	this.groupBox1.Controls.Add(this.label9);
        	this.groupBox1.Controls.Add(this.txtAV);
        	this.groupBox1.Controls.Add(this.label6);
        	this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.groupBox1.Location = new System.Drawing.Point(12, 70);
        	this.groupBox1.Name = "groupBox1";
        	this.groupBox1.Size = new System.Drawing.Size(416, 102);
        	this.groupBox1.TabIndex = 4;
        	this.groupBox1.TabStop = false;
        	this.groupBox1.Text = "指标";
        	// 
        	// txtVI
        	// 
        	this.txtVI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtVI.Location = new System.Drawing.Point(96, 73);
        	this.txtVI.Name = "txtVI";
        	this.txtVI.Size = new System.Drawing.Size(107, 23);
        	this.txtVI.TabIndex = 6;
        	this.txtVI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV40_KeyPress);
        	// 
        	// label12
        	// 
        	this.label12.AutoSize = true;
        	this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label12.Location = new System.Drawing.Point(19, 78);
        	this.label12.Name = "label12";
        	this.label12.Size = new System.Drawing.Size(77, 14);
        	this.label12.TabIndex = 42;
        	this.label12.Text = "VI粘度指数";
        	// 
        	// txtV100
        	// 
        	this.txtV100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtV100.Location = new System.Drawing.Point(96, 44);
        	this.txtV100.Name = "txtV100";
        	this.txtV100.Size = new System.Drawing.Size(107, 23);
        	this.txtV100.TabIndex = 5;
        	this.txtV100.TextChanged += new System.EventHandler(this.txtV100_Validated);
        	this.txtV100.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV40_KeyPress);
        	// 
        	// label11
        	// 
        	this.label11.AutoSize = true;
        	this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label11.Location = new System.Drawing.Point(5, 50);
        	this.label11.Name = "label11";
        	this.label11.Size = new System.Drawing.Size(91, 14);
        	this.label11.TabIndex = 40;
        	this.label11.Text = "V100运动粘度";
        	// 
        	// txtV40
        	// 
        	this.txtV40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtV40.Location = new System.Drawing.Point(96, 15);
        	this.txtV40.Name = "txtV40";
        	this.txtV40.Size = new System.Drawing.Size(107, 23);
        	this.txtV40.TabIndex = 4;
        	this.txtV40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV40_KeyPress);
        	// 
        	// label10
        	// 
        	this.label10.AutoSize = true;
        	this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label10.Location = new System.Drawing.Point(12, 22);
        	this.label10.Name = "label10";
        	this.label10.Size = new System.Drawing.Size(84, 14);
        	this.label10.TabIndex = 38;
        	this.label10.Text = "V40运动粘度";
        	// 
        	// txtASTM
        	// 
        	this.txtASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtASTM.Location = new System.Drawing.Point(287, 42);
        	this.txtASTM.Name = "txtASTM";
        	this.txtASTM.Size = new System.Drawing.Size(126, 23);
        	this.txtASTM.TabIndex = 8;
        	this.txtASTM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV40_KeyPress);
        	// 
        	// label9
        	// 
        	this.label9.AutoSize = true;
        	this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label9.Location = new System.Drawing.Point(250, 47);
        	this.label9.Name = "label9";
        	this.label9.Size = new System.Drawing.Size(35, 14);
        	this.label9.TabIndex = 30;
        	this.label9.Text = "色度";
        	// 
        	// txtAV
        	// 
        	this.txtAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.txtAV.Location = new System.Drawing.Point(287, 13);
        	this.txtAV.Name = "txtAV";
        	this.txtAV.Size = new System.Drawing.Size(126, 23);
        	this.txtAV.TabIndex = 7;
        	this.txtAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtV40_KeyPress);
        	// 
        	// label6
        	// 
        	this.label6.AutoSize = true;
        	this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label6.Location = new System.Drawing.Point(243, 18);
        	this.label6.Name = "label6";
        	this.label6.Size = new System.Drawing.Size(42, 14);
        	this.label6.TabIndex = 28;
        	this.label6.Text = " 酸值";
        	// 
        	// dtGetTime
        	// 
        	this.dtGetTime.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.dtGetTime.CustomFormat = "";
        	this.dtGetTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.dtGetTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dtGetTime.Location = new System.Drawing.Point(75, 184);
        	this.dtGetTime.Name = "dtGetTime";
        	this.dtGetTime.Size = new System.Drawing.Size(167, 23);
        	this.dtGetTime.TabIndex = 9;
        	// 
        	// dtTestTime
        	// 
        	this.dtTestTime.Cursor = System.Windows.Forms.Cursors.IBeam;
        	this.dtTestTime.CustomFormat = "";
        	this.dtTestTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.dtTestTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
        	this.dtTestTime.Location = new System.Drawing.Point(75, 211);
        	this.dtTestTime.Name = "dtTestTime";
        	this.dtTestTime.Size = new System.Drawing.Size(167, 23);
        	this.dtTestTime.TabIndex = 11;
        	// 
        	// combProductName
        	// 
        	this.combProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.combProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.combProductName.FormattingEnabled = true;
        	this.combProductName.Location = new System.Drawing.Point(73, 39);
        	this.combProductName.Name = "combProductName";
        	this.combProductName.Size = new System.Drawing.Size(142, 22);
        	this.combProductName.TabIndex = 1;
        	// 
        	// combGetLoacation
        	// 
        	this.combGetLoacation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
        	this.combGetLoacation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.combGetLoacation.FormattingEnabled = true;
        	this.combGetLoacation.Location = new System.Drawing.Point(298, 8);
        	this.combGetLoacation.Name = "combGetLoacation";
        	this.combGetLoacation.Size = new System.Drawing.Size(129, 22);
        	this.combGetLoacation.TabIndex = 2;
        	// 
        	// combTestPerson
        	// 
        	this.combTestPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.combTestPerson.FormattingEnabled = true;
        	this.combTestPerson.Items.AddRange(new object[] {
        	        	        	"化验室"});
        	this.combTestPerson.Location = new System.Drawing.Point(298, 184);
        	this.combTestPerson.Name = "combTestPerson";
        	this.combTestPerson.Size = new System.Drawing.Size(129, 22);
        	this.combTestPerson.TabIndex = 10;
        	// 
        	// label13
        	// 
        	this.label13.AutoSize = true;
        	this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
        	this.label13.Location = new System.Drawing.Point(248, 188);
        	this.label13.Name = "label13";
        	this.label13.Size = new System.Drawing.Size(49, 14);
        	this.label13.TabIndex = 32;
        	this.label13.Text = "检测人";
        	// 
        	// errorProvider1
        	// 
        	this.errorProvider1.ContainerControl = this;
        	// 
        	// AddBtTestData
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.Controls.Add(this.combTestPerson);
        	this.Controls.Add(this.label13);
        	this.Controls.Add(this.combGetLoacation);
        	this.Controls.Add(this.combProductName);
        	this.Controls.Add(this.dtTestTime);
        	this.Controls.Add(this.dtGetTime);
        	this.Controls.Add(this.groupBox1);
        	this.Controls.Add(this.label8);
        	this.Controls.Add(this.label7);
        	this.Controls.Add(this.combGetPerson);
        	this.Controls.Add(this.txtRemark);
        	this.Controls.Add(this.txtDataID);
        	this.Controls.Add(this.label4);
        	this.Controls.Add(this.label5);
        	this.Controls.Add(this.label3);
        	this.Controls.Add(this.label2);
        	this.Controls.Add(this.label1);
        	this.Controls.Add(this.btnCancle);
        	this.Controls.Add(this.btnOK);
        	this.Name = "AddBtTestData";
        	this.Size = new System.Drawing.Size(431, 311);
        	this.Load += new System.EventHandler(this.AddBtTestData_Load);
        	this.groupBox1.ResumeLayout(false);
        	this.groupBox1.PerformLayout();
        	((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.ErrorProvider errorProvider1;

        #endregion

        private System.Windows.Forms.ComboBox combGetPerson;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtDataID;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtAV;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtASTM;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtVI;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtV100;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtV40;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker dtGetTime;
        private System.Windows.Forms.DateTimePicker dtTestTime;
        private System.Windows.Forms.ComboBox combProductName;
        private System.Windows.Forms.ComboBox combGetLoacation;
        private System.Windows.Forms.ComboBox combTestPerson;
        private System.Windows.Forms.Label label13;

    }
}
