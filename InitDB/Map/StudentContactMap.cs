using InitDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitDB.Map
{
    public class StudentContactMap : EntityTypeConfiguration<StudentContact>
    {
        public StudentContactMap()
        {
            //表名
            ToTable("StudentContacts");

            //主键
            HasKey(x => x.Id);

            //字段
            Property(x => x.Id).HasColumnName("StudentId").HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            //索引

            //关系

        }

    }
}
