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
    ///		2012.04.04 版本：1.0 JiRiGaLa	脱离。
    /// 
    /// 版本：1.0
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2012.04.04</date>
    /// </author>
    /// </summary>
    public partial class BaseWorkFlowCurrentManager : BaseManager, IBaseManager
    {
        #region public int AuditTransmit(string currentId, string sendToUserId, string auditIdea) 获取信息
        /// <summary>
        /// 下个流程发送给谁
        /// </summary>
        /// <param name="workFlowId">当前主键</param>
        /// <returns>影响行数</returns>
        public int AuditTransmit(string currentId, string sendToUserId, string auditIdea)
        {
            int returnValue = 0;
            // 进行更新操作
            returnValue = this.StepAuditTransmit(currentId, sendToUserId, auditIdea);
            if (returnValue == 0)
            {
                // 数据可能被删除
                this.ReturnStatusCode = StatusCode.ErrorDeleted.ToString();
            }
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);
            // 发送提醒信息
            // this.SendRemindMessage(workFlowCurrentEntity.ObjectId, AuditStatus.Transmit, auditIdea, sendToUserId, null);
            this.ReturnStatusMessage = this.GetStateMessage(this.ReturnStatusCode);
            return returnValue;
        }
        #endregion

        #region private int StepAuditTransmit(string currentId, string sendToUserId, string auditIdea) 获取信息
        /// <summary>
        /// 下个流程发送给谁
        /// </summary>
        /// <param name="id">当前主键</param>
        /// <returns>影响行数</returns>
        private int StepAuditTransmit(string currentId, string sendToUserId, string auditIdea)
        {
            BaseWorkFlowCurrentEntity workFlowCurrentEntity = this.GetEntity(currentId);

            // 1.记录当前的审核时间、审核人信息
            workFlowCurrentEntity.ToDepartmentId = this.UserInfo.DepartmentId;
            workFlowCurrentEntity.ToDepartmentName = this.UserInfo.DepartmentName;
            workFlowCurrentEntity.ToUserId = this.UserInfo.Id;
            workFlowCurrentEntity.ToUserRealName = this.UserInfo.RealName;
            workFlowCurrentEntity.AuditStatus = AuditStatus.Transmit.ToString();

            // 2.记录审核日志
            this.AddHistory(workFlowCurrentEntity);

            // 3.上一个审核结束了，新的审核又开始了，更新待审核情况
            workFlowCurrentEntity.AuditUserId = this.UserInfo.Id;
            workFlowCurrentEntity.AuditUserRealName = this.UserInfo.RealName;
            workFlowCurrentEntity.AuditDate = DateTime.Now;
            workFlowCurrentEntity.AuditIdea = auditIdea;

            BaseUserManager userManager = new BaseUserManager(UserInfo);
            BaseUserEntity userEntity = userManager.GetEntity(sendToUserId);
            workFlowCurrentEntity.ToRoleId = null;
            workFlowCurrentEntity.ToRoleRealName = null;
            workFlowCurrentEntity.ToDepartmentId = null;
            workFlowCurrentEntity.ToDepartmentName = null;
            workFlowCurrentEntity.ToUserId = sendToUserId;
            workFlowCurrentEntity.ToUserRealName = userEntity.RealName;
            // TODO 用户的部门信息需要处理
            if (!string.IsNullOrEmpty(userEntity.DepartmentId))
            {
                BaseOrganizeManager organizeManager = new BaseOrganizeManager(UserInfo);
                BaseOrganizeEntity organizeEntity = organizeManager.GetEntity(userEntity.DepartmentId);
                workFlowCurrentEntity.ToDepartmentId = userEntity.DepartmentId;
                workFlowCurrentEntity.ToDepartmentName = organizeEntity.FullName;
            }
            workFlowCurrentEntity.AuditStatus = AuditStatus.WaitForAudit.ToString();
            // 当前审核人的信息写入当前工作流
            workFlowCurrentEntity.Enabled = 1;
            workFlowCurrentEntity.DeletionStateCode = 0;
            return this.UpdateEntity(workFlowCurrentEntity);
        }
        #endregion
    }
}