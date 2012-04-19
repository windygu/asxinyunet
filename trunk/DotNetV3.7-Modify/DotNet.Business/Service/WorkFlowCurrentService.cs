//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd. 
//-----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.ServiceModel;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// WorkFlowCurrentService
    /// 当前工作流服务
    /// 
    /// 修改纪录
    /// 
    ///		2007.08.15 版本：2.2 JiRiGaLa 改进运行速度采用 WebService 变量定义 方式处理数据。
    ///		2007.08.14 版本：2.1 JiRiGaLa 改进运行速度采用 Instance 方式处理数据。
    ///		2007.07.19 版本：1.0 JiRiGaLa 实现控件功能。
    ///		
    /// 版本：2.2
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2007.08.15</date>
    /// </author> 
    /// </summary>
    [ServiceBehavior(IncludeExceptionDetailInFaults = true)]
    public class WorkFlowCurrentService : System.MarshalByRefObject,IWorkFlowCurrentService
    {
        private string serviceName = AppMessage.WorkFlowCurrentService;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string WorkFlowDbConnection = BaseSystemInfo.WorkFlowDbConnection;

        /// <summary>
        /// 用户中心数据库连接
        /// </summary>
        private readonly string UserCenterDbConnection = BaseSystemInfo.UserCenterDbConnection;

        public string GetCurrentId(BaseUserInfo userInfo, string categoryId, string objectId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string returnValue = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.GetCurrentId(categoryId, objectId);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }

        public string AuditStatr(BaseUserInfo userInfo, string categoryCode, string categoryFullName, string[] objectIds, string objectFullName, string workFlowCode, string auditIdea, out string returnStatusCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            string returnValue = string.Empty;
            returnStatusCode = string.Empty;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    // 默认的都按报表来处理，特殊的直接调用，明确指定
                    IWorkFlowManager userReportManager = new UserReportManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    for (int i = 0; i < objectIds.Length; i++)
                    {
                        returnValue = workFlowCurrentManager.AutoStatr(userReportManager, categoryCode, categoryFullName, objectIds[i], objectFullName, workFlowCode, auditIdea);
                    }
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    dbHelper.CommitTransaction();
                    if (!string.IsNullOrEmpty(returnValue))
                    {
                        returnStatusCode = StatusCode.OK.ToString();
                    }
                }
                catch (Exception ex)
                {
                    dbHelper.RollbackTransaction();
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }

        /// <summary>
        /// 自动工作流审核通过
        /// </summary>
        /// <param name="flowId">当前流程主键</param>
        /// <param name="auditIdea">提交意见</param>
        /// <returns>影响行数</returns>
        public int AuditPass(BaseUserInfo userInfo, string flowId, string auditIdea)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    IWorkFlowManager userReportManager = new UserReportManager(userInfo);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dbHelper.BeginTransaction();
                    returnValue = workFlowCurrentManager.AutoAuditPass(userReportManager, flowId, auditIdea);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                    dbHelper.CommitTransaction();
                }
                catch (Exception ex)
                {
                    dbHelper.RollbackTransaction();
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }

        #region public int AuditTransmit(BaseUserInfo userInfo, string id, string sendToUserId) 下个流程发送给谁
        /// <summary>
        /// 下个流程发送给谁
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">当前主键</param>
        /// <param name="sendToUserId">用户主键</param>
        /// <param name="auditIdea">审核意见</param>
        /// <returns>数据权限</returns>
        public int AuditTransmit(BaseUserInfo userInfo, string id, string sendToUserId, string auditIdea)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.AuditTransmit(id, sendToUserId, auditIdea);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public int AuditReject(BaseUserInfo userInfo, string id, string auditIdea)
        /// <summary>
        /// 审核退回
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="id">当前主键</param>
        /// <param name="auditIdea">审核建议</param>
        /// <returns>数据权限</returns>
        public int AuditReject(BaseUserInfo userInfo, string id, string auditIdea)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.AuditReject(id, auditIdea);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public int AuditQuash(BaseUserInfo userInfo, string currentWorkFlowId, string auditIdea) 撤消审批流程中的单据
        /// <summary>
        /// 撤消审批流程中的单据
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="currentWorkFlowId">当前工作流主键</param>
        /// <param name="auditIdea">撤销意见</param>
        /// <returns>影响行数</returns>
        public int AuditQuash(BaseUserInfo userInfo, string currentWorkFlowId, string auditIdea)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.AuditQuash(currentWorkFlowId, auditIdea);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public int AuditComplete(BaseUserInfo userInfo, string id, string auditIdea) 最终审核通过
        /// <summary>
        /// 最终审核通过
        /// </summary>
        /// <param name="userInfo">当前用户</param>
        /// <param name="id">主键</param>
        /// <param name="auditIdea">审核意见</param>
        /// <returns>影响行数</returns>
        public int AuditComplete(BaseUserInfo userInfo, string id, string auditIdea)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.AuditComplete(null, id, auditIdea);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }
            
            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
        #endregion

        #region public DataTable GetDataTable(BaseUserInfo BaseUserInfo) 获取流程当前步骤列表
        /// <summary>
        /// 获取流程当前步骤列表
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTable(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = new DataTable(BaseWorkFlowCurrentEntity.TableName);
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldEnabled, 1));
                    parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0));
                    dataTable = workFlowCurrentManager.GetDataTable(parameters, BaseWorkFlowCurrentEntity.FieldSendDate);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }
        #endregion

        public DataTable GetMonitorPagedDT(BaseUserInfo userInfo, int pageSize, int pageIndex, out int recordCount, string categoryCode = null, string searchValue = null)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            recordCount = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    if (userInfo.IsAdministrator)
                    {
                        // 不分页
                        dataTable = workFlowCurrentManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0), BaseWorkFlowCurrentEntity.FieldSendDate);
                        // 分页
                        // dataTable = workFlowCurrentManager.GetPagedDT(pageSize, pageIndex, out recordCount, categoryCode, searchValue);
                    }
                    else
                    {
                        //dataTable = workFlowCurrentManager.GetMonitorDT();
                        dataTable = workFlowCurrentManager.GetMonitorPagedDT(pageSize,pageIndex,out recordCount,categoryCode,searchValue);
                    }
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }

        public DataTable GetMonitorDT(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    if (userInfo.IsAdministrator)
                    {
                        dataTable = workFlowCurrentManager.GetDataTable(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0), BaseWorkFlowCurrentEntity.FieldSendDate);
                    }
                    else
                    {
                        dataTable = workFlowCurrentManager.GetMonitorDT();
                    }
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }

        public DataTable GetWaitForAudit(BaseUserInfo userInfo)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    // 这个是获取用户的角色信息
                    dbHelper.Open(UserCenterDbConnection);
                    BaseUserRoleManager userRoleManager = new BaseUserRoleManager(dbHelper);
                    string[] roleIds = userRoleManager.GetAllRoleIds(userInfo.Id);
                    dbHelper.Close();
                    // 这里是获取待审核信息
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    dataTable = workFlowCurrentManager.GetWaitForAudit(userInfo.Id);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }

        /// <summary>
        /// 获取审核历史明细 
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="categoryId">单据分类主键</param>
        /// <param name="objectId">单据主键</param>
        /// <returns>数据权限</returns>
        public DataTable GetAuditDetailDT(BaseUserInfo userInfo, string categoryId, string objectId)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            DataTable dataTable = null;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    string[] ids = workFlowCurrentManager.GetIds(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldCategoryCode, categoryId), new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldObjectId, objectId));
                    BaseWorkFlowHistoryManager workFlowHistoryManager = new BaseWorkFlowHistoryManager(dbHelper, userInfo);
                    dataTable = workFlowHistoryManager.GetDataTable(BaseWorkFlowHistoryTable.FieldCurrentFlowId, ids, BaseWorkFlowHistoryTable.FieldCreateOn);
                    dataTable.TableName = BaseWorkFlowCurrentEntity.TableName;
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return dataTable;
        }

        /// <summary>
        /// 替换工作审核者
        /// </summary>
        /// <param name="userInfo">用户</param>
        /// <param name="oldCode">原来的工号</param>
        /// <param name="newCode">新的工号</param>
        /// <returns>影响行数</returns>
        public int Replace(BaseUserInfo userInfo, string oldCode, string newCode)
        {
            // 写入调试信息
            #if (DEBUG)
                int milliStart = BaseBusinessLogic.StartDebug(userInfo, MethodBase.GetCurrentMethod());
            #endif

            // 加强安全验证防止未授权匿名调用
            #if (!DEBUG)
                LogOnService.UserIsLogOn(userInfo);
            #endif

            int returnValue = 0;
            using (IDbHelper dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType))
            {
                try
                {
                    dbHelper.Open(WorkFlowDbConnection);
                    BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(dbHelper, userInfo);
                    returnValue = workFlowCurrentManager.ReplaceUser(oldCode, newCode);
                    BaseLogManager.Instance.Add(dbHelper, userInfo, this.serviceName, MethodBase.GetCurrentMethod());
                }
                catch (Exception ex)
                {
                    BaseExceptionManager.LogException(dbHelper, userInfo, ex);
                    throw ex;
                }
                finally
                {
                    dbHelper.Close();
                }
            }

            // 写入调试信息
            #if (DEBUG)
                BaseBusinessLogic.EndDebug(MethodBase.GetCurrentMethod(), milliStart);
            #endif

            return returnValue;
        }
    }
}