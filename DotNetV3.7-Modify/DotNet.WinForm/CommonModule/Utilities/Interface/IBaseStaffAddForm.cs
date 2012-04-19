//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace DotNet.WinForm
{
    /// <summary>
    /// IBaseStaffAddForm
    /// 添加员工窗体
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
    public interface IBaseStaffAddForm
    {
        /// <summary>
        /// 被选中的公司主键
        /// </summary>
        string CompanyId { get; set;}

        /// <summary>
        /// 被选中的公司全名
        /// </summary>
        string CompanyName { get; set;}

        /// <summary>
        /// 被选中的部门主键
        /// </summary>
        string DepartmentId { get; set;}

        /// <summary>
        /// 被选中的部门全名
        /// </summary>
        string DepartmentName { get; set;}
    }
}