using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial class AuthenService : IAuthenService
    {
        private CommonService<UserModel> _commonService;
        private string urlLogin= "api/auth/login";
        private string urlLoginDefualt = "api/auth/login/token/defualt";
        private string urlBase = "api/auth";
        public AuthenService()
        {
            _commonService = new CommonService<UserModel>();
        }

        public ResponseObject<UserModel> Login (string userName,string passWord)
        {
            return _commonService.PostApi(urlLogin + "?userName="+ userName + "&passWord=" + passWord, null);
        }
       
    }
}