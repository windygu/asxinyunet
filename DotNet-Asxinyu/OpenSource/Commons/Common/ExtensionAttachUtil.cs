namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Runtime.CompilerServices;

    public class ExtensionAttachUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DelReg(string p_FileTypeName)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("", true);
            RegistryKey key2 = key.OpenSubKey(p_FileTypeName);
            if (key2 != null)
            {
                key.DeleteSubKey(p_FileTypeName, true);
            }
            if (key2 != null)
            {
                key.DeleteSubKeyTree(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x59a4));
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SaveReg(string _FilePathString, string p_FileTypeName)
        {
            RegistryKey key = Registry.ClassesRoot.OpenSubKey("", true);
            if (key.OpenSubKey(p_FileTypeName, true) != null)
            {
                key.DeleteSubKey(p_FileTypeName, true);
            }
            key.CreateSubKey(p_FileTypeName);
            key.OpenSubKey(p_FileTypeName, true).SetValue("", kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x58fa));
            if (key.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5906), true) != null)
            {
                key.DeleteSubKeyTree(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5912));
            }
            key.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x591e));
            RegistryKey key2 = key.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x592a), true);
            key2.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5936));
            key2 = key2.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5944), true);
            key2.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5952));
            key2 = key2.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x595e), true);
            key2.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x596a));
            key2 = key2.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x597c), true);
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x598e) + _FilePathString + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5994);
            key2.SetValue("", str);
        }
    }
}

