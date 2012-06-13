using System;
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
    /// <summary>菜单表：自定义业务</summary>
    public partial class Menu<TEntity>
    {
        /// <summary>首次连接数据库时初始化数据，仅用于实体类重载，用户不应该调用该方法</summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void InitData()
        {
            base.InitData();

            // InitData一般用于当数据表没有数据时添加一些默认数据，该实体类的任何第一次数据库操作都会触发该方法，默认异步调用
            // Meta.Count是快速取得表记录数
            if (Meta.Count > 0) return;
            // 需要注意的是，如果该方法调用了其它实体类的首次数据库操作，目标实体类的数据初始化将会在同一个线程完成
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}菜单表数据……", typeof(TEntity).Name);
            //由于菜单与实际访问的地址，链接有关，因此需要根据实际情况去扫描相应的文件夹才行
            //TODO:借鉴Newlife实体类的思路，进行扫描
            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}菜单表数据！", typeof(TEntity).Name);
        }
    }
}
