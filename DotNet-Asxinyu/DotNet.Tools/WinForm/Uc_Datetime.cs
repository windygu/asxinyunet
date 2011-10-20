namespace EntLib.Controls.WinForm
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    public class Uc_Datetime : UserControl
    {
        private IContainer components;
        private DateTimePicker Dtp_Date;
        private DateTimePicker Dtp_Time;

        public Uc_Datetime()
        {
            this.InitializeComponent();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null) this.components.Dispose();
            base.Dispose(disposing);
        }

        private void Dtp_Date_ValueChanged(object sender, EventArgs e) {  }

        private void Dtp_Time_ValueChanged(object sender, EventArgs e) {  }

        private void InitializeComponent()
        {
            this.components = new Container();
            base.AutoScaleMode = AutoScaleMode.Font;
            this.Dtp_Time = new DateTimePicker();
            this.Dtp_Date = new DateTimePicker();
            base.SuspendLayout();
            this.Dtp_Time.CustomFormat = "HH:mm:ss";
            this.Dtp_Time.Format = DateTimePickerFormat.Custom;
            this.Dtp_Time.Location = new Point(0x55, 2);
            this.Dtp_Time.Name = "Dtp_Time";
            this.Dtp_Time.ShowUpDown = true;
            this.Dtp_Time.Size = new Size(0x48, 0x15);
            this.Dtp_Time.TabIndex = 0x2b;
            this.Dtp_Time.Value = new DateTime(0x7d8, 12, 9, 0, 0, 0, 0);
            this.Dtp_Time.ValueChanged += new System.EventHandler(this.Dtp_Time_ValueChanged);
            this.Dtp_Date.CustomFormat = "yyyy-MM-dd";
            this.Dtp_Date.Format = DateTimePickerFormat.Custom;
            this.Dtp_Date.Location = new Point(0, 2);
            this.Dtp_Date.Name = "Dtp_Date";
            this.Dtp_Date.Size = new Size(0x55, 0x15);
            this.Dtp_Date.TabIndex = 0x2a;
            this.Dtp_Date.ValueChanged += new System.EventHandler(this.Dtp_Date_ValueChanged);
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.Controls.Add(this.Dtp_Time);
            base.Controls.Add(this.Dtp_Date);
            base.Name = "Uc_Datetime";
            base.Size = new Size(0x9e, 0x18);
            base.ResumeLayout(false);
        }

        public DateTime Value
        {
            get
            {
                string arg_36_0 = this.Dtp_Date.Value.ToString("yyyy-MM-dd");
                string arg_36_1 = " ";
                DateTime value = this.Dtp_Time.Value;
                return Convert.ToDateTime(arg_36_0 + arg_36_1 + value.ToString("HH:mm:ss"));
            }
            set
            {
                this.Dtp_Date.Value = Convert.ToDateTime(value);
                this.Dtp_Time.Value = Convert.ToDateTime(value);
            }
        }
    }
}
