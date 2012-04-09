namespace Devv.Core.Utils
{
    using Microsoft.VisualBasic.CompilerServices;
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Text;

    public class CompressionUtil
    {
        private CompressionUtil()
        {
        }

        public static byte[] GZipCompress(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return null;
            }
            return GZipCompress(Encoding.UTF8.GetBytes(value));
        }

        public static byte[] GZipCompress(byte[] value)
        {
            if (value.Length < 1)
            {
                return null;
            }
            MemoryStream stream = new MemoryStream();
            GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true);
            stream2.Write(value, 0, value.Length);
            stream2.Close();
            stream.Position = 0L;
            byte[] buffer = new byte[Convert.ToInt32(stream.Length) + 1];
            stream.Read(buffer, 0, buffer.Length);
            byte[] dst = new byte[(buffer.Length + 4) + 1];
            Buffer.BlockCopy(buffer, 0, dst, 4, buffer.Length);
            Buffer.BlockCopy(BitConverter.GetBytes(value.Length), 0, dst, 0, 4);
            stream.Dispose();
            return dst;
        }

        public static byte[] GZipDecompress(byte[] compressed)
        {
            if (compressed.Length < 1)
            {
                return null;
            }
            try
            {
            }
            catch (Exception exception1)
            {
                ProjectData.SetProjectError(exception1);
                Exception exception = exception1;
                ProjectData.ClearProjectError();
            }
            using (MemoryStream stream = new MemoryStream())
            {
                byte[] array = new byte[BitConverter.ToInt32(compressed, 0) + 1];
                stream.Write(compressed, 4, compressed.Length - 4);
                stream.Position = 0L;
                new GZipStream(stream, CompressionMode.Decompress).Read(array, 0, array.Length);
                return array;
            }
        }
    }
}
