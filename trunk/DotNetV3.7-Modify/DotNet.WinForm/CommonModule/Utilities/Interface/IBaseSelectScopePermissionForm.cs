//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseSelectScopePermissionForm
    /// 选择权限窗体
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
    public interface IBaseSelectScopePermissionForm
    {
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        bool AllowNull { get; set;}

        /// <summary>
        /// 是否允许选择
        /// </summary>
        bool AllowSelect { get; set; }

        /// <summary>
        /// 被选中的角色主键
        /// </summary>
        string SelectedId { get; set;}

        /// <summary>
        /// 被选中的角色全名
        /// </summary>
        string SelectedFullName { get; set;}
    }
}