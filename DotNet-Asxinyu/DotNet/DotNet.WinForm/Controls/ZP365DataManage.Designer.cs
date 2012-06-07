namespace DotNet.WinForm.Controls
{
    partial class ZP365DataManage
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.winPage = new DotNet.WinForm.Controls.WinFormPager();
            this.stausInfoShow1 = new DotNet.WinForm.Controls.StausInfoShow();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(1);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgv);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel1MinSize = 310;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.winPage);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Panel2MinSize = 0;
            this.splitContainer1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer1.Size = new System.Drawing.Size(655, 371);
            this.splitContainer1.SplitterDistance = 339;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 41;
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(0, 0);
            this.dgv.Name = "dgv";
            this.dgv.RowTemplate.Height = 23;
            this.dgv.Size = new System.Drawing.Size(655, 339);
            this.dgv.TabIndex = 42;
            this.dgv.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgv_DataError);
            this.dgv.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.SetCellToolTipText);
            this.dgv.RowLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_RowLeave);
            // 
            // winPage
            // 
            this.winPage.AutoSize = true;
            this.winPage.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.winPage.BackColor = System.Drawing.Color.Transparent;
            this.winPage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.winPage.Dock = System.Windows.Forms.DockStyle.Right;
            this.winPage.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.winPage.Location = new System.Drawing.Point(232, 0);
            this.winPage.Name = "winPage";
            this.winPage.RecordCount = 0;
            this.winPage.Size = new System.Drawing.Size(423, 31);
            this.winPage.TabIndex = 0;
            this.winPage.PageIndexChanged += new DotNet.WinForm.Controls.WinFormPager.EventHandler(this.winPage_PageIndexChanged);
            // 
            // stausInfoShow1
            // 
            this.stausInfoShow1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.stausInfoShow1.Location = new System.Drawing.Point(0, 371);
            this.stausInfoShow1.Name = "stausInfoShow1";
            this.stausInfoShow1.Size = new System.Drawing.Size(655, 24);
            this.stausInfoShow1.TabIndex = 40;
            // 
            // ZP365DataManage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.stausInfoShow1);
            this.Name = "ZP365DataManage";
            this.Size = new System.Drawing.Size(655, 395);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.SplitContainer splitContainer1;

        #endregion

        public DotNet.WinForm.Controls.StausInfoShow stausInfoShow1;
        public System.Windows.Forms.DataGridView dgv;
        protected WinFormPager winPage;
    }
}
