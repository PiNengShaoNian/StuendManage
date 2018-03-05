using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ScoreManage.DAL
{
	/// <summary>
	/// 数据访问类:StudScoreInfo
	/// </summary>
	public partial class StudScoreInfo
	{
		public StudScoreInfo()
		{}
		#region  BasicMethod



		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ScoreManage.Model.StudScoreInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StudScoreInfo(");
			strSql.Append("studNo,courseID,studScore)");
			strSql.Append(" values (");
			strSql.Append("@SQL2012studNo,@SQL2012courseID,@SQL2012studScore)");
			SqlParameter[] parameters = {
					new SqlParameter("@SQL2012studNo", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseID", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012studScore", SqlDbType.Float,8)};
			parameters[0].Value = model.studNo;
			parameters[1].Value = model.courseID;
			parameters[2].Value = model.studScore;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ScoreManage.Model.StudScoreInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StudScoreInfo set ");
			strSql.Append("studNo=SQL2012studNo,");
			strSql.Append("courseID=SQL2012courseID,");
			strSql.Append("studScore=SQL2012studScore");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012studNo", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012courseID", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studScore", SqlDbType.Float,8)};
			parameters[0].Value = model.studNo;
			parameters[1].Value = model.courseID;
			parameters[2].Value = model.studScore;

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StudScoreInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScoreManage.Model.StudScoreInfo GetModel()
		{
			//该表无主键信息，请自定义主键/条件字段
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 studNo,courseID,studScore from StudScoreInfo ");
			strSql.Append(" where ");
			SqlParameter[] parameters = {
			};

			ScoreManage.Model.StudScoreInfo model=new ScoreManage.Model.StudScoreInfo();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				return DataRowToModel(ds.Tables[0].Rows[0]);
			}
			else
			{
				return null;
			}
		}


		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScoreManage.Model.StudScoreInfo DataRowToModel(DataRow row)
		{
			ScoreManage.Model.StudScoreInfo model=new ScoreManage.Model.StudScoreInfo();
			if (row != null)
			{
				if(row["studNo"]!=null)
				{
					model.studNo=row["studNo"].ToString();
				}
				if(row["courseID"]!=null)
				{
					model.courseID=row["courseID"].ToString();
				}
				if(row["studScore"]!=null && row["studScore"].ToString()!="")
				{
					model.studScore=decimal.Parse(row["studScore"].ToString());
				}
			}
			return model;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select studNo,courseID,studScore ");
			strSql.Append(" FROM StudScoreInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" studNo,courseID,studScore ");
			strSql.Append(" FROM StudScoreInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM StudScoreInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = DbHelperSQL.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.studNo desc");
			}
			strSql.Append(")AS Row, T.*  from StudScoreInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return DbHelperSQL.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012tblName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012fldName", SqlDbType.VarChar, 255),
					new SqlParameter("SQL2012PageSize", SqlDbType.Int),
					new SqlParameter("SQL2012PageIndex", SqlDbType.Int),
					new SqlParameter("SQL2012IsReCount", SqlDbType.Bit),
					new SqlParameter("SQL2012OrderType", SqlDbType.Bit),
					new SqlParameter("SQL2012strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "StudScoreInfo";
			parameters[1].Value = "studNo";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return DbHelperSQL.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

