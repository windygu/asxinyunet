namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Collections;
    using System.Drawing;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Windows.Forms;

    public static class RTFUtility
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AlignCenter(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa88c) + s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AlignFull(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8c2) + s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AlignLeft(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa89e) + s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string AlignRight(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8b0) + s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Bold(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa82a) + s + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa836));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string BuildTable(int NumRows, int NumCells, ArrayList values)
        {
            StringBuilder builder = new StringBuilder();
            int num = NumRows * NumCells;
            int count = values.Count;
            while (count <= num)
            {
                values.Add("");
                count++;
            }
            IEnumerator enumerator = values.GetEnumerator();
            enumerator.MoveNext();
            int num3 = 1;
            for (int i = 1; i <= NumRows; i++)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa30));
                num3 = 1;
                count = 1;
                while (count <= NumCells)
                {
                    builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa62) + num3);
                    num3++;
                    count++;
                }
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa72));
                count = 1;
                while (count <= NumCells)
                {
                    builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa78) + enumerator.Current.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa88));
                    enumerator.MoveNext();
                    count++;
                }
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaaa2));
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaaa8));
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaaae));
                num3 = 1;
                for (count = 1; count <= NumCells; count++)
                {
                    builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaaea) + num3);
                    num3++;
                }
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xac5e));
            }
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xac6e) + builder.ToString() + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xac8a));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string FontSize(string s, int n)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8d4) + Convert.ToString((int) (n * 2)) + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8e2) + s);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Italic(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa844) + s + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa850));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string LineBreak()
        {
            return LineBreak(1);
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string LineBreak(int n)
        {
            string str = "";
            for (int i = 0; i < n; i++)
            {
                str = str + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa87c);
            }
            return str;
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string ParagraphBorder(string s)
        {
            s = s.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8ea), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa8f6));
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa904) + s + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xaa20));
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string RtfToHtml(RichTextBox m_pText)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xac9e));
            m_pText.SelectionStart = 0;
            m_pText.SelectionLength = 1;
            Font selectionFont = m_pText.SelectionFont;
            Color selectionColor = m_pText.SelectionColor;
            Color selectionBackColor = m_pText.SelectionBackColor;
            int num = 0;
            int startIndex = 0;
            while (m_pText.Text.Length > m_pText.SelectionStart)
            {
                m_pText.SelectionStart++;
                m_pText.SelectionLength = 1;
                if ((m_pText.Text.Length == m_pText.SelectionStart) || ((((selectionFont.Name != m_pText.SelectionFont.Name) || (selectionFont.Size != m_pText.SelectionFont.Size)) || ((selectionFont.Style != m_pText.SelectionFont.Style) || (selectionColor != m_pText.SelectionColor))) || (selectionBackColor != m_pText.SelectionBackColor)))
                {
                    string str = m_pText.Text.Substring(startIndex, m_pText.SelectionStart - startIndex);
                    string str2 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacb2) + selectionColor.R.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacb8)) + selectionColor.G.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacc0)) + selectionColor.B.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacc8));
                    string str3 = kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacd0) + selectionBackColor.R.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacd6)) + selectionBackColor.G.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacde)) + selectionBackColor.B.ToString(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xace6));
                    string str4 = "";
                    string str5 = "";
                    if (selectionFont.Bold)
                    {
                        str4 = str4 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacee);
                        str5 = str5 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xacf8);
                    }
                    if (selectionFont.Italic)
                    {
                        str4 = str4 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad04);
                        str5 = str5 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad0e);
                    }
                    if (selectionFont.Underline)
                    {
                        str4 = str4 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad1a);
                        str5 = str5 + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad24);
                    }
                    builder.Append(string.Concat(new object[] { kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad30), str2, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad5c), selectionFont.Size, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad78), selectionFont.FontFamily.Name, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xad9c), str3, kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xadc6), str4, str.Replace(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xadd0), kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xadd6)), str5 }));
                    startIndex = m_pText.SelectionStart;
                    selectionFont = m_pText.SelectionFont;
                    selectionColor = m_pText.SelectionColor;
                    selectionBackColor = m_pText.SelectionBackColor;
                    num++;
                }
            }
            for (int i = 0; i < num; i++)
            {
                builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xade4));
            }
            builder.Append(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xadf6));
            return builder.ToString();
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string Underline(string s)
        {
            return (kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa85e) + s + kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xa86c));
        }
    }
}

