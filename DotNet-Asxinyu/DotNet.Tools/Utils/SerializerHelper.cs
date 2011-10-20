namespace Utils
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Runtime.Serialization.Formatters.Soap;
    using System.Xml.Serialization;

    /// <summary><para>　</para>
    /// 类名：常用工具类——序列化与反序列化类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>-------------------------------------------------------------------------------------------------------------</para><para>　XmlSerializer：XML序列化：序列化一个对象并保存入文件，与DeXmlSerializer匹配使用</para><para>　XmlDeSerializer：XML反序列化：从指定文件中读取内容并进行反序列化，与XmlSerializer匹配使用</para><para>　BinarySerializer：Binary序列化：将对象Binary序列化为Base64字符串，与BinaryDeSerializerObject匹配使用</para><para>　BinaryDeSerializer：Binary反序列化：将Base64字符串反序列化为Object对象，与BinarySerializerObject匹配使用</para><para>　SoapSerializer：Soap序列化：将对象用SOAP方式序列化</para><para>　SoapDeSerializer：Soap反序列化：将序列化后的数据反序列化为对象</para></summary>
    public class SerializerHelper
    {
        /// <summary>Binary反序列化：将Base64字符串反序列化为Object对象，与BinarySerializerObject匹配使用</summary>
        /// <param name="Base64Str">要反序列化的对象</param>
        /// <param name="IsGZip">是否经过压缩过</param>
        /// <returns></returns>
        public static object BinaryDeSerializer(string Base64Str, bool IsGZip)
        {
            MemoryStream serializationStream = null;
            try
            {
                BinaryFormatter formatter;
                byte[] buffer = Convert.FromBase64String(Base64Str);
                goto Label_0049;
            Label_000D:
                if ((((uint) IsGZip) | 0xff) == 0) goto Label_0036;
            Label_0025:
                formatter = new BinaryFormatter();
                serializationStream = new MemoryStream(buffer, 0, buffer.Length);
            Label_0036:
                return formatter.Deserialize(serializationStream);
            Label_0040:
                buffer = GZipHelper.Decompress(buffer);
                goto Label_0025;
            Label_0049:
                if (IsGZip) goto Label_0040;
                goto Label_000D;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (serializationStream != null) serializationStream.Close();
            }
            return null;
        }

        /// <summary>Binary序列化：将对象Binary序列化为Base64字符串，与BinaryDeSerializerObject匹配使用</summary>
        /// <param name="SerialObject">要序列化的对象</param>
        /// <param name="IsGZip">是否经过GZip压缩</param>
        /// <returns></returns>
        public static string BinarySerializer(object SerialObject, bool IsGZip)
        {
            string str = "";
            MemoryStream serializationStream = null;
            try
            {
                byte[] buffer;
                BinaryFormatter formatter = new BinaryFormatter();
                goto Label_001D;
            Label_0010:
                return Convert.ToBase64String(buffer, 0, buffer.Length);
            Label_001D:
                serializationStream = new MemoryStream();
                formatter.Serialize(serializationStream, SerialObject);
                buffer = serializationStream.ToArray();
                if (!IsGZip) goto Label_0010;
                buffer = GZipHelper.Compress(buffer);
                if (0 != 0 || ((uint) IsGZip) - ((uint) IsGZip) <= uint.MaxValue) goto Label_0010;
                return str;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (serializationStream != null) serializationStream.Close();
            }
            return str;
        }

        /// <summary>Soap反序列化：将序列化后的数据反序列化为对象</summary>
        /// <param name="SerializedStr">要反序列化的数据</param>
        /// <param name="IsGZip">是否需要GZIP压缩</param>
        /// <returns></returns>
        public static object SoapDeSerializer(string SerializedStr, bool IsGZip)
        {
            object obj2 = null;
            MemoryStream serializationStream = null;
            try
            {
                SoapFormatter formatter;
                byte[] buffer = Convert.FromBase64String(SerializedStr);
                if (((uint) IsGZip) + ((uint) IsGZip) <= uint.MaxValue) goto Label_003E;
            Label_0023:
                formatter = new SoapFormatter();
                return formatter.Deserialize(serializationStream);
            Label_003E:
                while (IsGZip)
                {
                    buffer = GZipHelper.Decompress(buffer);
                    goto Label_0044;
                }
                if (0 == 0)
                {
                }
            Label_0044:
                serializationStream = new MemoryStream(buffer, 0, buffer.Length);
                if (((uint) IsGZip) + ((uint) IsGZip) >= 0) goto Label_0023;
                return obj2;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (serializationStream != null) serializationStream.Close();
            }
            return obj2;
        }

        /// <summary>Soap序列化：将对象用SOAP方式序列化</summary>
        /// <param name="Obj">要序列化的对象</param>
        /// <param name="IsGZip">是否需要GZIP压缩</param>
        /// <returns></returns>
        public static string SoapSerializer(object Obj, bool IsGZip)
        {
            MemoryStream serializationStream = null;
            try
            {
                SoapFormatter formatter;
                byte[] buffer;
                serializationStream = new MemoryStream();
                goto Label_003F;
            Label_0010:
                return Convert.ToBase64String(buffer);
            Label_0019:
                buffer = GZipHelper.Compress(buffer);
                goto Label_0010;
            Label_0022:
                if (IsGZip) goto Label_0019;
                if (((uint) IsGZip) + ((uint) IsGZip) >= 0) goto Label_0010;
            Label_003F:
                formatter = new SoapFormatter();
                formatter.Serialize(serializationStream, Obj);
                buffer = serializationStream.ToArray();
                goto Label_0022;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (serializationStream != null) serializationStream.Close();
            }
            return "";
        }

        /// <summary>XML反序列化：从指定文件中读取内容并进行反序列化，与XmlSerializer匹配使用</summary>
        /// <param name="Type">对象类型</param>
        /// <param name="FileName">文件</param>
        /// <returns></returns>
        public static object XmlDeSerializer(Type Type, string FileName)
        {
            FileStream stream = null;
            object obj2;
            try
            {
                stream = new FileStream(FileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                obj2 = new System.Xml.Serialization.XmlSerializer(Type).Deserialize(stream);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return obj2;
        }

        /// <summary>XML反序列化：将内容反序列化为对象</summary>
        /// <param name="Base64Str">序列化后的对象</param>
        /// <param name="IsGZip">是否是经过GZIP压缩过的数据</param>
        /// <param name="ObjType">序列化前的对象类型如：typeof(DataTable)</param>
        /// <returns></returns>
        public static object XmlDeSerializer(string Base64Str, bool IsGZip, Type ObjType)
        {
            MemoryStream stream = null;
            try
            {
                byte[] buffer = Convert.FromBase64String(Base64Str);
                while (0 == 0)
                {
                    if (IsGZip) goto Label_0045;
                Label_0012:
                    stream = new MemoryStream(buffer, 0, buffer.Length);
                    System.Xml.Serialization.XmlSerializer serializer = new System.Xml.Serialization.XmlSerializer(ObjType);
                Label_0024:
                    return serializer.Deserialize(stream);
                }
                if ((((uint) IsGZip) & 0) != 0) goto Label_0024;
            Label_0045:
                buffer = GZipHelper.Decompress(buffer);
                goto Label_0012;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return null;
        }

        /// <summary>XML序列化：将指定的对象序列化</summary>
        /// <param name="Obj">要序列化的对象</param>
        /// <param name="IsGZip">是否需要GZIP压缩</param>
        /// <returns></returns>
        public static string XmlSerializer(object Obj, bool IsGZip)
        {
            MemoryStream stream = null;
            try
            {
                System.Xml.Serialization.XmlSerializer serializer;
                byte[] buffer;
                stream = new MemoryStream();
                goto Label_002A;
            Label_0010:
                buffer = stream.ToArray();
                if (IsGZip) buffer = GZipHelper.Compress(buffer);
                return Convert.ToBase64String(buffer);
            Label_002A:
                serializer = new System.Xml.Serialization.XmlSerializer(Obj.GetType());
                do
                {
                    serializer.Serialize((Stream) stream, Obj);
                }
                while (0 != 0);
                goto Label_0010;
            }
            catch (Exception)
            {
            }
            finally
            {
                if (stream != null) stream.Close();
            }
            return "";
        }

        /// <summary>XML序列化：序列化一个对象并保存入文件，与DeXmlSerializer匹配使用</summary>
        /// <param name="Obj">要序列化的对象</param>
        /// <param name="FileName">保存到文件</param>
        public static void XmlSerializer(object Obj, string FileName)
        {
            FileStream stream = null;
            try
            {
                stream = new FileStream(FileName, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
                new System.Xml.Serialization.XmlSerializer(Obj.GetType()).Serialize((Stream) stream, Obj);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                if (stream != null) stream.Close();
            }
        }
    }
}
