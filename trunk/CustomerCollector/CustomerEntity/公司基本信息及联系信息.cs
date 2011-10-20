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
	/// 公司基本信息及联系信息
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("公司基本信息及联系信息")]
	[BindTable("tb_companyinfo", Description = "公司基本信息及联系信息", ConnName = "CustomerEntity")]
	public partial class tb_companyinfo : Entity<tb_companyinfo>
	{
		#region 属性
		private String _CompanyName;
		/// <summary>
		/// 公司名称
		/// </summary>
		[Description("公司名称")]
		[DataObjectField(true, false, false, 50)]
		[BindColumn("CompanyName", Description = "公司名称", DefaultValue = "", Order = 1)]
		public String CompanyName
		{
			get { return _CompanyName; }
			set { if (OnPropertyChange("CompanyName", value)) _CompanyName = value; }
		}

		private String _UserType;
		/// <summary>
		/// 用户类型
		/// </summary>
		[Description("用户类型")]
		[DataObjectField(false, false, false, 15)]
		[BindColumn("UserType", Description = "用户类型", DefaultValue = "", Order = 2)]
		public String UserType
		{
			get { return _UserType; }
			set { if (OnPropertyChange("UserType", value)) _UserType = value; }
		}

		private String _UserName;
		/// <summary>
		/// 用户名
		/// </summary>
		[Description("用户名")]
		[DataObjectField(false, false, false, 30)]
		[BindColumn("UserName", Description = "用户名", DefaultValue = "", Order = 3)]
		public String UserName
		{
			get { return _UserName; }
			set { if (OnPropertyChange("UserName", value)) _UserName = value; }
		}

		private String _MainProductAndService;
		/// <summary>
		/// 主营产品和服务
		/// </summary>
		[Description("主营产品和服务")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("MainProductAndService", Description = "主营产品和服务", DefaultValue = "", Order = 4)]
		public String MainProductAndService
		{
			get { return _MainProductAndService; }
			set { if (OnPropertyChange("MainProductAndService", value)) _MainProductAndService = value; }
		}

		private String _LinkMan;
		/// <summary>
		/// 联系人
		/// </summary>
		[Description("联系人")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn("LinkMan", Description = "联系人", DefaultValue = "", Order = 5)]
		public String LinkMan
		{
			get { return _LinkMan; }
			set { if (OnPropertyChange("LinkMan", value)) _LinkMan = value; }
		}

		private String _CallName;
		/// <summary>
		/// 称呼
		/// </summary>
		[Description("称呼")]
		[DataObjectField(false, false, true, 6)]
		[BindColumn("CallName", Description = "称呼", DefaultValue = "", Order = 6)]
		public String CallName
		{
			get { return _CallName; }
			set { if (OnPropertyChange("CallName", value)) _CallName = value; }
		}

		private String _Position;
		/// <summary>
		/// 职位
		/// </summary>
		[Description("职位")]
		[DataObjectField(false, false, true, 16)]
		[BindColumn("Position", Description = "职位", DefaultValue = "", Order = 7)]
		public String Position
		{
			get { return _Position; }
			set { if (OnPropertyChange("Position", value)) _Position = value; }
		}

		private String _Tel;
		/// <summary>
		/// 座机电话
		/// </summary>
		[Description("座机电话")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn("Tel", Description = "座机电话", DefaultValue = "", Order = 8)]
		public String Tel
		{
			get { return _Tel; }
			set { if (OnPropertyChange("Tel", value)) _Tel = value; }
		}

		private String _Mobile;
		/// <summary>
		/// 手机号码
		/// </summary>
		[Description("手机号码")]
		[DataObjectField(false, false, true, 80)]
		[BindColumn("Mobile", Description = "手机号码", DefaultValue = "", Order = 9)]
		public String Mobile
		{
			get { return _Mobile; }
			set { if (OnPropertyChange("Mobile", value)) _Mobile = value; }
		}

		private String _Fax;
		/// <summary>
		/// 传真
		/// </summary>
		[Description("传真")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("Fax", Description = "传真", DefaultValue = "", Order = 10)]
		public String Fax
		{
			get { return _Fax; }
			set { if (OnPropertyChange("Fax", value)) _Fax = value; }
		}

		private String _Email;
		/// <summary>
		/// 电子邮箱
		/// </summary>
		[Description("电子邮箱")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("Email", Description = "电子邮箱", DefaultValue = "", Order = 11)]
		public String Email
		{
			get { return _Email; }
			set { if (OnPropertyChange("Email", value)) _Email = value; }
		}

		private String _Address;
		/// <summary>
		/// 地址
		/// </summary>
		[Description("地址")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn("Address", Description = "地址", DefaultValue = "", Order = 12)]
		public String Address
		{
			get { return _Address; }
			set { if (OnPropertyChange("Address", value)) _Address = value; }
		}

		private String _PostalCode;
		/// <summary>
		/// 邮编
		/// </summary>
		[Description("邮编")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("PostalCode", Description = "邮编", DefaultValue = "", Order = 13)]
		public String PostalCode
		{
			get { return _PostalCode; }
			set { if (OnPropertyChange("PostalCode", value)) _PostalCode = value; }
		}

		private String _WebSite;
		/// <summary>
		/// 公司网站
		/// </summary>
		[Description("公司网站")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn("WebSite", Description = "公司网站", DefaultValue = "", Order = 14)]
		public String WebSite
		{
			get { return _WebSite; }
			set { if (OnPropertyChange("WebSite", value)) _WebSite = value; }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, false, 0)]
		[BindColumn("UpdateTime", Description = "更新时间", DefaultValue = "", Order = 15)]
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
		[DataObjectField(false, false, false, 20)]
		[BindColumn("InfoOrigin", Description = "资料来源", DefaultValue = "", Order = 16)]
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
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 17)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChange("Remark", value)) _Remark = value; }
		}

		private String _BusinessModel;
		/// <summary>
		/// 经营模式
		/// </summary>
		[Description("经营模式")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("BusinessModel", Description = "经营模式", DefaultValue = "", Order = 18)]
		public String BusinessModel
		{
			get { return _BusinessModel; }
			set { if (OnPropertyChange("BusinessModel", value)) _BusinessModel = value; }
		}

		private String _SubCategory;
		/// <summary>
		/// 子类目
		/// </summary>
		[Description("子类目")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("SubCategory", Description = "子类目", DefaultValue = "", Order = 19)]
		public String SubCategory
		{
			get { return _SubCategory; }
			set { if (OnPropertyChange("SubCategory", value)) _SubCategory = value; }
		}

		private String _SubIndustry;
		/// <summary>
		/// 子行业
		/// </summary>
		[Description("子行业")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("SubIndustry", Description = "子行业", DefaultValue = "", Order = 20)]
		public String SubIndustry
		{
			get { return _SubIndustry; }
			set { if (OnPropertyChange("SubIndustry", value)) _SubIndustry = value; }
		}

		private String _Industry;
		/// <summary>
		/// 行业
		/// </summary>
		[Description("行业")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn("Industry", Description = "行业", DefaultValue = "", Order = 21)]
		public String Industry
		{
			get { return _Industry; }
			set { if (OnPropertyChange("Industry", value)) _Industry = value; }
		}

		private String _RootClass;
		/// <summary>
		/// 根类别
		/// </summary>
		[Description("根类别")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("RootClass", Description = "根类别", DefaultValue = "", Order = 22)]
		public String RootClass
		{
			get { return _RootClass; }
			set { if (OnPropertyChange("RootClass", value)) _RootClass = value; }
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
					case "CompanyName" : return _CompanyName;
					case "UserType" : return _UserType;
					case "UserName" : return _UserName;
					case "MainProductAndService" : return _MainProductAndService;
					case "LinkMan" : return _LinkMan;
					case "CallName" : return _CallName;
					case "Position" : return _Position;
					case "Tel" : return _Tel;
					case "Mobile" : return _Mobile;
					case "Fax" : return _Fax;
					case "Email" : return _Email;
					case "Address" : return _Address;
					case "PostalCode" : return _PostalCode;
					case "WebSite" : return _WebSite;
					case "UpdateTime" : return _UpdateTime;
					case "InfoOrigin" : return _InfoOrigin;
					case "Remark" : return _Remark;
					case "BusinessModel" : return _BusinessModel;
					case "SubCategory" : return _SubCategory;
					case "SubIndustry" : return _SubIndustry;
					case "Industry" : return _Industry;
					case "RootClass" : return _RootClass;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "CompanyName" : _CompanyName = Convert.ToString(value); break;
					case "UserType" : _UserType = Convert.ToString(value); break;
					case "UserName" : _UserName = Convert.ToString(value); break;
					case "MainProductAndService" : _MainProductAndService = Convert.ToString(value); break;
					case "LinkMan" : _LinkMan = Convert.ToString(value); break;
					case "CallName" : _CallName = Convert.ToString(value); break;
					case "Position" : _Position = Convert.ToString(value); break;
					case "Tel" : _Tel = Convert.ToString(value); break;
					case "Mobile" : _Mobile = Convert.ToString(value); break;
					case "Fax" : _Fax = Convert.ToString(value); break;
					case "Email" : _Email = Convert.ToString(value); break;
					case "Address" : _Address = Convert.ToString(value); break;
					case "PostalCode" : _PostalCode = Convert.ToString(value); break;
					case "WebSite" : _WebSite = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "InfoOrigin" : _InfoOrigin = Convert.ToString(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					case "BusinessModel" : _BusinessModel = Convert.ToString(value); break;
					case "SubCategory" : _SubCategory = Convert.ToString(value); break;
					case "SubIndustry" : _SubIndustry = Convert.ToString(value); break;
					case "Industry" : _Industry = Convert.ToString(value); break;
					case "RootClass" : _RootClass = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得公司基本信息及联系信息字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 公司名称
			///</summary>
			public const String CompanyName = "CompanyName";

			///<summary>
			/// 用户类型
			///</summary>
			public const String UserType = "UserType";

			///<summary>
			/// 用户名
			///</summary>
			public const String UserName = "UserName";

			///<summary>
			/// 主营产品和服务
			///</summary>
			public const String MainProductAndService = "MainProductAndService";

			///<summary>
			/// 联系人
			///</summary>
			public const String LinkMan = "LinkMan";

			///<summary>
			/// 称呼
			///</summary>
			public const String CallName = "CallName";

			///<summary>
			/// 职位
			///</summary>
			public const String Position = "Position";

			///<summary>
			/// 座机电话
			///</summary>
			public const String Tel = "Tel";

			///<summary>
			/// 手机号码
			///</summary>
			public const String Mobile = "Mobile";

			///<summary>
			/// 传真
			///</summary>
			public const String Fax = "Fax";

			///<summary>
			/// 电子邮箱
			///</summary>
			public const String Email = "Email";

			///<summary>
			/// 地址
			///</summary>
			public const String Address = "Address";

			///<summary>
			/// 邮编
			///</summary>
			public const String PostalCode = "PostalCode";

			///<summary>
			/// 公司网站
			///</summary>
			public const String WebSite = "WebSite";

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

			///<summary>
			/// 经营模式
			///</summary>
			public const String BusinessModel = "BusinessModel";

			///<summary>
			/// 子类目
			///</summary>
			public const String SubCategory = "SubCategory";

			///<summary>
			/// 子行业
			///</summary>
			public const String SubIndustry = "SubIndustry";

			///<summary>
			/// 行业
			///</summary>
			public const String Industry = "Industry";

			///<summary>
			/// 根类别
			///</summary>
			public const String RootClass = "RootClass";
		}
		#endregion
	}
}