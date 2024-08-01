using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBMS1.Models
{
    public class Patients
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public int Age { get; set; }
        public string PhoneNo { get; set; }

        public string Gender { get; set; }

        public string BloodGroup { get; set; }
        public string Address { get; set; }
    }
}