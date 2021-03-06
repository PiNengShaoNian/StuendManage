﻿using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ScoreManage.Model;
namespace ScoreManage.BLL
{
	/// <summary>
	/// CourseInfo
	/// </summary>
	public partial class CourseInfo
	{
		private readonly ScoreManage.DAL.CourseInfo dal=new ScoreManage.DAL.CourseInfo();
		public CourseInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string courseID)
		{
			return dal.Exists(courseID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ScoreManage.Model.CourseInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ScoreManage.Model.CourseInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string courseID)
		{
			
			return dal.Delete(courseID);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string courseIDlist )
		{
			return dal.DeleteList(courseIDlist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScoreManage.Model.CourseInfo GetModel(string courseID)
		{
			
			return dal.GetModel(courseID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ScoreManage.Model.CourseInfo GetModelByCache(string courseID)
		{
			
			string CacheKey = "CourseInfoModel-" + courseID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(courseID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ScoreManage.Model.CourseInfo)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ScoreManage.Model.CourseInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ScoreManage.Model.CourseInfo> DataTableToList(DataTable dt)
		{
			List<ScoreManage.Model.CourseInfo> modelList = new List<ScoreManage.Model.CourseInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ScoreManage.Model.CourseInfo model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = dal.DataRowToModel(dt.Rows[n]);
					if (model != null)
					{
						modelList.Add(model);
					}
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
		/// 分页获取数据列表
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			return dal.GetRecordCount(strWhere);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			return dal.GetListByPage( strWhere,  orderby,  startIndex,  endIndex);
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		//public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		//{
			//return dal.GetList(PageSize,PageIndex,strWhere);
		//}

		#endregion  BasicMethod
		#region  ExtensionMethod

		#endregion  ExtensionMethod
	}
}

