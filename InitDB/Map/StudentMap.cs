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
    public class StudentMap : EntityTypeConfiguration<Student>
    {
        public StudentMap()
        {
            //表名
            ToTable("Students");

            //主键
            HasKey(x => x.Id);

            //字段
            Property(x => x.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.Age);
            Property(x => x.Name).HasMaxLength(50).IsRequired();
            Property(x => x.CreateTime);
            Property(x => x.ModifiedTime);

            //索引

            //关系
            HasMany(x => x.Courses).WithMany(x => x.Students).Map(x =>
                x.ToTable("StudentCourses").MapLeftKey("StudentId").MapRightKey("CourseId"));
            //一对一关系，Student可能有StudentContact，但StudentContact必须有Student
            HasOptional(x => x.StudentContact).WithRequired(x => x.Student);


        }

    }
}
