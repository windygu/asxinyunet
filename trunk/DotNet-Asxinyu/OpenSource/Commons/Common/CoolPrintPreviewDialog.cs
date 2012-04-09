namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using dJC3anml0JxG27UjuF;
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;
    using vwdVswgYbtyE9UtZmP;

    public class CoolPrintPreviewDialog : Form
    {
        private ToolStripMenuItem 1EmGNW454;
        private ToolStripButton 1LIZtmuRJ;
        private ToolStripMenuItem 5TaRYAovg;
        private ToolStripButton 67IgbDtO7;
        private ToolStripMenuItem 6HHSiFx59;
        private ToolStripButton 87poTGRRI;
        private ToolStripMenuItem 97C7gHPPA;
        private ToolStripTextBox 9JBQHJiHP;
        private ToolStripMenuItem 9res8C5Df;
        private ToolStripMenuItem EZiD0BjjQ;
        private ToolStripMenuItem GH5kkB6XY;
        private ToolStripSeparator hHNOJIcoR;
        private ToolStripSeparator hQx5wFFip;
        private ToolStripButton IQOmGIxnI;
        private ToolStripButton IWgvQINni;
        private ToolStrip JCWn4nf54;
        private ToolStripLabel JL6cXVyVA;
        private ToolStripMenuItem JZXxXYYll;
        private IContainer kfCNb6LIy;
        private ToolStripButton lkSt99lM0;
        private ToolStripButton lqY3lfivA;
        private ToolStripSeparator psTpIalUM;
        private ToolStripMenuItem PTQ4LyDDt;
        private ToolStripSplitButton rkMVDxlFt;
        private ToolStripMenuItem UoZaUywPy;
        private ToolStripMenuItem v7n6mB6XI;
        private ToolStripMenuItem VlkhWVfH7;
        private PrintDocument WisrNfbCq;
        private hCFnrCVW6BPDw75Evd y3v08EJnu;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public CoolPrintPreviewDialog() : this(null)
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public CoolPrintPreviewDialog(Control parentForm)
        {
            this.kfCNb6LIy = null;
            this.voVjcfCWT();
            if (parentForm != null)
            {
                base.Size = parentForm.Size;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 9bP2Oyj5m(object, EventArgs)
        {
            this.9JBQHJiHP.Text = (this.y3v08EJnu.nKXrMp1lA() + 1).ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void 9vUWP8ynB(object, EventArgs)
        {
            this.9JBQHJiHP.SelectAll();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void AKae6LN2M(object, EventArgs)
        {
            base.Update();
            Application.DoEvents();
            this.JL6cXVyVA.Text = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7680), this.y3v08EJnu.1DE4NO3vw());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.kfCNb6LIy != null))
            {
                this.kfCNb6LIy.Dispose();
            }
            base.Dispose(disposing);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void fcNUBE6Y4(object, EventArgs)
        {
            this.y3v08EJnu.KJiaI9woE(0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void Fu3HlvBwR(object, CancelEventArgs)
        {
            this.UgFA6EwT8();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void jSdinGKD3(object, ToolStripItemClickedEventArgs args1)
        {
            if (args1.ClickedItem == this.5TaRYAovg)
            {
                this.y3v08EJnu.oMRxB4ibY((rUkYjs4cwm2FeA1dtX) 0);
            }
            else if (args1.ClickedItem == this.97C7gHPPA)
            {
                this.y3v08EJnu.oMRxB4ibY((rUkYjs4cwm2FeA1dtX) 1);
            }
            else if (args1.ClickedItem == this.9res8C5Df)
            {
                this.y3v08EJnu.oMRxB4ibY((rUkYjs4cwm2FeA1dtX) 2);
            }
            else if (args1.ClickedItem == this.1EmGNW454)
            {
                this.y3v08EJnu.oMRxB4ibY((rUkYjs4cwm2FeA1dtX) 3);
            }
            if (args1.ClickedItem == this.GH5kkB6XY)
            {
                this.y3v08EJnu.xCn6a9dnk(0.1);
            }
            else if (args1.ClickedItem == this.VlkhWVfH7)
            {
                this.y3v08EJnu.xCn6a9dnk(1.0);
            }
            else if (args1.ClickedItem == this.EZiD0BjjQ)
            {
                this.y3v08EJnu.xCn6a9dnk(1.5);
            }
            else if (args1.ClickedItem == this.v7n6mB6XI)
            {
                this.y3v08EJnu.xCn6a9dnk(2.0);
            }
            else if (args1.ClickedItem == this.6HHSiFx59)
            {
                this.y3v08EJnu.xCn6a9dnk(0.25);
            }
            else if (args1.ClickedItem == this.UoZaUywPy)
            {
                this.y3v08EJnu.xCn6a9dnk(0.5);
            }
            else if (args1.ClickedItem == this.JZXxXYYll)
            {
                this.y3v08EJnu.xCn6a9dnk(5.0);
            }
            else if (args1.ClickedItem == this.PTQ4LyDDt)
            {
                this.y3v08EJnu.xCn6a9dnk(0.75);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lWvfFeZUE(object, EventArgs)
        {
            using (PageSetupDialog dialog = new PageSetupDialog())
            {
                dialog.Document = this.Document;
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.y3v08EJnu.t00qRSolC();
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void MhlXt0Q8q(object, PrintEventArgs)
        {
            this.87poTGRRI.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x769e);
            this.1LIZtmuRJ.Enabled = this.IQOmGIxnI.Enabled = true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mi5qIK3te(object, EventArgs)
        {
            using (PrintDialog dialog = new PrintDialog())
            {
                dialog.AllowSomePages = true;
                dialog.AllowSelection = true;
                dialog.UseEXDialog = true;
                dialog.Document = this.Document;
                PrinterSettings printerSettings = dialog.PrinterSettings;
                printerSettings.MinimumPage = printerSettings.FromPage = 1;
                printerSettings.MaximumPage = printerSettings.ToPage = this.y3v08EJnu.1DE4NO3vw();
                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    this.y3v08EJnu.lPRM4Nury();
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OBHMaLtRG(object, EventArgs)
        {
            this.y3v08EJnu.oMRxB4ibY((this.y3v08EJnu.Kf2oXqL4k() == ((rUkYjs4cwm2FeA1dtX) 0)) ? ((rUkYjs4cwm2FeA1dtX) 1) : ((rUkYjs4cwm2FeA1dtX) 0));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!(!this.y3v08EJnu.ERklKEq5q() || e.Cancel))
            {
                this.y3v08EJnu.QM3fY09LE();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            this.y3v08EJnu.6ifRb4FX6(this.Document);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void PD3B8iBEN(object, KeyPressEventArgs args1)
        {
            char keyChar = args1.KeyChar;
            if (keyChar == '\r')
            {
                this.UgFA6EwT8();
                args1.Handled = true;
            }
            else if (!((keyChar <= ' ') || char.IsDigit(keyChar)))
            {
                args1.Handled = true;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void pXI80WIXh(object, PrintEventArgs)
        {
            this.87poTGRRI.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x768e);
            this.1LIZtmuRJ.Enabled = this.IQOmGIxnI.Enabled = false;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void T4DKb6wAk(object, EventArgs)
        {
            this.y3v08EJnu.KJiaI9woE(this.y3v08EJnu.nKXrMp1lA() - 1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void UgFA6EwT8()
        {
            int num;
            if (int.TryParse(this.9JBQHJiHP.Text, out num))
            {
                this.y3v08EJnu.KJiaI9woE(num - 1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void voVjcfCWT()
        {
            ComponentResourceManager manager = new ComponentResourceManager(typeof(CoolPrintPreviewDialog));
            this.JCWn4nf54 = new ToolStrip();
            this.1LIZtmuRJ = new ToolStripButton();
            this.IQOmGIxnI = new ToolStripButton();
            this.hQx5wFFip = new ToolStripSeparator();
            this.rkMVDxlFt = new ToolStripSplitButton();
            this.5TaRYAovg = new ToolStripMenuItem();
            this.97C7gHPPA = new ToolStripMenuItem();
            this.9res8C5Df = new ToolStripMenuItem();
            this.1EmGNW454 = new ToolStripMenuItem();
            this.hHNOJIcoR = new ToolStripSeparator();
            this.JZXxXYYll = new ToolStripMenuItem();
            this.v7n6mB6XI = new ToolStripMenuItem();
            this.EZiD0BjjQ = new ToolStripMenuItem();
            this.VlkhWVfH7 = new ToolStripMenuItem();
            this.PTQ4LyDDt = new ToolStripMenuItem();
            this.UoZaUywPy = new ToolStripMenuItem();
            this.6HHSiFx59 = new ToolStripMenuItem();
            this.GH5kkB6XY = new ToolStripMenuItem();
            this.67IgbDtO7 = new ToolStripButton();
            this.lkSt99lM0 = new ToolStripButton();
            this.9JBQHJiHP = new ToolStripTextBox();
            this.JL6cXVyVA = new ToolStripLabel();
            this.IWgvQINni = new ToolStripButton();
            this.lqY3lfivA = new ToolStripButton();
            this.psTpIalUM = new ToolStripSeparator();
            this.87poTGRRI = new ToolStripButton();
            this.y3v08EJnu = new hCFnrCVW6BPDw75Evd();
            this.JCWn4nf54.SuspendLayout();
            base.SuspendLayout();
            this.JCWn4nf54.AutoSize = false;
            this.JCWn4nf54.GripStyle = ToolStripGripStyle.Hidden;
            this.JCWn4nf54.Items.AddRange(new ToolStripItem[] { this.1LIZtmuRJ, this.IQOmGIxnI, this.hQx5wFFip, this.rkMVDxlFt, this.67IgbDtO7, this.lkSt99lM0, this.9JBQHJiHP, this.JL6cXVyVA, this.IWgvQINni, this.lqY3lfivA, this.psTpIalUM, this.87poTGRRI });
            this.JCWn4nf54.Location = new Point(0, 0);
            this.JCWn4nf54.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x76ae);
            this.JCWn4nf54.Size = new Size(0x2ec, 30);
            this.JCWn4nf54.TabIndex = 0;
            this.JCWn4nf54.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x76c6);
            this.1LIZtmuRJ.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.1LIZtmuRJ.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x76de));
            this.1LIZtmuRJ.ImageTransparentColor = Color.Magenta;
            this.1LIZtmuRJ.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7700);
            this.1LIZtmuRJ.Size = new Size(0x17, 0x1b);
            this.1LIZtmuRJ.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7716);
            this.1LIZtmuRJ.Click += new EventHandler(this.mi5qIK3te);
            this.IQOmGIxnI.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.IQOmGIxnI.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7722));
            this.IQOmGIxnI.ImageTransparentColor = Color.Magenta;
            this.IQOmGIxnI.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x774c);
            this.IQOmGIxnI.Size = new Size(0x17, 0x1b);
            this.IQOmGIxnI.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x776a);
            this.IQOmGIxnI.Click += new EventHandler(this.lWvfFeZUE);
            this.hQx5wFFip.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7776);
            this.hQx5wFFip.Size = new Size(6, 30);
            this.rkMVDxlFt.AutoToolTip = false;
            this.rkMVDxlFt.DropDownItems.AddRange(new ToolStripItem[] { this.5TaRYAovg, this.97C7gHPPA, this.1EmGNW454, this.9res8C5Df, this.hHNOJIcoR, this.JZXxXYYll, this.v7n6mB6XI, this.EZiD0BjjQ, this.VlkhWVfH7, this.PTQ4LyDDt, this.UoZaUywPy, this.6HHSiFx59, this.GH5kkB6XY });
            this.rkMVDxlFt.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x77a0));
            this.rkMVDxlFt.ImageTransparentColor = Color.Magenta;
            this.rkMVDxlFt.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x77c0);
            this.rkMVDxlFt.Size = new Size(0x4f, 0x1b);
            this.rkMVDxlFt.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x77d4);
            this.rkMVDxlFt.ButtonClick += new EventHandler(this.OBHMaLtRG);
            this.rkMVDxlFt.DropDownItemClicked += new ToolStripItemClickedEventHandler(this.jSdinGKD3);
            this.5TaRYAovg.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x77e4));
            this.5TaRYAovg.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7812);
            this.5TaRYAovg.Size = new Size(0x76, 0x16);
            this.5TaRYAovg.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7834);
            this.97C7gHPPA.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7840));
            this.97C7gHPPA.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x786a);
            this.97C7gHPPA.Size = new Size(0x76, 0x16);
            this.97C7gHPPA.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7888);
            this.9res8C5Df.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7890));
            this.9res8C5Df.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x78bc);
            this.9res8C5Df.Size = new Size(0x76, 0x16);
            this.9res8C5Df.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x78dc);
            this.1EmGNW454.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x78e4));
            this.1EmGNW454.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x790e);
            this.1EmGNW454.Size = new Size(0x76, 0x16);
            this.1EmGNW454.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x792c);
            this.hHNOJIcoR.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7934);
            this.hHNOJIcoR.Size = new Size(0x73, 6);
            this.JZXxXYYll.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x795c);
            this.JZXxXYYll.Size = new Size(0x76, 0x16);
            this.JZXxXYYll.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7970);
            this.v7n6mB6XI.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x797c);
            this.v7n6mB6XI.Size = new Size(0x76, 0x16);
            this.v7n6mB6XI.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7990);
            this.EZiD0BjjQ.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x799c);
            this.EZiD0BjjQ.Size = new Size(0x76, 0x16);
            this.EZiD0BjjQ.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x79b0);
            this.VlkhWVfH7.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x79bc);
            this.VlkhWVfH7.Size = new Size(0x76, 0x16);
            this.VlkhWVfH7.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x79d0);
            this.PTQ4LyDDt.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x79dc);
            this.PTQ4LyDDt.Size = new Size(0x76, 0x16);
            this.PTQ4LyDDt.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x79ee);
            this.UoZaUywPy.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x79f8);
            this.UoZaUywPy.Size = new Size(0x76, 0x16);
            this.UoZaUywPy.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a0a);
            this.6HHSiFx59.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a14);
            this.6HHSiFx59.Size = new Size(0x76, 0x16);
            this.6HHSiFx59.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a26);
            this.GH5kkB6XY.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a30);
            this.GH5kkB6XY.Size = new Size(0x76, 0x16);
            this.GH5kkB6XY.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a42);
            this.67IgbDtO7.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.67IgbDtO7.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a4c));
            this.67IgbDtO7.ImageTransparentColor = Color.Red;
            this.67IgbDtO7.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a6e);
            this.67IgbDtO7.Size = new Size(0x17, 0x1b);
            this.67IgbDtO7.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a84);
            this.67IgbDtO7.Click += new EventHandler(this.fcNUBE6Y4);
            this.lkSt99lM0.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.lkSt99lM0.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7a8c));
            this.lkSt99lM0.ImageTransparentColor = Color.Red;
            this.lkSt99lM0.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7aac);
            this.lkSt99lM0.Size = new Size(0x17, 0x1b);
            this.lkSt99lM0.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7ac0);
            this.lkSt99lM0.Click += new EventHandler(this.T4DKb6wAk);
            this.9JBQHJiHP.AutoSize = false;
            this.9JBQHJiHP.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7aca);
            this.9JBQHJiHP.Size = new Size(0x20, 0x15);
            this.9JBQHJiHP.TextBoxTextAlign = HorizontalAlignment.Center;
            this.9JBQHJiHP.Validating += new CancelEventHandler(this.Fu3HlvBwR);
            this.9JBQHJiHP.Enter += new EventHandler(this.9vUWP8ynB);
            this.9JBQHJiHP.KeyPress += new KeyPressEventHandler(this.PD3B8iBEN);
            this.JL6cXVyVA.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7ae8);
            this.JL6cXVyVA.Size = new Size(11, 0x1b);
            this.JL6cXVyVA.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b06);
            this.IWgvQINni.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.IWgvQINni.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b0c));
            this.IWgvQINni.ImageTransparentColor = Color.Red;
            this.IWgvQINni.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b2c);
            this.IWgvQINni.Size = new Size(0x17, 0x1b);
            this.IWgvQINni.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b40);
            this.IWgvQINni.Click += new EventHandler(this.YFqw2yc0N);
            this.lqY3lfivA.DisplayStyle = ToolStripItemDisplayStyle.Image;
            this.lqY3lfivA.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b4a));
            this.lqY3lfivA.ImageTransparentColor = Color.Red;
            this.lqY3lfivA.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b6a);
            this.lqY3lfivA.Size = new Size(0x17, 0x1b);
            this.lqY3lfivA.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b7e);
            this.lqY3lfivA.Click += new EventHandler(this.WgtPdL4t3);
            this.psTpIalUM.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7b8a);
            this.psTpIalUM.Size = new Size(6, 30);
            this.psTpIalUM.Visible = false;
            this.87poTGRRI.AutoToolTip = false;
            this.87poTGRRI.Image = (Image) manager.GetObject(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7ba2));
            this.87poTGRRI.ImageTransparentColor = Color.Magenta;
            this.87poTGRRI.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7bc6);
            this.87poTGRRI.Size = new Size(0x31, 0x1b);
            this.87poTGRRI.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7bde);
            this.87poTGRRI.Click += new EventHandler(this.XpA9mrlCE);
            this.y3v08EJnu.AutoScroll = true;
            this.y3v08EJnu.Dock = DockStyle.Fill;
            this.y3v08EJnu.6ifRb4FX6(null);
            this.y3v08EJnu.Location = new Point(0, 30);
            this.y3v08EJnu.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7be6);
            this.y3v08EJnu.Size = new Size(0x2ec, 0x2a5);
            this.y3v08EJnu.TabIndex = 1;
            this.y3v08EJnu.W06OXZ5gB(new EventHandler(this.AKae6LN2M));
            this.y3v08EJnu.2gTSS8eLF(new EventHandler(this.9bP2Oyj5m));
            base.AutoScaleDimensions = new SizeF(96f, 96f);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.ClientSize = new Size(0x2ec, 0x2c3);
            base.Controls.Add(this.y3v08EJnu);
            base.Controls.Add(this.JCWn4nf54);
            base.Name = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7bfa);
            base.ShowIcon = false;
            base.ShowInTaskbar = false;
            base.StartPosition = FormStartPosition.CenterParent;
            this.Text = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7c2a);
            this.JCWn4nf54.ResumeLayout(false);
            this.JCWn4nf54.PerformLayout();
            base.ResumeLayout(false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void WgtPdL4t3(object, EventArgs)
        {
            this.y3v08EJnu.KJiaI9woE(this.y3v08EJnu.1DE4NO3vw() - 1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void XpA9mrlCE(object, EventArgs)
        {
            if (this.y3v08EJnu.ERklKEq5q())
            {
                this.y3v08EJnu.QM3fY09LE();
            }
            else
            {
                base.Close();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void YFqw2yc0N(object, EventArgs)
        {
            this.y3v08EJnu.KJiaI9woE(this.y3v08EJnu.nKXrMp1lA() + 1);
        }

        public PrintDocument Document
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.WisrNfbCq;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (this.WisrNfbCq != null)
                {
                    this.WisrNfbCq.BeginPrint -= new PrintEventHandler(this.pXI80WIXh);
                    this.WisrNfbCq.EndPrint -= new PrintEventHandler(this.MhlXt0Q8q);
                }
                this.WisrNfbCq = value;
                if (this.WisrNfbCq != null)
                {
                    this.WisrNfbCq.BeginPrint += new PrintEventHandler(this.pXI80WIXh);
                    this.WisrNfbCq.EndPrint += new PrintEventHandler(this.MhlXt0Q8q);
                }
                if (base.Visible)
                {
                    this.y3v08EJnu.6ifRb4FX6(this.Document);
                }
            }
        }
    }
}

