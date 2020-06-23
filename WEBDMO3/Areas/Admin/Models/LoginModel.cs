using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WEBDMO3.Areas.Admin.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username Required")]
        public string Username { set; get; }
        [Required(ErrorMessage = "Password Required")]
        public string Password { set; get; }
        public bool RememberMe { set; get; }
    }
}