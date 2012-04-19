//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseRoleSelect
    /// 选择角色窗体
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
    public interface IBaseSelectRoleForm
    {
        /// <summary>
        /// 移出的主键数组
        /// </summary>
        string[] RemoveIds { get; set;}

        /// <summary>
        /// 只显示角色
        /// </summary>
        bool ShowRoleOnly{get; set;}

        /// <summary>
        /// 是否允许选择空
        /// </summary>
        bool AllowNull { get; set;}

        /// <summary>
        /// 是否允许选择
        /// </summary>
        bool AllowSelect { get; set; }

        /// <summary>
        /// 是否允许多个选择
        /// </summary>
        bool MultiSelect { get; set;}

        /// <summary>
        /// 按什么权限域获取角色列表
        /// </summary>
        string PermissionItemScopeCode { get; set; }

        /// <summary>
        /// 被选中的角色主键
        /// </summary>
        string SelectedId { get; set;}

        /// <summary>
        /// 被选中的角色全名
        /// </summary>
        string SelectedFullName { get; set;}

        /// <summary>
        /// 打开节点
        /// </summary>
        string OpenId { get; set;}

        /// <summary>
        /// 被选中的主键数组
        /// </summary>
        string[] SelectedIds { get; set;}
    }
}