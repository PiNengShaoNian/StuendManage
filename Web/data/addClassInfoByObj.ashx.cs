using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// addClassInfoByObj 的摘要说明
    /// </summary>
    public class addClassInfoByObj : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string classID, className, classDesc;
            classID = context.Request["classID"].ToString();
            className = context.Request["className"].ToString();
            classDesc = context.Request["classDesc"].ToString();
            BLL.ClassInfo classServer = new BLL.ClassInfo();
            Model.ClassInfo classObj = new Model.ClassInfo();
            classObj.classDesc = classDesc;
            classObj.className = className;
            classObj.classID = classID;
            bool isSuccess = classServer.Add(classObj);
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