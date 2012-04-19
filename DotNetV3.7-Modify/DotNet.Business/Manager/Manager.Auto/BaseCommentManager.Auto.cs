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
    /// BaseCommentManager
    /// 评论表
    ///
    /// 修改纪录
    ///
    ///		2010-09-30 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-09-30</date>
    /// </author>
    /// </summary>
    public partial class BaseCommentManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseCommentManager()
        {
            base.CurrentTableName = BaseCommentEntity.TableName;
            base.PrimaryKey = "Id";
            base.Identity = false;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseCommentManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseCommentManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseCommentManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseCommentManager(IDbHelper dbHelper, BaseUserInfo userInfo)
            : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        /// <param name="tableName">指定表名</param>
        public BaseCommentManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseCommentEntity baseCommentEntity)
        {
            return this.AddEntity(baseCommentEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseCommentEntity baseCommentEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(baseCommentEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        public int Update(BaseCommentEntity baseCommentEntity)
        {
            return this.UpdateEntity(baseCommentEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseCommentEntity GetEntity(int id)
        {
            BaseCommentEntity baseCommentEntity = new BaseCommentEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseCommentEntity.FieldId, id)));
            return baseCommentEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="entity">实体</param>
        public string AddEntity(BaseCommentEntity entity)
        {
            string sequence = string.Empty;
            if (entity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                entity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseCommentEntity.FieldId);
            if (!string.IsNullOrEmpty(entity.Id))
            {
                sqlBuilder.SetValue(BaseCommentEntity.FieldId, entity.Id);
            }
            this.SetEntity(sqlBuilder, entity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseCommentEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseCommentEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseCommentEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseCommentEntity.FieldModifiedOn);
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
        /// <param name="baseCommentEntity">实体</param>
        public int UpdateEntity(BaseCommentEntity baseCommentEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, baseCommentEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseCommentEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseCommentEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseCommentEntity.FieldId, baseCommentEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="baseCommentEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseCommentEntity baseCommentEntity)
        {
            sqlBuilder.SetValue(BaseCommentEntity.FieldCategoryCode, baseCommentEntity.CategoryCode);
            sqlBuilder.SetValue(BaseCommentEntity.FieldObjectId, baseCommentEntity.ObjectId);
            sqlBuilder.SetValue(BaseCommentEntity.FieldTitle, baseCommentEntity.Title);
            sqlBuilder.SetValue(BaseCommentEntity.FieldContents, baseCommentEntity.Contents);
            sqlBuilder.SetValue(BaseCommentEntity.FieldTargetURL, baseCommentEntity.TargetURL);
            sqlBuilder.SetValue(BaseCommentEntity.FieldIPAddress, baseCommentEntity.IPAddress);
            sqlBuilder.SetValue(BaseCommentEntity.FieldDeletionStateCode, baseCommentEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseCommentEntity.FieldEnabled, baseCommentEntity.Enabled);
            sqlBuilder.SetValue(BaseCommentEntity.FieldSortCode, baseCommentEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseCommentEntity.FieldId, id));
        }

        /// <summary>
        /// 生成表字段说明
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetTableColumns()
        {
            int returnValue = 0;
            string tableCode = base.CurrentTableName;
            string tableName = "评论表";
            // 先删除重复的数据
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginDelete(BaseTableColumnsEntity.TableName);
            sqlBuilder.SetWhere(BaseTableColumnsEntity.FieldTableCode, BaseCommentEntity.TableName);
            returnValue += sqlBuilder.EndDelete();
            // 插入字段说明数据
            returnValue += SetTableColumns(tableCode, tableName, "Id", "主键");
            returnValue += SetTableColumns(tableCode, tableName, "ParentId", "父亲节点主键");
            returnValue += SetTableColumns(tableCode, tableName, "CategoryId", "分类主键");
            returnValue += SetTableColumns(tableCode, tableName, "ObjectId", "唯一识别主键");
            returnValue += SetTableColumns(tableCode, tableName, "Title", "主题");
            returnValue += SetTableColumns(tableCode, tableName, "Content", "内容");
            returnValue += SetTableColumns(tableCode, tableName, "TargetURL", "消息的指向网页页面");
            returnValue += SetTableColumns(tableCode, tableName, "IPAddress", "IP地址");
            returnValue += SetTableColumns(tableCode, tableName, "DeletionStateCode", "删除标志");
            returnValue += SetTableColumns(tableCode, tableName, "Enabled", "有效");
            returnValue += SetTableColumns(tableCode, tableName, "Description", "描述");
            returnValue += SetTableColumns(tableCode, tableName, "SortCode", "排序码");
            returnValue += SetTableColumns(tableCode, tableName, "CreateOn", "创建日期");
            returnValue += SetTableColumns(tableCode, tableName, "CreateUserId", "创建用户主键");
            returnValue += SetTableColumns(tableCode, tableName, "CreateBy", "创建用户");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedOn", "修改日期");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedUserId", "修改用户主键");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedBy", "修改用户");
            return returnValue;
        }
    }
}