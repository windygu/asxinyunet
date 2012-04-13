using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DesignPattern
{
    /// <summary>
    /// 委托与事件学习-参考大话设计模式中的猫和老鼠的例子:
    /// 1个猫 Tom，2只老鼠 Jerry和Jack，只要Tom喊一声，老鼠就会喊 快跑，猫来了
    /// </summary>
    public class DelegateExample
    {
        //static void Main(string[] args)
        //{
        //    Cat cat = new Cat("Tom");

        //    Mouse mouseJerry = new Mouse("Jerry");
        //    Mouse mouseJack = new Mouse("Jack");
         
        //    cat.CatShout += new Cat.CatEventHander(mouseJack.Run);
        //    cat.CatShout += new Cat.CatEventHander(mouseJerry.Run);
        //    cat.Shout();
        //    Console.Read();
        //}
    }
        
    public class Cat
    {
        /// <summary>
        /// 猫的名称
        /// </summary>
        public string Name { get; set; }

        public Cat(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// 猫说话
        /// </summary>
        public void Shout()
        {
            Console.WriteLine("Hi ,我是{0}",Name );
            //如果事件中有对象，则执行
            if (CatShout != null) CatShout();
        }
        /// <summary>
        /// 声明一个"猫叫"的委托
        /// </summary>
        public delegate void CatEventHander();
        /// <summary>
        /// 声明一个猫叫的事件
        /// </summary>
        public event CatEventHander CatShout;
    }
    public class Mouse
    {
         /// <summary>
        /// 老鼠的名称
        /// </summary>
        public string Name { get; set; }

        public Mouse(string name)
        {
            this.Name = name;
        }
        /// <summary>
        /// 老鼠跑的方法(猫来的时候，老鼠就跑)
        /// </summary>
        public void Run()
        {
            Console.WriteLine("Hi,我是{0},快跑，猫来了....",Name );
        }
    }
}
