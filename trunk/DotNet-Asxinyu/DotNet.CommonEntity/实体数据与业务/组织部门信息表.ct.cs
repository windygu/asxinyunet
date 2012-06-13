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
    /// <summary>组织部门信息表</summary>
    public partial class Organize<TEntity>
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
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}组织部门表数据……", typeof(TEntity).Name);
            //添加2个角色,一个超级管理员，一个测试，同时添加类别信息
            //添加公司总部架构形式
            new Organize<Organize> { ParentId = 0, OrganizeCode = "ZB-12-01", ShortName = "公司总部", FullName = "**科技有限公司", Category = "有限责任公司", SortCode = 1 }.Insert();
            new Organize<Organize> { ParentId = 1, OrganizeCode = "ZB-12-0101", ShortName = "浙江分公司1", FullName = "浙江**科技有限公司", Category = "有限责任公司", SortCode = 2 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010101", ShortName = "公司高层", FullName = "董事会", Category = "公司部门", SortCode = 5 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010102", ShortName = "生产部", FullName = "生产部", Category = "司部门", SortCode = 7 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010103", ShortName = "技术部", FullName = "技术部", Category = "公司部门", SortCode = 9 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010104", ShortName = "行政部", FullName = "行政部", Category = "公司部门", SortCode = 11 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010105", ShortName = "财务部", FullName = "董事会", Category = "财务部", SortCode = 5 }.Insert();
            new Organize<Organize> { ParentId = 2, OrganizeCode = "ZB-12-010106", ShortName = "销售部", FullName = "销售部", Category = "公司部门", SortCode = 5 }.Insert();
            //添加类别信息
            new Category<Category> { ParentId = 0 , Name = "组织类别",SortCode = 10,Description="系统内置"}.Insert();
            int id = Category<Category>.FindByParentIdAndName(0, "组织类别").Id;//取得组织类别的Id
            new Category<Category> { ParentId = id , Name = "有限责任公司", SortCode = 11, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "股份有限公司", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "非公司企业法人", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "个人独资企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "合伙企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "中外合作企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "外商独资企业", SortCode = 17, Description = "系统内置" }.Insert();
            new Category<Category> { ParentId = id, Name = "公司部门", SortCode = 17, Description = "系统内置" }.Insert();
            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}组织部门表数据！", typeof(TEntity).Name);
        }
        #endregion
    }
}
