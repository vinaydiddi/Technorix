using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.CustomValidations
{
    public class DomainValiadations:ValidationAttribute
    {
        public DomainValiadations(string alloweddomain)
        {
            Alloweddomain = alloweddomain;
        }

        public string Alloweddomain { get; }

        public override bool IsValid(object value)
        {
            string[] result = value.ToString().Split("@");
            return result[1].ToUpper() == Alloweddomain.ToUpper();            
        }
    }
}
