//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH TECH, Ltd. 
//--------------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace DotNet.Business
{
    // using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// LeaveManager
    /// 管理层
    /// 
    /// 修改纪录
    /// 
    ///	2012-04-13 版本：1.0 JiRiGaLa 创建文件。
    ///		
    /// 版本：1.0
    ///
    /// <author>
    ///	<name>JiRiGaLa</name>
    ///	<date>2012-04-13</date>
    /// </author> 
    /// </summary>
    public partial class LeaveManager : BaseManager, IBaseManager
    {
	    /// <summary>
        /// 批量提交单据
		/// (无工作流)
        /// </summary>
        /// <param name="ids">单据主键</param>
        /// <returns>影响行数</returns>
        public int BatchSend(string[] ids)
        {
            int returnValue = 0;
            foreach (var id in ids)
            {
                returnValue += Send(id);
            }
            return returnValue;
        }

        /// <summary>
        /// 提交单据
		/// (无工作流)
        /// </summary>
        /// <param name="id">单据主键</param>
        /// <returns>影响行数</returns>
        public int Send(string id)
        {
            LeaveEntity entity = this.GetEntity(id);
            if (string.IsNullOrEmpty(entity.Code))
            {
                // 获取编号，产生序列号，按年生成
                string sequenceName = this.CurrentTableName + DateTime.Now.ToString("yyyy");
                BaseSequenceManager sequenceManager = new BaseSequenceManager(this.UserInfo);
                string sequenceCode = sequenceManager.GetSequence(sequenceName, 1, 6, true);
                entity.Code = DateTime.Now.ToString("yyyy") + "-" + sequenceCode;
            }
            entity.Enabled = 1;
            return this.Update(entity);
        }

        #region public DataTable GetDataTableByPage(string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = null, string sortDire = null)
        /// <summary>
        /// 按条件分页查询
        /// </summary>
        /// <param name="userId">查看用户</param>
        /// <param name="searchValue">查询字段</param>
        /// <param name="recordCount">记录数</param>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页显示</param>
        /// <param name="sortExpression">排序字段</param>
        /// <param name="sortDire">排序方向</param>
        /// <returns>数据表</returns>
        public DataTable GetDataTableByPage(string userId, string searchValue, out int recordCount, int pageIndex = 1, int pageSize = 20, string sortExpression = "CreateOn", string sortDire = "DESC")
        {
            string whereConditional = LeaveEntity.FieldDeletionStateCode + " = 0 ";
            if (!string.IsNullOrEmpty(userId))
            {
                whereConditional += " AND " + LeaveEntity.FieldCreateUserId + " = '" + userId + "'";
            }

			// 可以看自己公司的数据
            // whereConditional += " AND " + LeaveEntity.FieldCompanyId + " = '" + this.UserInfo.CompanyId + "'";
            // 用户在某个部门
            BaseUserManager userManager = new BaseUserManager(this.UserInfo);
            if (userManager.IsInOrganize(this.UserInfo.Id, "技术组") || userManager.IsInOrganize(this.UserInfo.Id, "管理组"))
            {
                // 可以看全部
            }
            else if (!string.IsNullOrEmpty(userId))
            {
                // 只能看自己的
                whereConditional += " AND " + LeaveEntity.FieldCreateUserId + " = '" + userId + "'";
            }
            else
            {
                // 可以看自己部门的数据
                // whereConditional += " AND " + LeaveEntity.FieldDepartmentId + " = '" + this.UserInfo.DepartmentId + "'";
            }

            searchValue = searchValue.Trim();
            if (!string.IsNullOrEmpty(searchValue))
            {
                searchValue = this.DbHelper.SqlSafe(searchValue);
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "'%" + searchValue + "%'";
                }
                whereConditional += " AND (" + LeaveEntity.FieldCreateBy + " LIKE " + searchValue;
                whereConditional += " OR " + LeaveEntity.FieldUserName + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldDepartmentName + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldCode + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldTransferOfPeople + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldTelephone + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldReason + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldItemsLeaveCategory + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldTransferInstructions + " LIKE " + searchValue;
whereConditional += " OR " + LeaveEntity.FieldDescription + " LIKE " + searchValue;

				whereConditional += " OR " + LeaveEntity.FieldModifiedBy + " LIKE " + searchValue + ")";
            }
            return GetDataTableByPage(out recordCount, pageIndex, pageSize, sortExpression, sortDire, this.CurrentTableName, whereConditional, "*");
        }
        #endregion
    }
}
