namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class MessageUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ConfirmYesNo(string prompt)
        {
            return (MessageBox.Show(prompt, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf694), MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ConfirmYesNoCancel(string prompt)
        {
            return MessageBox.Show(prompt, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf69c), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowError(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf658), MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowTips(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf640), MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowWarning(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf64c), MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowYesNoAndError(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf664), MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowYesNoAndTips(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf670), MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowYesNoAndWarning(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf67c), MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static DialogResult ShowYesNoCancelAndTips(string message)
        {
            return MessageBox.Show(message, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xf688), MessageBoxButtons.YesNoCancel, MessageBoxIcon.Asterisk);
        }
    }
}

