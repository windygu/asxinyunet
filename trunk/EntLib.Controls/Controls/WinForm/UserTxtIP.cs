namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class UserTxtIP : UserControl
    {
        private IContainer components;
        private Label lblA;
        private Label lblB;
        private Label lblC;
        private Panel panel1;
        private TextBox txtA;
        private TextBox txtB;
        private TextBox txtC;
        private TextBox txtD;

        public UserTxtIP()
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
            this.panel1 = new Panel();
            this.txtD = new TextBox();
            this.lblC = new Label();
            this.txtC = new TextBox();
            this.lblB = new Label();
            this.txtB = new TextBox();
            this.lblA = new Label();
            this.txtA = new TextBox();
            this.panel1.SuspendLayout();
            base.SuspendLayout();
            this.panel1.BackColor = SystemColors.Window;
            this.panel1.BorderStyle = BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtD);
            this.panel1.Controls.Add(this.lblC);
            this.panel1.Controls.Add(this.txtC);
            this.panel1.Controls.Add(this.lblB);
            this.panel1.Controls.Add(this.txtB);
            this.panel1.Controls.Add(this.lblA);
            this.panel1.Controls.Add(this.txtA);
            this.panel1.Location = new Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new Size(0x7c, 0x15);
            this.panel1.TabIndex = 0;
            this.txtD.BorderStyle = BorderStyle.None;
            this.txtD.Location = new Point(100, 2);
            this.txtD.MaxLength = 3;
            this.txtD.Name = "txtD";
            this.txtD.Size = new Size(20, 14);
            this.txtD.TabIndex = 6;
            this.txtD.Text = "255";
            this.txtD.TextAlign = HorizontalAlignment.Center;
            this.txtD.TextChanged += new System.EventHandler(this.txtD_TextChanged);
            this.txtD.KeyPress += new KeyPressEventHandler(this.txtD_KeyPress);
            this.lblC.Location = new Point(90, -2);
            this.lblC.Name = "lblC";
            this.lblC.Size = new Size(8, 0x17);
            this.lblC.TabIndex = 5;
            this.lblC.Text = ".";
            this.lblC.TextAlign = ContentAlignment.MiddleLeft;
            this.lblC.Enter += new System.EventHandler(this.lblC_Enter);
            this.txtC.BorderStyle = BorderStyle.None;
            this.txtC.Location = new Point(0x44, 2);
            this.txtC.MaxLength = 3;
            this.txtC.Name = "txtC";
            this.txtC.Size = new Size(20, 14);
            this.txtC.TabIndex = 4;
            this.txtC.Text = "255";
            this.txtC.TextAlign = HorizontalAlignment.Center;
            this.txtC.TextChanged += new System.EventHandler(this.txtC_TextChanged);
            this.txtC.KeyPress += new KeyPressEventHandler(this.txtC_KeyPress);
            this.lblB.Location = new Point(0x3a, -2);
            this.lblB.Name = "lblB";
            this.lblB.Size = new Size(8, 0x17);
            this.lblB.TabIndex = 3;
            this.lblB.Text = ".";
            this.lblB.TextAlign = ContentAlignment.MiddleLeft;
            this.lblB.Enter += new System.EventHandler(this.lblB_Enter);
            this.txtB.BorderStyle = BorderStyle.None;
            this.txtB.Location = new Point(0x24, 2);
            this.txtB.MaxLength = 3;
            this.txtB.Name = "txtB";
            this.txtB.Size = new Size(20, 14);
            this.txtB.TabIndex = 2;
            this.txtB.Text = "255";
            this.txtB.TextAlign = HorizontalAlignment.Center;
            this.txtB.TextChanged += new System.EventHandler(this.txtB_TextChanged);
            this.txtB.KeyPress += new KeyPressEventHandler(this.txtB_KeyPress);
            this.lblA.Location = new Point(0x1a, -2);
            this.lblA.Name = "lblA";
            this.lblA.Size = new Size(8, 0x17);
            this.lblA.TabIndex = 1;
            this.lblA.Text = ".";
            this.lblA.TextAlign = ContentAlignment.MiddleLeft;
            this.lblA.Enter += new System.EventHandler(this.lblA_Enter);
            this.txtA.BorderStyle = BorderStyle.None;
            this.txtA.Location = new Point(4, 2);
            this.txtA.MaxLength = 3;
            this.txtA.Name = "txtA";
            this.txtA.Size = new Size(20, 14);
            this.txtA.TabIndex = 0;
            this.txtA.Text = "255";
            this.txtA.TextAlign = HorizontalAlignment.Center;
            this.txtA.TextChanged += new System.EventHandler(this.txtA_TextChanged);
            this.txtA.KeyPress += new KeyPressEventHandler(this.txtA_KeyPress);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.panel1);
            base.Name = "UserTxtIP";
            base.Size = new Size(0x7c, 0x15);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            base.ResumeLayout(false);
        }

        private void lblA_Enter(object sender, EventArgs e)
        {
            this.txtB.Focus();
            this.txtB.Select();
        }

        private void lblB_Enter(object sender, EventArgs e)
        {
            this.txtC.Focus();
            this.txtC.Select();
        }

        private void lblC_Enter(object sender, EventArgs e)
        {
            this.txtD.Focus();
            this.txtD.Select();
        }

        private void txtA_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == '.' | e.KeyChar == '\r')
            {
                this.txtB.Focus();
                this.txtB.Select();
            }
            base.OnKeyPress(e);
        }

        private void txtA_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32((this.txtA.Text == "") ? "0" : this.txtA.Text) > 0xff) this.txtA.Text = "255";
        }

        private void txtB_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == '.' | e.KeyChar == '\r')
            {
                this.txtC.Focus();
                this.txtC.Select();
            }
            base.OnKeyPress(e);
        }

        private void txtB_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32((this.txtB.Text == "") ? "0" : this.txtB.Text) > 0xff) this.txtB.Text = "255";
        }

        private void txtC_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b') e.Handled = true;
            if (e.KeyChar == '.' | e.KeyChar == '\r')
            {
                this.txtD.Focus();
                this.txtD.Select();
            }
            base.OnKeyPress(e);
        }

        private void txtC_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32((this.txtC.Text == "") ? "0" : this.txtC.Text) > 0xff) this.txtC.Text = "255";
        }

        private void txtD_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < '0' || e.KeyChar > '9') && e.KeyChar != '\b') e.Handled = true;
            base.OnKeyPress(e);
        }

        private void txtD_TextChanged(object sender, EventArgs e)
        {
            if (Convert.ToInt32((this.txtD.Text == "") ? "0" : this.txtD.Text) > 0xff) this.txtD.Text = "255";
        }

        public string Text
        {
            get
            {
                string text = this.txtA.Text.Trim();
                if (text == "") text = "0";
                string text2 = this.txtB.Text.Trim();
                if (text2 == "") text2 = "0";
                string text3 = this.txtC.Text.Trim();
                if (text3 == "") text3 = "0";
                string text4 = this.txtD.Text.Trim();
                if (text4 == "") text4 = "0";
                return (text + "." + text2 + "." + text3 + "." + text4);
            }
            set
            {
                value = (value == null) ? "0.0.0.0" : value;
                value = (value == "") ? "0.0.0.0" : value;
                if (value != null)
                {
                    string[] array = value.Split(new char[] { '.' });
                    if (array.Length != 4)
                    {
                        this.txtA.Text = "0";
                        this.txtB.Text = "0";
                        this.txtC.Text = "0";
                        this.txtD.Text = "0";
                    }
                    else
                    {
                        this.txtA.Text = array[0];
                        this.txtB.Text = array[1];
                        this.txtC.Text = array[2];
                        this.txtD.Text = array[3];
                    }
                }
            }
        }

        public string Text16
        {
            get
            {
                string text = this.txtA.Text.Trim();
                if (text == "") text = "0";
                text = Convert.ToString(int.Parse(text), 0x10);
                if (text.Length == 1) text = "0" + text;
                string text2 = this.txtB.Text.Trim();
                if (text2 == "") text2 = "0";
                text2 = Convert.ToString(int.Parse(text2), 0x10);
                if (text2.Length == 1) text2 = "0" + text2;
                string text3 = this.txtC.Text.Trim();
                if (text3 == "") text3 = "0";
                text3 = Convert.ToString(int.Parse(text3), 0x10);
                if (text3.Length == 1) text3 = "0" + text3;
                string text4 = this.txtD.Text.Trim();
                if (text4 == "") text4 = "0";
                text4 = Convert.ToString(int.Parse(text4), 0x10);
                if (text4.Length == 1) text4 = "0" + text4;
                return (text + "." + text2 + "." + text3 + "." + text4);
            }
            set
            {
                string[] array = value.Split(new char[] { '.' });
                string text = array[0];
                text = Convert.ToInt32(text, 0x10).ToString();
                this.txtA.Text = text;
                string text2 = array[1];
                text2 = Convert.ToInt32(text2, 0x10).ToString();
                this.txtB.Text = text2;
                string text3 = array[2];
                text3 = Convert.ToInt32(text3, 0x10).ToString();
                this.txtC.Text = text3;
                string text4 = array[3];
                text4 = Convert.ToInt32(text4, 0x10).ToString();
                this.txtD.Text = text4;
            }
        }

        public string Value
        {
            get
            {
                string text = this.txtA.Text.Trim();
                if (text == "") text = "0";
                string text2 = this.txtB.Text.Trim();
                if (text2 == "") text2 = "0";
                string text3 = this.txtC.Text.Trim();
                if (text3 == "") text3 = "0";
                string text4 = this.txtD.Text.Trim();
                if (text4 == "") text4 = "0";
                return (text + text2 + text3 + text4);
            }
            set
            {
                if (value != null)
                {
                    string text = value.Substring(0, 3);
                    this.txtA.Text = text;
                    string text2 = value.Substring(3, 3);
                    this.txtB.Text = text2;
                    string text3 = value.Substring(6, 3);
                    this.txtC.Text = text3;
                    string text4 = value.Substring(9, 3);
                    this.txtD.Text = text4;
                }
            }
        }

        public string Value16
        {
            get
            {
                string text = this.txtA.Text.Trim();
                if (text == "") text = "0";
                text = Convert.ToString(int.Parse(text), 0x10);
                if (text.Length == 1) text = "0" + text;
                string text2 = this.txtB.Text.Trim();
                if (text2 == "") text2 = "0";
                text2 = Convert.ToString(int.Parse(text2), 0x10);
                if (text2.Length == 1) text2 = "0" + text2;
                string text3 = this.txtC.Text.Trim();
                if (text3 == "") text3 = "0";
                text3 = Convert.ToString(int.Parse(text3), 0x10);
                if (text3.Length == 1) text3 = "0" + text3;
                string text4 = this.txtD.Text.Trim();
                if (text4 == "") text4 = "0";
                text4 = Convert.ToString(int.Parse(text4), 0x10);
                if (text4.Length == 1) text4 = "0" + text4;
                return (text + text2 + text3 + text4);
            }
            set
            {
                string text = Convert.ToInt32(value.Substring(0, 2), 0x10).ToString();
                this.txtA.Text = text;
                string text2 = Convert.ToInt32(value.Substring(2, 2), 0x10).ToString();
                this.txtB.Text = text2;
                string text3 = Convert.ToInt32(value.Substring(4, 2), 0x10).ToString();
                this.txtC.Text = text3;
                string text4 = Convert.ToInt32(value.Substring(6, 2), 0x10).ToString();
                this.txtD.Text = text4;
            }
        }
    }
}
