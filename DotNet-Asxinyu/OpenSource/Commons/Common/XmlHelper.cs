namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Data;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Xml;
    using System.Xml.Serialization;

    public class XmlHelper
    {
        protected XmlDocument objXmlDoc = new XmlDocument();
        protected string strXmlFile;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public XmlHelper(string XmlFile)
        {
            try
            {
                this.objXmlDoc.Load(XmlFile);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            this.strXmlFile = XmlFile;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Delete(string Node)
        {
            string xpath = Node.Substring(0, Node.LastIndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8678)));
            this.objXmlDoc.SelectSingleNode(xpath).RemoveChild(this.objXmlDoc.SelectSingleNode(Node));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object Deserialize(string path)
        {
            object obj3;
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    IFormatter formatter = new BinaryFormatter();
                    stream.Seek(0L, SeekOrigin.Begin);
                    object obj2 = formatter.Deserialize(stream);
                    stream.Close();
                    obj3 = obj2;
                }
            }
            catch
            {
                obj3 = null;
            }
            return obj3;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DataSet GetData(string XmlPathNode)
        {
            DataSet set = new DataSet();
            StringReader reader = new StringReader(this.objXmlDoc.SelectSingleNode(XmlPathNode).OuterXml);
            set.ReadXml(reader);
            return set;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertElement(string MainNode, string Element, string Content)
        {
            XmlNode node = this.objXmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = this.objXmlDoc.CreateElement(Element);
            newChild.InnerText = Content;
            node.AppendChild(newChild);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertElement(string MainNode, string Element, string Attrib, string AttribContent, string Content)
        {
            XmlNode node = this.objXmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = this.objXmlDoc.CreateElement(Element);
            newChild.SetAttribute(Attrib, AttribContent);
            newChild.InnerText = Content;
            node.AppendChild(newChild);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void InsertNode(string MainNode, string ChildNode, string Element, string Content)
        {
            XmlNode node = this.objXmlDoc.SelectSingleNode(MainNode);
            XmlElement newChild = this.objXmlDoc.CreateElement(ChildNode);
            node.AppendChild(newChild);
            XmlElement element2 = this.objXmlDoc.CreateElement(Element);
            element2.InnerText = Content;
            newChild.AppendChild(element2);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string Read(string XmlPathNode, string Attrib)
        {
            string str = "";
            try
            {
                XmlNode node = this.objXmlDoc.SelectSingleNode(XmlPathNode);
                str = Attrib.Equals("") ? node.InnerText : node.Attributes[Attrib].Value;
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Replace(string XmlPathNode, string Content)
        {
            this.objXmlDoc.SelectSingleNode(XmlPathNode).InnerText = Content;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Save()
        {
            try
            {
                this.objXmlDoc.Save(this.strXmlFile);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            this.objXmlDoc = null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Serialize(string path, object obj)
        {
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    IFormatter formatter = new BinaryFormatter();
                    formatter.Serialize(stream, obj);
                    stream.Close();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object XmlDeserialize(string path, Type type)
        {
            object obj3;
            try
            {
                using (Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    XmlSerializer serializer = new XmlSerializer(type);
                    stream.Seek(0L, SeekOrigin.Begin);
                    object obj2 = serializer.Deserialize(stream);
                    stream.Close();
                    obj3 = obj2;
                }
            }
            catch
            {
                obj3 = null;
            }
            return obj3;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool XmlSerialize(string path, object obj, Type type)
        {
            try
            {
                if (!File.Exists(path))
                {
                    FileInfo info = new FileInfo(path);
                    if (!info.Directory.Exists)
                    {
                        Directory.CreateDirectory(info.Directory.FullName);
                    }
                }
                using (Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    new XmlSerializer(type).Serialize(stream, obj);
                    stream.Close();
                }
                return true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return false;
            }
        }
    }
}

