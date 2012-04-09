namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class FileDialogHelper
    {
        private static string 37jAJ3Bnt = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x300e);
        private static string 408MSTia8 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2e5c);
        private static string GPY6Re0PF = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2f48);
        private static string JiYUNJcCW = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2fc0);
        private const string mUvqAX6rk = "配置文件(*.cfg)|*.cfg|All File(*.*)|*.*";
        private static string PQMwwy6pB = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x305a);
        private static string XPOfx7u7N = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2e10);

        [MethodImpl(MethodImplOptions.NoInlining)]
        private FileDialogHelper()
        {
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Open(string title, string filter)
        {
            return Open(title, filter, string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Open(string title, string filter, string filename)
        {
            OpenFileDialog dialog = new OpenFileDialog {
                Filter = filter,
                Title = title,
                RestoreDirectory = true,
                FileName = filename
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenAccessDb()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2d40), JiYUNJcCW);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenBakDb(string file)
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2d08), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2d16), file);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenConfig()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2da8), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2db8));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenDir()
        {
            return OpenDir(string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenDir(string selectedPath)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog {
                Description = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2e02),
                SelectedPath = selectedPath
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.SelectedPath;
            }
            return string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenExcel()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2bf8), XPOfx7u7N);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenHtml()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c2e), GPY6Re0PF);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenImage()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c9e), 408MSTia8);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenText()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2bc8), PQMwwy6pB);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenZip()
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c5e), 37jAJ3Bnt);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string OpenZip(string filename)
        {
            return Open(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c6e), 37jAJ3Bnt, filename);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color PickColor()
        {
            Color control = SystemColors.Control;
            ColorDialog dialog = new ColorDialog();
            if (DialogResult.OK == dialog.ShowDialog())
            {
                control = dialog.Color;
            }
            return control;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Color PickColor(Color color)
        {
            Color control = SystemColors.Control;
            ColorDialog dialog = new ColorDialog {
                Color = color
            };
            if (DialogResult.OK == dialog.ShowDialog())
            {
                control = dialog.Color;
            }
            return control;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Save(string title, string filter)
        {
            return Save(title, filter, string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Save(string title, string filter, string filename)
        {
            return Save(title, filter, filename, "");
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Save(string title, string filter, string filename, string initialDirectory)
        {
            SaveFileDialog dialog = new SaveFileDialog {
                Filter = filter,
                Title = title,
                FileName = filename,
                RestoreDirectory = true
            };
            if (!string.IsNullOrEmpty(initialDirectory))
            {
                dialog.InitialDirectory = initialDirectory;
            }
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                return dialog.FileName;
            }
            return string.Empty;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveAccessDb()
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2cc2), JiYUNJcCW);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveBakDb()
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2cd0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2cde));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveConfig()
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2d4e), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2d5e));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveExcel()
        {
            return SaveExcel(string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveExcel(string filename)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c0a), XPOfx7u7N, filename);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveExcel(string filename, string initialDirectory)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c1c), XPOfx7u7N, filename, initialDirectory);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveHtml()
        {
            return SaveHtml(string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveHtml(string filename)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c3e), GPY6Re0PF, filename);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveHtml(string filename, string initialDirectory)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c4e), GPY6Re0PF, filename, initialDirectory);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveImage()
        {
            return SaveImage(string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveImage(string filename)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2caa), 408MSTia8, filename);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveImage(string filename, string initialDirectory)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2cb6), 408MSTia8, filename, initialDirectory);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveText()
        {
            return SaveText(string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveText(string filename)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2bd8), PQMwwy6pB, filename);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveText(string filename, string initialDirectory)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2be8), PQMwwy6pB, filename, initialDirectory);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveZip()
        {
            return SaveZip(string.Empty);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveZip(string filename)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c7e), 37jAJ3Bnt, filename);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string SaveZip(string filename, string initialDirectory)
        {
            return Save(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0x2c8e), 37jAJ3Bnt, filename, initialDirectory);
        }
    }
}

