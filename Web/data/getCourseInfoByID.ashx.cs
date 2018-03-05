using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getCourseInfoByID 的摘要说明
    /// </summary>
    public class getCourseInfoByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request["courseID"].ToString();
            BLL.CourseInfo courseServer = new BLL.CourseInfo();
            Model.CourseInfo course = courseServer.GetModel(id);
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(course);
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