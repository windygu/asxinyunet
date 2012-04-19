//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Diagnostics;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseSequenceManager
    /// 序列产生器表
    ///
    /// 修改纪录
    ///
    ///		2011-03-31 版本：1.0 ZhaoJingJing 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>ZhaoJingJing</name>
    ///		<date>2011-03-31</date>
    /// </author>
    /// </summary>
    public partial class BaseSequenceManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseSequenceManager()
        {
            base.CurrentTableName = BaseSequenceEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseSequenceManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseSequenceManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseSequenceManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseSequenceManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseSequenceManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseSequenceEntity sequenceEntity)
        {
            return this.AddEntity(sequenceEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <returns>主键</returns>
        public string Add(BaseSequenceEntity sequenceEntity, bool identity)
        {
            this.Identity = identity;
            return this.AddEntity(sequenceEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        public int Update(BaseSequenceEntity sequenceEntity)
        {
            return this.UpdateEntity(sequenceEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseSequenceEntity GetEntity(string id)
        {
            BaseSequenceEntity sequenceEntity = new BaseSequenceEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseSequenceEntity.FieldId, id)));
            return sequenceEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        public string AddEntity(BaseSequenceEntity sequenceEntity)
        {
            string sequence = string.Empty;
            if (sequenceEntity.Id != null)
            {
                sequence = sequenceEntity.Id.ToString();
            }
            this.Identity = false;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseSequenceEntity.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(sequenceEntity.Id))
                {
                    sequence = BaseBusinessLogic.NewGuid();
                    sequenceEntity.Id = sequence;
                }
                sqlBuilder.SetValue(BaseSequenceEntity.FieldId, sequenceEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseSequenceEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseSequenceEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(sequenceEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            sequenceEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseSequenceEntity.FieldId, sequenceEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, sequenceEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseSequenceEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseSequenceEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseSequenceEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseSequenceEntity.FieldModifiedOn);
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
        /// <param name="sequenceEntity">实体</param>
        public int UpdateEntity(BaseSequenceEntity sequenceEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, sequenceEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseSequenceEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseSequenceEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseSequenceEntity.FieldId, sequenceEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sequenceEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseSequenceEntity sequenceEntity)
        {
            sqlBuilder.SetValue(BaseSequenceEntity.FieldFullName, sequenceEntity.FullName);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldPrefix, sequenceEntity.Prefix);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldSeparator, sequenceEntity.Separator);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldSequence, sequenceEntity.Sequence);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldReduction, sequenceEntity.Reduction);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldStep, sequenceEntity.Step);
            sqlBuilder.SetValue(BaseSequenceEntity.FieldDescription, sequenceEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseSequenceEntity.FieldId, id));
        }
    }
}