using System;
namespace GetCustomData.Model
{
	/// <summary>
	/// 实体类tb_username 。(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public class tb_username
	{
		public tb_username()
		{}
		#region Model
		private string _id;
		private string _username;
		private int _origintype;
		private int _isregister;
		private DateTime _updatetime;
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
		public string UserName
		{
			set{ _username=value;}
			get{return _username;}
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
		public int IsRegister
		{
			set{ _isregister=value;}
			get{return _isregister;}
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
		public string Remark
		{
			set{ _remark=value;}
			get{return _remark;}
		}
		#endregion Model

	}
}

