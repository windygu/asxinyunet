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
        ///// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        //[EditorBrowsable(EditorBrowsableState.Never)]
        //protected override void InitData()
        //{
        //    base.InitData();
        //    // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
        //    // Meta.Count是快速取得表记录数

        //}
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