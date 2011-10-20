/*
 * 由SharpDevelop创建。
 * 用户： Administrator
 * 日期: 2011-9-29
 * 时间: 11:36
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace YoungRunST.Controls
{
	partial class AddOilTankST
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			this.dgv = new System.Windows.Forms.DataGridView();
			this.TankID = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.CurLiquidLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.btnCancle = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.dtGetTime = new System.Windows.Forms.DateTimePicker();
			this.label7 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
			this.SuspendLayout();
			// 
			// dgv
			// 
			this.dgv.AllowUserToAddRows = false;
			this.dgv.AllowUserToDeleteRows = false;
			this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
									this.TankID,
									this.CurLiquidLevel});
			this.dgv.Dock = System.Windows.Forms.DockStyle.Top;
			this.dgv.Location = new System.Drawing.Point(0, 0);
			this.dgv.Name = "dgv";
			this.dgv.RowTemplate.Height = 23;
			this.dgv.Size = new System.Drawing.Size(225, 422);
			this.dgv.TabIndex = 0;
			this.dgv.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.DgvEditingControlShowing);
			// 
			// TankID
			// 
			dataGridViewCellStyle1.NullValue = null;
			this.TankID.DefaultCellStyle = dataGridViewCellStyle1;
			this.TankID.HeaderText = "油罐号";
			this.TankID.Name = "TankID";
			this.TankID.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			this.TankID.Width = 80;
			// 
			// CurLiquidLevel
			// 
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle2.Format = "C2";
			dataGridViewCellStyle2.NullValue = null;
			this.CurLiquidLevel.DefaultCellStyle = dataGridViewCellStyle2;
			this.CurLiquidLevel.HeaderText = "液位";
			this.CurLiquidLevel.Name = "CurLiquidLevel";
			this.CurLiquidLevel.Width = 90;
			// 
			// btnCancle
			// 
			this.btnCancle.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnCancle.Location = new System.Drawing.Point(136, 457);
			this.btnCancle.Name = "btnCancle";
			this.btnCancle.Size = new System.Drawing.Size(78, 27);
			this.btnCancle.TabIndex = 11;
			this.btnCancle.Text = "取消";
			this.btnCancle.UseVisualStyleBackColor = true;
			this.btnCancle.Click += new System.EventHandler(this.btnCancle_Click);
			// 
			// btnOK
			// 
			this.btnOK.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.btnOK.Location = new System.Drawing.Point(25, 457);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(78, 27);
			this.btnOK.TabIndex = 10;
			this.btnOK.Text = "确定";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// dtGetTime
			// 
			this.dtGetTime.Cursor = System.Windows.Forms.Cursors.IBeam;
			this.dtGetTime.CustomFormat = "";
			this.dtGetTime.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.dtGetTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
			this.dtGetTime.Location = new System.Drawing.Point(60, 428);
			this.dtGetTime.Name = "dtGetTime";
			this.dtGetTime.Size = new System.Drawing.Size(172, 23);
			this.dtGetTime.TabIndex = 49;
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
			this.label7.Location = new System.Drawing.Point(0, 433);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(63, 14);
			this.label7.TabIndex = 50;
			this.label7.Text = "测量时间";
			// 
			// AddOilTankST
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.dtGetTime);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnCancle);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.dgv);
			this.Name = "AddOilTankST";
			this.Size = new System.Drawing.Size(225, 489);
			this.Load += new System.EventHandler(this.AddOilTankSTLoad);
			((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btnCancle;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DateTimePicker dtGetTime;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn TankID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurLiquidLevel;
	}
}
