using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
