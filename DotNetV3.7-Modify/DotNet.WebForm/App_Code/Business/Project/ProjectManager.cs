//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Data.Common;
using System.Collections.Generic;

namespace Project
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// ProjectManager
    /// 项目跟进表
    ///
    /// 修改纪录
    ///
    ///		2010-09-28 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-09-28</date>
    /// </author>
    /// </summary>
    public partial class ProjectManager : BaseManager, IBaseManager
    {
        public DataTable Search(string userId, string searchValue)
        {
            // 一、这里是开始进行动态SQL语句拼接，字段名、表明都进行了常量定义，表名字段名发生变化时，很容易就知道程序哪里都调用了这些。
            string sqlQuery = string.Empty;
            sqlQuery = " SELECT * "
                    + " FROM " + this.CurrentTableName
                    + " WHERE " + ProjectTable.FieldDeletionStateCode + " =  0 ";

            // 二、我们认为 userId 这个查询条件是安全，不是人为输入的参数，所以直接进行了SQL语句拼接
            if (!String.IsNullOrEmpty(userId))
            {
                sqlQuery += " AND " + ProjectTable.FieldCreateUserId + " = '" + userId + "'";
            }

            // 三、这里是进行参数化的准备，因为是多个不确定的查询参数，所以用了List。
            List<IDbDataParameter> dbParameters = new List<IDbDataParameter>();

            // 四、这里看查询条件是否为空
            searchValue = searchValue.Trim();
            if (!String.IsNullOrEmpty(searchValue))
            {
                // 五、这里是进行支持多种数据库的参数化查询
                sqlQuery += " AND (" + ProjectTable.FieldKeHuMingCheng + " LIKE " + DbHelper.GetParameter(ProjectTable.FieldKeHuMingCheng);
                sqlQuery += " OR " + ProjectTable.FieldKeHuXiangMuMingCheng + " LIKE " + DbHelper.GetParameter(ProjectTable.FieldKeHuXiangMuMingCheng);
                sqlQuery += " OR " + ProjectTable.FieldCreateBy + " LIKE " + DbHelper.GetParameter(ProjectTable.FieldCreateBy);
                sqlQuery += " OR " + ProjectTable.FieldDescription + " LIKE " + DbHelper.GetParameter(ProjectTable.FieldDescription) + ")";

                // 六、这里是判断，用户是否已经输入了%
                if (searchValue.IndexOf("%") < 0)
                {
                    searchValue = "%" + searchValue + "%";
                }

                // 七、这里生成支持多数据库的参数
                dbParameters.Add(DbHelper.MakeParameter(ProjectTable.FieldKeHuMingCheng, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(ProjectTable.FieldKeHuXiangMuMingCheng, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(ProjectTable.FieldCreateBy, searchValue));
                dbParameters.Add(DbHelper.MakeParameter(ProjectTable.FieldDescription, searchValue));
            }
            sqlQuery += " ORDER BY " + ProjectTable.FieldSortCode + " DESC ";

            // 八、这里是将List转换为数组，进行数据库查询
            return DbHelper.Fill(sqlQuery, dbParameters.ToArray());
        }
        
        /// <summary>
        /// 更新（带有修改记录功能）
        /// </summary>
        /// <param name="projectEntity">实体</param>
        /// <param name="changeLog">修改记录</param>
        /// <returns>影响行数</returns>
        public int Update(ProjectEntity projectEntity, bool changeLog)
        {
            // 若不需要修改记录
            if (!changeLog)
            {
                return this.UpdateEntity(projectEntity);
            }

            string changeMessage = String.Empty;

            // 获取原来的数据
            ProjectEntity oldProjectEntity = this.GetEntity((int)projectEntity.Id);
            if (oldProjectEntity.KeHuXiangMuMingCheng != projectEntity.KeHuXiangMuMingCheng)
            {
                changeMessage += "客户项目名称被修改为：" + projectEntity.KeHuXiangMuMingCheng + " 原值：" + oldProjectEntity.KeHuXiangMuMingCheng + "<br>";
            }
            if (oldProjectEntity.KeHuMingCheng != projectEntity.KeHuMingCheng)
            {
                changeMessage += "客户名称被修改为：" + projectEntity.KeHuMingCheng + " 原值：" + oldProjectEntity.KeHuMingCheng + "<br>";
            }

            if (oldProjectEntity.KaiGaiRiQi != projectEntity.KaiGaiRiQi)
            {
                // changeMessage += "开改模日期被修改为：" + ((DateTime)projectEntity.KaiGaiRiQi).ToString(BaseSystemInfo.DateFormat) + " 原值：" + ((DateTime)oldProjectEntity.KaiGaiRiQi).ToString(BaseSystemInfo.DateFormat) + "<br>";
            }

            if (!String.IsNullOrEmpty(changeMessage))
            {
                // BaseCommentManager commentManager = new BaseCommentManager(this.DbHelper, this.UserInfo);
                // commentManager.Add("工程管理", projectEntity.Id.ToString(), projectEntity.KeHuXiangMuMingCheng, changeMessage, false, String.Empty, false, this.UserInfo.IPAddress);
            }

            return this.UpdateEntity(projectEntity);
        }
    }
}