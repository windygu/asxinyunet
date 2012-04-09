namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization;
    using System.Runtime.Serialization.Formatters.Binary;

    public sealed class IsolatedStorageHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDataTime()
        {
            string str;
            IsolatedStorageFile isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain | IsolatedStorageScope.User, (Type) null, (Type) null);
            if (isf.GetDirectoryNames(UIConstants.IsolatedStorageDirectoryName).Length == 0)
            {
                return string.Empty;
            }
            if (isf.GetFileNames(UIConstants.IsolatedStorage).Length == 0)
            {
                return string.Empty;
            }
            using (IsolatedStorageFileStream stream = new IsolatedStorageFileStream(UIConstants.IsolatedStorage, FileMode.OpenOrCreate, isf))
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    str = reader.ReadLine();
                }
            }
            if (!string.IsNullOrEmpty(str))
            {
                try
                {
                    str = EncodeHelper.DesDecrypt(str, UIConstants.IsolatedStorageEncryptKey);
                }
                catch
                {
                }
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object Load(string key)
        {
            object obj2;
            IsolatedStorageFile isf = null;
            IsolatedStorageFileStream serializationStream = null;
            try
            {
                isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain | IsolatedStorageScope.User, (Type) null, (Type) null);
                serializationStream = new IsolatedStorageFileStream(key, FileMode.Open, FileAccess.Read, isf) {
                    Position = 0L
                };
                obj2 = new BinaryFormatter().Deserialize(serializationStream);
            }
            catch (FileNotFoundException)
            {
                obj2 = null;
            }
            catch (SerializationException)
            {
                obj2 = null;
            }
            finally
            {
                if (null != isf)
                {
                    isf.Close();
                }
                if (null != serializationStream)
                {
                    serializationStream.Close();
                }
            }
            return obj2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Save(object objectToSave, string key)
        {
            IsolatedStorageFile isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain | IsolatedStorageScope.User, (Type) null, (Type) null);
            IsolatedStorageFileStream serializationStream = new IsolatedStorageFileStream(key, FileMode.Create, FileAccess.Write, isf);
            new BinaryFormatter().Serialize(serializationStream, objectToSave);
            serializationStream.Close();
            isf.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SaveDataTime()
        {
            StreamWriter writer;
            IsolatedStorageFileStream stream2;
            string strText = DateTime.Now.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xae9c));
            string str2 = GetDataTime().Trim();
            if (!string.IsNullOrEmpty(str2))
            {
                strText = str2 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaec6) + strText;
            }
            strText = EncodeHelper.DesEncrypt(strText, UIConstants.IsolatedStorageEncryptKey);
            string str3 = strText;
            IsolatedStorageFile isf = IsolatedStorageFile.GetStore(IsolatedStorageScope.Assembly | IsolatedStorageScope.Domain | IsolatedStorageScope.User, (Type) null, (Type) null);
            string[] directoryNames = isf.GetDirectoryNames(UIConstants.IsolatedStorageDirectoryName);
            IsolatedStorageFileStream stream = null;
            if (directoryNames.Length == 0)
            {
                isf.CreateDirectory(UIConstants.IsolatedStorageDirectoryName);
                using (stream2 = stream = new IsolatedStorageFileStream(UIConstants.IsolatedStorage, FileMode.Create, isf))
                {
                    using (writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(strText);
                    }
                }
            }
            else if (isf.GetFileNames(UIConstants.IsolatedStorage).Length == 0)
            {
                using (stream2 = stream = new IsolatedStorageFileStream(UIConstants.IsolatedStorage, FileMode.Create, isf))
                {
                    using (writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(strText);
                    }
                }
            }
            else
            {
                using (stream2 = stream = new IsolatedStorageFileStream(UIConstants.IsolatedStorage, FileMode.Open, isf))
                {
                    using (writer = new StreamWriter(stream))
                    {
                        writer.WriteLine(strText);
                    }
                }
            }
        }
    }
}

