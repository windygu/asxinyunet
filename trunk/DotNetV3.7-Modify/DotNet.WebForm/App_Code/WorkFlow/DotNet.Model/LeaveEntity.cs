//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// LeaveEntity
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
    [Serializable]
    public partial class LeaveEntity
    {
        /// <summary>
        /// 主键
        /// </summary>
        public String Id { get; set; }

        /// <summary>
        /// 申请人主键
        /// </summary>
        public String UserId { get; set; }

        /// <summary>
        /// 申请人姓名
        /// </summary>
        public String UserName { get; set; }

        /// <summary>
        /// 部门主键
        /// </summary>
        public String DepartmentId { get; set; }

        /// <summary>
        /// 部门名称
        /// </summary>
        public String DepartmentName { get; set; }

        /// <summary>
        /// 单据编号
        /// </summary>
        public String Code { get; set; }

        /// <summary>
        /// 工作交接人
        /// </summary>
        public String TransferOfPeople { get; set; }

        /// <summary>
        /// 联系电话
        /// </summary>
        public String Telephone { get; set; }

        /// <summary>
        /// 请假原因
        /// </summary>
        public String Reason { get; set; }

        /// <summary>
        /// 请假天数
        /// </summary>
        public int? Day { get; set; }

        /// <summary>
        /// 请假类别
        /// </summary>
        public String ItemsLeaveCategory { get; set; }

        /// <summary>
        /// 开始日期
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// 结束日期
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// 工作交接说明
        /// </summary>
        public String TransferInstructions { get; set; }

        /// <summary>
        /// 审核状态
        /// </summary>
        public String AuditStatus { get; set; }

        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode { get; set; }

        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeletionStateCode { get; set; }

        /// <summary>
        /// 有效标志
        /// </summary>
        public int? Enabled { get; set; }

        /// <summary>
        /// 描述
        /// </summary>
        public String Description { get; set; }

        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn { get; set; }

        /// <summary>
        /// 创建用户主键
        /// </summary>
        public String CreateUserId { get; set; }

        /// <summary>
        /// 创建用户
        /// </summary>
        public String CreateBy { get; set; }

        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn { get; set; }

        /// <summary>
        /// 修改用户主键
        /// </summary>
        public String ModifiedUserId { get; set; }

        /// <summary>
        /// 修改用户
        /// </summary>
        public String ModifiedBy { get; set; }

        /// <summary>
        /// 构造函数
        /// </summary>
        public LeaveEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public LeaveEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public LeaveEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public LeaveEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public LeaveEntity GetSingle(DataTable dataTable)
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
        /// 从数据表读取返回实体列表
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public List<LeaveEntity>  GetList(DataTable dataTable)
        {
            List<LeaveEntity> entities=new List<LeaveEntity>();
            foreach(DataRow dataRow in dataTable.Rows)
            {
                entities.Add(GetFrom(dataRow));
            }
            return entities;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public LeaveEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldUserId]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldUserName]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldDepartmentId]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldDepartmentName]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldCode]);
            this.TransferOfPeople = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldTransferOfPeople]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldTelephone]);
            this.Reason = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldReason]);
            this.Day = BaseBusinessLogic.ConvertToInt(dataRow[LeaveEntity.FieldDay]);
            this.ItemsLeaveCategory = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldItemsLeaveCategory]);
            this.StartTime = BaseBusinessLogic.ConvertToDateTime(dataRow[LeaveEntity.FieldStartTime]);
            this.EndTime = BaseBusinessLogic.ConvertToDateTime(dataRow[LeaveEntity.FieldEndTime]);
            this.TransferInstructions = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldTransferInstructions]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldAuditStatus]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[LeaveEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[LeaveEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[LeaveEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[LeaveEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[LeaveEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[LeaveEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public LeaveEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldUserId]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldUserName]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldDepartmentId]);
            this.DepartmentName = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldDepartmentName]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldCode]);
            this.TransferOfPeople = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldTransferOfPeople]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldTelephone]);
            this.Reason = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldReason]);
            this.Day = BaseBusinessLogic.ConvertToInt(dataReader[LeaveEntity.FieldDay]);
            this.ItemsLeaveCategory = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldItemsLeaveCategory]);
            this.StartTime = BaseBusinessLogic.ConvertToDateTime(dataReader[LeaveEntity.FieldStartTime]);
            this.EndTime = BaseBusinessLogic.ConvertToDateTime(dataReader[LeaveEntity.FieldEndTime]);
            this.TransferInstructions = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldTransferInstructions]);
            this.AuditStatus = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldAuditStatus]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[LeaveEntity.FieldSortCode]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[LeaveEntity.FieldDeletionStateCode]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[LeaveEntity.FieldEnabled]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[LeaveEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[LeaveEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[LeaveEntity.FieldModifiedBy]);
            return this;
        }
    }
}
