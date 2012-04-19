//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Jirisoft TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Data;

namespace Project
{
    using DotNet.Utilities;

    /// <summary>
    /// MaintainEntity
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
    [Serializable]
    public partial class MaintainEntity
    {
        private string id = string.Empty;
        /// <summary>
        /// 主键
        /// </summary>
        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private string code = string.Empty;
        /// <summary>
        /// 单据编号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string departmentId = string.Empty;
        /// <summary>
        /// 部门主键
        /// </summary>
        public string DepartmentId
        {
            get
            {
                return this.departmentId;
            }
            set
            {
                this.departmentId = value;
            }
        }

        private string useerCode = string.Empty;
        /// <summary>
        /// 员工工号
        /// </summary>
        public string UserCode
        {
            get
            {
                return this.useerCode;
            }
            set
            {
                this.useerCode = value;
            }
        }

        private string departmentName = string.Empty;
        /// <summary>
        /// 部门名称
        /// </summary>
        public string DepartmentName
        {
            get
            {
                return this.departmentName;
            }
            set
            {
                this.departmentName = value;
            }
        }

        private string officeLocation = string.Empty;
        /// <summary>
        /// 办公地点
        /// </summary>
        public string OfficeLocation
        {
            get
            {
                return this.officeLocation;
            }
            set
            {
                this.officeLocation = value;
            }
        }

        private string telephone = string.Empty;
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Telephone
        {
            get
            {
                return this.telephone;
            }
            set
            {
                this.telephone = value;
            }
        }

        private string processorId = string.Empty;
        /// <summary>
        /// 受理人主键
        /// </summary>
        public string ProcessorId
        {
            get
            {
                return this.processorId;
            }
            set
            {
                this.processorId = value;
            }
        }

        private string processorName = string.Empty;
        /// <summary>
        /// 受理人姓名
        /// </summary>
        public string ProcessorName
        {
            get
            {
                return this.processorName;
            }
            set
            {
                this.processorName = value;
            }
        }

        private string serviceState = string.Empty;
        /// <summary>
        /// 服务状态
        /// </summary>
        public string ServiceState
        {
            get
            {
                return this.serviceState;
            }
            set
            {
                this.serviceState = value;
            }
        }

        private DateTime? reportingTime = null;
        /// <summary>
        /// 申报时间
        /// </summary>
        public DateTime? ReportingTime
        {
            get
            {
                return this.reportingTime;
            }
            set
            {
                this.reportingTime = value;
            }
        }

        private DateTime? completionTime = null;
        /// <summary>
        /// 完成时间
        /// </summary>
        public DateTime? CompletionTime
        {
            get
            {
                return this.completionTime;
            }
            set
            {
                this.completionTime = value;
            }
        }

        private string maintenancePersonnel = string.Empty;
        /// <summary>
        /// 负责人(维修人员)
        /// </summary>
        public string MaintenancePersonnel
        {
            get
            {
                return this.maintenancePersonnel;
            }
            set
            {
                this.maintenancePersonnel = value;
            }
        }

        private string malfunctionCause = string.Empty;
        /// <summary>
        /// 故障原因
        /// </summary>
        public string MalfunctionCause
        {
            get
            {
                return this.malfunctionCause;
            }
            set
            {
                this.malfunctionCause = value;
            }
        }

        private string bugLevel = string.Empty;
        /// <summary>
        /// 故障等级
        /// </summary>
        public string BugLevel
        {
            get
            {
                return this.bugLevel;
            }
            set
            {
                this.bugLevel = value;
            }
        }

        private string bugCategory = string.Empty;
        /// <summary>
        /// 故障类别
        /// </summary>
        public string BugCategory
        {
            get
            {
                return this.bugCategory;
            }
            set
            {
                this.bugCategory = value;
            }
        }

        private int? processTime = null;
        /// <summary>
        /// 处理耗时（分钟）
        /// </summary>
        public int? ProcessTime
        {
            get
            {
                return this.processTime;
            }
            set
            {
                this.processTime = value;
            }
        }

        private string ip = null;
        /// <summary>
        /// IP
        /// </summary>
        public string IP
        {
            get
            {
                return this.ip;
            }
            set
            {
                this.ip = value;
            }
        }

        private string computerUserName = string.Empty;
        /// <summary>
        /// 电脑用户名
        /// </summary>
        public string ComputerUserName
        {
            get
            {
                return this.computerUserName;
            }
            set
            {
                this.computerUserName = value;
            }
        }

        private string computerPassword = string.Empty;
        /// <summary>
        /// 密码
        /// </summary>
        public string ComputerPassword
        {
            get
            {
                return this.computerPassword;
            }
            set
            {
                this.computerPassword = value;
            }
        }

        private int? sortCode = null;
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private int? enabled = 1;
        /// <summary>
        /// 有效标志
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private string description = string.Empty;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private string createUserId = string.Empty;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private string createBy = string.Empty;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        private string modifiedUserId = string.Empty;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        private string modifiedBy = string.Empty;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public MaintainEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public MaintainEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public MaintainEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public MaintainEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public MaintainEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public MaintainEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldCode]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldDepartmentId]);
            this.UserCode = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldUserCode]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldDepartmentName]);
            this.OfficeLocation = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldOfficeLocation]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldTelephone]);
            this.ServiceState = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldServiceState]);
            this.ReportingTime = BaseBusinessLogic.ConvertToDateTime(dataRow[MaintainEntity.FieldReportingTime]);
            this.CompletionTime = BaseBusinessLogic.ConvertToDateTime(dataRow[MaintainEntity.FieldCompletionTime]);
            this.MaintenancePersonnel = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldMaintenancePersonnel]);
            this.MalfunctionCause = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldMalfunctionCause]);
            this.BugLevel = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldBugLevel]);
            this.BugCategory = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldBugCategory]);
            this.ProcessTime = BaseBusinessLogic.ConvertToInt(dataRow[MaintainEntity.FieldProcessTime]);
            this.IP = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldIP]);
            this.ComputerUserName = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldComputerUserName]);
            this.ComputerPassword = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldComputerPassword]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[MaintainEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[MaintainEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[MaintainEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[MaintainEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[MaintainEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[MaintainEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public MaintainEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldId]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldCode]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldDepartmentId]);
            this.UserCode = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldUserCode]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldDepartmentName]);
            this.OfficeLocation = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldOfficeLocation]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldTelephone]);
            this.ServiceState = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldServiceState]);
            this.ReportingTime = BaseBusinessLogic.ConvertToDateTime(dataReader[MaintainEntity.FieldReportingTime]);
            this.CompletionTime = BaseBusinessLogic.ConvertToDateTime(dataReader[MaintainEntity.FieldCompletionTime]);
            this.MaintenancePersonnel = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldMaintenancePersonnel]);
            this.MalfunctionCause = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldMalfunctionCause]);
            this.BugLevel = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldBugLevel]);
            this.BugCategory = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldBugCategory]);
            this.ProcessTime = BaseBusinessLogic.ConvertToInt(dataReader[MaintainEntity.FieldProcessTime]);
            this.ComputerUserName = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldComputerUserName]);
            this.ComputerPassword = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldComputerPassword]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[MaintainEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[MaintainEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[MaintainEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[MaintainEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[MaintainEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[MaintainEntity.FieldModifiedBy]);
            return this;
        }
    }
}