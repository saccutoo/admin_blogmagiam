using BlogMaGiam.Services;
using BlogMaGiam.ViewModel;
using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NLog;
using Common.Models;
using Common.Helpers;
using System.Configuration;
using Newtonsoft.Json;
using BlogMaGiam.Helpers;
using System.Web.Security;

namespace BlogMaGiam.Controllers
{
    public class AuthenController : BaseController
    {

        private IAuthenService _AuthenService;
        private Logger logger = LogManager.GetCurrentClassLogger();

        public AuthenController(IAuthenService AuthenService)
        {
            _AuthenService = AuthenService;
        }
       
        [HttpGet]
        public ActionResult Login()
        {
            UserViewModel vm = new UserViewModel();
            return View(vm);
        }

        [HttpPost]
        public ActionResult Login(UserModel model)
        {
            UserViewModel vm = new UserViewModel();
            vm.Data = model;
            if (string.IsNullOrEmpty(model.user_name))
            {
                vm.Message = "Please enter username";
            }
            else if (string.IsNullOrEmpty(model.pass_word))
            {
                vm.Message = "Please enter password";
            }
            if (string.IsNullOrEmpty(vm.Message))
            {
                var passWord = Helper.EncryptString(model.pass_word, ConfigurationManager.AppSettings["KEY_PASSWORD"]);
                var response = _AuthenService.Login(model.user_name, passWord);

                if (response.StatusCode==StatusCode.Fail)
                {
                    vm.Message = response.Message;
                    return View(vm);
                }
                else if(response.Data != null)
                {
                    var stringData = JsonConvert.SerializeObject(response.Data);
                    stringData = Helper.EncryptString(stringData, ConfigurationManager.AppSettings["KEY_PASSWORD"]);
                    Security.UserSignIn(stringData, System.Web.HttpContext.Current);
                    if (HttpRuntime.Cache["LoggedInUsers"] != null)
                    {
                        Dictionary<string, DateTime> loggedInUsers = new Dictionary<string, DateTime>();

                        //get the list of logged in users from the cache
                        //var loggedInUsers = HttpRuntime.Cache["LoggedInUsers"];
                        loggedInUsers = (Dictionary<string, DateTime>)HttpRuntime.Cache["LoggedInUsers"];

                        if (!loggedInUsers.ContainsKey(response.Data.user_name))
                        {
                            //add this user to the list
                            loggedInUsers.Add(response.Data.user_name, DateTime.Now);
                            //add the list back into the cache
                            HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                        }
                    }
                    else
                    {
                        //create a new list
                        Dictionary<string, DateTime> loggedInUsers = new Dictionary<string, DateTime>();
                        //add this user to the list
                        loggedInUsers.Add(response.Data.user_name, DateTime.Now);
                        //add the list into the cache
                        HttpRuntime.Cache["LoggedInUsers"] = loggedInUsers;
                    }

                    return RedirectToAction("Index", "Home");

                }
                else
                {
                    vm.Message = "User not found";
                    return View(vm);
                }
            }
            return View(vm);
        }

        [NoCache]
        public ActionResult Logout()
        {
            if (CurrentUser.User != null && !string.IsNullOrEmpty(CurrentUser.User.user_name))
            {
                Dictionary<string, DateTime> loggedInUsers = new Dictionary<string, DateTime>();
                loggedInUsers = (Dictionary<string, DateTime>)HttpRuntime.Cache["LoggedInUsers"];
                if (loggedInUsers != null && loggedInUsers.Count() > 0 && !string.IsNullOrEmpty(CurrentUser.User.user_name))
                {
                    if (loggedInUsers.ContainsKey(CurrentUser.User.user_name))
                    {
                        loggedInUsers.Remove(CurrentUser.User.user_name);
                    }

                }
            }
            FormsAuthentication.SignOut();
            //Clear session
            var current = System.Web.HttpContext.Current;
            ////Clears out Session
            current.Response.Cookies.Clear();
            // clear authentication cookie
            current.Response.Cookies.Remove(FormsAuthentication.FormsCookieName);
            current.Response.Cache.SetExpires(DateTime.Now.AddSeconds(-1));
            HttpCookie cookie = current.Request.Cookies[FormsAuthentication.FormsCookieName];
            Security.Logout(System.Web.HttpContext.Current);
            var vm = new UserModel();
            return RedirectToAction("Login", "Authen");
        }
    }
}