using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBMS1.Models
{
    public class BloodGroup
    {
        public int Id { get; set; }
        public string A_positive{ get; set; }
        public string A_negative { get; set; }
        public string B_positive { get; set; }
        public string B_negative { get; set; }
        public string O_positive { get; set; }
        public string O_negative { get; set; }
    }
}