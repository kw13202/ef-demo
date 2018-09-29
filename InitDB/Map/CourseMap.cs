using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InitDB.Model;

namespace InitDB.Map
{
    public class CourseMap : EntityTypeConfiguration<Course>
    {
        public CourseMap()
        {
            //表名
            ToTable("Courses");

            //主键
            HasKey(x => x.Id);

            //字段
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.MaximumStrength);
            Property(x => x.CreateTime);
            Property(x => x.ModifiedTime);

            //索引

            //关系

        }
    }
}
