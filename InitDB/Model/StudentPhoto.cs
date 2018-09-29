using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    public class StudentPhoto : BaseEntity
    {
        public int PhotoType { get; set; }
        public string PhotoUrl { get; set; }
        public int StudentId { get; set; }
        public virtual Student Student { get; set; }
    }
}
