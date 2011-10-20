namespace Utils
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;
    using System.Web;

    /// <summary><para>　</para>
    /// 类名：常用工具类——加密解密类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：20010-01-04</para><para>--------------------------------------------------------------</para><para>　StringEncode：返回 HTML 字符串的编码结果</para><para>　StringDecode：返回 HTML 字符串的解码结果</para><para>　UrlEncode：返回 URL 字符串的编码结果</para><para>　UrlDecode：返回 URL 字符串的解码结果</para><para>　DESEncrypt：DES加密</para><para>　DESDecrypt：DES解密</para><para>　MD5：MD5函数</para><para>　SHA256：SHA256函数</para></summary>
    public class EncyptHelper
    {
        /// <summary>32位Key值：</summary>
        public static byte[] DESKey = new byte[] { 
            3, 11, 0x13, 0x1b, 0x23, 0x2b, 0x33, 0x3b, 0x43, 0x4b, 0x9b, 0x93, 0x8b, 0x83, 0x7b, 0x73, 
            0x6b, 0x63, 0x5b, 0x53, 0xf3, 0xfb, 0xa3, 0xab, 0xb3, 0xbb, 0xc3, 0xeb, 0xe3, 0xdb, 0xd3, 0xcb
         };

        /// <summary>DES解密</summary>
        /// <param name="strSource">待解密的字串</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string strSource) { return DESDecrypt(strSource, DESKey); }

        /// <summary>DES解密</summary>
        /// <param name="strSource">待解密的字串</param>
        /// <param name="key">32位Key值</param>
        /// <returns>解密后的字符串</returns>
        public static string DESDecrypt(string strSource, byte[] key)
        {
            CryptoStream stream2;
            StreamReader reader;
            SymmetricAlgorithm algorithm = Rijndael.Create();
        Label_0033:
            if (4 != 0)
            {
                algorithm.Key = key;
                algorithm.Mode = CipherMode.ECB;
                algorithm.Padding = PaddingMode.Zeros;
            }
            ICryptoTransform transform = algorithm.CreateDecryptor();
            if (3 != 0)
            {
                MemoryStream stream = new MemoryStream(Convert.FromBase64String(strSource));
                stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
                if (0 != 0) goto Label_0033;
            }
            if (0 == 0) reader = new StreamReader(stream2, Encoding.Unicode);
            return reader.ReadToEnd();
        }

        /// <summary>DES加密</summary>
        /// <param name="strSource">待加密字串</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string strSource) { return DESEncrypt(strSource, DESKey); }

        /// <summary>DES加密</summary>
        /// <param name="strSource">待加密字串</param>
        /// <param name="key">Key值</param>
        /// <returns>加密后的字符串</returns>
        public static string DESEncrypt(string strSource, byte[] key)
        {
            MemoryStream stream;
            CryptoStream stream2;
            SymmetricAlgorithm algorithm = Rijndael.Create();
            if (0 == 0)
            {
                algorithm.Key = key;
                algorithm.Mode = CipherMode.ECB;
            }
            if (-2147483648 != 0)
            {
                algorithm.Padding = PaddingMode.Zeros;
                stream = new MemoryStream();
                stream2 = new CryptoStream(stream, algorithm.CreateEncryptor(), CryptoStreamMode.Write);
            }
            byte[] bytes = Encoding.Unicode.GetBytes(strSource);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            stream2.Close();
            return Convert.ToBase64String(stream.ToArray());
        }

        /// <summary>MD5函数,需引用：using System.Security.Cryptography;</summary>
        /// <param name="str">原始字符串</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str)
        {
            byte[] bytes = Encoding.Default.GetBytes(str);
        Label_0055:
            bytes = new MD5CryptoServiceProvider().ComputeHash(bytes);
            string str2 = "";
            int index = 0;
            while (index < bytes.Length)
            {
                str2 = str2 + bytes[index].ToString("x").PadLeft(2, '0');
                index++;
                if (0 != 0) goto Label_0055;
            }
            if ((((uint) index) | 0x80000000) != 0) return str2;
            goto Label_0055;
        }

        /// <summary>MD5函数,需引用：using System.Security.Cryptography;</summary>
        /// <param name="str">原始字符串</param>
        /// <param name="ToUper">是否将结果转为大写</param>
        /// <returns>MD5结果</returns>
        public static string MD5(string str, bool ToUper)
        {
            string str2 = MD5(str);
            if (ToUper) str2 = str2.ToUpper();
            return str2;
        }

        /// <summary>SHA256函数</summary>
        /// ///
        /// <param name="str">原始字符串</param>
        /// <returns>SHA256结果</returns>
        public static string SHA256(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }

        /// <summary>返回 HTML 字符串的解码结果</summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string StringDecode(string str) { return HttpUtility.HtmlDecode(str); }

        /// <summary>返回 HTML 字符串的编码结果</summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string StringEncode(string str) { return HttpUtility.HtmlEncode(str); }

        /// <summary>返回 URL 字符串的解码结果</summary>
        /// <param name="str">字符串</param>
        /// <returns>解码结果</returns>
        public static string UrlDecode(string str) { return HttpUtility.UrlDecode(str); }

        /// <summary>返回 URL 字符串的编码结果</summary>
        /// <param name="str">字符串</param>
        /// <returns>编码结果</returns>
        public static string UrlEncode(string str) { return HttpUtility.UrlEncode(str); }
    }
}
