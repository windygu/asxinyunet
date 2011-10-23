using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace ProtendCalculateForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
//            if ((DateTime.Now.Year==2011)&&(DateTime.Now.Month ==1)&&(DateTime.Now.Day <15))
//            {
                Application.Run(new CalcuteForm ());
//            }            
        }
    }
}
