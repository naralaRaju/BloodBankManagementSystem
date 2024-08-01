using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BBMS1.Models
{
    public class AdminLogin
    {
        [Required]
        public string Password { get; set; }
    }
}