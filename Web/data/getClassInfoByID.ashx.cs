using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// getClassInfoByID 的摘要说明
    /// </summary>
    public class getClassInfoByID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string id = context.Request["classID"].ToString();
            BLL.ClassInfo classServer = new BLL.ClassInfo();
            Model.ClassInfo classObj = classServer.GetModel(id);
            string json = new System.Web.Script.Serialization.JavaScriptSerializer().Serialize(classObj);
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