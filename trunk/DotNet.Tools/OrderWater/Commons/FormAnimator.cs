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
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FormAnimator(System.Windows.Forms.Form form, AnimationMethod method, int duration)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public FormAnimator(System.Windows.Forms.Form form, AnimationMethod method, AnimationDirection direction, int duration)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("user32", CharSet=CharSet.Auto, SetLastError=true, ExactSpelling=true)]
        public static extern bool AnimateWindow(IntPtr hWnd, int dwTime, int dwFlags);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Dispose()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected override void Finalize()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void lWvfFeZUE(object, EventArgs)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void mi5qIK3te(object, EventArgs)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private void OBHMaLtRG(object, CancelEventArgs args1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [Description("Gets or sets the direction in which the animation is performed.")]
        public AnimationDirection Direction
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [Description("Gets or sets the number of milliseconds over which the animation is played.")]
        public int Duration
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [Description("Gets the form to be animated.")]
        public System.Windows.Forms.Form Form
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
        }

        [Description("Gets or sets the animation method used to show and hide the form.")]
        public AnimationMethod Method
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                // Translated Error! Expression stack is empty at offset 0006.
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                // Translated Error! Expression stack is empty at offset 0006.
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
