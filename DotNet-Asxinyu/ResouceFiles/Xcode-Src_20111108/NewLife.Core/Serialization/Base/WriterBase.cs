﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace NewLife.Serialization
{
    /// <summary>
    /// 写入器基类
    /// </summary>
    /// <remarks>序列化框架的处理顺序为：IAccessor接口 => OnObjectWriting事件 => 扩展类型 => 基础类型 => 字典 => 枚举 => 序列化接口 => 自定义对象 => 未知类型 => OnObjectWrited事件</remarks>
    /// <typeparam name="TSettings">设置类</typeparam>
    public abstract class WriterBase<TSettings> : ReaderWriterBase<TSettings>, IWriter where TSettings : ReaderWriterSetting, new()
    {
        #region 基元类型
        #region 字节
        /// <summary>
        /// 将一个无符号字节写入
        /// </summary>
        /// <param name="value">要写入的无符号字节。</param>
        public abstract void Write(Byte value);

        /// <summary>
        /// 将字节数组写入，如果设置了UseSize，则先写入数组长度。
        /// </summary>
        /// <param name="buffer">包含要写入的数据的字节数组。</param>
        public virtual void Write(byte[] buffer)
        {
            if (buffer == null)
            {
                WriteSize(0);
                return;
            }

            WriteSize(buffer.Length);
            Write(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// 将一个有符号字节写入当前流，并将流的位置提升 1 个字节。
        /// </summary>
        /// <param name="value">要写入的有符号字节。</param>
        [CLSCompliant(false)]
        public virtual void Write(sbyte value) { Write((Byte)value); }

        /// <summary>
        /// 将字节数组部分写入当前流，不写入数组长度。
        /// </summary>
        /// <param name="buffer">包含要写入的数据的字节数组。</param>
        /// <param name="index">buffer 中开始写入的起始点。</param>
        /// <param name="count">要写入的字节数。</param>
        public virtual void Write(byte[] buffer, int index, int count)
        {
            if (buffer == null || buffer.Length < 1 || count <= 0 || index >= buffer.Length) return;

            for (int i = 0; i < count && index + i < buffer.Length; i++)
            {
                Write(buffer[index + i]);
            }
        }

        /// <summary>
        /// 写入字节数组，自动计算长度
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="count"></param>
        private void Write(Byte[] buffer, Int32 count)
        {
            if (buffer == null) return;

            if (count < 0 || count > buffer.Length) count = buffer.Length;

            Write(buffer, 0, count);
        }
        #endregion

        #region 有符号整数
        /// <summary>
        /// 写入整数的字节数组，某些写入器（如二进制写入器）可能需要改变字节顺序
        /// </summary>
        /// <param name="buffer"></param>
        protected virtual void WriteIntBytes(Byte[] buffer)
        {
            Write(buffer, -1);
        }

        /// <summary>
        /// 将 2 字节有符号整数写入当前流，并将流的位置提升 2 个字节。
        /// </summary>
        /// <param name="value">要写入的 2 字节有符号整数。</param>
        public virtual void Write(short value) { WriteIntBytes(BitConverter.GetBytes(value)); }

        /// <summary>
        /// 将 4 字节有符号整数写入当前流，并将流的位置提升 4 个字节。
        /// </summary>
        /// <param name="value">要写入的 4 字节有符号整数。</param>
        public virtual void Write(int value) { WriteIntBytes(BitConverter.GetBytes(value)); }

        /// <summary>
        /// 将 8 字节有符号整数写入当前流，并将流的位置提升 8 个字节。
        /// </summary>
        /// <param name="value">要写入的 8 字节有符号整数。</param>
        public virtual void Write(long value) { WriteIntBytes(BitConverter.GetBytes(value)); }
        #endregion

        #region 无符号整数
        /// <summary>
        /// 将 2 字节无符号整数写入当前流，并将流的位置提升 2 个字节。
        /// </summary>
        /// <param name="value">要写入的 2 字节无符号整数。</param>
        [CLSCompliant(false)]
        public virtual void Write(ushort value) { Write((Int16)value); }

        /// <summary>
        /// 将 4 字节无符号整数写入当前流，并将流的位置提升 4 个字节。
        /// </summary>
        /// <param name="value">要写入的 4 字节无符号整数。</param>
        [CLSCompliant(false)]
        public virtual void Write(uint value) { Write((Int32)value); }

        /// <summary>
        /// 将 8 字节无符号整数写入当前流，并将流的位置提升 8 个字节。
        /// </summary>
        /// <param name="value">要写入的 8 字节无符号整数。</param>
        [CLSCompliant(false)]
        public virtual void Write(ulong value) { Write((Int64)value); }
        #endregion

        #region 浮点数
        /// <summary>
        /// 将 4 字节浮点值写入当前流，并将流的位置提升 4 个字节。
        /// </summary>
        /// <param name="value">要写入的 4 字节浮点值。</param>
        public virtual void Write(float value) { Write(BitConverter.GetBytes(value), -1); }

        /// <summary>
        /// 将 8 字节浮点值写入当前流，并将流的位置提升 8 个字节。
        /// </summary>
        /// <param name="value">要写入的 8 字节浮点值。</param>
        public virtual void Write(double value) { Write(BitConverter.GetBytes(value), -1); }
        #endregion

        #region 字符串
        /// <summary>
        /// 将 Unicode 字符写入当前流，并根据所使用的 Encoding 和向流中写入的特定字符，提升流的当前位置。
        /// </summary>
        /// <param name="ch">要写入的非代理项 Unicode 字符。</param>
        public virtual void Write(char ch) { Write(Convert.ToByte(ch)); }

        /// <summary>
        /// 将字符数组写入当前流，并根据所使用的 Encoding 和向流中写入的特定字符，提升流的当前位置。
        /// </summary>
        /// <param name="chars">包含要写入的数据的字符数组。</param>
        public virtual void Write(char[] chars) { Write(chars, 0, chars == null ? 0 : chars.Length); }

        /// <summary>
        /// 将字符数组部分写入当前流，并根据所使用的 Encoding（可能还根据向流中写入的特定字符），提升流的当前位置。
        /// </summary>
        /// <param name="chars">包含要写入的数据的字符数组。</param>
        /// <param name="index">chars 中开始写入的起始点。</param>
        /// <param name="count">要写入的字符数。</param>
        public virtual void Write(char[] chars, int index, int count)
        {
            if (chars == null)
            {
                WriteSize(0);
                return;
            }

            if (chars.Length < 1 || count <= 0 || index >= chars.Length)
            {
                WriteSize(0);
                return;
            }

            // 先用写入字节长度
            Byte[] buffer = Settings.Encoding.GetBytes(chars, index, count);
            Write(buffer);
        }

        /// <summary>
        /// 写入字符串
        /// </summary>
        /// <param name="value">要写入的值。</param>
        public virtual void Write(string value) { Write(value == null ? null : value.ToCharArray()); }
        #endregion

        #region 其它
        /// <summary>
        /// 将单字节 Boolean 值写入
        /// </summary>
        /// <param name="value">要写入的 Boolean 值</param>
        public virtual void Write(Boolean value) { Write((Byte)(value ? 1 : 0)); }

        /// <summary>
        /// 将一个十进制值写入当前流，并将流位置提升十六个字节。
        /// </summary>
        /// <param name="value">要写入的十进制值。</param>
        public virtual void Write(decimal value)
        {
            Int32[] data = Decimal.GetBits(value);
            for (int i = 0; i < data.Length; i++)
            {
                Write(data[i]);
            }
        }

        /// <summary>
        /// 将一个时间日期写入
        /// </summary>
        /// <param name="value"></param>
        public virtual void Write(DateTime value) { Write(Settings.ConvertDateTimeToInt64(value)); }
        #endregion
        #endregion

        #region 值类型
        /// <summary>
        /// 写入值类型，只能识别基础类型，对于不能识别的类型，方法返回false
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <returns>是否写入成功</returns>
        protected virtual Boolean WriteValue(Object value, Type type)
        {
            // 不用担心，外部保证type正确。同时，禁止外部直接调用WriteValue，因为那样就越过了对未知类型的处理
            TypeCode code = Type.GetTypeCode(type);
            switch (code)
            {
                case TypeCode.Boolean:
                    Write((Boolean)value);
                    return true;
                case TypeCode.Byte:
                    Write((Byte)value);
                    return true;
                case TypeCode.Char:
                    Write((Char)value);
                    return true;
                case TypeCode.DBNull:
                    Write((Byte)0);
                    return true;
                case TypeCode.DateTime:
                    //return WriteValue(Convert.ToDateTime(value, CultureInfo.InvariantCulture).Ticks, null);
                    Write((DateTime)value);
                    return true;
                case TypeCode.Decimal:
                    Write((Decimal)value);
                    return true;
                case TypeCode.Double:
                    Write((Double)value);
                    return true;
                case TypeCode.Empty:
                    Write((Byte)0);
                    return true;
                case TypeCode.Int16:
                    Write((Int32)value);
                    return true;
                case TypeCode.Int32:
                    Write((Int32)value);
                    return true;
                case TypeCode.Int64:
                    Write((Int64)value);
                    return true;
                case TypeCode.Object:
                    break;
                case TypeCode.SByte:
                    Write((SByte)value);
                    return true;
                case TypeCode.Single:
                    Write((Single)value);
                    return true;
                case TypeCode.String:
                    Write((String)value);
                    return true;
                case TypeCode.UInt16:
                    Write((UInt16)value);
                    return true;
                case TypeCode.UInt32:
                    Write((UInt32)value);
                    return true;
                case TypeCode.UInt64:
                    Write((UInt64)value);
                    return true;
                default:
                    break;
            }

            return false;
        }
        #endregion

        #region 字典
        /// <summary>
        /// 写入枚举类型数据
        /// </summary>
        /// <param name="value">枚举数据</param>
        /// <returns>是否写入成功</returns>
        public Boolean Write(IDictionary value)
        {
            return WriteDictionary(value, null, WriteMember);
        }

        /// <summary>
        /// 写入字典类型数据
        /// </summary>
        /// <param name="value">字典数据</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        public virtual Boolean WriteDictionary(IDictionary value, Type type, WriteObjectCallback callback)
        {
            if (value == null) return true;
            // type = CheckAndWriteType("WriteDictionaryType", value, type);

            // 计算元素类型
            Type keyType = null;
            Type valueType = null;

            // 取得键值类型
            //if (!GetDictionaryEntryType(type, ref keyType, ref valueType)) return false;
            GetDictionaryEntryType(type, ref keyType, ref valueType);

            WriteSize(value.Count);
            if (value.Count == 0) return true;

            //type = value.GetType();
            if (type != null && !typeof(IDictionary).IsAssignableFrom(type)) throw new InvalidOperationException("目标类型不是字典类型！");

            Int32 i = 0;
            foreach (DictionaryEntry item in value)
            {
                Depth++;
                if (!WriteKeyValue(item, keyType, valueType, i++, callback)) return false;
                Depth--;
            }

            return true;
        }

        /// <summary>
        /// 写入字典项
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="keyType">键类型</param>
        /// <param name="valueType">值类型</param>
        /// <param name="index">成员索引</param>
        /// <param name="callback">使用指定委托方法处理复杂数据</param>
        /// <returns>是否写入成功</returns>
        protected Boolean WriteKeyValue(DictionaryEntry value, Type keyType, Type valueType, Int32 index, WriteObjectCallback callback)
        {
            // 写入成员前
            WriteDictionaryEventArgs e = null;
            if (OnDictionaryWriting != null)
            {
                e = new WriteDictionaryEventArgs(value, keyType, valueType, index, callback);

                OnDictionaryWriting(this, e);

                // 事件处理器可能已经成功写入对象
                if (e.Success) return true;

                // 事件里面有可能改变了参数
                value = (DictionaryEntry)e.Value;
                keyType = e.KeyType;
                valueType = e.ValueType;
                index = e.Index;
                callback = e.Callback;
            }

            Boolean rs = OnWriteKeyValue(value, keyType, valueType, index, callback);

            // 写入成员后
            if (OnDictionaryWrited != null)
            {
                if (e == null) e = new WriteDictionaryEventArgs(value, keyType, valueType, index, callback);
                e.Success = rs;

                OnDictionaryWrited(this, e);

                // 事件处理器可以影响结果
                rs = e.Success;
            }

            return rs;
        }

        /// <summary>
        /// 写入字典项
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="keyType">键类型</param>
        /// <param name="valueType">值类型</param>
        /// <param name="index">成员索引</param>
        /// <param name="callback">使用指定委托方法处理复杂数据</param>
        /// <returns>是否写入成功</returns>
        protected virtual Boolean OnWriteKeyValue(DictionaryEntry value, Type keyType, Type valueType, Int32 index, WriteObjectCallback callback)
        {
            // 如果无法取得字典项类型，则每个键值都单独写入类型
            //keyType = CheckAndWriteType("WriteKeyType", value.Key, keyType);
            if (!WriteObject(value.Key, keyType, callback)) return false;

            // valueType = CheckAndWriteType("WriteValueType", value.Value, valueType);
            if (!WriteObject(value.Value, valueType, callback)) return false;

            return true;
        }

        /// <summary>
        /// 取得字典的键值类型，默认只支持获取两个泛型参数的字典的键值类型
        /// </summary>
        /// <param name="type">字典类型</param>
        /// <param name="keyType">键类型</param>
        /// <param name="valueType">值类型</param>
        /// <returns>是否获取成功，如果失败，则字典读取失败</returns>
        protected virtual Boolean GetDictionaryEntryType(Type type, ref Type keyType, ref Type valueType)
        {
            // 两个泛型参数的泛型
            if (type.IsGenericType)
            {
                Type[] ts = type.GetGenericArguments();
                if (ts != null && ts.Length == 2)
                {
                    keyType = ts[0];
                    valueType = ts[1];

                    return true;
                }
            }

            return false;
        }
        #endregion

        #region 枚举
        /// <summary>
        /// 写入枚举类型数据
        /// </summary>
        /// <param name="value">枚举数据</param>
        /// <returns>是否写入成功</returns>
        public Boolean Write(IEnumerable value)
        {
            return WriteEnumerable(value, null, WriteMember);
        }

        /// <summary>
        /// 写入枚举数据，复杂类型使用委托方法进行处理
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="type">类型</param>
        /// <param name="callback">使用指定委托方法处理复杂数据</param>
        /// <returns>是否写入成功</returns>
        public virtual Boolean WriteEnumerable(IEnumerable value, Type type, WriteObjectCallback callback)
        {
            if (value == null) return true;           

            type = CheckAndWriteType("WriteEnumerableType", value, type);

            //type = value.GetType();
            if (type != null && !typeof(IEnumerable).IsAssignableFrom(type)) throw new InvalidOperationException("目标类型不是枚举类型！");

            // 计算元素类型，如果无法计算，这里不能处理，否则能写不能读（因为不知道元素类型）
            Type elementType = null;
            if (type.HasElementType) elementType = type.GetElementType();

            // 如果实现了IEnumerable<>接口，那么取泛型参数
            if (elementType == null)
            {
                Type[] ts = type.GetInterfaces();
                foreach (Type item in ts)
                {
                    if (item.IsGenericType && item.GetGenericTypeDefinition() == typeof(IEnumerable<>))
                    {
                        elementType = item.GetGenericArguments()[0];
                        break;
                    }
                }
            }

            //if (elementType == null) return false;

            Int32 i = 0;
            foreach (Object item in value)
            {
                Depth++;
                if (!WriteItem(item, elementType, i++, callback)) return false;
                Depth--;
            }
            return true;
        }

        /// <summary>
        /// 写入枚举项
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="type">元素类型</param>
        /// <param name="index">元素索引</param>
        /// <param name="callback">使用指定委托方法处理复杂数据</param>
        /// <returns>是否写入成功</returns>
        protected Boolean WriteItem(Object value, Type type, Int32 index, WriteObjectCallback callback)
        {
            // 写入成员前
            WriteItemEventArgs e = null;
            if (OnItemWriting != null)
            {
                e = new WriteItemEventArgs(value, type, index, callback);

                OnItemWriting(this, e);

                // 事件处理器可能已经成功写入对象
                if (e.Success) return true;

                // 事件里面有可能改变了参数
                value = e.Value;
                type = e.Type;
                index = e.Index;
                callback = e.Callback;
            }

            Boolean rs = OnWriteItem(value, type, index, callback);

            // 写入成员后
            if (OnItemWrited != null)
            {
                if (e == null) e = new WriteItemEventArgs(value, type, index, callback);
                e.Success = rs;

                OnItemWrited(this, e);

                // 事件处理器可以影响结果
                rs = e.Success;
            }

            return rs;
        }

        /// <summary>
        /// 写入枚举项
        /// </summary>
        /// <param name="value">对象</param>
        /// <param name="type">元素类型</param>
        /// <param name="index">元素索引</param>
        /// <param name="callback">使用指定委托方法处理复杂数据</param>
        /// <returns>是否写入成功</returns>
        protected virtual Boolean OnWriteItem(Object value, Type type, Int32 index, WriteObjectCallback callback)
        {
            // 如果无法取得元素类型，则每个元素都单独写入类型
            // type = CheckAndWriteType("WriteItemType", value, type);
            return WriteObject(value, type, callback);
        }
        #endregion

        #region 序列化接口
        /// <summary>
        /// 写入实现了可序列化接口的对象
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        public virtual Boolean WriteSerializable(Object value, Type type, WriteObjectCallback callback)
        {
            if (!typeof(ISerializable).IsAssignableFrom(type)) return false;

            WriteLog("WriteSerializable", type.Name);

            return WriteCustomObject(value, type, callback);
        }
        #endregion

        #region 未知对象
        /// <summary>
        /// 写入未知对象（其它所有方法都无法识别的对象），采用BinaryFormatter或者XmlSerialization
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        public virtual Boolean WriteUnKnown(Object value, Type type, WriteObjectCallback callback)
        {
            WriteLog("WriteUnKnown", type.Name);

            // 调用.Net的二进制序列化来解决剩下的事情
            BinaryFormatter bf = new BinaryFormatter();
            MemoryStream ms = new MemoryStream();
            bf.Serialize(ms, value);
            ms.Position = 0;
            Write(ms.ToArray());

            return true;
        }
        #endregion

        #region 扩展处理类型
        /// <summary>
        /// 扩展写入，反射查找合适的写入方法
        /// </summary>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected virtual Boolean WriteX(Object value, Type type)
        {
            if (type == typeof(Byte[]))
            {
                Write((Byte[])value);
                return true;
            }
            if (type == typeof(Char[]))
            {
                Write((Char[])value);
                return true;
            }

            //! 所有扩展类型的写入，分为Write和OnWrite两部分，Write供外部独立调用，单独提供对象应用，而OnWrite不写对象引用
            if (type == typeof(Guid))
            {
                OnWrite((Guid)value);
                return true;
            }
            if (type == typeof(IPAddress))
            {
                OnWrite((IPAddress)value);
                return true;
            }
            if (type == typeof(IPEndPoint))
            {
                OnWrite((IPEndPoint)value);
                return true;
            }
            if (typeof(Type).IsAssignableFrom(type))
            {
                OnWrite((Type)value);
                return true;
            }

            return false;
        }

        /// <summary>
        /// 写入Guid
        /// </summary>
        /// <param name="value"></param>
        public virtual void Write(Guid value)
        {
            if (WriteObjRef(value)) return;

            OnWrite(value);

            //Write(((Guid)value).ToByteArray(), -1);
        }

        /// <summary>
        /// 写入Guid
        /// </summary>
        /// <param name="value"></param>
        protected virtual void OnWrite(Guid value)
        {
            Write(((Guid)value).ToByteArray(), -1);
        }

        /// <summary>
        /// 写入IPAddress
        /// </summary>
        /// <param name="value"></param>
        public virtual void Write(IPAddress value)
        {
            if (WriteObjRef(value)) return;

            OnWrite(value);

            //Byte[] buffer = (value as IPAddress).GetAddressBytes();
            //Write(buffer);
            ////Write(buffer, -1);
        }

        /// <summary>
        /// 写入IPAddress
        /// </summary>
        /// <param name="value"></param>
        protected virtual void OnWrite(IPAddress value)
        {
            Write((value as IPAddress).GetAddressBytes());
        }

        /// <summary>
        /// 写入IPEndPoint
        /// </summary>
        /// <param name="value"></param>
        public virtual void Write(IPEndPoint value)
        {
            if (WriteObjRef(value)) return;

            OnWrite(value);

            //Write(value.Address);
            ////// 端口实际只占2字节
            ////Write((UInt16)value.Port);
            //Write(value.Port);
        }

        /// <summary>
        /// 写入IPEndPoint
        /// </summary>
        /// <param name="value"></param>
        protected virtual void OnWrite(IPEndPoint value)
        {
            //! 直接调用OnWrite，不写对象引用，将来可能得考虑写对象引用
            OnWrite(value.Address);
            //// 端口实际只占2字节
            //Write((UInt16)value.Port);
            Write(value.Port);
        }

        /// <summary>
        /// 写入Type
        /// </summary>
        /// <param name="value"></param>
        public void Write(Type value)
        {
            if (WriteObjRef(value)) return;

            OnWrite(value);

            //Depth++;
            //WriteLog("WriteType", value.FullName);

            //// 分离出去，便于重载，而又能有效利用对象引用
            //OnWriteType(value);
            //Depth--;
        }

        /// <summary>
        /// 写入Type
        /// </summary>
        /// <param name="value"></param>
        protected virtual void OnWrite(Type value)
        {
            Depth++;
            WriteLog("WriteType", value.FullName);

            // 分离出去，便于重载，而又能有效利用对象引用
            OnWriteType(value);
            Depth--;
        }

        /// <summary>
        /// 写入Type
        /// </summary>
        /// <param name="value"></param>
        protected virtual void OnWriteType(Type value)
        {
            // 尽管使用AssemblyQualifiedName更精确，但是它的长度实在太大了
            if (Settings.UseTypeFullName)
                Write(value.FullName);
            else
                Write(value.AssemblyQualifiedName);
        }

        /// <summary>
        /// 获取精确类型
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        protected Boolean IsExactType(Type type)
        {
            if (type == null || type.IsInterface || type.IsAbstract || type == typeof(Object))
                return false;
            else
                return true;
        }

        /// <summary>
        /// 检查对象类型与指定写入类型是否一致，若不一致，则先写入类型，以保证读取的时候能够以正确的类型读取。同时返回对象实际类型。
        /// </summary>
        /// <param name="action"></param>
        /// <param name="value"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        protected Type CheckAndWriteType(String action, Object value, Type type)
        {
            if (type == null && value == null) return null;

            if (type == null || type.IsInterface || type.IsAbstract || type == typeof(Object))
            {
                type = value.GetType();
                WriteLog(action, type.Name);
                WriteObjectType(type);
            }

            return type;
        }

        /// <summary>
        /// 写对象类型
        /// </summary>
        /// <param name="type"></param>
        protected virtual void WriteObjectType(Type type)
        {
            Write(type);
        }
        #endregion

        #region 复杂对象
        /// <summary>
        /// 把对象写入数据流
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns>是否写入成功</returns>
        public Boolean WriteObject(Object value)
        {
            return WriteObject(value, null, WriteMember);
        }

        /// <summary>
        /// 把目标对象指定成员写入数据流，处理基础类型、特殊类型、基础类型数组、特殊类型数组，通过委托方法处理成员
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        public Boolean WriteObject(Object value, Type type, WriteObjectCallback callback)
        {
            if (callback == null) callback = WriteMember;

            // 检查IAcessor接口
            IAccessor accessor = value as IAccessor;
            if (accessor != null && accessor.Write(this)) return true;

            Boolean rs = WriteObjectWithEvent(value, type, callback);

            // 检查IAcessor接口
            if (accessor != null) rs = accessor.WriteComplete(this, rs);

            return rs;
        }

        Boolean WriteObjectWithEvent(Object value, Type type, WriteObjectCallback callback)
        {
            // 事件
            WriteObjectEventArgs e = null;
            if (OnObjectWriting != null)
            {
                e = new WriteObjectEventArgs(value, type, callback);

                OnObjectWriting(this, e);

                // 事件处理器可能已经成功写入对象
                if (e.Success) return true;

                // 事件里面有可能改变了参数
                value = e.Value;
                type = e.Type;
                callback = e.Callback;
            }

            Boolean rs = OnWriteObject(value, type, callback);

            // 事件
            if (OnObjectWrited != null)
            {
                if (e == null) e = new WriteObjectEventArgs(value, type, callback);
                e.Success = rs;

                OnObjectWrited(this, e);

                // 事件处理器可以影响结果
                rs = e.Success;
            }

            return rs;
        }

        /// <summary>
        /// 把目标对象指定成员写入数据流，处理基础类型、特殊类型、基础类型数组、特殊类型数组，通过委托方法处理成员
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        protected virtual Boolean OnWriteObject(Object value, Type type, WriteObjectCallback callback)
        {
            //! 2011-05-27 17:33
            //! 精确类型，直接写入值
            //! 未知类型，写对象引用，写类型，写对象

            if (IsExactType(type))
            {
                // 基本类型
                if (WriteValue(value, type)) return true;

                // 写入对象引用
                if (WriteObjRef(value)) return true;

                // 扩展类型
                if (WriteX(value, type)) return true;

                // 写入引用对象
                if (WriteRefObject(value, type, callback)) return true;
            }
            else
            {
                // 写入对象引用
                if (WriteObjRef(value)) return true;

                // 写对象类型时增加缩进，避免写顶级对象类型的对象引用时无法写入（Depth=1的对象是不写对象引用的）
                Depth++;
                type = CheckAndWriteType("WriteObjectType", value, type);
                Depth--;

                // 基本类型
                if (WriteValue(value, type)) return true;

                // 扩展类型
                if (WriteX(value, type)) return true;

                // 写入引用对象
                if (WriteRefObject(value, type, callback)) return true;
            }

            return true;
        }

        /// <summary>
        /// 写入引用对象
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        protected virtual Boolean WriteRefObject(Object value, Type type, WriteObjectCallback callback)
        {
            //  type = CheckAndWriteType("WriteRefObjectType", value, type);

            // 字典
            if (typeof(IDictionary).IsAssignableFrom(type))
            {
                WriteLog("WriteDictionary", type.Name);

                if (WriteDictionary(value as IDictionary, type, callback)) return true;
            }

            // 枚举
            if (typeof(IEnumerable).IsAssignableFrom(type))
            {
                WriteLog("WriteEnumerable", type.Name);

                if (WriteEnumerable(value as IEnumerable, type, callback)) return true;
            }

            // 可序列化接口
            if (WriteSerializable(value, type, callback)) return true;

            // 复杂类型，处理对象成员
            if (WriteCustomObject(value, type, callback)) return true;

            return WriteUnKnown(value, type, callback);
        }

        List<Object> objRefs = new List<Object>();

        /// <summary>
        /// 写入对象引用。
        /// </summary>
        /// <param name="value">对象</param>
        /// <returns>是否写入成功</returns>
        public Boolean WriteObjRef(Object value)
        {
            if (!Settings.UseObjRef) return false;

            if (value == null)
            {
                WriteLog("WriteObjRef", "null");

                // 顶级不需要
                if (Depth > 1) OnWriteObjRefIndex(0);
                return true;
            }

            // 在对象引用集合中找该对象
            Int32 index = objRefs.IndexOf(value);

            // 如果没找到，添加，返回false，通知上层继续处理
            if (index < 0)
            {
                objRefs.Add(value);

                WriteLog("AddObjRef", objRefs.Count, value.ToString(), value.GetType().Name);

                // 写入引用计数
                if (Depth > 1) OnWriteObjRefIndex(objRefs.Count);

                return false;
            }

            WriteLog("WriteObjRef", index + 1, value.ToString(), value.GetType().Name);

            // 如果找到，写入对象引用计数，返回true，通知上层不要再处理该对象，避免重写写入对象
            OnWriteObjRefIndex(index + 1);

            return true;
        }

        /// <summary>
        /// 写对象引用计数
        /// </summary>
        /// <param name="index"></param>
        protected virtual void OnWriteObjRefIndex(Int32 index)
        {
            Write(index);
        }
        #endregion

        #region 自定义对象
        /// <summary>
        /// 写对象成员
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        public virtual Boolean WriteCustomObject(Object value, Type type, WriteObjectCallback callback)
        {
            if (value == null) return true;
            //if (type == null) type = value.GetType();
            //  type = CheckAndWriteType("WriteCustomObjectType", value, type);

            IObjectMemberInfo[] mis = GetMembers(type, value);
            if (mis == null || mis.Length < 1) return true;

            for (int i = 0; i < mis.Length; i++)
            {
                Depth++;
                WriteLog("WriteMember", mis[i].Name, mis[i].Type.Name);

                if (!WriteMember(value, mis[i].Type, mis[i], i, callback)) return false;
                Depth--;
            }

            return true;
        }

        /// <summary>
        /// 写入成员
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="member">成员</param>
        /// <param name="index">成员索引</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        protected Boolean WriteMember(Object value, Type type, IObjectMemberInfo member, Int32 index, WriteObjectCallback callback)
        {
            //type = CheckAndWriteType(value, type);

#if !DEBUG
            try
#endif
            {
                // 写入成员前
                WriteMemberEventArgs e = null;
                if (OnMemberWriting != null)
                {
                    e = new WriteMemberEventArgs(value, type, member, index, callback);

                    OnMemberWriting(this, e);

                    // 事件处理器可能已经成功写入对象
                    if (e.Success) return true;

                    // 事件里面有可能改变了参数
                    value = e.Value;
                    type = e.Type;
                    member = e.Member;
                    index = e.Index;
                    callback = e.Callback;
                }

                Boolean rs = OnWriteMember(value, type, member, index, callback);

                // 写入成员后
                if (OnMemberWrited != null)
                {
                    e = new WriteMemberEventArgs(value, type, member, index, callback);
                    e.Success = rs;

                    OnMemberWrited(this, e);

                    // 事件处理器可以影响结果
                    rs = e.Success;
                }

                return rs;
            }
#if !DEBUG
            catch (Exception ex)
            {
                throw new XSerializationException(member, ex);
            }
#endif
        }

        /// <summary>
        /// 写入成员
        /// </summary>
        /// <param name="value">要写入的对象</param>
        /// <param name="type">要写入的对象类型</param>
        /// <param name="member">成员</param>
        /// <param name="index">成员索引</param>
        /// <param name="callback">处理成员的方法</param>
        /// <returns>是否写入成功</returns>
        protected virtual Boolean OnWriteMember(Object value, Type type, IObjectMemberInfo member, Int32 index, WriteObjectCallback callback)
        {
            Object obj = member[value];

            //type = CheckAndWriteType("WriteMemberType", obj, type);

            //if (type == typeof(Object) && obj != null)
            //{
            //    type = obj.GetType();
            //    WriteLog("WriteMemberType", type.Name);
            //    Write(type);
            //}
            return callback(this, obj, type, callback);
        }

        private static Boolean WriteMember(IWriter writer, Object value, Type type, WriteObjectCallback callback)
        {
            return writer.WriteObject(value, type, callback);
        }
        #endregion

        #region 事件
        /// <summary>
        /// 写对象前触发。
        /// </summary>
        public event EventHandler<WriteObjectEventArgs> OnObjectWriting;

        /// <summary>
        /// 写对象后触发。
        /// </summary>
        public event EventHandler<WriteObjectEventArgs> OnObjectWrited;

        /// <summary>
        /// 写成员前触发。
        /// </summary>
        public event EventHandler<WriteMemberEventArgs> OnMemberWriting;

        /// <summary>
        /// 写成员后触发。
        /// </summary>
        public event EventHandler<WriteMemberEventArgs> OnMemberWrited;

        /// <summary>
        /// 写字典项前触发。
        /// </summary>
        public event EventHandler<WriteDictionaryEventArgs> OnDictionaryWriting;

        /// <summary>
        /// 写字典项后触发。
        /// </summary>
        public event EventHandler<WriteDictionaryEventArgs> OnDictionaryWrited;

        /// <summary>
        /// 写枚举项前触发。
        /// </summary>
        public event EventHandler<WriteItemEventArgs> OnItemWriting;

        /// <summary>
        /// 写枚举项后触发。
        /// </summary>
        public event EventHandler<WriteItemEventArgs> OnItemWrited;
        #endregion

        #region 方法
        /// <summary>
        /// 写入大小
        /// </summary>
        /// <param name="size"></param>
        protected virtual void WriteSize(Int32 size)
        {
            if (!UseSize) return;

            WriteLog("WriteSize", size);

            Write(size);
        }

        /// <summary>
        /// 写入长度
        /// </summary>
        /// <param name="lengths"></param>
        protected virtual void WriteLengths(string lengths)
        {
            //if (!UseSize) return;

            WriteLog("WriteLengths", lengths);

            Write(lengths);
        }

        /// <summary>
        /// 刷新缓存中的数据
        /// </summary>
        public virtual void Flush()
        {
            Stream.Flush();
        }

        /// <summary>
        /// 如果设置了自动刷新缓存，该方面将会调用Flush
        /// </summary>
        protected void AutoFlush()
        {
            if (Settings.AutoFlush) Flush();
        }

        /// <summary>
        /// 重置
        /// </summary>
        public override void Reset()
        {
            objRefs.Clear();

            base.Reset();
        }

        /// <summary>
        /// 输出数据转为字节数组
        /// </summary>
        /// <returns></returns>
        public virtual Byte[] ToArray()
        {
            Flush();

            Stream stream = Stream;
            if (stream is MemoryStream) return (stream as MemoryStream).ToArray();

            if (!stream.CanRead) return null;

            // 移动指针到开头
            if (stream.CanSeek) stream.Seek(0, SeekOrigin.Begin);

            // 把数据复制出来
            MemoryStream ms = new MemoryStream();
            Byte[] buffer = new Byte[64];
            Int32 index = 0;
            while (true)
            {
                Int32 count = stream.Read(buffer, index, buffer.Length);
                if (count <= 0) break;

                ms.Write(buffer, 0, count);

                index += count;
            }

            return ms.ToArray();
        }

        /// <summary>
        /// 已重载。
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            Byte[] buffer = ToArray();
            if (buffer == null || buffer.Length < 1) return base.ToString();

            return Settings.Encoding.GetString(buffer);
        }
        #endregion
    }
}