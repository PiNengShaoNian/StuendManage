using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// addStudByStudObj 的摘要说明
    /// </summary>
    public class addStudByStudObj : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //studNo, studName, studSex, studBirthDay, classID
            string studNo = context.Request["studNo"].ToString();
            string studName = context.Request["studName"].ToString();
            string studSex = context.Request["studSex"].ToString();
            DateTime studBirthDay = Convert.ToDateTime( context.Request["studBirthDay"].ToString());
            string classID = context.Request["classID"].ToString();
            BLL.StudInfo studServer = new BLL.StudInfo();
            Model.StudInfo stud = new Model.StudInfo(){classID=classID, studBirthDay= studBirthDay, studName =studName, studNo =studNo, studSex  = studSex};
            bool isSuccess = studServer.Add(stud);
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