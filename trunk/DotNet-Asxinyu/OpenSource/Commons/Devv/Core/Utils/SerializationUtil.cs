namespace Devv.Core.Utils
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class SerializationUtil
    {
        private SerializationUtil()
        {
        }

        public static void CopyObjectProperties(object source, object target)
        {
            foreach (PropertyInfo info in target.GetType().GetProperties())
            {
                if (info.CanWrite)
                {
                    PropertyInfo property = source.GetType().GetProperty(info.Name);
                    if (property != null)
                    {
                        info.SetValue(RuntimeHelpers.GetObjectValue(target), RuntimeHelpers.GetObjectValue(property.GetValue(RuntimeHelpers.GetObjectValue(source), null)), null);
                    }
                }
            }
        }

        public static object Deserialize(string xml, Type type)
        {
            return Deserialize(xml, type, Encoding.UTF8, type.Name);
        }

        public static object Deserialize(string xml, Type type, Encoding enc, string ns)
        {
            if (IOUtil.ValidatePhysicalPath(xml))
            {
                xml = IOUtil.ReadFile(xml, enc);
            }
            XmlSerializer serializer = new XmlSerializer(type);
            MemoryStream w = new MemoryStream(DataUtil.StringToUTF8ByteArray(xml));
            XmlTextWriter writer = new XmlTextWriter(w, enc);
            object objectValue = RuntimeHelpers.GetObjectValue(serializer.Deserialize(w));
            w.Dispose();
            return objectValue;
        }

        public static string Serialize(object obj)
        {
            return Serialize(RuntimeHelpers.GetObjectValue(obj), Encoding.UTF8, typeof(object).Name);
        }

        public static string Serialize(object obj, Encoding enc, string ns)
        {
            MemoryStream w = new MemoryStream();
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            XmlTextWriter writer = new XmlTextWriter(w, enc);
            serializer.Serialize((XmlWriter) writer, RuntimeHelpers.GetObjectValue(obj));
            w = (MemoryStream) writer.BaseStream;
            string str = DataUtil.UTF8ByteArrayToString(w.ToArray());
            w.Dispose();
            return str;
        }
    }
}
