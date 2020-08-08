using Microsoft.AspNetCore.Authentication;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public class LoginviewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string  email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string password { get; set; }        
        [DisplayName("Remember Me")]
        public bool rememberme { get; set; }
        public string ReturnUrl { get; set; }

        // AuthenticationScheme is in Microsoft.AspNetCore.Authentication namespace
        public IList<AuthenticationScheme> ExternalLogins { get; set; }
    }
}
