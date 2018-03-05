using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ScoreManage.DAL
{
	/// <summary>
	/// 数据访问类:ClassInfo
	/// </summary>
	public partial class ClassInfo
	{
		public ClassInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string classID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from ClassInfo");
			strSql.Append(" where classID=SQL2012classID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255)			};
			parameters[0].Value = classID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ScoreManage.Model.ClassInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into ClassInfo(");
			strSql.Append("classID,className,classDesc)");
			strSql.Append(" values (");
			strSql.Append("SQL2012classID,SQL2012className,SQL2012classDesc)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012className", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012classDesc", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.classID;
			parameters[1].Value = model.className;
			parameters[2].Value = model.classDesc;

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
		public bool Update(ScoreManage.Model.ClassInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update ClassInfo set ");
			strSql.Append("className=SQL2012className,");
			strSql.Append("classDesc=SQL2012classDesc");
			strSql.Append(" where classID=SQL2012classID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012className", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012classDesc", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.className;
			parameters[1].Value = model.classDesc;
			parameters[2].Value = model.classID;

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
		public bool Delete(string classID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClassInfo ");
			strSql.Append(" where classID=SQL2012classID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255)			};
			parameters[0].Value = classID;

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
		public bool DeleteList(string classIDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from ClassInfo ");
			strSql.Append(" where classID in ("+classIDlist + ")  ");
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
		public ScoreManage.Model.ClassInfo GetModel(string classID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 classID,className,classDesc from ClassInfo ");
			strSql.Append(" where classID=SQL2012classID ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255)			};
			parameters[0].Value = classID;

			ScoreManage.Model.ClassInfo model=new ScoreManage.Model.ClassInfo();
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
		public ScoreManage.Model.ClassInfo DataRowToModel(DataRow row)
		{
			ScoreManage.Model.ClassInfo model=new ScoreManage.Model.ClassInfo();
			if (row != null)
			{
				if(row["classID"]!=null)
				{
					model.classID=row["classID"].ToString();
				}
				if(row["className"]!=null)
				{
					model.className=row["className"].ToString();
				}
				if(row["classDesc"]!=null)
				{
					model.classDesc=row["classDesc"].ToString();
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
			strSql.Append("select classID,className,classDesc ");
			strSql.Append(" FROM ClassInfo ");
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
			strSql.Append(" classID,className,classDesc ");
			strSql.Append(" FROM ClassInfo ");
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
			strSql.Append("select count(1) FROM ClassInfo ");
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
				strSql.Append("order by T.classID desc");
			}
			strSql.Append(")AS Row, T.*  from ClassInfo T ");
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
			parameters[0].Value = "ClassInfo";
			parameters[1].Value = "classID";
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

