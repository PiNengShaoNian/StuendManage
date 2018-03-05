using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// addStudScoreByObj 的摘要说明
    /// </summary>
    public class addStudScoreByObj : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string studNo, courseID, studScore;
            studNo = context.Request["studNo"].ToString();
            courseID = context.Request["courseID"].ToString();
            studScore = context.Request["studScore"].ToString();
            BLL.StudScoreInfo scoreServer = new BLL.StudScoreInfo();
            Model.StudScoreInfo score = new Model.StudScoreInfo();
            score.courseID = courseID;
            score.studNo = studNo;
            score.studScore =Decimal.Parse( studScore);
            bool isSuccess = scoreServer.Add(score);
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