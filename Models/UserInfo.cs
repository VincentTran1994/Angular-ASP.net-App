using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.Models
{
    public class UserInfo
    {
        public int userId { get; set; }
        public string email { get; set; }
        public string fName { get; set; }
        public string lName { get; set; }
        public DateTime joinDate { get; set; }
        public char gender { get; set; }
    }
}
