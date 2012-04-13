﻿using System;
using System.Net;

namespace NewLife.Serialization
{
    /// <summary>文本读取器基类</summary>
    /// <typeparam name="TSettings">设置类</typeparam>
    public abstract class TextReaderBase<TSettings> : ReaderBase<TSettings> where TSettings : TextReaderWriterSetting, new()
    {
        #region 属性
        /// <summary>是否使用大小，如果使用，将在写入数组、集合和字符串前预先写入大小。字符串类型读写器一般带有边界，不需要使用大小</summary>
        protected override Boolean UseSize { get { return false; } }
        #endregion

        #region 基础元数据
        #region 字节
        /// <summary>从当前流中读取下一个字节，并使流的当前位置提升 1 个字节。</summary>
        /// <returns></returns>
        public override byte ReadByte() { return ReadBytes(1)[0]; }

        /// <summary>从当前流中将 count 个字节读入字节数组，并使当前位置提升 count 个字节。</summary>
        /// <param name="count">要读取的字节数。</param>
        /// <returns></returns>
        public override byte[] ReadBytes(int count)
        {
            String str = ReadString();
            if (str == null) return null;
            if (str.Length == 0) return new Byte[] { };

            if (Settings.UseBase64)
                return Convert.FromBase64String(str);
            else
                return FromHex(str);
        }

        /// <summary>解密</summary>
        /// <param name="data"></param>
        /// <returns></returns>
        static Byte[] FromHex(String data)
        {
            if (String.IsNullOrEmpty(data)) return null;

            Byte[] bts = new Byte[data.Length / 2];
            for (int i = 0; i < data.Length / 2; i++)
            {
                bts[i] = (Byte)Convert.ToInt32(data.Substring(2 * i, 2), 16);
            }
            return bts;
        }
        #endregion

        #region 有符号整数
        /// <summary>从当前流中读取 2 字节有符号整数，并使流的当前位置提升 2 个字节。</summary>
        /// <returns></returns>
        public override short ReadInt16() { return (Int16)ReadInt32(); }

        /// <summary>从当前流中读取 4 字节有符号整数，并使流的当前位置提升 4 个字节。</summary>
        /// <returns></returns>
        public override int ReadInt32() { return (Int32)ReadInt64(); }

        /// <summary>从当前流中读取 8 字节有符号整数，并使流的当前位置向前移动 8 个字节。</summary>
        /// <returns></returns>
        public override long ReadInt64() { return Int64.Parse(ReadString()); }
        #endregion

        #region 浮点数
        /// <summary>从当前流中读取 4 字节浮点值，并使流的当前位置提升 4 个字节。</summary>
        /// <returns></returns>
        public override float ReadSingle() { return (Single)ReadDouble(); }

        /// <summary>从当前流中读取 8 字节浮点值，并使流的当前位置提升 8 个字节。</summary>
        /// <returns></returns>
        public override double ReadDouble() { return Double.Parse(ReadString()); }
        #endregion

        #region 字符串
        /// <summary>从当前流中读取 count 个字符，以字符数组的形式返回数据，并根据所使用的 Encoding 和从流中读取的特定字符，提升当前位置。</summary>
        /// <param name="count">要读取的字符数。</param>
        /// <returns></returns>
        public override char[] ReadChars(int count)
        {
            String str = ReadString();
            if (str == null) return null;

            return str.ToCharArray();
        }

        /// <summary>从当前流中读取一个字符串。字符串有长度前缀，一次 7 位地被编码为整数。</summary>
        /// <returns></returns>
        public override string ReadString() { throw new NotImplementedException(); }
        #endregion

        #region 其它
        /// <summary>从当前流中读取 Boolean 值，并使该流的当前位置提升 1 个字节。</summary>
        /// <returns></returns>
        public override bool ReadBoolean() { return Boolean.Parse(ReadString()); }

        /// <summary>从当前流中读取十进制数值，并将该流的当前位置提升十六个字节。</summary>
        /// <returns></returns>
        public override decimal ReadDecimal() { return Decimal.Parse(ReadString()); }

        /// <summary>读取一个时间日期</summary>
        /// <returns></returns>
        public override DateTime ReadDateTime() { return DateTime.Parse(ReadString()); }
        #endregion
        #endregion

        #region 扩展类型
        /// <summary>读取Guid</summary>
        /// <returns></returns>
        protected override Guid OnReadGuid() { return new Guid(ReadString()); }

        /// <summary>读取IPAddress</summary>
        /// <returns></returns>
        protected override IPAddress OnReadIPAddress()
        {
            String str = ReadString();
            if (String.IsNullOrEmpty(str)) return null;

            return IPAddress.Parse(str);
        }

        /// <summary>读取IPEndPoint</summary>
        /// <returns></returns>
        protected override IPEndPoint OnReadIPEndPoint()
        {
            String str = ReadString();
            if (String.IsNullOrEmpty(str)) return null;

            Int32 index = str.IndexOf(":");

            IPAddress address = IPAddress.Parse(str.Substring(0, index));
            Int32 port = Int32.Parse(str.Substring(index + 1));
            return new IPEndPoint(address, port);
        }
        #endregion

        #region 读取值
        /// <summary>尝试读取值类型数据，返回是否读取成功</summary>
        /// <param name="type">要读取的对象类型</param>
        /// <param name="value">要读取的对象</param>
        /// <returns></returns>
        public override bool ReadValue(Type type, ref object value)
        {
            if (type != null && type.IsEnum && Settings.UseEnumName)
            {
                String str = ReadString();
                value = Enum.Parse(type, str, true);
                return true;
            }
            return base.ReadValue(type, ref value);
        }
        #endregion
    }
}