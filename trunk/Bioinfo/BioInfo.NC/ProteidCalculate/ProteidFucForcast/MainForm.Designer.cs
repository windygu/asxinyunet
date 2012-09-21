/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2011-3-28
 * Time: 13:13
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ProteidFucForcast
{
	partial class MainForm
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
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.ExportDataToExcel = new System.Windows.Forms.Button();
			this.btnReset = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.rdbWave = new System.Windows.Forms.RadioButton();
			this.dgvResult = new System.Windows.Forms.DataGridView();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.txtInput = new System.Windows.Forms.TextBox();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.ckb3 = new System.Windows.Forms.CheckBox();
			this.ckb1 = new System.Windows.Forms.CheckBox();
			this.ckb2 = new System.Windows.Forms.CheckBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtTrainData = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtForResult = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnForSet = new System.Windows.Forms.Button();
			this.btnForcast = new System.Windows.Forms.Button();
			this.label6 = new System.Windows.Forms.Label();
			this.txtForText = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnReset2 = new System.Windows.Forms.Button();
			this.btnCalculate = new System.Windows.Forms.Button();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.txtSvmResult = new System.Windows.Forms.TextBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.ckb6 = new System.Windows.Forms.CheckBox();
			this.ckb4 = new System.Windows.Forms.CheckBox();
			this.ckb5 = new System.Windows.Forms.CheckBox();
			this.txtCount = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.btnFilePath = new System.Windows.Forms.Button();
			this.txtTestFilePath = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.combFunClass = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.saveFile = new System.Windows.Forms.SaveFileDialog();
			this.openFile = new System.Windows.Forms.OpenFileDialog();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult)).BeginInit();
			this.tabPage3.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox2.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(593, 554);
			this.tabControl1.TabIndex = 3;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.ExportDataToExcel);
			this.tabPage1.Controls.Add(this.btnReset);
			this.tabPage1.Controls.Add(this.btnOK);
			this.tabPage1.Controls.Add(this.groupBox1);
			this.tabPage1.Controls.Add(this.dgvResult);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.txtInput);
			this.tabPage1.Location = new System.Drawing.Point(4, 25);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(585, 525);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "特征值计算";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// ExportDataToExcel
			// 
			this.ExportDataToExcel.Location = new System.Drawing.Point(406, 250);
			this.ExportDataToExcel.Name = "ExportDataToExcel";
			this.ExportDataToExcel.Size = new System.Drawing.Size(120, 30);
			this.ExportDataToExcel.TabIndex = 15;
			this.ExportDataToExcel.Text = "导出到Excel";
			this.ExportDataToExcel.UseVisualStyleBackColor = true;
			this.ExportDataToExcel.Click += new System.EventHandler(this.ExportDataToExcelClick);
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(245, 250);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(84, 30);
			this.btnReset.TabIndex = 14;
			this.btnReset.Text = "重置";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(83, 250);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(87, 30);
			this.btnOK.TabIndex = 13;
			this.btnOK.Text = "计算";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.rdbWave);
			this.groupBox1.Location = new System.Drawing.Point(9, 5);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(572, 59);
			this.groupBox1.TabIndex = 12;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "选择特征提取算法";
			// 
			// rdbWave
			// 
			this.rdbWave.AutoSize = true;
			this.rdbWave.Checked = true;
			this.rdbWave.Location = new System.Drawing.Point(15, 25);
			this.rdbWave.Name = "rdbWave";
			this.rdbWave.Size = new System.Drawing.Size(146, 20);
			this.rdbWave.TabIndex = 0;
			this.rdbWave.TabStop = true;
			this.rdbWave.Text = "氨基酸组成(AAC)";
			this.rdbWave.UseVisualStyleBackColor = true;
			// 
			// dgvResult
			// 
			this.dgvResult.AllowUserToAddRows = false;
			this.dgvResult.AllowUserToDeleteRows = false;
			this.dgvResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvResult.Location = new System.Drawing.Point(1, 302);
			this.dgvResult.Name = "dgvResult";
			this.dgvResult.RowTemplate.Height = 23;
			this.dgvResult.Size = new System.Drawing.Size(581, 218);
			this.dgvResult.TabIndex = 6;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 283);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(224, 16);
			this.label2.TabIndex = 5;
			this.label2.Text = "计算结果(每行为一条特征值):";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 75);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(208, 16);
			this.label1.TabIndex = 3;
			this.label1.Text = "请输入测试序列(注意格式):";
			// 
			// txtInput
			// 
			this.txtInput.Location = new System.Drawing.Point(5, 94);
			this.txtInput.Multiline = true;
			this.txtInput.Name = "txtInput";
			this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtInput.Size = new System.Drawing.Size(576, 150);
			this.txtInput.TabIndex = 2;
			// 
			// tabPage3
			// 
			this.tabPage3.Controls.Add(this.groupBox4);
			this.tabPage3.Controls.Add(this.txtForResult);
			this.tabPage3.Controls.Add(this.label7);
			this.tabPage3.Controls.Add(this.btnForSet);
			this.tabPage3.Controls.Add(this.btnForcast);
			this.tabPage3.Controls.Add(this.label6);
			this.tabPage3.Controls.Add(this.txtForText);
			this.tabPage3.Location = new System.Drawing.Point(4, 25);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(585, 525);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "序列预测";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.ckb3);
			this.groupBox4.Controls.Add(this.ckb1);
			this.groupBox4.Controls.Add(this.ckb2);
			this.groupBox4.Controls.Add(this.button1);
			this.groupBox4.Controls.Add(this.txtTrainData);
			this.groupBox4.Controls.Add(this.label5);
			this.groupBox4.Location = new System.Drawing.Point(5, 13);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(577, 102);
			this.groupBox4.TabIndex = 21;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "数据源设置";
			// 
			// ckb3
			// 
			this.ckb3.AutoSize = true;
			this.ckb3.Checked = true;
			this.ckb3.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckb3.Location = new System.Drawing.Point(381, 74);
			this.ckb3.Name = "ckb3";
			this.ckb3.Size = new System.Drawing.Size(123, 20);
			this.ckb3.TabIndex = 10;
			this.ckb3.Text = "SVM与NEC结合";
			this.ckb3.UseVisualStyleBackColor = true;
			// 
			// ckb1
			// 
			this.ckb1.AutoSize = true;
			this.ckb1.Checked = true;
			this.ckb1.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckb1.Location = new System.Drawing.Point(40, 74);
			this.ckb1.Name = "ckb1";
			this.ckb1.Size = new System.Drawing.Size(139, 20);
			this.ckb1.TabIndex = 9;
			this.ckb1.Text = "最近邻居法(NC)";
			this.ckb1.UseVisualStyleBackColor = true;
			// 
			// ckb2
			// 
			this.ckb2.AutoSize = true;
			this.ckb2.Checked = true;
			this.ckb2.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckb2.Location = new System.Drawing.Point(231, 74);
			this.ckb2.Name = "ckb2";
			this.ckb2.Size = new System.Drawing.Size(83, 20);
			this.ckb2.TabIndex = 8;
			this.ckb2.Text = "SVM分类";
			this.ckb2.UseVisualStyleBackColor = true;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(441, 25);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(63, 29);
			this.button1.TabIndex = 7;
			this.button1.Text = "选择";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// txtTrainData
			// 
			this.txtTrainData.Location = new System.Drawing.Point(122, 28);
			this.txtTrainData.Name = "txtTrainData";
			this.txtTrainData.Size = new System.Drawing.Size(313, 26);
			this.txtTrainData.TabIndex = 6;
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(6, 31);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(122, 20);
			this.label5.TabIndex = 5;
			this.label5.Text = "训练集数据源：";
			// 
			// txtForResult
			// 
			this.txtForResult.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.txtForResult.Location = new System.Drawing.Point(3, 342);
			this.txtForResult.Multiline = true;
			this.txtForResult.Name = "txtForResult";
			this.txtForResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtForResult.Size = new System.Drawing.Size(579, 180);
			this.txtForResult.TabIndex = 20;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(4, 323);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(104, 16);
			this.label7.TabIndex = 19;
			this.label7.Text = "预测计算结果";
			// 
			// btnForSet
			// 
			this.btnForSet.Location = new System.Drawing.Point(356, 296);
			this.btnForSet.Name = "btnForSet";
			this.btnForSet.Size = new System.Drawing.Size(84, 30);
			this.btnForSet.TabIndex = 18;
			this.btnForSet.Text = "重置";
			this.btnForSet.UseVisualStyleBackColor = true;
			this.btnForSet.Click += new System.EventHandler(this.BtnForSetClick);
			// 
			// btnForcast
			// 
			this.btnForcast.Location = new System.Drawing.Point(140, 296);
			this.btnForcast.Name = "btnForcast";
			this.btnForcast.Size = new System.Drawing.Size(87, 30);
			this.btnForcast.TabIndex = 17;
			this.btnForcast.Text = "计算";
			this.btnForcast.UseVisualStyleBackColor = true;
			this.btnForcast.Click += new System.EventHandler(this.BtnForcastClick);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(6, 121);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(456, 16);
			this.label6.TabIndex = 16;
			this.label6.Text = "请输入预测序列(注意格式,只支持一条序列:不带标记符及*号):";
			// 
			// txtForText
			// 
			this.txtForText.Location = new System.Drawing.Point(6, 140);
			this.txtForText.Multiline = true;
			this.txtForText.Name = "txtForText";
			this.txtForText.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtForText.Size = new System.Drawing.Size(576, 151);
			this.txtForText.TabIndex = 15;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnReset2);
			this.tabPage2.Controls.Add(this.btnCalculate);
			this.tabPage2.Controls.Add(this.groupBox3);
			this.tabPage2.Controls.Add(this.groupBox2);
			this.tabPage2.Location = new System.Drawing.Point(4, 25);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(585, 525);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "分类计算对比";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnReset2
			// 
			this.btnReset2.Location = new System.Drawing.Point(333, 201);
			this.btnReset2.Name = "btnReset2";
			this.btnReset2.Size = new System.Drawing.Size(78, 29);
			this.btnReset2.TabIndex = 3;
			this.btnReset2.Text = "重置";
			this.btnReset2.UseVisualStyleBackColor = true;
			this.btnReset2.Click += new System.EventHandler(this.BtnReset2Click);
			// 
			// btnCalculate
			// 
			this.btnCalculate.Location = new System.Drawing.Point(142, 201);
			this.btnCalculate.Name = "btnCalculate";
			this.btnCalculate.Size = new System.Drawing.Size(78, 29);
			this.btnCalculate.TabIndex = 2;
			this.btnCalculate.Text = "计算";
			this.btnCalculate.UseVisualStyleBackColor = true;
			this.btnCalculate.Click += new System.EventHandler(this.BtnCalculateClick);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.txtSvmResult);
			this.groupBox3.Location = new System.Drawing.Point(3, 236);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(576, 281);
			this.groupBox3.TabIndex = 1;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "分类计算结果";
			// 
			// txtSvmResult
			// 
			this.txtSvmResult.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSvmResult.Location = new System.Drawing.Point(3, 22);
			this.txtSvmResult.Multiline = true;
			this.txtSvmResult.Name = "txtSvmResult";
			this.txtSvmResult.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtSvmResult.Size = new System.Drawing.Size(570, 256);
			this.txtSvmResult.TabIndex = 0;
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.ckb6);
			this.groupBox2.Controls.Add(this.ckb4);
			this.groupBox2.Controls.Add(this.ckb5);
			this.groupBox2.Controls.Add(this.txtCount);
			this.groupBox2.Controls.Add(this.label8);
			this.groupBox2.Controls.Add(this.btnFilePath);
			this.groupBox2.Controls.Add(this.txtTestFilePath);
			this.groupBox2.Controls.Add(this.label4);
			this.groupBox2.Controls.Add(this.combFunClass);
			this.groupBox2.Controls.Add(this.label3);
			this.groupBox2.Location = new System.Drawing.Point(8, 6);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(571, 189);
			this.groupBox2.TabIndex = 0;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "参数设置(NC:SVM:SVM结合NC)";
			// 
			// ckb6
			// 
			this.ckb6.AutoSize = true;
			this.ckb6.Checked = true;
			this.ckb6.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckb6.Location = new System.Drawing.Point(383, 154);
			this.ckb6.Name = "ckb6";
			this.ckb6.Size = new System.Drawing.Size(123, 20);
			this.ckb6.TabIndex = 13;
			this.ckb6.Text = "SVM与NEC结合";
			this.ckb6.UseVisualStyleBackColor = true;
			// 
			// ckb4
			// 
			this.ckb4.AutoSize = true;
			this.ckb4.Checked = true;
			this.ckb4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckb4.Location = new System.Drawing.Point(42, 154);
			this.ckb4.Name = "ckb4";
			this.ckb4.Size = new System.Drawing.Size(139, 20);
			this.ckb4.TabIndex = 12;
			this.ckb4.Text = "最近邻居法(NC)";
			this.ckb4.UseVisualStyleBackColor = true;
			// 
			// ckb5
			// 
			this.ckb5.AutoSize = true;
			this.ckb5.Checked = true;
			this.ckb5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.ckb5.Location = new System.Drawing.Point(233, 154);
			this.ckb5.Name = "ckb5";
			this.ckb5.Size = new System.Drawing.Size(83, 20);
			this.ckb5.TabIndex = 11;
			this.ckb5.Text = "SVM分类";
			this.ckb5.UseVisualStyleBackColor = true;
			// 
			// txtCount
			// 
			this.txtCount.Location = new System.Drawing.Point(120, 109);
			this.txtCount.Name = "txtCount";
			this.txtCount.Size = new System.Drawing.Size(223, 26);
			this.txtCount.TabIndex = 6;
			this.txtCount.Text = "20";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(42, 113);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(90, 20);
			this.label8.TabIndex = 5;
			this.label8.Text = "记录数目：";
			// 
			// btnFilePath
			// 
			this.btnFilePath.Location = new System.Drawing.Point(438, 66);
			this.btnFilePath.Name = "btnFilePath";
			this.btnFilePath.Size = new System.Drawing.Size(63, 29);
			this.btnFilePath.TabIndex = 4;
			this.btnFilePath.Text = "选择";
			this.btnFilePath.UseVisualStyleBackColor = true;
			this.btnFilePath.Click += new System.EventHandler(this.BtnFilePathClick);
			// 
			// txtTestFilePath
			// 
			this.txtTestFilePath.Location = new System.Drawing.Point(119, 68);
			this.txtTestFilePath.Name = "txtTestFilePath";
			this.txtTestFilePath.Size = new System.Drawing.Size(313, 26);
			this.txtTestFilePath.TabIndex = 3;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(42, 73);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(90, 20);
			this.label4.TabIndex = 2;
			this.label4.Text = "测试数据：";
			// 
			// combFunClass
			// 
			this.combFunClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combFunClass.FormattingEnabled = true;
			this.combFunClass.Items.AddRange(new object[] {
									"0.All",
									"1.BIOGENESIS OF CELLULAR COMPONENTS",
									"2.CELL CYCLE AND DNA PROCESSING",
									"3.CELL FATE",
									"4.CELL RESCUE, DEFENSE AND VIRULENCE",
									"5.CELL TYPE DIFFERENTIATION",
									"6.CELLULAR COMMUNICATION",
									"7.CELLULAR TRANSPORT, TRANSPORT FACILITIES AND TRANSPORT ROUTES",
									"8.DEVELOPMENT",
									"9.ENERGY",
									"10.INTERACTION WITH THE ENVIRONMENT",
									"11.metabolism",
									"12.PROTEIN FATE",
									"13.PROTEIN SYNTHESIS",
									"14.PROTEIN WITH BINDING FUNCTION OR COFACTOR REQUIREMENT (structural or catalytic" +
												")",
									"15.REGULATION OF METABOLISM AND PROTEIN FUNCTION",
									"16.TRANSCRIPTION",
									"17.TRANSPOSABLE ELEMENTS, VIRAL AND PLASMID PROTEINS",
									"18.UNCLASSIFIED PROTEINS"});
			this.combFunClass.Location = new System.Drawing.Point(120, 29);
			this.combFunClass.Name = "combFunClass";
			this.combFunClass.Size = new System.Drawing.Size(382, 24);
			this.combFunClass.TabIndex = 1;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(42, 32);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(90, 20);
			this.label3.TabIndex = 0;
			this.label3.Text = "功能类别：";
			// 
			// openFile
			// 
			this.openFile.FileName = "openFileDialog1";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(593, 554);
			this.Controls.Add(this.tabControl1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "ProteinFuncPredic";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvResult)).EndInit();
			this.tabPage3.ResumeLayout(false);
			this.tabPage3.PerformLayout();
			this.groupBox4.ResumeLayout(false);
			this.groupBox4.PerformLayout();
			this.tabPage2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox3.PerformLayout();
			this.groupBox2.ResumeLayout(false);
			this.groupBox2.PerformLayout();
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox ckb2;
		private System.Windows.Forms.CheckBox ckb1;
		private System.Windows.Forms.CheckBox ckb3;
		private System.Windows.Forms.CheckBox ckb6;
		private System.Windows.Forms.CheckBox ckb4;
		private System.Windows.Forms.CheckBox ckb5;
		private System.Windows.Forms.TextBox txtForResult;
		private System.Windows.Forms.TextBox txtTrainData;
		private System.Windows.Forms.TextBox txtCount;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.TextBox txtSvmResult;
		private System.Windows.Forms.OpenFileDialog openFile;
		private System.Windows.Forms.TextBox txtForText;
		private System.Windows.Forms.Button btnForcast;
		private System.Windows.Forms.Button btnForSet;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.Button btnCalculate;
		private System.Windows.Forms.Button btnReset2;
		private System.Windows.Forms.TextBox txtTestFilePath;
		private System.Windows.Forms.Button btnFilePath;
		private System.Windows.Forms.ComboBox combFunClass;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.SaveFileDialog saveFile;
		private System.Windows.Forms.TextBox txtInput;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.DataGridView dgvResult;
		private System.Windows.Forms.RadioButton rdbWave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button ExportDataToExcel;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
	}
}
