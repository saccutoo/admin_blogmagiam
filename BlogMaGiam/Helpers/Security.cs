using Common;
using Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace BlogMaGiam.Helpers
{
    public static class Security
    {
        
        public static void UserSignIn(string value, HttpContext curentHttpContext)
        {
            var token = SetAuthCookie(curentHttpContext, value, Constant.ADMIN_BLOGMAGIAM, Constant.KEY_ADMIN_BLOGMAGIAM, DateTime.Now.AddMinutes(30));
        }

        public static string SetAuthCookie(HttpContext httpContext, string authenticationTicket, string cookieName, string key, DateTime Expiration)
        {
            var encryptedTicket = Helper.EncryptString(authenticationTicket, key);
            var cookie = new HttpCookie(cookieName, encryptedTicket)
            {
                HttpOnly = false,
                Expires = Expiration
            };
            httpContext.Response.Cookies.Add(cookie);
            return encryptedTicket;
        }

        public static void Logout(HttpContext httpContext)
        {
            var cookie = new HttpCookie(Constant.ADMIN_BLOGMAGIAM);
            DateTime nowDateTime = DateTime.Now;
            cookie.Expires = nowDateTime.AddDays(-1);
            httpContext.Response.Cookies.Add(cookie);
            httpContext.Request.Cookies.Remove(Constant.ADMIN_BLOGMAGIAM);
            FormsAuthentication.SignOut();
        }

        public static void RemoveCacheByKey(HttpContext httpContext, string key)
        {
            var cookie = new HttpCookie(key);
            DateTime nowDateTime = DateTime.Now;
            cookie.Expires = nowDateTime.AddDays(-1);
            httpContext.Response.Cookies.Add(cookie);
            httpContext.Request.Cookies.Remove(key);
            FormsAuthentication.SignOut();

        }

    }
}