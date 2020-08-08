using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public class CreateViewModel
    {
       
        [Required]
        [StringLength(20, ErrorMessage = "characters exceeded")]
        public string name { get; set; }
        [Required]
        public DeptEnum ? department { get; set; }
        [Required]
        [Display(Name = "office email")]
        //[RegularExpression("\b[A-Z0-9._%+-]+@[A-Z0-9.-]+.[A-Z]{2,}\b", ErrorMessage = "Email address is not valid")]
        public string email { get; set; }
        public IFormFile photo { get; set; }
    }
}
