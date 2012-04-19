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
    /// BaseWorkFlowCurrentManager
    /// 工作流当前状态
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
    public partial class BaseWorkFlowCurrentManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseWorkFlowCurrentManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            base.CurrentTableName = BaseWorkFlowCurrentEntity.TableName;
            base.Identity = false;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseWorkFlowCurrentManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseWorkFlowCurrentManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowCurrentManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseWorkFlowCurrentManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseWorkFlowCurrentManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowCurrentEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowCurrentEntity baseWorkFlowCurrentEntity)
        {
            return this.AddEntity(baseWorkFlowCurrentEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseWorkFlowCurrentEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseWorkFlowCurrentEntity baseWorkFlowCurrentEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseWorkFlowCurrentEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseWorkFlowCurrentEntity">实体</param>
        public int Update(BaseWorkFlowCurrentEntity baseWorkFlowCurrentEntity)
        {
            return this.UpdateEntity(baseWorkFlowCurrentEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowCurrentEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseWorkFlowCurrentEntity GetEntity(string id)
        {
            BaseWorkFlowCurrentEntity baseWorkFlowCurrentEntity = new BaseWorkFlowCurrentEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldId, id)));
            return baseWorkFlowCurrentEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(BaseWorkFlowCurrentEntity entity)
        {
            string sequence = string.Empty;
            if (entity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                entity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseWorkFlowCurrentEntity.FieldId);
            if (string.IsNullOrEmpty(entity.Id))
            {
                entity.Id = Guid.NewGuid().ToString();
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldId, entity.Id);
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowCurrentEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowCurrentEntity.FieldModifiedOn);
            sqlBuilder.EndInsert();
            return entity.Id;
        }

        /// <summary>
        /// 更新实体
        /// </summary>
        /// <param name="baseWorkFlowCurrentEntity">实体</param>
        public int UpdateEntity(BaseWorkFlowCurrentEntity baseWorkFlowCurrentEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseWorkFlowCurrentEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseWorkFlowCurrentEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseWorkFlowCurrentEntity.FieldId, baseWorkFlowCurrentEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseWorkFlowCurrentEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseWorkFlowCurrentEntity baseWorkFlowCurrentEntity)
        {
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldCategoryCode, baseWorkFlowCurrentEntity.CategoryCode);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldCategoryFullName, baseWorkFlowCurrentEntity.CategoryFullName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldObjectId, baseWorkFlowCurrentEntity.ObjectId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldObjectFullName, baseWorkFlowCurrentEntity.ObjectFullName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldWorkFlowId, baseWorkFlowCurrentEntity.WorkFlowId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldActivityId, baseWorkFlowCurrentEntity.ActivityId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldActivityFullName, baseWorkFlowCurrentEntity.ActivityFullName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToDepartmentId, baseWorkFlowCurrentEntity.ToDepartmentId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToDepartmentName, baseWorkFlowCurrentEntity.ToDepartmentName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToUserId, baseWorkFlowCurrentEntity.ToUserId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToUserRealName, baseWorkFlowCurrentEntity.ToUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToRoleId, baseWorkFlowCurrentEntity.ToRoleId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToRoleRealName, baseWorkFlowCurrentEntity.ToRoleRealName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldAuditUserId, baseWorkFlowCurrentEntity.AuditUserId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldAuditUserCode, baseWorkFlowCurrentEntity.AuditUserCode);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, baseWorkFlowCurrentEntity.AuditUserRealName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldSendDate, baseWorkFlowCurrentEntity.SendDate);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldAuditDate, baseWorkFlowCurrentEntity.AuditDate);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldAuditIdea, baseWorkFlowCurrentEntity.AuditIdea);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldAuditStatus, baseWorkFlowCurrentEntity.AuditStatus);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldSortCode, baseWorkFlowCurrentEntity.SortCode);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldEnabled, baseWorkFlowCurrentEntity.Enabled);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, baseWorkFlowCurrentEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldDescription, baseWorkFlowCurrentEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldId, id));
        }        
    }
}
