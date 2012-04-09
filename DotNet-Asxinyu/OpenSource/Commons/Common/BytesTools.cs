namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Runtime.CompilerServices;
    using System.Text;

    public static class BytesTools
    {
        public static readonly Encoding ASCII = Encoding.ASCII;
        public static readonly Encoding GB2312 = Encoding.GetEncoding(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8dce));

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] 01FqmBarm(byte[] buffer1, int num1, int num2)
        {
            if (buffer1.Length < (num1 + num2))
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c28));
            }
            byte[] buffer = new byte[num2];
            for (int i = 0; i < num2; i++)
            {
                buffer[i] = buffer1[i + num1];
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static ushort 4bccOhnfl(byte[] buffer1, int num1)
        {
            return BitConverter.ToUInt16(SwapBytes(new byte[] { buffer1[num1], buffer1[num1 + 1] }), 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int BufferLookup(byte[] srcbuff, byte[] subbuff)
        {
            return BufferLookup(srcbuff, subbuff, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int BufferLookup(byte[] srcbuff, string subchars)
        {
            return BufferLookup(srcbuff, subchars, 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int BufferLookup(byte[] srcbuff, byte[] subbuff, int start)
        {
            for (int i = start; i < ((srcbuff.Length - subbuff.Length) + 1); i++)
            {
                for (int j = 0; j < subbuff.Length; j++)
                {
                    if (srcbuff[i + j] != subbuff[j])
                    {
                        break;
                    }
                    if (j == (subbuff.Length - 1))
                    {
                        return i;
                    }
                }
            }
            return -1;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int BufferLookup(byte[] srcbuff, string subchars, int start)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(subchars);
            return BufferLookup(srcbuff, bytes, start);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string BytesToHex(byte[] bytes)
        {
            if (bytes == null)
            {
                return "";
            }
            string str = "";
            for (int i = 0; i < bytes.Length; i++)
            {
                str = str + bytes[i].ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c4a));
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] Clone(byte[] byte1)
        {
            if (byte1 == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8cae));
            }
            byte[] dst = new byte[byte1.Length];
            Buffer.BlockCopy(byte1, 0, dst, 0, byte1.Length);
            return dst;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] Combine(byte[] byte1, byte[] byte2)
        {
            if (byte1 == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c92));
            }
            if (byte2 == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8ca0));
            }
            byte[] dst = new byte[byte1.Length + byte2.Length];
            Buffer.BlockCopy(byte1, 0, dst, 0, byte1.Length);
            Buffer.BlockCopy(byte2, 0, dst, byte1.Length, byte2.Length);
            return dst;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Compare(byte[] byte1, byte[] byte2)
        {
            if (byte1 == null)
            {
                return false;
            }
            if (byte2 == null)
            {
                return false;
            }
            if (byte1.Length != byte2.Length)
            {
                return false;
            }
            for (int i = 0; i < byte1.Length; i++)
            {
                if (byte1[i] != byte2[i])
                {
                    return false;
                }
            }
            return true;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] dT3f0t4t3(ushort num1)
        {
            return SwapBytes(BitConverter.GetBytes(num1));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] GetBytesFromHexString(string hexadecimalNumber)
        {
            string message = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8cbc);
            if (string.IsNullOrEmpty(hexadecimalNumber))
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8d32));
            }
            StringBuilder builder = new StringBuilder(hexadecimalNumber.ToUpper(CultureInfo.CurrentCulture));
            char ch = builder[0];
            if (ch.Equals('0') && (ch = builder[1]).Equals('X'))
            {
                builder.Remove(0, 2);
            }
            if ((builder.Length % 2) != 0)
            {
                throw new ArgumentException(message);
            }
            byte[] buffer = new byte[builder.Length / 2];
            try
            {
                for (int i = 0; i < buffer.Length; i++)
                {
                    int startIndex = i * 2;
                    buffer[i] = Convert.ToByte(builder.ToString(startIndex, 2), 0x10);
                }
            }
            catch (FormatException exception)
            {
                throw new ArgumentException(message, exception);
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetHexStringFromBytes(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8d58));
            }
            if (bytes.Length == 0)
            {
                throw new ArgumentOutOfRangeException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8d66), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8d74));
            }
            StringBuilder builder = new StringBuilder(bytes.Length * 2);
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8dc6), CultureInfo.CurrentCulture));
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] HexToBytes(string input)
        {
            int num = input.Length % 2;
            if (num != 0)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c78));
            }
            List<byte> list = new List<byte>();
            for (int i = 0; i < input.Length; i += 2)
            {
                byte item = Convert.ToByte(input.Substring(i, 2), 0x10);
                list.Add(item);
            }
            return list.ToArray();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static DateTime MEWIXKqxt(byte[] buffer1)
        {
            string str = "";
            for (int i = 0; i < 7; i++)
            {
                str = str + buffer1[i].ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c52));
            }
            str = str.Substring(0, 4) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c5a) + str.Substring(4, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c60) + str.Substring(6, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c66) + str.Substring(8, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c6c) + str.Substring(10, 2) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c72) + str.Substring(12, 2);
            try
            {
                return Convert.ToDateTime(str);
            }
            catch
            {
                return new DateTime(0x7d0, 1, 1);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] SpecCharConvert(byte[] srcbuff)
        {
            List<byte> list = new List<byte>();
            foreach (byte num in srcbuff)
            {
                if (num == 0x7e)
                {
                    list.Add(0x7d);
                    list.Add(0x5e);
                }
                else if (num == 0x7d)
                {
                    list.Add(0x7d);
                    list.Add(0x5d);
                }
                else
                {
                    list.Add(num);
                }
            }
            return list.ToArray();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] SpecCharReverse(byte[] srcbuff)
        {
            List<byte> list = new List<byte>();
            int index = 0;
            while (index < srcbuff.Length)
            {
                if (srcbuff[index] == 0x7d)
                {
                    if (srcbuff[index + 1] == 0x5e)
                    {
                        list.Add(0x7e);
                    }
                    else
                    {
                        if (srcbuff[index + 1] != 0x5d)
                        {
                            throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8c3e));
                        }
                        list.Add(0x7d);
                    }
                    index += 2;
                }
                else
                {
                    list.Add(srcbuff[index]);
                    index++;
                }
            }
            return list.ToArray();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] SwapBytes(byte[] bytes)
        {
            int length = bytes.Length;
            byte[] buffer = new byte[length];
            for (int i = 0; i < length; i++)
            {
                buffer[i] = bytes[(length - i) - 1];
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static uint TEPULnwMP(byte[] buffer1, int num1)
        {
            return BitConverter.ToUInt32(SwapBytes(01FqmBarm(buffer1, num1, 4)), 0);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ToDBDate(DateTime dateTime)
        {
            byte[] buffer = new byte[15];
            buffer[0] = (byte) ((dateTime.Year / 100) + 100);
            buffer[1] = (byte) ((dateTime.Year % 100) + 100);
            buffer[2] = (byte) dateTime.Month;
            buffer[3] = (byte) dateTime.Day;
            buffer[4] = (byte) (dateTime.Hour + 1);
            buffer[5] = (byte) (dateTime.Minute + 1);
            buffer[6] = (byte) (dateTime.Second + 1);
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ToSBC(byte[] srcbuff)
        {
            List<byte> list = new List<byte>();
            int index = 0;
            while (index < srcbuff.Length)
            {
                if (srcbuff[index] == 0x20)
                {
                    list.Add(0xa1);
                    list.Add(0xa1);
                    index++;
                }
                else if (srcbuff[index] == 0x7e)
                {
                    list.Add(0xa1);
                    list.Add(0xab);
                    index++;
                }
                else if (srcbuff[index] > 0x80)
                {
                    list.Add(srcbuff[index]);
                    list.Add(srcbuff[index + 1]);
                    index += 2;
                }
                else
                {
                    list.Add(0xa3);
                    list.Add((byte) (srcbuff[index] + 0x80));
                    index++;
                }
            }
            return list.ToArray();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        internal static byte[] yTHMJ858G(int num1)
        {
            return SwapBytes(BitConverter.GetBytes(num1));
        }
    }
}

