using Common.Helpers;
using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BlogMaGiam.Services
{
    public partial interface IAuthenService
    {
        ResponseObject<UserModel> Login(string userName, string passWord);
    }
}