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
	/// 普通权限表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("普通权限表")]
	[BindTable("tb_popuauthority", Description = "普通权限表", ConnName = "AuthorityConn")]
	public partial class tb_popuauthority : Entity<tb_popuauthority>
	{
		#region 属性
		private UInt32 _ID;
		/// <summary>
		/// 编号
		/// </summary>
		[Description("编号")]
		[DataObjectField(true, true, false, 10)]
		[BindColumn("ID", Description = "编号", DefaultValue = "", Order = 1)]
		public UInt32 ID
		{
			get { return _ID; }
			set { if (OnPropertyChange("ID", value)) _ID = value; }
		}

		private String _UserName;
		/// <summary>
		/// 用户名
		/// </summary>
		[Description("用户名")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("UserName", Description = "用户名", DefaultValue = "", Order = 2)]
		public String UserName
		{
			get { return _UserName; }
			set { if (OnPropertyChange("UserName", value)) _UserName = value; }
		}

		private String _AuthorityID;
		/// <summary>
		/// 权限编号
		/// </summary>
		[Description("权限编号")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("AuthorityID", Description = "权限编号", DefaultValue = "", Order = 3)]
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
		[DataObjectField(false, false, true, 20)]
		[BindColumn("AuthorityName", Description = "权限名称", DefaultValue = "", Order = 4)]
		public String AuthorityName
		{
			get { return _AuthorityName; }
			set { if (OnPropertyChange("AuthorityName", value)) _AuthorityName = value; }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 50)]
		[BindColumn("Remark", Description = "备注", DefaultValue = "", Order = 5)]
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
					case "ID" : return _ID;
					case "UserName" : return _UserName;
					case "AuthorityID" : return _AuthorityID;
					case "AuthorityName" : return _AuthorityName;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "ID" : _ID = Convert.ToUInt32(value); break;
					case "UserName" : _UserName = Convert.ToString(value); break;
					case "AuthorityID" : _AuthorityID = Convert.ToString(value); break;
					case "AuthorityName" : _AuthorityName = Convert.ToString(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得普通权限表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 用户名
			///</summary>
			public const String UserName = "UserName";

			///<summary>
			/// 权限编号
			///</summary>
			public const String AuthorityID = "AuthorityID";

			///<summary>
			/// 权限名称
			///</summary>
			public const String AuthorityName = "AuthorityName";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}