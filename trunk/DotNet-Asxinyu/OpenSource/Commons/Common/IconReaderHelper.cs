namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using Ih3008QWDePRuiqEka;
    using KnVbXRZYPBDCaqXOmu;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    public class IconReaderHelper
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon ExtractIconForExtension(string extension, bool large)
        {
            if (extension == null)
            {
                throw new ArgumentException(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e84), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4ebc));
            }
            return GetAssociatedIcon(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x4e7e) + extension, large);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon GetAssociatedIcon(string stubPath, bool large)
        {
            uint num2;
            8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf structure = new 8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf();
            int num = Marshal.SizeOf(structure);
            if (large)
            {
                num2 = 0x110;
            }
            else
            {
                num2 = 0x111;
            }
            8gZQUAenTSNGaA21G1.t00qRSolC(stubPath, 0x100, ref structure, (uint) num, num2);
            return Icon.FromHandle(structure.t00qRSolC);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetDisplayName(string name, bool isDirectory)
        {
            uint num = 0x410;
            8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf structure = new 8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf();
            uint num2 = isDirectory ? 0x10 : 0x80;
            8gZQUAenTSNGaA21G1.t00qRSolC(name, num2, ref structure, (uint) Marshal.SizeOf(structure), num);
            return structure.WO5U9QNDF;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay)
        {
            uint num = 0x110;
            if (linkOverlay)
            {
                num += 0x8000;
            }
            if (IconSize.Small == size)
            {
                num++;
            }
            else
            {
                num = num;
            }
            8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf structure = new 8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf();
            8gZQUAenTSNGaA21G1.t00qRSolC(name, 0x80, ref structure, (uint) Marshal.SizeOf(structure), num);
            Icon icon = (Icon) Icon.FromHandle(structure.t00qRSolC).Clone();
            NLUYivc0ZVYj0RHwU5.t00qRSolC(structure.t00qRSolC);
            return icon;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Icon GetFolderIcon(IconSize size, FolderType folderType)
        {
            uint num = 0x100;
            if (FolderType.Open == folderType)
            {
                num += 2;
            }
            if (IconSize.Small == size)
            {
                num++;
            }
            else
            {
                num = num;
            }
            8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf structure = new 8gZQUAenTSNGaA21G1.IPZ6Lxb8jKI5iDHkvf();
            8gZQUAenTSNGaA21G1.t00qRSolC(null, 0x10, ref structure, (uint) Marshal.SizeOf(structure), num);
            Icon.FromHandle(structure.t00qRSolC);
            Icon icon = (Icon) Icon.FromHandle(structure.t00qRSolC).Clone();
            NLUYivc0ZVYj0RHwU5.t00qRSolC(structure.t00qRSolC);
            return icon;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetIcon(ImageList images, string extension)
        {
            return GetIcon(images, extension, false);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static int GetIcon(ImageList images, string extension, bool largeIcon)
        {
            for (int i = 0; i < images.Images.Count; i++)
            {
                if (images.Images.Keys[i] == extension)
                {
                    return i;
                }
            }
            images.Images.Add(extension, ExtractIconForExtension(extension, largeIcon));
            return (images.Images.Count - 1);
        }

        public enum FolderType
        {
            Open,
            Closed
        }

        public enum IconSize
        {
            Large,
            Small
        }
    }
}

