using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getCourseInfoList 的摘要说明
    /// </summary>
    public class getCourseInfoList : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            BLL.CourseInfo courseServer = new BLL.CourseInfo();
            List<Model.CourseInfo> courseList = new List<Model.CourseInfo>();
            int pageIndex = int.Parse(context.Request["pageIndex"]);
            int pageSize = 12;
            int totalCount = courseServer.GetRecordCount(string.Empty);

            string pagination = CreatePagination.ShowPageNavigate(pageSize, pageIndex, totalCount);
            int count = courseServer.GetRecordCount(string.Empty);
            var studDataSet = courseServer.GetListByPage(string.Empty, "courseID", (pageIndex - 1) * pageSize, pageIndex * pageSize);
            courseList = courseServer.DataTableToList(studDataSet.Tables[0]);
            var paginationAndJson = new { studList = courseList, pagination = pagination };
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