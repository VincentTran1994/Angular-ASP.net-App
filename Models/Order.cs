using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.Models
{
    public class Order
    {
        public int userID { get; set; }
        public int movieID { get; set; }
        public DateTime dateOrder { get; set; }

    }
}
