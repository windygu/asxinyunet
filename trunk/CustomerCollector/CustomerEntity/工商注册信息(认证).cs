/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-02 15:13:30
 * 版权：KP.NET 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;

namespace CustomerEntity
{
	/// <summary>
	/// 工商注册信息(认证)
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("工商注册信息(认证)")]
	[BindTable("tb_registinfo", Description = "工商注册信息(认证)", ConnName = "CustomerEntity")]
	public partial class tb_registinfo : Entity<tb_registinfo>
	{
		#region 属性
		private String _RegistrationNo;
		/// <summary>
		/// 注册号
		/// </summary>
		[Description("注册号")]
		[DataObjectField(true, false, false, 20)]
		[BindColumn("RegistrationNo", Description = "注册号", DefaultValue = "", Order = 1)]
		public String RegistrationNo
		{
			get { return _RegistrationNo; }
			set { if (OnPropertyChange("RegistrationNo", value)) _RegistrationNo = value; }
		}

		private String _CompanyName;
		/// <summary>
		/// 公司名称
		/// </summary>
		[Description("公司名称")]
		[DataObjectField(false, false, false, 30)]
		[BindColumn("CompanyName", Description = "公司名称", DefaultValue = "", Order = 2)]
		public String CompanyName
		{
			get { return _CompanyName; }
			set { if (OnPropertyChange("CompanyName", value)) _CompanyName = value; }
		}

		private String _Address;
		/// <summary>
		/// 注册地址
		/// </summary>
		[Description("注册地址")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("Address", Description = "注册地址", DefaultValue = "", Order = 3)]
		public String Address
		{
			get { return _Address; }
			set { if (OnPropertyChange("Address", value)) _Address = value; }
		}

		private String _RegisteredCapital;
		/// <summary>
		/// 注册资本
		/// </summary>
		[Description("注册资本")]
		[DataObjectField(false, false, true, 12)]
		[BindColumn("RegisteredCapital", Description = "注册资本", DefaultValue = "", Order = 4)]
		public String RegisteredCapital
		{
			get { return _RegisteredCapital; }
			set { if (OnPropertyChange("RegisteredCapital", value)) _RegisteredCapital = value; }
		}

		private String _YearEstablished;
		/// <summary>
		/// 成立日期
		/// </summary>
		[Description("成立日期")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn("YearEstablished", Description = "成立日期", DefaultValue = "", Order = 5)]
		public String YearEstablished
		{
			get { return _YearEstablished; }
			set { if (OnPropertyChange("YearEstablished", value)) _YearEstablished = value; }
		}

		private String _ManageRange;
		/// <summary>
		/// 经营范围
		/// </summary>
		[Description("经营范围")]
		[DataObjectField(false, false, true, 60)]
		[BindColumn("ManageRange", Description = "经营范围", DefaultValue = "", Order = 6)]
		public String ManageRange
		{
			get { return _ManageRange; }
			set { if (OnPropertyChange("ManageRange", value)) _ManageRange = value; }
		}

		private String _LegalRepresentative;
		/// <summary>
		/// 法定代表人
		/// </summary>
		[Description("法定代表人")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("LegalRepresentative", Description = "法定代表人", DefaultValue = "", Order = 7)]
		public String LegalRepresentative
		{
			get { return _LegalRepresentative; }
			set { if (OnPropertyChange("LegalRepresentative", value)) _LegalRepresentative = value; }
		}

		private String _CompanyType;
		/// <summary>
		/// 企业类型
		/// </summary>
		[Description("企业类型")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("CompanyType", Description = "企业类型", DefaultValue = "", Order = 8)]
		public String CompanyType
		{
			get { return _CompanyType; }
			set { if (OnPropertyChange("CompanyType", value)) _CompanyType = value; }
		}

		private String _ManageTimeLimit;
		/// <summary>
		/// 营业期限
		/// </summary>
		[Description("营业期限")]
		[DataObjectField(false, false, true, 60)]
		[BindColumn("ManageTimeLimit", Description = "营业期限", DefaultValue = "", Order = 9)]
		public String ManageTimeLimit
		{
			get { return _ManageTimeLimit; }
			set { if (OnPropertyChange("ManageTimeLimit", value)) _ManageTimeLimit = value; }
		}

		private String _RegisteredDepartment;
		/// <summary>
		/// 登记机关
		/// </summary>
		[Description("登记机关")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("RegisteredDepartment", Description = "登记机关", DefaultValue = "", Order = 10)]
		public String RegisteredDepartment
		{
			get { return _RegisteredDepartment; }
			set { if (OnPropertyChange("RegisteredDepartment", value)) _RegisteredDepartment = value; }
		}

		private String _AnnualSurveyDate;
		/// <summary>
		/// 年检时间
		/// </summary>
		[Description("年检时间")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("AnnualSurveyDate", Description = "年检时间", DefaultValue = "", Order = 11)]
		public String AnnualSurveyDate
		{
			get { return _AnnualSurveyDate; }
			set { if (OnPropertyChange("AnnualSurveyDate", value)) _AnnualSurveyDate = value; }
		}

		private String _InfoWebSite;
		/// <summary>
		/// 来源网站
		/// </summary>
		[Description("来源网站")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("InfoWebSite", Description = "来源网站", DefaultValue = "", Order = 12)]
		public String InfoWebSite
		{
			get { return _InfoWebSite; }
			set { if (OnPropertyChange("InfoWebSite", value)) _InfoWebSite = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 13)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChange("UpdateTime", value)) _UpdateTime = value; }
		}

		private String _InfoOrigin;
		/// <summary>
		/// 资料来源
		/// </summary>
		[Description("资料来源")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("InfoOrigin", Description = "资料来源", DefaultValue = "", Order = 14)]
		public String InfoOrigin
		{
			get { return _InfoOrigin; }
			set { if (OnPropertyChange("InfoOrigin", value)) _InfoOrigin = value; }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 15)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChange("Remark", value)) _Remark = value; }
		}
		#endregion

		#region 获取/设置 字段值
		/// <summary>
		/// 获取/设置 字段值。
		/// 一个索引，基类使用反射实现。
		/// 派生实体类可重写该索引，以避免反射带来的性能损耗
		/// </summary>
		/// <param name="name">字段名</param>
		/// <returns></returns>
		public override Object this[String name]
		{
			get
			{
				switch (name)
				{
					case "RegistrationNo" : return _RegistrationNo;
					case "CompanyName" : return _CompanyName;
					case "Address" : return _Address;
					case "RegisteredCapital" : return _RegisteredCapital;
					case "YearEstablished" : return _YearEstablished;
					case "ManageRange" : return _ManageRange;
					case "LegalRepresentative" : return _LegalRepresentative;
					case "CompanyType" : return _CompanyType;
					case "ManageTimeLimit" : return _ManageTimeLimit;
					case "RegisteredDepartment" : return _RegisteredDepartment;
					case "AnnualSurveyDate" : return _AnnualSurveyDate;
					case "InfoWebSite" : return _InfoWebSite;
					case "UpdateTime" : return _UpdateTime;
					case "InfoOrigin" : return _InfoOrigin;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "RegistrationNo" : _RegistrationNo = Convert.ToString(value); break;
					case "CompanyName" : _CompanyName = Convert.ToString(value); break;
					case "Address" : _Address = Convert.ToString(value); break;
					case "RegisteredCapital" : _RegisteredCapital = Convert.ToString(value); break;
					case "YearEstablished" : _YearEstablished = Convert.ToString(value); break;
					case "ManageRange" : _ManageRange = Convert.ToString(value); break;
					case "LegalRepresentative" : _LegalRepresentative = Convert.ToString(value); break;
					case "CompanyType" : _CompanyType = Convert.ToString(value); break;
					case "ManageTimeLimit" : _ManageTimeLimit = Convert.ToString(value); break;
					case "RegisteredDepartment" : _RegisteredDepartment = Convert.ToString(value); break;
					case "AnnualSurveyDate" : _AnnualSurveyDate = Convert.ToString(value); break;
					case "InfoWebSite" : _InfoWebSite = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得工商注册信息(认证)字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 注册号
			///</summary>
			public const String RegistrationNo = "RegistrationNo";

			///<summary>
			/// 公司名称
			///</summary>
			public const String CompanyName = "CompanyName";

			///<summary>
			/// 注册地址
			///</summary>
			public const String Address = "Address";

			///<summary>
			/// 注册资本
			///</summary>
			public const String RegisteredCapital = "RegisteredCapital";

			///<summary>
			/// 成立日期
			///</summary>
			public const String YearEstablished = "YearEstablished";

			///<summary>
			/// 经营范围
			///</summary>
			public const String ManageRange = "ManageRange";

			///<summary>
			/// 法定代表人
			///</summary>
			public const String LegalRepresentative = "LegalRepresentative";

			///<summary>
			/// 企业类型
			///</summary>
			public const String CompanyType = "CompanyType";

			///<summary>
			/// 营业期限
			///</summary>
			public const String ManageTimeLimit = "ManageTimeLimit";

			///<summary>
			/// 登记机关
			///</summary>
			public const String RegisteredDepartment = "RegisteredDepartment";

			///<summary>
			/// 年检时间
			///</summary>
			public const String AnnualSurveyDate = "AnnualSurveyDate";

			///<summary>
			/// 来源网站
			///</summary>
			public const String InfoWebSite = "InfoWebSite";

			///<summary>
			/// 更新时间
			///</summary>
			public const String UpdateTime = "UpdateTime";

			///<summary>
			/// 资料来源
			///</summary>
			public const String InfoOrigin = "InfoOrigin";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}