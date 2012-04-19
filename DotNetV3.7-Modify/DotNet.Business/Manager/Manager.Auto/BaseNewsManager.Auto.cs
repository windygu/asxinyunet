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
    /// BaseNewsManager
    /// 新闻表
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
    public partial class BaseNewsManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseNewsManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseNewsEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseNewsManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseNewsManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">操作员信息</param>
        public BaseNewsManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">操作员信息</param>
        public BaseNewsManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseNewsManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="newsEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseNewsEntity newsEntity)
        {
            return this.AddEntity(newsEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="newsEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseNewsEntity newsEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(newsEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="newsEntity">实体</param>
        public int Update(BaseNewsEntity newsEntity)
        {
            return this.UpdateEntity(newsEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseNewsEntity GetEntity(string id)
        {
            BaseNewsEntity newsEntity = new BaseNewsEntity(this.GetDataTable(new KeyValuePair<string, object>(BaseNewsEntity.FieldId, id)));
            return newsEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="newsEntity">实体</param>
        public string AddEntity(BaseNewsEntity newsEntity)
        {
            string sequence = string.Empty;
            sequence = newsEntity.Id;
            if (newsEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                newsEntity.SortCode = int.Parse(sequence);
            }
            if (newsEntity.Id is string)
            {
                this.Identity = false;
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseNewsEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseNewsEntity.FieldId, newsEntity.Id);
            }
            else
            {
                if (!this.ReturnId && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                {
                    sqlBuilder.SetFormula(BaseNewsEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                }
                else
                {
                    if (this.Identity && DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        if (string.IsNullOrEmpty(newsEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            newsEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(BaseNewsEntity.FieldId, newsEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, newsEntity);
            if (UserInfo != null)
            {
                newsEntity.CreateUserId = UserInfo.Id;
                newsEntity.CreateBy = UserInfo.RealName;
                sqlBuilder.SetValue(BaseNewsEntity.FieldCreateUserId, newsEntity.CreateUserId);
                sqlBuilder.SetValue(BaseNewsEntity.FieldCreateBy, newsEntity.CreateBy);
            }
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldCreateOn);
            /*
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldModifiedOn);
             */
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
        /// <param name="newsEntity">实体</param>
        public int UpdateEntity(BaseNewsEntity newsEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, newsEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseNewsEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseNewsEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseNewsEntity.FieldId, newsEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="newsEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseNewsEntity newsEntity)
        {
            if (newsEntity.Contents == null)
            {
                newsEntity.FileSize = 0;
            }
            else
            {
                newsEntity.FileSize = newsEntity.Contents.Length;
            }
            sqlBuilder.SetValue(BaseNewsEntity.FieldFolderId, newsEntity.FolderId);
            sqlBuilder.SetValue(BaseNewsEntity.FieldCategoryCode, newsEntity.CategoryCode);
            sqlBuilder.SetValue(BaseNewsEntity.FieldCode, newsEntity.Code);
            sqlBuilder.SetValue(BaseNewsEntity.FieldTitle, newsEntity.Title);
            sqlBuilder.SetValue(BaseNewsEntity.FieldFilePath, newsEntity.FilePath);
            sqlBuilder.SetValue(BaseNewsEntity.FieldIntroduction, newsEntity.Introduction);
            sqlBuilder.SetValue(BaseNewsEntity.FieldContents, newsEntity.Contents);
            sqlBuilder.SetValue(BaseNewsEntity.FieldSource, newsEntity.Source);
            sqlBuilder.SetValue(BaseNewsEntity.FieldKeywords, newsEntity.Keywords);
            sqlBuilder.SetValue(BaseNewsEntity.FieldFileSize, newsEntity.FileSize);
            sqlBuilder.SetValue(BaseNewsEntity.FieldImageUrl, newsEntity.ImageUrl);
            sqlBuilder.SetValue(BaseNewsEntity.FieldHomePage, newsEntity.HomePage);
            sqlBuilder.SetValue(BaseNewsEntity.FieldSubPage, newsEntity.SubPage);
            sqlBuilder.SetValue(BaseNewsEntity.FieldAuditStatus, newsEntity.AuditStatus);
            sqlBuilder.SetValue(BaseNewsEntity.FieldReadCount, newsEntity.ReadCount);
            sqlBuilder.SetValue(BaseNewsEntity.FieldDeletionStateCode, newsEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseNewsEntity.FieldDescription, newsEntity.Description);
            sqlBuilder.SetValue(BaseNewsEntity.FieldEnabled, newsEntity.Enabled);
            sqlBuilder.SetValue(BaseNewsEntity.FieldSortCode, newsEntity.SortCode);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseNewsEntity.FieldId, id));
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
            sqlBuilder.SetWhere(BaseTableColumnsEntity.FieldTableCode, BaseNewsEntity.TableName);
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
