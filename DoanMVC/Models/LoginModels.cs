using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoanMVC.Models
{
    public class LoginModels
    {
        [Key]
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage = "Bạn phải nhập tài khoản")]
        [MaxLength(100)]
        public string UserName { set; get; }

        [Required(ErrorMessage = "Bạn phải nhập mật khẩu")]
        [Display(Name = "Mật khẩu")]
        [MaxLength(32)]
        public string Password { set; get; }
    }
}