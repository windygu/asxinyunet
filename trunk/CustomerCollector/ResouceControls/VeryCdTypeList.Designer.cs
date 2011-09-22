namespace ResouceControls
{
    partial class VeryCdTypeList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VeryCdTypeList));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolFind = new System.Windows.Forms.ToolStripButton();
            this.toolExportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.stausInfoShow1 = new DotNet.Tools.Controls.StausInfoShow();
            this.dgvTypeList = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeList)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolStripSeparator1,
            this.toolFind,
            this.toolExportToExcel,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(699, 25);
            this.toolStrip1.TabIndex = 39;
            this.toolStrip1.Text = " ";
            // 
            // toolSave
            // 
            this.toolSave.Enabled = false;
            this.toolSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(55, 22);
            this.toolSave.Tag = "1";
            this.toolSave.Text = "保存";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolFind
            // 
            this.toolFind.Enabled = false;
            this.toolFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolFind.Image = ((System.Drawing.Image)(resources.GetObject("toolFind.Image")));
            this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFind.Name = "toolFind";
            this.toolFind.Size = new System.Drawing.Size(55, 22);
            this.toolFind.Tag = "3";
            this.toolFind.Text = "查询";
            // 
            // toolExportToExcel
            // 
            this.toolExportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("toolExportToExcel.Image")));
            this.toolExportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolExportToExcel.Name = "toolExportToExcel";
            this.toolExportToExcel.Size = new System.Drawing.Size(104, 22);
            this.toolExportToExcel.Text = "导出到Excel";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolExit
            // 
            this.toolExit.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolExit.Image = ((System.Drawing.Image)(resources.GetObject("toolExit.Image")));
            this.toolExit.ImageTransparentColor = System.Drawing.SystemColors.Control;
            this.toolExit.Name = "toolExit";
            this.toolExit.Size = new System.Drawing.Size(55, 22);
            this.toolExit.Tag = "7";
            this.toolExit.Text = "退出";
            // 
            // stausInfoShow1
            // 
            this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stausInfoShow1.Location = new System.Drawing.Point(0, 412);
            this.stausInfoShow1.Name = "stausInfoShow1";
            this.stausInfoShow1.Size = new System.Drawing.Size(699, 29);
            this.stausInfoShow1.TabIndex = 40;
            // 
            // dgvTypeList
            // 
            this.dgvTypeList.AllowUserToDeleteRows = false;
            this.dgvTypeList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTypeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTypeList.Location = new System.Drawing.Point(0, 25);
            this.dgvTypeList.Name = "dgvTypeList";
            this.dgvTypeList.RowTemplate.Height = 23;
            this.dgvTypeList.Size = new System.Drawing.Size(699, 387);
            this.dgvTypeList.TabIndex = 42;
            // 
            // VeryCdTypeList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dgvTypeList);
            this.Controls.Add(this.stausInfoShow1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "VeryCdTypeList";
            this.Size = new System.Drawing.Size(699, 441);
            this.Load += new System.EventHandler(this.VeryCdTypeList_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTypeList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripButton toolExportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private DotNet.Tools.Controls.StausInfoShow stausInfoShow1;
        private System.Windows.Forms.DataGridView dgvTypeList;
    }
}
