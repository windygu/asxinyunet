namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class FileAssociationsHelper
    {
        private static RegistryKey YFqw2yc0N;

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void fcNUBE6Y4(string text2, string text1)
        {
            try
            {
                RegistryKey key = YFqw2yc0N.CreateSubKey(Path.Combine(text1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x75ac)));
                key.DeleteValue(text2);
                key.Close();
            }
            catch (Exception exception)
            {
                Debug.WriteLine(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x75ce) + exception.Message);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void jSdinGKD3(string text2, string text1)
        {
            RegistryKey key = YFqw2yc0N.CreateSubKey(Path.Combine(text1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x758a)));
            key.SetValue(text2, string.Empty);
            key.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void lWvfFeZUE(string text1, string text2, string text3)
        {
            RegistryKey key = YFqw2yc0N.CreateSubKey(text1);
            key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7498), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x74bc));
            key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x74e4), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x74fe));
            key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7522), text1);
            key.SetValue(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7532), text2);
            RegistryKey key2 = key.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7552));
            key2.SetValue(string.Empty, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7560));
            key2 = key2.CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x756c)).CreateSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7578));
            key2.SetValue(string.Empty, text3);
            key2.Close();
            key.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void mi5qIK3te(string[] textArray1)
        {
            if (textArray1.Length < 6)
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x737e));
            }
            try
            {
                Action<string> action = null;
                PJaUSuqXo0yUTL9U3B8 yutlub = new PJaUSuqXo0yUTL9U3B8 {
                    AWbNwkBdU = textArray1[0]
                };
                bool flag = bool.Parse(textArray1[1]);
                string str2 = textArray1[2];
                string str3 = textArray1[3];
                bool flag2 = bool.Parse(textArray1[4]);
                List<string> list = new List<string>();
                for (int i = 0; i < textArray1.Length; i++)
                {
                    if (i >= 5)
                    {
                        list.Add(textArray1[i]);
                    }
                }
                string[] array = list.ToArray();
                if (flag)
                {
                    YFqw2yc0N = Registry.CurrentUser.OpenSubKey(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7474));
                }
                else
                {
                    YFqw2yc0N = Registry.ClassesRoot;
                }
                Array.ForEach<string>(array, new Action<string>(yutlub.VZJq3SjrW));
                OBHMaLtRG(yutlub.AWbNwkBdU);
                if (!flag2)
                {
                    lWvfFeZUE(yutlub.AWbNwkBdU, str2, str3);
                    if (action == null)
                    {
                        action = new Action<string>(yutlub.JkKfoMY5A);
                    }
                    Array.ForEach<string>(array, action);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                Console.ReadLine();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void OBHMaLtRG(string text1)
        {
            try
            {
                YFqw2yc0N.DeleteSubKeyTree(text1);
            }
            catch
            {
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void RegisterFileAssociations(string progId, bool registerInHKCU, string appId, string openWith, params string[] extensions)
        {
            T4DKb6wAk(false, progId, registerInHKCU, appId, openWith, extensions);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void T4DKb6wAk(bool flag2, string text1, bool flag1, string text2, string text3, string[] textArray1)
        {
            string str = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x762a), new object[] { text1, flag1, text2, text3, flag2, string.Join(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7660), textArray1) });
            try
            {
                mi5qIK3te(str.Split(new char[] { ' ' }));
            }
            catch (Win32Exception exception)
            {
                if (exception.NativeErrorCode == 0x4c7)
                {
                    LogHelper.Info(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x7666));
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void UnregisterFileAssociations(string progId, bool registerInHKCU, string appId, string openWith, params string[] extensions)
        {
            T4DKb6wAk(true, progId, registerInHKCU, appId, openWith, extensions);
        }

        [CompilerGenerated]
        private sealed class PJaUSuqXo0yUTL9U3B8
        {
            public string AWbNwkBdU;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void JkKfoMY5A(string text1)
            {
                FileAssociationsHelper.jSdinGKD3(this.AWbNwkBdU, text1);
            }

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void VZJq3SjrW(string text1)
            {
                FileAssociationsHelper.fcNUBE6Y4(this.AWbNwkBdU, text1);
            }
        }
    }
}

