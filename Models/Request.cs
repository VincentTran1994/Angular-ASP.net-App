using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.Models
{
    public class Request
    {
        public int requestId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string content { get; set; }
        public DateTime dateRequest { get; set; }

    }
}
