namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class DataEditBaseForm : Form
    {
        [CompilerGenerated]
        private bool <CloseValiData>k__BackingField;
        protected GroupBox BaseFormGroupBox;
        protected Panel BaseFormTopPanel;
        protected Button BtnCancel;
        protected Button btnNext;
        protected Button btnPrevious;
        protected Button BtnSave;
        protected Button BtnSure;
        private IContainer components;
        private int FormType;
        protected bool isRefresh = true;
        protected int M_ID = -2;
        [Category("Base_DataForm"), Description("刷新数据")]
        public RefreshDataEventHandle RefreshData;

        public DataEditBaseForm()
        {
            this.InitializeComponent();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        private void BtnSave_Click(object sender, EventArgs e) { this.SaveOption(); }

        private void BtnSure_Click(object sender, EventArgs e)
        {
            this.BtnSure.Focus();
            try
            {
                string sM = this.ValidateInput();
                if (sM == string.Empty)
                {
                    if (this.ValidateChanges())
                    {
                        this.BtnSure.DialogResult = DialogResult.OK;
                        if (this.FormType == 0 || this.FormType == 1)
                        {
                            if (this.FormType == 0)
                                sM = this.CreateData();
                            else
                                sM = this.SaveData();
                            if (sM == string.Empty)
                            {
                                if (this.isRefresh && this.RefreshData != null) this.RefreshData(this.M_ID);
                                base.DialogResult = DialogResult.Yes;
                            }
                            else
                                MessageBox.Show(sM, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                        else
                            sM = "操作类型判断失败！";
                    }
                    else
                        base.DialogResult = DialogResult.No;
                }
                else
                    MessageBox.Show(sM, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }
        }

        protected virtual void CancelMothond() { base.DialogResult = DialogResult.No; }

        protected virtual string CreateData() { return string.Empty; }

        private void DataDetailBaseForm_Load(object sender, EventArgs e) { this.RefrashChildData(); }

        private void DataEditBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.CloseValiData && base.DialogResult != DialogResult.No && base.DialogResult != DialogResult.Yes)
                {
                    this.BtnCancel.Focus();
                    if (this.ValidateChanges())
                    {
                        switch (MessageBox.Show("数据已改变，是否保存？", "操作提示", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk))
                        {
                            case DialogResult.Yes:
                            {
                                string sTr = string.Empty;
                                try
                                {
                                    if (this.FormType == 0)
                                        sTr = this.CreateData();
                                    else
                                        sTr = this.SaveData();
                                }
                                catch (Exception ex)
                                {
                                    sTr = ex.Message;
                                }
                                if (sTr != string.Empty)
                                {
                                    MessageBox.Show(sTr, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    e.Cancel = true;
                                }
                                break;
                            }
                            case DialogResult.Cancel:
                                e.Cancel = true;
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                e.Cancel = true;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnPrevious = new Button();
            this.btnNext = new Button();
            this.BaseFormTopPanel = new Panel();
            this.BtnSave = new Button();
            this.BtnSure = new Button();
            this.BaseFormGroupBox = new GroupBox();
            this.BtnCancel = new Button();
            this.BaseFormGroupBox.SuspendLayout();
            base.SuspendLayout();
            this.btnPrevious.Dock = DockStyle.Right;
            this.btnPrevious.Location = new Point(0x9d, 0x11);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new Size(0x54, 30);
            this.btnPrevious.TabIndex = 0;
            this.btnPrevious.Text = "上一条记录";
            this.btnPrevious.UseVisualStyleBackColor = true;
            this.btnPrevious.Visible = false;
            this.btnNext.Dock = DockStyle.Right;
            this.btnNext.Location = new Point(0xf1, 0x11);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new Size(0x54, 30);
            this.btnNext.TabIndex = 1;
            this.btnNext.Text = "下一条记录";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Visible = false;
            this.BaseFormTopPanel.Dock = DockStyle.Fill;
            this.BaseFormTopPanel.Location = new Point(0, 0);
            this.BaseFormTopPanel.Name = "BaseFormTopPanel";
            this.BaseFormTopPanel.Size = new Size(0x21f, 0x13a);
            this.BaseFormTopPanel.TabIndex = 4;
            this.BtnSave.Dock = DockStyle.Right;
            this.BtnSave.Location = new Point(0x145, 0x11);
            this.BtnSave.Name = "BtnSave";
            this.BtnSave.Size = new Size(0x4b, 30);
            this.BtnSave.TabIndex = 2;
            this.BtnSave.Text = "保 存";
            this.BtnSave.UseVisualStyleBackColor = true;
            this.BtnSave.Visible = false;
            this.BtnSave.Click += new System.EventHandler(this.BtnSave_Click);
            this.BtnSure.Dock = DockStyle.Right;
            this.BtnSure.Location = new Point(400, 0x11);
            this.BtnSure.Name = "BtnSure";
            this.BtnSure.Size = new Size(70, 30);
            this.BtnSure.TabIndex = 3;
            this.BtnSure.Text = "确 定";
            this.BtnSure.UseVisualStyleBackColor = true;
            this.BtnSure.Click += new System.EventHandler(this.BtnSure_Click);
            this.BaseFormGroupBox.Controls.Add(this.btnPrevious);
            this.BaseFormGroupBox.Controls.Add(this.btnNext);
            this.BaseFormGroupBox.Controls.Add(this.BtnSave);
            this.BaseFormGroupBox.Controls.Add(this.BtnSure);
            this.BaseFormGroupBox.Controls.Add(this.BtnCancel);
            this.BaseFormGroupBox.Dock = DockStyle.Bottom;
            this.BaseFormGroupBox.Location = new Point(0, 0x13a);
            this.BaseFormGroupBox.Name = "BaseFormGroupBox";
            this.BaseFormGroupBox.Size = new Size(0x21f, 50);
            this.BaseFormGroupBox.TabIndex = 5;
            this.BaseFormGroupBox.TabStop = false;
            this.BtnCancel.DialogResult = DialogResult.Cancel;
            this.BtnCancel.Dock = DockStyle.Right;
            this.BtnCancel.Location = new Point(470, 0x11);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new Size(70, 30);
            this.BtnCancel.TabIndex = 4;
            this.BtnCancel.Text = "关 闭";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x21f, 0x16c);
            base.Controls.Add(this.BaseFormTopPanel);
            base.Controls.Add(this.BaseFormGroupBox);
            base.Name = "DataEditBaseForm";
            this.Text = "DataEditBaseForm";
            base.Load += new System.EventHandler(this.DataDetailBaseForm_Load);
            this.BaseFormGroupBox.ResumeLayout(false);
            base.ResumeLayout(false);
        }

        protected virtual void LoadChildData() {  }

        protected void RefrashChildData() { this.LoadChildData(); }

        protected virtual string SaveData() { return string.Empty; }

        protected bool SaveOption()
        {
            string sTr = this.ValidateInput();
            if (sTr == string.Empty)
            {
                if (!this.ValidateChanges()) return true;
                try
                {
                    if (this.FormType == 0)
                        sTr = this.CreateData();
                    else
                        sTr = this.SaveData();
                }
                catch (Exception ex)
                {
                    sTr = ex.Message;
                }
                this.RefreshData(this.M_ID);
                if (sTr == string.Empty)
                {
                    MessageBox.Show("保存成功！", "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                    return true;
                }
                MessageBox.Show(sTr, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            MessageBox.Show(sTr, "操作提示", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            return false;
        }

        protected virtual bool ValidateChanges() { return false; }

        protected virtual string ValidateInput() { return string.Empty; }

        [Description("获取或设置'明细基窗口'类型(0:新建,1:编辑)"), Browsable(true)]
        public int BaseFormType { get { return this.FormType; } set { this.FormType = value; } }

        [Browsable(true), Description("是否需要窗口关闭验证")]
        public bool CloseValiData { [CompilerGenerated]
        get { return this.<CloseValiData>k__BackingField; } [CompilerGenerated]
        set { this.<CloseValiData>k__BackingField = value; } }

        [Browsable(true), Description("是否需要刷新调用窗口")]
        public bool IsRefresh { get { return this.isRefresh; } set { this.isRefresh = value; } }

        public delegate void RefreshDataEventHandle(int ID);
    }
}
