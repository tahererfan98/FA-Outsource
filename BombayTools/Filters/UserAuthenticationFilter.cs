using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Data;
using System.Data.Sql;
using System.Web.Mvc.Filters;
using EN = BombayToolsEntities.BusinessEntities;
using System.Web.Routing;

namespace BombayTools.Filters
{
    public class UserAuthenticationFilter : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            //Check Session is Empty Then set as Result is HttpUnauthorizedResult 
            if (string.IsNullOrEmpty(Convert.ToString(filterContext.HttpContext.Session["userid"])))
            {
                
                HttpCookie reqCookies = filterContext.HttpContext.Request.Cookies["BombayTool_userCookies"];
                if (reqCookies == null)
                {
                   
                    filterContext.Result = new RedirectResult("~/Home/index");
                }
                else {
                    filterContext.HttpContext.Session["userid"] = reqCookies["userid"].ToString();
                    filterContext.HttpContext.Session["mainuserid"] = reqCookies["userid"].ToString();
                    filterContext.HttpContext.Session["username"] = reqCookies["username"].ToString();
                    filterContext.HttpContext.Session["usertype"] = reqCookies["usertype"].ToString();
                    filterContext.HttpContext.Session["mode"] = reqCookies["mode"].ToString();
                    filterContext.HttpContext.Session["toUserType"] = reqCookies["toUserType"].ToString();
                    filterContext.HttpContext.Session["UserEmailID"] = reqCookies["UserEmailID"].ToString();
                    filterContext.HttpContext.Session["LoginType"] = reqCookies["LoginType"].ToString();
                    filterContext.HttpContext.Session["FullName"] = reqCookies["FullName"].ToString();
                    filterContext.HttpContext.Session["Project"] = reqCookies["Project"].ToString();
                }
                
            }
            //else
            //{
            //    filterContext.Result = new RedirectResult("~/Home/index");
            //}
        }

        //Runs after the OnAuthentication method  
        //------------//
        //OnAuthenticationChallenge:- if Method gets called when Authentication or Authorization is 
        //failed and this method is called after
        //Execution of Action Method but before rendering of View
        //------------//
        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            //We are checking Result is null or Result is HttpUnauthorizedResult 
            // if yes then we are Redirect to Error View
            if (filterContext.Result == null || filterContext.Result is HttpUnauthorizedResult)
            {
                filterContext.Result = new RedirectResult("~/Home/index");
                //filterContext.Result = new ViewResult
                //{
                //    ViewName = "~/Home/Index"

                //};
            }
        }


    }
}