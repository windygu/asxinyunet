using System;
using System.Data;
using System.Text;
using System.Data.OleDb;
using Maticsoft.DBUtility;//请先添加引用
namespace LotteryTicketData.DAL
{
	/// <summary>
	/// 数据访问类tb_ssq。
	/// </summary>
	public class tb_ssq
	{
		public tb_ssq()
		{}
		#region  成员方法

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(Double 期号)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_ssq");
			strSql.Append(" where 期号=@期号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@期号", OleDbType.Double)};
			parameters[0].Value = 期号;

			return DbHelperOleDb.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(LotteryTicketData.Model.tb_ssq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_ssq(");
			strSql.Append("开奖日期,期号,号码1,号码2,号码3,号码4,号码5,号码6,红球)");
			strSql.Append(" values (");
			strSql.Append("@开奖日期,@期号,@号码1,@号码2,@号码3,@号码4,@号码5,@号码6,@红球)");
			OleDbParameter[] parameters = {
					new OleDbParameter("@开奖日期", OleDbType.Date),
					new OleDbParameter("@期号", OleDbType.Double),
					new OleDbParameter("@号码1", OleDbType.Double),
					new OleDbParameter("@号码2", OleDbType.Double),
					new OleDbParameter("@号码3", OleDbType.Double),
					new OleDbParameter("@号码4", OleDbType.Double),
					new OleDbParameter("@号码5", OleDbType.Double),
					new OleDbParameter("@号码6", OleDbType.Double),
					new OleDbParameter("@红球", OleDbType.Double)};
			parameters[0].Value = model.开奖日期;
			parameters[1].Value = model.期号;
			parameters[2].Value = model.号码1;
			parameters[3].Value = model.号码2;
			parameters[4].Value = model.号码3;
			parameters[5].Value = model.号码4;
			parameters[6].Value = model.号码5;
			parameters[7].Value = model.号码6;
			parameters[8].Value = model.红球;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public void Update(LotteryTicketData.Model.tb_ssq model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_ssq set ");
			strSql.Append("开奖日期=@开奖日期,");
			strSql.Append("期号=@期号,");
			strSql.Append("号码1=@号码1,");
			strSql.Append("号码2=@号码2,");
			strSql.Append("号码3=@号码3,");
			strSql.Append("号码4=@号码4,");
			strSql.Append("号码5=@号码5,");
			strSql.Append("号码6=@号码6,");
			strSql.Append("红球=@红球");
			strSql.Append(" where 期号=@期号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@开奖日期", OleDbType.Date),
					new OleDbParameter("@期号", OleDbType.Double),
					new OleDbParameter("@号码1", OleDbType.Double),
					new OleDbParameter("@号码2", OleDbType.Double),
					new OleDbParameter("@号码3", OleDbType.Double),
					new OleDbParameter("@号码4", OleDbType.Double),
					new OleDbParameter("@号码5", OleDbType.Double),
					new OleDbParameter("@号码6", OleDbType.Double),
					new OleDbParameter("@红球", OleDbType.Double)};
			parameters[0].Value = model.开奖日期;
			parameters[1].Value = model.期号;
			parameters[2].Value = model.号码1;
			parameters[3].Value = model.号码2;
			parameters[4].Value = model.号码3;
			parameters[5].Value = model.号码4;
			parameters[6].Value = model.号码5;
			parameters[7].Value = model.号码6;
			parameters[8].Value = model.红球;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public void Delete(Double 期号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_ssq ");
			strSql.Append(" where 期号=@期号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@期号", OleDbType.Double)};
			parameters[0].Value = 期号;

			DbHelperOleDb.ExecuteSql(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public LotteryTicketData.Model.tb_ssq GetModel(Double 期号)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select 开奖日期,期号,号码1,号码2,号码3,号码4,号码5,号码6,红球 from tb_ssq ");
			strSql.Append(" where 期号=@期号 ");
			OleDbParameter[] parameters = {
					new OleDbParameter("@期号", OleDbType.Double)};
			parameters[0].Value = 期号;

			LotteryTicketData.Model.tb_ssq model=new LotteryTicketData.Model.tb_ssq();
			DataSet ds=DbHelperOleDb.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["开奖日期"].ToString()!="")
				{
					model.开奖日期=DateTime.Parse(ds.Tables[0].Rows[0]["开奖日期"].ToString());
				}
				//model.期号=ds.Tables[0].Rows[0]["期号"].ToString();
				//model.号码1=ds.Tables[0].Rows[0]["号码1"].ToString();
				//model.号码2=ds.Tables[0].Rows[0]["号码2"].ToString();
				//model.号码3=ds.Tables[0].Rows[0]["号码3"].ToString();
				//model.号码4=ds.Tables[0].Rows[0]["号码4"].ToString();
				//model.号码5=ds.Tables[0].Rows[0]["号码5"].ToString();
				//model.号码6=ds.Tables[0].Rows[0]["号码6"].ToString();
				//model.红球=ds.Tables[0].Rows[0]["红球"].ToString();
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
			strSql.Append("select 开奖日期,期号,号码1,号码2,号码3,号码4,号码5,号码6,红球 ");
			strSql.Append(" FROM tb_ssq ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperOleDb.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			OleDbParameter[] parameters = {
					new OleDbParameter("@tblName", OleDbType.VarChar, 255),
					new OleDbParameter("@fldName", OleDbType.VarChar, 255),
					new OleDbParameter("@PageSize", OleDbType.Integer),
					new OleDbParameter("@PageIndex", OleDbType.Integer),
					new OleDbParameter("@IsReCount", OleDbType.Bit),
					new OleDbParameter("@OrderType", OleDbType.Bit),
					new OleDbParameter("@strWhere", OleDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_ssq";
			parameters[1].Value = "ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperOleDb.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  成员方法
	}
}

