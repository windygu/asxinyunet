/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-21 21:42:29
 * 版权：KP.NET 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;

namespace DotNet.Authority
{
	/// <summary>
	/// 用户信息
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("用户信息")]
	[BindTable("tb_userinfo", Description = "用户信息", ConnName = "AuthorityConn")]
	public partial class tb_userinfo : Entity<tb_userinfo>
	{
		#region 属性
		private String _UserName;
		/// <summary>
		/// 用户名
		/// </summary>
		[Description("用户名")]
		[DataObjectField(true, false, false, 20)]
		[BindColumn("UserName", Description = "用户名", DefaultValue = "", Order = 1)]
		public String UserName
		{
			get { return _UserName; }
			set { if (OnPropertyChange("UserName", value)) _UserName = value; }
		}

		private String _Name;
		/// <summary>
		/// 姓名
		/// </summary>
		[Description("姓名")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("Name", Description = "姓名", DefaultValue = "", Order = 2)]
		public String Name
		{
			get { return _Name; }
			set { if (OnPropertyChange("Name", value)) _Name = value; }
		}

		private String _Sex;
		/// <summary>
		/// 性别
		/// </summary>
		[Description("性别")]
		[DataObjectField(false, false, true, 4)]
		[BindColumn("Sex", Description = "性别", DefaultValue = "", Order = 3)]
		public String Sex
		{
			get { return _Sex; }
			set { if (OnPropertyChange("Sex", value)) _Sex = value; }
		}

		private String _Department;
		/// <summary>
		/// 部门
		/// </summary>
		[Description("部门")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("Department", Description = "部门", DefaultValue = "", Order = 4)]
		public String Department
		{
			get { return _Department; }
			set { if (OnPropertyChange("Department", value)) _Department = value; }
		}

		private String _Job;
		/// <summary>
		/// 职务
		/// </summary>
		[Description("职务")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn("Job", Description = "职务", DefaultValue = "", Order = 5)]
		public String Job
		{
			get { return _Job; }
			set { if (OnPropertyChange("Job", value)) _Job = value; }
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
					case "UserName" : return _UserName;
					case "Name" : return _Name;
					case "Sex" : return _Sex;
					case "Department" : return _Department;
					case "Job" : return _Job;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "UserName" : _UserName = Convert.ToString(value); break;
					case "Name" : _Name = Convert.ToString(value); break;
					case "Sex" : _Sex = Convert.ToString(value); break;
					case "Department" : _Department = Convert.ToString(value); break;
					case "Job" : _Job = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得用户信息字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 用户名
			///</summary>
			public const String UserName = "UserName";

			///<summary>
			/// 姓名
			///</summary>
			public const String Name = "Name";

			///<summary>
			/// 性别
			///</summary>
			public const String Sex = "Sex";

			///<summary>
			/// 部门
			///</summary>
			public const String Department = "Department";

			///<summary>
			/// 职务
			///</summary>
			public const String Job = "Job";
		}
		#endregion
	}
}