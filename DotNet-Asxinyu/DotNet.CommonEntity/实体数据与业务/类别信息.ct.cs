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
    /// <summary>类别信息</summary>
    public partial class Category<TEntity>
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
            if (XTrace.Debug) XTrace.WriteLine("开始初始化{0}类别数据……", typeof(TEntity).Name);
            //添加常规类别,其他业务需要用到的特色类别，自动去处理完成
            //TODO:总结常规用到的类别信息，并添加
            if (XTrace.Debug) XTrace.WriteLine("完成初始化{0}类别表数据！", typeof(TEntity).Name);
        }
        #endregion
    }
}
