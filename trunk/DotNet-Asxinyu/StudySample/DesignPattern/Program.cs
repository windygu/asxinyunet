using System.Collections.Generic;
using System.Linq;
using System.Text;
using System;
using System.Collections;
using System.Diagnostics;
using DotNet.Core.Commons ;

namespace DesignPattern
{
    public class SequenceTest
    {
        //配置第一个单元：部门编号 JSB,3个字符，分隔符为-，不是流水号,填充可以不设置或者随意设置
        static SeqUnitSetting s1 = new SeqUnitSetting("JSB", 3, false, false, true, '0', '-');
        //配置第二个单元：按照当前系统时间的日期来，6位，分隔符，如果不需要流水号，那么就不要设置分隔符
        static SeqUnitSetting s2 = new SeqUnitSetting("yyMMdd", 6, true, false, false);
        //配置最后一个单元：流水号，一般单据号最后是变动的数字,填充#号，3位
        static SeqUnitSetting s3 = new SeqUnitSetting("", 3, false, true, true, '#');     
        public static string GetSequence()
        {
            return s1.CurrentSquenceString + s2.CurrentSquenceString + s3.GetCurrentSerialNumber ();
        }
    }

    public class Test
    {       
        static void Main(string[] args)
        {            
            //DbHelper.FillDataForDb("Common", 50);
            DbHelper.CopyDataBase("CommonMSSQL", "CommonMysql", 20);
            DbHelper.CopyDataBase("CommonMysql", "CommonMSSQL2", 20);
            //DbHelper.CopyDataBase("CommonAccess", "CommonSqlite", 50);
            //DbHelper.CopyDataBase("CommonSqlite", "Common", 50);
            Console.ReadKey();
            
        }
        static void TestSequence()
        {
            SeqUnitSetting s1 = new SeqUnitSetting("JSB", 3, false, false, true, '0','-');
            SeqUnitSetting s2 = new SeqUnitSetting("yyMMdd", 6, true, false, false);
            Console.WriteLine (s1.CurrentSquenceString  +s2.CurrentSquenceString  +"001");
        }
        /// 数据集合、哈希表及链表的速度测试,验证石头的总结：
        /// 数据行集合，索引访问第一
        /// 哈希桶集合，查找排序第一
        /// 链表型集合，插入删除第一
        /// 环境：采用汉字字符串进行数据的索引访问，查找排序及插入删除操作
    }
}