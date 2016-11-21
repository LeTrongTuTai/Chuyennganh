using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanMVC.Models
{
    public class UserGroupViewModel
    {
        public string ID { set; get; }

        [Required(ErrorMessage = "Nhập tên")]
        public string Name { set; get; }

        public string Role { set; get; }
    }
}