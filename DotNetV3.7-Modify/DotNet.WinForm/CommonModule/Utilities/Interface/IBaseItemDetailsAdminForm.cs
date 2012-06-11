﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseItemDetailsAdminForm
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
    public interface IBaseItemDetailsAdminForm
    {
        /// <summary>
        /// 目标节点
        /// </summary>
        string ParentId { get; set; }

        /// <summary>
        /// 目标表名
        /// </summary>
        string TargetTable { get; set; }
    }
}