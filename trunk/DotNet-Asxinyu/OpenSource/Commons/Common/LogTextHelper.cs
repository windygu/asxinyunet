namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class LogTextHelper
    {
        public static bool DebugLog = false;
        private static string mUvqAX6rk = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x982));
        public static bool RecordLog = true;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static LogTextHelper()
        {
            if (!Directory.Exists(mUvqAX6rk))
            {
                Directory.CreateDirectory(mUvqAX6rk);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLine(string message)
        {
            string contents = DateTime.Now.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x98c)) + message + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9c2);
            string str2 = DateTime.Now.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9ce)) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9e2);
            try
            {
                if (RecordLog)
                {
                    File.AppendAllText(Path.Combine(mUvqAX6rk, str2), contents, Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9ee)));
                }
                if (DebugLog)
                {
                    Console.WriteLine(contents);
                }
            }
            catch
            {
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void WriteLine(string className, string funName, string message)
        {
            WriteLine(string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x9fe), className, funName, message));
        }
    }
}

