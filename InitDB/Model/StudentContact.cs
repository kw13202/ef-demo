using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    public class StudentContact
    {
        public int Id { get; set; }
        public string ContactNumber { get; set; }
        public virtual Student Student { get; set; }
    }
}
