using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace newmvccore.Models
{
    public class EditViewModel:CreateViewModel
    {
        public int id { get; set; }
        public string existingphotopath { get; set; }
    }
}
