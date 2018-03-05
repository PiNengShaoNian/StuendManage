using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// editStudByStudObj 的摘要说明
    /// </summary>
    public class editStudByStudObj : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string studNo = context.Request["studNo"].ToString();
            string studName = context.Request["studName"].ToString();
            string studSex = context.Request["studSex"].ToString();
            string date = context.Request["studBirthDay"].ToString();
            string classID = context.Request["classID"].ToString();
            BLL.StudInfo studServer = new BLL.StudInfo();
            Model.StudInfo stud = studServer.GetModel(studNo);
            DateTime studBirthDay = Convert.ToDateTime(date == ""?stud.studBirthDay.ToString():date);
            stud.classID = classID;
            stud.studName = studName;
            stud.studNo = studNo;
            stud.studSex = studSex;
            stud.studBirthDay = studBirthDay;
            bool isSuccess = studServer.Update(stud);
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