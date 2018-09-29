using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Model
{
    public class Course : BaseEntity
    {
        /// <summary>
        /// 课程名称
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 课程时长
        /// </summary>
        public int MaximumStrength { get; set; }

        public virtual ICollection<Student> Students { get; set; }

    }
}
