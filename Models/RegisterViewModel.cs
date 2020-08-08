using Microsoft.AspNetCore.Mvc;
using newmvccore.CustomValidations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public class RegisterViewModel
    {
        [Required]
        [Remote("IsemailUsed", "account")]
        [DataType(DataType.EmailAddress)]
        [DomainValiadations(alloweddomain:"gmail.com",ErrorMessage ="invalid domainname")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [DisplayName("Confirm Password")]
        [Compare("Password", ErrorMessage ="password did not match")]
        public string ConfirmPassword { get; set; }
        [Required]
        public string city { get; set; }
    }
}
