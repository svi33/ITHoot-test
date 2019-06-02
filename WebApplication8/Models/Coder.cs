using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication8.Models
{
    public class Coder
    {
        public int CoderID { get; set; }
        public string Name { get; set; }
        public string CoderInfo { get; set; }

        public virtual ICollection<CoderProject> projects { get; set; }
    }
}
