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
    /// BaseFileManager
    /// 文件新闻表
    ///
    /// 修改纪录
    ///
    ///		2010-07-28 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-28</date>
    /// </author>
    /// </summary>
    public partial class BaseFileManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseFileManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseFileEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseFileManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseFileManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseFileManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseFileManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseFileManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fileEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseFileEntity fileEntity)
        {
            return this.AddEntity(fileEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="fileEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseFileEntity fileEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(fileEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="BaseFileEntity">实体</param>
        public int Update(BaseFileEntity fileEntity)
        {
            return this.UpdateEntity(fileEntity);
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="fileEntity">实体</param>
        public string AddEntity(BaseFileEntity fileEntity)
        {
            string sequence = string.Empty;
            sequence = fileEntity.Id;
            if (fileEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                fileEntity.SortCode = int.Parse(sequence);
            }
            if (fileEntity.Id is string)
            {
                this.Identity = false;
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseFileEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldId, fileEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(BaseFileEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        if (string.IsNullOrEmpty(fileEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            fileEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseFileEntity.FieldId, fileEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, fileEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFileEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseFileEntity.FieldCreateOn);
            // 这里主要是为了列表里的数据库更好看
            sqlBuilder.SetValue(BaseFileEntity.FieldModifiedUserId, fileEntity.ModifiedUserId);
            sqlBuilder.SetValue(BaseFileEntity.FieldModifiedBy, fileEntity.ModifiedBy);
            sqlBuilder.SetValue(BaseFileEntity.FieldModifiedOn, fileEntity.ModifiedOn);
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
        /// <param name="fileEntity">实体</param>
        public int UpdateEntity(BaseFileEntity fileEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, fileEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseFileEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseFileEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseFileEntity.FieldId, fileEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="BaseFileEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseFileEntity fileEntity)
        {
            sqlBuilder.SetValue(BaseFileEntity.FieldFolderId, fileEntity.FolderId);
            sqlBuilder.SetValue(BaseFileEntity.FieldCategoryCode, fileEntity.CategoryCode);
            sqlBuilder.SetValue(BaseFileEntity.FieldCode, fileEntity.Code);
            sqlBuilder.SetValue(BaseFileEntity.FieldFileName, fileEntity.FileName);
            sqlBuilder.SetValue(BaseFileEntity.FieldFilePath, fileEntity.FilePath);
            sqlBuilder.SetValue(BaseFileEntity.FieldIntroduction, fileEntity.Introduction);
            sqlBuilder.SetValue(BaseFileEntity.FieldContents, fileEntity.Contents);
            sqlBuilder.SetValue(BaseFileEntity.FieldSource, fileEntity.Source);
            sqlBuilder.SetValue(BaseFileEntity.FieldKeywords, fileEntity.Keywords);
            if (fileEntity.Contents != null)
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldFileSize, fileEntity.Contents.Length);
            }
            else
            {
                sqlBuilder.SetValue(BaseFileEntity.FieldFileSize, fileEntity.FileSize);
            }
            sqlBuilder.SetValue(BaseFileEntity.FieldImageUrl, fileEntity.ImageUrl);
            sqlBuilder.SetValue(BaseFileEntity.FieldHomePage, fileEntity.HomePage);
            sqlBuilder.SetValue(BaseFileEntity.FieldSubPage, fileEntity.SubPage);
            sqlBuilder.SetValue(BaseFileEntity.FieldAuditStatus, fileEntity.AuditStatus);
            sqlBuilder.SetValue(BaseFileEntity.FieldReadCount, fileEntity.ReadCount);
            sqlBuilder.SetValue(BaseFileEntity.FieldDeletionStateCode, fileEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseFileEntity.FieldDescription, fileEntity.Description);
            sqlBuilder.SetValue(BaseFileEntity.FieldEnabled, fileEntity.Enabled);
            sqlBuilder.SetValue(BaseFileEntity.FieldSortCode, fileEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseFileEntity.FieldId, id));
        }

        /// <summary>
        /// 生成表字段说明
        /// </summary>
        /// <returns>影响行数</returns>
        public int SetTableColumns()
        {
            int returnValue = 0;
            string tableCode = base.CurrentTableName;
            string tableName = "新闻表";
            // 先删除重复的数据
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginDelete(BaseTableColumnsEntity.TableName);
            sqlBuilder.SetWhere(BaseTableColumnsEntity.FieldTableCode, BaseFileEntity.TableName);
            returnValue += sqlBuilder.EndDelete();
            // 插入字段说明数据
            returnValue += SetTableColumns(tableCode, tableName, "Id", "代码");
            returnValue += SetTableColumns(tableCode, tableName, "FolderId", "文件夹节点代码");
            returnValue += SetTableColumns(tableCode, tableName, "CategoryCode", "文件类别码");
            returnValue += SetTableColumns(tableCode, tableName, "Title", "文件名");
            returnValue += SetTableColumns(tableCode, tableName, "FilePath", "文件路径");
            returnValue += SetTableColumns(tableCode, tableName, "Introduction", "内容简介");
            returnValue += SetTableColumns(tableCode, tableName, "Contents", "文件内容");
            returnValue += SetTableColumns(tableCode, tableName, "Source", "新闻来源");
            returnValue += SetTableColumns(tableCode, tableName, "Keywords", "关键字");
            returnValue += SetTableColumns(tableCode, tableName, "FileSize", "文件大小");
            returnValue += SetTableColumns(tableCode, tableName, "ImageUrl", "图片文件位置(图片新闻)");
            returnValue += SetTableColumns(tableCode, tableName, "HomePage", "置首页");
            returnValue += SetTableColumns(tableCode, tableName, "AuditStatus", "审核状态");
            returnValue += SetTableColumns(tableCode, tableName, "ReadCount", "被阅读次数");
            returnValue += SetTableColumns(tableCode, tableName, "DeletionStateCode", "删除标志");
            returnValue += SetTableColumns(tableCode, tableName, "Description", "描述");
            returnValue += SetTableColumns(tableCode, tableName, "Enabled", "有效");
            returnValue += SetTableColumns(tableCode, tableName, "SortCode", "排序码");
            returnValue += SetTableColumns(tableCode, tableName, "CreateOn", "创建日期");
            returnValue += SetTableColumns(tableCode, tableName, "CreateBy", "创建用户");
            returnValue += SetTableColumns(tableCode, tableName, "CreateUserId", "创建用户主键");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedOn", "修改日期");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedBy", "修改用户");
            returnValue += SetTableColumns(tableCode, tableName, "ModifiedUserId", "修改用户主键");
            return returnValue;
        }
    }
}
