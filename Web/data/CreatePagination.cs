﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

namespace ScoreManage.Web.data
{
    public class CreatePagination
    {
        public static string ShowPageNavigate(int pageSize, int currentPage, int totalCount)
        {
            string redirectTo = "";
            pageSize = pageSize == 0 ? 3 : pageSize;
            var totalPages = Math.Max((totalCount + pageSize - 1) / pageSize, 1); //总页数
            var output = new StringBuilder();
            if (totalPages > 1)
            {
                output.Append("<ul class='pagination'>");
                if (currentPage != 1)
                {//处理首页连接
                    output.AppendFormat("<li><a href='javascript:void(0)'>&laquo;</a></li>");
                    //output.AppendFormat("<a class='pageLink' href='{0}?pageIndex=1&pageSize={1}'>首页</a> ", redirectTo, pageSize);
                }
                if (currentPage > 1)
                {//处理上一页的连接
                    //output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>上一页</a> ", redirectTo, currentPage - 1, pageSize);
                }
                else
                {
                    // output.Append("<span class='pageLink'>上一页</span>");
                }

                output.Append(" ");
                int currint = 5;
                for (int i = 0; i <= 10; i++)
                {//一共最多显示10个页码，前面5个，后面5个
                    if ((currentPage + i - currint) >= 1 && (currentPage + i - currint) <= totalPages)
                    {
                        if (currint == i)
                        {//当前页处理
                            //output.Append(string.Format("[{0}]", currentPage));
                            output.AppendFormat("<li><a href='javascript:void(0)'>{0}</a></li>", currentPage);
                            //output.AppendFormat("<a class='cpb' href='{0}?pageIndex={1}&pageSize={2}'>{3}</a> ", redirectTo, currentPage, pageSize, currentPage);
                        }
                        else
                        {//一般页处理
                            output.AppendFormat("<li><a href='javascript:void(0)'>{0}</a></li>", currentPage + i - currint);
                        }
                    }
                    output.Append(" ");
                }
                if (currentPage < totalPages)
                {//处理下一页的链接
                    //output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>下一页</a> ", redirectTo, currentPage + 1, pageSize);
                }
                else
                {
                    //output.Append("<span class='pageLink'>下一页</span>");
                }
                output.Append(" ");
                if (currentPage != totalPages)
                {
                    output.AppendFormat("<li><a href='javascript:void(0)'>&raquo;</a></li>");
                    //output.AppendFormat("<a class='pageLink' href='{0}?pageIndex={1}&pageSize={2}'>末页</a> ", redirectTo, totalPages, pageSize);
                }
                output.Append(" ");
            }
            output.Append("</ul>");
            return output.ToString();
        }
    }
}