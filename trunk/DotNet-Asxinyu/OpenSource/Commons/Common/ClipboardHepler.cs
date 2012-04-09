namespace WHC.OrderWater.Commons
{
    using System;
    using System.Collections.Specialized;
    using System.ComponentModel;
    using System.Drawing;
    using System.IO;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;

    [Browsable(false), EditorBrowsable(EditorBrowsableState.Never)]
    public class ClipboardHepler
    {
        [ThreadStatic]
        private static int qCpqRb2bV;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Clear()
        {
            Clipboard.Clear();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainsAudio()
        {
            return Clipboard.ContainsAudio();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainsData(string format)
        {
            return Clipboard.ContainsData(format);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainsFileDropList()
        {
            return Clipboard.ContainsFileDropList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainsImage()
        {
            return Clipboard.ContainsImage();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainsText()
        {
            return Clipboard.ContainsText();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static bool ContainsText(TextDataFormat format)
        {
            return Clipboard.ContainsText(format);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Stream GetAudioStream()
        {
            return Clipboard.GetAudioStream();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static object GetData(string format)
        {
            return Clipboard.GetData(format);
        }

        [MethodImpl(MethodImplOptions.NoInlining), EditorBrowsable(EditorBrowsableState.Advanced)]
        public static IDataObject GetDataObject()
        {
            return Clipboard.GetDataObject();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static StringCollection GetFileDropList()
        {
            return Clipboard.GetFileDropList();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static Image GetImage()
        {
            return Clipboard.GetImage();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetText()
        {
            return Clipboard.GetText();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetText(TextDataFormat format)
        {
            return Clipboard.GetText(format);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SafeSetClipboard(object dataObject)
        {
            GxSMkEq4hTjITdoIIVa va = new GxSMkEq4hTjITdoIIVa {
                JkKfoMY5A = dataObject,
                VZJq3SjrW = ++qCpqRb2bV
            };
            try
            {
                Clipboard.SetDataObject(va.JkKfoMY5A, true);
            }
            catch (ExternalException)
            {
                GJiJFtqg9OANCfobjwo cfobjwo = new GJiJFtqg9OANCfobjwo {
                    LqbfxwEBL = va,
                    ArbNmJ8sV = new Timer()
                };
                cfobjwo.ArbNmJ8sV.Interval = 100;
                cfobjwo.ArbNmJ8sV.Tick += new EventHandler(cfobjwo.7dwqV7ssD);
                cfobjwo.ArbNmJ8sV.Start();
            }
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetAudio(byte[] audioBytes)
        {
            Clipboard.SetAudio(audioBytes);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetAudio(Stream audioStream)
        {
            Clipboard.SetAudio(audioStream);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetData(string format, object data)
        {
            Clipboard.SetData(format, data);
        }

        [MethodImpl(MethodImplOptions.NoInlining), EditorBrowsable(EditorBrowsableState.Advanced)]
        public static void SetDataObject(DataObject data)
        {
            Clipboard.SetDataObject(data);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetFileDropList(StringCollection filePaths)
        {
            Clipboard.SetFileDropList(filePaths);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetImage(Image image)
        {
            Clipboard.SetImage(image);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetText(string text)
        {
            Clipboard.SetText(text);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetText(string text, TextDataFormat format)
        {
            Clipboard.SetText(text, format);
        }

        [CompilerGenerated]
        private sealed class GJiJFtqg9OANCfobjwo
        {
            public Timer ArbNmJ8sV;
            public ClipboardHepler.GxSMkEq4hTjITdoIIVa LqbfxwEBL;

            [MethodImpl(MethodImplOptions.NoInlining)]
            public void 7dwqV7ssD(object, EventArgs)
            {
                this.ArbNmJ8sV.Stop();
                this.ArbNmJ8sV.Dispose();
                if (ClipboardHepler.qCpqRb2bV == this.LqbfxwEBL.VZJq3SjrW)
                {
                    try
                    {
                        Clipboard.SetDataObject(this.LqbfxwEBL.JkKfoMY5A, true, 10, 50);
                    }
                    catch (ExternalException)
                    {
                    }
                }
            }
        }

        [CompilerGenerated]
        private sealed class GxSMkEq4hTjITdoIIVa
        {
            public object JkKfoMY5A;
            public int VZJq3SjrW;
        }
    }
}

