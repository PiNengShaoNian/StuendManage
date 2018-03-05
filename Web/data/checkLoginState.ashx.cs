using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// checkLoginState 的摘要说明
    /// </summary>
    public class checkLoginState : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            if (context.Session["loginUser"] == null)
            {
                context.Response.Write("不ok");
                return;
            }
            else
            {
                context.Response.Write("ok");
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