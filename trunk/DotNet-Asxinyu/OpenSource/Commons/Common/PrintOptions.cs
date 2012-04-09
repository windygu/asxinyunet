namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class PrintOptions : Form
    {
        internal CheckedListBox 9bP2Oyj5m;
        internal Label 9vUWP8ynB;
        protected Button btnCancel;
        protected Button btnOK;
        private IContainer fcNUBE6Y4;
        internal TextBox Fu3HlvBwR;
        internal GroupBox PD3B8iBEN;
        internal RadioButton T4DKb6wAk;
        internal Label UgFA6EwT8;
        internal CheckBox WgtPdL4t3;
        internal RadioButton YFqw2yc0N;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public PrintOptions()
        {
            this.fcNUBE6Y4 = null;
            this.jSdinGKD3();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public PrintOptions(List<string> availableFields)
        {
            this.fcNUBE6Y4 = null;
            this.jSdinGKD3();
            foreach (string str in availableFields)
            {
                this.9bP2Oyj5m.Items.Add(str, true);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.fcNUBE6Y4 != null))
            {
                this.fcNUBE6Y4.Dispose();
            }
            base.Dispose(disposing);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public List<string> GetSelectedColumns()
        {
            List<string> list = new List<string>();
            foreach (object obj2 in this.9bP2Oyj5m.CheckedItems)
            {
                list.Add(obj2.ToString());
            }
            return list;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void jSdinGKD3()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(PrintOptions));
            this.T4DKb6wAk = new RadioButton();
            this.YFqw2yc0N = new RadioButton();
            this.WgtPdL4t3 = new CheckBox();
            this.9vUWP8ynB = new Label();
            this.Fu3HlvBwR = new TextBox();
            this.PD3B8iBEN = new GroupBox();
            this.UgFA6EwT8 = new Label();
            this.btnOK = new Button();
            this.btnCancel = new Button();
            this.9bP2Oyj5m = new CheckedListBox();
            this.PD3B8iBEN.SuspendLayout();
            base.SuspendLayout();
            this.T4DKb6wAk.AutoSize = true;
            this.T4DKb6wAk.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x690c), 9f);
            this.T4DKb6wAk.Location = new Point(0x5b, 0x12);
            this.T4DKb6wAk.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6916);
            this.T4DKb6wAk.Size = new Size(0x3b, 0x10);
            this.T4DKb6wAk.TabIndex = 1;
            this.T4DKb6wAk.TabStop = true;
            this.T4DKb6wAk.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6938);
            this.T4DKb6wAk.UseVisualStyleBackColor = true;
            this.YFqw2yc0N.AutoSize = true;
            this.YFqw2yc0N.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6942), 9f);
            this.YFqw2yc0N.Location = new Point(9, 0x12);
            this.YFqw2yc0N.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x694c);
            this.YFqw2yc0N.Size = new Size(0x3b, 0x10);
            this.YFqw2yc0N.TabIndex = 0;
            this.YFqw2yc0N.TabStop = true;
            this.YFqw2yc0N.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6964);
            this.YFqw2yc0N.UseVisualStyleBackColor = true;
            this.WgtPdL4t3.AutoSize = true;
            this.WgtPdL4t3.CheckAlign = ContentAlignment.MiddleRight;
            this.WgtPdL4t3.FlatStyle = FlatStyle.System;
            this.WgtPdL4t3.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x696e), 9f);
            this.WgtPdL4t3.Location = new Point(0xbb, 0x48);
            this.WgtPdL4t3.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6978);
            this.WgtPdL4t3.Size = new Size(0x66, 0x11);
            this.WgtPdL4t3.TabIndex = 0x15;
            this.WgtPdL4t3.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x699e);
            this.WgtPdL4t3.UseVisualStyleBackColor = true;
            this.9vUWP8ynB.AutoSize = true;
            this.9vUWP8ynB.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x69ae), 9f);
            this.9vUWP8ynB.Location = new Point(0xb8, 0x63);
            this.9vUWP8ynB.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x69b8);
            this.9vUWP8ynB.Size = new Size(0x35, 12);
            this.9vUWP8ynB.TabIndex = 20;
            this.9vUWP8ynB.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x69cc);
            this.Fu3HlvBwR.AcceptsReturn = true;
            this.Fu3HlvBwR.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x69d8), 9f);
            this.Fu3HlvBwR.Location = new Point(0xb8, 0x72);
            this.Fu3HlvBwR.Multiline = true;
            this.Fu3HlvBwR.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x69e2);
            this.Fu3HlvBwR.ScrollBars = ScrollBars.Vertical;
            this.Fu3HlvBwR.Size = new Size(0xb0, 0x47);
            this.Fu3HlvBwR.TabIndex = 0x13;
            this.PD3B8iBEN.Controls.Add(this.T4DKb6wAk);
            this.PD3B8iBEN.Controls.Add(this.YFqw2yc0N);
            this.PD3B8iBEN.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x69f6), 9f);
            this.PD3B8iBEN.Location = new Point(0xb8, 20);
            this.PD3B8iBEN.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a00);
            this.PD3B8iBEN.Size = new Size(0xad, 0x27);
            this.PD3B8iBEN.TabIndex = 0x12;
            this.PD3B8iBEN.TabStop = false;
            this.PD3B8iBEN.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a22);
            this.UgFA6EwT8.AutoSize = true;
            this.UgFA6EwT8.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a2e), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.UgFA6EwT8.Location = new Point(8, 8);
            this.UgFA6EwT8.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a38);
            this.UgFA6EwT8.Size = new Size(0x41, 12);
            this.UgFA6EwT8.TabIndex = 0x11;
            this.UgFA6EwT8.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a5e);
            this.btnOK.BackColor = SystemColors.Control;
            this.btnOK.Cursor = Cursors.Default;
            this.btnOK.FlatStyle = FlatStyle.System;
            this.btnOK.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a6c), 9f);
            this.btnOK.ForeColor = SystemColors.ControlText;
            this.btnOK.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a76));
            this.btnOK.ImageAlign = ContentAlignment.MiddleRight;
            this.btnOK.Location = new Point(0xe1, 0xe7);
            this.btnOK.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a90);
            this.btnOK.RightToLeft = RightToLeft.No;
            this.btnOK.Size = new Size(0x3f, 0x17);
            this.btnOK.TabIndex = 14;
            this.btnOK.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6a9e);
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new EventHandler(this.lWvfFeZUE);
            this.btnCancel.BackColor = SystemColors.Control;
            this.btnCancel.Cursor = Cursors.Default;
            this.btnCancel.DialogResult = DialogResult.Cancel;
            this.btnCancel.FlatStyle = FlatStyle.System;
            this.btnCancel.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6aae), 9f);
            this.btnCancel.ForeColor = SystemColors.ControlText;
            this.btnCancel.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6ab8));
            this.btnCancel.Location = new Point(0x129, 0xe7);
            this.btnCancel.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6ada);
            this.btnCancel.RightToLeft = RightToLeft.No;
            this.btnCancel.Size = new Size(0x3f, 0x17);
            this.btnCancel.TabIndex = 15;
            this.btnCancel.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6af0);
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new EventHandler(this.OBHMaLtRG);
            this.9bP2Oyj5m.CheckOnClick = true;
            this.9bP2Oyj5m.Font = new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b00), 9f, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.9bP2Oyj5m.FormattingEnabled = true;
            this.9bP2Oyj5m.Location = new Point(8, 0x1a);
            this.9bP2Oyj5m.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b0a);
            this.9bP2Oyj5m.Size = new Size(170, 0xe4);
            this.9bP2Oyj5m.TabIndex = 13;
            base.AutoScaleDimensions = new SizeF(6f, 12f);
            base.AutoScaleMode = AutoScaleMode.Font;
            base.ClientSize = new Size(0x171, 0x10b);
            base.Controls.Add(this.WgtPdL4t3);
            base.Controls.Add(this.9vUWP8ynB);
            base.Controls.Add(this.Fu3HlvBwR);
            base.Controls.Add(this.PD3B8iBEN);
            base.Controls.Add(this.UgFA6EwT8);
            base.Controls.Add(this.btnOK);
            base.Controls.Add(this.btnCancel);
            base.Controls.Add(this.9bP2Oyj5m);
            base.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            base.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b1a);
            base.SizeGripStyle = SizeGripStyle.Show;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x6b36);
            base.Load += new EventHandler(this.mi5qIK3te);
            this.PD3B8iBEN.ResumeLayout(false);
            this.PD3B8iBEN.PerformLayout();
            base.ResumeLayout(false);
            base.PerformLayout();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lWvfFeZUE(object, EventArgs)
        {
            base.DialogResult = DialogResult.OK;
            base.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mi5qIK3te(object, EventArgs)
        {
            this.YFqw2yc0N.Checked = true;
            this.WgtPdL4t3.Checked = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OBHMaLtRG(object, EventArgs)
        {
            base.DialogResult = DialogResult.Cancel;
            base.Close();
        }

        public bool FitToPageWidth
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.WgtPdL4t3.Checked;
            }
        }

        public bool PrintAllRows
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.YFqw2yc0N.Checked;
            }
        }

        public string PrintTitle
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.Fu3HlvBwR.Text;
            }
        }
    }
}

