//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    using DotNet.Utilities;

    /// <summary>
    /// IBaseOrganizeEditForm
    /// 编辑组织机构窗体
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
    public interface IBaseOrganizeEditForm
    {
        /// <summary>
        /// 编辑主键
        /// </summary>
        string EntityId { get; set;}
    }
}