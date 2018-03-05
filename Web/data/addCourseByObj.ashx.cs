using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// addCourseByObj 的摘要说明
    /// </summary>
    public class addCourseByObj : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string courseID, courseName, courseType, courseDesc;
            decimal courseCredit;
            courseID = context.Request["courseID"].ToString();
            courseName = context.Request["courseName"].ToString();
            courseType = context.Request["courseType"].ToString();
            courseDesc = context.Request["courseDesc"].ToString();
            courseCredit = Decimal.Parse(context.Request["courseCredit"].ToString());
            Model.CourseInfo course = new Model.CourseInfo();
            course.courseCredit = courseCredit;
            course.courseDesc = courseDesc;
            course.courseID = courseID;
            course.courseName = courseName;
            course.courseType = courseType;
            BLL.CourseInfo courseServer = new BLL.CourseInfo();
            bool isSuccess = courseServer.Add(course);
            if (isSuccess)
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