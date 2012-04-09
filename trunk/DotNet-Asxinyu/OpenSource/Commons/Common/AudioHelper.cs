namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Media;
    using System.Runtime.CompilerServices;
    using System.Security;
    using System.Security.Permissions;

    [EditorBrowsable(EditorBrowsableState.Advanced), Browsable(false), HostProtection(SecurityAction.LinkDemand, Resources=HostProtectionResource.ExternalProcessMgmt)]
    public class AudioHelper
    {
        private static SoundPlayer eMSUYugy4;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string 3xodQsKC6(string text1)
        {
            if (string.IsNullOrEmpty(text1))
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf46));
            }
            return text1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void EPgfA8o8U(SoundPlayer player1, AudioPlayMode mode1)
        {
            if (eMSUYugy4 != null)
            {
                XxQqQ66mW(eMSUYugy4);
            }
            eMSUYugy4 = player1;
            switch (mode1)
            {
                case AudioPlayMode.WaitToComplete:
                    eMSUYugy4.PlaySync();
                    break;

                case AudioPlayMode.Background:
                    eMSUYugy4.Play();
                    break;

                case AudioPlayMode.BackgroundLoop:
                    eMSUYugy4.PlayLooping();
                    break;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void hudMECjTG(AudioPlayMode mode1, string text1)
        {
            if ((mode1 < AudioPlayMode.WaitToComplete) || (mode1 > AudioPlayMode.BackgroundLoop))
            {
                throw new InvalidEnumArgumentException(text1, (int) mode1, typeof(AudioPlayMode));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(string location)
        {
            Play(location, AudioPlayMode.Background);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(Stream stream, AudioPlayMode playMode)
        {
            hudMECjTG(playMode, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcee8));
            if (stream == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcefc));
            }
            EPgfA8o8U(new SoundPlayer(stream), playMode);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(string location, AudioPlayMode playMode)
        {
            hudMECjTG(playMode, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xced4));
            SoundPlayer player = new SoundPlayer(3xodQsKC6(location));
            EPgfA8o8U(player, playMode);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Play(byte[] data, AudioPlayMode playMode)
        {
            if (data == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf0c));
            }
            hudMECjTG(playMode, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf18));
            MemoryStream stream = new MemoryStream(data);
            Play(stream, playMode);
            stream.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void PlaySystemSound(SystemSound systemSound)
        {
            if (systemSound == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xcf2c));
            }
            systemSound.Play();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Stop()
        {
            SoundPlayer player = new SoundPlayer();
            XxQqQ66mW(player);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void XxQqQ66mW(SoundPlayer player1)
        {
            new SecurityPermission(SecurityPermissionFlag.UnmanagedCode).Assert();
            try
            {
                player1.Stop();
            }
            finally
            {
                CodeAccessPermission.RevertAssert();
            }
        }
    }
}

