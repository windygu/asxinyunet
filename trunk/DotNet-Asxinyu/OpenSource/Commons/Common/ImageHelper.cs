namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Net;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Windows.Forms;

    public class ImageHelper
    {
        private static int[] TEPULnwMP = new int[] { 0x10, 14, 12, 10, 8, 6, 4 };

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Rectangle 01FqmBarm(Image image1, Matrix matrix1)
        {
            GraphicsUnit world = GraphicsUnit.World;
            Rectangle rectangle = Rectangle.Round(image1.GetBounds(ref world));
            Point point = new Point(rectangle.Left, rectangle.Top);
            Point point2 = new Point(rectangle.Right, rectangle.Top);
            Point point3 = new Point(rectangle.Right, rectangle.Bottom);
            Point point4 = new Point(rectangle.Left, rectangle.Bottom);
            Point[] pts = new Point[] { point, point2, point3, point4 };
            GraphicsPath path = new GraphicsPath(pts, new byte[] { 0, 1, 1, 1 });
            path.Transform(matrix1);
            return Rectangle.Round(path.GetBounds());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Image 4bccOhnfl(Stream stream1)
        {
            Image image = null;
            try
            {
                stream1.Position = 0L;
                Image original = Image.FromStream(stream1);
                using (original)
                {
                    image = new Bitmap(original);
                }
            }
            catch
            {
                try
                {
                    stream1.Position = 0L;
                    Icon icon = new Icon(stream1);
                    if (icon != null)
                    {
                        image = icon.ToBitmap();
                    }
                }
                catch
                {
                }
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image AddCanvas(Image img, int size)
        {
            Image image = new Bitmap(img.Width + (size * 2), img.Height + (size * 2));
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(img, new Rectangle(size, size, img.Width, img.Height), new Rectangle(0, 0, img.Width, img.Height), GraphicsUnit.Pixel);
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap Base64StrToBmp(string ImgBase64Str)
        {
            return new Bitmap(new MemoryStream(Convert.FromBase64String(ImgBase64Str)));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static unsafe Bitmap ChangeBrightness(Bitmap bmp, int value)
        {
            BitmapData bitmapdata = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            int num = bitmapdata.Stride - (bmp.Width * 3);
            int num2 = bmp.Width * 3;
            byte* numPtr = (byte*) bitmapdata.Scan0;
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < num2; j++)
                {
                    int num3 = numPtr[0] + value;
                    if (num3 < 0)
                    {
                        num3 = 0;
                    }
                    else if (num3 > 0xff)
                    {
                        num3 = 0xff;
                    }
                    numPtr[0] = (byte) num3;
                    numPtr++;
                }
                numPtr += num;
            }
            bmp.UnlockBits(bitmapdata);
            return bmp;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ChangeImageSize(Image img, float percentage)
        {
            int width = (int) ((percentage / 100f) * img.Width);
            int height = (int) ((percentage / 100f) * img.Height);
            return ChangeImageSize(img, width, height, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ChangeImageSize(Image img, int width, int height)
        {
            Image image = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(img, new Rectangle(0, 0, image.Width, image.Height));
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ChangeImageSize(Image img, int width, int height, bool preserveSize)
        {
            if (preserveSize)
            {
                width = Math.Min(img.Width, width);
                height = Math.Min(img.Height, height);
            }
            Image image = new Bitmap(width, height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.DrawImage(img, new Rectangle(0, 0, image.Width, image.Height));
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CompareResult CompareTwoImages(Bitmap bmp1, Bitmap bmp2)
        {
            CompareResult compareOk = CompareResult.CompareOk;
            if (bmp1.Size != bmp2.Size)
            {
                return CompareResult.SizeMismatch;
            }
            ImageConverter converter = new ImageConverter();
            byte[] buffer = new byte[1];
            buffer = (byte[]) converter.ConvertTo(bmp1, buffer.GetType());
            byte[] buffer2 = new byte[1];
            buffer2 = (byte[]) converter.ConvertTo(bmp2, buffer2.GetType());
            SHA256Managed managed = new SHA256Managed();
            byte[] buffer3 = managed.ComputeHash(buffer);
            byte[] buffer4 = managed.ComputeHash(buffer2);
            for (int i = 0; ((i < buffer3.Length) && (i < buffer4.Length)) && (compareOk == CompareResult.CompareOk); i++)
            {
                if (buffer3[i] != buffer4[i])
                {
                    compareOk = CompareResult.PixelMismatch;
                }
            }
            return compareOk;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompressAsJPG(Bitmap bmp, string saveFilePath, int quality)
        {
            EncoderParameter parameter = new EncoderParameter(Encoder.Quality, (long) quality);
            EncoderParameters encoderParams = new EncoderParameters(1);
            encoderParams.Param[0] = parameter;
            bmp.Save(saveFilePath, GetCodecInfo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x87ae)), encoderParams);
            bmp.Dispose();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompressAsJPG(Stream inputStream, string saveFilePath, int quality)
        {
            CompressAsJPG(new Bitmap(inputStream), saveFilePath, quality);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CopyToClipboard(Image img)
        {
            MemoryStream stream = new MemoryStream();
            MemoryStream data = new MemoryStream();
            img.Save(stream, ImageFormat.Bmp);
            byte[] buffer = stream.GetBuffer();
            data.Write(buffer, 14, ((int) stream.Length) - 14);
            stream.Position = 0L;
            IDataObject obj2 = new DataObject();
            obj2.SetData(DataFormats.Dib, true, data);
            Clipboard.SetDataObject(obj2, true);
            data.Close();
            stream.Close();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image CropImage(Image img, Rectangle rect)
        {
            Image image = new Bitmap(rect.Width, rect.Height);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(img, new Rectangle(0, 0, rect.Width, rect.Height), rect, GraphicsUnit.Pixel);
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap CropImage(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            if (b == null)
            {
                return null;
            }
            int width = b.Width;
            int height = b.Height;
            if ((StartX >= width) || (StartY >= height))
            {
                return null;
            }
            if ((StartX + iWidth) > width)
            {
                iWidth = width - StartX;
            }
            if ((StartY + iHeight) > height)
            {
                iHeight = height - StartY;
            }
            try
            {
                Bitmap image = new Bitmap(iWidth, iHeight, PixelFormat.Format24bppRgb);
                Graphics graphics = Graphics.FromImage(image);
                graphics.DrawImage(b, new Rectangle(0, 0, iWidth, iHeight), new Rectangle(StartX, StartY, iWidth, iHeight), GraphicsUnit.Pixel);
                graphics.Dispose();
                return image;
            }
            catch
            {
                return null;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(byte[] buffer1, int num2, Stack<Point> p_ColorStack, int num3, int num1, Color color1, Color color2, int num4)
        {
            int index = (num1 * num2) + (num3 * 4);
            if (yTHMJ858G(Color.FromArgb(buffer1[index + 3], buffer1[index + 2], buffer1[index + 1], buffer1[index]), color1, num4))
            {
                p_ColorStack.Push(new Point(num3, num1));
                buffer1[index + 3] = color2.A;
                buffer1[index + 2] = color2.R;
                buffer1[index + 1] = color2.G;
                buffer1[index] = color2.B;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo info in imageEncoders)
            {
                if (info.MimeType == mimeType)
                {
                    return info;
                }
            }
            return null;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Rectangle GetScreenBounds()
        {
            Point point = new Point(0, 0);
            Point point2 = new Point(0, 0);
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.X < point.X)
                {
                    point.X = screen.Bounds.X;
                }
                if (screen.Bounds.Y < point.Y)
                {
                    point.Y = screen.Bounds.Y;
                }
                if ((screen.Bounds.X + screen.Bounds.Width) > point2.X)
                {
                    point2.X = screen.Bounds.X + screen.Bounds.Width;
                }
                if ((screen.Bounds.Y + screen.Bounds.Height) > point2.Y)
                {
                    point2.Y = screen.Bounds.Y + screen.Bounds.Height;
                }
            }
            return new Rectangle(point.X, point.Y, point2.X + Math.Abs(point.X), point2.Y + Math.Abs(point.Y));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ImageFromBytes(byte[] bytes)
        {
            Image image = null;
            try
            {
                if (bytes == null)
                {
                    return image;
                }
                MemoryStream stream = new MemoryStream(bytes, false);
                using (stream)
                {
                    image = 4bccOhnfl(stream);
                }
            }
            catch
            {
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ImageFromUrl(string url)
        {
            Image image = null;
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    return image;
                }
                Uri address = new Uri(url);
                if (address.IsFile)
                {
                    FileStream stream = new FileStream(address.LocalPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using (stream)
                    {
                        return 4bccOhnfl(stream);
                    }
                }
                WebClient client = new WebClient();
                using (client)
                {
                    MemoryStream stream2 = new MemoryStream(client.DownloadData(address), false);
                    using (stream2)
                    {
                        return 4bccOhnfl(stream2);
                    }
                }
            }
            catch
            {
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ImageToBase64Str(Image Img)
        {
            MemoryStream stream = new MemoryStream();
            Img.Save(stream, ImageFormat.Jpeg);
            return Convert.ToBase64String(stream.GetBuffer());
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ImageToBase64Str(string ImgName)
        {
            Image image = Image.FromFile(ImgName);
            MemoryStream stream = new MemoryStream();
            image.Save(stream, ImageFormat.Jpeg);
            string str = Convert.ToBase64String(stream.GetBuffer());
            image.Dispose();
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ImageToBytes(Image image)
        {
            byte[] buffer = null;
            if (image != null)
            {
                lock (image)
                {
                    MemoryStream stream = new MemoryStream();
                    using (stream)
                    {
                        image.Save(stream, ImageFormat.Png);
                        buffer = stream.GetBuffer();
                    }
                }
            }
            return buffer;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap MakeBackgroundTransparent(IntPtr hWnd, Image image)
        {
            Region region;
            if (NativeMethods.GetWindowRegion(hWnd, out region))
            {
                Bitmap bitmap = new Bitmap(image.Width, image.Height);
                using (Graphics graphics = Graphics.FromImage(bitmap))
                {
                    if (!region.IsEmpty(graphics))
                    {
                        RectangleF bounds = region.GetBounds(graphics);
                        graphics.Clip = region;
                        graphics.DrawImage(image, new RectangleF(new PointF(0f, 0f), bounds.Size), bounds, GraphicsUnit.Pixel);
                        return bitmap;
                    }
                }
            }
            return (Bitmap) image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ScaleMode mode)
        {
            MakeThumbnail(originalImagePath, thumbnailPath, width, height, mode, ImageFormat.Jpeg);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ScaleMode mode, ImageFormat format)
        {
            Image originalImage = Image.FromFile(originalImagePath);
            Image image2 = ResizeImageToAFixedSize(originalImage, width, height, mode);
            try
            {
                image2.Save(thumbnailPath, format);
            }
            catch (Exception exception)
            {
                throw exception;
            }
            finally
            {
                originalImage.Dispose();
                image2.Dispose();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ResizeImageByPercent(Image imgPhoto, int Percent)
        {
            float num = ((float) Percent) / 100f;
            int width = imgPhoto.Width;
            int height = imgPhoto.Height;
            int x = 0;
            int y = 0;
            int num6 = 0;
            int num7 = 0;
            int num8 = (int) (width * num);
            int num9 = (int) (height * num);
            Bitmap image = new Bitmap(num8, num9, PixelFormat.Format24bppRgb);
            image.SetResolution(imgPhoto.HorizontalResolution, imgPhoto.VerticalResolution);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(imgPhoto, new Rectangle(num6, num7, num8, num9), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ResizeImageToAFixedSize(Image originalImage, int width, int height, ScaleMode mode)
        {
            int num = width;
            int num2 = height;
            int x = 0;
            int y = 0;
            int num5 = originalImage.Width;
            int num6 = originalImage.Height;
            switch (mode)
            {
                case ScaleMode.W:
                    num2 = (originalImage.Height * width) / originalImage.Width;
                    break;

                case ScaleMode.H:
                    num = (originalImage.Width * height) / originalImage.Height;
                    break;

                case ScaleMode.Cut:
                    if ((((double) originalImage.Width) / ((double) originalImage.Height)) > (((double) num) / ((double) num2)))
                    {
                        num6 = originalImage.Height;
                        num5 = (originalImage.Height * num) / num2;
                        y = 0;
                        x = (originalImage.Width - num5) / 2;
                    }
                    else
                    {
                        num5 = originalImage.Width;
                        num6 = (originalImage.Width * height) / num;
                        x = 0;
                        y = (originalImage.Height - num6) / 2;
                    }
                    break;
            }
            Image image = new Bitmap(num, num2);
            using (Graphics graphics = Graphics.FromImage(image))
            {
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.Clear(Color.Transparent);
                graphics.DrawImage(originalImage, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num5, num6), GraphicsUnit.Pixel);
            }
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap RotateImage(Image img, float theta)
        {
            Bitmap bitmap2;
            Matrix matrix = new Matrix();
            matrix.Translate((float) (img.Width / -2), (float) (img.Height / -2), MatrixOrder.Append);
            matrix.RotateAt(theta, (PointF) new Point(0, 0), MatrixOrder.Append);
            using (GraphicsPath path = new GraphicsPath())
            {
                Point[] points = new Point[] { new Point(0, 0), new Point(img.Width, 0), new Point(0, img.Height) };
                path.AddPolygon(points);
                path.Transform(matrix);
                PointF[] pathPoints = path.PathPoints;
                Rectangle rectangle = 01FqmBarm(img, matrix);
                Bitmap image = new Bitmap(rectangle.Width, rectangle.Height);
                using (Graphics graphics = Graphics.FromImage(image))
                {
                    Matrix matrix2 = new Matrix();
                    matrix2.Translate((float) (image.Width / 2), (float) (image.Height / 2), MatrixOrder.Append);
                    graphics.Transform = matrix2;
                    graphics.CompositingQuality = CompositingQuality.HighQuality;
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.DrawImage(img, pathPoints);
                    bitmap2 = image;
                }
            }
            return bitmap2;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SaveOneInchPic(Image image, Color transColor, float dpi, string path)
        {
            try
            {
                image = image.Clone() as Image;
                ((Bitmap) image).SetResolution(dpi, dpi);
                ImageCodecInfo codecInfo = GetCodecInfo(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8796));
                EncoderParameters encoderParams = new EncoderParameters(2);
                encoderParams.Param[0] = new EncoderParameter(Encoder.Quality, 100L);
                encoderParams.Param[1] = new EncoderParameter(Encoder.ColorDepth, 0x20L);
                image.Save(path, codecInfo, encoderParams);
                image.Dispose();
            }
            catch (Exception exception)
            {
                LogHelper.Error(exception);
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImageColorAll(Image p_Image, Color p_OdlColor, Color p_NewColor, int p_Float)
        {
            int width = p_Image.Width;
            int height = p_Image.Height;
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(p_Image, new Rectangle(0, 0, width, height));
            graphics.Dispose();
            BitmapData bitmapdata = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            bitmapdata.PixelFormat = PixelFormat.Format32bppArgb;
            int length = bitmapdata.Stride * height;
            byte[] destination = new byte[length];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, length);
            int num4 = width * height;
            int index = 0;
            for (int i = 0; i != num4; i++)
            {
                if (yTHMJ858G(Color.FromArgb(destination[index + 3], destination[index + 2], destination[index + 1], destination[index]), p_OdlColor, p_Float))
                {
                    destination[index + 3] = p_NewColor.A;
                    destination[index + 2] = p_NewColor.R;
                    destination[index + 1] = p_NewColor.G;
                    destination[index] = p_NewColor.B;
                }
                index += 4;
            }
            Marshal.Copy(destination, 0, bitmapdata.Scan0, length);
            image.UnlockBits(bitmapdata);
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImageColorBrim(Image p_Image, Color p_OldColor, Color p_NewColor, int p_Float)
        {
            int num6;
            int width = p_Image.Width;
            int height = p_Image.Height;
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(p_Image, new Rectangle(0, 0, width, height));
            graphics.Dispose();
            BitmapData bitmapdata = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            bitmapdata.PixelFormat = PixelFormat.Format32bppArgb;
            int length = bitmapdata.Stride * height;
            byte[] destination = new byte[length];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, length);
            int index = 0;
            int num5 = 0;
            while (num5 != height)
            {
                index = num5 * bitmapdata.Stride;
                num6 = 0;
                while (num6 != width)
                {
                    if (yTHMJ858G(Color.FromArgb(destination[index + 3], destination[index + 2], destination[index + 1], destination[index]), p_OldColor, p_Float))
                    {
                        destination[index + 3] = p_NewColor.A;
                        destination[index + 2] = p_NewColor.R;
                        destination[index + 1] = p_NewColor.G;
                        destination[index] = p_NewColor.B;
                        index += 4;
                    }
                    else
                    {
                        break;
                    }
                    num6++;
                }
                index = (num5 + 1) * bitmapdata.Stride;
                num6 = 0;
                while (num6 != width)
                {
                    if (yTHMJ858G(Color.FromArgb(destination[index - 1], destination[index - 2], destination[index - 3], destination[index - 4]), p_OldColor, p_Float))
                    {
                        destination[index - 1] = p_NewColor.A;
                        destination[index - 2] = p_NewColor.R;
                        destination[index - 3] = p_NewColor.G;
                        destination[index - 4] = p_NewColor.B;
                        index -= 4;
                    }
                    else
                    {
                        break;
                    }
                    num6++;
                }
                num5++;
            }
            for (num6 = 0; num6 != width; num6++)
            {
                index = num6 * 4;
                num5 = 0;
                while (num5 != height)
                {
                    if (yTHMJ858G(Color.FromArgb(destination[index + 3], destination[index + 2], destination[index + 1], destination[index]), p_OldColor, p_Float))
                    {
                        destination[index + 3] = p_NewColor.A;
                        destination[index + 2] = p_NewColor.R;
                        destination[index + 1] = p_NewColor.G;
                        destination[index] = p_NewColor.B;
                        index += bitmapdata.Stride;
                    }
                    else
                    {
                        break;
                    }
                    num5++;
                }
                index = (num6 * 4) + ((height - 1) * bitmapdata.Stride);
                for (num5 = 0; num5 != height; num5++)
                {
                    if (yTHMJ858G(Color.FromArgb(destination[index + 3], destination[index + 2], destination[index + 1], destination[index]), p_OldColor, p_Float))
                    {
                        destination[index + 3] = p_NewColor.A;
                        destination[index + 2] = p_NewColor.R;
                        destination[index + 1] = p_NewColor.G;
                        destination[index] = p_NewColor.B;
                        index -= bitmapdata.Stride;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            Marshal.Copy(destination, 0, bitmapdata.Scan0, length);
            image.UnlockBits(bitmapdata);
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImageColorPoint(Image p_Image, Point p_Point, Color p_NewColor, int p_Float)
        {
            int width = p_Image.Width;
            int height = p_Image.Height;
            if (p_Point.X > (width - 1))
            {
                return p_Image;
            }
            if (p_Point.Y > (height - 1))
            {
                return p_Image;
            }
            Color pixel = ((Bitmap) p_Image).GetPixel(p_Point.X, p_Point.Y);
            Bitmap image = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            Graphics graphics = Graphics.FromImage(image);
            graphics.DrawImage(p_Image, new Rectangle(0, 0, width, height));
            graphics.Dispose();
            BitmapData bitmapdata = image.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);
            bitmapdata.PixelFormat = PixelFormat.Format32bppArgb;
            int length = bitmapdata.Stride * height;
            byte[] destination = new byte[length];
            Marshal.Copy(bitmapdata.Scan0, destination, 0, length);
            int index = (p_Point.Y * bitmapdata.Stride) + (p_Point.X * 4);
            Color color2 = Color.FromArgb(destination[index + 3], destination[index + 2], destination[index + 1], destination[index]);
            if (color2.Equals(p_NewColor))
            {
                return p_Image;
            }
            Stack<Point> stack = new Stack<Point>(0x3e8);
            stack.Push(p_Point);
            destination[index + 3] = p_NewColor.A;
            destination[index + 2] = p_NewColor.R;
            destination[index + 1] = p_NewColor.G;
            destination[index] = p_NewColor.B;
            do
            {
                Point point = stack.Pop();
                if (point.X > 0)
                {
                    dT3f0t4t3(destination, bitmapdata.Stride, stack, point.X - 1, point.Y, color2, p_NewColor, p_Float);
                }
                if (point.Y > 0)
                {
                    dT3f0t4t3(destination, bitmapdata.Stride, stack, point.X, point.Y - 1, color2, p_NewColor, p_Float);
                }
                if (point.X < (width - 1))
                {
                    dT3f0t4t3(destination, bitmapdata.Stride, stack, point.X + 1, point.Y, color2, p_NewColor, p_Float);
                }
                if (point.Y < (height - 1))
                {
                    dT3f0t4t3(destination, bitmapdata.Stride, stack, point.X, point.Y + 1, color2, p_NewColor, p_Float);
                }
            }
            while (stack.Count > 0);
            Marshal.Copy(destination, 0, bitmapdata.Scan0, length);
            image.UnlockBits(bitmapdata);
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImgOpacity(Image imgPic, float imgOpac)
        {
            Bitmap image = new Bitmap(imgPic.Width, imgPic.Height);
            Graphics graphics = Graphics.FromImage(image);
            ColorMatrix newColorMatrix = new ColorMatrix {
                Matrix33 = imgOpac
            };
            ImageAttributes imageAttr = new ImageAttributes();
            imageAttr.SetColorMatrix(newColorMatrix);
            graphics.DrawImage(imgPic, new Rectangle(0, 0, image.Width, image.Height), 0, 0, imgPic.Width, imgPic.Height, GraphicsUnit.Pixel, imageAttr);
            graphics.Dispose();
            return image;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkImage(Image originalImage, Image watermarkImage)
        {
            return WatermarkImage(originalImage, watermarkImage, WatermarkPosition.BottomRight);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkImage(Image originalImage, Image watermarkImage, WatermarkPosition position)
        {
            ImageAttributes imageAttr = new ImageAttributes();
            ColorMap map = new ColorMap {
                OldColor = Color.FromArgb(0xff, 0, 0xff, 0),
                NewColor = Color.FromArgb(0, 0, 0, 0)
            };
            ColorMap[] mapArray = new ColorMap[] { map };
            imageAttr.SetRemapTable(mapArray, ColorAdjustType.Bitmap);
            float[][] numArray2 = new float[5][];
            float[] numArray3 = new float[5];
            numArray3[0] = 1f;
            numArray2[0] = numArray3;
            numArray3 = new float[5];
            numArray3[1] = 1f;
            numArray2[1] = numArray3;
            numArray3 = new float[5];
            numArray3[2] = 1f;
            numArray2[2] = numArray3;
            numArray3 = new float[5];
            numArray3[3] = 0.3f;
            numArray2[3] = numArray3;
            numArray3 = new float[5];
            numArray3[4] = 1f;
            numArray2[4] = numArray3;
            float[][] newColorMatrix = numArray2;
            ColorMatrix matrix = new ColorMatrix(newColorMatrix);
            imageAttr.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            int x = 0;
            int y = 0;
            int width = 0;
            int height = 0;
            double num5 = 1.0;
            if ((originalImage.Width > (watermarkImage.Width * 4)) && (originalImage.Height > (watermarkImage.Height * 4)))
            {
                num5 = 1.0;
            }
            else if ((originalImage.Width > (watermarkImage.Width * 4)) && (originalImage.Height < (watermarkImage.Height * 4)))
            {
                num5 = Convert.ToDouble((int) (originalImage.Height / 4)) / Convert.ToDouble(watermarkImage.Height);
            }
            else if ((originalImage.Width < (watermarkImage.Width * 4)) && (originalImage.Height > (watermarkImage.Height * 4)))
            {
                num5 = Convert.ToDouble((int) (originalImage.Width / 4)) / Convert.ToDouble(watermarkImage.Width);
            }
            else if ((originalImage.Width * watermarkImage.Height) > (originalImage.Height * watermarkImage.Width))
            {
                num5 = Convert.ToDouble((int) (originalImage.Height / 4)) / Convert.ToDouble(watermarkImage.Height);
            }
            else
            {
                num5 = Convert.ToDouble((int) (originalImage.Width / 4)) / Convert.ToDouble(watermarkImage.Width);
            }
            width = Convert.ToInt32((double) (watermarkImage.Width * num5));
            height = Convert.ToInt32((double) (watermarkImage.Height * num5));
            switch (position)
            {
                case WatermarkPosition.TopLeft:
                    x = 10;
                    y = 10;
                    break;

                case WatermarkPosition.TopRight:
                    y = 10;
                    x = (originalImage.Width - width) - 10;
                    break;

                case WatermarkPosition.BottomLeft:
                    x = 10;
                    y = (originalImage.Height - height) - 10;
                    break;

                case WatermarkPosition.BottomRight:
                    x = (originalImage.Width - width) - 10;
                    y = (originalImage.Height - height) - 10;
                    break;

                case WatermarkPosition.Center:
                    x = (originalImage.Width / 2) - (width / 2);
                    y = (originalImage.Height / 2) - (height / 2);
                    break;
            }
            using (Graphics graphics = Graphics.FromImage(originalImage))
            {
                graphics.DrawImage(watermarkImage, new Rectangle(x, y, width, height), 0, 0, watermarkImage.Width, watermarkImage.Height, GraphicsUnit.Pixel, imageAttr);
            }
            return originalImage;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkText(Image originalImage, string text)
        {
            return WatermarkText(originalImage, text, WatermarkPosition.BottomRight);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkText(Image originalImage, string text, WatermarkPosition position)
        {
            return WatermarkText(originalImage, text, position, new Font(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x8784), 12f, FontStyle.Italic), new SolidBrush(Color.Black));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkText(Image originalImage, string text, WatermarkPosition position, Font font, Brush brush)
        {
            using (Graphics graphics = Graphics.FromImage(originalImage))
            {
                Font font2 = null;
                SizeF ef = new SizeF();
                ef = graphics.MeasureString(text, font);
                if (ef.Width >= originalImage.Width)
                {
                    for (int i = 0; i < 7; i++)
                    {
                        font2 = new Font(font.FontFamily, (float) TEPULnwMP[i], font.Style);
                        ef = graphics.MeasureString(text, font2);
                        if (ef.Width < originalImage.Width)
                        {
                            break;
                        }
                    }
                }
                else
                {
                    font2 = font;
                }
                float x = originalImage.Width * 0.01f;
                float y = originalImage.Height * 0.01f;
                switch (position)
                {
                    case WatermarkPosition.TopRight:
                        x = (originalImage.Width * 0.99f) - ef.Width;
                        break;

                    case WatermarkPosition.BottomLeft:
                        y = (originalImage.Height * 0.99f) - ef.Height;
                        break;

                    case WatermarkPosition.BottomRight:
                        x = (originalImage.Width * 0.99f) - ef.Width;
                        y = (originalImage.Height * 0.99f) - ef.Height;
                        break;

                    case WatermarkPosition.Center:
                        x = (((float) originalImage.Width) / 2f) - (ef.Width / 2f);
                        y = (((float) originalImage.Height) / 2f) - (ef.Height / 2f);
                        break;
                }
                graphics.DrawString(text, font2, brush, x, y);
                return originalImage;
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool yTHMJ858G(Color color1, Color color2, int num1)
        {
            int r = color1.R;
            int g = color1.G;
            int b = color1.B;
            return ((((r <= (color2.R + num1)) && (r >= (color2.R - num1))) && ((g <= (color2.G + num1)) && (g >= (color2.G - num1)))) && ((b <= (color2.B + num1)) && (b >= (color2.B - num1))));
        }

        public enum CompareResult
        {
            CompareOk,
            PixelMismatch,
            SizeMismatch
        }

        public enum ScaleMode
        {
            HW,
            W,
            H,
            Cut
        }

        public enum WatermarkPosition
        {
            TopLeft,
            TopRight,
            BottomLeft,
            BottomRight,
            Center
        }
    }
}

