using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectC.DTO
{
  public class Guest
    {
        public int roomid { get; set; }
        public string status { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public int phone { get; set; }
        public int roomnumber { get; set; }

        public DateTime datein { get; set; }
        public DateTime dateout { get; set; }


    }
}
