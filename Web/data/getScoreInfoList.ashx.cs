using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getScoreInfoList 的摘要说明
    /// </summary>
    public class getScoreInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            List<Model.StudScoreInfo> scoreList = new List<Model.StudScoreInfo>();
            BLL.StudScoreInfo scoreServer = new BLL.StudScoreInfo();
            int pageSize = 12;
            int pageIndex = int.Parse(context.Request["pageIndex"].ToString());
            int totalCount = scoreServer.GetRecordCount(string.Empty);
            string pagination = CreatePagination.ShowPageNavigate(pageSize, pageIndex, totalCount);
            var scoreDataSet = scoreServer.GetListByPage(string.Empty, string.Empty, (pageIndex-1)*pageSize, pageIndex*pageSize);
            scoreList = scoreServer.DataTableToList(scoreDataSet.Tables[0]);
            var scoreListAndJson = new { studList = scoreList, pagination = pagination };
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(scoreListAndJson);
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