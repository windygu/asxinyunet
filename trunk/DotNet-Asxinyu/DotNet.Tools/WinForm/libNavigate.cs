namespace EntLib.Controls.WinForm
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class libNavigate : mapBase
    {
        private int _pointType = 1;
        [CompilerGenerated]
        private string <RightID>k__BackingField;
        public Font BTN_FONT = new Font("宋体", 10.5f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
        public List<Button> btn_main = new List<Button>();
        public Color BTN_MAINCOLOR = Color.LightSteelBlue;
        public int BTN_MAINLEFT = 20;
        public int BTN_SEP = 5;
        public Point BTN_SIZE = new Point(120, 30);
        public List<Button> btn_sub = new List<Button>();
        public Color BTN_SUBCOLOR = SystemColors.Info;
        public int BTN_SUBLEFT = 200;
        public int BTN_TOP = 2;
        private Button btnBack;
        private IContainer components;

        public libNavigate()
        {
            this.InitializeComponent();
            this.loadMainButton();
        }

        private void btn_MainClick(object sender, EventArgs e) { this.loadSubButton(((RightTreeNode) ((Control) sender).Tag).RightID); }

        private void btn_SubClick(object sender, EventArgs e)
        {
            base.loadgui.ShowForm(sender, e);
            if (((RightTreeNode) (sender as Button).Tag).ClassName != "" && this.btn_sub.IndexOf(sender as Button) < 0) this.clearControl(this.btn_sub);
        }

        private void btnBack_Click(object sender, EventArgs e) { base.loadgui.setDockStyle(-1); }

        private void clearControl(List<Button> list)
        {
            for (int i = 0; i < list.Count; i++)
            {
                base.Controls.Remove(list[i]);
            }
            if (list == this.btn_main) this.clearControl(this.btn_sub);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.btnBack = new Button();
            base.SuspendLayout();
            base.lb_Hint.Size = new Size(0x17, 0xdb);
            this.btnBack.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;
            this.btnBack.BackColor = Color.Transparent;
            this.btnBack.FlatStyle = FlatStyle.Flat;
            this.btnBack.Font = new Font("宋体", 9f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.btnBack.ForeColor = Color.DodgerBlue;
            this.btnBack.Location = new Point(0x112, 0xb9);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new Size(0x4d, 0x17);
            this.btnBack.TabIndex = 0;
            this.btnBack.Text = " 返 回 ";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.btnBack);
            base.Name = "libNavigate";
            base.Size = new Size(0x162, 0xdb);
            base.Controls.SetChildIndex(this.btnBack, 0);
            base.Controls.SetChildIndex(base.lb_Hint, 0);
            base.ResumeLayout(false);
        }

        public void loadMainButton() {  }

        public void loadSubButton(string parentID) {  }

        public int PointType
        {
            get { return this._pointType; }
            set
            {
                this._pointType = value;
                this.loadMainButton();
                this.loadSubButton("");
            }
        }

        public string RightID { [CompilerGenerated]
        get { return this.<RightID>k__BackingField; } [CompilerGenerated]
        set { this.<RightID>k__BackingField = value; } }
    }
}
