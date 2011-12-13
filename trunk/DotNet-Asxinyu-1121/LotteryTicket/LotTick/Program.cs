/*
 * 
 * 计划：验证结果的单独显示，表格中
 *       过滤信息的显示和传递
 *       过滤结果的显示
 * 2011-12-13 重构基本完成，基本达到上次的功能，结构更加清晰
 * 2011-12-01 开始重构整个基础类库，先设计和搭建框架，后编码 
 */


using System;

namespace LotTick
{
    class Program
    {
        static void Main(string[] args)
        {
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
