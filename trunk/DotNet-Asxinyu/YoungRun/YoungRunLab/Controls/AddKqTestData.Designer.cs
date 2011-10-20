/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-26
 * 时间: 13:30
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab.Controls
{
	partial class AddKqTestData
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
            this.combTestPerson = new System.Windows.Forms.ComboBox();
            this.combGetLoacation = new System.Windows.Forms.ComboBox();
            this.combProductName = new System.Windows.Forms.ComboBox();
            this.dtTestTime = new System.Windows.Forms.DateTimePicker();
            this.dtGetTime = new System.Windows.Forms.DateTimePicker();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.combT8HaveQ = new System.Windows.Forms.ComboBox();
            this.combJYHaveQ = new System.Windows.Forms.ComboBox();
            this.combCYHaveQ = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtAVa = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtASTM = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.combGetPerson = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDataID = new System.Windows.Forms.TextBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // combTestPerson
            // 
            this.combTestPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combTestPerson.FormattingEnabled = true;
            this.combTestPerson.Items.AddRange(new object[] {
            "化验室"});
            this.combTestPerson.Location = new System.Drawing.Point(301, 184);
            this.combTestPerson.Name = "combTestPerson";
            this.combTestPerson.Size = new System.Drawing.Size(129, 22);
            this.combTestPerson.TabIndex = 11;
            // 
            // combGetLoacation
            // 
            this.combGetLoacation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combGetLoacation.FormattingEnabled = true;
            this.combGetLoacation.Location = new System.Drawing.Point(301, 8);
            this.combGetLoacation.Name = "combGetLoacation";
            this.combGetLoacation.Size = new System.Drawing.Size(129, 22);
            this.combGetLoacation.TabIndex = 3;
            // 
            // combProductName
            // 
            this.combProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combProductName.FormattingEnabled = true;
            this.combProductName.Location = new System.Drawing.Point(76, 38);
            this.combProductName.Name = "combProductName";
            this.combProductName.Size = new System.Drawing.Size(142, 22);
            this.combProductName.TabIndex = 2;
            // 
            // dtTestTime
            // 
            this.dtTestTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtTestTime.CustomFormat = "";
            this.dtTestTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtTestTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtTestTime.Location = new System.Drawing.Point(78, 211);
            this.dtTestTime.Name = "dtTestTime";
            this.dtTestTime.Size = new System.Drawing.Size(169, 23);
            this.dtTestTime.TabIndex = 12;
            // 
            // dtGetTime
            // 
            this.dtGetTime.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.dtGetTime.CustomFormat = "";
            this.dtGetTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtGetTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtGetTime.Location = new System.Drawing.Point(78, 184);
            this.dtGetTime.Name = "dtGetTime";
            this.dtGetTime.Size = new System.Drawing.Size(169, 23);
            this.dtGetTime.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.combT8HaveQ);
            this.groupBox1.Controls.Add(this.combJYHaveQ);
            this.groupBox1.Controls.Add(this.combCYHaveQ);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.txtAVa);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtASTM);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(15, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(416, 102);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "指标";
            // 
            // combT8HaveQ
            // 
            this.combT8HaveQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combT8HaveQ.FormattingEnabled = true;
            this.combT8HaveQ.Items.AddRange(new object[] {
            "不含",
            "含"});
            this.combT8HaveQ.Location = new System.Drawing.Point(282, 43);
            this.combT8HaveQ.Name = "combT8HaveQ";
            this.combT8HaveQ.Size = new System.Drawing.Size(128, 22);
            this.combT8HaveQ.TabIndex = 8;
            // 
            // combJYHaveQ
            // 
            this.combJYHaveQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combJYHaveQ.FormattingEnabled = true;
            this.combJYHaveQ.Items.AddRange(new object[] {
            "不含",
            "含"});
            this.combJYHaveQ.Location = new System.Drawing.Point(75, 40);
            this.combJYHaveQ.Name = "combJYHaveQ";
            this.combJYHaveQ.Size = new System.Drawing.Size(109, 22);
            this.combJYHaveQ.TabIndex = 7;
            // 
            // combCYHaveQ
            // 
            this.combCYHaveQ.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combCYHaveQ.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combCYHaveQ.FormattingEnabled = true;
            this.combCYHaveQ.Items.AddRange(new object[] {
            "不含",
            "含"});
            this.combCYHaveQ.Location = new System.Drawing.Point(75, 68);
            this.combCYHaveQ.Name = "combCYHaveQ";
            this.combCYHaveQ.Size = new System.Drawing.Size(109, 22);
            this.combCYHaveQ.TabIndex = 9;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(12, 73);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 14);
            this.label12.TabIndex = 42;
            this.label12.Text = "抽油含醛";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(12, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(63, 14);
            this.label11.TabIndex = 40;
            this.label11.Text = "精油含醛";
            // 
            // txtAVa
            // 
            this.txtAVa.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAVa.Location = new System.Drawing.Point(76, 12);
            this.txtAVa.Name = "txtAVa";
            this.txtAVa.Size = new System.Drawing.Size(107, 23);
            this.txtAVa.TabIndex = 6;
            this.txtAVa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtASTMKeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(40, 18);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 14);
            this.label10.TabIndex = 38;
            this.label10.Text = "酸值";
            // 
            // txtASTM
            // 
            this.txtASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtASTM.Location = new System.Drawing.Point(282, 14);
            this.txtASTM.Name = "txtASTM";
            this.txtASTM.Size = new System.Drawing.Size(126, 23);
            this.txtASTM.TabIndex = 6;
            this.txtASTM.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtASTMKeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(217, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 30;
            this.label9.Text = "精油色度";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(210, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 14);
            this.label6.TabIndex = 28;
            this.label6.Text = "塔8水含醛";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(15, 215);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 49;
            this.label8.Text = "检测时间";
            // 
            // combGetPerson
            // 
            this.combGetPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combGetPerson.FormattingEnabled = true;
            this.combGetPerson.Items.AddRange(new object[] {
            "糠醛车间组1",
            "糠醛车间组2",
            "糠醛车间组3",
            "糠醛车间组4"});
            this.combGetPerson.Location = new System.Drawing.Point(301, 39);
            this.combGetPerson.Name = "combGetPerson";
            this.combGetPerson.Size = new System.Drawing.Size(129, 22);
            this.combGetPerson.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(15, 189);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 48;
            this.label7.Text = "采样时间";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(239, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 46;
            this.label5.Text = "采样地点";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(111, 275);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 27);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(41, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 47;
            this.label4.Text = "备注";
            // 
            // txtDataID
            // 
            this.txtDataID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtDataID.Location = new System.Drawing.Point(76, 9);
            this.txtDataID.Name = "txtDataID";
            this.txtDataID.ReadOnly = true;
            this.txtDataID.Size = new System.Drawing.Size(142, 23);
            this.txtDataID.TabIndex = 1;
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(78, 240);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(349, 23);
            this.txtRemark.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(251, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 14);
            this.label3.TabIndex = 45;
            this.label3.Text = "采样人";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 14);
            this.label2.TabIndex = 42;
            this.label2.Text = "原料名称";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 40;
            this.label1.Text = "数据编号";
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(268, 275);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(78, 27);
            this.btnCancle.TabIndex = 15;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.BtnCancleClick);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(251, 188);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 14);
            this.label13.TabIndex = 51;
            this.label13.Text = "检测人";
            // 
            // AddKqTestData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.combTestPerson);
            this.Controls.Add(this.combGetLoacation);
            this.Controls.Add(this.combProductName);
            this.Controls.Add(this.dtTestTime);
            this.Controls.Add(this.dtGetTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combGetPerson);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDataID);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.label13);
            this.Name = "AddKqTestData";
            this.Size = new System.Drawing.Size(436, 312);
            this.Load += new System.EventHandler(this.AddKqTestData_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.ComboBox combT8HaveQ;
		private System.Windows.Forms.ComboBox combJYHaveQ;
		private System.Windows.Forms.ComboBox combCYHaveQ;
		private System.Windows.Forms.TextBox txtAVa;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnCancle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.TextBox txtDataID;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox combGetPerson;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtASTM;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.DateTimePicker dtGetTime;
		private System.Windows.Forms.DateTimePicker dtTestTime;
		private System.Windows.Forms.ComboBox combProductName;
		private System.Windows.Forms.ComboBox combGetLoacation;
		private System.Windows.Forms.ComboBox combTestPerson;
	}
}
