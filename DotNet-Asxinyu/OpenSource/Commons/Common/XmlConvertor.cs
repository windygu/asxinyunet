namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public sealed class XmlConvertor
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private XmlConvertor()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ObjectToXml(object obj, bool toBeIndented)
        {
            if (null == obj)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x58a4));
            }
            UTF8Encoding encoding = new UTF8Encoding(false);
            XmlSerializer serializer = new XmlSerializer(obj.GetType());
            MemoryStream w = new MemoryStream();
            XmlTextWriter writer = new XmlTextWriter(w, encoding) {
                Formatting = toBeIndented ? Formatting.Indented : Formatting.None
            };
            try
            {
                serializer.Serialize((XmlWriter) writer, obj);
            }
            catch (InvalidOperationException)
            {
                throw new InvalidOperationException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x58ae));
            }
            finally
            {
                writer.Close();
            }
            return encoding.GetString(w.ToArray());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object XmlToObject(string xml, Type type)
        {
            if (null == xml)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5850));
            }
            if (null == type)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x585a));
            }
            object obj2 = null;
            XmlSerializer serializer = new XmlSerializer(type);
            StringReader input = new StringReader(xml);
            XmlReader xmlReader = new XmlTextReader(input);
            try
            {
                obj2 = serializer.Deserialize(xmlReader);
            }
            catch (InvalidOperationException exception)
            {
                throw new InvalidOperationException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5866), exception);
            }
            finally
            {
                xmlReader.Close();
            }
            return obj2;
        }
    }
}

