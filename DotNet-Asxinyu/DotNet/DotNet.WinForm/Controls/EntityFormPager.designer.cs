namespace DotNet.WinForm.Controls
{
    partial class EntityFormPager
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EntityFormPager));
            this.btnFirst = new System.Windows.Forms.Button();
            this.imglstPager = new System.Windows.Forms.ImageList(this.components);
            this.btnPrevious = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnLast = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtToPageIndex = new System.Windows.Forms.TextBox();
            this.toolTipPager = new System.Windows.Forms.ToolTip(this.components);
            this.btnToPageIndex = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnFirst
            // 
            resources.ApplyResources(this.btnFirst, "btnFirst");
            this.btnFirst.BackColor = System.Drawing.Color.Transparent;
            this.btnFirst.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFirst.FlatAppearance.BorderSize = 0;
            this.btnFirst.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnFirst.ImageList = this.imglstPager;
            this.btnFirst.Name = "btnFirst";
            this.btnFirst.TabStop = false;
            this.btnFirst.UseVisualStyleBackColor = false;
            this.btnFirst.Click += new System.EventHandler(this.btnFirst_Click);
            // 
            // imglstPager
            // 
            this.imglstPager.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglstPager.ImageStream")));
            this.imglstPager.TransparentColor = System.Drawing.Color.Transparent;
            this.imglstPager.Images.SetKeyName(0, "resultset_first.png");
            this.imglstPager.Images.SetKeyName(1, "resultset_previous.png");
            this.imglstPager.Images.SetKeyName(2, "resultset_next.png");
            this.imglstPager.Images.SetKeyName(3, "resultset_last.png");
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.BackColor = System.Drawing.Color.Transparent;
            this.btnPrevious.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevious.FlatAppearance.BorderSize = 0;
            this.btnPrevious.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnPrevious.ImageList = this.imglstPager;
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.TabStop = false;
            this.btnPrevious.UseVisualStyleBackColor = false;
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.BackColor = System.Drawing.Color.Transparent;
            this.btnNext.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNext.FlatAppearance.BorderSize = 0;
            this.btnNext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNext.ImageList = this.imglstPager;
            this.btnNext.Name = "btnNext";
            this.btnNext.TabStop = false;
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnLast
            // 
            resources.ApplyResources(this.btnLast, "btnLast");
            this.btnLast.BackColor = System.Drawing.Color.Transparent;
            this.btnLast.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLast.FlatAppearance.BorderSize = 0;
            this.btnLast.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLast.ImageList = this.imglstPager;
            this.btnLast.Name = "btnLast";
            this.btnLast.TabStop = false;
            this.btnLast.UseVisualStyleBackColor = false;
            this.btnLast.Click += new System.EventHandler(this.btnLast_Click);
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Name = "label3";
            // 
            // txtToPageIndex
            // 
            resources.ApplyResources(this.txtToPageIndex, "txtToPageIndex");
            this.txtToPageIndex.Name = "txtToPageIndex";
            this.txtToPageIndex.TabStop = false;
            this.toolTipPager.SetToolTip(this.txtToPageIndex, resources.GetString("txtToPageIndex.ToolTip"));
            this.txtToPageIndex.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtToPageIndex_KeyPress);
            // 
            // btnToPageIndex
            // 
            resources.ApplyResources(this.btnToPageIndex, "btnToPageIndex");
            this.btnToPageIndex.BackColor = System.Drawing.Color.Transparent;
            this.btnToPageIndex.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnToPageIndex.FlatAppearance.BorderSize = 0;
            this.btnToPageIndex.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnToPageIndex.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnToPageIndex.Name = "btnToPageIndex";
            this.btnToPageIndex.TabStop = false;
            this.toolTipPager.SetToolTip(this.btnToPageIndex, resources.GetString("btnToPageIndex.ToolTip"));
            this.btnToPageIndex.UseVisualStyleBackColor = false;
            this.btnToPageIndex.Click += new System.EventHandler(this.btnToPageIndex_Click);
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Name = "label1";
            // 
            // EntityFormPager
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::DotNet.Tools.Controls.Resource.PageBg;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnToPageIndex);
            this.Controls.Add(this.txtToPageIndex);
            this.Controls.Add(this.btnLast);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnPrevious);
            this.Controls.Add(this.btnFirst);
            this.Controls.Add(this.label3);
            this.Name = "EntityFormPager";
            this.toolTipPager.SetToolTip(this, resources.GetString("$this.ToolTip"));
            this.Load += new System.EventHandler(this.Pager_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Pager_Paint);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.WinFormPager_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ImageList imglstPager;
        private System.Windows.Forms.Button btnFirst;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnLast;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtToPageIndex;
        private System.Windows.Forms.ToolTip toolTipPager;
        private System.Windows.Forms.Button btnToPageIndex;
        private System.Windows.Forms.Label label1;
    }
}
