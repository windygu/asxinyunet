namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class MP3Helper
    {
        [DllImport("winmm.dll", EntryPoint="mciSendString")]
        private static extern long 01FqmBarm(string, StringBuilder, int, IntPtr);
        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(byte[] buffer1, string text1)
        {
            if (!File.Exists(text1))
            {
                FileStream output = new FileStream(text1, FileMode.OpenOrCreate);
                BinaryWriter writer = new BinaryWriter(output);
                foreach (byte num in buffer1)
                {
                    writer.Write(num);
                }
                writer.Close();
                output.Close();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Pause()
        {
            01FqmBarm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9550), null, 0, IntPtr.Zero);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(string MP3_FileName, bool Repeat)
        {
            01FqmBarm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9410) + MP3_FileName + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9420), null, 0, IntPtr.Zero);
            01FqmBarm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9464) + (Repeat ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9484) : string.Empty), null, 0, IntPtr.Zero);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(byte[] MP3_EmbeddedResource, bool Repeat)
        {
            dT3f0t4t3(MP3_EmbeddedResource, Path.GetTempPath() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9496));
            01FqmBarm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x94b2) + Path.GetTempPath() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x94c2), null, 0, IntPtr.Zero);
            01FqmBarm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x951e) + (Repeat ? kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x953e) : string.Empty), null, 0, IntPtr.Zero);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Stop()
        {
            01FqmBarm(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9570), null, 0, IntPtr.Zero);
        }
    }
}

