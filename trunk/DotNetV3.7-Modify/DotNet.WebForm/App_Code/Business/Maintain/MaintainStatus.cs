//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;

namespace Project
{
    using DotNet.Utilities;

    /// <summary>
    /// MaintainStatus
    /// 服务状态。
    /// 
    /// 修改纪录
    /// 
    ///		2012.03.27 版本：1.0 JiRiGaLa 重新调整主键的规范化。
    ///		
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.03.27</date>
    /// </author> 
    /// </summary>    
    #region public enum MaintainStatus 服务状态
    public enum MaintainStatus
    {
        /// <summary>
        /// 00 草稿状态
        /// </summary>
        [EnumDescription("草稿")]
        Draft = 0,

        /// <summary>
        /// 01 已提交
        /// </summary>
        [EnumDescription("已提交")]
        Submitted = 1,
        
        /// <summary>
        /// 02 待维修
        /// </summary>
        [EnumDescription("待维修")]
        MaintainWaiting = 2,  

        /// <summary>
        /// 03 维修中
        /// </summary>
        [EnumDescription("维修中")]
        MaintainProcessing = 3,  
        
        /// <summary>
        /// 04 已维修
        /// </summary>
        [EnumDescription("已维修")]
        MaintainProcessed = 4,
        
        /// <summary>
        /// 05 完成
        /// </summary>
        [EnumDescription("完成")]
        Complete = 5,

        /// <summary>
        /// 06 废弃
        /// </summary>
        [EnumDescription("废弃")]
        AuditQuash = 6
    }
    #endregion
}