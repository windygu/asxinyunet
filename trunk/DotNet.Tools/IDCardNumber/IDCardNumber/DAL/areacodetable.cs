using System;
using System.Data;
using System.Text;
using MySql.Data.MySqlClient;
using Maticsoft.DBUtility;//请先添加引用
namespace DotNet.Tools.IDCardNumber.DAL
{
	/// <summary>
	/// 数据访问类areacodetable。
	/// </summary>
	public class areacodetable
	{
		public areacodetable()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string AreaCode)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from areacodetable");
			strSql.Append(" where AreaCode=@AreaCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AreaCode", MySqlDbType.VarChar)};
			parameters[0].Value = AreaCode;

			return DbHelperMySQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(DotNet.Tools.IDCardNumber.Model.areacodetable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into areacodetable(");
			strSql.Append("FullName,ShortName,AreaCode,UpdateTime)");
			strSql.Append(" values (");
			strSql.Append("@FullName,@ShortName,@AreaCode,@UpdateTime)");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FullName", MySqlDbType.VarChar,60),
					new MySqlParameter("@ShortName", MySqlDbType.VarChar,20),
					new MySqlParameter("@AreaCode", MySqlDbType.VarChar,10),
					new MySqlParameter("@UpdateTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.FullName;
			parameters[1].Value = model.ShortName;
			parameters[2].Value = model.AreaCode;
			parameters[3].Value = model.UpdateTime;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(DotNet.Tools.IDCardNumber.Model.areacodetable model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update areacodetable set ");
			strSql.Append("FullName=@FullName,");
			strSql.Append("ShortName=@ShortName,");
			strSql.Append("UpdateTime=@UpdateTime");
			strSql.Append(" where AreaCode=@AreaCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@FullName", MySqlDbType.VarChar,60),
					new MySqlParameter("@ShortName", MySqlDbType.VarChar,20),
					new MySqlParameter("@AreaCode", MySqlDbType.VarChar,10),
					new MySqlParameter("@UpdateTime", MySqlDbType.DateTime)};
			parameters[0].Value = model.FullName;
			parameters[1].Value = model.ShortName;
			parameters[2].Value = model.AreaCode;
			parameters[3].Value = model.UpdateTime;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(string AreaCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from areacodetable ");
			strSql.Append(" where AreaCode=@AreaCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AreaCode", MySqlDbType.VarChar)};
			parameters[0].Value = AreaCode;

			DbHelperMySQL.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public DotNet.Tools.IDCardNumber.Model.areacodetable GetModel(string AreaCode)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FullName,ShortName,AreaCode,UpdateTime from areacodetable ");
			strSql.Append(" where AreaCode=@AreaCode ");
			MySqlParameter[] parameters = {
					new MySqlParameter("@AreaCode", MySqlDbType.VarChar)};
			parameters[0].Value = AreaCode;

			DotNet.Tools.IDCardNumber.Model.areacodetable model=new DotNet.Tools.IDCardNumber.Model.areacodetable();
			DataSet ds=DbHelperMySQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				model.FullName=ds.Tables[0].Rows[0]["FullName"].ToString();
				model.ShortName=ds.Tables[0].Rows[0]["ShortName"].ToString();
				model.AreaCode=ds.Tables[0].Rows[0]["AreaCode"].ToString();
				if(ds.Tables[0].Rows[0]["UpdateTime"].ToString()!="")
				{
					model.UpdateTime=DateTime.Parse(ds.Tables[0].Rows[0]["UpdateTime"].ToString());
				}
				return model;
			}
			else
			{
				return null;
			}
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select FullName,ShortName,AreaCode,UpdateTime ");
			strSql.Append(" FROM areacodetable ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperMySQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			MySqlParameter[] parameters = {
					new MySqlParameter("@tblName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@fldName", MySqlDbType.VarChar, 255),
					new MySqlParameter("@PageSize", MySqlDbType.Int32),
					new MySqlParameter("@PageIndex", MySqlDbType.Int32),
					new MySqlParameter("@IsReCount", MySqlDbType.Bit),
					new MySqlParameter("@OrderType", MySqlDbType.Bit),
					new MySqlParameter("@strWhere", MySqlDbType.VarChar,1000),
					};
			parameters[0].Value = "areacodetable";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperMySQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

