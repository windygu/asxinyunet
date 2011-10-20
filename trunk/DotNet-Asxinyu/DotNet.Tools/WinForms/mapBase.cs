namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class mapBase : UserControl
    {
        private IContainer components;
        public Label lb_Hint;
        public LoadGUI loadgui;

        public mapBase()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new Container();
            this.lb_Hint = new Label();
            base.SuspendLayout();
            this.lb_Hint.BackColor = Color.SteelBlue;
            this.lb_Hint.BorderStyle = BorderStyle.Fixed3D;
            this.lb_Hint.Dock = DockStyle.Left;
            this.lb_Hint.Font = new Font("宋体", 9.75f, FontStyle.Regular, GraphicsUnit.Point, 0x86);
            this.lb_Hint.ForeColor = Color.White;
            this.lb_Hint.Location = new Point(0, 0);
            this.lb_Hint.Name = "lb_Hint";
            this.lb_Hint.Size = new Size(0x17, 0x9a);
            this.lb_Hint.TabIndex = 3;
            this.lb_Hint.Text = "当前操作";
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.lb_Hint);
            base.Name = "mapBase";
            base.Size = new Size(0xe4, 0x9a);
            base.ResumeLayout(false);
        }
    }
}
