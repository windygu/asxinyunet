namespace WHC.OrderWater.Commons
{
    using System;
    using System.IO;
    using System.Reflection;
    using System.Runtime.CompilerServices;

    public sealed class XmlUtils
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private XmlUtils()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object LoadObjectFromXml(string path, Type type)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return XmlConvertor.XmlToObject(reader.ReadToEnd(), type);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReadFile(string path)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                return reader.ReadToEnd();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ReadFileFromEmbedded(string fileWholeName)
        {
            using (TextReader reader = new StreamReader(Assembly.GetExecutingAssembly().GetManifestResourceStream(fileWholeName)))
            {
                return reader.ReadToEnd();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SaveObjectToXml(string path, object obj)
        {
            string str = XmlConvertor.ObjectToXml(obj, true);
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.Write(str);
            }
        }
    }
}

