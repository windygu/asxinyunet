/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-26
 * 时间: 15:12
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunLab.Controls
{
	partial class AddOilSampleTest
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
			this.dtSendTime = new System.Windows.Forms.DateTimePicker();
			this.label8 = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.txtSendPerson = new System.Windows.Forms.TextBox();
			this.txtRemark = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancle = new System.Windows.Forms.Button();
			this.combRecordType = new System.Windows.Forms.ComboBox();
			this.label3 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtRecordID = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.txtOilName = new System.Windows.Forms.TextBox();
			this.txtDataID = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.btnInputData = new System.Windows.Forms.Button();
			this.txtProvider = new System.Windows.Forms.ComboBox();
			this.SuspendLayout();
			// 
			// dtSendTime
			// 
			this.dtSendTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dtSendTime.CustomFormat = "";
			this.dtSendTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtSendTime.Location = new System.Drawing.Point(261, 66);
			this.dtSendTime.Name = "dtSendTime";
			this.dtSendTime.Size = new System.Drawing.Size(122, 23);
			this.dtSendTime.TabIndex = 6;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label8.Location = new System.Drawing.Point(197, 70);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(63, 14);
			this.label8.TabIndex = 63;
			this.label8.Text = "送样时间";
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOK.Location = new System.Drawing.Point(109, 160);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 27);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label4.Location = new System.Drawing.Point(32, 132);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(35, 14);
			this.label4.TabIndex = 62;
			this.label4.Text = "备注";
			// 
			// txtSendPerson
			// 
			this.txtSendPerson.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtSendPerson.Location = new System.Drawing.Point(261, 36);
			this.txtSendPerson.Name = "txtSendPerson";
			this.txtSendPerson.Size = new System.Drawing.Size(122, 23);
			this.txtSendPerson.TabIndex = 5;
			// 
			// txtRemark
			// 
			this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtRemark.Location = new System.Drawing.Point(68, 127);
			this.txtRemark.Name = "txtRemark";
			this.txtRemark.Size = new System.Drawing.Size(315, 23);
			this.txtRemark.TabIndex = 9;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label2.Location = new System.Drawing.Point(4, 71);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(63, 14);
			this.label2.TabIndex = 61;
			this.label2.Text = "油品名称";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label1.Location = new System.Drawing.Point(211, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(49, 14);
			this.label1.TabIndex = 60;
			this.label1.Text = "送样人";
			// 
			// btnCancle
			// 
			this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancle.Location = new System.Drawing.Point(230, 160);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(78, 27);
			this.btnCancle.TabIndex = 11;
			this.btnCancle.Text = "取消";
			this.btnCancle.UseVisualStyleBackColor = true;
			this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
			// 
			// combRecordType
			// 
			this.combRecordType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.combRecordType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.combRecordType.FormattingEnabled = true;
			this.combRecordType.Items.AddRange(new object[] {
									"调配小样",
									"外来油样"});
			this.combRecordType.Location = new System.Drawing.Point(68, 37);
			this.combRecordType.Name = "combRecordType";
			this.combRecordType.Size = new System.Drawing.Size(122, 22);
			this.combRecordType.TabIndex = 2;
			this.combRecordType.SelectedIndexChanged += new System.EventHandler(this.combRecordType_SelectedIndexChanged);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label3.Location = new System.Drawing.Point(4, 41);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(63, 14);
			this.label3.TabIndex = 66;
			this.label3.Text = "记录类型";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label5.Location = new System.Drawing.Point(225, 11);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(35, 14);
			this.label5.TabIndex = 68;
			this.label5.Text = "来源";
			// 
			// txtRecordID
			// 
			this.txtRecordID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtRecordID.Location = new System.Drawing.Point(68, 7);
			this.txtRecordID.Name = "txtRecordID";
			this.txtRecordID.ReadOnly = true;
			this.txtRecordID.Size = new System.Drawing.Size(122, 23);
			this.txtRecordID.TabIndex = 1;
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label6.Location = new System.Drawing.Point(4, 11);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 14);
			this.label6.TabIndex = 70;
			this.label6.Text = "记录编号";
			// 
			// txtOilName
			// 
			this.txtOilName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtOilName.Location = new System.Drawing.Point(68, 66);
			this.txtOilName.Name = "txtOilName";
			this.txtOilName.Size = new System.Drawing.Size(122, 23);
			this.txtOilName.TabIndex = 3;
			// 
			// txtDataID
			// 
			this.txtDataID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtDataID.Location = new System.Drawing.Point(68, 96);
			this.txtDataID.Name = "txtDataID";
			this.txtDataID.ReadOnly = true;
			this.txtDataID.Size = new System.Drawing.Size(122, 23);
			this.txtDataID.TabIndex = 7;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(4, 101);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 14);
			this.label7.TabIndex = 73;
			this.label7.Text = "数据编号";
			// 
			// btnInputData
			// 
			this.btnInputData.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnInputData.Location = new System.Drawing.Point(194, 97);
			this.btnInputData.Name = "btnInputData";
			this.btnInputData.Size = new System.Drawing.Size(112, 23);
			this.btnInputData.TabIndex = 8;
			this.btnInputData.Text = "输入检测数据";
			this.btnInputData.UseVisualStyleBackColor = true;
			this.btnInputData.Click += new System.EventHandler(this.btnInputData_Click);
			// 
			// txtProvider
			// 
			this.txtProvider.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.txtProvider.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.txtProvider.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.txtProvider.FormattingEnabled = true;
			this.txtProvider.Location = new System.Drawing.Point(261, 6);
			this.txtProvider.Name = "txtProvider";
			this.txtProvider.Size = new System.Drawing.Size(122, 22);
			this.txtProvider.TabIndex = 74;
			// 
			// AddOilSampleTest
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.txtProvider);
			this.Controls.Add(this.btnInputData);
			this.Controls.Add(this.txtDataID);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.txtOilName);
			this.Controls.Add(this.txtRecordID);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.combRecordType);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.dtSendTime);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtSendPerson);
			this.Controls.Add(this.txtRemark);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnCancle);
			this.Name = "AddOilSampleTest";
			this.Size = new System.Drawing.Size(386, 192);
			this.Load += new System.EventHandler(this.AddOilSampleTest_Load);
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtDataID;
		private System.Windows.Forms.TextBox txtOilName;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtRecordID;
        private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox combRecordType;
		private System.Windows.Forms.Button btnCancle;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.TextBox txtSendPerson;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtSendTime;
        private System.Windows.Forms.Button btnInputData;
        private System.Windows.Forms.ComboBox txtProvider;
	}
}
