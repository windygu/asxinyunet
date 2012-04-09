namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;

    public class UIConstants
    {
        public static string ApplicationExpiredDate = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4d6);
        public static string IsolatedStorage = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa578);
        public static string IsolatedStorageDirectoryName = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa5c4);
        public static string IsolatedStorageEncryptKey = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa5de);
        public static string PublicKey = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa5f2);
        public static int SoftwareProbationDay = 20;
        public static string SoftwareProductName = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4f8);
        public static string SoftwareRegistryKey = (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa524) + SoftwareVersion);
        public static string SoftwareVersion = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4ee);
        public static string WebRegisterURL = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa7dc);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetValue(string expiredDate, string version, string name, string publicKey)
        {
            ApplicationExpiredDate = expiredDate;
            SoftwareVersion = version;
            SoftwareProductName = name;
            SoftwareRegistryKey = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa47e) + name + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4a8) + version;
            IsolatedStorage = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4ae) + name + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa4ca);
            PublicKey = publicKey;
        }
    }
}

