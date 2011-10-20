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
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("kernel32", EntryPoint="GetPrivateProfileString")]
        private static extern int 408MSTia8(string, string, string, byte[], int, string);
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearAllSection()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void ClearSection(string Section)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string IniReadValue(string Section, string Key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public byte[] IniReadValues(string section, string key)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void IniWriteValue(string Section, string Key, string Value)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [DllImport("kernel32", EntryPoint="WritePrivateProfileString")]
        private static extern long mUvqAX6rk(string, string, string, string);
        [DllImport("kernel32", EntryPoint="GetPrivateProfileString")]
        private static extern int XPOfx7u7N(string, string, string, StringBuilder, int, string);
    }
}
