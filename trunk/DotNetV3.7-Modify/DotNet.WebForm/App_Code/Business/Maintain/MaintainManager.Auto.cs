//--------------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Jirisoft TECH, Ltd.
//--------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Data;

namespace Project
{
    using DotNet.Business;
    using DotNet.Utilities;

    /// <summary>
    /// MaintainManager
    /// 故障报修
    ///
    /// 修改纪录
    ///
    ///		2012-02-17 版本：1.0  创建主键。
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
        /// <summary>
        /// 构造函数
        /// </summary>
        public MaintainManager()
        {
            base.CurrentTableName = MaintainEntity.TableName;
            base.PrimaryKey = "Id";
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public MaintainManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public MaintainManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public MaintainManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public MaintainManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public MaintainManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="maintainEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(MaintainEntity maintainEntity)
        {
            return this.AddEntity(maintainEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="maintainEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主键</param>
        /// <returns>主键</returns>
        public string Add(MaintainEntity maintainEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(maintainEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="maintainEntity">实体</param>
        public int Update(MaintainEntity maintainEntity)
        {
            return this.UpdateEntity(maintainEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public MaintainEntity GetEntity(string id)
        {
            MaintainEntity maintainEntity = new MaintainEntity(this.GetDataTable(new KeyValuePair<string, object>(MaintainEntity.FieldId, id)));
            return maintainEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="maintainEntity">实体</param>
        public string AddEntity(MaintainEntity maintainEntity)
        {
            string sequence = string.Empty;
            this.Identity = false;
            if (maintainEntity.SortCode == null || maintainEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                maintainEntity.SortCode = int.Parse(sequence);
            }
            if (maintainEntity.Id != null)
            {
                sequence = maintainEntity.Id.ToString();
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, MaintainEntity.FieldId);
            if (!this.Identity)
            {
                if (string.IsNullOrEmpty(maintainEntity.Id))
                {
                    sequence = BaseBusinessLogic.NewGuid();
                    maintainEntity.Id = sequence;
                }
                sqlBuilder.SetValue(MaintainEntity.FieldId, maintainEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(MaintainEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(MaintainEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (string.IsNullOrEmpty(maintainEntity.Id))
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            maintainEntity.Id = sequence;
                        }
                        sqlBuilder.SetValue(MaintainEntity.FieldId, maintainEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, maintainEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(MaintainEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(MaintainEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(MaintainEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(MaintainEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(MaintainEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(MaintainEntity.FieldModifiedOn);
            if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.SqlServer || DbHelper.CurrentDbType == CurrentDbType.Access))
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
        /// <param name="maintainEntity">实体</param>
        public int UpdateEntity(MaintainEntity maintainEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, maintainEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(MaintainEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(MaintainEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(MaintainEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(MaintainEntity.FieldId, maintainEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="maintainEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, MaintainEntity maintainEntity)
        {
            sqlBuilder.SetValue(MaintainEntity.FieldCode, maintainEntity.Code);
            sqlBuilder.SetValue(MaintainEntity.FieldDepartmentId, maintainEntity.DepartmentId);
            sqlBuilder.SetValue(MaintainEntity.FieldUserCode, maintainEntity.UserCode);
            sqlBuilder.SetValue(MaintainEntity.FieldDepartmentName, maintainEntity.DepartmentName);
            sqlBuilder.SetValue(MaintainEntity.FieldOfficeLocation, maintainEntity.OfficeLocation);
            sqlBuilder.SetValue(MaintainEntity.FieldTelephone, maintainEntity.Telephone);
            sqlBuilder.SetValue(MaintainEntity.FieldServiceState, maintainEntity.ServiceState);
            sqlBuilder.SetValue(MaintainEntity.FieldReportingTime, maintainEntity.ReportingTime);
            sqlBuilder.SetValue(MaintainEntity.FieldCompletionTime, maintainEntity.CompletionTime);
            sqlBuilder.SetValue(MaintainEntity.FieldMaintenancePersonnel, maintainEntity.MaintenancePersonnel);
            sqlBuilder.SetValue(MaintainEntity.FieldMalfunctionCause, maintainEntity.MalfunctionCause);
            sqlBuilder.SetValue(MaintainEntity.FieldBugLevel, maintainEntity.BugLevel);
            sqlBuilder.SetValue(MaintainEntity.FieldBugCategory, maintainEntity.BugCategory);
            sqlBuilder.SetValue(MaintainEntity.FieldProcessTime, maintainEntity.ProcessTime);
            sqlBuilder.SetValue(MaintainEntity.FieldProcessorId, maintainEntity.ProcessorId);
            sqlBuilder.SetValue(MaintainEntity.FieldProcessorName, maintainEntity.ProcessorName);
            sqlBuilder.SetValue(MaintainEntity.FieldIP, maintainEntity.IP);
            sqlBuilder.SetValue(MaintainEntity.FieldComputerUserName, maintainEntity.ComputerUserName);
            sqlBuilder.SetValue(MaintainEntity.FieldComputerPassword, maintainEntity.ComputerPassword);
            sqlBuilder.SetValue(MaintainEntity.FieldSortCode, maintainEntity.SortCode);
            sqlBuilder.SetValue(MaintainEntity.FieldDescription, maintainEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(string id)
        {
            return this.Delete(new KeyValuePair<string, object>(MaintainEntity.FieldId, id));
        }
    }
}
