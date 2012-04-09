namespace WHC.OrderWater.Commons
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public sealed class FormAnimator : IDisposable
    {
        private int 9vUWP8ynB;
        private const int fcNUBE6Y4 = 0x20000;
        private const int jSdinGKD3 = 0x10000;
        private System.Windows.Forms.Form T4DKb6wAk;
        private AnimationDirection WgtPdL4t3;
        private AnimationMethod YFqw2yc0N;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FormAnimator(System.Windows.Forms.Form form)
        {
            this.T4DKb6wAk = form;
            this.T4DKb6wAk.Load += new EventHandler(this.mi5qIK3te);
            this.T4DKb6wAk.VisibleChanged += new EventHandler(this.lWvfFeZUE);
            this.T4DKb6wAk.Closing += new CancelEventHandler(this.OBHMaLtRG);
            this.9vUWP8ynB = 250;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FormAnimator(System.Windows.Forms.Form form, AnimationMethod method, int duration) : this(form)
        {
            this.YFqw2yc0N = method;
            this.9vUWP8ynB = duration;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FormAnimator(System.Windows.Forms.Form form, AnimationMethod method, AnimationDirection direction, int duration) : this(form, method, duration)
        {
            this.WgtPdL4t3 = direction;
        }

        [DllImport("user32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            this.T4DKb6wAk.Load -= new EventHandler(this.mi5qIK3te);
            this.T4DKb6wAk.VisibleChanged -= new EventHandler(this.lWvfFeZUE);
            this.T4DKb6wAk.Closing -= new CancelEventHandler(this.OBHMaLtRG);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        ~FormAnimator()
        {
            this.T4DKb6wAk = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lWvfFeZUE(object, EventArgs)
        {
            if (this.T4DKb6wAk.MdiParent == null)
            {
                int dwFlags = (int) (this.YFqw2yc0N | ((AnimationMethod) ((int) this.WgtPdL4t3)));
                if (this.T4DKb6wAk.Visible)
                {
                    dwFlags |= 0x20000;
                }
                else
                {
                    dwFlags |= 0x10000;
                }
                AnimateWindow(this.T4DKb6wAk.Handle, this.9vUWP8ynB, dwFlags);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mi5qIK3te(object, EventArgs)
        {
            if ((this.T4DKb6wAk.MdiParent == null) || (this.YFqw2yc0N != AnimationMethod.Blend))
            {
                AnimateWindow(this.T4DKb6wAk.Handle, this.9vUWP8ynB, (int) ((((AnimationMethod) 0x20000) | this.YFqw2yc0N) | ((AnimationMethod) ((int) this.WgtPdL4t3))));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OBHMaLtRG(object, CancelEventArgs args1)
        {
            if (!args1.Cancel && ((this.T4DKb6wAk.MdiParent == null) || (this.YFqw2yc0N != AnimationMethod.Blend)))
            {
                AnimateWindow(this.T4DKb6wAk.Handle, this.9vUWP8ynB, (int) ((((AnimationMethod) 0x10000) | this.YFqw2yc0N) | ((AnimationMethod) 4)));
            }
        }

        [Description("Gets or sets the direction in which the animation is performed.")]
        public AnimationDirection Direction
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.WgtPdL4t3;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.WgtPdL4t3 = value;
            }
        }

        [Description("Gets or sets the number of milliseconds over which the animation is played.")]
        public int Duration
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.9vUWP8ynB;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.9vUWP8ynB = value;
            }
        }

        [Description("Gets the form to be animated.")]
        public System.Windows.Forms.Form Form
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.T4DKb6wAk;
            }
        }

        [Description("Gets or sets the animation method used to show and hide the form.")]
        public AnimationMethod Method
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.YFqw2yc0N;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                this.YFqw2yc0N = value;
            }
        }

        [Flags]
        public enum AnimationDirection
        {
            [Description("From top to bottom.")]
            Down = 4,
            [Description("From right to left.")]
            Left = 2,
            [Description("From left to right.")]
            Right = 1,
            [Description("From bottom to top.")]
            Up = 8
        }

        public enum AnimationMethod
        {
            [Description("Fades from transaprent to opaque when showing and from opaque to transparent when hiding.")]
            Blend = 0x80000,
            [Description("Expands out from centre when showing and collapses into centre when hiding.")]
            Centre = 0x10,
            [Description("Default animation method. Rolls out from edge when showing and into edge when hiding. Requires a direction.")]
            Roll = 0,
            [Description("Slides out from edge when showing and slides into edge when hiding. Requires a direction.")]
            Slide = 0x40000
        }
    }
}

