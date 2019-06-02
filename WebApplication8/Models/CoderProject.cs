using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class CoderProject
    {
        public int CoderProjectID { get; set; }
        public int CoderID { get; set; }
        public int ProjectID { get; set; }

        public virtual Coder CoderTo { get; set; }
        public virtual Project ProjectTo { get; set; }
    }
}
