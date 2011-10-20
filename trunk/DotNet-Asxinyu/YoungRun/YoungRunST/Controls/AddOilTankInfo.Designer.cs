/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-29
 * 时间: 10:57
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunST.Controls
{
	partial class AddOilTankInfo
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
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnCancle = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtPerCmVolume = new System.Windows.Forms.TextBox();
            this.txtVolume = new System.Windows.Forms.TextBox();
            this.txtHeight = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPurpose = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.combOilTankID = new System.Windows.Forms.ComboBox();
            this.txtAlarmHeight = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.combStrogeType = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtProductName = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(23, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 14);
            this.label5.TabIndex = 26;
            this.label5.Text = "总体积";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(9, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "每CM容量";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(2, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "总高度(M)";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(9, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 23;
            this.label1.Text = "油罐编号";
            // 
            // txtRemark
            // 
            this.txtRemark.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtRemark.Location = new System.Drawing.Point(73, 241);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(142, 23);
            this.txtRemark.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(37, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 14);
            this.label4.TabIndex = 31;
            this.label4.Text = "备注";
            // 
            // btnCancle
            // 
            this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCancle.Location = new System.Drawing.Point(131, 277);
            this.btnCancle.Name = "btnCancle";
            this.btnCancle.Size = new System.Drawing.Size(78, 27);
            this.btnCancle.TabIndex = 12;
            this.btnCancle.Text = "取消";
            this.btnCancle.UseVisualStyleBackColor = true;
            this.btnCancle.Click += new System.EventHandler(this.BtnCancleClick);
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnOK.Location = new System.Drawing.Point(37, 277);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(78, 27);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "确定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.BtnOKClick);
            // 
            // txtPerCmVolume
            // 
            this.txtPerCmVolume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPerCmVolume.Location = new System.Drawing.Point(73, 90);
            this.txtPerCmVolume.Name = "txtPerCmVolume";
            this.txtPerCmVolume.Size = new System.Drawing.Size(142, 23);
            this.txtPerCmVolume.TabIndex = 4;
            this.txtPerCmVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHeightKeyPress);
            // 
            // txtVolume
            // 
            this.txtVolume.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtVolume.Location = new System.Drawing.Point(73, 61);
            this.txtVolume.Name = "txtVolume";
            this.txtVolume.Size = new System.Drawing.Size(142, 23);
            this.txtVolume.TabIndex = 3;
            this.txtVolume.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHeightKeyPress);
            // 
            // txtHeight
            // 
            this.txtHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtHeight.Location = new System.Drawing.Point(73, 32);
            this.txtHeight.Name = "txtHeight";
            this.txtHeight.Size = new System.Drawing.Size(142, 23);
            this.txtHeight.TabIndex = 2;
            this.txtHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHeightKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(9, 156);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 36;
            this.label6.Text = "油品名称";
            // 
            // txtPurpose
            // 
            this.txtPurpose.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtPurpose.Location = new System.Drawing.Point(73, 181);
            this.txtPurpose.Name = "txtPurpose";
            this.txtPurpose.Size = new System.Drawing.Size(142, 23);
            this.txtPurpose.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(37, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 14);
            this.label7.TabIndex = 38;
            this.label7.Text = "用途";
            // 
            // combOilTankID
            // 
            this.combOilTankID.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combOilTankID.FormattingEnabled = true;
            this.combOilTankID.Location = new System.Drawing.Point(73, 4);
            this.combOilTankID.Name = "combOilTankID";
            this.combOilTankID.Size = new System.Drawing.Size(142, 22);
            this.combOilTankID.TabIndex = 1;
            // 
            // txtAlarmHeight
            // 
            this.txtAlarmHeight.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtAlarmHeight.Location = new System.Drawing.Point(73, 210);
            this.txtAlarmHeight.Name = "txtAlarmHeight";
            this.txtAlarmHeight.Size = new System.Drawing.Size(142, 23);
            this.txtAlarmHeight.TabIndex = 8;
            this.txtAlarmHeight.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtHeightKeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(9, 213);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 14);
            this.label8.TabIndex = 40;
            this.label8.Text = "警戒高度";
            // 
            // combStrogeType
            // 
            this.combStrogeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.combStrogeType.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.combStrogeType.FormattingEnabled = true;
            this.combStrogeType.Location = new System.Drawing.Point(73, 121);
            this.combStrogeType.Name = "combStrogeType";
            this.combStrogeType.Size = new System.Drawing.Size(142, 22);
            this.combStrogeType.TabIndex = 5;
            this.combStrogeType.SelectedIndexChanged += new System.EventHandler(this.combStrogeType_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(9, 125);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(63, 14);
            this.label9.TabIndex = 42;
            this.label9.Text = "存储类型";
            // 
            // txtProductName
            // 
            this.txtProductName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.txtProductName.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.txtProductName.FormattingEnabled = true;
            this.txtProductName.Location = new System.Drawing.Point(73, 152);
            this.txtProductName.Name = "txtProductName";
            this.txtProductName.Size = new System.Drawing.Size(142, 22);
            this.txtProductName.TabIndex = 6;
            // 
            // AddOilTankInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtProductName);
            this.Controls.Add(this.combStrogeType);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtAlarmHeight);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.combOilTankID);
            this.Controls.Add(this.txtPurpose);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtPerCmVolume);
            this.Controls.Add(this.txtVolume);
            this.Controls.Add(this.txtHeight);
            this.Controls.Add(this.txtRemark);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancle);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddOilTankInfo";
            this.Size = new System.Drawing.Size(222, 307);
            this.Load += new System.EventHandler(this.AddOilTankInfoLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox combStrogeType;
		private System.Windows.Forms.TextBox txtAlarmHeight;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox combOilTankID;
        private System.Windows.Forms.TextBox txtPurpose;
		private System.Windows.Forms.TextBox txtHeight;
		private System.Windows.Forms.TextBox txtVolume;
		private System.Windows.Forms.TextBox txtPerCmVolume;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancle;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtRemark;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox txtProductName;
	}
}
