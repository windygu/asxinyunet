﻿//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    ///	BaseFolderManager
    ///	
    ///	修改记录
    /// 
    ///     2007.06.06 版本：2.5 JiRiGaLa   统一进行主键整理。
    ///     2007.05.29 版本：2.4 JiRiGaLa   ErrorDeleted，ErrorChanged 状态进行改进整理。
    ///	    2007.05.29 版本：2.3 JiRiGaLa   BatchSave，ErrorDataRelated，force 进行改进整理。
    ///	    2007.05.23 版本：2.2 JiRiGaLa   ReturnStatusCode，ReturnStatusMessage 进行改进。
    ///	    2007.05.12 版本：2.1 JiRiGaLa   BatchSave 进行改进。
    ///	    2007.01.04 版本：2.0 JiRiGaLa   重新整理主键。
    ///	    2006.02.12 版本：1.2 JiRiGaLa   调整主键的规范化。
    ///	    2006.02.12 版本：1.2 JiRiGaLa   调整主键的规范化。
    ///	    2004.11.19 版本：1.1 JiRiGaLa   增加员工类别判断部分。
    ///     2004.11.18 版本：1.0 JiRiGaLa   主键进行了绝对的优化，这是个好东西啊，平时要多用，用得要灵活些。
    ///		
    /// 版本：2.5
    /// </summary>
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.06.06</date>
    /// </author> 
    /// </summary>
    public class BaseFolderManager : BaseManager
    {
        public BaseFolderManager()
        {
            base.CurrentTableName = BaseFolderEntity.TableName;
        }

        public BaseFolderManager(IDbHelper dbHelper): this()
        {
            DbHelper = dbHelper;
        }

        public BaseFolderManager(BaseUserInfo userInfo): this()
        {
            UserInfo = userInfo;
        }

        public BaseFolderManager(IDbHelper dbHelper, BaseUserInfo userInfo) : this(dbHelper)
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseFolderEntity GetEntity(string id)
        {
            BaseFolderEntity folderEntity = new BaseFolderEntity(this.GetDataTableById(id));
            return folderEntity;
        }

        #region private void SetEntity(SQLBuilder sqlBuilder, BaseFolderEntity folderEntity) 设置实体
        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="sqlBuilder">SQL生成器</param>
        /// <param name="folderEntity">实体对象</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseFolderEntity folderEntity)
        {
            sqlBuilder.SetValue(BaseFolderEntity.FieldParentId, folderEntity.ParentId);
            sqlBuilder.SetValue(BaseFolderEntity.FieldFolderName, folderEntity.FolderName);
            sqlBuilder.SetValue(BaseFolderEntity.FieldSortCode, folderEntity.SortCode);
            sqlBuilder.SetValue(BaseFolderEntity.FieldDescription, folderEntity.Description);
            sqlBuilder.SetValue(BaseFolderEntity.FieldEnabled, folderEntity.Enabled ? 1 : 0);
        }
        #endregion

        #region public string AddEntity(BaseFolderEntity folderEntity) 添加
        /// <summary>
        /// Add 添加的主键
        /// </summary>
        /// <param name="folderEntity">文件夹对象</param>
        /// <returns>主键</returns>
        public string AddEntity(BaseFolderEntity folderEntity)
        {
            string returnValue = string.Empty;
            BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper);
            string sequence = sequenceManager.GetSequence(BaseFolderEntity.TableName);
            if (String.IsNullOrEmpty(folderEntity.Id))
            {
                folderEntity.Id = BaseBusinessLogic.NewGuid();
            }
            folderEntity.SortCode = sequence;
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginInsert(this.CurrentTableName);
            sqlBuilder.SetValue(BaseFolderEntity.FieldId, folderEntity.Id);
            this.SetEntity(sqlBuilder, folderEntity);
            sqlBuilder.SetValue(BaseFolderEntity.FieldCreateUserId, UserInfo.Id);
            sqlBuilder.SetValue(BaseFolderEntity.FieldCreateBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(BaseFolderEntity.FieldCreateOn);
            sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(BaseFolderEntity.FieldModifiedOn);
            return sqlBuilder.EndInsert() > 0 ? sequence : string.Empty;
        }
        #endregion

        #region public int UpdateEntity(BaseFolderEntity folderEntity) 更新
        /// <summary>
        /// Update 更新的主键
        /// </summary>
        /// <param name="folderEntity">文件夹对象</param>
        /// <returns>影响行数</returns>
        public int UpdateEntity(BaseFolderEntity folderEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, folderEntity);
            sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedUserId, UserInfo.Id);
            sqlBuilder.SetValue(BaseFolderEntity.FieldModifiedBy, UserInfo.RealName);
            sqlBuilder.SetDBNow(BaseFolderEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseFolderEntity.FieldId, folderEntity.Id);
            return sqlBuilder.EndUpdate();
        }
        #endregion

        #region public string Add(BaseFolderEntity folderEntity, out string statusCode) 添加
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="folderEntity">文件夹的基类表结构定义</param>
        /// <param name="statusCode">状态返回码</param>
        /// <returns>主键</returns>
        public string Add(BaseFolderEntity folderEntity, out string statusCode)
        {
            string returnValue = string.Empty;
            // 检查文件夹名是否重复
            if (this.Exists(new KeyValuePair<string, object>(BaseFolderEntity.FieldParentId, folderEntity.ParentId), new KeyValuePair<string, object>(BaseFolderEntity.FieldFolderName, folderEntity.FolderName)))
            {
                // 文件夹名已重复
                statusCode = StatusCode.ErrorNameExist.ToString();
            }
            else
            {
                returnValue = this.AddEntity(folderEntity);
                // 运行成功
                statusCode = StatusCode.OKAdd.ToString();
            }
            return returnValue;
        }
        #endregion

        #region public int Update(BaseFolderEntity folderEntity, out string statusCode) 更新
        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="folderEntity">文件夹的基类表结构定义</param>
        /// <param name="statusCode">状态返回码</param>
        /// <returns>影响行数</returns>
        public int Update(BaseFolderEntity folderEntity, out string statusCode)
        {
            int returnValue = 0;
            //if (DbLogic.IsModifed(DbHelper, BaseFolderEntity.TableName, folderEntity.Id, folderEntity.ModifiedUserId, folderEntity.ModifiedOn))
            //{
            //    // 数据已经被修改
            //    statusCode = StatusCode.ErrorChanged.ToString();
            //}
            //else
            //{
                // 检查文件夹名是否重复
                if (this.Exists(new KeyValuePair<string, object>(BaseFolderEntity.FieldParentId, folderEntity.ParentId), new KeyValuePair<string, object>(BaseFolderEntity.FieldFolderName, folderEntity.FolderName), folderEntity.Id))
                {
                    // 文件夹名已重复
                    statusCode = StatusCode.ErrorNameExist.ToString();
                }
                else
                {
                    returnValue = this.UpdateEntity(folderEntity);
                    if (returnValue == 1)
                    {
                        // 运行成功
                        statusCode = StatusCode.OKUpdate.ToString();
                    }
                    else
                    {
                        statusCode = StatusCode.ErrorDeleted.ToString();
                    }
                }
            //}
            return returnValue;
        }
        #endregion

        #region public DataTable Search(string searchValue) 查询
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        public DataTable Search(string searchValue)
        {
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT * "
                     + " FROM " + BaseFolderEntity.TableName
                     + " WHERE " + BaseFolderEntity.FieldFolderName + " LIKE " + DbHelper.GetParameter(BaseFolderEntity.FieldFolderName)
                     + " OR " + BaseFolderEntity.FieldDescription + " LIKE " + DbHelper.GetParameter(BaseFolderEntity.FieldDescription);
            DataTable dataTable = new DataTable(BaseFolderEntity.TableName);
            searchValue = searchValue.Trim();
            if (searchValue.IndexOf("%") < 0)
            {
                searchValue = "%" + searchValue + "%";
            }
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            dbParameters.Add(DbHelper.MakeParameter(BaseFolderEntity.FieldFolderName, searchValue));
            dbParameters.Add(DbHelper.MakeParameter(BaseFolderEntity.FieldDescription, searchValue));
            DbHelper.Fill(dataTable, sqlQuery, dbParameters.ToArray());
            return dataTable;
        }
        #endregion

        #region public int MoveTo(string id, string parentId) 移动
        /// <summary>
        /// 移动
        /// </summary>
        /// <param name="id">主键</param>
        /// <param name="parentId">父级主键</param>
        /// <returns>影响行数</returns>
        public int MoveTo(string id, string parentId)
        {
            return this.SetProperty(id, new KeyValuePair<string, object>(BaseOrganizeEntity.FieldParentId, parentId));
        }
        #endregion

        #region public override int BatchSave(DataTable dataTable) 批量进行保存
        /// <summary>
        /// 批量进行保存
        /// </summary>
        /// <param name="dataTable">数据表</param>
        /// <returns>影响行数</returns>
        public override int BatchSave(DataTable dataTable)
        {
            int returnValue = 0;
            BaseFolderEntity folderEntity = new BaseFolderEntity();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                // 删除状态
                if (dataRow.RowState == DataRowState.Deleted)
                {
                    string id = dataRow[BaseFolderEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        returnValue += this.DeleteEntity(id);
                    }
                }
                // 被修改过
                if (dataRow.RowState == DataRowState.Modified)
                {
                    string id = dataRow[BaseFolderEntity.FieldId, DataRowVersion.Original].ToString();
                    if (id.Length > 0)
                    {
                        folderEntity.GetFrom(dataRow);
                        returnValue += this.UpdateEntity(folderEntity);
                    }
                }
                // 添加状态
                if (dataRow.RowState == DataRowState.Added)
                {
                    folderEntity.GetFrom(dataRow);
                    returnValue += this.AddEntity(folderEntity).Length > 0 ? 1 : 0;
                }
                if (dataRow.RowState == DataRowState.Unchanged)
                {
                    continue;
                }
                if (dataRow.RowState == DataRowState.Detached)
                {
                    continue;
                }
            }
            return returnValue;
        }
        #endregion
    }
}