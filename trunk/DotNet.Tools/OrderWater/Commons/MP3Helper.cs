namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class MP3Helper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public MP3Helper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("winmm.dll", EntryPoint="mciSendString")]
        private static extern long 01FqmBarm(string, StringBuilder, int, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(byte[] buffer1, string text1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Pause()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(string MP3_FileName, bool Repeat)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(byte[] MP3_EmbeddedResource, bool Repeat)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Stop()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }
    }
}
