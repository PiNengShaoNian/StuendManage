using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getClassInfoList 的摘要说明
    /// </summary>
    public class getClassInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            List<Model.ClassInfo> classList = new List<Model.ClassInfo>();
            BLL.ClassInfo classServer = new BLL.ClassInfo();
            //int pageIndex= int.Parse(context.Request["pageIndex"]);
            //int pageSize = 12;
            //int totalCount = classServer.GetRecordCount(string.Empty);

            //string pagination = CreatePagination.ShowPageNavigate(pageSize,pageIndex,totalCount);
            int count = classServer.GetRecordCount(string.Empty);
            var classDataSet = classServer.GetListByPage(string.Empty, "classID", 1,30);
            //var classDataSet = classServer.GetListByPage(string.Empty,"ClassId",1,20);
            classList =classServer.DataTableToList(classDataSet.Tables[0]);
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(classList);
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