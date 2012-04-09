namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;

    public sealed class ByteImageConvertor
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        private ByteImageConvertor()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ByteToImage(byte[] bytes)
        {
            if (bytes == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5e0));
            }
            using (MemoryStream stream = new MemoryStream())
            {
                stream.Write(bytes, 0, bytes.Length);
                return Image.FromStream(stream);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ImageToByte(Image image)
        {
            if (image == null)
            {
                throw new ArgumentNullException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x5ee));
            }
            using (MemoryStream stream = new MemoryStream())
            {
                image.Save(stream, ImageFormat.Jpeg);
                return stream.ToArray();
            }
        }
    }
}

