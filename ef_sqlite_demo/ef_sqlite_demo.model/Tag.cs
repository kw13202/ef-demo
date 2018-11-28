using System;
using System.Collections.Generic;
using System.Text;

namespace ef_sqlite_demo.model
{
    public class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public DateTime CreateTime { get; set; }
        public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
    }
}
