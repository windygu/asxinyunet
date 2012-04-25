using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections;
using System.Diagnostics;
using DotNet.Core.Commons ;

namespace DesignPattern
{
    public class Test
    {
        static void Main(string[] args)
        {
            //DbHelper.FillDataForDb("Common", 50);
            DbHelper.CopyDataBase("Common", "CopyTest",20);
        }
        
        /// 数据集合、哈希表及链表的速度测试,验证石头的总结：
        /// 数据行集合，索引访问第一
        /// 哈希桶集合，查找排序第一
        /// 链表型集合，插入删除第一
        /// 环境：采用汉字字符串进行数据的索引访问，查找排序及插入删除操作
    }
}