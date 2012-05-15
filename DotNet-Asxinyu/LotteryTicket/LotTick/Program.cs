/*
 * 
 * 计划：验证结果的单独显示，表格中
 *       DisplayData
 * 2012-04-20 对指标进行检验，并进一步增加指标种类，分为单期计算指标和多期计算指标
 * 2012-03-07 增加异步调用处理方法
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
          
            //LotTickData lot1 = new LotTickData(new int[] { 1, 2, 3, 6, 7, 10, 12, 16 });
            //LotTickData lot2 = new LotTickData(new int[] { 1, 2, 3, 6, 7, 8,9, 12, 16 });
            //LotTickData lot3 = new LotTickData(new int[] { 1, 2, 5, 6, 9, 10, 11, 12 });
            //Index_红最长连续数 model = new Index_红最长连续数();
            //Console.WriteLine (model.GetOneResult (lot1 ).ToString ());
            //Console.WriteLine(model.GetOneResult(lot2).ToString());
            //Console.WriteLine(model.GetOneResult(lot3).ToString());
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
