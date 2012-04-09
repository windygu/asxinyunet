namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FullscreenHelper
    {
        private FormBorderStyle Gd6gd0WLH;
        private Rectangle lPRM4Nury;
        private bool QM3fY09LE = false;
        private Form t00qRSolC = null;
        private FormWindowState WO5U9QNDF;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FullscreenHelper(Form form)
        {
            this.t00qRSolC = form;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Toggle()
        {
            this.Fullscreen = !this.Fullscreen;
        }

        public bool Fullscreen
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.QM3fY09LE;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (this.QM3fY09LE != value)
                {
                    this.QM3fY09LE = value;
                    if (this.QM3fY09LE)
                    {
                        this.lPRM4Nury = this.t00qRSolC.Bounds;
                        this.Gd6gd0WLH = this.t00qRSolC.FormBorderStyle;
                        this.WO5U9QNDF = this.t00qRSolC.WindowState;
                        if (this.t00qRSolC.MainMenuStrip != null)
                        {
                            this.t00qRSolC.MainMenuStrip.Visible = false;
                        }
                        this.t00qRSolC.FormBorderStyle = FormBorderStyle.None;
                        this.t00qRSolC.Bounds = Screen.PrimaryScreen.Bounds;
                        this.t00qRSolC.WindowState = FormWindowState.Normal;
                    }
                    else
                    {
                        this.t00qRSolC.TopMost = false;
                        this.t00qRSolC.WindowState = this.WO5U9QNDF;
                        this.t00qRSolC.Bounds = this.lPRM4Nury;
                        this.t00qRSolC.FormBorderStyle = this.Gd6gd0WLH;
                        if (this.t00qRSolC.MainMenuStrip != null)
                        {
                            this.t00qRSolC.MainMenuStrip.Visible = true;
                        }
                    }
                }
            }
        }
    }
}

