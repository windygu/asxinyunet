using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Xml.Serialization;
using NewLife.Log;
using System.Linq;
using XCode;
using XCode.Configuration;
using NewLife.Security;

namespace DotNet.CommonEntity
{
    /// <summary>
    /// 添加系统初始化数据
    /// </summary>
    public class InitSystemData
    {
        #region 初始化
        public static void InitAllData()
        {
            InitRole();
        }
        #endregion


        #region 角色表
        private static void InitRole()
        {
            if (Role.FindCount()> 0) return;
            // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}角色表数据……", typeof(Role).Name);
            //添加2个角色,一个超级管理员，一个测试，同时添加类别信息            
            #region 添加常规角色信息
            new Role() { RoleName = "超级管理员", Category = "管理员", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "普通管理员", Category = "管理员", SortCode = 2, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "总经理", Category = "高层领导", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "董事长", Category = "高层领导", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "测试1", Category = "测试员", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "测试2", Category = "测试员", SortCode = 2, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "行政文员", Category = "行政部", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "技术主管", Category = "技术部", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "技术员", Category = "技术部", SortCode = 2, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "化验员", Category = "技术部", SortCode = 3, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "生产主管", Category = "生产部", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "车间主任", Category = "生产部", SortCode = 2, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "销售主管", Category = "销售部", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "业务员", Category = "销售部", SortCode = 2, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "财务主管", Category = "财务部", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "会计", Category = "财务部", SortCode = 2, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "出纳", Category = "财务部", SortCode = 3, IsEnable = 1, Description = "系统内置" }.Insert();
            new Role() { RoleName = "厂长", Category = "高层领导", SortCode = 1, IsEnable = 1, Description = "系统内置" }.Insert();
            #endregion

            #region 添加角色的 类别信息
            new Category<Category> { ParentId = 0, Name = "角色类别", SortCode = 10, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "高层领导", SortCode = 2, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "管理员", SortCode = 11, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "测试员", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "行政部", SortCode = 13, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "人事部", SortCode = 15, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "技术部", SortCode = 5, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "质量部", SortCode = 6, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "财务部", SortCode = 7, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "生产部", SortCode = 3, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "销售部", SortCode = 4, Description = "系统内置" }.Insert();
            #endregion
                
            #region 添加用户信息
            new User() { UserName = "Admin", Password = DataHelper.Hash("admin"), SortCode = 1, IsEnable = 1 }.Insert ();
            new User() { UserName = "test", Password = DataHelper.Hash("test"), SortCode = 10, IsEnable = 1 }.Insert ();
            #endregion

            #region 添加用户角色关系
            new UserRole() { UserId = 1, RoleId = 1, IsEnable = 1 }.Insert ();
            new UserRole() { UserId = 2, RoleId = 3, IsEnable = 1 }.Insert ();
            #endregion
            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}角色数据！", typeof(Role ).Name);
        }
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion

        #region
        #endregion
    }
}
