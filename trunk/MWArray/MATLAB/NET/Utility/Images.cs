namespace MathWorks.MATLAB.NET.Utility
{
    using MathWorks.MATLAB.NET.Arrays;
    using System;
    using System.Drawing;
    using System.Drawing.Imaging;

    public class Images
    {
        public static Image renderArrayData(MWArray rgbData)
        {
            MWNumericArray array = (MWNumericArray) rgbData;
            byte[,,] buffer = (byte[,,]) array.ToArray(MWArrayComponent.Real);
            int length = buffer.GetLength(1);
            int width = buffer.GetLength(2);
            Bitmap bitmap = new Bitmap(width, length, PixelFormat.Format24bppRgb);
            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int red = buffer[0, i, j];
                    int green = buffer[1, i, j];
                    int blue = buffer[2, i, j];
                    Color color = Color.FromArgb(red, green, blue);
                    bitmap.SetPixel(j, i, color);
                }
            }
            return bitmap;
        }
    }
}
