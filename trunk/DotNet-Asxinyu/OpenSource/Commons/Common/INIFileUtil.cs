namespace WHC.OrderWater.Commons
{
    using System;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Text;

    public class INIFileUtil
    {
        public string path;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public INIFileUtil(string INIPath)
        {
            this.path = INIPath;
        }

        [DllImport("kernel32", EntryPoint="GetPrivateProfileString")]
        private static extern int 408MSTia8(string, string, string, byte[], int, string);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearAllSection()
        {
            this.IniWriteValue(null, null, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearSection(string Section)
        {
            this.IniWriteValue(Section, null, null);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string IniReadValue(string Section, string Key)
        {
            StringBuilder builder = new StringBuilder(0xff);
            int num = XPOfx7u7N(Section, Key, "", builder, 0xff, this.path);
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] IniReadValues(string section, string key)
        {
            byte[] buffer = new byte[0xff];
            int num = 408MSTia8(section, key, "", buffer, 0xff, this.path);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void IniWriteValue(string Section, string Key, string Value)
        {
            mUvqAX6rk(Section, Key, Value, this.path);
        }

        [DllImport("kernel32", EntryPoint="WritePrivateProfileString")]
        private static extern long mUvqAX6rk(string, string, string, string);
        [DllImport("kernel32", EntryPoint="GetPrivateProfileString")]
        private static extern int XPOfx7u7N(string, string, string, StringBuilder, int, string);
    }
}

