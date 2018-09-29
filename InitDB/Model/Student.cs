using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public byte Age { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual StudentContact StudentContact { get; set; }
        public virtual ICollection<StudentPhoto> StudentPhotos { get; set; }
    }
}
