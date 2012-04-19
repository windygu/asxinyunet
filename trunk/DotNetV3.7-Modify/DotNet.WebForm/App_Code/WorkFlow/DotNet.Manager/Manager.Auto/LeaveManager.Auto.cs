//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// LeaveManager
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
    public partial class LeaveManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public LeaveManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = LeaveEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public LeaveManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public LeaveManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public LeaveManager(BaseUserInfo userInfo) : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public LeaveManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public LeaveManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName) : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="leaveEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(LeaveEntity leaveEntity)
        {
            return this.AddEntity(leaveEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="leaveEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(LeaveEntity leaveEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(leaveEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="leaveEntity">实体</param>
        public int Update(LeaveEntity leaveEntity)
        {
            return this.UpdateEntity(leaveEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public LeaveEntity GetEntity(string id)
        {
            LeaveEntity leaveEntity = new LeaveEntity(this.GetDataTable(new KeyValuePair<string, object>(LeaveEntity.FieldId, id)));
            return leaveEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="leaveEntity">实体</param>
        public string AddEntity(LeaveEntity leaveEntity)
        {
            string sequence = string.Empty;
            this.Identity = false; 
            if (leaveEntity.SortCode == null || leaveEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                leaveEntity.SortCode = int.Parse(sequence);
            }
            if (leaveEntity.Id != null)
            {
                sequence = leaveEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, LeaveEntity.FieldId);
            if (!this.Identity) 
            {
                if (string.IsNullOrEmpty(leaveEntity.Id)) 
                { 
                    sequence = BaseBusinessLogic.NewGuid(); 
                    leaveEntity.Id = sequence ;
                }
                sqlBuilder.SetValue(LeaveEntity.FieldId, leaveEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(LeaveEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(LeaveEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(leaveEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            leaveEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(LeaveEntity.FieldId, leaveEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, leaveEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(LeaveEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(LeaveEntity.FieldCreateBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(LeaveEntity.FieldCreateOn);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(LeaveEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(LeaveEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(LeaveEntity.FieldModifiedOn);
            if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.SqlServer || DbHelper.CurrentDbType == CurrentDbType.Access))
            {
                sequence = sqlBuilder.EndInsert().ToString();
            }
            else
            {
                sqlBuilder.EndInsert();
            }
            return sequence;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="leaveEntity">实体</param>
        public int UpdateEntity(LeaveEntity leaveEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, leaveEntity);
            if (UserInfo != null) 
            { 
                sqlBuilder.SetValue(LeaveEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(LeaveEntity.FieldModifiedBy, UserInfo.RealName);
            } 
            sqlBuilder.SetDBNow(LeaveEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(LeaveEntity.FieldId, leaveEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="leaveEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, LeaveEntity leaveEntity)
        {
            sqlBuilder.SetValue(LeaveEntity.FieldUserId, leaveEntity.UserId);
            sqlBuilder.SetValue(LeaveEntity.FieldUserName, leaveEntity.UserName);
            sqlBuilder.SetValue(LeaveEntity.FieldDepartmentId, leaveEntity.DepartmentId);
            sqlBuilder.SetValue(LeaveEntity.FieldDepartmentName, leaveEntity.DepartmentName);
            sqlBuilder.SetValue(LeaveEntity.FieldCode, leaveEntity.Code);
            sqlBuilder.SetValue(LeaveEntity.FieldTransferOfPeople, leaveEntity.TransferOfPeople);
            sqlBuilder.SetValue(LeaveEntity.FieldTelephone, leaveEntity.Telephone);
            sqlBuilder.SetValue(LeaveEntity.FieldReason, leaveEntity.Reason);
            sqlBuilder.SetValue(LeaveEntity.FieldDay, leaveEntity.Day);
            sqlBuilder.SetValue(LeaveEntity.FieldItemsLeaveCategory, leaveEntity.ItemsLeaveCategory);
            sqlBuilder.SetValue(LeaveEntity.FieldStartTime, leaveEntity.StartTime);
            sqlBuilder.SetValue(LeaveEntity.FieldEndTime, leaveEntity.EndTime);
            sqlBuilder.SetValue(LeaveEntity.FieldTransferInstructions, leaveEntity.TransferInstructions);
            sqlBuilder.SetValue(LeaveEntity.FieldAuditStatus, leaveEntity.AuditStatus);
            sqlBuilder.SetValue(LeaveEntity.FieldSortCode, leaveEntity.SortCode);
            sqlBuilder.SetValue(LeaveEntity.FieldDeletionStateCode, leaveEntity.DeletionStateCode);
            sqlBuilder.SetValue(LeaveEntity.FieldEnabled, leaveEntity.Enabled);
            sqlBuilder.SetValue(LeaveEntity.FieldDescription, leaveEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(LeaveEntity.FieldId, id));
        }
    }
}
