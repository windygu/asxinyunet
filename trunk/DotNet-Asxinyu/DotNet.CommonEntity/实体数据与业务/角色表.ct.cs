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
    /// <summary>角色表</summary>
    public partial class Role<TEntity>
    {
        #region 数据初始化
        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            base.InitData();

            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            // Meta.Count是快速取得表记录数
            if (Meta.Count > 0) return;
            // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}角色表数据……", typeof(TEntity).Name);
            //添加2个角色,一个超级管理员，一个测试，同时添加类别信息

            #region 添加常规角色信息
            new Role<Role>() { RoleName = "超级管理员", Category = "管理员", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "普通管理员", Category = "管理员", SortCode = 2, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "测试1", Category = "测试员", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "测试2", Category = "测试员", SortCode = 2, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "行政文员", Category = "行政部", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "技术主管", Category = "技术部", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "技术员", Category = "技术部", SortCode = 2, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "化验员", Category = "技术部", SortCode = 3, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "生产主管", Category = "生产部", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "车间主任", Category = "生产部", SortCode = 2, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "销售主管", Category = "销售部", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "业务员", Category = "销售部", SortCode = 2, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "财务主管", Category = "财务部", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "会计", Category = "财务部", SortCode = 2, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "出纳", Category = "财务部", SortCode = 3, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "厂长", Category = "高层领导", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "总经理", Category = "高层领导", SortCode = 1, IsEnable = 1 }.Insert();
            new Role<Role>() { RoleName = "董事长", Category = "高层领导", SortCode = 1, IsEnable = 1 }.Insert();
            #endregion

            #region 添加角色的 类别信息
            new Category<Category> { ParentId = 0, Name = "角色类别", SortCode = 10, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "管理员", SortCode = 11, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "测试员", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "行政部", SortCode = 13, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "人事部", SortCode = 15, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "技术部", SortCode = 5, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "质量部", SortCode = 6, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "财务部", SortCode = 7, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "生产部", SortCode = 3, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "销售部", SortCode = 4, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = 1, Name = "高层领导", SortCode = 4, Description = "系统内置" }.Insert();
            #endregion

            #region 添加用户信息
            new User () { UserName ="Admin",Password = DataHelper.Hash ("admin"), SortCode = 1,IsEnable = 1};
            new User () { UserName = "test", Password = DataHelper.Hash("test"), SortCode = 10, IsEnable = 1 };
            #endregion

            #region 添加用户角色关系
            new UserRole() { UserId = 1, RoleId = 1, IsEnable = 1 };
            new UserRole() { UserId = 2, RoleId = 3, IsEnable = 1 };
            #endregion
            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}角色表数据！", typeof(TEntity).Name);
        }
        #endregion

        #region 常规删除逻辑
        /// <summary>已重载。删除关联数据</summary>
        /// <returns></returns>
        protected override int OnDelete()
        {
            //对关键基础数据表，删除一般变为不可用,同时也增加物理删除方法
            //删除角色，需要去 UserRole表和RolePermission表停用相应的数据
            if (RolePermissions != null)
            {
                RolePermissions.SetItem(RolePermission._.IsEnable, 0);
                RolePermissions.Update();
            }
            if (UserRoles != null)
            {
                UserRoles.SetItem(UserRole._.IsEnable, 0);
                UserRoles.Update();
            }
            return base.OnDelete();
        }
        public override int Delete()
        {
            IsEnable = 0;//不是真正的删除,只是停用，另外新建方法定期对无效数据进行清理
            return base.Update();
        }
        #endregion
        
        #region 物理删除
        /// <summary>
        /// 真正的物理删除方法
        /// </summary>
        public virtual int PhysicDelete()
        {
            if (RolePermissions != null) RolePermissions.Delete();
            if (UserRoles != null) UserRoles.Delete();
            return base.Delete();
        }
        #endregion
    }
}
