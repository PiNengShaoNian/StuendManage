using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using ScoreManage.Model;
using ScoreManage.BLL;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getStudInfoList 的摘要说明
    /// </summary>
    public class getStudInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            List<Model.StudInfo> studList = new List<Model.StudInfo>();
            BLL.StudInfo sutdServer = new BLL.StudInfo();

            int pageIndex= int.Parse(context.Request["pageIndex"]);
            int pageSize = 12;
            int totalCount = sutdServer.GetRecordCount(string.Empty);

            string pagination = CreatePagination.ShowPageNavigate(pageSize,pageIndex,totalCount);
            studList = sutdServer.GetModelList(string.Empty);
            int count = sutdServer.GetRecordCount(string.Empty);
            var studDataSet = sutdServer.GetListByPage(string.Empty, "studNo", (pageIndex - 1) * pageSize, pageIndex * pageSize);
            studList = sutdServer.DataTableToList(studDataSet.Tables[0]);
            var paginationAndJson = new { studList = studList, pagination = pagination };
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(paginationAndJson);
            context.Response.Write(json);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}