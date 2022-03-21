using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogMaGiam.ViewModel
{
    public class UserViewModel
    {
        public UserModel Data { get; set; } = new UserModel();
        public string Message { get; set; }
    }

}
