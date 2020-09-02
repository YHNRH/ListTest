using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ListTest.Models
{
    public class Appointment
    {
        
        public int Id { get; set; }

        public string Appointment_name { get; set; }
        public Users User { get; set; }

    }
}
