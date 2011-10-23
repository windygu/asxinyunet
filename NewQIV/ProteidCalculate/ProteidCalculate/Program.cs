using System;
using System.Collections ; 
using System.Collections.Generic;
using System.Text;
using MathWorks.MATLAB.NET.Utility;
using MathWorks.MATLAB.NET.Arrays;
using KdTree; 
using DotNet.Tools ;

namespace ProteidCalculate
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = "VDISRDNKIILLSDE";
            double[] res = ProteidCharacter.NewWacc_OneSeqence(str , 7);
            Console.Read();
        }
    }
}