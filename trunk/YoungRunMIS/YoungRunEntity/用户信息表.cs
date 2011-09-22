/*
 * XCoder v3.4.2011.0329
 * 作者：asxinyu
 * 时间：2011-09-20 15:58:06
 * 版权：YoungRun
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.DataAccessLayer;

namespace YoungRunEntity
{
	/// <summary>
	/// 用户信息表
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("用户信息表")]
	[BindTable("tb_user", Description = "用户信息表", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
	public partial class tb_user
	{
		#region 属性
		private String _UserName;
		/// <summary>
		/// 用户名
		/// </summary>
		[Description("用户名")]
		[DataObjectField(true, false, false, 20)]
		[BindColumn(1, "UserName", "用户名", "", "varchar(20)", 0, 0, false)]
		public String UserName
		{
			get { return _UserName; }
			set { if (OnPropertyChanging("UserName", value)) { _UserName = value; OnPropertyChanged("UserName"); } }
		}

		private String _PassWord;
		/// <summary>
		/// 密码
		/// </summary>
		[Description("密码")]
		[DataObjectField(false, false, false, 60)]
		[BindColumn(2, "PassWord", "密码", "", "varchar(60)", 0, 0, false)]
		public String PassWord
		{
			get { return _PassWord; }
			set { if (OnPropertyChanging("PassWord", value)) { _PassWord = value; OnPropertyChanged("PassWord"); } }
		}

		private String _DepartMent;
		/// <summary>
		/// 部门
		/// </summary>
		[Description("部门")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn(3, "DepartMent", "部门", "", "varchar(20)", 0, 0, false)]
		public String DepartMent
		{
			get { return _DepartMent; }
			set { if (OnPropertyChanging("DepartMent", value)) { _DepartMent = value; OnPropertyChanged("DepartMent"); } }
		}

		private String _Name;
		/// <summary>
		/// 姓名
		/// </summary>
		[Description("姓名")]
		[DataObjectField(false, false, false, 20)]
		[BindColumn(4, "Name", "姓名", "", "varchar(20)", 0, 0, false)]
		public String Name
		{
			get { return _Name; }
			set { if (OnPropertyChanging("Name", value)) { _Name = value; OnPropertyChanged("Name"); } }
		}

		private String _Tel;
		/// <summary>
		/// 联系电话
		/// </summary>
		[Description("联系电话")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn(5, "Tel", "联系电话", "", "varchar(30)", 0, 0, false)]
		public String Tel
		{
			get { return _Tel; }
			set { if (OnPropertyChanging("Tel", value)) { _Tel = value; OnPropertyChanged("Tel"); } }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 65535)]
		[BindColumn(6, "Remark", "备注", "", "text", 0, 0, false)]
		public String Remark
		{
			get { return _Remark; }
			set { if (OnPropertyChanging("Remark", value)) { _Remark = value; OnPropertyChanged("Remark"); } }
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
					case "DepartMent" : return _DepartMent;
					case "Name" : return _Name;
					case "Tel" : return _Tel;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "UserName" : _UserName = Convert.ToString(value); break;
					case "PassWord" : _PassWord = Convert.ToString(value); break;
					case "DepartMent" : _DepartMent = Convert.ToString(value); break;
					case "Name" : _Name = Convert.ToString(value); break;
					case "Tel" : _Tel = Convert.ToString(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得用户信息表字段名的快捷方式
		/// </summary>
        [CLSCompliant(false)]
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
			/// 部门
			///</summary>
			public const String DepartMent = "DepartMent";

			///<summary>
			/// 姓名
			///</summary>
			public const String Name = "Name";

			///<summary>
			/// 联系电话
			///</summary>
			public const String Tel = "Tel";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}