namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    public sealed class EncodeHelper
    {
        public const string DEFAULT_ENCRYPT_KEY = "12345678";
        private static byte[] Gd6gd0WLH = new byte[] { 0x41, 0x72, 0x65, 0x79, 0x6f, 0x75, 0x6d, 0x79, 0x53, 110, 0x6f, 0x77, 0x6d, 0x61, 110, 0x3f };
        private static readonly string lPRM4Nury = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x583c);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AES_Decrypt(string decryptString)
        {
            return AES_Decrypt(decryptString, lPRM4Nury);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AES_Decrypt(string decryptString, string decryptKey)
        {
            try
            {
                decryptKey = t00qRSolC(decryptKey, 0x20, "");
                decryptKey = decryptKey.PadRight(0x20, ' ');
                ICryptoTransform transform = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(decryptKey), IV = Gd6gd0WLH }.CreateDecryptor();
                byte[] inputBuffer = Convert.FromBase64String(decryptString);
                byte[] bytes = transform.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length);
                return Encoding.UTF8.GetString(bytes);
            }
            catch
            {
                return string.Empty;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AES_DecryptFile(string InputFile, string OutputFile)
        {
            try
            {
                string decryptKey = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x57fa);
                FileStream fs = new FileStream(InputFile, FileMode.Open);
                FileStream stream2 = new FileStream(OutputFile, FileMode.Create);
                CryptoStream stream3 = AES_DecryptStream(fs, decryptKey);
                byte[] buffer = new byte[0x400];
                int count = 0;
                while (true)
                {
                    count = stream3.Read(buffer, 0, buffer.Length);
                    stream2.Write(buffer, 0, count);
                    if (count < buffer.Length)
                    {
                        break;
                    }
                }
                stream3.Close();
                fs.Close();
                stream2.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CryptoStream AES_DecryptStream(FileStream fs, string decryptKey)
        {
            decryptKey = t00qRSolC(decryptKey, 0x20, "");
            decryptKey = decryptKey.PadRight(0x20, ' ');
            ICryptoTransform transform = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(decryptKey), IV = Gd6gd0WLH }.CreateDecryptor();
            return new CryptoStream(fs, transform, CryptoStreamMode.Read);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AES_Encrypt(string encryptString)
        {
            return AES_Encrypt(encryptString, lPRM4Nury);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AES_Encrypt(string encryptString, string encryptKey)
        {
            encryptKey = t00qRSolC(encryptKey, 0x20, "");
            encryptKey = encryptKey.PadRight(0x20, ' ');
            ICryptoTransform transform = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 0x20)), IV = Gd6gd0WLH }.CreateEncryptor();
            byte[] bytes = Encoding.UTF8.GetBytes(encryptString);
            return Convert.ToBase64String(transform.TransformFinalBlock(bytes, 0, bytes.Length));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool AES_EncryptFile(string InputFile, string OutputFile)
        {
            try
            {
                string decryptKey = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x57dc);
                FileStream stream = new FileStream(InputFile, FileMode.Open);
                FileStream fs = new FileStream(OutputFile, FileMode.Create);
                CryptoStream stream3 = AES_EncryptStrream(fs, decryptKey);
                byte[] buffer = new byte[stream.Length];
                stream.Read(buffer, 0, buffer.Length);
                stream3.Write(buffer, 0, buffer.Length);
                stream3.Close();
                stream.Close();
                fs.Close();
            }
            catch
            {
                return false;
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CryptoStream AES_EncryptStrream(FileStream fs, string decryptKey)
        {
            decryptKey = t00qRSolC(decryptKey, 0x20, "");
            decryptKey = decryptKey.PadRight(0x20, ' ');
            ICryptoTransform transform = new RijndaelManaged { Key = Encoding.UTF8.GetBytes(decryptKey), IV = Gd6gd0WLH }.CreateEncryptor();
            return new CryptoStream(fs, transform, CryptoStreamMode.Write);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Base64Decrypt(string str)
        {
            byte[] bytes = Convert.FromBase64String(str);
            return Encoding.UTF8.GetString(bytes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Base64Encrypt(string str)
        {
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(str));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DecryptString(string input, bool throwException)
        {
            string str = "";
            try
            {
                str = input;
                if (!MD5Util.ValidateValue(str))
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5824));
                }
                return MD5Util.RemoveMD5Profix(Base64Util.Decrypt(MD5Util.RemoveMD5Profix(str)));
            }
            catch
            {
                if (throwException)
                {
                    throw;
                }
                return "";
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DesDecrypt(string strText)
        {
            try
            {
                return DesDecrypt(strText, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x57a8));
            }
            catch
            {
                return "";
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DesDecrypt(string strText, string sDecrKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            byte[] buffer = new byte[strText.Length];
            rgbKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            buffer = Convert.FromBase64String(strText);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            Encoding encoding = new UTF8Encoding();
            return encoding.GetString(stream.ToArray());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DesDecrypt(string m_InFilePath, string m_OutFilePath, string sDecrKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            rgbKey = Encoding.UTF8.GetBytes(sDecrKey.Substring(0, 8));
            FileStream stream = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
            FileStream stream2 = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            stream2.SetLength(0L);
            byte[] buffer = new byte[100];
            long num = 0L;
            long length = stream.Length;
            DES des = new DESCryptoServiceProvider();
            CryptoStream stream3 = new CryptoStream(stream2, des.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            while (num < length)
            {
                int count = stream.Read(buffer, 0, 100);
                stream3.Write(buffer, 0, count);
                num += count;
            }
            stream3.Close();
            stream2.Close();
            stream.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DesEncrypt(string strText)
        {
            try
            {
                return DesEncrypt(strText, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5794));
            }
            catch
            {
                return "";
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string DesEncrypt(string strText, string strEncrKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            rgbKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.UTF8.GetBytes(strText);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, provider.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            stream2.Write(bytes, 0, bytes.Length);
            stream2.FlushFinalBlock();
            return Convert.ToBase64String(stream.ToArray());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DesEncrypt(string m_InFilePath, string m_OutFilePath, string strEncrKey)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = new byte[] { 0x12, 0x34, 0x56, 120, 0x90, 0xab, 0xcd, 0xef };
            rgbKey = Encoding.UTF8.GetBytes(strEncrKey.Substring(0, 8));
            FileStream stream = new FileStream(m_InFilePath, FileMode.Open, FileAccess.Read);
            FileStream stream2 = new FileStream(m_OutFilePath, FileMode.OpenOrCreate, FileAccess.Write);
            stream2.SetLength(0L);
            byte[] buffer = new byte[100];
            long num = 0L;
            long length = stream.Length;
            DES des = new DESCryptoServiceProvider();
            CryptoStream stream3 = new CryptoStream(stream2, des.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
            while (num < length)
            {
                int count = stream.Read(buffer, 0, 100);
                stream3.Write(buffer, 0, count);
                num += count;
            }
            stream3.Close();
            stream2.Close();
            stream.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string EncryptString(string input)
        {
            return MD5Util.AddMD5Profix(Base64Util.Encrypt(MD5Util.AddMD5Profix(input)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string EncyptMD5_3_16(string s)
        {
            MD5 md = MD5.Create();
            byte[] bytes = Encoding.ASCII.GetBytes(s);
            byte[] buffer = md.ComputeHash(bytes);
            byte[] buffer3 = md.ComputeHash(buffer);
            byte[] buffer4 = md.ComputeHash(buffer3);
            StringBuilder builder = new StringBuilder();
            foreach (byte num in buffer4)
            {
                builder.Append(num.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x581e)).PadLeft(2, '0'));
            }
            return builder.ToString().ToUpper();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string MD5Encrypt(string strText)
        {
            byte[] bytes = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(strText));
            return Encoding.Default.GetString(bytes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string MD5EncryptHash(string input)
        {
            byte[] sourceArray = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            char[] destinationArray = new char[sourceArray.Length];
            Array.Copy(sourceArray, destinationArray, sourceArray.Length);
            return new string(destinationArray);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string MD5EncryptHashHex(string input)
        {
            byte[] buffer = new MD5CryptoServiceProvider().ComputeHash(Encoding.Default.GetBytes(input), 0, input.Length);
            string str = string.Empty;
            for (int i = 0; i < buffer.Length; i++)
            {
                str = str + Uri.HexEscape((char) buffer[i]);
            }
            return str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5818), "").ToLower();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string QM3fY09LE(string text1, int num1, int num4, string text2)
        {
            string str = text1;
            if (Regex.IsMatch(text1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x57bc)) || Regex.IsMatch(text1, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x57cc)))
            {
                if (num1 >= text1.Length)
                {
                    return string.Empty;
                }
                return text1.Substring(num1, ((num4 + num1) > text1.Length) ? (text1.Length - num1) : num4);
            }
            if (num4 > 0)
            {
                byte[] bytes = Encoding.Default.GetBytes(text1);
                if (bytes.Length > num1)
                {
                    int length = bytes.Length;
                    if (bytes.Length > (num1 + num4))
                    {
                        length = num4 + num1;
                    }
                    else
                    {
                        num4 = bytes.Length - num1;
                        text2 = "";
                    }
                    int[] numArray = new int[num4];
                    int num2 = 0;
                    for (int i = num1; i < length; i++)
                    {
                        if (bytes[i] > 0x7f)
                        {
                            num2++;
                            if (num2 == 3)
                            {
                                num2 = 1;
                            }
                        }
                        else
                        {
                            num2 = 0;
                        }
                        numArray[i] = num2;
                    }
                    if ((bytes[length - 1] > 0x7f) && (numArray[num4 - 1] == 1))
                    {
                        num4++;
                    }
                    byte[] destinationArray = new byte[num4];
                    Array.Copy(bytes, num1, destinationArray, 0, num4);
                    return (Encoding.Default.GetString(destinationArray) + text2);
                }
            }
            return string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SHA256(string str)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(str);
            SHA256Managed managed = new SHA256Managed();
            return Convert.ToBase64String(managed.ComputeHash(bytes));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static string t00qRSolC(string text1, int num1, string text2)
        {
            return QM3fY09LE(text1, 0, num1, text2);
        }
    }
}

