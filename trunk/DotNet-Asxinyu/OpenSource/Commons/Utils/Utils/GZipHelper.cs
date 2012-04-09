namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    /// <summary><para>　</para>
    /// 类名：常用工具类——GZip压缩与解压缩类
    /// <para>创建时间：2009-12-10</para><para>创建人：月亮  http://ycmoon.008.net  QQ:817647</para><para>最后修改时间：2009-12-10</para><para>----------------------------------------------------------------</para><para>　Compress：(1)：对目标文件(夹)进行压缩，将压缩结果保存为指定文件</para><para>　Compress：(2)：对同目录下的多个文件进行压缩，将压缩结果保存为指定文件</para><para>　Compress：(3)：压缩字节数组</para><para>　Compress：(4)：压缩流</para><para>　Decompress：(1)：对目标压缩文件解压缩，将内容解压缩到指定文件夹</para><para>　Decompress：(1)：解压获取二进制内容</para></summary>
    public class GZipHelper
    {
        /// <summary>默认扩展名</summary>
        public const string DefaultExtension = ".gz";
        /// <summary>解压缩最大单元长度</summary>
        public const int MaxUnitLength = 0x1000;

        /// <summary>压缩流</summary>
        /// <param name="stream">待压缩的流</param>
        /// <returns></returns>
        public static byte[] Compress(Stream stream)
        {
            byte[] buffer2;
            using (MemoryStream stream2 = new MemoryStream())
            {
                using (GZipStream stream3 = new GZipStream(stream2, CompressionMode.Compress, true))
                {
                    int num;
                    byte[] buffer = new byte[0x1000];
                    while ((num = stream.Read(buffer, 0, buffer.Length)) != 0)
                    {
                        stream3.Write(buffer, 0, num);
                    }
                    stream3.Close();
                    buffer2 = stream2.ToArray();
                }
            }
            return buffer2;
        }

        /// <summary>压缩字节数组</summary>
        /// <param name="buffer">待压缩的字节数组</param>
        /// <returns></returns>
        public static byte[] Compress(byte[] buffer) { return Compress(new MemoryStream(buffer)); }

        /// <summary>对同目录下的多个文件进行压缩，将压缩结果保存为指定文件</summary>
        /// <param name="fileNames">文件名数组</param>
        /// <param name="zipFile">压缩文件名</param>
        public static void Compress(string[] fileNames, string zipFile)
        {
            if (fileNames == null) return;
            List<GZipUnit> list = new List<GZipUnit>();
            string[] strArray = fileNames;
            int index = 0;
        Label_0021:
            if (index < strArray.Length)
            {
                while (true)
                {
                    string path = strArray[index];
                    list.Add(new GZipUnit(Path.GetFileName(path), File.ReadAllBytes(path)));
                    if (0 != 0) return;
                    if (((uint) index) + ((uint) index) >= 0)
                    {
                        index++;
                        goto Label_0021;
                    }
                }
            }
            xbbc02da781acbd1a(zipFile, list);
        }

        /// <summary>对目标文件(夹)进行压缩，将压缩结果保存为指定文件</summary>
        /// <param name="path">目标文件(夹)</param>
        /// <param name="zipFile">压缩文件名</param>
        public static void Compress(string path, string zipFile)
        {
            if (!File.Exists(path))
            {
                if (!Directory.Exists(path)) throw new FileNotFoundException("Not Found", path);
                List<GZipUnit> list3 = xd1e589c3e6c349cd(path, Path.GetDirectoryName(path));
                do
                {
                    xbbc02da781acbd1a(zipFile, list3);
                }
                while (0 != 0);
            }
            else
            {
                List<GZipUnit> list2 = new List<GZipUnit>();
                list2.Add(new GZipUnit(Path.GetFileName(path), File.ReadAllBytes(path)));
                List<GZipUnit> list = list2;
                xbbc02da781acbd1a(zipFile, list);
            }
        }

        /// <summary>解压获取二进制内容</summary>
        /// <param name="fileName">文件名</param>
        /// <returns></returns>
        public static byte[] Decompress(string fileName)
        {
            if (!File.Exists(fileName)) throw new FileNotFoundException("not found", fileName);
            return Decompress(File.ReadAllBytes(fileName));
        }

        /// <summary>解压获取二进制内容</summary>
        /// <param name="buffer">解压前二进制内容</param>
        /// <returns></returns>
        public static byte[] Decompress(byte[] buffer)
        {
            byte[] buffer3;
            if (buffer == null) return null;
            using (Stream stream = new MemoryStream(buffer))
            {
                List<byte> list = new List<byte>();
                using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress, true))
                {
                    int num;
                    byte[] buffer2 = new byte[0x1000];
                Label_0028:
                    if ((num = stream2.Read(buffer2, 0, buffer2.Length)) != 0) goto Label_0067;
                    goto Label_0082;
                Label_003A:
                    if (3 == 0) goto Label_0082;
                    for (int i = 0; i < num; i++)
                    {
                        list.Add(buffer2[i]);
                    }
                    goto Label_0028;
                Label_005E:
                    list.AddRange(buffer2);
                    goto Label_0028;
                Label_0067:
                    if (num == buffer2.Length) goto Label_005E;
                    goto Label_003A;
                }
            Label_0082:
                buffer3 = list.ToArray();
            }
            return buffer3;
        }

        /// <summary>对目标压缩文件解压缩，将内容解压缩到指定文件夹</summary>
        /// <param name="zipFile">压缩文件</param>
        /// <param name="dirPath">解压缩目录</param>
        public static void Decompress(string zipFile, string dirPath) { x495c2f7da5fba6d2(Decompress(zipFile), dirPath); }

        private static byte[] x32541aa2f39b1f2b(byte[] xf9a0d04800d70471, int xd4f974c06ffa392b, int x961016a387451f05)
        {
            List<byte> list;
            int num;
            if (xd4f974c06ffa392b <= xf9a0d04800d70471.Length - 1)
            {
                list = new List<byte>();
                num = xd4f974c06ffa392b;
            }
            else
            {
                if (0 == 0 && 0 != 0) goto Label_002F;
                return null;
            }
        Label_001B:
            while (num < xf9a0d04800d70471.Length)
            {
                if (num < xd4f974c06ffa392b + x961016a387451f05) goto Label_002F;
                break;
            }
            return list.ToArray();
        Label_002F:
            list.Add(xf9a0d04800d70471[num]);
            num++;
            goto Label_001B;
        }

        private static void x495c2f7da5fba6d2(byte[] x5cafa8d49ea71ea1, string xb12a62c5db500525)
        {
            using (List<GZipUnit>.Enumerator enumerator = xf76803be5e9ee2aa(x5cafa8d49ea71ea1).GetEnumerator())
            {
                GZipUnit unit;
                string str;
                string str2;
                goto Label_0055;
            Label_0011:
                if (!Directory.Exists(str2)) goto Label_006E;
            Label_0019:
                using (FileStream stream = new FileStream(str, FileMode.Create, FileAccess.Write))
                {
                    stream.Write(unit.Buffer, 0, unit.Buffer.Length);
                    stream.Close();
                    goto Label_0055;
                }
                if (2 != 0)
                {
                }
            Label_0055:
                if (enumerator.MoveNext()) goto Label_0079;
                if (-1 != 0) return;
            Label_0065:
                str2 = Path.GetDirectoryName(str);
                goto Label_0011;
            Label_006E:
                Directory.CreateDirectory(str2);
                goto Label_0019;
            Label_0079:
                unit = enumerator.Current;
                str = Path.Combine(xb12a62c5db500525, unit.FileName);
                goto Label_0065;
            }
        }

        private static uint x6770bc3efe337225(byte[] x37cf7043760b312e) { return Convert.ToUInt32((int) ((x37cf7043760b312e[0] << 0x18) + (x37cf7043760b312e[1] << 0x10) + x37cf7043760b312e[2] << 8 + x37cf7043760b312e[3])); }

        private static byte[] x8291881ef07bb5c7(List<GZipUnit> x10154c16e21df88a)
        {
            if (x10154c16e21df88a == null || 8 != 0 && x10154c16e21df88a.Count == 0) return new byte[0];
            List<byte> list = new List<byte>();
            using (List<GZipUnit>.Enumerator enumerator = x10154c16e21df88a.GetEnumerator())
            {
                GZipUnit unit;
                byte[] buffer;
                int length;
                goto Label_0039;
            Label_002D:
                list.AddRange(unit.Buffer);
            Label_0039:
                if (enumerator.MoveNext()) goto Label_00DF;
                goto Label_00DC;
            Label_004A:
                list.AddRange(buffer);
                list.AddRange(xa7f7a75f9cd5120c((uint) unit.Buffer.Length));
                if (((uint) length) > uint.MaxValue) goto Label_0091;
                goto Label_002D;
            Label_0078:
                if (((uint) length) >= 0) goto Label_00A9;
                if (15 != 0)
                {
                }
            Label_0091:
                throw new ArgumentException(string.Format("file name[{0}] is too long, max length is 255", unit.FileName));
            Label_00A9:
                if (length > 0xff) goto Label_0091;
                list.Add((byte) length);
                goto Label_004A;
            Label_00BB:
                buffer = Encoding.Default.GetBytes(unit.FileName);
                length = buffer.Length;
                goto Label_0078;
            Label_00DC:
                if (0 == 0) goto Label_0107;
            Label_00DF:
                unit = enumerator.Current;
                goto Label_00BB;
            }
        Label_0107:
            return list.ToArray();
        }

        private static void x8c8660bdb71bdc0f(ref string x44563e523ace19b5)
        {
            if (string.IsNullOrEmpty(Path.GetExtension(x44563e523ace19b5))) x44563e523ace19b5 = x44563e523ace19b5 + ".gz";
        }

        private static byte[] xa7f7a75f9cd5120c(uint x37cf7043760b312e)
        {
            byte[] buffer = new byte[4];
            buffer[3] = Convert.ToByte((uint) (x37cf7043760b312e % 0x100));
            if (x37cf7043760b312e - x37cf7043760b312e <= uint.MaxValue)
            {
                x37cf7043760b312e /= 0x100;
                if (15 != 0) buffer[2] = Convert.ToByte((uint) (x37cf7043760b312e % 0x100));
                x37cf7043760b312e /= 0x100;
                buffer[1] = Convert.ToByte((uint) (x37cf7043760b312e % 0x100));
                x37cf7043760b312e /= 0x100;
                buffer[0] = Convert.ToByte((uint) (x37cf7043760b312e % 0x100));
                return buffer;
            }
            return buffer;
        }

        private static void xbbc02da781acbd1a(string x44563e523ace19b5, List<GZipUnit> x10154c16e21df88a)
        {
            x8c8660bdb71bdc0f(ref x44563e523ace19b5);
            using (Stream stream = new MemoryStream())
            {
                byte[] buffer = x8291881ef07bb5c7(x10154c16e21df88a);
                stream.Write(buffer, 0, buffer.Length);
                stream.Position = 0;
                xf33c14abcd720615(stream, x44563e523ace19b5);
            }
        }

        private static List<GZipUnit> xd1e589c3e6c349cd(string xa41e5934c019a2b7, string xbb34adac352faae2)
        {
            List<GZipUnit> list = new List<GZipUnit>();
            xd1e589c3e6c349cd(list, xa41e5934c019a2b7, xbb34adac352faae2);
            return list;
        }

        private static void xd1e589c3e6c349cd(List<GZipUnit> x10154c16e21df88a, string xb12a62c5db500525, string xbb34adac352faae2)
        {
            int num2;
            string[] files = Directory.GetFiles(xb12a62c5db500525);
            int index = 0;
        Label_004D:
            if (index < files.Length)
            {
                string path = files[index];
                byte[] buffer = File.ReadAllBytes(path);
                string name = path.Replace(xbb34adac352faae2, string.Empty);
            Label_0067:
                if (!name.StartsWith(Path.DirectorySeparatorChar.ToString()))
                {
                    GZipUnit item = new GZipUnit(name, buffer);
                    x10154c16e21df88a.Add(item);
                    if (((uint) index) + ((uint) num2) <= uint.MaxValue)
                    {
                        if (0xff == 0) return;
                        index++;
                        if ((((uint) num2) | 0xff) == 0) goto Label_0067;
                    }
                    goto Label_004D;
                }
                name = name.Remove(0, 1);
                if (15 == 0) goto Label_005D;
                goto Label_0067;
            }
            string[] directories = Directory.GetDirectories(xb12a62c5db500525);
        Label_005D:
            num2 = 0;
            while (num2 < directories.Length)
            {
                string str3 = directories[num2];
                xd1e589c3e6c349cd(x10154c16e21df88a, str3, xbb34adac352faae2);
                num2++;
            }
        }

        private static void xf33c14abcd720615(Stream x337e217cb3ba0627, string xad2aa743a63d46b9)
        {
            byte[] bytes = Compress(x337e217cb3ba0627);
            File.WriteAllBytes(xad2aa743a63d46b9, bytes);
        }

        private static List<GZipUnit> xf76803be5e9ee2aa(byte[] x5cafa8d49ea71ea1)
        {
            List<GZipUnit> list = new List<GZipUnit>();
            while (true)
            {
                byte num2;
                int index = 0;
                while (index < x5cafa8d49ea71ea1.Length)
                {
                    num2 = x5cafa8d49ea71ea1[index];
                    byte[] bytes = x32541aa2f39b1f2b(x5cafa8d49ea71ea1, index + 1, num2);
                    string name = Encoding.Default.GetString(bytes);
                    uint num3 = x6770bc3efe337225(x32541aa2f39b1f2b(x5cafa8d49ea71ea1, index + 1 + num2, 4));
                    byte[] buffer = x32541aa2f39b1f2b(x5cafa8d49ea71ea1, index + num2 + 5, (int) num3);
                    GZipUnit item = new GZipUnit(name, buffer);
                    if (num2 - ((uint) index) > uint.MaxValue || num2 >= 0)
                    {
                        list.Add(item);
                        index += num2 + 5 + (int) num3;
                    }
                }
                if (num2 - num2 >= 0) return list;
            }
        }

        /// <summary>GZip流单元</summary>
        [Serializable]
        private class GZipUnit
        {
            private byte[] _buffer;
            private string _fileName;

            /// <summary>Initializes a new instance of the <see cref="T:Utils.GZipHelper.GZipUnit" /> class.</summary>
            /// <param name="name">The name.</param>
            /// <param name="buffer">The buffer.</param>
            public GZipUnit(string name, byte[] buffer)
            {
                this._fileName = name;
                this._buffer = buffer;
            }

            /// <summary>Gets the buffer.</summary>
            /// <value>The buffer.</value>
            public byte[] Buffer { get { return this._buffer; } }

            /// <summary>Gets the name of the file.</summary>
            /// <value>The name of the file.</value>
            public string FileName { get { return this._fileName; } }
        }
    }
}
