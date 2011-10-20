namespace Utils
{
    using System;
    using System.Runtime.InteropServices;
    using System.Text;

    /// <summary><para>　</para>
    /// 类名：常用工具类——INI文件读写类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>-----------------------------------------------------</para><para>　IniWriteValue：写INI文件</para><para>　IniReadValue：读取INI文件中键值为字符串的键</para><para>　IniReadValues：读取INI文件中键值为字节的键</para><para>　ClearAllSection：删除ini文件下所有段落</para><para>　ClearSection：删除指定段落下的所有键</para></summary>
    public class IniHelper
    {
        private static string xe125219852864557;

        /// <summary>构造函数</summary>
        /// <param name="INIPath"></param>
        public IniHelper(string INIPath)
        {
            xe125219852864557 = INIPath;
        }

        /// <summary>删除ini文件下所有段落</summary>
        public static void ClearAllSection() { IniWriteValue(null, null, null); }

        /// <summary>删除指定段落下的所有键</summary>
        /// <param name="Section">要删除的段落</param>
        public static void ClearSection(string Section) { IniWriteValue(Section, null, null); }

        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string defVal, byte[] retVal, int size, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);
        /// <summary>读取INI文件中键值为字符串的键</summary>
        /// <param name="Section">要读取的段落</param>
        /// <param name="Key">要读取的键</param>
        /// <returns>对应的键值</returns>
        public static string IniReadValue(string Section, string Key)
        {
            StringBuilder retVal = new StringBuilder(0xff);
            GetPrivateProfileString(Section, Key, "", retVal, 0xff, xe125219852864557);
            return retVal.ToString();
        }

        /// <summary>读取INI文件中键值为字节的键</summary>
        /// <param name="section">要读取的段落</param>
        /// <param name="key">要读取的键</param>
        /// <returns>对应的键值</returns>
        public byte[] IniReadValues(string section, string key)
        {
            byte[] retVal = new byte[0xff];
            GetPrivateProfileString(section, key, "", retVal, 0xff, xe125219852864557);
            return retVal;
        }

        /// <summary>写INI文件</summary>
        /// <param name="Section">要写入的段落</param>
        /// <param name="Key">要写入的键</param>
        /// <param name="Value">要写的的键值</param>
        public static void IniWriteValue(string Section, string Key, string Value) { WritePrivateProfileString(Section, Key, Value, xe125219852864557); }

        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
    }
}
