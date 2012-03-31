/*
 * Created by SharpDevelop.
 * User: Administrator
 * Date: 2010-8-24
 * Time: 11:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace YR_CalcuteVI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
            this.epVI = new System.Windows.Forms.ErrorProvider(this.components);
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnReset = new System.Windows.Forms.Button();
            this.txtVI = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtV100 = new System.Windows.Forms.TextBox();
            this.txtV40 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.txtResult = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combTemp = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtPer = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVb = new System.Windows.Forms.TextBox();
            this.txtVa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtPer2 = new System.Windows.Forms.TextBox();
            this.txtPer1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.combTemp1 = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.txtV = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtV2 = new System.Windows.Forms.TextBox();
            this.txtV1 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epVI)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2,
            this.toolStripStatusLabel5});
            this.statusStrip1.Location = new System.Drawing.Point(0, 263);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(395, 22);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(262, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "宁波永润石化科技有限公司";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(14, 17);
            this.toolStripStatusLabel2.Text = "||";
            // 
            // toolStripStatusLabel5
            // 
            this.toolStripStatusLabel5.Name = "toolStripStatusLabel5";
            this.toolStripStatusLabel5.Size = new System.Drawing.Size(104, 17);
            this.toolStripStatusLabel5.Text = "开发维护：董斌辉";
            // 
            // epVI
            // 
            this.epVI.ContainerControl = this;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(395, 263);
            this.tabControl1.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.comboBox1);
            this.tabPage1.Controls.Add(this.label16);
            this.tabPage1.Controls.Add(this.btnReset);
            this.tabPage1.Controls.Add(this.txtVI);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.txtV100);
            this.tabPage1.Controls.Add(this.txtV40);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnOK);
            this.tabPage1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(387, 235);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "粘指计算";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "粘度指数",
            "根据粘指计算V100"});
            this.comboBox1.Location = new System.Drawing.Point(139, 22);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 24);
            this.comboBox1.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label16.Location = new System.Drawing.Point(57, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(90, 26);
            this.label16.TabIndex = 24;
            this.label16.Text = "计算类型:";
            // 
            // btnReset
            // 
            this.btnReset.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnReset.Location = new System.Drawing.Point(218, 185);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(74, 29);
            this.btnReset.TabIndex = 21;
            this.btnReset.Text = "重置";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.BtnResetClick);
            // 
            // txtVI
            // 
            this.txtVI.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVI.Location = new System.Drawing.Point(139, 136);
            this.txtVI.Name = "txtVI";
            this.txtVI.Size = new System.Drawing.Size(183, 26);
            this.txtVI.TabIndex = 23;
            this.txtVI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(59, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 26);
            this.label3.TabIndex = 22;
            this.label3.Text = "粘度指数：";
            // 
            // txtV100
            // 
            this.txtV100.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV100.Location = new System.Drawing.Point(139, 95);
            this.txtV100.Name = "txtV100";
            this.txtV100.Size = new System.Drawing.Size(183, 26);
            this.txtV100.TabIndex = 17;
            this.txtV100.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // txtV40
            // 
            this.txtV40.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV40.Location = new System.Drawing.Point(139, 56);
            this.txtV40.Name = "txtV40";
            this.txtV40.Size = new System.Drawing.Size(183, 26);
            this.txtV40.TabIndex = 16;
            this.txtV40.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(19, 98);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(133, 26);
            this.label2.TabIndex = 19;
            this.label2.Text = "100度运动粘度：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(121, 26);
            this.label1.TabIndex = 18;
            this.label1.Text = "40度运动粘度：";
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(114, 185);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(69, 29);
            this.btnOK.TabIndex = 20;
            this.btnOK.Text = "计算";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.txtResult);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.combTemp);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.button1);
            this.tabPage2.Controls.Add(this.txtPer);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.txtVb);
            this.tabPage2.Controls.Add(this.txtVa);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(387, 235);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "调和粘度计算";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtResult.Location = new System.Drawing.Point(109, 123);
            this.txtResult.Name = "txtResult";
            this.txtResult.Size = new System.Drawing.Size(232, 26);
            this.txtResult.TabIndex = 35;
            this.txtResult.Tag = "15";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(30, 126);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 23);
            this.label8.TabIndex = 34;
            this.label8.Text = "调和结果：";
            // 
            // combTemp
            // 
            this.combTemp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combTemp.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combTemp.FormattingEnabled = true;
            this.combTemp.Items.AddRange(new object[] {
            "40",
            "100"});
            this.combTemp.Location = new System.Drawing.Point(277, 70);
            this.combTemp.Name = "combTemp";
            this.combTemp.Size = new System.Drawing.Size(71, 24);
            this.combTemp.TabIndex = 33;
            this.combTemp.Tag = "14";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(233, 72);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 26);
            this.label7.TabIndex = 32;
            this.label7.Text = "温度：";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(205, 178);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 29);
            this.button1.TabIndex = 29;
            this.button1.Text = "重置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // txtPer
            // 
            this.txtPer.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPer.Location = new System.Drawing.Point(277, 22);
            this.txtPer.Name = "txtPer";
            this.txtPer.Size = new System.Drawing.Size(71, 26);
            this.txtPer.TabIndex = 31;
            this.txtPer.Tag = "13";
            this.txtPer.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(191, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 26);
            this.label4.TabIndex = 30;
            this.label4.Text = "A油品比例：";
            // 
            // txtVb
            // 
            this.txtVb.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVb.Location = new System.Drawing.Point(109, 69);
            this.txtVb.Name = "txtVb";
            this.txtVb.Size = new System.Drawing.Size(71, 26);
            this.txtVb.TabIndex = 25;
            this.txtVb.Tag = "12";
            this.txtVb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // txtVa
            // 
            this.txtVa.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVa.Location = new System.Drawing.Point(109, 23);
            this.txtVa.Name = "txtVa";
            this.txtVa.Size = new System.Drawing.Size(71, 26);
            this.txtVa.TabIndex = 24;
            this.txtVa.Tag = "11";
            this.txtVa.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 73);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 26);
            this.label5.TabIndex = 27;
            this.label5.Text = "B油品粘度：";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(23, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 26);
            this.label6.TabIndex = 26;
            this.label6.Text = "A油品粘度：";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(93, 178);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 29);
            this.button2.TabIndex = 28;
            this.button2.Text = "计算";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtPer2);
            this.tabPage3.Controls.Add(this.txtPer1);
            this.tabPage3.Controls.Add(this.label14);
            this.tabPage3.Controls.Add(this.label15);
            this.tabPage3.Controls.Add(this.label9);
            this.tabPage3.Controls.Add(this.combTemp1);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.button3);
            this.tabPage3.Controls.Add(this.txtV);
            this.tabPage3.Controls.Add(this.label11);
            this.tabPage3.Controls.Add(this.txtV2);
            this.tabPage3.Controls.Add(this.txtV1);
            this.tabPage3.Controls.Add(this.label12);
            this.tabPage3.Controls.Add(this.label13);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(387, 235);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "调和比例计算";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtPer2
            // 
            this.txtPer2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPer2.Location = new System.Drawing.Point(191, 141);
            this.txtPer2.Name = "txtPer2";
            this.txtPer2.Size = new System.Drawing.Size(71, 26);
            this.txtPer2.TabIndex = 48;
            // 
            // txtPer1
            // 
            this.txtPer1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPer1.Location = new System.Drawing.Point(191, 105);
            this.txtPer1.Name = "txtPer1";
            this.txtPer1.Size = new System.Drawing.Size(71, 26);
            this.txtPer1.TabIndex = 47;
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(105, 145);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(101, 26);
            this.label14.TabIndex = 50;
            this.label14.Text = "B油品比例：";
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(105, 108);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(101, 26);
            this.label15.TabIndex = 49;
            this.label15.Text = "A油品比例：";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(27, 111);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(100, 23);
            this.label9.TabIndex = 46;
            this.label9.Text = "结果：";
            // 
            // combTemp1
            // 
            this.combTemp1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combTemp1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combTemp1.FormattingEnabled = true;
            this.combTemp1.Items.AddRange(new object[] {
            "40",
            "100"});
            this.combTemp1.Location = new System.Drawing.Point(273, 63);
            this.combTemp1.Name = "combTemp1";
            this.combTemp1.Size = new System.Drawing.Size(71, 24);
            this.combTemp1.TabIndex = 45;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(227, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 26);
            this.label10.TabIndex = 44;
            this.label10.Text = "温度：";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(212, 184);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(74, 29);
            this.button3.TabIndex = 41;
            this.button3.Text = "重置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Button3Click);
            // 
            // txtV
            // 
            this.txtV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV.Location = new System.Drawing.Point(106, 65);
            this.txtV.Name = "txtV";
            this.txtV.Size = new System.Drawing.Size(71, 26);
            this.txtV.TabIndex = 43;
            this.txtV.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(27, 66);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 26);
            this.label11.TabIndex = 42;
            this.label11.Text = "目标粘度：";
            // 
            // txtV2
            // 
            this.txtV2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV2.Location = new System.Drawing.Point(273, 17);
            this.txtV2.Name = "txtV2";
            this.txtV2.Size = new System.Drawing.Size(71, 26);
            this.txtV2.TabIndex = 37;
            this.txtV2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // txtV1
            // 
            this.txtV1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtV1.Location = new System.Drawing.Point(105, 19);
            this.txtV1.Name = "txtV1";
            this.txtV1.Size = new System.Drawing.Size(71, 26);
            this.txtV1.TabIndex = 36;
            this.txtV1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(187, 21);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(101, 26);
            this.label12.TabIndex = 39;
            this.label12.Text = "B油品粘度：";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(19, 21);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(101, 26);
            this.label13.TabIndex = 38;
            this.label13.Text = "A油品粘度：";
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button4.Location = new System.Drawing.Point(92, 184);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(69, 29);
            this.button4.TabIndex = 40;
            this.button4.Text = "计算";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.textBox1);
            this.tabPage4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(387, 235);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "说明";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox1.Location = new System.Drawing.Point(0, 0);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(387, 235);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = resources.GetString("textBox1.Text");
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button5);
            this.tabPage5.Controls.Add(this.button6);
            this.tabPage5.Controls.Add(this.textBox5);
            this.tabPage5.Controls.Add(this.label20);
            this.tabPage5.Controls.Add(this.textBox2);
            this.tabPage5.Controls.Add(this.label17);
            this.tabPage5.Controls.Add(this.textBox3);
            this.tabPage5.Controls.Add(this.textBox4);
            this.tabPage5.Controls.Add(this.label18);
            this.tabPage5.Controls.Add(this.label19);
            this.tabPage5.Location = new System.Drawing.Point(4, 24);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(387, 235);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "粘温计算";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            this.textBox2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox2.Location = new System.Drawing.Point(155, 101);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(183, 26);
            this.textBox2.TabIndex = 29;
            this.textBox2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label17.Location = new System.Drawing.Point(33, 100);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(136, 26);
            this.label17.TabIndex = 28;
            this.label17.Text = "需要计算的温度：";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox3.Location = new System.Drawing.Point(155, 60);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(183, 26);
            this.textBox3.TabIndex = 25;
            this.textBox3.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox4.Location = new System.Drawing.Point(155, 21);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(183, 26);
            this.textBox4.TabIndex = 24;
            this.textBox4.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SetControlOnlyValue);
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label18.Location = new System.Drawing.Point(38, 59);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(131, 26);
            this.label18.TabIndex = 27;
            this.label18.Text = "100度运动粘度：";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label19.Location = new System.Drawing.Point(46, 20);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(123, 26);
            this.label19.TabIndex = 26;
            this.label19.Text = "40度运动粘度：";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label20.Location = new System.Drawing.Point(52, 139);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(117, 26);
            this.label20.TabIndex = 30;
            this.label20.Text = "结果(粘度)：";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox5
            // 
            this.textBox5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textBox5.Location = new System.Drawing.Point(156, 140);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(183, 26);
            this.textBox5.TabIndex = 31;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button5.Location = new System.Drawing.Point(220, 188);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(74, 29);
            this.button5.TabIndex = 43;
            this.button5.Text = "重置";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button6.Location = new System.Drawing.Point(100, 188);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(69, 29);
            this.button6.TabIndex = 42;
            this.button6.Text = "计算";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 285);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "宁波永润化验室计算工具(0.5)(2012-3-31)";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.epVI)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.TextBox txtPer2;
		private System.Windows.Forms.TextBox txtPer1;
		private System.Windows.Forms.TextBox txtV1;
		private System.Windows.Forms.TextBox txtV2;
		private System.Windows.Forms.TextBox txtV;
		private System.Windows.Forms.ComboBox combTemp1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtResult;
		private System.Windows.Forms.ComboBox combTemp;
		private System.Windows.Forms.TextBox txtVa;
		private System.Windows.Forms.TextBox txtVb;
		private System.Windows.Forms.TextBox txtPer;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.ErrorProvider epVI;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtVI;
		private System.Windows.Forms.TextBox txtV100;
		private System.Windows.Forms.TextBox txtV40;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel5;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
		private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
	}
}
