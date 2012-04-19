//-----------------------------------------------------------------
// All Rights Reserved , Copyright (C) 2012 , Hairihan TECH, Ltd .
//-----------------------------------------------------------------

using System;
using System.Data;
using System.Collections.Generic;

namespace DotNet.Business
{
    using DotNet.Utilities;

    /// <summary>
    /// BaseStaffEntity
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
    [Serializable]
    public partial class BaseStaffEntity
    {
        private int? id = null;
        /// <summary>
        /// 主键
        /// </summary>
        public int? Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }

        private int? userId = null;
        /// <summary>
        /// 用户主键
        /// </summary>
        public int? UserId
        {
            get
            {
                return this.userId;
            }
            set
            {
                this.userId = value;
            }
        }

        private string userName = null;
        /// <summary>
        /// 用户名(登录用)
        /// </summary>
        public string UserName
        {
            get
            {
                return this.userName;
            }
            set
            {
                this.userName = value;
            }
        }

        private string realName = null;
        /// <summary>
        /// 姓名
        /// </summary>
        public string RealName
        {
            get
            {
                return this.realName;
            }
            set
            {
                this.realName = value;
            }
        }

        private string code = null;
        /// <summary>
        /// 编号,工号
        /// </summary>
        public string Code
        {
            get
            {
                return this.code;
            }
            set
            {
                this.code = value;
            }
        }

        private string gender = null;
        /// <summary>
        /// 性别
        /// </summary>
        public string Gender
        {
            get
            {
                return this.gender;
            }
            set
            {
                this.gender = value;
            }
        }

        private string companyId = null;
        /// <summary>
        /// 公司代码
        /// </summary>
        public string CompanyId
        {
            get
            {
                return this.companyId;
            }
            set
            {
                this.companyId = value;
            }
        }

        private string departmentId = null;
        /// <summary>
        /// 部门代码
        /// </summary>
        public string DepartmentId
        {
            get
            {
                return this.departmentId;
            }
            set
            {
                this.departmentId = value;
            }
        }

        private string workgroupId = null;
        /// <summary>
        /// 工作组代码
        /// </summary>
        public string WorkgroupId
        {
            get
            {
                return this.workgroupId;
            }
            set
            {
                this.workgroupId = value;
            }
        }

        private string dutyId = null;
        /// <summary>
        /// 职位代码
        /// </summary>
        public string DutyId
        {
            get
            {
                return this.dutyId;
            }
            set
            {
                this.dutyId = value;
            }
        }

        private string identificationCode = null;
        /// <summary>
        /// 唯一身份Id
        /// </summary>
        public string IdentificationCode
        {
            get
            {
                return this.identificationCode;
            }
            set
            {
                this.identificationCode = value;
            }
        }

        private string idCard = null;
        /// <summary>
        /// 身份证号码
        /// </summary>
        public string IdCard
        {
            get
            {
                return this.idCard;
            }
            set
            {
                this.idCard = value;
            }
        }

        private string bankCode = null;
        /// <summary>
        /// 银行卡号
        /// </summary>
        public string BankCode
        {
            get
            {
                return this.bankCode;
            }
            set
            {
                this.bankCode = value;
            }
        }

        private string email = null;
        /// <summary>
        /// 电子邮件
        /// </summary>
        public string Email
        {
            get
            {
                return this.email;
            }
            set
            {
                this.email = value;
            }
        }

        private string mobile = null;
        /// <summary>
        /// 手机
        /// </summary>
        public string Mobile
        {
            get
            {
                return this.mobile;
            }
            set
            {
                this.mobile = value;
            }
        }

        private string shortNumber = null;
        /// <summary>
        /// 短号
        /// </summary>
        public string ShortNumber
        {
            get
            {
                return this.shortNumber;
            }
            set
            {
                this.shortNumber = value;
            }
        }

        private string telephone = null;
        /// <summary>
        /// 电话
        /// </summary>
        public string Telephone
        {
            get
            {
                return this.telephone;
            }
            set
            {
                this.telephone = value;
            }
        }

