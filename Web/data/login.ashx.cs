using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;

namespace ScoreManage.Web.data
{
    /// <summary>
    /// login 的摘要说明
    /// </summary>
    public class login : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            //context.Response.Write("Hello World");
            string name = context.Request["txtName"];

                ////解决Cookie乱码问题：Server.UrlEncode

                //context.Request.Cookies["UserName"].Value = context.Server.UrlEncode(name);
                //context.Request.Cookies["UserName"].Expires = DateTime.Now.AddDays(7);

                
               
                #region 校验验证码

                string userValdiateCode = context.Request["txtCode"];

                string sessionVCode = context.Session["VCode"] as string;
                //验证一次，立即清空
                context.Session["VCode"] = null;
                //漏洞：

                if ( string.IsNullOrEmpty(sessionVCode)||  userValdiateCode != sessionVCode)
                {
                    //Page.RegisterStartupScript("ss","<script>alert('验证码错误！')</script>");
                    //Response.Write("<script>alert('验证码错误！')</script>");
                    //StrScript = "<script>alert('验证码错误！')</script>";
                    context.Response.Write("验证码错误");
                    return;
                }



                #endregion

                #region 校验用户名密码

                string strName = context.Request["txtName"];
                string pwd = context.Request["txtPwd"];
                BLL.User userServer = new BLL.User();
                
                string strSqlWhere = string.Format(" LoginName='{0}' and PassWord='{1}' ",strName,pwd);

                List<Model.User> loginUsers = userServer.GetModelList(strSqlWhere);

                if (loginUsers.Count <= 0)
                {
                    context.Response.Write("用户名或密码错误");
                    return;
                }

                //把当前登录成功的用户信息放到了Session["loginUser"]

                context.Session["loginUser"] = loginUsers[0];
                 
                //context.Response.Redirect("../index.html");
                context.Response.Write("ok");
                #endregion
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