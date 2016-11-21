using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanMVC.Common
{
    public static class CommonConstants
    {
        public static string USER_SESSION = "USER_SESSION";
        public const string CartSession = "CartSession";
        public static string AccountSession = "AccountSession";
        //public static string SessionCart = "SessionCart";
        public static string SESSION_ROLE = "SESSION_ROLE";
        public static string MetaSession = "MetaSession";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static int QuantityOld = 0;

        public static string CurrentCulture { set; get; }
    }
}