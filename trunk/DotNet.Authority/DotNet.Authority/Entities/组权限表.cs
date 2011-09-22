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
	/// 组权限表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("组权限表")]
	[BindTable("tb_groupauthority", Description = "组权限表", ConnName = "AuthorityConn")]
	public partial class tb_groupauthority : Entity<tb_groupauthority>
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

		private String _GroupName;
		/// <summary>
		/// 组名称
		/// </summary>
		[Description("组名称")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("GroupName", Description = "组名称", DefaultValue = "", Order = 2)]
		public String GroupName
		{
			get { return _GroupName; }
			set { if (OnPropertyChange("GroupName", value)) _GroupName = value; }
		}

		private String _AuthorityID;
		/// <summary>
		/// 权限编号
		/// </summary>
		[Description("权限编号")]
		[DataObjectField(false, false, false, 50)]
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
					case "GroupName" : return _GroupName;
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
					case "GroupName" : _GroupName = Convert.ToString(value); break;
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
		/// 取得组权限表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 组名称
			///</summary>
			public const String GroupName = "GroupName";

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