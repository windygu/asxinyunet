//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseOrganizeAddForm
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
    public interface IBaseOrganizeAddForm
    {
        /// <summary>
        /// 父节点主键
        /// </summary>
        string ParentId { get; set;}

        /// <summary>
        /// 父节点全称
        /// </summary>
        string ParentFullName { get; set;}
    }
}