using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections;
using System.Diagnostics;

namespace DesignPattern
{
    public class Test
    {
        static void Main(string[] args)
        {

        }
          /// <summary>
        /// 数据集合、哈希表及链表的速度测试,验证石头的总结：
        /// 数据行集合，索引访问第一
        /// 哈希桶集合，查找排序第一
        /// 链表型集合，插入删除第一
        /// 环境：采用汉字字符串进行数据的索引访问，查找排序及插入删除操作
        /// </summary>
        public void CollectionValidate()
        {
            //石头的代码
            int max = 1000000;
            List<String> list = new List<string>(max );
            Hashtable ht = new Hashtable(max);
            LinkedList<string> link = new LinkedList<string>();

            Random rnd = new Random((Int32)DateTime.Now.Ticks);
            for (int i = 0; i < max; i++)
            {
                Int32 len = rnd.Next(0, 20);
                Char[] cs = new Char[len];
                for (int j = 0; j < len; j++)
                {
                    cs[j] = (Char)rnd.Next(0x4e00, 0x9fa5);
                }
                string t = new String(cs);
                //逐一添加到上述集合中
                list.Add(t);
                ht.Add(t, string.Empty);
                link.AddLast(t);
            }            
            //分别测试
            Stopwatch sw = new Stopwatch();
            sw.Start();
            String str = null;
            for (int i = 0; i < max; i++)
            {
                str = list[i];
                if(list.Contains (str ))

            }
            sw.Stop();
            Console.WriteLine("双列表：{0}", sw.Elapsed);

            list = new List<string>();
            sw.Start();
            for (int i = 0; i < max; i++)
            {
                str = ss[i];
                if (!list.Contains(str)) list.Add(str);
            }
            sw.Stop();
            Console.WriteLine("单列表：{1}", sw.Elapsed);
        }    
    }
}