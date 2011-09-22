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
	/// 白土车间检测
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("白土车间检测")]
	[BindTable("tb_bttestdata", Description = "白土车间检测", ConnName = "YoungRunMIS", DbType = DatabaseType.MySql)]
	public partial class tb_bttestdata
	{
		#region 属性
		private String _ID;
		/// <summary>
		/// 数据编号
		/// </summary>
		[Description("数据编号")]
		[DataObjectField(true, false, false, 20)]
		[BindColumn(1, "ID", "数据编号", "", "varchar(20)", 0, 0, false)]
		public String ID
		{
			get { return _ID; }
			set { if (OnPropertyChanging("ID", value)) { _ID = value; OnPropertyChanged("ID"); } }
		}

		private String _ProductName;
		/// <summary>
		/// 产品名称
		/// </summary>
		[Description("产品名称")]
		[DataObjectField(false, false, true, 30)]
		[BindColumn(2, "ProductName", "产品名称", "", "varchar(30)", 0, 0, false)]
		public String ProductName
		{
			get { return _ProductName; }
			set { if (OnPropertyChanging("ProductName", value)) { _ProductName = value; OnPropertyChanged("ProductName"); } }
		}

		private Double _V40;
		/// <summary>
		/// V40
		/// </summary>
		[Description("V40")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(3, "V40", "V40", "", "double", 22, 0, false)]
		public Double V40
		{
			get { return _V40; }
			set { if (OnPropertyChanging("V40", value)) { _V40 = value; OnPropertyChanged("V40"); } }
		}

		private Double _V100;
		/// <summary>
		/// V100
		/// </summary>
		[Description("V100")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(4, "V100", "V100", "", "double", 22, 0, false)]
		public Double V100
		{
			get { return _V100; }
			set { if (OnPropertyChanging("V100", value)) { _V100 = value; OnPropertyChanged("V100"); } }
		}

		private Int32 _VI;
		/// <summary>
		/// 粘度指数
		/// </summary>
		[Description("粘度指数")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(5, "VI", "粘度指数", "", "int(10)", 10, 0, false)]
		public Int32 VI
		{
			get { return _VI; }
			set { if (OnPropertyChanging("VI", value)) { _VI = value; OnPropertyChanged("VI"); } }
		}

		private Double _AV;
		/// <summary>
		/// 酸值
		/// </summary>
		[Description("酸值")]
		[DataObjectField(false, false, true, 22)]
		[BindColumn(6, "AV", "酸值", "", "double", 22, 0, false)]
		public Double AV
		{
			get { return _AV; }
			set { if (OnPropertyChanging("AV", value)) { _AV = value; OnPropertyChanged("AV"); } }
		}

		private String _ASTM;
		/// <summary>
		/// 色度
		/// </summary>
		[Description("色度")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(7, "ASTM", "色度", "", "varchar(20)", 0, 0, false)]
		public String ASTM
		{
			get { return _ASTM; }
			set { if (OnPropertyChanging("ASTM", value)) { _ASTM = value; OnPropertyChanged("ASTM"); } }
		}

		private DateTime _GetSampleTime;
		/// <summary>
		/// 采样时间
		/// </summary>
		[Description("采样时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn(8, "GetSampleTime", "采样时间", "", "datetime", 0, 0, false)]
		public DateTime GetSampleTime
		{
			get { return _GetSampleTime; }
			set { if (OnPropertyChanging("GetSampleTime", value)) { _GetSampleTime = value; OnPropertyChanged("GetSampleTime"); } }
		}

		private String _GetSamLocation;
		/// <summary>
		/// 采样地点
		/// </summary>
		[Description("采样地点")]
		[DataObjectField(false, false, true, 10)]
		[BindColumn(9, "GetSamLocation", "采样地点", "", "varchar(10)", 0, 0, false)]
		public String GetSamLocation
		{
			get { return _GetSamLocation; }
			set { if (OnPropertyChanging("GetSamLocation", value)) { _GetSamLocation = value; OnPropertyChanged("GetSamLocation"); } }
		}

		private String _GetSampPerson;
		/// <summary>
		/// 采样人
		/// </summary>
		[Description("采样人")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(10, "GetSampPerson", "采样人", "", "varchar(20)", 0, 0, false)]
		public String GetSampPerson
		{
			get { return _GetSampPerson; }
			set { if (OnPropertyChanging("GetSampPerson", value)) { _GetSampPerson = value; OnPropertyChanged("GetSampPerson"); } }
		}

		private String _TestPerson;
		/// <summary>
		/// 检测人
		/// </summary>
		[Description("检测人")]
		[DataObjectField(false, false, true, 20)]
		[BindColumn(11, "TestPerson", "检测人", "", "varchar(20)", 0, 0, false)]
		public String TestPerson
		{
			get { return _TestPerson; }
			set { if (OnPropertyChanging("TestPerson", value)) { _TestPerson = value; OnPropertyChanged("TestPerson"); } }
		}

		private DateTime _UpdateTime;
		/// <summary>
		/// 更新时间
		/// </summary>
		[Description("更新时间")]
		[DataObjectField(false, false, true, 0)]
		[BindColumn(12, "UpdateTime", "更新时间", "", "datetime", 0, 0, false)]
		public DateTime UpdateTime
		{
			get { return _UpdateTime; }
			set { if (OnPropertyChanging("UpdateTime", value)) { _UpdateTime = value; OnPropertyChanged("UpdateTime"); } }
		}

		private String _Remark;
		/// <summary>
		/// 备注
		/// </summary>
		[Description("备注")]
		[DataObjectField(false, false, true, 100)]
		[BindColumn(13, "Remark", "备注", "", "varchar(100)", 0, 0, false)]
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
					case "ID" : return _ID;
					case "ProductName" : return _ProductName;
					case "V40" : return _V40;
					case "V100" : return _V100;
					case "VI" : return _VI;
					case "AV" : return _AV;
					case "ASTM" : return _ASTM;
					case "GetSampleTime" : return _GetSampleTime;
					case "GetSamLocation" : return _GetSamLocation;
					case "GetSampPerson" : return _GetSampPerson;
					case "TestPerson" : return _TestPerson;
					case "UpdateTime" : return _UpdateTime;
					case "Remark" : return _Remark;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "ID" : _ID = Convert.ToString(value); break;
					case "ProductName" : _ProductName = Convert.ToString(value); break;
					case "V40" : _V40 = Convert.ToDouble(value); break;
					case "V100" : _V100 = Convert.ToDouble(value); break;
					case "VI" : _VI = Convert.ToInt32(value); break;
					case "AV" : _AV = Convert.ToDouble(value); break;
					case "ASTM" : _ASTM = Convert.ToString(value); break;
					case "GetSampleTime" : _GetSampleTime = Convert.ToDateTime(value); break;
					case "GetSamLocation" : _GetSamLocation = Convert.ToString(value); break;
					case "GetSampPerson" : _GetSampPerson = Convert.ToString(value); break;
					case "TestPerson" : _TestPerson = Convert.ToString(value); break;
					case "UpdateTime" : _UpdateTime = Convert.ToDateTime(value); break;
					case "Remark" : _Remark = Convert.ToString(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得白土车间检测字段名的快捷方式
		/// </summary>
        [CLSCompliant(false)]
		public class _
		{
			///<summary>
			/// 数据编号
			///</summary>
			public const String ID = "ID";

			///<summary>
			/// 产品名称
			///</summary>
			public const String ProductName = "ProductName";

			///<summary>
			/// V40
			///</summary>
			public const String V40 = "V40";

			///<summary>
			/// V100
			///</summary>
			public const String V100 = "V100";

			///<summary>
			/// 粘度指数
			///</summary>
			public const String VI = "VI";

			///<summary>
			/// 酸值
			///</summary>
			public const String AV = "AV";

			///<summary>
			/// 色度
			///</summary>
			public const String ASTM = "ASTM";

			///<summary>
			/// 采样时间
			///</summary>
			public const String GetSampleTime = "GetSampleTime";

			///<summary>
			/// 采样地点
			///</summary>
			public const String GetSamLocation = "GetSamLocation";

			///<summary>
			/// 采样人
			///</summary>
			public const String GetSampPerson = "GetSampPerson";

			///<summary>
			/// 检测人
			///</summary>
			public const String TestPerson = "TestPerson";

			///<summary>
			/// 更新时间
			///</summary>
			public const String UpdateTime = "UpdateTime";

			///<summary>
			/// 备注
			///</summary>
			public const String Remark = "Remark";
		}
		#endregion
	}
}