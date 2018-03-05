using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getStudInfoByID 的摘要说明
    /// </summary>
    public class getStudInfoByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request["studNo"].ToString();
            BLL.StudInfo studServer = new BLL.StudInfo();
            Model.StudInfo stud = studServer.GetModel(id);
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(stud);
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