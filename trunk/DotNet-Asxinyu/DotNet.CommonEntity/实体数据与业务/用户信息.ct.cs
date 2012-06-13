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
    /// <summary>用户信息</summary>
    public partial class User<TEntity> 
    {
        //用户的初始化信息放在角色表的初始化里面，因为是同步进行的。有了角色和用户，才能添加角色关系
    }
}
