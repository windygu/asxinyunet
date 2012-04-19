//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowHistoryEntity
    /// 工作流审核历史步骤记录
    ///
    /// 修改纪录
    ///
    ///		2010-08-05 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-08-05</date>
    /// </author>
    /// </summary>
    [Serializable]
    public class BaseWorkFlowHistoryEntity
    {
        private int? id = null;
        /// <summary>
        /// 代码
        /// </summary>
        public int? Id
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

        private string currentFlowId = null;
        /// <summary>
        /// 当前工作流主键
        /// </summary>
        public string CurrentFlowId
        {
            get
            {
                return this.currentFlowId;
            }
            set
            {
                this.currentFlowId = value;
            }
        }

        private int? workFlowId = null;
        /// <summary>
        /// 工作流主键
        /// </summary>
        public int? WorkFlowId
        {
            get
            {
                return this.workFlowId;
            }
            set
            {
                this.workFlowId = value;
            }
        }

        private int? activityId = null;
        /// <summary>
        /// 审核步骤主键
        /// </summary>
        public int? ActivityId
        {
            get
            {
                return this.activityId;
            }
            set
            {
                this.activityId = value;
            }
        }

        private string activityFullName = null;
        /// <summary>
        /// 审核步骤名称
        /// </summary>
        public string ActivityFullName
        {
            get
            {
                return this.activityFullName;
            }
            set
            {
                this.activityFullName = value;
            }
        }

        private string departmentId = null;
        /// <summary>
        /// 待审核部门主键
        /// </summary>
        public string ToDepartmentId
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

        private string departmentFullName = null;
        /// <summary>
        /// 待审核部门名称
        /// </summary>
        public string ToDepartmentName
        {
            get
            {
                return this.departmentFullName;
            }
            set
            {
                this.departmentFullName = value;
            }
        }

        private string userId = null;
        /// <summary>
        /// 待审核用户主键
        /// </summary>
        public string ToUserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private string userRealName = null;
        /// <summary>
        /// 待审核用户
        /// </summary>
        public string ToUserRealName
        {
            get
            {
                return this.userRealName;
            }
            set
            {
                this.userRealName = value;
            }
        }

        private string roleId = null;
        /// <summary>
        /// 待审核角色主键
        /// </summary>
        public string ToRoleId
        {
            get
            {
                return this.roleId;
            }
            set
            {
                this.roleId = value;
            }
        }

        private string roleRealName = null;
        /// <summary>
        /// 待审核角色
        /// </summary>
        public string ToRoleRealName
        {
            get
            {
                return this.roleRealName;
            }
            set
            {
                this.roleRealName = value;
            }
        }

        private string auditUserId = null;
        /// <summary>
        /// 审核用户主键
        /// </summary>
        public string AuditUserId
        {
            get
            {
                return this.auditUserId;
            }
            set
            {
                this.auditUserId = value;
            }
        }

        private string auditUserRealName = null;
        /// <summary>
        /// 审核用户
        /// </summary>
        public string AuditUserRealName
        {
            get
            {
                return this.auditUserRealName;
            }
            set
            {
                this.auditUserRealName = value;
            }
        }

        private DateTime? sendDate = null;
        /// <summary>
        /// 发出日期
        /// </summary>
        public DateTime? SendDate
        {
            get
            {
                return this.sendDate;
            }
            set
            {
                this.sendDate = value;
            }
        }

        private DateTime? auditDate = null;
        /// <summary>
        /// 审核日期
        /// </summary>
        public DateTime? AuditDate
        {
            get
            {
                return this.auditDate;
            }
            set
            {
                this.auditDate = value;
            }
        }

        private string auditIdea = null;
        /// <summary>
        /// 审核意见
        /// </summary>
        public string AuditIdea
        {
            get
            {
                return this.auditIdea;
            }
            set
            {
                this.auditIdea = value;
            }
        }

        private string auditState = null;
        /// <summary>
        /// 审核状态码
        /// </summary>
        public string AuditStatus
        {
            get
            {
                return this.auditState;
            }
            set
            {
                this.auditState = value;
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

        private int? enabled = 0;
        /// <summary>
        /// 有效
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

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标志
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

        private string description = null;
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

        private string createUserId = null;
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

        private string createBy = null;
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

        private string modifiedUserId = null;
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

        private string modifiedBy = null;
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
        public BaseWorkFlowHistoryEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowHistoryEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowHistoryEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowHistoryEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseWorkFlowHistoryEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseWorkFlowHistoryEntity> GetList(DataTable dataTable)
        {
            List<BaseWorkFlowHistoryEntity> entites = new List<BaseWorkFlowHistoryEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseWorkFlowHistoryEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryTable.FieldId]);
            this.CurrentFlowId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldCurrentFlowId]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryTable.FieldWorkFlowId]);
            this.ActivityId = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryTable.FieldActivityId]);
            this.ActivityFullName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldActivityFullName]);
            this.ToDepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldToDepartmentId]);
            this.ToDepartmentName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldToDepartmentName]);
            this.ToUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldToUserId]);
            this.ToUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldToUserRealName]);
            this.ToRoleId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldToRoleId]);
            this.ToRoleRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldToRoleRealName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldAuditUserId]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldAuditUserRealName]);
            this.SendDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryTable.FieldSendDate]);
            this.AuditDate = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryTable.FieldAuditDate]);
            this.AuditIdea = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldAuditIdea]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldAuditStatus]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryTable.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryTable.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseWorkFlowHistoryTable.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryTable.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseWorkFlowHistoryTable.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseWorkFlowHistoryTable.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseWorkFlowHistoryEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryTable.FieldId]);
            this.CurrentFlowId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldCurrentFlowId]);
            this.WorkFlowId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryTable.FieldWorkFlowId]);
            this.ActivityId = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryTable.FieldActivityId]);
            this.ActivityFullName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldActivityFullName]);
            this.ToDepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldToDepartmentId]);
            this.ToDepartmentName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldToDepartmentName]);
            this.ToUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldToUserId]);
            this.ToUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldToUserRealName]);
            this.ToRoleId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldToRoleId]);
            this.ToRoleRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldToRoleRealName]);
            this.AuditUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldAuditUserId]);
            this.AuditUserRealName = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldAuditUserRealName]);
            this.SendDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryTable.FieldSendDate]);
            this.AuditDate = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryTable.FieldAuditDate]);
            this.AuditIdea = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldAuditIdea]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldAuditStatus]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryTable.FieldSortCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryTable.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseWorkFlowHistoryTable.FieldDeletionStateCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryTable.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseWorkFlowHistoryTable.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseWorkFlowHistoryTable.FieldModifiedBy]);
            return this;
        }
    }
}
