namespace WHC.OrderWater.Commons
{
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class NotifyIconHelper
    {
        [CompilerGenerated]
        private string 9vUWP8ynB;
        private bool fcNUBE6Y4 = false;
        [CompilerGenerated]
        private Icon Fu3HlvBwR;
        private Timer jSdinGKD3;
        private Status lWvfFeZUE;
        private NotifyIcon OBHMaLtRG;
        [CompilerGenerated]
        private Icon PD3B8iBEN;
        [CompilerGenerated]
        private Icon T4DKb6wAk;
        [CompilerGenerated]
        private string WgtPdL4t3;
        [CompilerGenerated]
        private Icon YFqw2yc0N;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public NotifyIconHelper(NotifyIcon notifyIcon)
        {
            this.OBHMaLtRG = notifyIcon;
            this.NotifyStatus = Status.Offline;
            this.jSdinGKD3 = new Timer();
            this.jSdinGKD3.Interval = 500;
            this.jSdinGKD3.Tick += new EventHandler(this.mi5qIK3te);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mi5qIK3te(object, EventArgs)
        {
            this.OBHMaLtRG.Icon = this.fcNUBE6Y4 ? this.Icon_Shrink1 : this.Icon_Shrink2;
            this.fcNUBE6Y4 = !this.fcNUBE6Y4;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Refresh()
        {
            switch (this.lWvfFeZUE)
            {
                case Status.Offline:
                    this.OBHMaLtRG.Icon = this.Icon_UnConntect;
                    this.OBHMaLtRG.Text = this.Text_UnConntect;
                    break;

                case Status.Online:
                    this.OBHMaLtRG.Icon = this.Icon_Conntected;
                    this.OBHMaLtRG.Text = this.Text_Conntected;
                    break;

                case Status.TwinkleNotice:
                    this.jSdinGKD3.Start();
                    break;
            }
        }

        public Icon Icon_Conntected
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.YFqw2yc0N;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.YFqw2yc0N = value;
            }
        }

        public Icon Icon_Shrink1
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.Fu3HlvBwR;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.Fu3HlvBwR = value;
            }
        }

        public Icon Icon_Shrink2
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.PD3B8iBEN;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.PD3B8iBEN = value;
            }
        }

        public Icon Icon_UnConntect
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.T4DKb6wAk;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.T4DKb6wAk = value;
            }
        }

        public Status NotifyStatus
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.lWvfFeZUE;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (value != this.lWvfFeZUE)
                {
                    if ((this.lWvfFeZUE == Status.TwinkleNotice) && (this.jSdinGKD3 != null))
                    {
                        this.jSdinGKD3.Stop();
                    }
                    this.lWvfFeZUE = value;
                    this.Refresh();
                }
            }
        }

        public string Text_Conntected
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.9vUWP8ynB;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.9vUWP8ynB = value;
            }
        }

        public string Text_UnConntect
        {
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            get
            {
                return this.WgtPdL4t3;
            }
            [MethodImpl(MethodImplOptions.NoInlining), CompilerGenerated]
            set
            {
                this.WgtPdL4t3 = value;
            }
        }

        public enum Status
        {
            Offline,
            Online,
            TwinkleNotice
        }
    }
}

