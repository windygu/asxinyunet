//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;
using System.Reflection;
using System.Transactions;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseWorkFlowCurrentManager
    /// 流程管理.
    /// 
    /// 修改纪录
    ///		
    ///		2012.04.03 版本：1.0 JiRiGaLa	脱离。
    /// 
    /// 版本：2.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.03</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowCurrentManager : BaseManager, IBaseManager
    {
        private static readonly object WorkFlowCurrentLock = new object();



        /// <summary>
        /// 获取等审核信息
        /// </summary>
        /// <param name="userId">用户主键</param>
        /// <param name="categoryFullName">分类</param>
        /// <param name="search">查询</param>
        /// <returns>数据表</returns>
        public DataTable GetWaitForAudit(string userId = null, string categoryFullName = null, string searchValue = null)
        {
            if (string.IsNullOrEmpty(userId))
            {
                userId = this.UserInfo.Id;
            }
            string sqlQuery = " SELECT * "
                            + "   FROM " + BaseWorkFlowCurrentEntity.TableName
                // 未被删除的，有效的数据，还没能审核结束的
                            + "  WHERE (" + BaseWorkFlowCurrentEntity.FieldDeletionStateCode + " = 0) "
                // Enabled 0 表示，审核还没结束
                            + "    AND (" + BaseWorkFlowCurrentEntity.FieldEnabled + " = 0) ";
            if (!string.IsNullOrEmpty(userId))
            {
                // 待审核的工作流（指向用户的）
                sqlQuery += "    AND (" + BaseWorkFlowCurrentEntity.FieldToUserId + "=" + userId + " ";
                //（指向角色的）
                BaseUserRoleManager userRoleManager = new BaseUserRoleManager(this.UserInfo);
                string[] roleIds = userRoleManager.GetAllRoleIds(userId);
                if (roleIds != null && roleIds.Length > 0)
                {
                    sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToRoleId + " IN (" + StringUtil.ArrayToList(roleIds) + ")";
                }
                //（指向部门的）
                BaseUserOrganizeManager userOrganizeManager = new BaseUserOrganizeManager(this.UserInfo);
                string[] organizeIds = userOrganizeManager.GetAllOrganizeIds(userId);
                if (organizeIds != null && organizeIds.Length > 0)
                {
                    sqlQuery += " OR (" + BaseWorkFlowCurrentEntity.FieldToUserId + " IS NULL AND + " + BaseWorkFlowCurrentEntity.FieldToDepartmentId + " IN (" + StringUtil.ArrayToList(organizeIds) + "))";
                }
                sqlQuery += " ) ";
            }

            if (!string.IsNullOrEmpty(categoryFullName))
            {
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldCategoryFullName + " ='" + categoryFullName + "') ";
            }

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName, searchValue));
            }
            // 排序字段
            sqlQuery += " ORDER BY " + BaseWorkFlowCurrentEntity.FieldSendDate;
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }


        #region public DataTable GetAllWaitForAudit() 获取等审核信息
        /// <summary>
        /// 获取等审核信息
        /// </summary>
        /// <param name="dataSet">填充数据权限</param>
        /// <returns>数据权限</returns>
        public DataTable GetAllWaitForAudit()
        {
            string sqlQuery = " SELECT * "
                            + "   FROM " + BaseWorkFlowCurrentEntity.TableName
                            + "  WHERE (" + BaseWorkFlowCurrentEntity.FieldEnabled + " = ?) "
                            + "    AND (" + BaseWorkFlowCurrentEntity.FieldAuditStatus + "= ? OR " + BaseWorkFlowCurrentEntity.FieldAuditStatus + "= ? OR " + BaseWorkFlowCurrentEntity.FieldAuditStatus + "= ?)";

            string[] names = new string[4];
            Object[] values = new Object[4];
            names[0] = BaseWorkFlowCurrentEntity.FieldEnabled;
            values[0] = 1;
            names[1] = BaseWorkFlowCurrentEntity.FieldAuditStatus;
            values[1] = AuditStatus.WaitForAudit.ToString();
            names[2] = BaseWorkFlowCurrentEntity.FieldAuditStatus;
            values[2] = AuditStatus.StartAudit.ToString();
            names[3] = BaseWorkFlowCurrentEntity.FieldAuditStatus;
            values[3] = AuditStatus.AuditReject.ToString();
            DataTable dataTable = DbHelper.Fill(sqlQuery, DbHelper.MakeParameters(names, values));
            return dataTable;
        }
        #endregion


        /// <summary>
        /// 分页流程监控看全部的数据
        /// </summary>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="recordCount"></param>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="searchValue">查询内容</param>
        /// <returns>数据表</returns>
        public DataTable GetPagedDT(int pageSize, int pageIndex, out int recordCount, string categoryCode = null, string searchValue = null)
        {
            string sqlQuery = string.Empty;
            sqlQuery += "SELECT * FROM " + BaseWorkFlowCurrentEntity.TableName
                      + " WHERE " + BaseWorkFlowCurrentEntity.FieldDeletionStateCode + " = 0 ";

            if (!string.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND " + BaseWorkFlowCurrentEntity.FieldCategoryCode + "= '" + categoryCode + "'";
            }
            searchValue = StringUtil.GetSearchString(searchValue);
            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldCreateBy + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE '" + searchValue + "')";
            }
            string orderBy = BaseWorkFlowCurrentEntity.FieldSortCode;
            return this.GetDataTableByPage(out recordCount, pageIndex, pageSize, sqlQuery, orderBy);
        }

        #region public DataTable GetRoleWaitForAudit(string roleId, string categoryCode)
        /// <summary>
        /// 获取某个角色的，当前待审核的列表
        /// </summary>
        /// <param name="roleId">角色主键</param>
        /// <param name="categoryCode">分类主键</param>
        /// <returns>数据表</returns>
        public DataTable GetRoleWaitForAudit(string roleId, string categoryCode)
        {
            string sqlQuery = " SELECT * "
                            + "   FROM " + BaseWorkFlowCurrentEntity.TableName
                // 未被删除的，有效的数据
                            + "  WHERE (" + BaseWorkFlowCurrentEntity.FieldDeletionStateCode + " = 0) AND (" + BaseWorkFlowCurrentEntity.FieldEnabled + " = 1) ";
            // 待审核的工作流（指向角色的）
            if (!string.IsNullOrEmpty(roleId))
            {
                sqlQuery += "    AND (" + BaseWorkFlowCurrentEntity.FieldToRoleId + " = " + roleId + ") ";
            }
            // 分类
            if (!string.IsNullOrEmpty(roleId))
            {
                sqlQuery += "   AND (" + BaseWorkFlowCurrentEntity.FieldCategoryCode + " = '" + categoryCode + "') ";
            }
            // 排序字段
            sqlQuery += " ORDER BY " + BaseWorkFlowCurrentEntity.FieldSendDate;
            return DbHelper.Fill(sqlQuery);
        }
        #endregion

        /// <summary>
        /// 获取已审核流程列表
        /// </summary>
        /// <param name="categoryId">分类主键</param>
        /// <param name="categorybillFullName">流程</param>
        /// <param name="searchValue">关键字</param>
        /// <returns></returns>
        public DataTable GetAuditRecord(string categoryCode, string categorybillFullName = null, string searchValue = null)
        {
            string sqlQuery = @"   SELECT BaseWorkFlowCurrent.*
                                     FROM BaseWorkFlowCurrent
                                    WHERE BaseWorkFlowCurrent.DELETIONSTATECODE = 0
                                          AND (BaseWorkFlowCurrent.Id 
                                               IN ( SELECT DISTINCT BaseWorkFlowHistory.CurrentFlowId
                                                      FROM BaseWorkFlowHistory
                                                     WHERE (BaseWorkFlowHistory.DeletionStateCode = 0) 
                                                            AND (BaseWorkFlowHistory.AuditUserId = " + this.UserInfo.Id + "  OR BaseWorkFlowHistory.ToUserId = " + this.UserInfo.Id + @") 
                                                            AND (BaseWorkFlowHistory.DeletionStateCode = 0)))";

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!string.IsNullOrEmpty(categoryCode))
            {
                WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.DbHelper, this.UserInfo);
                DataTable dataTable = templateManager.Search(string.Empty, categoryCode, string.Empty, null, false);
                string categoryCodes = BaseBusinessLogic.FieldToList(dataTable, BaseFileEntity.FieldCode);
                if (!string.IsNullOrEmpty(categoryCodes))
                {
                    sqlQuery += " AND (BaseWorkFlowCurrent.CategoryCode IN (" + categoryCodes + ")) ";
                }
            }
            if (!string.IsNullOrEmpty(categorybillFullName))
            {
                sqlQuery += " AND (BaseWorkFlowCurrent.CategoryFullName ='" + categorybillFullName + "') ";
            }

            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName, searchValue));
            }

            sqlQuery += "  ORDER BY BaseWorkFlowCurrent.SORTCODE ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }

        public DataTable GetShareBillDT(string categoryFullName = null, string searchValue = null)
        {
            string sqlQuery = @"   SELECT BaseWorkFlowCurrent.*
                                     FROM BaseWorkFlowCurrent, BaseWorkFlowActivity
                                    WHERE BaseWorkFlowCurrent.DELETIONSTATECODE = 0
                                          AND BaseWorkFlowCurrent.ENABLED = 1
                                          AND (BaseWorkFlowActivity.AUDITUSERID = '" + this.UserInfo.Id + @"') 
                                          AND (BaseWorkFlowActivity.ENABLED = 0)
                                          AND (BaseWorkFlowActivity.DELETIONSTATECODE = 0) 
                                          AND (BaseWorkFlowActivity.WORKFLOWID = BaseWorkFlowCurrent.WORKFLOWID) ";
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!string.IsNullOrEmpty(categoryFullName))
            {
                sqlQuery += " AND (BaseWorkFlowCurrent.CategoryFullName ='" + categoryFullName + "') ";
            }

            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldCreateBy);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName, searchValue));
            }
            sqlQuery += " ORDER BY BaseWorkFlowCurrent.CREATEON DESC ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }

        /// <summary>
        /// 越级审核是按排序码比对来实现
        /// 审核流程定义时审核步骤地排序顺序
        /// 这里需要排序顺序进行优化
        /// </summary>
        /// <param name="categoryCode"></param>
        /// <param name="searchValue"></param>
        /// <returns></returns>
        public DataTable GetSuperAudit(string categoryCode, string searchValue)
        {
            string sqlQuery = @"   SELECT BaseWorkFlowCurrent.*
                                     FROM BaseWorkFlowCurrent, BaseWorkFlowActivity
                                    WHERE BaseWorkFlowCurrent.DELETIONSTATECODE = 0
                                          AND (BaseWorkFlowActivity.AUDITUSERID = '" + this.UserInfo.Id + @"') 
                                          AND (BaseWorkFlowActivity.DELETIONSTATECODE = 0) 
                                          AND (BaseWorkFlowActivity.ENABLED = 1)
                                          AND (BaseWorkFlowActivity.WORKFLOWID = BaseWorkFlowCurrent.WORKFLOWID) 
                                          AND (BaseWorkFlowActivity.SORTCODE > BaseWorkFlowCurrent.SORTCODE)";

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!string.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND (BaseWorkFlowCurrent.CategoryCode ='" + categoryCode + "') ";
            }

            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldCreateBy);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName, searchValue));
            }
            sqlQuery += " ORDER BY BaseWorkFlowCurrent.SORTCODE ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }

        /// <summary>
        /// 流程监控是看未被删除的,当前正在审核中的单据
        /// </summary>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="searchValue">查询内容</param>
        /// <returns>数据表</returns>
        public DataTable GetMonitorDT(string categoryCode = null, string searchValue = null)
        {
            string sqlQuery = @"   SELECT BaseWorkFlowCurrent.*
                                     FROM BaseWorkFlowCurrent
                                    WHERE BaseWorkFlowCurrent.DELETIONSTATECODE = 0
                                          AND (BaseWorkFlowCurrent.ENABLED = 0)";
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!string.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND (BaseWorkFlowCurrent.CategoryCode ='" + categoryCode + "') ";
            }

            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldCreateBy + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldCreateBy);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.TableName + "." + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName, searchValue));
            }
            sqlQuery += " ORDER BY BaseWorkFlowCurrent.SORTCODE ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }

        /*
        public DataTable GetMonitorDT(string categoryCode, string searchValue)
        {
            BaseUserRoleManager userRoleManager = new BaseUserRoleManager();
            string[] roleIds = userRoleManager.GetAllRoleIds(this.UserInfo.Id);

            string sqlQuery = " SELECT * "
                            + "   FROM " + BaseWorkFlowCurrentEntity.TableName
                // 未被删除的，有效的数据
                            + "  WHERE (" + BaseWorkFlowCurrentEntity.FieldDeletionStateCode + " = 0) AND (" + BaseWorkFlowCurrentEntity.FieldEnabled + " = 1) "
                // 待审核的工作流（指向用户的）
                            + "    AND (((" + BaseWorkFlowCurrentEntity.FieldToUserId + "=" + this.UserInfo.Id + ") ";
            //（指向角色的）
            if (roleIds != null && roleIds.Length > 0)
            {
                sqlQuery += " OR (" + BaseWorkFlowCurrentEntity.FieldToRoleId + " IN (" + BaseBusinessLogic.ArrayToList(roleIds) + ")) ";
            }

            sqlQuery += " ) "
                // 被退回的工作流，待审核什么的工作流（自己创建的哪些工作流）
                             + "     OR  (" + BaseWorkFlowCurrentEntity.FieldCreateUserId + "=" + this.UserInfo.Id + ") "


                // 参与的工作流程
                            + "     OR " + BaseWorkFlowCurrentEntity.FieldId + " IN (SELECT DISTINCT " + BaseWorkFlowCurrentEntity.FieldWorkFlowId + " FROM " + BaseWorkFlowHistoryTable.TableName
                            + "               WHERE " + BaseWorkFlowHistoryTable.FieldAuditUserId + " = " + this.UserInfo.Id + " OR " + BaseWorkFlowHistoryTable.FieldCreateUserId + " = " + this.UserInfo.Id + ") "


                            + " ) "
                // 排序字段
                        + " ORDER BY " + BaseWorkFlowCurrentEntity.FieldSendDate;
            return DbHelper.Fill(sqlQuery);
        }
        */

        /// <summary>
        /// 分页流程监控是看未被删除的,当前正在审核中的单据
        /// </summary>
        /// <param name="categoryCode">单据分类</param>
        /// <param name="searchValue">查询内容</param>
        /// <returns>数据表</returns>
        public DataTable GetMonitorPagedDT(int pageSize, int pageIndex, out int recordCount, string categoryCode = null, string searchValue = null)
        {
            string sqlQuery = string.Empty;
            sqlQuery += "SELECT * FROM " + BaseWorkFlowCurrentEntity.TableName
                      + " WHERE " + BaseWorkFlowCurrentEntity.FieldDeletionStateCode + " = 0 "
                      + " AND " + BaseWorkFlowCurrentEntity.FieldEnabled + " = 0 ";
            if (!string.IsNullOrEmpty(categoryCode))
            {
                sqlQuery += " AND " + BaseWorkFlowCurrentEntity.FieldCategoryCode + "= '" + categoryCode + "') ";
            }
            searchValue = StringUtil.GetSearchString(searchValue);
            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldCreateBy + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE '" + searchValue + "'";
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE '" + searchValue + "')";
            }
            string orderBy = BaseWorkFlowCurrentEntity.FieldSortCode;
            return this.GetDataTableByPage(out recordCount, pageIndex, pageSize, sqlQuery, orderBy);
        }


        /// <summary>
        /// 获取已审核流程列表
        /// </summary>
        /// <param name="categoryId">分类主键</param>
        /// <param name="billCategoryCode">流程</param>
        /// <param name="searchValue">关键字</param>
        /// <returns></returns>
        public DataTable GetUserAllBill(string categoryId, string billCategoryCode = null, string searchValue = null)
        {
            string sqlQuery = @"   SELECT BaseWorkFlowCurrent.*
                                     FROM BaseWorkFlowCurrent
                                    WHERE BaseWorkFlowCurrent.DELETIONSTATECODE = 0
                                          AND (BaseWorkFlowCurrent.CreateUserId = '" + this.UserInfo.Id + "')";

            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();
            if (!string.IsNullOrEmpty(categoryId))
            {
                WorkFlowBillTemplateManager templateManager = new WorkFlowBillTemplateManager(this.DbHelper, this.UserInfo);
                DataTable dataTable = templateManager.Search(string.Empty, categoryId, string.Empty, null, false);
                string categoryCodes = BaseBusinessLogic.FieldToList(dataTable, BaseFileEntity.FieldCode);
                if (!string.IsNullOrEmpty(categoryCodes))
                {
                    sqlQuery += " AND (BaseWorkFlowCurrent.CategoryCode IN (" + categoryCodes + ")) ";
                }
            }
            if (!string.IsNullOrEmpty(billCategoryCode))
            {
                sqlQuery += " AND (BaseWorkFlowCurrent.CategoryCode ='" + billCategoryCode + "') ";
            }

            if (!String.IsNullOrEmpty(searchValue))
            {
                searchValue = searchValue.Trim();
                sqlQuery += " AND (" + BaseWorkFlowCurrentEntity.FieldObjectFullName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldAuditIdea + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToDepartmentName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName);
                sqlQuery += " OR " + BaseWorkFlowCurrentEntity.FieldToUserRealName + " LIKE " + DbHelper.GetParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName) + ")";
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldObjectFullName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditUserRealName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldAuditIdea, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToDepartmentName, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(BaseWorkFlowCurrentEntity.FieldToUserRealName, searchValue));
            }

            sqlQuery += "  ORDER BY BaseWorkFlowCurrent.SORTCODE ";
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }



        #region public int Replace(string oldUserId, string newUserId) 替换当前步骤中的人员
        /// <summary>
        /// 替换当前步骤中的人员
        /// </summary>
        /// <param name="oldUserId">原来的工号</param>
        /// <param name="newUserId">新的工号</param>
        /// <returns>影响行数</returns>
        public int ReplaceUser(string oldUserId, string newUserId)
        {
            BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            BaseUserEntity newUserEntity = userManager.GetEntity(newUserId);
            SQLBuilder sqlBuilder = new SQLBuilder(this.DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToUserId, newUserEntity.Id);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToUserRealName, newUserEntity.RealName);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToDepartmentId, newUserEntity.DepartmentId);
            sqlBuilder.SetValue(BaseWorkFlowCurrentEntity.FieldToDepartmentName, newUserEntity.DepartmentName);
            sqlBuilder.SetWhere(BaseWorkFlowCurrentEntity.FieldToUserId, oldUserId, "OldUserId");
            return sqlBuilder.EndUpdate();
        }
        #endregion


        #region public int Reset(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        /// <summary>
        /// 重置审批流程中的单据(撤销的没必要发送提醒信息)
        /// </summary>
        /// <param name="categoryCode">分类编号</param>
        /// <param name="objectId">实体主键</param>
        /// <param name="auditIdea">批示</param>
        /// <returns>影响行数</returns>
        public int Reset(BaseWorkFlowCurrentEntity workFlowCurrentEntity)
        {
            IWorkFlowManager workFlowManager = this.GetWorkFlowManager(workFlowCurrentEntity.Id);
            // 退回时，应该给创建者一个提醒消息
            return workFlowManager.OnReset(workFlowCurrentEntity) ? 1 : 0;
        }
        #endregion
    }
}