//-----------------------------------------------------------------
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
    ///	UserBillManager
    /// 用户审批单据
    /// 工作流_用户单据表名
    /// 
    /// 修改纪录
    /// 
    ///		2011.09.06 版本：1.0 JiRiGaLa	创建。
    /// 
    /// 版本：1.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.09.06</date>
    /// </author> 
    /// </summary>
    public partial class UserBillManager : BaseNewsManager
    {
        public UserBillManager()
        {
            base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            this.CurrentTableName = "WorkFlowUserBill";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public UserBillManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public UserBillManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public UserBillManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public UserBillManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public UserBillManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 检索数据
        /// </summary>
        /// <param name="userId">用户Id</param>
        /// <param name="categoryCode">单据类别</param>
        /// <param name="searchValue">关键字</param>
        /// <param name="enabled">是否有效</param>
        /// <param name="deletionStateCode">是否删除</param>
        /// <returns></returns>
        public DataTable SearchBill(string userId, string categoryId, string categorybillFullName, string searchValue, bool? enabled, bool? deletionStateCode)
        {
            int delete = 0;
            if (deletionStateCode != null)
            {
                delete = (bool)deletionStateCode ? 1 : 0;
            }
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT " + BaseNewsEntity.FieldId
                    + "        ," + BaseNewsEntity.FieldFolderId
                    + "        ," + BaseNewsEntity.FieldCategoryCode
                    + "        ," + BaseNewsEntity.FieldTitle
                    + "        ," + BaseNewsEntity.FieldCode
                    + "        ," + BaseNewsEntity.FieldKeywords
                    + "        ," + BaseNewsEntity.FieldIntroduction
                    + "        ," + BaseNewsEntity.FieldAuditStatus
                    + "        ," + BaseNewsEntity.FieldModifiedUserId
                    + "        ," + BaseNewsEntity.FieldModifiedBy
                    + "        ," + BaseNewsEntity.FieldModifiedOn
                    + "        ," + BaseNewsEntity.FieldCreateOn
                    + "        ," + BaseNewsEntity.FieldSortCode
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + BaseNewsEntity.FieldDeletionStateCode + " = " + delete;
            if (enabled != null)
            {
                int isEnabled = (bool)enabled ? 1 : 0;
                sqlQuery += " AND " + BaseNewsEntity.FieldEnabled + " = " + isEnabled;
            }
            if (!String.IsNullOrEmpty(userId))
            {
                sqlQuery += " AND " + BaseNewsEntity.FieldCreateUserId + " = " + userId;
            }
            if (!string.IsNullOrEmpty(categoryId))
            {
                WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.DbHelper, this.UserInfo);
                DataTable dataTable = templateManager.Search(string.Empty, categoryId, string.Empty, null, false);
                string categoryIds = BaseBusinessLogic.FieldToList(dataTable, BaseFileEntity.FieldId);
                if (!string.IsNullOrEmpty(categoryIds))
                {
                    sqlQuery += " AND (" + BaseNewsEntity.FieldCategoryCode + " IN (" + categoryIds + ")) ";
                }
            }
            if (!String.IsNullOrEmpty(categorybillFullName))
            {
                sqlQuery += " AND " + BaseNewsEntity.FieldCategoryCode + " = '" + categorybillFullName + "'";
            }
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                sqlQuery += " AND (" + BaseNewsEntity.FieldTitle + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldTitle);
                sqlQuery += " OR " + BaseNewsEntity.FieldCode + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldCode);
                sqlQuery += " OR " + BaseNewsEntity.FieldCategoryCode + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldCategoryCode);
                sqlQuery += " OR " + BaseNewsEntity.FieldModifiedBy + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldModifiedBy);
                sqlQuery += " OR " + BaseNewsEntity.FieldIntroduction + " LIKE " + DbHelper.GetParameter(BaseNewsEntity.FieldIntroduction) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldTitle, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldCategoryCode, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldModifiedBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseNewsEntity.FieldIntroduction, searchValue));
            }
            sqlQuery += " ORDER BY " + BaseNewsEntity.FieldSortCode + " DESC ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }
    }
}