namespace WHC.OrderWater.Commons
{
    using Microsoft.Office.Interop.Word;
    using System;
    using System.Runtime.CompilerServices;
    using System.Windows.Forms;

    public class WordCombineUtil
    {
        public static object Miss_Object = Missing.Value;

        [MethodImpl(MethodImplOptions.NoInlining)]
        public static void Combine(string[] orgs, ref object dest)
        {
            if ((orgs != null) && (orgs.Length >= 2))
            {
                ApplicationClass class2 = new ApplicationClass();
                object obj4 = orgs[0];
                Document document = class2.get_Documents().Open(ref obj4, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
                class2.get_Selection().WholeStory();
                class2.get_Selection().Copy();
                class2.get_Selection().Paste();
                Clipboard.Clear();
                string str = string.Empty;
                object obj5 = false;
                object obj6 = false;
                object obj7 = false;
                object obj8 = (WdUnits) 5;
                for (int i = 1; i < orgs.Length; i++)
                {
                    str = orgs[i];
                    class2.get_Selection().InsertBreak(ref Miss_Object);
                    class2.get_Selection().InsertFile(str, ref Miss_Object, ref obj5, ref obj6, ref obj7);
                }
                document.SaveAs(ref dest, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object, ref Miss_Object);
                document.Close(ref Miss_Object, ref Miss_Object, ref Miss_Object);
                class2.Quit(ref Miss_Object, ref Miss_Object, ref Miss_Object);
                class2 = null;
            }
        }
    }
}

