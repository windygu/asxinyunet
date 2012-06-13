using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCode ;

namespace DotNet.CommonEntity
{
    /// <summary>
    /// 封装一些常用的实体类的方法，比如初始化数据等
    /// </summary>
    public class CommonEntityHelper
    {
        /// <summary>
        /// 初始化实体类的所有数据
        /// </summary>
        public static void InitData()
        {
            var a = Role.FindAll();

            //new Role<Role>() { RoleName = "超级管理员", Category = "管理员", SortCode = 1, IsEnable = 1 }.Insert();
            //new Role<Role>() { RoleName = "普通管理员", Category = "管理员", SortCode = 2, IsEnable = 1 }.Insert();
            //new Role<Role>() { RoleName = "测试1", Category = "测试员", SortCode = 1, IsEnable = 1 }.Insert();
            //new Role<Role>() { RoleName = "测试2", Category = "测试员", SortCode = 2, IsEnable = 1 }.Insert();
            //new Role<Role>() { RoleName = "行政文员", Category = "行政部", SortCode = 1, IsEnable = 1 }.Insert();
            //var t = User.FindAll();
            //var t1 = Role.FindAll();
        }       
    }
}
