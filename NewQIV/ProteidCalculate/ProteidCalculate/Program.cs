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
        	string path1 = @"C:\QIV\XLJ\PTM\t.xls";
        	string[] str = new string[] {"MNRGFFNMLGRRPFPAPTAMWRPRRRRQAAPMPARNGLASQIQQLTTAVSALVIGQATR"} ;
        	double[][] data = ProteidCharacter.PredSulSiteTest(str,5,'P',6) ;
        	int row = data.GetLength (0) ;
        	int col = data[0].Length  ;
        	double[][] res = new double[row ][] ;
        	for (int i = 0 ; i <row ; i ++ )
        	{
        		double[] temp = new double[col +1 ] ;
        		Array.Copy (data[i],0,temp ,0,col ) ;
        		temp [col ] = 1 ;        		
        		res [i ] = temp ;
        	}
        	if(ConverterAlgorithm.ConvertToExcel<double>(res,path1 ,"a"))
        	{
        		Console.WriteLine ("True") ;
        	}
        	else 
        		Console.WriteLine ("False") ;
        //	string testFilePath = @"C:\QIV\XLJ\PTM\PredSulSite.xls";
//        	double rate = ProteidCharacter.SvmTest (testFilePath,res ) ;
//        	Console.WriteLine (rate.ToString ()) ;
            Console.Read();
        }
    }
}