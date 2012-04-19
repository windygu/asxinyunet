//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseOrganizeRoleAddForm
    /// 选择组织机构窗体
    /// 
    /// 修改纪录
    ///
    ///		2008.06.04 版本：1.0 JiRiGaLa 创建。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2008.06.04</date>
    /// </author> 
    /// </summary>
    public interface IBaseOrganizeRoleAddForm
    {
        /// <summary>
        /// 被选中的组织机构主键
        /// </summary>
        string OrganizeId { get; set;}

        /// <summary>
        /// 被选中的组织机构全名
        /// </summary>
        string OrganizeFullName { get; set;}
    }
}