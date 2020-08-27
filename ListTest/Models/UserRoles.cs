using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListTest.Models
{
    public class UserRoles
    {
        
        public int IdUser { get; set; }
        public Users User{ get; set; }
        public int IdRoles { get; set; }
        public Roles Role{ get; set; }
    }
}
