using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public static class Constant
    {
        public static int Success = 1;
        public static int Error = 2;

        public static string ALL = "ALL";
        public static string DAY = "DAY";
        public static string MONTH = "MONTH";
        public static string WEEK = "WEEK";
        public static string YEAR = "YEAR";

        public static string ACTIVE = "ACTIVE";

        public static string ADMIN_BLOGMAGIAM = "BlogMaGiam";
        public static string KEY_ADMIN_BLOGMAGIAM = "key_admin_blogmagiam.com";

    }


    public enum StatusCode
    {
        Success = 0,
        FailRequired = 1,
        FailRole = -1,
        Fail = 99,
        FailSession = -99,
        FailApp = -98,
        FailFunction = -97,
        FailPermisstions = -96
    }
}
