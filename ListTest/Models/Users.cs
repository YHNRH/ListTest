using ListTest.Models;
using System.Collections.Generic;

namespace ListTest
{
    public class Users
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int Age { get; set; }
        
        public List<UserRoles> UserRoles { get; set; }

        
        public Appointment Appointment   { get; set; }


    }

}
