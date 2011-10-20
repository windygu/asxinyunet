namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Drawing2D;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Runtime.CompilerServices;

    public class ImageHelper
    {
        private static int[] TEPULnwMP;

        [MethodImpl(MethodImplOptions.NoInlining)]
        static ImageHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public ImageHelper()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Rectangle 01FqmBarm(Image image1, Matrix matrix1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static Image 4bccOhnfl(Stream stream1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image AddCanvas(Image img, int size)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap Base64StrToBmp(string ImgBase64Str)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap ChangeBrightness(Bitmap bmp, int value)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ChangeImageSize(Image img, float percentage)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ChangeImageSize(Image img, int width, int height)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ChangeImageSize(Image img, int width, int height, bool preserveSize)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static CompareResult CompareTwoImages(Bitmap bmp1, Bitmap bmp2)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompressAsJPG(Bitmap bmp, string saveFilePath, int quality)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CompressAsJPG(Stream inputStream, string saveFilePath, int quality)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void CopyToClipboard(Image img)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image CropImage(Image img, Rectangle rect)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap CropImage(Bitmap b, int StartX, int StartY, int iWidth, int iHeight)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static void dT3f0t4t3(byte[] buffer1, int num2, Stack<Point> p_ColorStack, int num3, int num1, Color color1, Color color2, int num4)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static ImageCodecInfo GetCodecInfo(string mimeType)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Rectangle GetScreenBounds()
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ImageFromBytes(byte[] bytes)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ImageFromUrl(string url)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ImageToBase64Str(Image Img)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ImageToBase64Str(string ImgName)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static byte[] ImageToBytes(Image image)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap MakeBackgroundTransparent(IntPtr hWnd, Image image)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ScaleMode mode)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height, ScaleMode mode, ImageFormat format)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ResizeImageByPercent(Image imgPhoto, int Percent)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image ResizeImageToAFixedSize(Image originalImage, int width, int height, ScaleMode mode)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Bitmap RotateImage(Image img, float theta)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SaveOneInchPic(Image image, Color transColor, float dpi, string path)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImageColorAll(Image p_Image, Color p_OdlColor, Color p_NewColor, int p_Float)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImageColorBrim(Image p_Image, Color p_OldColor, Color p_NewColor, int p_Float)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImageColorPoint(Image p_Image, Point p_Point, Color p_NewColor, int p_Float)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image SetImgOpacity(Image imgPic, float imgOpac)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkImage(Image originalImage, Image watermarkImage)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkImage(Image originalImage, Image watermarkImage, WatermarkPosition position)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkText(Image originalImage, string text)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkText(Image originalImage, string text, WatermarkPosition position)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image WatermarkText(Image originalImage, string text, WatermarkPosition position, Font font, Brush brush)
        {
            // Translated Error! Expression stack is empty at offset 0006.
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        private static bool yTHMJ858G(Color color1, Color color2, int num1)
        {
            // Translated Error! Expression stack is empty at offset 0006.
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
