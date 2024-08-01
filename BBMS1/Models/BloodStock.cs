using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BBMS1.Models
{
    public class BloodStock
    {
        public int Id { get; set; }
        public string BloodType { get; set; }
        public int PacketCount { get; set; }
    }
}