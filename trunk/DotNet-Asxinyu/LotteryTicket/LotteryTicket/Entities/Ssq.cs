/*
 * XCoder v3.4.2011.0329
 * 作者：Administrator/PC2010081511LNR
 * 时间：2011-04-22 11:37:47
 * 版权：版权所有 (C) 新生命开发团队 2010
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using XCode;
using XCode.DataAccessLayer;

namespace LotteryTicket.Entities
{
	/// <summary>
	/// 
	/// </summary>
	[Serializable]
	[DataObject]
	[Description("")]
	[BindTable("tb_ssq", Description = "", ConnName = "LotTick", DbType = DatabaseType.Access)]
	public partial class ssq
	{
		#region 属性
		private DateTime _开奖日期;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 8)]
		[BindColumn(1, "开奖日期", "", "", "DateTime", 0, 0, false)]
		public DateTime 开奖日期
		{
			get { return _开奖日期; }
			set { if (OnPropertyChanging("开奖日期", value)) { _开奖日期 = value; OnPropertyChanged("开奖日期"); } }
		}

		private Double _期号;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(true, false, true, 15)]
		[BindColumn(2, "期号", "", "0", "Double", 15, 0, false)]
		public Double 期号
		{
			get { return _期号; }
			set { if (OnPropertyChanging("期号", value)) { _期号 = value; OnPropertyChanged("期号"); } }
		}

		private Double _号码1;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(3, "号码1", "", "0", "Double", 15, 0, false)]
		public Double 号码1
		{
			get { return _号码1; }
			set { if (OnPropertyChanging("号码1", value)) { _号码1 = value; OnPropertyChanged("号码1"); } }
		}

		private Double _号码2;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(4, "号码2", "", "0", "Double", 15, 0, false)]
		public Double 号码2
		{
			get { return _号码2; }
			set { if (OnPropertyChanging("号码2", value)) { _号码2 = value; OnPropertyChanged("号码2"); } }
		}

		private Double _号码3;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(5, "号码3", "", "0", "Double", 15, 0, false)]
		public Double 号码3
		{
			get { return _号码3; }
			set { if (OnPropertyChanging("号码3", value)) { _号码3 = value; OnPropertyChanged("号码3"); } }
		}

		private Double _号码4;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(6, "号码4", "", "0", "Double", 15, 0, false)]
		public Double 号码4
		{
			get { return _号码4; }
			set { if (OnPropertyChanging("号码4", value)) { _号码4 = value; OnPropertyChanged("号码4"); } }
		}

		private Double _号码5;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(7, "号码5", "", "0", "Double", 15, 0, false)]
		public Double 号码5
		{
			get { return _号码5; }
			set { if (OnPropertyChanging("号码5", value)) { _号码5 = value; OnPropertyChanged("号码5"); } }
		}

		private Double _号码6;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(8, "号码6", "", "0", "Double", 15, 0, false)]
		public Double 号码6
		{
			get { return _号码6; }
			set { if (OnPropertyChanging("号码6", value)) { _号码6 = value; OnPropertyChanged("号码6"); } }
		}

		private Double _红球;
		/// <summary>
		/// 
		/// </summary>
		[Description("")]
		[DataObjectField(false, false, true, 15)]
		[BindColumn(9, "红球", "", "0", "Double", 15, 0, false)]
		public Double 红球
		{
			get { return _红球; }
			set { if (OnPropertyChanging("红球", value)) { _红球 = value; OnPropertyChanged("红球"); } }
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
					case "开奖日期" : return _开奖日期;
					case "期号" : return _期号;
					case "号码1" : return _号码1;
					case "号码2" : return _号码2;
					case "号码3" : return _号码3;
					case "号码4" : return _号码4;
					case "号码5" : return _号码5;
					case "号码6" : return _号码6;
					case "红球" : return _红球;
					default: return base[name];
				}
			}
			set
			{
				switch (name)
				{
					case "开奖日期" : _开奖日期 = Convert.ToDateTime(value); break;
					case "期号" : _期号 = Convert.ToDouble(value); break;
					case "号码1" : _号码1 = Convert.ToDouble(value); break;
					case "号码2" : _号码2 = Convert.ToDouble(value); break;
					case "号码3" : _号码3 = Convert.ToDouble(value); break;
					case "号码4" : _号码4 = Convert.ToDouble(value); break;
					case "号码5" : _号码5 = Convert.ToDouble(value); break;
					case "号码6" : _号码6 = Convert.ToDouble(value); break;
					case "红球" : _红球 = Convert.ToDouble(value); break;
					default: base[name] = value; break;
				}
			}
		}
		#endregion

		#region 字段名
		/// <summary>
		/// 取得字段名的快捷方式
		/// </summary>
        [CLSCompliant(false)]
		public class _
		{
			///<summary>
			/// 
			///</summary>
			public const String 开奖日期 = "开奖日期";

			///<summary>
			/// 
			///</summary>
			public const String 期号 = "期号";

			///<summary>
			/// 
			///</summary>
			public const String 号码1 = "号码1";

			///<summary>
			/// 
			///</summary>
			public const String 号码2 = "号码2";

			///<summary>
			/// 
			///</summary>
			public const String 号码3 = "号码3";

			///<summary>
			/// 
			///</summary>
			public const String 号码4 = "号码4";

			///<summary>
			/// 
			///</summary>
			public const String 号码5 = "号码5";

			///<summary>
			/// 
			///</summary>
			public const String 号码6 = "号码6";

			///<summary>
			/// 
			///</summary>
			public const String 红球 = "红球";
		}
		#endregion
	}
}