namespace EntLib.Controls.WinForm
{
    using System;
    using System.IO;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml;

    public static class XMLConfigure
    {
        private static XmlNode ParentNode;
        private static int PathDepth = 0;
        private static string[] PathNode = null;

        private static XmlDocument CheckFileExit(string XMLFile)
        {
            XmlDocument document = new XmlDocument();
            if (File.Exists(XMLFile))
            {
                try
                {
                    document.Load(XMLFile);
                    return document;
                }
                catch (Exception exception)
                {
                    throw new Exception("载入XML文件[" + XMLFile + "]失败.\r\n" + exception.Message);
                }
            }
            XmlDeclaration newChild = document.CreateXmlDeclaration("1.0", "gb2312", null);
            document.AppendChild(newChild);
            XmlElement element = document.CreateElement("", "打印项目模板", "");
            document.AppendChild(element);
            document.Save(XMLFile);
            return document;
        }

        private static void CheckPath(XmlDocument myDoc, string Path)
        {
            if (PathNode == null)
            {
                PathNode = Path.Split(new char[] { '/' });
                PathDepth = 0;
            }
            if (PathDepth < PathNode.Length)
            {
                string path = GetPath(++PathDepth);
                string elementName = PathNode[PathDepth - 1];
                XmlNode node = FindNode(myDoc, path);
                if (node == null)
                {
                    XmlNode newChild = InsertXmlElement(myDoc, elementName, null);
                    ParentNode.AppendChild(newChild);
                    ParentNode = FindNode(myDoc, path);
                }
                else
                    ParentNode = node;
                CheckPath(myDoc, path);
            }
        }

        public static bool DeleteNode(string XMLFile, string Path)
        {
            XmlDocument myDoc = CheckFileExit(XMLFile);
            XmlNode oldChild = FindNode(myDoc, Path);
            if (oldChild != null)
            {
                if (oldChild.ParentNode != null)
                    oldChild.ParentNode.RemoveChild(oldChild);
                else
                    myDoc.RemoveChild(oldChild);
                myDoc.Save(XMLFile);
            }
            return true;
        }

        private static object DeserializeBinary(byte[] buf)
        {
            MemoryStream serializationStream = new MemoryStream(buf);
            serializationStream.Position = 0;
            object obj2 = new BinaryFormatter().Deserialize(serializationStream);
            serializationStream.Close();
            return obj2;
        }

        private static XmlNode FindNode(XmlDocument myDoc, string Path)
        {
            XmlNode node = myDoc.SelectSingleNode(Path);
            if (node != null) return node;
            return null;
        }

        private static XmlNodeList FindNodes(XmlDocument myDoc, string Path)
        {
            XmlNodeList list = myDoc.SelectNodes(Path);
            if (list != null) return list;
            return null;
        }

        private static string GetPath(int depth)
        {
            string str = "";
            for (int i = 0; i < depth && i < PathNode.Length; i++)
            {
                str = str + PathNode[i] + "/";
            }
            return str.Substring(0, str.Length - 1);
        }

        private static XmlNode InsertXmlElement(XmlDocument myDoc, string ElementName, string Text)
        {
            if (ElementName != "")
            {
                XmlElement element = myDoc.CreateElement("", ElementName, "");
                element.InnerText = Text;
                return element;
            }
            return null;
        }

        private static string Object2String(object Obj)
        {
            StringBuilder builder = new StringBuilder();
            foreach (byte num in SerializeBinary(Obj))
            {
                builder.Append(((int) num).ToString());
                builder.Append(",");
            }
            return builder.Remove(builder.Length - 1, 1).ToString();
        }

        public static object ReadNode(string XMLFile, string Path, object DefaultValue) { return String2Object(ReadNode(XMLFile, Path, Object2String(DefaultValue))); }

        public static string ReadNode(string XMLFile, string Path, string DefaultValue)
        {
            XmlNode node = FindNode(CheckFileExit(XMLFile), Path);
            if (node != null) return node.InnerText;
            WriteNode(XMLFile, Path, DefaultValue);
            return DefaultValue;
        }

        public static string[] ReadNodes(string XMLFile, string Path)
        {
            string str = "";
            foreach (XmlNode node2 in FindNode(CheckFileExit(XMLFile), Path).ChildNodes)
            {
                if (!(node2.Name == "DefaultProject")) str = str + node2.Name.ToString() + ",";
            }
            return str.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
        }

        private static byte[] SerializeBinary(object request)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            MemoryStream serializationStream = new MemoryStream();
            formatter.Serialize(serializationStream, request);
            return serializationStream.GetBuffer();
        }

        private static object String2Object(string Value)
        {
            string[] strArray = Value.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            byte[] buf = new byte[strArray.Length];
            for (int i = 0; i < buf.Length; i++)
            {
                buf[i] = Convert.ToByte(strArray[i]);
            }
            return DeserializeBinary(buf);
        }

        private static bool UpdateXmlNode(string TextName, XmlNode XNe)
        {
            if (XNe != null)
            {
                XNe.InnerText = TextName;
                return true;
            }
            return false;
        }

        public static void WriteNode(string XMLFile, string Path, object Value) { WriteNode(XMLFile, Path, Object2String(Value)); }

        public static void WriteNode(string XMLFile, string Path, string Value)
        {
            XmlDocument myDoc = CheckFileExit(XMLFile);
            PathNode = null;
            PathDepth = 0;
            ParentNode = null;
            CheckPath(myDoc, Path);
            XmlNode xNe = FindNode(myDoc, Path);
            if (xNe != null) UpdateXmlNode(Value, xNe);
            myDoc.Save(XMLFile);
        }
    }
}
