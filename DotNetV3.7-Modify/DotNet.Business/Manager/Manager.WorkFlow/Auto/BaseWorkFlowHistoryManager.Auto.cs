//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowHistoryManager
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
    public partial class BaseWorkFlowHistoryManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowHistoryManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseWorkFlowHistoryTable.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseWorkFlowHistoryManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseWorkFlowHistoryManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowHistoryManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowHistoryManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseWorkFlowHistoryManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            return this.AddEntity(baseWorkFlowHistoryEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseWorkFlowHistoryEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        public int Update(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            return this.UpdateEntity(baseWorkFlowHistoryEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowHistoryEntity GetEntity(int id)
        {
            BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity = new BaseWorkFlowHistoryEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowHistoryTable.FieldId, id)));
            return baseWorkFlowHistoryEntity;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowHistoryEntity GetEntity(int? id)
        {
            return GetEntity((int)id);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        public string AddEntity(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            string sequence = string.Empty;
            if (baseWorkFlowHistoryEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                baseWorkFlowHistoryEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseWorkFlowHistoryTable.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldId, baseWorkFlowHistoryEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowHistoryTable.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseWorkFlowHistoryTable.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (baseWorkFlowHistoryEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            baseWorkFlowHistoryEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldId, baseWorkFlowHistoryEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, baseWorkFlowHistoryEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowHistoryTable.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowHistoryTable.FieldModifiedOn);
            if (DbHelper.CurrentDbType == CurrentDbType.SqlServer && this.Identity)
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
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        public int UpdateEntity(BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseWorkFlowHistoryEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowHistoryTable.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkFlowHistoryTable.FieldId, baseWorkFlowHistoryEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseWorkFlowHistoryEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkFlowHistoryEntity baseWorkFlowHistoryEntity)
        {
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldCurrentFlowId, baseWorkFlowHistoryEntity.CurrentFlowId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldWorkFlowId, baseWorkFlowHistoryEntity.WorkFlowId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldActivityId, baseWorkFlowHistoryEntity.ActivityId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldActivityFullName, baseWorkFlowHistoryEntity.ActivityFullName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldToDepartmentId, baseWorkFlowHistoryEntity.ToDepartmentId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldToDepartmentName, baseWorkFlowHistoryEntity.ToDepartmentName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldToUserId, baseWorkFlowHistoryEntity.ToUserId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldToUserRealName, baseWorkFlowHistoryEntity.ToUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldToRoleId, baseWorkFlowHistoryEntity.ToRoleId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldToRoleRealName, baseWorkFlowHistoryEntity.ToRoleRealName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldAuditUserId, baseWorkFlowHistoryEntity.AuditUserId);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldAuditUserRealName, baseWorkFlowHistoryEntity.AuditUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldSendDate, baseWorkFlowHistoryEntity.SendDate);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldAuditDate, baseWorkFlowHistoryEntity.AuditDate);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldAuditIdea, baseWorkFlowHistoryEntity.AuditIdea);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldAuditStatus, baseWorkFlowHistoryEntity.AuditStatus);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldSortCode, baseWorkFlowHistoryEntity.SortCode);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldEnabled, baseWorkFlowHistoryEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldDeletionStateCode, baseWorkFlowHistoryEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseWorkFlowHistoryTable.FieldDescription, baseWorkFlowHistoryEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseWorkFlowHistoryTable.FieldId, id));
        }        
    }
}
