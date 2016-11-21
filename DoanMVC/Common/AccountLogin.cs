using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DoanMVC.Common
{
    [Serializable]
    public class AccountLogin
    {
        public int UserID { set; get; }
        public string UserName { set; get; }
        public string Name { set; get; }
        public string Email { set; get; }
        public string Address { set; get; }
        public string Phone { set; get; }
    }
}
