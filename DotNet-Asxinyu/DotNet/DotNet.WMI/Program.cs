using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections;
using System.Diagnostics;

namespace DotNet.WMI
{ 
    public class Test
    {       
        static void Main(string[] args)
        {
            Console.WriteLine(SystemInfo.GetAllConfigInfoFormComputer(WMI_ClassNames.Win32_BIOS));
            Console.ReadKey();
        }      
    }
}