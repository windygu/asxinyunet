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
    ///	WorkFlowBillTemplateManager
    /// 单据模板表
    /// 工作流_模板单据表名
    /// 
    /// 修改纪录
    /// 
    ///		2011.11.23 版本：2.0 JiRiGaLa	支持Excel模板。
    ///		2011.09.06 版本：1.0 JiRiGaLa	创建。
    /// 
    /// 版本：2.0
    /// 
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2011.11.23</date>
    /// </author> 
    /// </summary>
    public partial class WorkFlowBillTemplateManager : BaseNewsManager
    {
        public static string TemplateTable = "WorkFlowBillTemplate";

        public WorkFlowBillTemplateManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.WorkFlowDbType, BaseSystemInfo.WorkFlowDbConnection);
            }
            this.CurrentTableName = TemplateTable;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public WorkFlowBillTemplateManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public WorkFlowBillTemplateManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public WorkFlowBillTemplateManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public WorkFlowBillTemplateManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public WorkFlowBillTemplateManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        public string GetAddPage(string idOrCode)
        {
            return GetPage(idOrCode, "AddPage");
        }

        public string GetShowPage(string idOrCode)
        {
            return GetPage(idOrCode, "ShowPage");
        }

        public string GetEditPage(string idOrCode)
        {
            return GetPage(idOrCode, "EditPage");
        }

        public string GetPage(string idOrCode, string page = "ShowPage")
        {
            string returnValue = this.GetProperty(idOrCode, page);
            if (string.IsNullOrEmpty(returnValue))
            {
                List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldCode, idOrCode));
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldDeletionStateCode, 0));
                parameters.Add(new KeyValuePair<string, object>(BaseBusinessLogic.FieldEnabled, 1));
                returnValue = this.GetProperty(parameters, page);
                if (string.IsNullOrEmpty(returnValue))
                {
                    returnValue = "../HtmlBill/HtmlBillEdit.aspx?Id={Id}";
                }
            }
            return returnValue;
        }

        public override int SetDeleted(object id, bool modifiedUser = false)
        {
            List<KeyValuePair<string, object>> parameters = new List<KeyValuePair<string, object>>();
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldCategoryCode, id));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldDeletionStateCode, 0));
            parameters.Add(new KeyValuePair<string, object>(BaseWorkFlowCurrentEntity.FieldEnabled, 0));
            BaseWorkFlowCurrentManager workFlowCurrentManager = new BaseWorkFlowCurrentManager(this.UserInfo);
            // 若现在还有流程在用这个模板,就不可以被删除
            if (!workFlowCurrentManager.Exists(parameters))
            {
                return base.SetDeleted(id, modifiedUser);
            }
            return 0;
        }
    }
}