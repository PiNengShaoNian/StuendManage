using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;
using Maticsoft.DBUtility;//Please add references
namespace ScoreManage.DAL
{
	/// <summary>
	/// 数据访问类:StudInfo
	/// </summary>
	public partial class StudInfo
	{
		public StudInfo()
		{}
		#region  BasicMethod

		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string studNo)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from StudInfo");
			strSql.Append(" where studNo=SQL2012studNo ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012studNo", SqlDbType.NVarChar,255)			};
			parameters[0].Value = studNo;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}


		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ScoreManage.Model.StudInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into StudInfo(");
			strSql.Append("studNo,studName,studSex,studBirthDay,classID)");
			strSql.Append(" values (");
			strSql.Append("SQL2012studNo,SQL2012studName,SQL2012studSex,SQL2012studBirthDay,SQL2012classID)");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012studNo", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studName", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studSex", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studBirthDay", SqlDbType.DateTime),
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.studNo;
			parameters[1].Value = model.studName;
			parameters[2].Value = model.studSex;
			parameters[3].Value = model.studBirthDay;
			parameters[4].Value = model.classID;

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
		public bool Update(ScoreManage.Model.StudInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update StudInfo set ");
			strSql.Append("studName=SQL2012studName,");
			strSql.Append("studSex=SQL2012studSex,");
			strSql.Append("studBirthDay=SQL2012studBirthDay,");
			strSql.Append("classID=SQL2012classID");
			strSql.Append(" where studNo=SQL2012studNo ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012studName", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studSex", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studBirthDay", SqlDbType.DateTime),
					new SqlParameter("SQL2012classID", SqlDbType.NVarChar,255),
					new SqlParameter("SQL2012studNo", SqlDbType.NVarChar,255)};
			parameters[0].Value = model.studName;
			parameters[1].Value = model.studSex;
			parameters[2].Value = model.studBirthDay;
			parameters[3].Value = model.classID;
			parameters[4].Value = model.studNo;

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
		public bool Delete(string studNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StudInfo ");
			strSql.Append(" where studNo=SQL2012studNo ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012studNo", SqlDbType.NVarChar,255)			};
			parameters[0].Value = studNo;

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
		public bool DeleteList(string studNolist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from StudInfo ");
			strSql.Append(" where studNo in ("+studNolist + ")  ");
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
		public ScoreManage.Model.StudInfo GetModel(string studNo)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 studNo,studName,studSex,studBirthDay,classID from StudInfo ");
			strSql.Append(" where studNo=SQL2012studNo ");
			SqlParameter[] parameters = {
					new SqlParameter("SQL2012studNo", SqlDbType.NVarChar,255)			};
			parameters[0].Value = studNo;

			ScoreManage.Model.StudInfo model=new ScoreManage.Model.StudInfo();
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
		public ScoreManage.Model.StudInfo DataRowToModel(DataRow row)
		{
			ScoreManage.Model.StudInfo model=new ScoreManage.Model.StudInfo();
			if (row != null)
			{
				if(row["studNo"]!=null)
				{
					model.studNo=row["studNo"].ToString();
				}
				if(row["studName"]!=null)
				{
					model.studName=row["studName"].ToString();
				}
				if(row["studSex"]!=null)
				{
					model.studSex=row["studSex"].ToString();
				}
				if(row["studBirthDay"]!=null && row["studBirthDay"].ToString()!="")
				{
					model.studBirthDay=DateTime.Parse(row["studBirthDay"].ToString());
				}
				if(row["classID"]!=null)
				{
					model.classID=row["classID"].ToString();
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
			strSql.Append("select studNo,studName,studSex,studBirthDay,classID ");
			strSql.Append(" FROM StudInfo ");
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
			strSql.Append(" studNo,studName,studSex,studBirthDay,classID ");
			strSql.Append(" FROM StudInfo ");
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
			strSql.Append("select count(1) FROM StudInfo ");
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
			strSql.Append(")AS Row, T.*  from StudInfo T ");
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
			parameters[0].Value = "StudInfo";
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

