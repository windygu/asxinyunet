//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseModuleManager
    /// 模块（菜单）表
    ///
    /// 修改纪录
    ///
    ///		2011-10-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011-10-15</date>
    /// </author>
    /// </summary>
    public partial class BaseModuleManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseModuleManager()
        {
            base.CurrentTableName = BaseModuleEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseModuleManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseModuleManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseModuleManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseModuleManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseModuleManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseModuleEntity moduleEntity)
        {
            return this.AddEntity(moduleEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseModuleEntity moduleEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(moduleEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        public int Update(BaseModuleEntity moduleEntity)
        {
            return this.UpdateEntity(moduleEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseModuleEntity GetEntity(string id)
        {
            BaseModuleEntity moduleEntity = new BaseModuleEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, id)));
            return moduleEntity;
        }

        public BaseModuleEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        public string AddEntity(BaseModuleEntity moduleEntity)
        {
            string sequence = string.Empty;
            if (moduleEntity.SortCode == null || moduleEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                moduleEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseModuleEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseModuleEntity.FieldId, moduleEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseModuleEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseModuleEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (moduleEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            moduleEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseModuleEntity.FieldId, moduleEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, moduleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseModuleEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseModuleEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseModuleEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseModuleEntity.FieldModifiedOn);
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
        /// <param name="moduleEntity">实体</param>
        public int UpdateEntity(BaseModuleEntity moduleEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, moduleEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseModuleEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseModuleEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseModuleEntity.FieldId, moduleEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="moduleEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseModuleEntity moduleEntity)
        {
            sqlBuilder.SetValue(BaseModuleEntity.FieldParentId, moduleEntity.ParentId);
            sqlBuilder.SetValue(BaseModuleEntity.FieldCode, moduleEntity.Code);
            sqlBuilder.SetValue(BaseModuleEntity.FieldFullName, moduleEntity.FullName);
            sqlBuilder.SetValue(BaseModuleEntity.FieldCategory, moduleEntity.Category);
            sqlBuilder.SetValue(BaseModuleEntity.FieldImageIndex, moduleEntity.ImageIndex);
            sqlBuilder.SetValue(BaseModuleEntity.FieldSelectedImageIndex, moduleEntity.SelectedImageIndex);
            sqlBuilder.SetValue(BaseModuleEntity.FieldNavigateUrl, moduleEntity.NavigateUrl);
            sqlBuilder.SetValue(BaseModuleEntity.FieldTarget, moduleEntity.Target);
            sqlBuilder.SetValue(BaseModuleEntity.FieldIsPublic, moduleEntity.IsPublic);
            sqlBuilder.SetValue(BaseModuleEntity.FieldIsMenu, moduleEntity.IsMenu);
            sqlBuilder.SetValue(BaseModuleEntity.FieldExpand, moduleEntity.Expand);
            sqlBuilder.SetValue(BaseModuleEntity.FieldPermissionItemCode, moduleEntity.PermissionItemCode);
            sqlBuilder.SetValue(BaseModuleEntity.FieldPermissionScopeTables, moduleEntity.PermissionScopeTables);
            sqlBuilder.SetValue(BaseModuleEntity.FieldAllowEdit, moduleEntity.AllowEdit);
            sqlBuilder.SetValue(BaseModuleEntity.FieldAllowDelete, moduleEntity.AllowDelete);
            sqlBuilder.SetValue(BaseModuleEntity.FieldSortCode, moduleEntity.SortCode);
            sqlBuilder.SetValue(BaseModuleEntity.FieldDeletionStateCode, moduleEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseModuleEntity.FieldEnabled, moduleEntity.Enabled);
            sqlBuilder.SetValue(BaseModuleEntity.FieldDescription, moduleEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseModuleEntity.FieldId, id));
        }
    }
}