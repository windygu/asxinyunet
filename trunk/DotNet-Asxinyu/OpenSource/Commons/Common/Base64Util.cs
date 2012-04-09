namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Runtime.CompilerServices;
    using System.Text;

    public class Base64Util
    {
        protected string m_codeTable = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb56c);
        protected string m_pad = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb5f0);
        protected Dictionary<int, char> m_t1 = new Dictionary<int, char>();
        protected Dictionary<char, int> m_t2 = new Dictionary<char, int>();
        protected static Base64Util s_b64 = new Base64Util();

        [MethodImpl(MethodImplOptions.NoInlining)]
        public Base64Util()
        {
            this.InitDict();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Decode(string source)
        {
            int num4;
            if ((source == null) || (source == ""))
            {
                return "";
            }
            List<byte> byteArr = new List<byte>();
            char[] array = source.ToCharArray();
            int num = array.Length % 4;
            if (num != 0)
            {
                Array.Resize<char>(ref array, array.Length - num);
            }
            int index = source.IndexOf(this.m_pad);
            if (index != -1)
            {
                index = source.Length - index;
            }
            int num3 = array.Length / 4;
            for (num4 = 0; num4 < num3; num4++)
            {
                this.DecodeUnit(byteArr, new char[] { array[num4 * 4], array[(num4 * 4) + 1], array[(num4 * 4) + 2], array[(num4 * 4) + 3] });
            }
            for (num4 = 0; num4 < index; num4++)
            {
                byteArr.RemoveAt(byteArr.Count - 1);
            }
            return Encoding.UTF8.GetString(byteArr.ToArray());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void DecodeUnit(List<byte> byteArr, params char[] chArray)
        {
            int num;
            int[] numArray = new int[3];
            byte[] buffer = new byte[chArray.Length];
            for (num = 0; num < chArray.Length; num++)
            {
                buffer[num] = this.FindChar(chArray[num]);
            }
            numArray[0] = (buffer[0] << 2) + ((buffer[1] & 0x30) >> 4);
            numArray[1] = ((buffer[1] & 15) << 4) + ((buffer[2] & 60) >> 2);
            numArray[2] = ((buffer[2] & 3) << 6) + buffer[3];
            for (num = 0; num < numArray.Length; num++)
            {
                byteArr.Add((byte) numArray[num]);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Decrypt(string input)
        {
            return s_b64.Decode(input);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Encode(string source)
        {
            int num4;
            if ((source == null) || (source == ""))
            {
                return "";
            }
            StringBuilder builder = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(source);
            int num = bytes.Length % 3;
            int length = 3 - num;
            if (num != 0)
            {
                Array.Resize<byte>(ref bytes, bytes.Length + length);
            }
            int num3 = (int) Math.Ceiling((double) ((bytes.Length * 1.0) / 3.0));
            for (num4 = 0; num4 < num3; num4++)
            {
                builder.Append(this.EncodeUnit(new byte[] { bytes[num4 * 3], bytes[(num4 * 3) + 1], bytes[(num4 * 3) + 2] }));
            }
            if (num != 0)
            {
                builder.Remove(builder.Length - length, length);
                for (num4 = 0; num4 < length; num4++)
                {
                    builder.Append(this.m_pad);
                }
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected string EncodeUnit(params byte[] unit)
        {
            int[] numArray = new int[] { (unit[0] & 0xfc) >> 2, ((unit[0] & 3) << 4) + ((unit[1] & 240) >> 4), ((unit[1] & 15) << 2) + ((unit[2] & 0xc0) >> 6), unit[2] & 0x3f };
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < numArray.Length; i++)
            {
                builder.Append(this.GetEC(numArray[i]));
            }
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Encrypt(string input)
        {
            return s_b64.Encode(input);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected byte FindChar(char ch)
        {
            int num = this.m_t2[ch];
            return (byte) num;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected char GetEC(int code)
        {
            return this.m_t1[code];
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Base64Util GetStandardBase64()
        {
            return new Base64Util { Pad = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb5f6), CodeTable = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb5fc) };
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void InitDict()
        {
            this.m_t1.Clear();
            this.m_t2.Clear();
            this.m_t2.Add(this.m_pad[0], -1);
            for (int i = 0; i < this.m_codeTable.Length; i++)
            {
                this.m_t1.Add(i, this.m_codeTable[i]);
                this.m_t2.Add(this.m_codeTable[i], i);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void Test()
        {
            this.InitDict();
            string str = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb724);
            string source = this.Encode(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb756));
            string str3 = this.Decode(source);
            Console.WriteLine(source);
            Console.WriteLine(str == str3);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void ValidateEqualPad(string input, string pad)
        {
            if (input.IndexOf(pad) > -1)
            {
                throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb708) + pad);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        protected void ValidateRepeat(string input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                if (input.LastIndexOf(input[i]) > i)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb6ee) + input[i]);
                }
            }
        }

        public string CodeTable
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.m_codeTable;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (value == null)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb680));
                }
                if (value.Length < 0x40)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb698));
                }
                this.ValidateRepeat(value);
                this.ValidateEqualPad(value, this.m_pad);
                this.m_codeTable = value;
                this.InitDict();
            }
        }

        public string Pad
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.m_pad;
            }
            [MethodImpl(MethodImplOptions.NoInlining)]
            set
            {
                if (value == null)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb6b4));
                }
                if (value.Length != 1)
                {
                    throw new Exception(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xb6d2));
                }
                this.ValidateEqualPad(this.m_codeTable, value);
                this.m_pad = value;
                this.InitDict();
            }
        }
    }
}