        private string oICQ = null;
        /// <summary>
        /// QQ号码
        /// </summary>
        public string OICQ
        {
            get
            {
                return this.oICQ;
            }
            set
            {
                this.oICQ = value;
            }
        }

        private string officePhone = null;
        /// <summary>
        /// 办公电话
        /// </summary>
        public string OfficePhone
        {
            get
            {
                return this.officePhone;
            }
            set
            {
                this.officePhone = value;
            }
        }

        private string officeZipCode = null;
        /// <summary>
        /// 办公邮编
        /// </summary>
        public string OfficeZipCode
        {
            get
            {
                return this.officeZipCode;
            }
            set
            {
                this.officeZipCode = value;
            }
        }

        private string officeAddress = null;
        /// <summary>
        /// 办公地址
        /// </summary>
        public string OfficeAddress
        {
            get
            {
                return this.officeAddress;
            }
            set
            {
                this.officeAddress = value;
            }
        }

        private string officeFax = null;
        /// <summary>
        /// 办公传真
        /// </summary>
        public string OfficeFax
        {
            get
            {
                return this.officeFax;
            }
            set
            {
                this.officeFax = value;
            }
        }

        private string homePhone = null;
        /// <summary>
        /// 住宅电话
        /// </summary>
        public string HomePhone
        {
            get
            {
                return this.homePhone;
            }
            set
            {
                this.homePhone = value;
            }
        }

        private string carCode = null;
        /// <summary>
        /// 车牌号
        /// </summary>
        public string CarCode
        {
            get
            {
                return this.carCode;
            }
            set
            {
                this.carCode = value;
            }
        }        

        private string emergencyContact = null;
        /// <summary>
        /// 紧急联系
        /// </summary>
        public string EmergencyContact
        {
            get
            {
                return this.emergencyContact;
            }
            set
            {
                this.emergencyContact = value;
            }
        }        

        private string age = null;
        /// <summary>
        /// 年龄
        /// </summary>
        public string Age
        {
            get
            {
                return this.age;
            }
            set
            {
                this.age = value;
            }
        }

        private string birthday = null;
        /// <summary>
        /// 出生日期
        /// </summary>
        public string Birthday
        {
            get
            {
                return this.birthday;
            }
            set
            {
                this.birthday = value;
            }
        }

        private string education = null;
        /// <summary>
        /// 最高学历
        /// </summary>
        public string Education
        {
            get
            {
                return this.education;
            }
            set
            {
                this.education = value;
            }
        }

        private string school = null;
        /// <summary>
        /// 毕业院校
        /// </summary>
        public string School
        {
            get
            {
                return this.school;
            }
            set
            {
                this.school = value;
            }
        }

        private string degree = null;
        /// <summary>
        /// 最高学位
        /// </summary>
        public string Degree
        {
            get
            {
                return this.degree;
            }
            set
            {
                this.degree = value;
            }
        }

        private string titleId = null;
        /// <summary>
        /// 职称主键
        /// </summary>
        public string TitleId
        {
            get
            {
                return this.titleId;
            }
            set
            {
                this.titleId = value;
            }
        }

        private string titleDate = null;
        /// <summary>
        /// 职称评定日期
        /// </summary>
        public string TitleDate
        {
            get
            {
                return this.titleDate;
            }
            set
            {
                this.titleDate = value;
            }
        }

        private string titleLevel = null;
        /// <summary>
        /// 职称等级
        /// </summary>
        public string TitleLevel
        {
            get
            {
                return this.titleLevel;
            }
            set
            {
                this.titleLevel = value;
            }
        }

        private string workingDate = null;
        /// <summary>
        /// 工作时间
        /// </summary>
        public string WorkingDate
        {
            get
            {
                return this.workingDate;
            }
            set
            {
                this.workingDate = value;
            }
        }

        private string joinInDate = null;
        /// <summary>
        /// 加入本单位时间
        /// </summary>
        public string JoinInDate
        {
            get
            {
                return this.joinInDate;
            }
            set
            {
                this.joinInDate = value;
            }
        }

