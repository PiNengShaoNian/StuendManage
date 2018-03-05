using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// deleteCourseByID 的摘要说明
    /// </summary>
    public class deleteCourseByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request["courseID"].ToString();
            BLL.CourseInfo courseServer = new BLL.CourseInfo();
            bool isSueess = courseServer.Delete(id);
            if (isSueess)
            {
                context.Response.Write("ok");
            }
            else
            {
                context.Response.Write("不ok");
            }
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