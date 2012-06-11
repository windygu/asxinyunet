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
            InitRole();
            InitCategory();
            InitUser();
            InitUserRole();
        }

        #region 初始化角色
        static void InitRole()
        {
            Role<Role> role = new Role<Role>();
            role.SystemId = 1;
            role.OrganizeId = 1;
            role.RoleName = "超级管理员";
            role.Category = "Administrator";
            role.SortCode = 1;
            role.IsEnable = 1;
            role.DeletionStatusCode = 0;
            role.Description = "系统最高管理员,权限最大";
            role.Insert();
        }
        #endregion

        #region 初始化类别
        //初始化类别表，如角色类别这些类似的东西
        static void InitCategory()
        {
            Category<Category> category = new Category<Category>();
            category.SystemId = 1 ;
            category.ParentId = 0 ;//0为根节点
            category.Name = "RoleCategory";
            category.DisplayName = "角色类别";
            category.SortCode = 10;//留一些给其他优先级高的用
            category.IsEnable = 1;
            category.DeletionStatusCode = 0;
            category.Description = "角色表中角色类别";
            category.Insert();

            //添加子节点1
            Category<Category> category1 = new Category<Category>();
            category1.SystemId = 1;
            category1.ParentId = 1;//0为根节点
            category1.Name = "Administrator";
            category1.DisplayName = "管理员";
            category1.SortCode = 20;//留一些给其他优先级高的用
            category1.IsEnable = 1;
            category1.DeletionStatusCode = 0;
            category1.Description = "管理员类别，包括普通，超级等";
            category1.Insert();

            //添加子节点2
            Category<Category> category2 = new Category<Category>();
            category2.SystemId = 1;
            category2.ParentId = 1;//0为根节点
            category2.Name = "Test";
            category2.DisplayName = "测试员";
            category2.SortCode = 30;//留一些给其他优先级高的用
            category2.IsEnable = 1;
            category2.DeletionStatusCode = 0;
            category2.Description = "测试人员,可以分级设置";
            category2.Insert();

            //添加孙节点
            Category<Category> category3 = new Category<Category>();
            category3.SystemId = 1;
            category3.ParentId = 2;//0为根节点
            category3.Name = "SuperAdmin";
            category3.DisplayName = "超级管理员";
            category3.SortCode = 10;//留一些给其他优先级高的用
            category3.IsEnable = 1;
            category3.DeletionStatusCode = 0;
            category3.Description = "系统最高权限用户";
            category3.Insert();

            //添加孙节点
        }
        #endregion

        #region  初始化用户信息
        static void InitUser()
        {
            User<User> user = new User<User>();
            user.StaffId  = 0;
            user.UserName = "Admin";
            user.Password = "admin".GetHashCode().ToString ();
            user.SortCode = 10;
            user.IsEnable = 1;
            user.DeletionStatusCode = 0;
            user.Description = "管理员，无员工数据";
            user.Insert();
        }
        #endregion

        #region 初始化用户角色信息
        static void InitUserRole()
        {
            UserRole<UserRole> userRole = new UserRole<UserRole>();
            userRole.UserId = 1;
            userRole.RoleId = 1;
            userRole.SortCode = 10;
            userRole.IsEnable = 1;
            userRole.DeletionStatusCode = 0;
            userRole.Insert();
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
    }
}
