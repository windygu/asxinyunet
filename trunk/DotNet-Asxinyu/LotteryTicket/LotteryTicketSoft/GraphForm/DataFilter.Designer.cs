namespace LotteryTicketSoft.GraphForm
{
    partial class DataFilter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataFilter));
            this.gpbFilter = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSaveFile = new System.Windows.Forms.Button();
            this.txtSaveFileName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOPenDataFile = new System.Windows.Forms.Button();
            this.txtInitFileName = new System.Windows.Forms.TextBox();
            this.lblPrepareDataPath = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SaveFile = new System.Windows.Forms.SaveFileDialog();
            this.formPager = new DotNet.WinForm.Controls.WinFormPager();
            this.gpbFilter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // gpbFilter
            // 
            this.gpbFilter.Controls.Add(this.btnOK);
            this.gpbFilter.Controls.Add(this.btnSaveFile);
            this.gpbFilter.Controls.Add(this.txtSaveFileName);
            this.gpbFilter.Controls.Add(this.label1);
            this.gpbFilter.Controls.Add(this.btnOPenDataFile);
            this.gpbFilter.Controls.Add(this.txtInitFileName);
            this.gpbFilter.Controls.Add(this.lblPrepareDataPath);
            this.gpbFilter.Location = new System.Drawing.Point(1, 2);
            this.gpbFilter.Margin = new System.Windows.Forms.Padding(4);
            this.gpbFilter.Name = "gpbFilter";
            this.gpbFilter.Padding = new System.Windows.Forms.Padding(4);
            this.gpbFilter.Size = new System.Drawing.Size(486, 92);
            this.gpbFilter.TabIndex = 0;
            this.gpbFilter.TabStop = false;
            this.gpbFilter.Text = "过滤设置";
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(417, 56);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(66, 27);
            this.btnOK.TabIndex = 8;
            this.btnOK.Text = "计算";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSaveFile
            // 
            this.btnSaveFile.Location = new System.Drawing.Point(363, 56);
            this.btnSaveFile.Name = "btnSaveFile";
            this.btnSaveFile.Size = new System.Drawing.Size(54, 26);
            this.btnSaveFile.TabIndex = 7;
            this.btnSaveFile.Text = "保存";
            this.btnSaveFile.UseVisualStyleBackColor = true;
            this.btnSaveFile.Click += new System.EventHandler(this.btnSaveFile_Click);
            // 
            // txtSaveFileName
            // 
            this.txtSaveFileName.Location = new System.Drawing.Point(107, 56);
            this.txtSaveFileName.Name = "txtSaveFileName";
            this.txtSaveFileName.Size = new System.Drawing.Size(256, 26);
            this.txtSaveFileName.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "数据保存路径";
            // 
            // btnOPenDataFile
            // 
            this.btnOPenDataFile.Location = new System.Drawing.Point(364, 21);
            this.btnOPenDataFile.Name = "btnOPenDataFile";
            this.btnOPenDataFile.Size = new System.Drawing.Size(54, 26);
            this.btnOPenDataFile.TabIndex = 4;
            this.btnOPenDataFile.Text = "打开";
            this.btnOPenDataFile.UseVisualStyleBackColor = true;
            this.btnOPenDataFile.Click += new System.EventHandler(this.btnOPenDataFile_Click);
            // 
            // txtInitFileName
            // 
            this.txtInitFileName.Location = new System.Drawing.Point(108, 21);
            this.txtInitFileName.Name = "txtInitFileName";
            this.txtInitFileName.Size = new System.Drawing.Size(256, 26);
            this.txtInitFileName.TabIndex = 3;
            // 
            // lblPrepareDataPath
            // 
            this.lblPrepareDataPath.AutoSize = true;
            this.lblPrepareDataPath.Location = new System.Drawing.Point(4, 26);
            this.lblPrepareDataPath.Name = "lblPrepareDataPath";
            this.lblPrepareDataPath.Size = new System.Drawing.Size(104, 16);
            this.lblPrepareDataPath.TabIndex = 0;
            this.lblPrepareDataPath.Text = "初始数据路径";
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(-2, 99);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(489, 295);
            this.dgv.TabIndex = 2;
            // 
            // OpenFile
            // 
            this.OpenFile.Filter = "Lot数据文件|*.lot";
            this.OpenFile.Title = "打开Lot数据文件";
            // 
            // SaveFile
            // 
            this.SaveFile.Filter = "Lot数据文件|*.lot";
            this.SaveFile.Title = "保存Lot数据文件";
            // 
            // formPager
            // 
            this.formPager.AutoSize = true;
            this.formPager.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.formPager.BackColor = System.Drawing.Color.Transparent;
            this.formPager.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("formPager.BackgroundImage")));
            this.formPager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.formPager.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.formPager.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.formPager.Location = new System.Drawing.Point(3, 401);
            this.formPager.Margin = new System.Windows.Forms.Padding(4);
            this.formPager.Name = "formPager";
            this.formPager.RecordCount = 0;
            this.formPager.Size = new System.Drawing.Size(423, 27);
            this.formPager.TabIndex = 3;
            this.formPager.PageIndexChanged += new DotNet.WinForm.Controls.WinFormPager.EventHandler(this.formPager_PageIndexChanged);
            // 
            // DataFilter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.formPager);
            this.Controls.Add(this.dgv);
            this.Controls.Add(this.gpbFilter);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "DataFilter";
            this.Size = new System.Drawing.Size(486, 427);
            this.gpbFilter.ResumeLayout(false);
            this.gpbFilter.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gpbFilter;
        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.TextBox txtInitFileName;
        private System.Windows.Forms.Label lblPrepareDataPath;
        private System.Windows.Forms.Button btnOPenDataFile;
        private System.Windows.Forms.Button btnSaveFile;
        private System.Windows.Forms.TextBox txtSaveFileName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.SaveFileDialog SaveFile;
        private System.Windows.Forms.Button btnOK;
        private DotNet.WinForm.Controls.WinFormPager formPager;
    }
}
