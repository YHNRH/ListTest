using ListTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListTest
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        
        public List<UserRoles> UserRoles { get; set; }

    }

}
