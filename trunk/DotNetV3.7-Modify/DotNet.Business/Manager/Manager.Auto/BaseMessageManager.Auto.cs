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
    /// BaseMessageManager
    /// 消息表
    ///
    /// 修改纪录
    ///
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    public partial class BaseMessageManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseMessageManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseMessageEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseMessageManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseMessageManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseMessageManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseMessageManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseMessageManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseMessageEntity messageEntity)
        {
            return this.AddEntity(messageEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="messageEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseMessageEntity messageEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(messageEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="messageEntity">实体</param>
        public int Update(BaseMessageEntity messageEntity)
        {
            return this.UpdateEntity(messageEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseMessageEntity GetEntity(string id)
        {
            BaseMessageEntity messageEntity = new BaseMessageEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseMessageEntity.FieldId, id)));
            return messageEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="messageEntity">实体</param>
        public string AddEntity(BaseMessageEntity messageEntity)
        {
            if (messageEntity.Id is string)
            {
                this.Identity = false;
            }
            string sequence = string.Empty;
            sequence = messageEntity.Id;
            if (messageEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                messageEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseMessageEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseMessageEntity.FieldId, messageEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseMessageEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseMessageEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(messageEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            messageEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseMessageEntity.FieldId, messageEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, messageEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseMessageEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseMessageEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseMessageEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseMessageEntity.FieldModifiedOn);
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
        /// <param name="messageEntity">实体</param>
        public int UpdateEntity(BaseMessageEntity messageEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, messageEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseMessageEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseMessageEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseMessageEntity.FieldId, messageEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="messageEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseMessageEntity messageEntity)
        {
            sqlBuilder.SetValue(BaseMessageEntity.FieldParentId, messageEntity.ParentId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldFunctionCode, messageEntity.FunctionCode);
            sqlBuilder.SetValue(BaseMessageEntity.FieldCategoryCode, messageEntity.CategoryCode);
            sqlBuilder.SetValue(BaseMessageEntity.FieldObjectId, messageEntity.ObjectId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldTitle, messageEntity.Title);
            sqlBuilder.SetValue(BaseMessageEntity.FieldContents, messageEntity.Contents);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReceiverId, messageEntity.ReceiverId);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReceiverRealName, messageEntity.ReceiverRealName);
            sqlBuilder.SetValue(BaseMessageEntity.FieldIsNew, messageEntity.IsNew);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReadCount, messageEntity.ReadCount);
            sqlBuilder.SetValue(BaseMessageEntity.FieldReadDate, messageEntity.ReadDate);
            sqlBuilder.SetValue(BaseMessageEntity.FieldTargetURL, messageEntity.TargetURL);
            sqlBuilder.SetValue(BaseMessageEntity.FieldIPAddress, messageEntity.IPAddress);
            sqlBuilder.SetValue(BaseMessageEntity.FieldDeletionStateCode, messageEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseMessageEntity.FieldEnabled, messageEntity.Enabled);
            sqlBuilder.SetValue(BaseMessageEntity.FieldDescription, messageEntity.Description);
            sqlBuilder.SetValue(BaseMessageEntity.FieldSortCode, messageEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseMessageEntity.FieldId, id));
        }        
    }
}