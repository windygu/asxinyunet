using System;
namespace GetCustomData.Model
{
	/// <summary>
	/// 实体类tb_thirdtradeclass 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tb_thirdtradeclass
	{
		public tb_thirdtradeclass()
		{}
		#region Model
		private string _id;
		private string _tpyename;
		private string _industryname;
		private string _website;
		private DateTime _updatetime;
		private int _origintype;
		private string _remark;
		/// <summary>
		/// 
		/// </summary>
		public string ID
		{
			set{ _id=value;}
			get{return _id;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string TpyeName
		{
			set{ _tpyename=value;}
			get{return _tpyename;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string IndustryName
		{
			set{ _industryname=value;}
			get{return _industryname;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string WebSite
		{
			set{ _website=value;}
			get{return _website;}
		}
		/// <summary>
		/// 
		/// </summary>
		public DateTime UpdateTime
		{
			set{ _updatetime=value;}
			get{return _updatetime;}
		}
		/// <summary>
		/// 
		/// </summary>
		public int OriginType
		{
			set{ _origintype=value;}
			get{return _origintype;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

