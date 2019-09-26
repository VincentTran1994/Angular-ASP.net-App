using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace angularASPApp.Models
{
    public class MovieInfo
    {
        public int movieID { get; set; }
        public string movieName { get; set; }
        public DateTime publish { get; set; }
        public string author { get; set; }

    }
}
