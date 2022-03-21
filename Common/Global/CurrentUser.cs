using Common.Helpers;
using Common.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Common
{
    public static class CurrentUser
    {
        public static UserModel User
        {
            get
            {
                try
                {
                    HttpCookie getCookie = HttpContext.Current.Request.Cookies[Constant.ADMIN_BLOGMAGIAM];
                    if (getCookie != null)
                    {
                        var value = getCookie.Value;
                        string strConvertKey = Helper.DecryptString(value, Constant.KEY_ADMIN_BLOGMAGIAM);
                        strConvertKey = Helper.DecryptString(strConvertKey, ConfigurationManager.AppSettings["KEY_PASSWORD"]);
                        return JsonConvert.DeserializeObject<UserModel>(strConvertKey);
                    }
                }
                catch (Exception)
                {
                    return new UserModel();
                }
                return new UserModel();
            }
        }
    }
}
