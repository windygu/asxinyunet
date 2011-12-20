/*
 * 
 * 计划：验证结果的单独显示，表格中
 *       DisplayData
 *       
 * 
 * 2011-12-14 基本完成通用配置信息控件的开发
 * 2011-12-13 重构基本完成，基本达到上次的功能，结构更加清晰
 * 2011-12-01 开始重构整个基础类库，先设计和搭建框架，后编码 
 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Net.Configuration;
using System.IO;
using NewLife.Configuration;


namespace LotTick
{
    class Program
    {
        static void Main(string[] args)
        {
            object e = ConfigurationManager.AppSettings["MySection111"];
            //Console.WriteLine();            
            Console.WriteLine(Config.GetConfig<string>("url"));
            //TwoColorBall t = new TwoColorBall(22); 
            //int[][] data = TwoColorBall.GetInitiaData();
            Console.ReadKey();
        }
    }

    class A
    {
        public virtual void TestA(int data)
        {
            Console.WriteLine("基类方法A:{0}",data );
        }
        public virtual void TestB(int data)
        {
            Console.WriteLine("方法B调用方法A:{0}", data);
            TestA(data);
        }
    }
    class B:A 
    {
        public override void TestA(int data)
        {
            Console.WriteLine("子类方法A:{0}",data );
        }       
    }
}
