namespace EntLib.Controls.WinForm
{
    using System;
    using System.Reflection;

    public class LoadFormAndShow
    {
        public static object loadandshow(string fname, string classname) { return Activator.CreateInstance(Assembly.LoadFrom(fname).GetType(classname)); }
    }
}
