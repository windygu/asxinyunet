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
    /// BaseStaffManager
    /// 员工表
    ///
    /// 修改纪录
    ///
    ///		2010-07-15 版本：1.0 JiRiGaLa 创建主键。
    ///
    /// 版本：1.0
    ///
    /// <author>
    ///		<name>JiRiGaLa</name>
    ///		<date>2010-07-15</date>
    /// </author>
    /// </summary>
    public partial class BaseStaffManager : BaseManager, IBaseManager
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseStaffManager()
        {
            if (base.dbHelper == null)
            {
                base.dbHelper = DbHelperFactory.GetHelper(BaseSystemInfo.UserCenterDbType, BaseSystemInfo.UserCenterDbConnection);
            }
            base.CurrentTableName = BaseStaffEntity.TableName;
        }

        /// <summary>
        /// 构造函数
        /// <param name="tableName">指定表名</param>
        /// </summary>
        public BaseStaffManager(string tableName)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        public BaseStaffManager(IDbHelper dbHelper)
            : this()
        {
            DbHelper = dbHelper;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="userInfo">用户信息</param>
        public BaseStaffManager(BaseUserInfo userInfo)
            : this()
        {
            UserInfo = userInfo;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dbHelper">数据库连接</param>
        /// <param name="userInfo">用户信息</param>
        public BaseStaffManager(IDbHelper dbHelper, BaseUserInfo userInfo)
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
        public BaseStaffManager(IDbHelper dbHelper, BaseUserInfo userInfo, string tableName)
            : this(dbHelper, userInfo)
        {
            base.CurrentTableName = tableName;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="staffEntity">实体</param>
        /// <returns>主键</returns>
        public string Add(BaseStaffEntity staffEntity)
        {
            return this.AddEntity(staffEntity);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="staffEntity">实体</param>
        /// <param name="identity">自增量方式</param>
        /// <param name="returnId">返回主鍵</param>
        /// <returns>主键</returns>
        public string Add(BaseStaffEntity staffEntity, bool identity, bool returnId)
        {
            this.Identity = identity;
            this.ReturnId = returnId;
            return this.AddEntity(staffEntity);
        }

        /// <summary>
        /// 更新
        /// </summary>
        /// <param name="staffEntity">实体</param>
        public int Update(BaseStaffEntity staffEntity)
        {
            return this.UpdateEntity(staffEntity);
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseStaffEntity GetEntity(int id)
        {
            return GetEntity(id.ToString());
        }

        /// <summary>
        /// 获取实体
        /// </summary>
        /// <param name="id">主键</param>
        public BaseStaffEntity GetEntity(string id)
        {
            BaseStaffEntity staffEntity = new BaseStaffEntity(this.GetDataTable(BaseStaffEntity.FieldId, id));
            return staffEntity;
        }

        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="staffEntity">实体</param>
        public string AddEntity(BaseStaffEntity staffEntity)
        {
            string sequence = string.Empty;
            if (staffEntity.SortCode == 0)
            {
                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                staffEntity.SortCode = int.Parse(sequence);
            }
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper, this.Identity, this.ReturnId);
            sqlBuilder.BeginInsert(this.CurrentTableName, BaseStaffEntity.FieldId);
            if (!this.Identity)
            {
                sqlBuilder.SetValue(BaseStaffEntity.FieldId, staffEntity.Id);
            }
            else
            {
                if (!this.ReturnId && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                {
                    if (DbHelper.CurrentDbType == CurrentDbType.Oracle)
                    {
                        sqlBuilder.SetFormula(BaseStaffEntity.FieldId, "SEQ_" + this.CurrentTableName.ToUpper() + ".NEXTVAL ");
                    }
                    if (DbHelper.CurrentDbType == CurrentDbType.DB2)
                    {
                        sqlBuilder.SetFormula(BaseStaffEntity.FieldId, "NEXT VALUE FOR SEQ_" + this.CurrentTableName.ToUpper());
                    }
                }
                else
                {
                    if (this.Identity && (DbHelper.CurrentDbType == CurrentDbType.Oracle || DbHelper.CurrentDbType == CurrentDbType.DB2))
                    {
                        if (staffEntity.Id == null)
                        {
                            if (string.IsNullOrEmpty(sequence))
                            {
                                BaseSequenceManager sequenceManager = new BaseSequenceManager(DbHelper, this.Identity);
                                sequence = sequenceManager.GetSequence(this.CurrentTableName);
                            }
                            staffEntity.Id = int.Parse(sequence);
                        }
                        sqlBuilder.SetValue(BaseStaffEntity.FieldId, staffEntity.Id);
                    }
                }
            }
            this.SetEntity(sqlBuilder, staffEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseStaffEntity.FieldCreateUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseStaffEntity.FieldCreateBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseStaffEntity.FieldCreateOn);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseStaffEntity.FieldModifiedOn);
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
        /// <param name="staffEntity">实体</param>
        public int UpdateEntity(BaseStaffEntity staffEntity)
        {
            SQLBuilder sqlBuilder = new SQLBuilder(DbHelper);
            sqlBuilder.BeginUpdate(this.CurrentTableName);
            this.SetEntity(sqlBuilder, staffEntity);
            if (UserInfo != null)
            {
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedUserId, UserInfo.Id);
                sqlBuilder.SetValue(BaseStaffEntity.FieldModifiedBy, UserInfo.RealName);
            }
            sqlBuilder.SetDBNow(BaseStaffEntity.FieldModifiedOn);
            sqlBuilder.SetWhere(BaseStaffEntity.FieldId, staffEntity.Id);
            return sqlBuilder.EndUpdate();
        }

        /// <summary>
        /// 设置实体
        /// </summary>
        /// <param name="staffEntity">实体</param>
        private void SetEntity(SQLBuilder sqlBuilder, BaseStaffEntity staffEntity)
        {
            sqlBuilder.SetValue(BaseStaffEntity.FieldUserId, staffEntity.UserId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldUserName, staffEntity.UserName);
            sqlBuilder.SetValue(BaseStaffEntity.FieldRealName, staffEntity.RealName);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCode, staffEntity.Code);
            sqlBuilder.SetValue(BaseStaffEntity.FieldGender, staffEntity.Gender);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCompanyId, staffEntity.CompanyId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDepartmentId, staffEntity.DepartmentId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldWorkgroupId, staffEntity.WorkgroupId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDutyId, staffEntity.DutyId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldIdentificationCode, staffEntity.IdentificationCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldIdCard, staffEntity.IdCard);
            sqlBuilder.SetValue(BaseStaffEntity.FieldBankCode, staffEntity.BankCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEmail, staffEntity.Email);
            sqlBuilder.SetValue(BaseStaffEntity.FieldMobile, staffEntity.Mobile);
            sqlBuilder.SetValue(BaseStaffEntity.FieldShortNumber, staffEntity.ShortNumber);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTelephone, staffEntity.Telephone);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOICQ, staffEntity.OICQ);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficePhone, staffEntity.OfficePhone);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficeZipCode, staffEntity.OfficeZipCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficeAddress, staffEntity.OfficeAddress);
            sqlBuilder.SetValue(BaseStaffEntity.FieldOfficeFax, staffEntity.OfficeFax);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomePhone, staffEntity.HomePhone);
            sqlBuilder.SetValue(BaseStaffEntity.FieldAge, staffEntity.Age);
            sqlBuilder.SetValue(BaseStaffEntity.FieldBirthday, staffEntity.Birthday);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEducation, staffEntity.Education);
            sqlBuilder.SetValue(BaseStaffEntity.FieldSchool, staffEntity.School);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDegree, staffEntity.Degree);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTitleId, staffEntity.TitleId);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTitleDate, staffEntity.TitleDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldTitleLevel, staffEntity.TitleLevel);
            sqlBuilder.SetValue(BaseStaffEntity.FieldWorkingDate, staffEntity.WorkingDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldJoinInDate, staffEntity.JoinInDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomeZipCode, staffEntity.HomeZipCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomeAddress, staffEntity.HomeAddress);
            sqlBuilder.SetValue(BaseStaffEntity.FieldHomeFax, staffEntity.HomeFax);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCarCode, staffEntity.CarCode);            
            sqlBuilder.SetValue(BaseStaffEntity.FieldEmergencyContact, staffEntity.EmergencyContact);            
            sqlBuilder.SetValue(BaseStaffEntity.FieldNativePlace, staffEntity.NativePlace);
            sqlBuilder.SetValue(BaseStaffEntity.FieldParty, staffEntity.Party);
            sqlBuilder.SetValue(BaseStaffEntity.FieldNation, staffEntity.Nation);
            sqlBuilder.SetValue(BaseStaffEntity.FieldNationality, staffEntity.Nationality);
            sqlBuilder.SetValue(BaseStaffEntity.FieldMajor, staffEntity.Major);
            sqlBuilder.SetValue(BaseStaffEntity.FieldWorkingProperty, staffEntity.WorkingProperty);
            sqlBuilder.SetValue(BaseStaffEntity.FieldCompetency, staffEntity.Competency);
            sqlBuilder.SetValue(BaseStaffEntity.FieldIsDimission, staffEntity.IsDimission);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDimissionDate, staffEntity.DimissionDate);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDimissionCause, staffEntity.DimissionCause);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDimissionWhither, staffEntity.DimissionWhither);
            sqlBuilder.SetValue(BaseStaffEntity.FieldEnabled, staffEntity.Enabled);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDeletionStateCode, staffEntity.DeletionStateCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldSortCode, staffEntity.SortCode);
            sqlBuilder.SetValue(BaseStaffEntity.FieldDescription, staffEntity.Description);
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="id">主键</param>
        /// <returns>影响行数</returns>
        public int Delete(int id)
        {
            return this.Delete(new KeyValuePair<string, object>(BaseStaffEntity.FieldId, id));
        }        
    }
}
