using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XCode ;

namespace DotNet.CommonEntity
{
    #region 实体类
    /// <summary>菜单表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Menu : Menu<Menu> { }

    /// <summary>角色表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Role : Role<Role> { }

    /// <summary>角色权限表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class RolePermission : RolePermission<RolePermission> { }
  
    /// <summary>类别信息</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Category : Category<Category> { }

    /// <summary>权限表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Permission : Permission<Permission> { }

    /// <summary>日志信息</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Log : Log<Log> { }

    /// <summary>系统设置表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Setting : Setting<Setting> { }

    /// <summary>用户角色表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class UserRole : UserRole<UserRole> { }

    /// <summary>用户配置信息表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class UserProfile : UserProfile<UserProfile> { }

    /// <summary>用户权限表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class UserPermission : UserPermission<UserPermission> { }

    /// <summary>用户信息</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class User : User<User> { }

    /// <summary>员工信息表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Staff : Staff<Staff> { }

    /// <summary>组织部门信息表</summary>
    [ModelCheckMode(ModelCheckModes.CheckAllTablesWhenInit)]
    public class Organize : Organize<Organize> { }    
    #endregion

    /// <summary>
    /// 封装一些常用的实体类的方法，比如初始化数据等
    /// </summary>
    public class CommonEntityHelper
    {   
        //实现权限的各类接口供外部调用
    }
}
