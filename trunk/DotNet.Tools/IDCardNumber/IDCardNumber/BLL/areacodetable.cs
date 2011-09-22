using System;
using System.Data;
using System.Collections.Generic;
using LTP.Common;
using DotNet.Tools.IDCardNumber.Model;
namespace DotNet.Tools.IDCardNumber.BLL
{
	/// <summary>
	/// ҵ���߼���areacodetable ��ժҪ˵����
	/// </summary>
	public class areacodetable
	{
		private readonly DotNet.Tools.IDCardNumber.DAL.areacodetable dal=new DotNet.Tools.IDCardNumber.DAL.areacodetable();
		public areacodetable()
		{}
		#region  ��Ա����
		/// <summary>
		/// �Ƿ���ڸü�¼
		/// </summary>
		public bool Exists(string AreaCode)
		{
			return dal.Exists(AreaCode);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Add(DotNet.Tools.IDCardNumber.Model.areacodetable model)
		{
			dal.Add(model);
		}

		/// <summary>
		/// ����һ������
		/// </summary>
		public void Update(DotNet.Tools.IDCardNumber.Model.areacodetable model)
		{
			dal.Update(model);
		}

		/// <summary>
		/// ɾ��һ������
		/// </summary>
		public void Delete(string AreaCode)
		{
			
			dal.Delete(AreaCode);
		}

		/// <summary>
		/// �õ�һ������ʵ��
		/// </summary>
		public DotNet.Tools.IDCardNumber.Model.areacodetable GetModel(string AreaCode)
		{
			
			return dal.GetModel(AreaCode);
		}

		/// <summary>
		/// �õ�һ������ʵ�壬�ӻ����С�
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
		/// ��������б�
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// ��������б�
		/// </summary>
		public List<DotNet.Tools.IDCardNumber.Model.areacodetable> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// ��������б�
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
		/// ��������б�
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}

		/// <summary>
		/// ��������б�
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  ��Ա����
	}
}

