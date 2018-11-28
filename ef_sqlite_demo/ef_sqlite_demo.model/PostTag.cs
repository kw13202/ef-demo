using System;
using System.Collections.Generic;
using System.Text;

namespace ef_sqlite_demo.model
{
    public class PostTag
    {
        public int PostId { get; set; }
        public virtual Post Post { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
