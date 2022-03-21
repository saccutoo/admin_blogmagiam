using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMaGiam.Helpers
{
    public class ActionExecuting : ActionFilterAttribute
    {

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var rawUrl = HttpContext.Current.Request.RawUrl;
            if (filterContext.ActionDescriptor.ActionName.ToLower() != "login")
            {
                if (string.IsNullOrEmpty(CurrentUser.User.user_name) || string.IsNullOrEmpty(CurrentUser.User.token))
                {
                    if (filterContext.ActionDescriptor.ActionName.ToLower().Contains("sendrequestchangepass") || filterContext.ActionDescriptor.ActionName.ToLower().Contains("forgotpassword"))
                    {
                        goto Finish;
                    }
                    //           filterContext.Result = new RedirectToRouteResult(new
                    //System.Web.Routing.RouteValueDictionary(new { controller = "Authen", action = "Login", RedirectUrl = rawUrl }));
                    filterContext.Result = new RedirectToRouteResult(new
                    System.Web.Routing.RouteValueDictionary(new { controller = "Authen", action = "Login" }));
                }

                else
                {
                    Dictionary<string, DateTime> loggedInUsers = new Dictionary<string, DateTime>();

                    loggedInUsers = (Dictionary<string, DateTime>)HttpRuntime.Cache["LoggedInUsers"];

                    var userName = CurrentUser.User.user_name;
                    if (loggedInUsers != null)
                    {
                        loggedInUsers[userName] = DateTime.Now;
                        HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                    }

                    goto Finish;
                }
            }
            else
            {
                if (string.IsNullOrEmpty(CurrentUser.User.user_name) || string.IsNullOrEmpty(CurrentUser.User.token))
                {
                    goto Finish;
                }
                else
                {
                    filterContext.Result = new RedirectToRouteResult(new
        System.Web.Routing.RouteValueDictionary(new { controller = "Home", action = "Index", RedirectUrl = rawUrl }));
                }
            }

        Finish:
            base.OnActionExecuting(filterContext);
        }

    }
}