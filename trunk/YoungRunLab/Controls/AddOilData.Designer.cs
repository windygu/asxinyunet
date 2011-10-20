/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-26
 * 时间: 14:21
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab.Controls
{
	partial class AddOilData
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
			this.combProductName = new System.Windows.Forms.ComboBox();
			this.dtTestTime = new System.Windows.Forms.DateTimePicker();
			this.txtVI = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.txtOther = new System.Windows.Forms.TextBox();
			this.label22 = new System.Windows.Forms.Label();
			this.txtV = new System.Windows.Forms.TextBox();
			this.label21 = new System.Windows.Forms.Label();
			this.txtDistillation = new System.Windows.Forms.TextBox();
			this.label20 = new System.Windows.Forms.Label();
			this.txtWAA = new System.Windows.Forms.TextBox();
			this.label19 = new System.Windows.Forms.Label();
			this.txtXZQD = new System.Windows.Forms.TextBox();
			this.label18 = new System.Windows.Forms.Label();
			this.txtCR = new System.Windows.Forms.TextBox();
			this.label17 = new System.Windows.Forms.Label();
			this.txtMI = new System.Windows.Forms.TextBox();
			this.label16 = new System.Windows.Forms.Label();
			this.txtD20 = new System.Windows.Forms.TextBox();
			this.label15 = new System.Windows.Forms.Label();
			this.txtWC = new System.Windows.Forms.TextBox();
			this.label14 = new System.Windows.Forms.Label();
			this.txtFP = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtPP = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.txtV100 = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.txtV40 = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtASTM = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtAV = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtDataID = new System.Windows.Forms.TextBox();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancle = new System.Windows.Forms.Button();
			this.label13 = new System.Windows.Forms.Label();
			this.combRecordType = new System.Windows.Forms.ComboBox();
			this.label7 = new System.Windows.Forms.Label();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// combTestPerson
			// 
			this.combTestPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combTestPerson.FormattingEnabled = true;
			this.combTestPerson.Items.AddRange(new object[] {
									"化验室"});
			this.combTestPerson.Location = new System.Drawing.Point(74, 336);
			this.combTestPerson.Name = "combTestPerson";
			this.combTestPerson.Size = new System.Drawing.Size(211, 22);
			this.combTestPerson.TabIndex = 20;
			// 
			// combProductName
			// 
			this.combProductName.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
			this.combProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combProductName.FormattingEnabled = true;
			this.combProductName.Location = new System.Drawing.Point(73, 33);
			this.combProductName.Name = "combProductName";
			this.combProductName.Size = new System.Drawing.Size(212, 22);
			this.combProductName.TabIndex = 1;
			// 
			// dtTestTime
			// 
			this.dtTestTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dtTestTime.CustomFormat = "";
			this.dtTestTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtTestTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtTestTime.Location = new System.Drawing.Point(74, 308);
			this.dtTestTime.Name = "dtTestTime";
			this.dtTestTime.Size = new System.Drawing.Size(211, 23);
			this.dtTestTime.TabIndex = 19;
			// 
			// txtVI
			// 
			this.txtVI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtVI.Location = new System.Drawing.Point(36, 75);
			this.txtVI.Name = "txtVI";
			this.txtVI.Size = new System.Drawing.Size(54, 23);
			this.txtVI.TabIndex = 5;
			this.txtVI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.txtOther);
			this.groupBox1.Controls.Add(this.label22);
			this.groupBox1.Controls.Add(this.txtV);
			this.groupBox1.Controls.Add(this.label21);
			this.groupBox1.Controls.Add(this.txtDistillation);
			this.groupBox1.Controls.Add(this.label20);
			this.groupBox1.Controls.Add(this.txtWAA);
			this.groupBox1.Controls.Add(this.label19);
			this.groupBox1.Controls.Add(this.txtXZQD);
			this.groupBox1.Controls.Add(this.label18);
			this.groupBox1.Controls.Add(this.txtCR);
			this.groupBox1.Controls.Add(this.label17);
			this.groupBox1.Controls.Add(this.txtMI);
			this.groupBox1.Controls.Add(this.label16);
			this.groupBox1.Controls.Add(this.txtD20);
			this.groupBox1.Controls.Add(this.label15);
			this.groupBox1.Controls.Add(this.txtWC);
			this.groupBox1.Controls.Add(this.label14);
			this.groupBox1.Controls.Add(this.txtFP);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtPP);
			this.groupBox1.Controls.Add(this.label5);
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
			this.groupBox1.Location = new System.Drawing.Point(7, 57);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(285, 246);
			this.groupBox1.TabIndex = 2;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "指标";
			// 
			// txtOther
			// 
			this.txtOther.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtOther.Location = new System.Drawing.Point(84, 217);
			this.txtOther.Name = "txtOther";
			this.txtOther.Size = new System.Drawing.Size(194, 23);
			this.txtOther.TabIndex = 16;
			// 
			// label22
			// 
			this.label22.AutoSize = true;
			this.label22.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label22.Location = new System.Drawing.Point(20, 217);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(63, 14);
			this.label22.TabIndex = 64;
			this.label22.Text = "其他指标";
			// 
			// txtV
			// 
			this.txtV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtV.Location = new System.Drawing.Point(84, 191);
			this.txtV.Name = "txtV";
			this.txtV.Size = new System.Drawing.Size(194, 23);
			this.txtV.TabIndex = 18;
			// 
			// label21
			// 
			this.label21.AutoSize = true;
			this.label21.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label21.Location = new System.Drawing.Point(20, 194);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(63, 14);
			this.label21.TabIndex = 62;
			this.label21.Text = "低温粘度";
			// 
			// txtDistillation
			// 
			this.txtDistillation.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDistillation.Location = new System.Drawing.Point(84, 162);
			this.txtDistillation.Name = "txtDistillation";
			this.txtDistillation.Size = new System.Drawing.Size(194, 23);
			this.txtDistillation.TabIndex = 17;
			// 
			// label20
			// 
			this.label20.AutoSize = true;
			this.label20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label20.Location = new System.Drawing.Point(48, 165);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(35, 14);
			this.label20.TabIndex = 60;
			this.label20.Text = "馏程";
			// 
			// txtWAA
			// 
			this.txtWAA.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtWAA.Location = new System.Drawing.Point(84, 133);
			this.txtWAA.Name = "txtWAA";
			this.txtWAA.Size = new System.Drawing.Size(194, 23);
			this.txtWAA.TabIndex = 15;
			// 
			// label19
			// 
			this.label19.AutoSize = true;
			this.label19.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label19.Location = new System.Drawing.Point(6, 136);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(77, 14);
			this.label19.TabIndex = 58;
			this.label19.Text = "水溶性酸碱";
			// 
			// txtXZQD
			// 
			this.txtXZQD.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtXZQD.Location = new System.Drawing.Point(213, 46);
			this.txtXZQD.Name = "txtXZQD";
			this.txtXZQD.Size = new System.Drawing.Size(65, 23);
			this.txtXZQD.TabIndex = 12;
			// 
			// label18
			// 
			this.label18.AutoSize = true;
			this.label18.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label18.Location = new System.Drawing.Point(178, 50);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(35, 14);
			this.label18.TabIndex = 56;
			this.label18.Text = "旋氧";
			// 
			// txtCR
			// 
			this.txtCR.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtCR.Location = new System.Drawing.Point(213, 75);
			this.txtCR.Name = "txtCR";
			this.txtCR.Size = new System.Drawing.Size(65, 23);
			this.txtCR.TabIndex = 13;
			this.txtCR.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label17
			// 
			this.label17.AutoSize = true;
			this.label17.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label17.Location = new System.Drawing.Point(178, 79);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(35, 14);
			this.label17.TabIndex = 54;
			this.label17.Text = "残炭";
			// 
			// txtMI
			// 
			this.txtMI.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtMI.Location = new System.Drawing.Point(213, 101);
			this.txtMI.Name = "txtMI";
			this.txtMI.Size = new System.Drawing.Size(65, 23);
			this.txtMI.TabIndex = 14;
			this.txtMI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label16
			// 
			this.label16.AutoSize = true;
			this.label16.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label16.Location = new System.Drawing.Point(178, 105);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(35, 14);
			this.label16.TabIndex = 52;
			this.label16.Text = "杂质";
			// 
			// txtD20
			// 
			this.txtD20.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtD20.Location = new System.Drawing.Point(213, 17);
			this.txtD20.Name = "txtD20";
			this.txtD20.Size = new System.Drawing.Size(65, 23);
			this.txtD20.TabIndex = 11;
			this.txtD20.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label15
			// 
			this.label15.AutoSize = true;
			this.label15.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label15.Location = new System.Drawing.Point(178, 22);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(35, 14);
			this.label15.TabIndex = 50;
			this.label15.Text = "密度";
			// 
			// txtWC
			// 
			this.txtWC.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtWC.Location = new System.Drawing.Point(128, 101);
			this.txtWC.Name = "txtWC";
			this.txtWC.Size = new System.Drawing.Size(46, 23);
			this.txtWC.TabIndex = 10;
			this.txtWC.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label14
			// 
			this.label14.AutoSize = true;
			this.label14.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label14.Location = new System.Drawing.Point(94, 105);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(35, 14);
			this.label14.TabIndex = 48;
			this.label14.Text = "水分";
			// 
			// txtFP
			// 
			this.txtFP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtFP.Location = new System.Drawing.Point(127, 17);
			this.txtFP.Name = "txtFP";
			this.txtFP.Size = new System.Drawing.Size(46, 23);
			this.txtFP.TabIndex = 7;
			this.txtFP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(94, 22);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(35, 14);
			this.label3.TabIndex = 46;
			this.label3.Text = "闪点";
			// 
			// txtPP
			// 
			this.txtPP.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtPP.Location = new System.Drawing.Point(36, 101);
			this.txtPP.Name = "txtPP";
			this.txtPP.Size = new System.Drawing.Size(54, 23);
			this.txtPP.TabIndex = 6;
			this.txtPP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(3, 105);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 14);
			this.label5.TabIndex = 45;
			this.label5.Text = "倾点";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label12.Location = new System.Drawing.Point(17, 79);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(21, 14);
			this.label12.TabIndex = 42;
			this.label12.Text = "VI";
			// 
			// txtV100
			// 
			this.txtV100.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtV100.Location = new System.Drawing.Point(36, 46);
			this.txtV100.Name = "txtV100";
			this.txtV100.Size = new System.Drawing.Size(54, 23);
			this.txtV100.TabIndex = 4;
			this.txtV100.TextChanged += new System.EventHandler(this.txtV100_TextChanged);
			this.txtV100.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label11.Location = new System.Drawing.Point(3, 50);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(35, 14);
			this.label11.TabIndex = 40;
			this.label11.Text = "V100";
			// 
			// txtV40
			// 
			this.txtV40.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtV40.Location = new System.Drawing.Point(36, 17);
			this.txtV40.Name = "txtV40";
			this.txtV40.Size = new System.Drawing.Size(54, 23);
			this.txtV40.TabIndex = 3;
			this.txtV40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label10.Location = new System.Drawing.Point(10, 22);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(28, 14);
			this.label10.TabIndex = 38;
			this.label10.Text = "V40";
			// 
			// txtASTM
			// 
			this.txtASTM.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtASTM.Location = new System.Drawing.Point(128, 75);
			this.txtASTM.Name = "txtASTM";
			this.txtASTM.Size = new System.Drawing.Size(46, 23);
			this.txtASTM.TabIndex = 9;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label9.Location = new System.Drawing.Point(94, 79);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(35, 14);
			this.label9.TabIndex = 30;
			this.label9.Text = "色度";
			// 
			// txtAV
			// 
			this.txtAV.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtAV.Location = new System.Drawing.Point(128, 46);
			this.txtAV.Name = "txtAV";
			this.txtAV.Size = new System.Drawing.Size(46, 23);
			this.txtAV.TabIndex = 8;
			this.txtAV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtV40KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(86, 50);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(42, 14);
			this.label6.TabIndex = 28;
			this.label6.Text = " 酸值";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label8.Location = new System.Drawing.Point(10, 312);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 14);
			this.label8.TabIndex = 49;
			this.label8.Text = "检测时间";
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOK.Location = new System.Drawing.Point(57, 419);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 27);
			this.btnOK.TabIndex = 23;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(38, 392);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 14);
			this.label4.TabIndex = 47;
			this.label4.Text = "备注";
			// 
			// txtDataID
			// 
			this.txtDataID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDataID.Location = new System.Drawing.Point(73, 4);
			this.txtDataID.Name = "txtDataID";
			this.txtDataID.ReadOnly = true;
			this.txtDataID.Size = new System.Drawing.Size(212, 23);
			this.txtDataID.TabIndex = 0;
			// 
			// txtRemark
			// 
			this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtRemark.Location = new System.Drawing.Point(74, 387);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(211, 23);
			this.txtRemark.TabIndex = 22;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(11, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 14);
			this.label2.TabIndex = 42;
			this.label2.Text = "油品名称";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(11, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 14);
			this.label1.TabIndex = 40;
			this.label1.Text = "数据编号";
			// 
			// btnCancle
			// 
			this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancle.Location = new System.Drawing.Point(169, 419);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(78, 27);
			this.btnCancle.TabIndex = 24;
			this.btnCancle.Text = "取消";
			this.btnCancle.UseVisualStyleBackColor = true;
			this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
			// 
			// label13
			// 
			this.label13.AutoSize = true;
			this.label13.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label13.Location = new System.Drawing.Point(24, 340);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(49, 14);
			this.label13.TabIndex = 51;
			this.label13.Text = "检测人";
			// 
			// combRecordType
			// 
			this.combRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combRecordType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combRecordType.FormattingEnabled = true;
			this.combRecordType.Location = new System.Drawing.Point(74, 362);
			this.combRecordType.Name = "combRecordType";
			this.combRecordType.Size = new System.Drawing.Size(211, 22);
			this.combRecordType.TabIndex = 21;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(10, 367);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 14);
			this.label7.TabIndex = 53;
			this.label7.Text = "记录类型";
			// 
			// AddOilData
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.combRecordType);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.combTestPerson);
			this.Controls.Add(this.combProductName);
			this.Controls.Add(this.dtTestTime);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtDataID);
			this.Controls.Add(this.txtRemark);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancle);
			this.Controls.Add(this.label13);
			this.Name = "AddOilData";
			this.Size = new System.Drawing.Size(296, 449);
			this.Load += new System.EventHandler(this.AddOilData_Load);
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ComboBox combRecordType;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox txtMI;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox txtD20;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox txtWC;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtPP;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFP;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Button btnCancle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.TextBox txtDataID;
		private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtAV;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtASTM;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtV40;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtV100;
		private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtVI;
		private System.Windows.Forms.DateTimePicker dtTestTime;
		private System.Windows.Forms.ComboBox combProductName;
		private System.Windows.Forms.ComboBox combTestPerson;
        private System.Windows.Forms.TextBox txtCR;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtXZQD;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox txtWAA;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtDistillation;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtV;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtOther;
        private System.Windows.Forms.Label label22;
	}
}
