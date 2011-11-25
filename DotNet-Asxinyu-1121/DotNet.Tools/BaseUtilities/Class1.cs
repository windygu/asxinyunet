using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
namespace DotNet.Tools.BaseUtilities
{
    class Class1
    {
        #region XML序列化
        /// <summary>
        /// 读取XML文件，反序列化为对象
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="t">对象</param>
        /// <param name="fileName">xml文件名</param>
        /// <returns>反序列化的对象</returns>
        public static T ReadXMLFileToType<T>(string xmlFileName)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(xmlFileName, FileMode.Open, FileAccess.Read);
            return (T)ser.Deserialize(fileStream);
        }

        /// <summary>
        /// 序列化对象，保存为XML文件，前缀为空
        /// </summary>
        /// <param name="t">对象类型</param>
        /// <param name="s">对象序列化后的Xml文件</param>
        public static void SaveTypeToXmlFile<T>(T t, string xmlFile)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            FileStream fileStream = new FileStream(xmlFile, FileMode.Create, FileAccess.Write);
            ser.Serialize(fileStream, t);
            fileStream.Close();
        }
        #endregion

        #region 二进制序列化
        /// <summary>
        /// 二进制序列化,将对象保存为文件
        /// </summary>
        private static void BinarySerialize<T>(T t, string fileName)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter formatter = new BinaryFormatter();
            FileStream fileStream = File.Create(fileName);
            formatter.Serialize(fileStream, t);
            fileStream.Close();
        }
        /// <summary>
        /// 二进制反序列化,将文件读取为对象
        /// </summary>
        private static T BinaryDeserialize<T>(string fileName)
        {
            System.Runtime.Serialization.Formatters.Binary.BinaryFormatter derializer = new BinaryFormatter();
            FileStream fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read, FileShare.Read);
            T t = (T)derializer.Deserialize(fileStream);
            fileStream.Close();
            return t;
        }
        #endregion
    }
}
