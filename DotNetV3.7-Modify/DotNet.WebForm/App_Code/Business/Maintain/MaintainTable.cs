//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Jirisoft TECH, Ltd.
//--------------------------------------------------------------------

using System;

namespace Project
{
    /// <summary>
    /// MaintainTable
    /// 故障报修
    ///
    /// 修改纪录
    ///
    ///		2012-02-17 版本：1.0  创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name></name>
    ///		<date>2012-02-17</date>
    /// </author>
    /// </summary>
    public partial class MaintainEntity
    {
        ///<summary>
        /// 故障报销
        ///</summary>
        [NonSerialized]
        public static string TableName = "Maintain";

        ///<summary>
        /// 主键
        ///</summary>
        [NonSerialized]
        public static string FieldId = "Id";

        ///<summary>
        /// 单据编号
        ///</summary>
        [NonSerialized]
        public static string FieldCode = "Code";

        ///<summary>
        /// 部门主键
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentId = "DepartmentId";

        ///<summary>
        /// 员工工号
        ///</summary>
        [NonSerialized]
        public static string FieldUserCode = "UserCode";

        ///<summary>
        /// 部门名称
        ///</summary>
        [NonSerialized]
        public static string FieldDepartmentName = "DepartmentName";

        ///<summary>
        /// 办公地点
        ///</summary>
        [NonSerialized]
        public static string FieldOfficeLocation = "OfficeLocation";

        ///<summary>
        /// 联系电话
        ///</summary>
        [NonSerialized]
        public static string FieldTelephone = "Telephone";

        ///<summary>
        /// 服务状态
        ///</summary>
        [NonSerialized]
        public static string FieldServiceState = "ServiceState";

        ///<summary>
        /// 申报时间
        ///</summary>
        [NonSerialized]
        public static string FieldReportingTime = "ReportingTime";

        ///<summary>
        /// 完成时间
        ///</summary>
        [NonSerialized]
        public static string FieldCompletionTime = "CompletionTime";

        ///<summary>
        /// 负责人(维修人员)
        ///</summary>
        [NonSerialized]
        public static string FieldMaintenancePersonnel = "MaintenancePersonnel";

        ///<summary>
        /// 故障原因
        ///</summary>
        [NonSerialized]
        public static string FieldMalfunctionCause = "MalfunctionCause";

        ///<summary>
        /// 故障等级
        ///</summary>
        [NonSerialized]
        public static string FieldBugLevel = "BugLevel";

        ///<summary>
        /// 故障类别
        ///</summary>
        [NonSerialized]
        public static string FieldBugCategory = "BugCategory";

        ///<summary>
        /// 处理耗时（分钟）
        ///</summary>
        [NonSerialized]
        public static string FieldProcessTime = "ProcessTime";

        ///<summary>
        /// IP
        ///</summary>
        [NonSerialized]
        public static string FieldIP = "IP";

        ///<summary>
        /// 电脑用户名
        ///</summary>
        [NonSerialized]
        public static string FieldComputerUserName = "ComputerUserName";

        ///<summary>
        /// 密码
        ///</summary>
        [NonSerialized]
        public static string FieldComputerPassword = "ComputerPassword";

        ///<summary>
        /// 受理人主键
        ///</summary>
        [NonSerialized]
        public static string FieldProcessorId = "ProcessorId";

        ///<summary>
        /// 受理人姓名
        ///</summary>
        [NonSerialized]
        public static string FieldProcessorName = "ProcessorName";

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
