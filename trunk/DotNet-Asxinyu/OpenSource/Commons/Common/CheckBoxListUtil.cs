namespace WHC.OrderWater.Commons
{
    using 1YyIjYqRnHRBNetelZO;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class CheckBoxListUtil
    {
        [MethodImpl(MethodImplOptions.NoInlining)]
        public static string GetCheckedItems(CheckedListBox cblItems)
        {
            string str = "";
            for (int i = 0; i < cblItems.CheckedItems.Count; i++)
            {
                if (cblItems.GetItemChecked(i))
                {
                    str = str + string.Format(kHtXIHqmeHOlI8PlpVR.7dwqV7ssD(0xd5de), cblItems.GetItemText(cblItems.Items[i]));
                }
            }
            return str.Trim(new char[] { ',' });
        }

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void SetCheck(CheckedListBox cblItems, string valueList)
        {
            string[] strArray = valueList.Split(new char[] { ',' });
            foreach (string str in strArray)
            {
                for (int i = 0; i < cblItems.Items.Count; i++)
                {
                    if (cblItems.GetItemText(cblItems.Items[i]) == str)
                    {
                        cblItems.SetItemChecked(i, true);
                    }
                }
            }
        }
    }
}

