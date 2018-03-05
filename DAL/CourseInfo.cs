using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ScoreManage.DAL
{
	/// <summary>
	/// 数据访问类:CourseInfo
	/// </summary>
	public partial class CourseInfo
	{
		public CourseInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string courseID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from CourseInfo");
			strSql.Append(" where courseID=SQL2012courseID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012courseID", SqlDbType.NVarChar,255)			};
			parameters[0].Value = courseID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ScoreManage.Model.CourseInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into CourseInfo(");
			strSql.Append("courseID,courseName,courseType,courseCredit,courseDesc)");
			strSql.Append(" values (");
			strSql.Append("@SQL2012courseID,@SQL2012courseName,@SQL2012courseType,@SQL2012courseCredit,@SQL2012courseDesc)");
			SqlParameter[] parameters = {
					new SqlParameter("@SQL2012courseID", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseName", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseType", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseCredit", SqlDbType.Float,8),
					new SqlParameter("@SQL2012courseDesc", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.courseID;
			parameters[1].Value = model.courseName;
			parameters[2].Value = model.courseType;
			parameters[3].Value = model.courseCredit;
			parameters[4].Value = model.courseDesc;

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
		public bool Update(ScoreManage.Model.CourseInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update CourseInfo set ");
			strSql.Append("courseName=@SQL2012courseName,");
			strSql.Append("courseType=@SQL2012courseType,");
			strSql.Append("courseCredit=@SQL2012courseCredit,");
			strSql.Append("courseDesc=@SQL2012courseDesc");
			strSql.Append(" where courseID=@SQL2012courseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SQL2012courseName", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseType", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseCredit", SqlDbType.Float,8),
					new SqlParameter("@SQL2012courseDesc", SqlDbType.NVarChar,255),
					new SqlParameter("@SQL2012courseID", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.courseName;
			parameters[1].Value = model.courseType;
			parameters[2].Value = model.courseCredit;
			parameters[3].Value = model.courseDesc;
			parameters[4].Value = model.courseID;

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
		public bool Delete(string courseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseInfo ");
			strSql.Append(" where courseID=@SQL2012courseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SQL2012courseID", SqlDbType.NVarChar,255)			};
			parameters[0].Value = courseID;

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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string courseIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from CourseInfo ");
			strSql.Append(" where courseID in ("+courseIDlist + ")  ");
			int rows=DbHelperSQL.ExecuteSql(strSql.ToString());
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
		public ScoreManage.Model.CourseInfo GetModel(string courseID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 courseID,courseName,courseType,courseCredit,courseDesc from CourseInfo ");
			strSql.Append(" where courseID=@SQL2012courseID ");
			SqlParameter[] parameters = {
					new SqlParameter("@SQL2012courseID", SqlDbType.NVarChar,255)			};
			parameters[0].Value = courseID;

			ScoreManage.Model.CourseInfo model=new ScoreManage.Model.CourseInfo();
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
		public ScoreManage.Model.CourseInfo DataRowToModel(DataRow row)
		{
			ScoreManage.Model.CourseInfo model=new ScoreManage.Model.CourseInfo();
			if (row != null)
			{
				if(row["courseID"]!=null)
				{
					model.courseID=row["courseID"].ToString();
				}
				if(row["courseName"]!=null)
				{
					model.courseName=row["courseName"].ToString();
				}
				if(row["courseType"]!=null)
				{
					model.courseType=row["courseType"].ToString();
				}
				if(row["courseCredit"]!=null && row["courseCredit"].ToString()!="")
				{
					model.courseCredit=decimal.Parse(row["courseCredit"].ToString());
				}
				if(row["courseDesc"]!=null)
				{
					model.courseDesc=row["courseDesc"].ToString();
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
			strSql.Append("select courseID,courseName,courseType,courseCredit,courseDesc ");
			strSql.Append(" FROM CourseInfo ");
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
			strSql.Append(" courseID,courseName,courseType,courseCredit,courseDesc ");
			strSql.Append(" FROM CourseInfo ");
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
			strSql.Append("select count(1) FROM CourseInfo ");
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
				strSql.Append("order by T.courseID desc");
			}
			strSql.Append(")AS Row, T.*  from CourseInfo T ");
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
			parameters[0].Value = "CourseInfo";
			parameters[1].Value = "courseID";
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

