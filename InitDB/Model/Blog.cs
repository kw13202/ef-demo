using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime? CreatedTime { get; set; }
        public double Double { get; set; }
        public float Float { get; set; }
    }
}
