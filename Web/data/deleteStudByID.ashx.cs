using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// deleteStudByID 的摘要说明
    /// </summary>
    public class deleteStudByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request["studNo"].ToString();
            BLL.StudInfo studServer = new BLL.StudInfo();
            bool isSuccess = studServer.Delete(id);
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