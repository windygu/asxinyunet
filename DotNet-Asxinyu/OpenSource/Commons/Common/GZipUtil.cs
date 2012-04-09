namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Microsoft.Win32;
    using System;
    using System.Diagnostics;
    using System.IO;
    using System.IO.Compression;
    using System.Runtime.CompilerServices;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;

    public class GZipUtil
    {
        private static string 408MSTia8 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2b48);

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Compress(string text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(text);
            MemoryStream stream = new MemoryStream();
            using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true))
            {
                stream2.Write(bytes, 0, bytes.Length);
            }
            stream.Position = 0L;
            byte[] buffer = stream.ToArray();
            stream.Read(buffer, 0, buffer.Length);
            byte[] dst = new byte[buffer.Length + 4];
            Buffer.BlockCopy(buffer, 0, dst, 4, buffer.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(bytes.Length), 0, dst, 0, 4);
            return Convert.ToBase64String(dst);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] Compress(byte[] bytData)
        {
            using (MemoryStream stream = GZip<MemoryStream>(new MemoryStream(bytData), CompressionMode.Compress))
            {
                return stream.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException();
            }
            byte[] buffer = null;
            FileStream stream = null;
            FileStream stream2 = null;
            try
            {
                stream = new FileStream(sourceFile, FileMode.Open, FileAccess.Read, FileShare.Read);
                buffer = new byte[stream.Length];
                if (stream.Read(buffer, 0, buffer.Length) != buffer.Length)
                {
                    throw new ApplicationException();
                }
                stream2 = new FileStream(destinationFile, FileMode.OpenOrCreate, FileAccess.Write);
                new GZipStream(stream2, CompressionMode.Compress, true).Write(buffer, 0, buffer.Length);
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (stream2 != null)
                {
                    stream2.Close();
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompressRAR(string patch, string rarPatch, string rarName)
        {
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(408MSTia8);
                string str = key.GetValue("").ToString();
                key.Close();
                str = str.Substring(1, str.Length - 7);
                Directory.CreateDirectory(patch);
                string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2ae2) + rarName + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2af2) + patch + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2af8);
                ProcessStartInfo info = new ProcessStartInfo {
                    FileName = str,
                    Arguments = str2,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    WorkingDirectory = rarPatch
                };
                Process process = new Process {
                    StartInfo = info
                };
                process.Start();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] Decompress(byte[] bytData)
        {
            using (MemoryStream stream = GZip<MemoryStream>(new MemoryStream(bytData), CompressionMode.Decompress))
            {
                return stream.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void DecompressFile(string sourceFile, string destinationFile)
        {
            if (!File.Exists(sourceFile))
            {
                throw new FileNotFoundException();
            }
            FileStream stream = null;
            FileStream stream2 = null;
            GZipStream stream3 = null;
            byte[] buffer = null;
            try
            {
                int num4;
                bool flag;
                stream = new FileStream(sourceFile, FileMode.Open);
                stream3 = new GZipStream(stream, CompressionMode.Decompress, true);
                buffer = new byte[4];
                int num = ((int) stream.Length) - 4;
                stream.Position = num;
                stream.Read(buffer, 0, 4);
                stream.Position = 0L;
                byte[] buffer2 = new byte[BitConverter.ToInt32(buffer, 0) + 100];
                int offset = 0;
                int count = 0;
                goto Label_00B8;
            Label_0083:
                num4 = stream3.Read(buffer2, offset, 100);
                if (num4 == 0)
                {
                    goto Label_00C0;
                }
                offset += num4;
                count += num4;
            Label_00B8:
                flag = true;
                goto Label_0083;
            Label_00C0:
                stream2 = new FileStream(destinationFile, FileMode.Create);
                stream2.Write(buffer2, 0, count);
                stream2.Flush();
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (stream3 != null)
                {
                    stream3.Close();
                }
                if (stream2 != null)
                {
                    stream2.Close();
                }
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool Exists()
        {
            return !string.IsNullOrEmpty(Registry.LocalMachine.OpenSubKey(408MSTia8).GetValue("").ToString());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static T GZip<T>(Stream stream, CompressionMode mode) where T: Stream
        {
            T local2;
            byte[] array = new byte[0x1000];
            T local = default(T);
            using (Stream stream2 = new GZipStream(stream, mode))
            {
                bool flag;
                goto Label_0070;
            Label_0029:
                Array.Clear(array, 0, array.Length);
                int count = stream2.Read(array, 0, array.Length);
                if (count > 0)
                {
                    local.Write(array, 0, count);
                }
                else
                {
                    goto Label_0078;
                }
            Label_0070:
                flag = true;
                goto Label_0029;
            Label_0078:
                local2 = local;
            }
            return local2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GZipToObject(byte[] byteArray)
        {
            return XPOfx7u7N(Decompress(byteArray));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static byte[] mUvqAX6rk(object obj1)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, obj1);
                return stream.ToArray();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ObjectToGZip(object obj)
        {
            return Compress(mUvqAX6rk(obj));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Uncompress(string compressedText)
        {
            byte[] buffer = Convert.FromBase64String(compressedText);
            MemoryStream stream = new MemoryStream();
            int num = BitConverter.ToInt32(buffer, 0);
            stream.Write(buffer, 4, buffer.Length - 4);
            byte[] buffer2 = new byte[num];
            stream.Position = 0L;
            new GZipStream(stream, CompressionMode.Decompress).Read(buffer2, 0, buffer2.Length);
            return Encoding.UTF8.GetString(buffer2);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string UnCompressRAR(string unRarPatch, string rarPatch, string rarName)
        {
            unRarPatch = unRarPatch.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2b02), "");
            rarPatch = rarPatch.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2b12), "");
            try
            {
                RegistryKey key = Registry.LocalMachine.OpenSubKey(408MSTia8);
                string str = key.GetValue("").ToString();
                key.Close();
                if (!Directory.Exists(unRarPatch))
                {
                    Directory.CreateDirectory(unRarPatch);
                }
                string str2 = string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2b22), rarName, unRarPatch);
                ProcessStartInfo info = new ProcessStartInfo {
                    FileName = str,
                    Arguments = str2,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    WorkingDirectory = rarPatch
                };
                Process process = new Process {
                    StartInfo = info
                };
                process.Start();
                process.WaitForExit();
                process.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return unRarPatch;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static object XPOfx7u7N(byte[] buffer1)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(buffer1))
            {
                return formatter.Deserialize(stream);
            }
        }
    }
}

