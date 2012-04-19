//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseSelectItemDetailsForm
    /// 选择基础编码窗体
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
    public interface IBaseSelectItemDetailsForm
    {
        /// <summary>
        /// 是否允许选择空
        /// </summary>
        bool AllowNull { get; set; }

        /// <summary>
        /// 父亲节点
        /// </summary>
        string ParentId { get; set; }

        /// <summary>
        /// 分类主键
        /// </summary>
        string CategoryId { get; set;}

        /// <summary>
        /// 被选中的角色主键
        /// </summary>
        string SelectedId { get; set; }

        /// <summary>
        /// 被选中的角色编号
        /// </summary>
        string SelectedCode { get; set; }

        /// <summary>
        /// 被选中的角色全名
        /// </summary>
        string SelectedFullName { get; set; }
    }
}