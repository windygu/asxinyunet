﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Net;

namespace NewLife.Serialization
{
    /// <summary>
    /// 字符串类型写入器基类
    /// </summary>
    /// <typeparam name="TSettings">设置类</typeparam>
    public class TextWriterBase<TSettings> : WriterBase<TSettings> where TSettings : TextReaderWriterSetting, new()
    {
        #region 属性
        /// <summary>是否使用大小，如果使用，将在写入数组、集合和字符串前预先写入大小。字符串类型读写器一般带有边界，不需要使用大小</summary>
        protected override Boolean UseSize
        {
            get { return false; }
        }
        #endregion

        #region 基础元数据
        #region 字节
        /// <summary>
        /// 将一个无符号字节写入
        /// </summary>
        /// <param name="value">要写入的无符号字节。</param>
        public override void Write(Byte value)
        {
            Write(new Byte[] { value }, 0, 1);
        }

        ///// <summary>
        ///// 将字节数组写入，先写入字节数组的长度
        ///// </summary>
        ///// <param name="buffer">包含要写入的数据的字节数组。</param>
        //public override void Write(byte[] buffer)
        //{
        //    if (buffer == null) return;

        //    Write(buffer, 0, buffer.Length);
        //}

        /// <summary>
        /// 将字节数组部分写入当前流。
        /// </summary>
        /// <param name="buffer">包含要写入的数据的字节数组。</param>
        /// <param name="index">buffer 中开始写入的起始点。</param>
        /// <param name="count">要写入的字节数。</param>
        public override void Write(byte[] buffer, int index, int count)
        {
            if (buffer == null || buffer.Length < 1 || count <= 0 || index >= buffer.Length) return;

            //Writer.WriteBase64(buffer, index, count);

            if (Settings.UseBase64)
                Write(Convert.ToBase64String(buffer, index, count));
            else
                Write(BitConverter.ToString(buffer, index, count).Replace("-", null));

            AutoFlush();
        }
        #endregion

        #region 有符号整数
        /// <summary>
        /// 将 2 字节有符号整数写入当前流，并将流的位置提升 2 个字节。
        /// </summary>
        /// <param name="value">要写入的 2 字节有符号整数。</param>
        public override void Write(short value) { Write((Int32)value); }

        /// <summary>
        /// 将 4 字节有符号整数写入当前流，并将流的位置提升 4 个字节。
        /// </summary>
        /// <param name="value">要写入的 4 字节有符号整数。</param>
        public override void Write(int value) { Write((Int64)value); }

        /// <summary>
        /// 将 8 字节有符号整数写入当前流，并将流的位置提升 8 个字节。
        /// </summary>
        /// <param name="value">要写入的 8 字节有符号整数。</param>
        public override void Write(long value) { Write(value.ToString()); }
        #endregion

        #region 浮点数
        /// <summary>
        /// 将 4 字节浮点值写入当前流，并将流的位置提升 4 个字节。
        /// </summary>
        /// <param name="value">要写入的 4 字节浮点值。</param>
        public override void Write(float value) { Write(value.ToString()); }

        /// <summary>
        /// 将 8 字节浮点值写入当前流，并将流的位置提升 8 个字节。
        /// </summary>
        /// <param name="value">要写入的 8 字节浮点值。</param>
        public override void Write(double value) { Write(value.ToString()); }
        #endregion

        #region 字符串
        /// <summary>
        /// 将字符数组部分写入当前流，并根据所使用的 Encoding（可能还根据向流中写入的特定字符），提升流的当前位置。
        /// </summary>
        /// <param name="chars">包含要写入的数据的字符数组。</param>
        /// <param name="index">chars 中开始写入的起始点。</param>
        /// <param name="count">要写入的字符数。</param>
        public override void Write(char[] chars, int index, int count)
        {
            if (chars == null || chars.Length < 1 || count <= 0 || index >= chars.Length)
            {
                //Write(0);
                return;
            }

            //Writer.WriteChars(chars, index, count);
            Write(new String(chars, index, count));

            //AutoFlush();
        }

        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="value">要写入的值。</param>
        public override void Write(string value)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region 其它
        /// <summary>
        /// 将单字节 Boolean 值写入
        /// </summary>
        /// <param name="value">要写入的 Boolean 值</param>
        public override void Write(Boolean value) { Write(value.ToString()); }
        //public override void Write(Boolean value) { Write(value ? "true" : "false"); }

        /// <summary>
        /// 将一个十进制值写入当前流，并将流位置提升十六个字节。
        /// </summary>
        /// <param name="value">要写入的十进制值。</param>
        public override void Write(decimal value) { Write(value.ToString()); }

        /// <summary>
        /// 将一个时间日期写入
        /// </summary>
        /// <param name="value"></param>
        public override void Write(DateTime value) { Write(value.ToString("yyyy-MM-dd HH:mm:ss")); }
        #endregion
        #endregion

        #region 扩展类型
        /// <summary>
        /// 写入Guid
        /// </summary>
        /// <param name="value"></param>
        protected override void OnWrite(Guid value)
        {
            Write(value.ToString());
        }

        /// <summary>
        /// 写入IPAddress
        /// </summary>
        /// <param name="value"></param>
        protected override void OnWrite(IPAddress value)
        {
            Write(value.ToString());
        }

        /// <summary>
        /// 写入IPEndPoint
        /// </summary>
        /// <param name="value"></param>
        protected override void OnWrite(IPEndPoint value)
        {
            Write(value.ToString());
        }
        #endregion

        #region 写入值类型
        /// <summary>
        /// 写入值类型，只能识别基础类型，对于不能识别的类型，方法返回false
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <returns>是否写入成功</returns>
        protected override bool WriteValue(object value, Type type)
        {
            if (value != null && Settings.UseEnumName)
            {
                //type = value.GetType();
                if (type != null && type.IsEnum)
                {
                    Write(value.ToString());
                    return true;
                }
            }
            return base.WriteValue(value, type);
        }
        #endregion
    }
}