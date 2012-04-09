namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Xml;

    public sealed class AppConfig
    {
        private string mi5qIK3te;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public AppConfig()
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8256));
            string str2 = AppDomain.CurrentDomain.SetupInformation.ConfigurationFile.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x826e), "");
            if (File.Exists(path))
            {
                this.mi5qIK3te = path;
            }
            else
            {
                if (!File.Exists(str2))
                {
                    throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8280));
                }
                this.mi5qIK3te = str2;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public AppConfig(string configFilePath)
        {
            this.mi5qIK3te = configFilePath;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string AppConfigGet(string keyName)
        {
            string str = string.Empty;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(this.mi5qIK3te);
                XmlNodeList elementsByTagName = document.GetElementsByTagName(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x82ec));
                for (int i = 0; i < elementsByTagName.Count; i++)
                {
                    XmlAttribute attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x82f6)];
                    if ((attribute != null) && (attribute.Value == keyName))
                    {
                        attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8300)];
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            catch
            {
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void AppConfigSet(string keyName, string keyValue)
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.mi5qIK3te);
            XmlNodeList elementsByTagName = document.GetElementsByTagName(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x82ca));
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                XmlAttribute attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x82d4)];
                if ((attribute != null) && (attribute.Value == keyName))
                {
                    attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x82de)];
                    if (attribute != null)
                    {
                        attribute.Value = keyValue;
                        break;
                    }
                }
            }
            document.Save(this.mi5qIK3te);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetConnectionString(string keyName)
        {
            string str = string.Empty;
            try
            {
                XmlDocument document = new XmlDocument();
                document.Load(this.mi5qIK3te);
                XmlNodeList elementsByTagName = document.GetElementsByTagName(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x83ba));
                for (int i = 0; i < elementsByTagName.Count; i++)
                {
                    XmlAttribute attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x83c4)];
                    if ((attribute != null) && (attribute.Value == keyName))
                    {
                        attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x83d0)];
                        if (attribute != null)
                        {
                            return attribute.Value;
                        }
                    }
                }
            }
            catch
            {
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public DatabaseInfo GetDatabaseInfo(string keyName)
        {
            return new DatabaseInfo(this.GetConnectionString(keyName));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public string GetSubValue(string keyName, string subKeyName)
        {
            string[] strArray = this.AppConfigGet(keyName).ToLower().Split(new char[] { ';' });
            for (int i = 0; i < strArray.Length; i++)
            {
                if (strArray[i].ToLower().IndexOf(subKeyName.ToLower()) >= 0)
                {
                    int index = strArray[i].IndexOf(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x830e));
                    return strArray[i].Substring(index + 1);
                }
            }
            return string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetConnectionString(string keyName, string keyValue)
        {
            XmlDocument document = new XmlDocument();
            document.Load(this.mi5qIK3te);
            XmlNodeList elementsByTagName = document.GetElementsByTagName(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8380));
            for (int i = 0; i < elementsByTagName.Count; i++)
            {
                XmlAttribute attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x838a)];
                if ((attribute != null) && (attribute.Value == keyName))
                {
                    attribute = elementsByTagName[i].Attributes[kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8396)];
                    if (attribute != null)
                    {
                        attribute.Value = keyValue;
                        break;
                    }
                }
            }
            document.Save(this.mi5qIK3te);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SetDatabaseInfo(string keyName, DatabaseInfo databaseInfo)
        {
            this.SetConnectionString(keyName, databaseInfo.ConnectionString);
        }

        public string AppName
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AppConfigGet(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8342));
            }
        }

        public string HWSecurity
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AppConfigGet(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8314));
            }
        }

        public string Manufacturer
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AppConfigGet(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8364));
            }
        }

        public string System_ID
        {
            [MethodImpl(MethodImplOptions.NoInlining)]
            get
            {
                return this.AppConfigGet(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x832c));
            }
        }
    }
}

