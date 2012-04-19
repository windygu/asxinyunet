namespace DotNet.WinForm
{
    partial class FrmDataGridViewSetting
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grbSetting = new System.Windows.Forms.GroupBox();
            this.grdSetting = new System.Windows.Forms.DataGridView();
            this.ColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HeaderText = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DisplayIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Width = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Visible = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Frozen = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSetBottom = new System.Windows.Forms.Button();
            this.btnSetDown = new System.Windows.Forms.Button();
            this.btnSetUp = new System.Windows.Forms.Button();
            this.btnSetTop = new System.Windows.Forms.Button();
            this.grbSetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSetting)).BeginInit();
            this.SuspendLayout();
            // 
            // grbSetting
            // 
            this.grbSetting.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grbSetting.Controls.Add(this.grdSetting);
            this.grbSetting.Location = new System.Drawing.Point(2, 12);
            this.grbSetting.Name = "grbSetting";
            this.grbSetting.Size = new System.Drawing.Size(451, 388);
            this.grbSetting.TabIndex = 0;
            this.grbSetting.TabStop = false;
            this.grbSetting.Text = "设置";
            // 
            // grdSetting
            // 
            this.grdSetting.AllowUserToAddRows = false;
            this.grdSetting.AllowUserToDeleteRows = false;
            this.grdSetting.BackgroundColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdSetting.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdSetting.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSetting.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnName,
            this.HeaderText,
            this.DisplayIndex,
            this.Width,
            this.Visible,
            this.Frozen});
            this.grdSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSetting.Location = new System.Drawing.Point(3, 17);
            this.grdSetting.MultiSelect = false;
            this.grdSetting.Name = "grdSetting";
            this.grdSetting.RowTemplate.Height = 23;
            this.grdSetting.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdSetting.Size = new System.Drawing.Size(445, 368);
            this.grdSetting.TabIndex = 0;
            this.grdSetting.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdSetting_RowEnter);
            // 
            // ColumnName
            // 
            this.ColumnName.DataPropertyName = "ColumnName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.ColumnName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnName.HeaderText = "列名";
            this.ColumnName.Name = "ColumnName";
            this.ColumnName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnName.Visible = false;
            // 
            // HeaderText
            // 
            this.HeaderText.DataPropertyName = "HeaderText";
            this.HeaderText.HeaderText = "列名";
            this.HeaderText.Name = "HeaderText";
            this.HeaderText.ReadOnly = true;
            this.HeaderText.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.HeaderText.Width = 120;
            // 
            // DisplayIndex
            // 
            this.DisplayIndex.DataPropertyName = "DisplayIndex";
            this.DisplayIndex.HeaderText = "位置";
            this.DisplayIndex.Name = "DisplayIndex";
            this.DisplayIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DisplayIndex.Visible = false;
            // 
            // Width
            // 
            this.Width.DataPropertyName = "Width";
            this.Width.FillWeight = 120F;
            this.Width.HeaderText = "宽度";
            this.Width.MaxInputLength = 200;
            this.Width.Name = "Width";
            this.Width.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Width.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Width.Width = 120;
            // 
            // Visible
            // 
            this.Visible.DataPropertyName = "Visible";
            this.Visible.FalseValue = "False";
            this.Visible.HeaderText = "显示";
            this.Visible.Name = "Visible";
            this.Visible.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Visible.TrueValue = "True";
            this.Visible.Width = 80;
            // 
            // Frozen
            // 
            this.Frozen.DataPropertyName = "Frozen";
            this.Frozen.FalseValue = "False";
            this.Frozen.HeaderText = "冻结";
            this.Frozen.Name = "Frozen";
            this.Frozen.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Frozen.TrueValue = "True";
            this.Frozen.Width = 80;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(288, 406);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "确定";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(366, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "取消";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSetBottom
            // 
            this.btnSetBottom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetBottom.Location = new System.Drawing.Point(81, 406);
            this.btnSetBottom.Name = "btnSetBottom";
            this.btnSetBottom.Size = new System.Drawing.Size(23, 23);
            this.btnSetBottom.TabIndex = 10;
            this.btnSetBottom.Text = "▼";
            this.btnSetBottom.UseVisualStyleBackColor = true;
            this.btnSetBottom.Click += new System.EventHandler(this.btnSetBottom_Click);
            // 
            // btnSetDown
            // 
            this.btnSetDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetDown.Location = new System.Drawing.Point(56, 406);
            this.btnSetDown.Name = "btnSetDown";
            this.btnSetDown.Size = new System.Drawing.Size(23, 23);
            this.btnSetDown.TabIndex = 9;
            this.btnSetDown.Text = "▽";
            this.btnSetDown.UseVisualStyleBackColor = true;
            this.btnSetDown.Click += new System.EventHandler(this.btnSetDown_Click);
            // 
            // btnSetUp
            // 
            this.btnSetUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetUp.Location = new System.Drawing.Point(31, 406);
            this.btnSetUp.Name = "btnSetUp";
            this.btnSetUp.Size = new System.Drawing.Size(23, 23);
            this.btnSetUp.TabIndex = 8;
            this.btnSetUp.Text = "△";
            this.btnSetUp.UseVisualStyleBackColor = true;
            this.btnSetUp.Click += new System.EventHandler(this.btnSetUp_Click);
            // 
            // btnSetTop
            // 
            this.btnSetTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSetTop.Location = new System.Drawing.Point(6, 406);
            this.btnSetTop.Name = "btnSetTop";
            this.btnSetTop.Size = new System.Drawing.Size(23, 23);
            this.btnSetTop.TabIndex = 7;
            this.btnSetTop.Text = "▲";
            this.btnSetTop.UseVisualStyleBackColor = true;
            this.btnSetTop.Click += new System.EventHandler(this.btnSetTop_Click);
            // 
            // FrmDataGridViewSetting
            // 
            this.AcceptButton = this.btnSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(453, 432);
            this.Controls.Add(this.btnSetBottom);
            this.Controls.Add(this.btnSetDown);
            this.Controls.Add(this.btnSetUp);
            this.Controls.Add(this.btnSetTop);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grbSetting);
            this.Name = "FrmDataGridViewSetting";
            this.Text = "数据列设置";
            this.grbSetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSetting)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbSetting;
        private System.Windows.Forms.DataGridView grdSetting;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetBottom;
        private System.Windows.Forms.Button btnSetDown;
        private System.Windows.Forms.Button btnSetUp;
        private System.Windows.Forms.Button btnSetTop;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnName;
        private System.Windows.Forms.DataGridViewTextBoxColumn HeaderText;
        private System.Windows.Forms.DataGridViewTextBoxColumn DisplayIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn Width;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Visible;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Frozen;
    }
}