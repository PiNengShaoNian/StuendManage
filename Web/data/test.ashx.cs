using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// test 的摘要说明
    /// </summary>
    public class test : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string page= CreatePagination.ShowPageNavigate(15, 2, 616);
            context.Response.Write(page);
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