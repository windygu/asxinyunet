//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace DotNet.Business
{
    /// <summary>
    /// LeaveTable
    /// 请假单
    /// 
    /// 修改纪录
    /// 
    /// 2012-04-13 版本：1.0 JiRiGaLa 创建主键。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    /// <name>JiRiGaLa</name>
    /// <date>2012-04-13</date>
    /// </author>
    /// </summary>
    public partial class LeaveEntity
    {
        ///<summary>
        /// 请假单
        ///</summary>
        [NonSerialized]
        public static string TableName = "Leave";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 申请人主键
        ///</summary>
        [NonSerialized]
        public static string FieldUserId = "UserId";

        ///<summary>
        /// 申请人姓名
        ///</summary>
        [NonSerialized]
        public static string FieldUserName = "UserName";

        ///<summary>
        /// 部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        ///<summary>
        /// 部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentName = "DepartmentName";

        ///<summary>
        /// 单据编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 工作交接人
        ///</summary>
        [NonSerialized]
        public static string FieldTransferOfPeople = "TransferOfPeople";

        ///<summary>
        /// 联系电话
        ///</summary>
        [NonSerialized]
        public static string FieldTelephone = "Telephone";

        ///<summary>
        /// 请假原因
        ///</summary>
        [NonSerialized]
        public static string FieldReason = "Reason";

        ///<summary>
        /// 请假天数
        ///</summary>
        [NonSerialized]
        public static string FieldDay = "Day";

        ///<summary>
        /// 请假类别
        ///</summary>
        [NonSerialized]
        public static string FieldItemsLeaveCategory = "ItemsLeaveCategory";

        ///<summary>
        /// 开始日期
        ///</summary>
        [NonSerialized]
        public static string FieldStartTime = "StartTime";

        ///<summary>
        /// 结束日期
        ///</summary>
        [NonSerialized]
        public static string FieldEndTime = "EndTime";

        ///<summary>
        /// 工作交接说明
        ///</summary>
        [NonSerialized]
        public static string FieldTransferInstructions = "TransferInstructions";

        ///<summary>
        /// 审核状态
        ///</summary>
        [NonSerialized]
        public static string FieldAuditStatus = "AuditStatus";

        ///<summary>
        /// 排序码
        ///</summary>
        [NonSerialized]
        public static string FieldSortCode = "SortCode";

        ///<summary>
        /// 删除标记
        ///</summary>
        [NonSerialized]
        public static string FieldDeletionStateCode = "DeletionStateCode";

        ///<summary>
        /// 有效标志
        ///</summary>
        [NonSerialized]
        public static string FieldEnabled = "Enabled";

        ///<summary>
        /// 描述
        ///</summary>
        [NonSerialized]
        public static string FieldDescription = "Description";

        ///<summary>
        /// 创建日期
        ///</summary>
        [NonSerialized]
        public static string FieldCreateOn = "CreateOn";

        ///<summary>
        /// 创建用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldCreateUserId = "CreateUserId";

        ///<summary>
        /// 创建用户
        ///</summary>
        [NonSerialized]
        public static string FieldCreateBy = "CreateBy";

        ///<summary>
        /// 修改日期
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedOn = "ModifiedOn";

        ///<summary>
        /// 修改用户主键
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedUserId = "ModifiedUserId";

        ///<summary>
        /// 修改用户
        ///</summary>
        [NonSerialized]
        public static string FieldModifiedBy = "ModifiedBy";
    }
}
