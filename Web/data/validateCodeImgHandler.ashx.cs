using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// validateCodeImgHandler 的摘要说明
    /// </summary>
    public class validateCodeImgHandler : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            ValidateCode vc = new ValidateCode();
            string str = vc.CreateValidateCode(4);
            //HttpSessionStateBase[]
            //SessionIDManager[]
            context.Session["VCode"] = str;
            vc.CreateValidateGraphic(str, context);
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