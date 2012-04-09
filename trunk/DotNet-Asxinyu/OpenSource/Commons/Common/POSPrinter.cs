namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class POSPrinter
    {
        private string 408MSTia8;
        private const int XPOfx7u7N = 3;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public POSPrinter()
        {
            this.408MSTia8 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4dcc);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public POSPrinter(string prnPort)
        {
            this.408MSTia8 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4dd8);
            this.408MSTia8 = prnPort;
        }

        [DllImport("kernel32.dll", EntryPoint="CreateFile", CharSet=CharSet.Auto)]
        private static extern IntPtr mUvqAX6rk(string, int, int, int, int, int, int);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public string PrintLine(string str)
        {
            try
            {
                IntPtr handle = mUvqAX6rk(this.408MSTia8, 0x40000000, 0, 0, 3, 0, 0);
                if (handle.ToInt32() == -1)
                {
                    return kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4de4);
                }
                using (FileStream stream = new FileStream(handle, FileAccess.ReadWrite))
                {
                    using (StreamWriter writer = new StreamWriter(stream, Encoding.Default))
                    {
                        writer.WriteLine(str);
                    }
                }
                return "";
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }
    }
}