        private string homeZipCode = null;
        /// <summary>
        /// 家庭住址邮编
        /// </summary>
        public string HomeZipCode
        {
            get
            {
                return this.homeZipCode;
            }
            set
            {
                this.homeZipCode = value;
            }
        }

        private string homeAddress = null;
        /// <summary>
        /// 家庭住址
        /// </summary>
        public string HomeAddress
        {
            get
            {
                return this.homeAddress;
            }
            set
            {
                this.homeAddress = value;
            }
        }

        private string homeFax = null;
        /// <summary>
        /// 家庭传真
        /// </summary>
        public string HomeFax
        {
            get
            {
                return this.homeFax;
            }
            set
            {
                this.homeFax = value;
            }
        }

        private string nativePlace = null;
        /// <summary>
        /// 籍贯
        /// </summary>
        public string NativePlace
        {
            get
            {
                return this.nativePlace;
            }
            set
            {
                this.nativePlace = value;
            }
        }

        private string party = null;
        /// <summary>
        /// 政治面貌
        /// </summary>
        public string Party
        {
            get
            {
                return this.party;
            }
            set
            {
                this.party = value;
            }
        }

        private string nation = null;
        /// <summary>
        /// 国籍
        /// </summary>
        public string Nation
        {
            get
            {
                return this.nation;
            }
            set
            {
                this.nation = value;
            }
        }

        private string nationality = null;
        /// <summary>
        /// 民族
        /// </summary>
        public string Nationality
        {
            get
            {
                return this.nationality;
            }
            set
            {
                this.nationality = value;
            }
        }

        private string major = null;
        /// <summary>
        /// 专业
        /// </summary>
        public string Major
        {
            get
            {
                return this.major;
            }
            set
            {
                this.major = value;
            }
        }

        private string workingProperty = null;
        /// <summary>
        /// 工作性质
        /// </summary>
        public string WorkingProperty
        {
            get
            {
                return this.workingProperty;
            }
            set
            {
                this.workingProperty = value;
            }
        }

        private string competency = null;
        /// <summary>
        /// 职业资格
        /// </summary>
        public string Competency
        {
            get
            {
                return this.competency;
            }
            set
            {
                this.competency = value;
            }
        }

        private int? isDimission = 0;
        /// <summary>
        /// 离职
        /// </summary>
        public int? IsDimission
        {
            get
            {
                return this.isDimission;
            }
            set
            {
                this.isDimission = value;
            }
        }

        private string dimissionDate = null;
        /// <summary>
        /// 离职日期
        /// </summary>
        public string DimissionDate
        {
            get
            {
                return this.dimissionDate;
            }
            set
            {
                this.dimissionDate = value;
            }
        }

        private string dimissionCause = null;
        /// <summary>
        /// 离职原因
        /// </summary>
        public string DimissionCause
        {
            get
            {
                return this.dimissionCause;
            }
            set
            {
                this.dimissionCause = value;
            }
        }

        private string dimissionWhither = null;
        /// <summary>
        /// 离职去向
        /// </summary>
        public string DimissionWhither
        {
            get
            {
                return this.dimissionWhither;
            }
            set
            {
                this.dimissionWhither = value;
            }
        }

        private int? enabled = 0;
        /// <summary>
        /// 有效
        /// </summary>
        public int? Enabled
        {
            get
            {
                return this.enabled;
            }
            set
            {
                this.enabled = value;
            }
        }

        private int? deletionStateCode = 0;
        /// <summary>
        /// 删除标记
        /// </summary>
        public int? DeletionStateCode
        {
            get
            {
                return this.deletionStateCode;
            }
            set
            {
                this.deletionStateCode = value;
            }
        }

        private int? sortCode = 0;
        /// <summary>
        /// 排序码
        /// </summary>
        public int? SortCode
        {
            get
            {
                return this.sortCode;
            }
            set
            {
                this.sortCode = value;
            }
        }

        private string description = null;
        /// <summary>
        /// 描述
        /// </summary>
        public string Description
        {
            get
            {
                return this.description;
            }
            set
            {
                this.description = value;
            }
        }

