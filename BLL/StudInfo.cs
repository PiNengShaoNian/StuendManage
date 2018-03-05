using System;
using System.Data;
using System.Collections.Generic;
using Maticsoft.Common;
using ScoreManage.Model;
namespace ScoreManage.BLL
{
	/// <summary>
	/// StudInfo
	/// </summary>
	public partial class StudInfo
	{
		private readonly ScoreManage.DAL.StudInfo dal=new ScoreManage.DAL.StudInfo();
		public StudInfo()
		{}
		#region  BasicMethod
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string studNo)
		{
			return dal.Exists(studNo);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public bool Add(ScoreManage.Model.StudInfo model)
		{
			return dal.Add(model);
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(ScoreManage.Model.StudInfo model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string studNo)
		{
			
			return dal.Delete(studNo);
		}
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool DeleteList(string studNolist )
		{
			return dal.DeleteList(studNolist );
		}

		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public ScoreManage.Model.StudInfo GetModel(string studNo)
		{
			
			return dal.GetModel(studNo);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public ScoreManage.Model.StudInfo GetModelByCache(string studNo)
		{
			
			string CacheKey = "StudInfoModel-" + studNo;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(studNo);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (ScoreManage.Model.StudInfo)objModel;
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
		public List<ScoreManage.Model.StudInfo> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<ScoreManage.Model.StudInfo> DataTableToList(DataTable dt)
		{
			List<ScoreManage.Model.StudInfo> modelList = new List<ScoreManage.Model.StudInfo>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				ScoreManage.Model.StudInfo model;
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

