//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 ,  TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace Project
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// MaintainManager
    /// 管理层
    /// 
    /// 修改纪录
    /// 
    ///		2012-02-17 版本：1.0  创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///		<name></name>
    ///		<date>2012-02-17</date>
    /// </author> 
    /// </summary>
    public partial class MaintainManager : BaseManager, IBaseManager
    {
        #region public DataTable GetDataTableByPage(string userId, string bugCategory, string serviceState, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <param name="userId">创建者</param>
        /// <param name="bugCategory">分类</param>
        /// <param name="serviceState">服务状态</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(string userId, string bugCategory, string serviceState, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        {
            string whereConditional = MaintainEntity.FieldDeletionStateCode + " = 0 ";
            if (!string.IsNullOrEmpty(userId))
            {
                whereConditional += " AND " + MaintainEntity.FieldCreateUserId + " = '" + userId + "'";
            }
            if (!string.IsNullOrEmpty(bugCategory))
            {
                whereConditional += " AND " + MaintainEntity.FieldBugCategory + " = '" + bugCategory + "'";
            }
            if (!string.IsNullOrEmpty(serviceState))
            {
                whereConditional += " AND " + MaintainEntity.FieldServiceState + " = '"+ serviceState + "'";
            }
            searchValue = searchValue.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = this.DbHelper.SqlSafe(searchValue);
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "'%" + searchValue + "%'";
                }
                whereConditional += " AND (" + MaintainEntity.FieldBugCategory + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldBugLevel + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldCode + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldComputerUserName + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldCreateBy + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldDepartmentName + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldDescription + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldMalfunctionCause + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldModifiedBy + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldOfficeLocation + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldServiceState + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldTelephone + " LIKE " + searchValue;
                whereConditional += " OR " + MaintainEntity.FieldUserCode + " LIKE " + searchValue + ")";
            }
            return GetDataTableByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion


        #region public int SetDraft() 设置为草稿状态
        /// <summary>
        /// 设置为草稿状态
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        public int SetDraft(string[] ids)
        {
            int returnValue = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldServiceState, MaintainStatus.Draft.ToDescription()));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedOn, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedBy, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedUserId, this.UserInfo.Id));
            returnValue = this.SetProperty(ids, parameters);
            return returnValue;
        }
        #endregion


        /// <summary>
        /// 当发出维修单时
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响行数</returns>
        private int AfterSetSend(MaintainEntity entity)
        {
            int returnValue = 0;
            string maintenancePersonnelId = string.Empty;
            BaseRoleManager roleManager = new BaseRoleManager(this.UserInfo);
            maintenancePersonnelId = roleManager.GetIdByCode("MaintenancePersonnel");
            if (!string.IsNullOrEmpty(maintenancePersonnelId))
            {
                // 发送请求维护的提醒信息
                BaseMessageEntity messageEntity = new BaseMessageEntity();
                messageEntity.FunctionCode = MessageFunction.Note.ToString();
                messageEntity.Contents = UserInfo.RealName + "(" + UserInfo.IPAddress + ")" + entity.Description;
                BaseMessageManager manager = new BaseMessageManager(this.UserInfo);
                returnValue = manager.BatchSend(string.Empty, string.Empty, maintenancePersonnelId, messageEntity);
            }
            return returnValue;
        }

        #region public int SetSend() 设置为已提交状态
        /// <summary>
        /// 设置为已提交状态
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        public int SetSend(string[] ids)
        {
            int returnValue = 0;
            MaintainEntity entity = null;
            string id = string.Empty;
            for (int i = 0; i < ids.Length; i++)
            {
                id = ids[i];
                entity = this.GetEntity(id);
                if (string.IsNullOrEmpty(entity.Code))
                {
                    // 获取编号，产生序列号
                    string sequenceName = DateTime.Now.ToString("yyyy");
                    BaseSequenceManager sequenceManager = new BaseSequenceManager(this.UserInfo);
                    string sequenceCode = sequenceManager.GetSequence(sequenceName, 1, 6, true);
                    entity.Code = sequenceCode;
                }
                entity.ServiceState = MaintainStatus.Submitted.ToDescription();
                entity.ReportingTime = DateTime.Now;
                entity.Enabled = 1;
                returnValue += this.Update(entity);
                this.AfterSetSend(entity);
            }
            
            /*
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldServiceState, "已提交"));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedOn, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedBy, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedUserId, this.UserInfo.Id));
            returnValue = this.SetProperty(ids, parameters);
            */

            return returnValue;
        }
        #endregion


        #region public int SetProcessing() 设置为维修中状态
        /// <summary>
        /// 批量设置为维修中状态
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        public int SetProcessing(string[] ids)
        {
            int returnValue = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldProcessorId, this.UserInfo.Id));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldProcessorName, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldServiceState, MaintainStatus.MaintainProcessing.ToDescription()));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedOn, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedBy, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedUserId, this.UserInfo.Id));
            returnValue = this.SetProperty(ids, parameters);
            return returnValue;
        }
        #endregion

        /// <summary>
        /// 当完成维修单时
        /// </summary>
        /// <param name="entity">实体</param>
        /// <returns>影响行数</returns>
        private int AfterSetProcessed(MaintainEntity entity)
        {
            // 发送请求维护的提醒信息
            BaseMessageEntity messageEntity = new BaseMessageEntity();
            messageEntity.FunctionCode = MessageFunction.Note.ToString();
            messageEntity.Contents = UserInfo.RealName + "(" + MaintainStatus.MaintainProcessed.ToDescription() + ")" + entity.Description;
            messageEntity.ReceiverId = entity.CreateUserId;
            messageEntity.ReceiverRealName = entity.CreateBy;
            BaseMessageManager manager = new BaseMessageManager(this.UserInfo);
            return manager.Send(messageEntity);
        }


        #region public int SetProcessed() 设置为已处理状态
        /// <summary>
        /// 批量设置为已处理状态
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        public int SetProcessed(string[] ids)
        {
            int returnValue = 0;

            MaintainEntity entity = null;
            string id = string.Empty;
            for (int i = 0; i < ids.Length; i++)
            {
                id = ids[i];
                entity = this.GetEntity(id);
                entity.ProcessorId = this.UserInfo.Id;
                entity.ProcessorName = this.UserInfo.RealName;
                entity.ServiceState = MaintainStatus.MaintainProcessed.ToDescription();
                entity.CompletionTime = DateTime.Now;
                entity.Enabled = 0;
                returnValue += this.Update(entity);
                this.AfterSetProcessed(entity);
            }

            /*
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldProcessorId, this.UserInfo.Id));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldProcessorName, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldCompletionTime, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldServiceState, "已处理"));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedOn, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedBy, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedUserId, this.UserInfo.Id));
            returnValue = this.SetProperty(ids, parameters);
            */
            return returnValue;
        }
        #endregion


        #region public int SetComplete() 设置为已完成状态
        /// <summary>
        /// 批量设置为已完成状态
        /// </summary>
        /// <param name="ids">主键数组</param>
        /// <returns>影响的行数</returns>
        public int SetComplete(string[] ids)
        {
            int returnValue = 0;
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldCompletionTime, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldServiceState, MaintainStatus.Complete.ToDescription()));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedOn, DateTime.Now));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedBy, this.UserInfo.RealName));
            parameters.Add(new KeyValuePair<string, object>(MaintainEntity.FieldModifiedUserId, this.UserInfo.Id));
            returnValue = this.SetProperty(ids, parameters);
            return returnValue;
        }
        #endregion
    }
}