        private DateTime? createOn = null;
        /// <summary>
        /// 创建日期
        /// </summary>
        public DateTime? CreateOn
        {
            get
            {
                return this.createOn;
            }
            set
            {
                this.createOn = value;
            }
        }

        private string createUserId = null;
        /// <summary>
        /// 创建用户主键
        /// </summary>
        public string CreateUserId
        {
            get
            {
                return this.createUserId;
            }
            set
            {
                this.createUserId = value;
            }
        }

        private string createBy = null;
        /// <summary>
        /// 创建用户
        /// </summary>
        public string CreateBy
        {
            get
            {
                return this.createBy;
            }
            set
            {
                this.createBy = value;
            }
        }

        private DateTime? modifiedOn = null;
        /// <summary>
        /// 修改日期
        /// </summary>
        public DateTime? ModifiedOn
        {
            get
            {
                return this.modifiedOn;
            }
            set
            {
                this.modifiedOn = value;
            }
        }

        private string modifiedUserId = null;
        /// <summary>
        /// 修改用户主键
        /// </summary>
        public string ModifiedUserId
        {
            get
            {
                return this.modifiedUserId;
            }
            set
            {
                this.modifiedUserId = value;
            }
        }

        private string modifiedBy = null;
        /// <summary>
        /// 修改用户
        /// </summary>
        public string ModifiedBy
        {
            get
            {
                return this.modifiedBy;
            }
            set
            {
                this.modifiedBy = value;
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        public BaseStaffEntity()
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseStaffEntity(DataRow dataRow)
        {
            this.GetFrom(dataRow);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseStaffEntity(IDataReader dataReader)
        {
            this.GetFrom(dataReader);
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseStaffEntity(DataTable dataTable)
        {
            this.GetSingle(dataTable);
        }

        /// <summary>
        /// 从数据表读取
        /// </summary>
        /// <param name="dataTable">数据表</param>
        public BaseStaffEntity GetSingle(DataTable dataTable)
        {
            if ((dataTable == null) || (dataTable.Rows.Count == 0))
            {
                return null;
            }
            foreach (DataRow dataRow in dataTable.Rows)
            {
                this.GetFrom(dataRow);
                break;
            }
            return this;
        }

        /// <summary>
        /// 从数据表读取实体列表
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public List<BaseStaffEntity> GetList(DataTable dataTable)
        {
            List<BaseStaffEntity> entites = new List<BaseStaffEntity>();
            foreach (DataRow dataRow in dataTable.Rows)
            {
                entites.Add(GetFrom(dataRow));
            }
            return entites;
        }

        /// <summary>
        /// 从数据行读取
        /// </summary>
        /// <param name="dataRow">数据行</param>
        public BaseStaffEntity GetFrom(DataRow dataRow)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldUserId]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldUserName]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldRealName]);
            this.Code = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCode]);
            this.Gender = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldGender]);
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDepartmentId]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldWorkgroupId]);
            this.DutyId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDutyId]);
            this.IdentificationCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldIdentificationCode]);
            this.IdCard = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldIdCard]);
            this.BankCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldBankCode]);
            this.Email = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldEmail]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldMobile]);
            this.ShortNumber = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldShortNumber]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTelephone]);
            this.OICQ = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOICQ]);
            this.OfficePhone = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficePhone]);
            this.OfficeZipCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficeZipCode]);
            this.OfficeAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficeAddress]);
            this.OfficeFax = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldOfficeFax]);
            this.HomePhone = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomePhone]);
            this.Age = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldAge]);
            this.Birthday = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldBirthday]);
            this.Education = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldEducation]);
            this.School = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldSchool]);
            this.Degree = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDegree]);
            this.TitleId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTitleId]);
            this.TitleDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTitleDate]);
            this.TitleLevel = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldTitleLevel]);
            this.WorkingDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldWorkingDate]);
            this.JoinInDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldJoinInDate]);
            this.HomeZipCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomeZipCode]);
            this.HomeAddress = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomeAddress]);
            this.HomeFax = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldHomeFax]);
            this.CarCode = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCarCode]);
            this.EmergencyContact = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldEmergencyContact]);            
            this.NativePlace = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldNativePlace]);
            this.Party = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldParty]);
            this.Nation = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldNation]);
            this.Nationality = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldNationality]);
            this.Major = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldMajor]);
            this.WorkingProperty = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldWorkingProperty]);
            this.Competency = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCompetency]);
            this.IsDimission = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldIsDimission]);
            this.DimissionDate = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDimissionDate]);
            this.DimissionCause = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDimissionCause]);
            this.DimissionWhither = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDimissionWhither]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataRow[BaseStaffEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseStaffEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataRow[BaseStaffEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataRow[BaseStaffEntity.FieldModifiedBy]);
            return this;
        }

        /// <summary>
        /// 从数据流读取
        /// </summary>
        /// <param name="dataReader">数据流</param>
        public BaseStaffEntity GetFrom(IDataReader dataReader)
        {
            this.Id = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldId]);
            this.UserId = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldUserId]);
            this.UserName = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldUserName]);
            this.RealName = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldRealName]);
            this.Code = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCode]);
            this.Gender = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldGender]);
            this.CompanyId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCompanyId]);
            this.DepartmentId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDepartmentId]);
            this.WorkgroupId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldWorkgroupId]);
            this.DutyId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDutyId]);
            this.IdentificationCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldIdentificationCode]);
            this.IdCard = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldIdCard]);
            this.BankCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldBankCode]);
            this.Email = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldEmail]);
            this.Mobile = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldMobile]);
            this.ShortNumber = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldShortNumber]);
            this.Telephone = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTelephone]);
            this.OICQ = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOICQ]);
            this.OfficePhone = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficePhone]);
            this.OfficeZipCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficeZipCode]);
            this.OfficeAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficeAddress]);
            this.OfficeFax = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldOfficeFax]);
            this.HomePhone = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomePhone]);
            this.Age = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldAge]);
            this.CarCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCarCode]);
            this.Birthday = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldBirthday]);
            this.Education = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldEducation]);
            this.School = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldSchool]);
            this.Degree = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDegree]);
            this.TitleId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTitleId]);
            this.TitleDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTitleDate]);
            this.TitleLevel = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldTitleLevel]);
            this.WorkingDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldWorkingDate]);
            this.JoinInDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldJoinInDate]);
            this.HomeZipCode = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomeZipCode]);
            this.HomeAddress = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomeAddress]);
            this.HomeFax = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldHomeFax]);
            this.NativePlace = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldNativePlace]);
            this.Party = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldParty]);
            this.Nation = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldNation]);
            this.Nationality = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldNationality]);
            this.Major = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldMajor]);
            this.WorkingProperty = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldWorkingProperty]);
            this.Competency = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCompetency]);
            this.IsDimission = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldIsDimission]);
            this.DimissionDate = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDimissionDate]);
            this.DimissionCause = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDimissionCause]);
            this.DimissionWhither = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDimissionWhither]);
            this.Enabled = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldEnabled]);
            this.DeletionStateCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldDeletionStateCode]);
            this.SortCode = BaseBusinessLogic.ConvertToInt(dataReader[BaseStaffEntity.FieldSortCode]);
            this.Description = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldDescription]);
            this.CreateOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseStaffEntity.FieldCreateOn]);
            this.CreateUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCreateUserId]);
            this.CreateBy = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldCreateBy]);
            this.ModifiedOn = BaseBusinessLogic.ConvertToDateTime(dataReader[BaseStaffEntity.FieldModifiedOn]);
            this.ModifiedUserId = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldModifiedUserId]);
            this.ModifiedBy = BaseBusinessLogic.ConvertToString(dataReader[BaseStaffEntity.FieldModifiedBy]);
            return this;
        }
    }
}
