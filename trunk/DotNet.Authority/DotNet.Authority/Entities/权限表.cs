/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-21 21:42:28
 * 版权：KP.NET 2011
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;

namespace DotNet.Authority
{
	/// <summary>
	/// 权限表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("权限表")]
	[BindTable("tb_authoritylist", Description = "权限表", ConnName = "AuthorityConn")]
	public partial class tb_authoritylist : Entity<tb_authoritylist>
	{
		#region 属性
		private String _AuthorityID;
		/// <summary>
		/// 权限编号
		/// </summary>
		[Description("权限编号")]
		[DataObjectField(true, false, false, 50)]
		[BindColumn("AuthorityID", Description = "权限编号", DefaultValue = "", Order = 1)]
		public String AuthorityID
		{
			get { return _AuthorityID; }
			set { if (OnPropertyChange("AuthorityID", value)) _AuthorityID = value; }
		}

		private String _AuthorityName;
		/// <summary>
		/// 权限名称
		/// </summary>
		[Description("权限名称")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("AuthorityName", Description = "权限名称", DefaultValue = "", Order = 2)]
		public String AuthorityName
		{
			get { return _AuthorityName; }
			set { if (OnPropertyChange("AuthorityName", value)) _AuthorityName = value; }
		}

		private String _AuthorityIntro;
		/// <summary>
		/// 权限介绍
		/// </summary>
		[Description("权限介绍")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn("AuthorityIntro", Description = "权限介绍", DefaultValue = "", Order = 3)]
		public String AuthorityIntro
		{
			get { return _AuthorityIntro; }
			set { if (OnPropertyChange("AuthorityIntro", value)) _AuthorityIntro = value; }
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
					case "AuthorityID" : return _AuthorityID;
					case "AuthorityName" : return _AuthorityName;
					case "AuthorityIntro" : return _AuthorityIntro;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "AuthorityID" : _AuthorityID = Convert.ToString(value); break;
					case "AuthorityName" : _AuthorityName = Convert.ToString(value); break;
					case "AuthorityIntro" : _AuthorityIntro = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得权限表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 权限编号
			///</summary>
			public const String AuthorityID = "AuthorityID";

			///<summary>
			/// 权限名称
			///</summary>
			public const String AuthorityName = "AuthorityName";

			///<summary>
			/// 权限介绍
			///</summary>
			public const String AuthorityIntro = "AuthorityIntro";
		}
		#endregion
	}
}