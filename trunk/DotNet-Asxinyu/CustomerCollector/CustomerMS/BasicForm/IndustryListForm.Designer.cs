/*
 * Created by SharpDevelop.
 * User: 董斌辉
 * Date: 2011-8-24
 * Time: 22:11
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace CustomerMS.BasicForm
{
	partial class IndustryListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndustryListForm));
            this.StausInfo = new DotNet.Tools.Controls.StausInfoShow();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolSave = new System.Windows.Forms.ToolStripButton();
            this.toolCancel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolAdd = new System.Windows.Forms.ToolStripButton();
            this.toolFind = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolAmend = new System.Windows.Forms.ToolStripButton();
            this.toolDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolExit = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gpbSet = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.combInfoOrigin = new System.Windows.Forms.ComboBox();
            this.combRootClassName = new System.Windows.Forms.ComboBox();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.txtKeyWords = new System.Windows.Forms.TextBox();
            this.txtCollectionMark = new System.Windows.Forms.TextBox();
            this.txtIndustryWebSite = new System.Windows.Forms.TextBox();
            this.txtIndustryName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblInfoOrigin = new System.Windows.Forms.Label();
            this.lblKeyWords = new System.Windows.Forms.Label();
            this.lblRootClassName = new System.Windows.Forms.Label();
            this.lblIndustryWebSite = new System.Windows.Forms.Label();
            this.lblIndustryName = new System.Windows.Forms.Label();
            this.dgvIndustryList = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.gpbSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndustryList)).BeginInit();
            this.SuspendLayout();
            // 
            // StausInfo
            // 
            this.StausInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.StausInfo.Location = new System.Drawing.Point(0, 445);
            this.StausInfo.Name = "StausInfo";
            this.StausInfo.Size = new System.Drawing.Size(582, 24);
            this.StausInfo.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSave,
            this.toolCancel,
            this.toolStripSeparator1,
            this.toolAdd,
            this.toolFind,
            this.toolStripButton1,
            this.toolAmend,
            this.toolDelete,
            this.toolStripSeparator2,
            this.toolExit});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(582, 25);
            this.toolStrip1.TabIndex = 34;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolSave
            // 
            this.toolSave.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolSave.Image = ((System.Drawing.Image)(resources.GetObject("toolSave.Image")));
            this.toolSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolSave.Name = "toolSave";
            this.toolSave.Size = new System.Drawing.Size(55, 22);
            this.toolSave.Tag = "1";
            this.toolSave.Text = "保存";
            // 
            // toolCancel
            // 
            this.toolCancel.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolCancel.Image = ((System.Drawing.Image)(resources.GetObject("toolCancel.Image")));
            this.toolCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolCancel.Name = "toolCancel";
            this.toolCancel.Size = new System.Drawing.Size(55, 22);
            this.toolCancel.Tag = "2";
            this.toolCancel.Text = "取消";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolAdd
            // 
            this.toolAdd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolAdd.Image = ((System.Drawing.Image)(resources.GetObject("toolAdd.Image")));
            this.toolAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAdd.Name = "toolAdd";
            this.toolAdd.Size = new System.Drawing.Size(55, 22);
            this.toolAdd.Tag = "3";
            this.toolAdd.Text = "添加";
            this.toolAdd.Click += new System.EventHandler(this.toolAdd_Click);
            // 
            // toolFind
            // 
            this.toolFind.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolFind.Image = ((System.Drawing.Image)(resources.GetObject("toolFind.Image")));
            this.toolFind.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolFind.Name = "toolFind";
            this.toolFind.Size = new System.Drawing.Size(55, 22);
            this.toolFind.Tag = "3";
            this.toolFind.Text = "查询";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(91, 22);
            this.toolStripButton1.Text = "导出到Excel";
            // 
            // toolAmend
            // 
            this.toolAmend.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolAmend.Image = ((System.Drawing.Image)(resources.GetObject("toolAmend.Image")));
            this.toolAmend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolAmend.Name = "toolAmend";
            this.toolAmend.Size = new System.Drawing.Size(55, 22);
            this.toolAmend.Tag = "3";
            this.toolAmend.Text = "修改";
            // 
            // toolDelete
            // 
            this.toolDelete.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.toolDelete.Image = ((System.Drawing.Image)(resources.GetObject("toolDelete.Image")));
            this.toolDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolDelete.Name = "toolDelete";
            this.toolDelete.Size = new System.Drawing.Size(55, 22);
            this.toolDelete.Tag = "3";
            this.toolDelete.Text = "删除";
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
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(0, 25);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gpbSet);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dgvIndustryList);
            this.splitContainer1.Size = new System.Drawing.Size(582, 420);
            this.splitContainer1.SplitterDistance = 172;
            this.splitContainer1.SplitterWidth = 2;
            this.splitContainer1.TabIndex = 35;
            // 
            // gpbSet
            // 
            this.gpbSet.Controls.Add(this.dateTimePicker1);
            this.gpbSet.Controls.Add(this.combInfoOrigin);
            this.gpbSet.Controls.Add(this.combRootClassName);
            this.gpbSet.Controls.Add(this.txtRemark);
            this.gpbSet.Controls.Add(this.txtKeyWords);
            this.gpbSet.Controls.Add(this.txtCollectionMark);
            this.gpbSet.Controls.Add(this.txtIndustryWebSite);
            this.gpbSet.Controls.Add(this.txtIndustryName);
            this.gpbSet.Controls.Add(this.label1);
            this.gpbSet.Controls.Add(this.label7);
            this.gpbSet.Controls.Add(this.label6);
            this.gpbSet.Controls.Add(this.lblInfoOrigin);
            this.gpbSet.Controls.Add(this.lblKeyWords);
            this.gpbSet.Controls.Add(this.lblRootClassName);
            this.gpbSet.Controls.Add(this.lblIndustryWebSite);
            this.gpbSet.Controls.Add(this.lblIndustryName);
            this.gpbSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbSet.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gpbSet.Location = new System.Drawing.Point(0, 0);
            this.gpbSet.Name = "gpbSet";
            this.gpbSet.Size = new System.Drawing.Size(582, 172);
            this.gpbSet.TabIndex = 36;
            this.gpbSet.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(424, 77);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(154, 23);
            this.dateTimePicker1.TabIndex = 18;
            // 
            // combInfoOrigin
            // 
            this.combInfoOrigin.FormattingEnabled = true;
            this.combInfoOrigin.Location = new System.Drawing.Point(423, 48);
            this.combInfoOrigin.Name = "combInfoOrigin";
            this.combInfoOrigin.Size = new System.Drawing.Size(154, 22);
            this.combInfoOrigin.TabIndex = 17;
            // 
            // combRootClassName
            // 
            this.combRootClassName.FormattingEnabled = true;
            this.combRootClassName.Location = new System.Drawing.Point(423, 14);
            this.combRootClassName.Name = "combRootClassName";
            this.combRootClassName.Size = new System.Drawing.Size(154, 22);
            this.combRootClassName.TabIndex = 16;
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(83, 148);
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(495, 23);
            this.txtRemark.TabIndex = 12;
            // 
            // txtKeyWords
            // 
            this.txtKeyWords.Location = new System.Drawing.Point(83, 116);
            this.txtKeyWords.Name = "txtKeyWords";
            this.txtKeyWords.Size = new System.Drawing.Size(495, 23);
            this.txtKeyWords.TabIndex = 11;
            // 
            // txtCollectionMark
            // 
            this.txtCollectionMark.Location = new System.Drawing.Point(83, 82);
            this.txtCollectionMark.Name = "txtCollectionMark";
            this.txtCollectionMark.Size = new System.Drawing.Size(236, 23);
            this.txtCollectionMark.TabIndex = 10;
            // 
            // txtIndustryWebSite
            // 
            this.txtIndustryWebSite.Location = new System.Drawing.Point(83, 47);
            this.txtIndustryWebSite.Name = "txtIndustryWebSite";
            this.txtIndustryWebSite.Size = new System.Drawing.Size(236, 23);
            this.txtIndustryWebSite.TabIndex = 9;
            // 
            // txtIndustryName
            // 
            this.txtIndustryName.Location = new System.Drawing.Point(83, 14);
            this.txtIndustryName.Name = "txtIndustryName";
            this.txtIndustryName.Size = new System.Drawing.Size(236, 23);
            this.txtIndustryName.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 154);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "备注";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(354, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 14);
            this.label7.TabIndex = 6;
            this.label7.Text = "更新时间";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 86);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 14);
            this.label6.TabIndex = 5;
            this.label6.Text = "采集标志";
            // 
            // lblInfoOrigin
            // 
            this.lblInfoOrigin.AutoSize = true;
            this.lblInfoOrigin.Location = new System.Drawing.Point(354, 51);
            this.lblInfoOrigin.Name = "lblInfoOrigin";
            this.lblInfoOrigin.Size = new System.Drawing.Size(63, 14);
            this.lblInfoOrigin.TabIndex = 4;
            this.lblInfoOrigin.Text = "资料来源";
            // 
            // lblKeyWords
            // 
            this.lblKeyWords.AutoSize = true;
            this.lblKeyWords.Location = new System.Drawing.Point(30, 120);
            this.lblKeyWords.Name = "lblKeyWords";
            this.lblKeyWords.Size = new System.Drawing.Size(49, 14);
            this.lblKeyWords.TabIndex = 3;
            this.lblKeyWords.Text = "关键词";
            // 
            // lblRootClassName
            // 
            this.lblRootClassName.AutoSize = true;
            this.lblRootClassName.Location = new System.Drawing.Point(354, 17);
            this.lblRootClassName.Name = "lblRootClassName";
            this.lblRootClassName.Size = new System.Drawing.Size(63, 14);
            this.lblRootClassName.TabIndex = 2;
            this.lblRootClassName.Text = "根类名称";
            // 
            // lblIndustryWebSite
            // 
            this.lblIndustryWebSite.AutoSize = true;
            this.lblIndustryWebSite.Location = new System.Drawing.Point(16, 52);
            this.lblIndustryWebSite.Name = "lblIndustryWebSite";
            this.lblIndustryWebSite.Size = new System.Drawing.Size(63, 14);
            this.lblIndustryWebSite.TabIndex = 1;
            this.lblIndustryWebSite.Text = "行业网址";
            // 
            // lblIndustryName
            // 
            this.lblIndustryName.AutoSize = true;
            this.lblIndustryName.Location = new System.Drawing.Point(16, 18);
            this.lblIndustryName.Name = "lblIndustryName";
            this.lblIndustryName.Size = new System.Drawing.Size(63, 14);
            this.lblIndustryName.TabIndex = 0;
            this.lblIndustryName.Text = "行业名称";
            // 
            // dgvIndustryList
            // 
            this.dgvIndustryList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIndustryList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIndustryList.Location = new System.Drawing.Point(0, 0);
            this.dgvIndustryList.Name = "dgvIndustryList";
            this.dgvIndustryList.RowTemplate.Height = 23;
            this.dgvIndustryList.Size = new System.Drawing.Size(582, 246);
            this.dgvIndustryList.TabIndex = 0;
            // 
            // IndustryListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 469);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.StausInfo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "IndustryListForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IndustryListForm";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.gpbSet.ResumeLayout(false);
            this.gpbSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIndustryList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        private DotNet.Tools.Controls.StausInfoShow StausInfo;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolSave;
        private System.Windows.Forms.ToolStripButton toolCancel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolAdd;
        private System.Windows.Forms.ToolStripButton toolFind;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolAmend;
        private System.Windows.Forms.ToolStripButton toolDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolExit;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox gpbSet;
        private System.Windows.Forms.DataGridView dgvIndustryList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblInfoOrigin;
        private System.Windows.Forms.Label lblKeyWords;
        private System.Windows.Forms.Label lblRootClassName;
        private System.Windows.Forms.Label lblIndustryWebSite;
        private System.Windows.Forms.Label lblIndustryName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.TextBox txtKeyWords;
        private System.Windows.Forms.TextBox txtCollectionMark;
        private System.Windows.Forms.TextBox txtIndustryWebSite;
        private System.Windows.Forms.TextBox txtIndustryName;
        private System.Windows.Forms.ComboBox combRootClassName;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.ComboBox combInfoOrigin;
	}
}
