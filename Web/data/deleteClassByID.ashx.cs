using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// deleteClassByID 的摘要说明
    /// </summary>
    public class deleteClassByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string classID = context.Request["classID"].ToString();
            BLL.ClassInfo classServer = new BLL.ClassInfo();
            bool isSuccess = classServer.Delete(classID);
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