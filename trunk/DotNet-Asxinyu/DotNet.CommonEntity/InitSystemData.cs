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

        #region 组织部门表
        private static void InitOrganize()
        {
            if (Organize.FindCount ()> 0) return;            
            //添加公司总部架构形式
            new Organize<Organize> { ParentId = 0, OrganizeCode = "ZB-12-01", ShortName = "公司总部", FullName = "**科技有限公司", Category = "有限责任公司", SortCode = 1 }.Insert();
            new Organize<Organize> { ParentId = 1, OrganizeCode = "ZB-12-0101", ShortName = "浙江分公司1", FullName = "浙江**科技有限公司", Category = "有限责任公司", SortCode = 2 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010101", ShortName = "公司高层", FullName = "董事会", Category = "公司部门", SortCode = 5 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010102", ShortName = "生产部", FullName = "生产部", Category = "公司部门", SortCode = 7 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010103", ShortName = "技术部", FullName = "技术部", Category = "公司部门", SortCode = 9 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010104", ShortName = "行政部", FullName = "行政部", Category = "公司部门", SortCode = 11 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010105", ShortName = "财务部", FullName = "董事会", Category = "财务部", SortCode = 5 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010106", ShortName = "销售部", FullName = "销售部", Category = "公司部门", SortCode = 5 }.Insert();
            //添加类别信息
            new Category<Category> { ParentId = 0, Name = "组织类别", SortCode = 10, Description = "系统内置" }.Insert();
            int id = Category<Category>.FindByParentIdAndName(0, "组织类别").Id;//取得组织类别的Id
            new Category<Category> { ParentId = id, Name = "有限责任公司", SortCode = 11, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "股份有限公司", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "非公司企业法人", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "个人独资企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "合伙企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "中外合作企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "外商独资企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "公司部门", SortCode = 17, Description = "系统内置" }.Insert();
            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}组织部门表数据！", typeof(Organize ).Name);
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
    }
}
