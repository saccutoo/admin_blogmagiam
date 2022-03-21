using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BlogMaGiam.Controllers
{
    public class BaseController : Controller
    {
        public bool CheckPermision(int status)
        {
            if (status == 404)
            {
                return false;
            }
            return true;
        }
    }
}