using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DotNet.Tools.IDCardNumber.Model;
namespace DotNet.Tools.IDCardNumber.BLL
{
	/// <summary>
	/// 业务逻辑类areacodetable 的摘要说明。
	/// </summary>
	public class areacodetable
	{
		private readonly DotNet.Tools.IDCardNumber.DAL.areacodetable dal=new DotNet.Tools.IDCardNumber.DAL.areacodetable();
		public areacodetable()
		{}
		#region  成员方法
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AreaCode)
		{
			return dal.Exists(AreaCode);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DotNet.Tools.IDCardNumber.Model.areacodetable model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DotNet.Tools.IDCardNumber.Model.areacodetable model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string AreaCode)
		{
			
			dal.Delete(AreaCode);
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DotNet.Tools.IDCardNumber.Model.areacodetable GetModel(string AreaCode)
		{
			
			return dal.GetModel(AreaCode);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中。
		/// </summary>
		public DotNet.Tools.IDCardNumber.Model.areacodetable GetModelByCache(string AreaCode)
		{
			
			string CacheKey = "areacodetableModel-" + AreaCode;
			object objModel = LTP.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(AreaCode);
					if (objModel != null)
					{
						int ModelCache = LTP.Common.ConfigHelper.GetConfigInt("ModelCache");
						LTP.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (DotNet.Tools.IDCardNumber.Model.areacodetable)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DotNet.Tools.IDCardNumber.Model.areacodetable> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<DotNet.Tools.IDCardNumber.Model.areacodetable> DataTableToList(DataTable dt)
		{
			List<DotNet.Tools.IDCardNumber.Model.areacodetable> modelList = new List<DotNet.Tools.IDCardNumber.Model.areacodetable>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				DotNet.Tools.IDCardNumber.Model.areacodetable model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new DotNet.Tools.IDCardNumber.Model.areacodetable();
					model.FullName=dt.Rows[n]["FullName"].ToString();
					model.ShortName=dt.Rows[n]["ShortName"].ToString();
					model.AreaCode=dt.Rows[n]["AreaCode"].ToString();
					if(dt.Rows[n]["UpdateTime"].ToString()!="")
					{
						model.UpdateTime=DateTime.Parse(dt.Rows[n]["UpdateTime"].ToString());
					}
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  成员方法
	}
}

