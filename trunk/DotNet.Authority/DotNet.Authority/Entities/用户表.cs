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
	/// 用户表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("用户表")]
	[BindTable("tb_user", Description = "用户表", ConnName = "AuthorityConn")]
	public partial class tb_user : Entity<tb_user>
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

		private String _PassWord;
		/// <summary>
		/// 密码
		/// </summary>
		[Description("密码")]
		[DataObjectField(false, false, false, 30)]
		[BindColumn("PassWord", Description = "密码", DefaultValue = "", Order = 2)]
		public String PassWord
		{
			get { return _PassWord; }
			set { if (OnPropertyChange("PassWord", value)) _PassWord = value; }
		}

		private String _GroupName;
		/// <summary>
		/// 用户组
		/// </summary>
		[Description("用户组")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn("GroupName", Description = "用户组", DefaultValue = "", Order = 3)]
		public String GroupName
		{
			get { return _GroupName; }
			set { if (OnPropertyChange("GroupName", value)) _GroupName = value; }
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
					case "PassWord" : return _PassWord;
					case "GroupName" : return _GroupName;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "UserName" : _UserName = Convert.ToString(value); break;
					case "PassWord" : _PassWord = Convert.ToString(value); break;
					case "GroupName" : _GroupName = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得用户表字段名的快捷方式
		/// </summary>
		public class _
		{
			///<summary>
			/// 用户名
			///</summary>
			public const String UserName = "UserName";

			///<summary>
			/// 密码
			///</summary>
			public const String PassWord = "PassWord";

			///<summary>
			/// 用户组
			///</summary>
			public const String GroupName = "GroupName";
		}
		#endregion
	}
}